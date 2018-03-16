using System;
using System.Windows;

namespace VKMSmalta.View.Elements.ViewModel
{
    public class VkmLightableRectangleViewModel : ElementViewModelBase
    {
        public Visibility LightableRectangleVisibility
        {
            get { return GetProperty(() => LightableRectangleVisibility); }
            set { SetProperty(() => LightableRectangleVisibility, value); }
        }
        
        public VkmLightableRectangleViewModel(int value, string name) : base(value, name)
        {
            Value = value;
        }

        protected override void OnValueChanged()
        {
            base.OnValueChanged();

            switch (Value)
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