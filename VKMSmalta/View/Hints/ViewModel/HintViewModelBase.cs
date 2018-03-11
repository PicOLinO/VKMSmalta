using DevExpress.Mvvm;
using VKMSmalta.Services;

namespace VKMSmalta.View.Hints.ViewModel
{
    public class HintViewModelBase : ViewModelBase
    {
        protected readonly HintService hintService;

        public DelegateCommand ClickNextCommand { get; set; }

        public string HintText
        {
            get { return GetProperty(() => HintText); }
            set { SetProperty(() => HintText, value); }
        }

        public HintViewModelBase(string hintText, HintService hintService)
        {
            this.hintService = hintService;
            HintText = hintText;

            CreateCommands();
        }

        private void CreateCommands()
        {
            ClickNextCommand = new DelegateCommand(OnClickNext, CanOnClickNext);
        }

        protected virtual bool CanOnClickNext()
        {
            return true;
        }

        protected virtual void OnClickNext()
        {
            hintService.ShowNextHint();
        }
    }
}