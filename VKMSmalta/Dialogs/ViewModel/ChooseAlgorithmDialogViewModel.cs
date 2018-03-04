using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DevExpress.Mvvm;
using VKMSmalta.Dialogs.Factories;
using VKMSmalta.Domain;
using VKMSmalta.Services;
using VKMSmalta.View.ViewModel;
using Action = VKMSmalta.Domain.Action;

namespace VKMSmalta.Dialogs.ViewModel
{
    public class ChooseAlgorithmDialogViewModel : DialogViewModelBase
    {
        public ObservableCollection<Algorithm> Algorithms { get; set; }

        public Algorithm SelectedAlgorithm
        {
            get { return GetProperty(() => SelectedAlgorithm); }
            set { SetProperty(() => SelectedAlgorithm, value); }
        }

        public ChooseAlgorithmDialogViewModel(HintService hintService)
        {
            var algorithmsFactory = new AlgorithmsFactory(hintService);

            Algorithms = new ObservableCollection<Algorithm>
                         {
                             algorithmsFactory.GetPrepareToLaunchAlgorithm()
                         };
        }
    }
}