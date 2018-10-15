#region Usings

using System;
using System.Timers;
using Vkm.Smalta.View.Elements.ViewModel.Interfaces;

#endregion

namespace Vkm.Smalta.View.Elements.ViewModel
{
    public class VkmBlackTriangleArrowViewModel : ElementViewModelBase, IDisposable
    {
        private const int Coefficient = 11;

        private const int MaxValue = 10;
        private const int MinValue = 0;

        private readonly bool isInitialize;

        private readonly int startupRotation;
        private int neededRotation;

        public VkmBlackTriangleArrowViewModel(int value, string name, int startupRotation) : base(value, name)
        {
            isInitialize = true;

            Timer = new Timer(100);
            Timer.Elapsed += TimerOnElapsed;

            this.startupRotation = RotationDegrees = startupRotation;
            Value = value;

            isInitialize = false;
        }

        public int RotationDegrees
        {
            get { return GetProperty(() => RotationDegrees); }
            set { SetProperty(() => RotationDegrees, value); }
        }

        private void TimerOnElapsed(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            if (RotationDegrees < neededRotation)
            {
                RotationDegrees += 1;
            }
            else if (RotationDegrees > neededRotation)
            {
                RotationDegrees -= 1;
            }
            else
            {
                Timer.Stop();
            }
        }

        protected override void OnValueChanged()
        {
            base.OnValueChanged();

            if (Value > MaxValue || Value < MinValue)
            {
                return;
            }

            neededRotation = (Coefficient * Value) + startupRotation;

            if (isInitialize)
            {
                RotationDegrees = neededRotation;
                return;
            }

            Timer.Start();
        }

        #region IDisposable

        public void Dispose()
        {
            Timer.Elapsed -= TimerOnElapsed;
            Timer?.Dispose();
        }

        #endregion

        #region ITimingValueChangedElement

        public Timer Timer { get; }

        #endregion
    }
}