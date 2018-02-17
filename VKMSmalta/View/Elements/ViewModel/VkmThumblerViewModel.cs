using DevExpress.Mvvm;

namespace VKMSmalta.View.Elements.ViewModel
{
    public sealed class VkmThumblerViewModel : ClickableElementViewModelBase
    {
        private readonly string imageOffSource;
        private readonly string imageOnSource;

        public VkmThumblerViewModel(string imageOffSource = "/VKMSmalta;component/View/Images/ThumblerOff.png", string imageOnSource = "/VKMSmalta;component/View/Images/ThumblerOn.png")
        {
            this.imageOffSource = ImageSource = imageOffSource;
            this.imageOnSource = imageOnSource;
        }

        protected override void OnClick()
        {
            base.OnClick();

            Value = Value == 0 ? 1 : 0;
            ImageSource = ImageSource == imageOffSource ? imageOnSource : imageOffSource;

            SendActionToHistoryService();
        }
    }
}