using VKMSmalta.Domain;
using VKMSmalta.Services;

namespace VKMSmalta.Dialogs.Factories
{
    public interface IDialogFactory
    {
        void ShowInfoDialog();
        bool ShowLoginDialog();
        bool ShowRegisterDialog();
        Algorithm ShowChooseAlgorithmDialog(IHintService vm);
        bool ShowTrainingCompleteDialog();
    }
}