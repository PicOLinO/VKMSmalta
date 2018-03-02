using System;
using System.Windows;

namespace VKMSmalta.View.Elements.ViewModel
{
    public class VkmLightableRectangleViewModel : ElementViewModelBase, IValuableNamedElement
    {
        public Visibility LightableRectangleVisibility
        {
            get { return GetProperty(() => LightableRectangleVisibility); }
            set { SetProperty(() => LightableRectangleVisibility, value); }
        }
        
        public override int Value
        {
            get { return GetProperty(() => Value); }
            set { SetProperty(() => Value, value, OnValueChanged); }
        }
        
        public VkmLightableRectangleViewModel(int value, string name) : base(value, name)
        {
            OnValueChanged(value);
        }

        private void OnValueChanged(int value)
        {
            switch (value)
            {
                case 0:
                    LightableRectangleVisibility = Visibility.Collapsed;
                    break;
                case 1:
                    LightableRectangleVisibility = Visibility.Visible;
                    break;
                default:
                    throw new IndexOutOfRangeException();
            }
        }
    }
}