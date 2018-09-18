#region Usings

using DevExpress.Mvvm;
using Vkm.Smalta.Services;

#endregion

namespace Vkm.Smalta.View.Hints.ViewModel
{
    public class HintViewModelBase : ViewModelBase
    {
        protected readonly IHintService HintService;

        public HintViewModelBase(string hintText)
        {
            HintService = ServiceContainer.GetService<IHintService>();
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