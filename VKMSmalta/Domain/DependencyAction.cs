using System.Collections.Generic;
using System.Linq;
using VKMSmalta.Services;
using VKMSmalta.View.Elements.ViewModel;

namespace VKMSmalta.Domain
{
    public class DependencyAction
    {
        private readonly string dependencyElementName;
        private ElementViewModelBase DependencyElement { get; set; }
        /// <summary>
        /// Ключ: значение передающееся. Значение: значение выставляющееся у DependencyElement
        /// </summary>
        public Dictionary<int, int> DependencyValues { get; }

        public DependencyAction(string dependencyElementName, Dictionary<int, int> dependencyValues)
        {
            this.dependencyElementName = dependencyElementName;
            DependencyValues = dependencyValues;
        }

        public void SetDependencyElementValue(int value)
        {
            if (DependencyElement == null)
            {
                DependencyElement = FindElementByName(dependencyElementName);
            }
            DependencyElement.Value = DependencyValues[value];
        }

        private ElementViewModelBase FindElementByName(string elementName)
        {
            return DependencyContainer.Instance.GetAllElementsOfCurrentDevicePage().Single(e => e.Name == elementName);
        }
    }
}