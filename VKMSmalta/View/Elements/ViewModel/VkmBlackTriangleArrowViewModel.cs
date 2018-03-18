using System;
using System.Timers;
using VKMSmalta.View.Elements.ViewModel.Interfaces;

namespace VKMSmalta.View.Elements.ViewModel
{
    public class VkmBlackTriangleArrowViewModel : ElementViewModelBase, ITimingValueChangedElement, IDisposable
    {
        private const int Coefficient = 11;

        private const int MaxValue = 10;
        private const int MinValue = 0;

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

            if (Value >= MaxValue && Value <= MinValue)
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