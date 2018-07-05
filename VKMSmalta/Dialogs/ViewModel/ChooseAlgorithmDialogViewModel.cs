#region Usings

using System.Collections.ObjectModel;
using Vkm.Smalta.Dialogs.Factories;
using Vkm.Smalta.Domain;
using Vkm.Smalta.Services;

#endregion

namespace Vkm.Smalta.Dialogs.ViewModel
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