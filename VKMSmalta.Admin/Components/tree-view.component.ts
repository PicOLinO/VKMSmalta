import { Component } from '@angular/core';
import { TreeView } from './tree-view.directive';
import { ProjectRoleService } from '../../services/project-role.service';
import swal from 'sweetalert2';

@Component({
    selector: 'tree-view-menu',
    template: '<tree-view [menuList]="menuList"></tree-view>',
    styleUrls: ['./tree-view.css']
})
export class TreeViewComponent {
    public roleName: string;
    menuList: any;
    constructor(private _projectService: ProjectRoleService) {
    }
    ngOnInit() {
        this.roleName = "Admin";
        this._projectService.getMenuDetails(this.roleName).then((res: any) => {
            this.menuList = res;
        }, (error) => {
            swal("Failed to get Treeview menu details", error._body, "error");
        });
    }
}  