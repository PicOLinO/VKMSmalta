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
        private readonly DependencyType type;
        private readonly string dependencyElementName;
        private ElementViewModelBase DependencyElement { get; set; }
        private int DelayedTimeInSeconds { get; }
        /// <summary>
        /// Ключ: значение передающееся. Значение: значение выставляющееся у DependencyElement
        /// </summary>
        private Dictionary<int, int> DependencyValues { get; }

        public DependencyAction(DependencyType type, string dependencyElementName, Dictionary<int, int> dependencyValues, int delayedTimeInSeconds = 0)
        {
            this.type = type;
            this.dependencyElementName = dependencyElementName;
            DependencyValues = dependencyValues;
            DelayedTimeInSeconds = delayedTimeInSeconds;
        }

        public async Task UpdateDependencyElementValue(int value)
        {
            if (DelayedTimeInSeconds != 0)
            {
                await Task.Delay(TimeSpan.FromSeconds(DelayedTimeInSeconds));
            }

            DependencyElement = FindElementByName(dependencyElementName);

            switch (type)
            {
                case DependencyType.Replace:
                    DependencyElement.Value = DependencyValues[value];
                    break;
                case DependencyType.Add:
                    DependencyElement.Value += DependencyValues[value];
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            
        }

        private ElementViewModelBase FindElementByName(string elementName)
        {
            return DependencyContainer.Instance.GetAllElementsOfCurrentDevicePage().Single(e => e.Name == elementName);
        }
    }
}