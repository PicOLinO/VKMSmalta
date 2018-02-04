using DevExpress.Mvvm;

namespace VKMSmalta.View.Elements.ViewModel
{
    public class VkmThumblerViewModel : ElementViewModelBase
    {
        private readonly string imageOffSource;
        private readonly string imageOnSource;

        public DelegateCommand ClickCommand { get; set; }

        public string ImageSource
        {
            get { return GetProperty(() => ImageSource); }
            set { SetProperty(() => ImageSource, value); }
        }

        public VkmThumblerViewModel(string imageOffSource = "/VKMSmalta;component/View/Images/ThumblerOff.png", string imageOnSource = "/VKMSmalta;component/View/Images/ThumblerOn.png")
        {
            this.imageOffSource = ImageSource = imageOffSource;
            this.imageOnSource = imageOnSource;

            CreateCommands();
        }

        private void CreateCommands()
        {
            ClickCommand = new DelegateCommand(OnClick);
        }

        private void OnClick()
        {
            ImageSource = ImageSource == imageOffSource ? imageOnSource : imageOffSource;
        }
    }
}