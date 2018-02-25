using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DevExpress.Mvvm;
using VKMSmalta.Dialogs.Factories;
using VKMSmalta.Domain;
using VKMSmalta.View.ViewModel;
using Action = VKMSmalta.Domain.Action;

namespace VKMSmalta.Dialogs.ViewModel
{
    public class ChooseAlgorithmDialogViewModel : ViewModelBase
    {
        public ObservableCollection<Algorithm> Algorithms { get; set; }

        public Algorithm SelectedAlgorithm
        {
            get { return GetProperty(() => SelectedAlgorithm); }
            set { SetProperty(() => SelectedAlgorithm, value); }
        }

        public ChooseAlgorithmDialogViewModel()
        {
            Algorithms = new ObservableCollection<Algorithm>
                         {
                             AlgorithmsFactory.GetPrepareToLaunchAlgorithm()
                         };
        }
    }
}