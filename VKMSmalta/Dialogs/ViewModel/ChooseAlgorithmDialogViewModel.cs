using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DevExpress.Mvvm;
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
            var newAlgorithm = new Algorithm
                           {
                               Name = "Test Algorithm",
                               Actions = new LinkedList<Action>(new []
                                                                {
                                                                    new Action(ActionName.Click, "vkt101", new HintViewModel("somehint"))
                                                                })
                           };

            Algorithms = new ObservableCollection<Algorithm> {newAlgorithm};
        }
    }
}