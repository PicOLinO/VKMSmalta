#region Usings

#endregion

using System;

namespace Vkm.Smalta.View.Elements.ViewModel
{
    public sealed class VkmRotateStepWheelViewModel : ClickableElementViewModelBase
    {
        private readonly int maxValue;
        private readonly int rotationStepDegrees;
        private readonly int startupRotation;

        public VkmRotateStepWheelViewModel(int value, string name, int startupRotation, int rotationStepDegrees, int maxValue, string image, int posTop, int posLeft, Enum page) : base(value, name, posTop, posLeft, page)
        {
            this.startupRotation = RotationDegrees = startupRotation;
            this.rotationStepDegrees = rotationStepDegrees;
            this.maxValue = maxValue;
            ImageSource = image;
            Value = value;
        }

        public int RotationDegrees
        {
            get { return GetProperty(() => RotationDegrees); }
            set { SetProperty(() => RotationDegrees, value); }
        }

        protected override void OnMouseLeftButtonUp()
        {
            base.OnMouseLeftButtonUp();

            if (Value < maxValue - 1)
            {
                Value += 1;
            }
            else
            {
                Value = 0;
            }
        }

        protected override void OnValueChanged()
        {
            base.OnValueChanged();

            if (Value > maxValue)
            {
                Value = 0;
                return;
            }

            RotationDegrees = (Value * rotationStepDegrees) + startupRotation;
        }
    }
}