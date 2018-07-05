#region Usings

using System;

#endregion

namespace Vkm.Smalta.View.Elements.ViewModel
{
    public class VkmLampViewModel : ElementViewModelBase
    {
        private readonly string imageOffSource;
        private readonly string imageOnSource;

        public VkmLampViewModel(int value, string name, string imageOnSource, string imageOffSource) : base(value, name)
        {
            this.imageOnSource = imageOnSource;
            this.imageOffSource = imageOffSource;
            Value = value;
        }

        protected override void OnValueChanged()
        {
            base.OnValueChanged();

            switch (Value)
            {
                case 0:
                    ImageSource = imageOffSource;
                    break;
                case 1:
                    ImageSource = imageOnSource;
                    break;
                default:
                    throw new IndexOutOfRangeException();
            }
        }
    }
}