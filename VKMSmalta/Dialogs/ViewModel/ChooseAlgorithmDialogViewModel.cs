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
            //TODO: Добавить фабрику по производству Algorithm
            var newAlgorithm = CreateTestAlgorithm();

            Algorithms = new ObservableCollection<Algorithm> {newAlgorithm};
        }

        private Algorithm CreateTestAlgorithm()
        {
            var startStateOfElements = new Dictionary<string, int>
                                       {
                                           {"vkt101", 0},
                                           {"vkwhl", 1}
                                       };
            var endStateOfElements = new Dictionary<string, int>
                                     {
                                         {"vkt101", 1},
                                         {"vkwhl", 4}
                                     };

            var newAlgorithm = new Algorithm(startStateOfElements, endStateOfElements)
                               {
                                   Name = "Test Algorithm",
                                   Actions = new LinkedList<Action>(new[]
                                                                    {
                                                                        //TODO: Добавить фабрику по производству Action
                                                                        new Action(ActionName.Click, "vkt101", new HintViewModel("some hint", 1)),
                                                                        new Action(ActionName.Click, "vkt101", new HintViewModel("some hint 2", 0)),
                                                                        new Action(ActionName.Click, "vkwhl", new HintViewModel("some hint for wheel", 2))
                                                                    })
                               };

            return newAlgorithm;
        }
    }
}