var Resnyanskiy;
(function (Resnyanskiy) {
    function createElement(tagName, className, id) {
        var result = document.createElement(tagName);
        if (className)
            result.className = className;
        if (id)
            result.id = id;
        return result;
    }
    function parseIdString(idString) {
        return parseInt(/\d+$/.exec(idString)[0], 10);
    }
    class TreeNode {
        constructor(id, title, isBranch) {
            this.id = id;
            this.title = title;
            this.isBranch = isBranch;
            this.items = {};
        }
        convertId(id) {
            return "+" + id;
        }
        addItem(item) {
            var itemId = item.id;
            if (this.findItem(itemId, false) == null) {
                this.items[this.convertId(itemId)] = item;
            }
        }
        removeItem(id) {
            delete this.items[this.convertId(id)];
        }
        findItem(id, deep) {
            var result = this.items[this.convertId(id)];
            if (!deep || result)
                return result;
            for (var n in this.items) {
                result = this.items[n].findItem(id, deep);
                if (result)
                    return result;
            }
        }
        getItems() {
            return this.items;
        }
        hasItems() {
            return Object.keys(this.items).length > 0;
        }
        getView() {
            var listNodeContent = createElement("a");
            listNodeContent.setAttribute("href", "#");
            listNodeContent.appendChild(document.createTextNode(this.title));
            var listItem = createElement("li", this.isBranch ? "branch" : null, "li-" + this.id);
            listItem.appendChild(createElement("span", "connector"));
            listItem.appendChild(createElement("span", "icon"));
            listItem.appendChild(listNodeContent);
            if (this.isBranch)
                listItem.appendChild(createElement("ul", null, "ul-" + this.id));
            return listItem;
        }
    }
    Resnyanskiy.TreeNode = TreeNode;
    class Tree {
        constructor(container, nodes) {
            this.toggleBranchItemsVisibleClosure = (ev) => {
                var nodeId = parseIdString(ev.target.parentNode.attributes["id"].value);
                var node = this.rootNode.findItem(nodeId, true);
                if (!this.toggleNodeItemsVisible(node) && (this.onBranchExpand instanceof Function)) {
                    this.treeContainer.querySelector("li#li-" + nodeId).classList.add("loading");
                    this.onBranchExpand(nodeId);
                }
            };
            this.onNodeClickClosure = (ev) => {
                var nodeId = parseIdString(ev.target.parentNode.attributes["id"].value);
                if (this.onNodeClick instanceof Function)
                    this.onNodeClick(nodeId);
            };
            this.rootNode = new TreeNode(0, "root", true);
            var ulElement = container.querySelector("ul");
            if (ulElement) {
                this.parseULElement(ulElement, 0);
                container.removeChild(ulElement);
            }
            this.treeContainer = createElement("ul", "container");
            if (nodes)
                for (var n in nodes)
                    this.rootNode.addItem(nodes[n]);
            this.renderNodeItemsTo(this.treeContainer, this.rootNode);
            container.classList.add("resnyanskiy-tree");
            container.appendChild(this.treeContainer);
        }
        parseULElement(ulElement, nodeId) {
            var node = nodeId == 0 ? this.rootNode : this.rootNode.findItem(nodeId, true);
            var ulElementContent = ulElement.childNodes;
            for (var i = 0; i < ulElementContent.length; i++) {
                var listItem = ulElementContent[i];
                if (listItem instanceof HTMLLIElement) {
                    var id = parseIdString(listItem.id);
                    var itemsContainer = listItem.querySelector("ul");
                    var isBranch = itemsContainer != undefined;
                    var nodeTitle;
                    var listItemContent = listItem.childNodes;
                    for (var j = 0; j < listItemContent.length; j++) {
                        var item = listItemContent[j];
                        if (item.nodeType == Node.TEXT_NODE) {
                            nodeTitle = item.textContent.trim();
                            break;
                        }
                    }
                    node.addItem(new TreeNode(id, nodeTitle, isBranch));
                    if (isBranch)
                        this.parseULElement(itemsContainer, id);
                }
            }
        }
        renderNodeItemsTo(ulElement, node) {
            var nodeItems = node.getItems();
            for (var id in nodeItems) {
                var nodeItem = nodeItems[id];
                ulElement.appendChild(nodeItem.getView());
            }
            var branchConnectorNodeList = ulElement.querySelectorAll("li.branch > span.connector");
            for (var i = 0; i < branchConnectorNodeList.length; i++) {
                var connectorNode = branchConnectorNodeList[i];
                connectorNode.addEventListener("click", this.toggleBranchItemsVisibleClosure);
            }
            var contentNodeList = ulElement.querySelectorAll("li > a");
            for (var i = 0; i < contentNodeList.length; i++) {
                var contentNode = contentNodeList[i];
                contentNode.addEventListener("click", this.onNodeClickClosure);
            }
        }
        toggleNodeItemsVisible(node) {
            if (node && node.hasItems()) {
                var ulElement = this.treeContainer.querySelector("ul#ul-" + node.id);
                if (ulElement.hasChildNodes()) {
                    while (ulElement.firstChild)
                        ulElement.removeChild(ulElement.firstChild);
                    ulElement.parentNode.classList.remove("opened");
                }
                else {
                    this.renderNodeItemsTo(ulElement, node);
                    ulElement.parentNode.classList.add("opened");
                }
                return true;
            }
            else {
                return false;
            }
        }
        updateNode(id, items, showNodeItems) {
            var node = this.rootNode.findItem(id, true);
            for (var i in items)
                node.addItem(items[i]);
            this.treeContainer.querySelector("li#li-" + id).classList.remove("loading");
            if (showNodeItems)
                this.toggleNodeItemsVisible(node);
        }
    }
    Resnyanskiy.Tree = Tree;
})(Resnyanskiy || (Resnyanskiy = {}));
//# sourceMappingURL=resnyanskiy.js.tree.js.map