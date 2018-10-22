#region Usings

using System;

#endregion

namespace Vkm.ComplexSim.View.Elements.ViewModel
{
    public class VkmLampViewModel : ElementViewModelBase
    {
        private readonly string imageOffSource;
        private readonly string imageOnSource;

        public VkmLampViewModel(int value, string name, string imageOnSource, string imageOffSource, int posTop, int posLeft, Enum page) : base(value, name, posTop, posLeft, page)
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