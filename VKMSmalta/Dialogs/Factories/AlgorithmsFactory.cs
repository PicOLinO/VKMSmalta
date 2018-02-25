using System.Collections.Generic;
using VKMSmalta.Domain;
using VKMSmalta.View.ViewModel;

namespace VKMSmalta.Dialogs.Factories
{
    public static class AlgorithmsFactory
    {
        public static Algorithm GetPrepareToLaunchAlgorithm()
        {
            var endStateOfElements = new Dictionary<string, int>
                                     {
                                         {"thumbler_light", 1},
                                         {"thumbler_1channel", 1},
                                         {"thumbler_2channel", 1},
                                         {"thumbler_3channel", 1},
                                         {"thumbler_4channel", 1},
                                         {"thumbler_imitator", 0}
                                     };

            var newAlgorithm = new Algorithm(null, endStateOfElements)
                               {
                                   Name = "Подготовка изделия Л001 к включению",
                                   Actions = new LinkedList<Action>(new[]
                                                                    {
                                                                        ActionsFactory.GetClickAction("thumbler_light", "Установите данный тумблер в положение ПОДСВЕТ", 1),
                                                                        ActionsFactory.GetClickAction("thumbler_1channel", "Установите данный тумблер в положение I КАНАЛ", 1),
                                                                        ActionsFactory.GetClickAction("thumbler_2channel", "Установите данный тумблер в положение II КАНАЛ", 1),
                                                                        ActionsFactory.GetClickAction("thumbler_3channel", "Установите данный тумблер в положение III КАНАЛ", 1),
                                                                        ActionsFactory.GetClickAction("thumbler_4channel", "Установите данный тумблер в положение IV КАНАЛ", 1),
                                                                        ActionsFactory.GetClickAction("thumbler_imitator", "Установите данный тумблер в положение ОТКЛ.", 0),
                                                                    })
                               };

            return newAlgorithm;
        }
    }
}