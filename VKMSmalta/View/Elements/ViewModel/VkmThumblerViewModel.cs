using System;
using DevExpress.Mvvm;

namespace VKMSmalta.View.Elements.ViewModel
{
    public sealed class VkmThumblerViewModel : ClickableElementViewModelBase
    {
        private int value;
        private readonly string imageOffSource;
        private readonly string imageOnSource;

        public override int Value
        {
            get => value;
            set
            {
                this.value = value;
                switch (value)
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

        public VkmThumblerViewModel(int value, string name, string imageOffSource = "/VKMSmalta;component/View/Images/ThumblerOff.png", string imageOnSource = "/VKMSmalta;component/View/Images/ThumblerOn.png") : base(value, name)
        {
            this.imageOffSource = imageOffSource;
            this.imageOnSource = imageOnSource;
            Value = value;
        }

        protected override void OnClick()
        {
            base.OnClick();

            Value = Value == 0 ? 1 : 0;

            SendActionToHistoryService();
        }
    }
}