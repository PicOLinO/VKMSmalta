﻿#region Usings

#endregion

using System;
using System.Windows.Input;
using DevExpress.Mvvm;

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

            MouseRightButtonUpCommand = new DelegateCommand(OnMouseRightButtonUp);
        }

        public ICommand MouseRightButtonUpCommand { get; set; }

        public int RotationDegrees
        {
            get { return GetProperty(() => RotationDegrees); }
            set { SetProperty(() => RotationDegrees, value); }
        }

        private void OnMouseRightButtonUp()
        {
            if (Value == 0)
            {
                Value = maxValue - 1;
            }
            else
            {
                Value -= 1;
            }
        }

        protected override void Interact()
        {
            base.Interact();
            
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