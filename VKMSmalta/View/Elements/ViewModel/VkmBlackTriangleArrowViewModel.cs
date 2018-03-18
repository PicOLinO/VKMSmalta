using System;
using System.Timers;
using VKMSmalta.View.Elements.ViewModel.Interfaces;

namespace VKMSmalta.View.Elements.ViewModel
{
    public class VkmBlackTriangleArrowViewModel : ElementViewModelBase, ITimingValueChangedElement, IDisposable
    {
        private const int Coefficient = 11;

        private readonly int maxValue;
        private readonly int minValue;

        private readonly int startupRotation;
        private int neededRotation;

        private readonly bool isInitialize;

        public Timer Timer { get; }

        public int RotationDegrees
        {
            get { return GetProperty(() => RotationDegrees); }
            set { SetProperty(() => RotationDegrees, value); }
        }

        protected override void OnValueChanged()
        {
            base.OnValueChanged();

            if (Value >= maxValue && Value <= minValue)
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

        public VkmBlackTriangleArrowViewModel(int value, string name, int startupRotation) : base(value, name)
        {
            isInitialize = true;

            Timer = new Timer(100);
            Timer.Elapsed += TimerOnElapsed;

            maxValue = 10;
            minValue = 0;

            this.startupRotation = RotationDegrees = startupRotation;
            Value = value;

            isInitialize = false;
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

        public void Dispose()
        {
            Timer.Elapsed -= TimerOnElapsed;
            Timer?.Dispose();
        }
    }
}