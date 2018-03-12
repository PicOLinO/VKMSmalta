using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VKMSmalta.Services;
using VKMSmalta.View.Elements.ViewModel;

namespace VKMSmalta.Domain
{
    public class DependencyAction
    {
        private readonly string dependencyElementName;
        private ElementViewModelBase DependencyElement { get; set; }
        private int DelayedTimeInSeconds { get; }
        /// <summary>
        /// Ключ: значение передающееся. Значение: значение выставляющееся у DependencyElement
        /// </summary>
        private Dictionary<int, int> DependencyValues { get; }

        public DependencyAction(string dependencyElementName, Dictionary<int, int> dependencyValues, int delayedTimeInSeconds = 0)
        {
            this.dependencyElementName = dependencyElementName;
            DependencyValues = dependencyValues;
            DelayedTimeInSeconds = delayedTimeInSeconds;
        }

        public async Task SetDependencyElementValue(int value)
        {
            if (DelayedTimeInSeconds != 0)
            {
                await Task.Delay(TimeSpan.FromSeconds(DelayedTimeInSeconds));
            }

            DependencyElement = FindElementByName(dependencyElementName);
            DependencyElement.Value = DependencyValues[value];
        }

        private ElementViewModelBase FindElementByName(string elementName)
        {
            return DependencyContainer.Instance.GetAllElementsOfCurrentDevicePage().Single(e => e.Name == elementName);
        }
    }
}