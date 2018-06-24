#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VKMSmalta.Services;
using VKMSmalta.View.Elements.ViewModel;

#endregion

namespace VKMSmalta.Domain
{
    public class DependencyAction
    {
        private readonly string dependencyElementName;
        private readonly DependencyType type;

        public DependencyAction(DependencyType type, string dependencyElementName, Dictionary<int, int> dependencyValues, int delayedTimeInSeconds = 0)
        {
            this.type = type;
            this.dependencyElementName = dependencyElementName;
            DependencyValues = dependencyValues;
            DelayedTimeInSeconds = delayedTimeInSeconds;
        }

        private int DelayedTimeInSeconds { get; }
        private ElementViewModelBase DependencyElement { get; set; }

        /// <summary>
        /// Ключ: значение передающееся. Значение: значение выставляющееся у DependencyElement
        /// </summary>
        private Dictionary<int, int> DependencyValues { get; }

        private ElementViewModelBase FindElementByName(string elementName)
        {
            return DependencyContainer.Instance.GetAllElementsOfCurrentDevicePage().Single(e => e.Name == elementName);
        }

        public async Task UpdateDependencyElementValue(int value, System.Action dependencyActionsCounterCallback = null)
        {
            if (DelayedTimeInSeconds > 0)
            {
                await Task.Delay(TimeSpan.FromSeconds(DelayedTimeInSeconds));
            }

            if (DependencyElement == null)
            {
                DependencyElement = FindElementByName(dependencyElementName);
            }

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

            dependencyActionsCounterCallback?.Invoke();
        }
    }
}