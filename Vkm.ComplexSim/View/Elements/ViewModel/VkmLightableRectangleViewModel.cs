#region Usings

using System;
using System.Windows.Media;

#endregion

namespace Vkm.ComplexSim.View.Elements.ViewModel
{
    public class VkmLightableRectangleViewModel : ElementViewModelBase
    {
        public VkmLightableRectangleViewModel(int value, string name, string text, Color backgroundColor, int posTop, int posLeft, Enum page) : base(value, name, posTop, posLeft, page)
        {
            Value = value;
            Text = text;
            BackgroundColor = backgroundColor;
        }

        public Color BackgroundColor
        {
            get { return GetProperty(() => BackgroundColor); }
            set { SetProperty(() => BackgroundColor, value); }
        }

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