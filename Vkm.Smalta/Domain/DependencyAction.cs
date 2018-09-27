#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Vkm.Smalta.Services;
using Vkm.Smalta.View.Elements.ViewModel;

#endregion

namespace Vkm.Smalta.Domain
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

        public bool CancellationToken { private get; set; }

        private int DelayedTimeInSeconds { get; }
        private ElementViewModelBase DependencyElement { get; set; }

        /// <summary>
        /// Ключ: значение передающееся. Значение: значение выставляющееся у DependencyElement
        /// </summary>
        private Dictionary<int, int> DependencyValues { get; }

        private void AddDelepndencyElementValueCore(int newValue)
        {
            DependencyElement.Value += DependencyValues[newValue];
        }

        private ElementViewModelBase FindElementByName(string elementName)
        {
            return CurrentDevicePageService.Instance.GetAllElementsOfCurrentDevicePage().Single(e => e.Name == elementName);
        }

        private void UpdateDependencyElementValueCore(int newValue)
        {
            DependencyElement.Value = DependencyValues[newValue];
        }

        public async Task UpdateDependencyElementValue(int value, Action<string> dependencyActionsCounterCallback = null)
        {
            if (DelayedTimeInSeconds > 0)
            {
                await Task.Delay(TimeSpan.FromSeconds(DelayedTimeInSeconds));
                if (CancellationToken)
                {
                    return;
                }
            }

            if (DependencyElement == null)
            {
                DependencyElement = FindElementByName(dependencyElementName);
            }

            switch (type)
            {
                case DependencyType.Replace:
                    await Application.Current.Dispatcher.BeginInvoke((System.Action) (() => UpdateDependencyElementValueCore(value)));
                    break;
                case DependencyType.Add:
                    await Application.Current.Dispatcher.BeginInvoke((System.Action) (() => AddDelepndencyElementValueCore(value)));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            dependencyActionsCounterCallback?.Invoke(dependencyElementName);
        }
    }
}