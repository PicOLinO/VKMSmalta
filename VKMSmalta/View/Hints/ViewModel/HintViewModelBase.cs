#region Usings

using DevExpress.Mvvm;
using VKMSmalta.Services;

#endregion

namespace VKMSmalta.View.Hints.ViewModel
{
    public class HintViewModelBase : ViewModelBase
    {
        protected readonly HintService HintService;

        public HintViewModelBase(string hintText, HintService hintService)
        {
            HintService = hintService;
            HintText = hintText;

            CreateCommands();
        }

        public DelegateCommand ClickNextCommand { get; set; }

        public string HintText
        {
            get { return GetProperty(() => HintText); }
            set { SetProperty(() => HintText, value); }
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
            HintService.ShowNextHint();
        }
    }
}