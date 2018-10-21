#region Usings

using System.Collections.Generic;
using System.Collections.ObjectModel;
using Vkm.ComplexSim.Domain;

#endregion

namespace Vkm.ComplexSim.Dialogs.ViewModel
{
    public class ChooseAlgorithmDialogViewModel : DialogViewModelBase
    {
        public ChooseAlgorithmDialogViewModel(IEnumerable<Algorithm> algorithms)
        {
            Algorithms = new ObservableCollection<Algorithm>(algorithms);
        }

        public ObservableCollection<Algorithm> Algorithms { get; set; }

        public Algorithm SelectedAlgorithm
        {
            get { return GetProperty(() => SelectedAlgorithm); }
            set { SetProperty(() => SelectedAlgorithm, value); }
        }
    }
}