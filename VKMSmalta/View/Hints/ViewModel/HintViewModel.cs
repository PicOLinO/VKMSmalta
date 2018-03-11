using DevExpress.Mvvm;
using VKMSmalta.Services;

namespace VKMSmalta.View.Hints.ViewModel
{
    public class HintViewModel : ViewModelBase
    {
        private readonly int accessibleValue;
        private readonly HintService hintService;

        public DelegateCommand ClickNextCommand { get; set; }

        public string HintText
        {
            get { return GetProperty(() => HintText); }
            set { SetProperty(() => HintText, value); }
        }

        public HintViewModel(string hintText, int accessibleValue, HintService hintService)
        {
            this.accessibleValue = accessibleValue;
            this.hintService = hintService;
            HintText = hintText;

            CreateCommands();
        }

        private void CreateCommands()
        {
            ClickNextCommand = new DelegateCommand(OnClickNext, CanOnClickNext);
        }

        private bool CanOnClickNext()
        {
            var element = hintService.GetValuableElementByCurrentHint();
            return element?.Value == accessibleValue;
        }

        private void OnClickNext()
        {
            hintService.ShowNextHint();
        }
    }
}