#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Vkm.Smalta.Services;
using Vkm.Smalta.View.Elements.ViewModel;
using Vkm.Smalta.View.ViewModel;

#endregion

namespace Vkm.Smalta.Domain
{
    public class DependencyAction
    {
        private readonly string dependencyElementName;
        private readonly int? dependencyCoefficient;
        private readonly DependencyType type;

        public DependencyAction(DependencyType type, string dependencyElementName, Dictionary<int, int> dependencyValues = null, int? dependencyCoefficient = null, int delayedTimeInSeconds = 0)
        {
            this.type = type;
            this.dependencyElementName = dependencyElementName;
            this.dependencyCoefficient = dependencyCoefficient;
            DependencyValues = dependencyValues;
            DelayedTimeInSeconds = delayedTimeInSeconds;
        }

        public bool CancellationToken { private get; set; }

        private int DelayedTimeInSeconds { get; }
        private ElementViewModelBase DependencyElement => DevicePageViewModel.Instance.GetElementByName(dependencyElementName);

        /// <summary>
        /// Ключ: значение передающееся. Значение: значение выставляющееся у DependencyElement
        /// </summary>
        private Dictionary<int, int> DependencyValues { get; }

        private void AddDependencyElementValueCore(int newValue)
        {
            if (DependencyValues.ContainsKey(newValue))
            {
                DependencyElement.Value += DependencyValues[newValue];
            }
        }

        private void UpdateDependencyElementValueCore(int newValue)
        {
            if (DependencyValues.ContainsKey(newValue))
            {
                DependencyElement.Value = DependencyValues[newValue];
            }
        }

        private void UpdateDependencyElementValueByCoefficientCore(int sourceValue)
        {
            if (dependencyCoefficient != null)
            {
                DependencyElement.Value = sourceValue * dependencyCoefficient.Value;
            }
        }

        private void AddDependencyElementValueByCoefficientCore(int sourceValue)
        {
            if (dependencyCoefficient != null)
            {
                DependencyElement.Value += sourceValue * dependencyCoefficient.Value;
            }
        }

        public async Task UpdateDependencyElementValueAsync(int value, Action<string> dependencyActionsCounterCallback = null)
        {
            if (DelayedTimeInSeconds > 0)
            {
                await Task.Delay(TimeSpan.FromSeconds(DelayedTimeInSeconds));
                if (CancellationToken)
                {
                    return;
                }
            }

            switch (type)
            {
                case DependencyType.Replace:
                    await Application.Current.Dispatcher.BeginInvoke((System.Action) (() => UpdateDependencyElementValueCore(value)));
                    break;
                case DependencyType.Add:
                    await Application.Current.Dispatcher.BeginInvoke((System.Action) (() => AddDependencyElementValueCore(value)));
                    break;
                case DependencyType.CoefficientReplace:
                    await Application.Current.Dispatcher.BeginInvoke((System.Action)(() => UpdateDependencyElementValueByCoefficientCore(value)));
                    break;
                case DependencyType.CoefficientAdd:
                    await Application.Current.Dispatcher.BeginInvoke((System.Action)(() => AddDependencyElementValueByCoefficientCore(value)));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            dependencyActionsCounterCallback?.Invoke(dependencyElementName);
        }
    }
}