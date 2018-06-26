#region Usings

using System.Collections.ObjectModel;
using VKMSmalta.Dialogs.Factories;
using VKMSmalta.Domain;
using VKMSmalta.Services;

#endregion

namespace VKMSmalta.Dialogs.ViewModel
{
    public class ChooseAlgorithmDialogViewModel : DialogViewModelBase
    {
        public ChooseAlgorithmDialogViewModel(IHintService hintService)
        {
            var algorithmsFactory = new AlgorithmsFactory(hintService);

            Algorithms = new ObservableCollection<Algorithm>
                         {
                             algorithmsFactory.GetPrepareToLaunchAlgorithm(),
                             algorithmsFactory.GetLaunchAlgorithm(),
                             algorithmsFactory.GetStopAlgorithm()
                         };
        }

        public ObservableCollection<Algorithm> Algorithms { get; set; }

        public Algorithm SelectedAlgorithm
        {
            get { return GetProperty(() => SelectedAlgorithm); }
            set { SetProperty(() => SelectedAlgorithm, value); }
        }
    }
}