#region Usings

using System.Collections.Generic;
using System.Collections.ObjectModel;
using Vkm.Smalta.Dialogs.Factories;
using Vkm.Smalta.Domain;
using Vkm.Smalta.Services;

#endregion

namespace Vkm.Smalta.Dialogs.ViewModel
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