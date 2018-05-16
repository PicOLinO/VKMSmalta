using System;
using System.Windows;
using System.Windows.Media;

namespace VKMSmalta.View.Elements.ViewModel
{
    public class VkmLightableRectangleViewModel : ElementViewModelBase
    {
        public double LightableRectangleOpacity
        {
            get { return GetProperty(() => LightableRectangleOpacity); }
            set { SetProperty(() => LightableRectangleOpacity, value); }
        }

        public string Text
        {
            get { return GetProperty(() => Text); }
            set { SetProperty(() => Text, value); }
        }

        public Color BackgroundColor
        {
            get { return GetProperty(() => BackgroundColor); }
            set { SetProperty(() => BackgroundColor, value); }
        }

        public VkmLightableRectangleViewModel(int value, string name, string text, Color backgroundColor) : base(value, name)
        {
            Value = value;
            Text = text;
            BackgroundColor = backgroundColor;
        }

        protected override void OnValueChanged()
        {
            base.OnValueChanged();

            switch (Value)
            {
                case 0:
                    LightableRectangleOpacity = 0.3;
                    break;
                case 1:
                    LightableRectangleOpacity = 1;
                    break;
                default:
                    throw new IndexOutOfRangeException();
            }
        }
    }
}