using System.Collections.Generic;
using VKMSmalta.Domain;
using VKMSmalta.Services;
using VKMSmalta.View.ViewModel;

namespace VKMSmalta.Dialogs.Factories
{
    public class AlgorithmsFactory
    {
        private readonly HintService hintService;

        public AlgorithmsFactory(HintService hintService)
        {
            this.hintService = hintService;
        }

        public Algorithm GetPrepareToLaunchAlgorithm()
        {
            var actionsFactory = new ActionsFactory(hintService);

            var startStateOfElements = new Dictionary<string, int>
                                       {
                                           //TODO:
                                       };

            var endStateOfElements = new Dictionary<string, int>
                                     {
                                         {"main_thumbler_light", 1},
                                         {"main_thumbler_1channel", 1},
                                         {"main_thumbler_2channel", 1},
                                         {"main_thumbler_3channel", 1},
                                         {"main_thumbler_4channel", 1},
                                         {"main_thumbler_simulator", 0},
                                         {"adv_reciever_1channel", 1},
                                         {"adv_reciever_2channel", 1},
                                         {"adv_reciever_3channel", 1},
                                         {"adv_reciever_4channel", 1},
                                         {"adv_transmitter_1channel", 1},
                                         {"adv_transmitter_2channel", 1},
                                         {"adv_transmitter_3channel", 1},
                                         {"adv_transmitter_4channel", 1},
                                         {"adv_antenna_equal", 1},
                                         {"adv_modulation", 0},
                                     };

            var newAlgorithm = new Algorithm(startStateOfElements, endStateOfElements)
                               {
                                   Name = "Подготовка изделия Л001 к включению",
                                   Actions = new LinkedList<Action>(new[]
                                                                    {
                                                                        actionsFactory.GetClickAction("main_thumbler_light", "Установите данный тумблер в положение ПОДСВЕТ", 1),

                                                                        actionsFactory.GetClickAction("main_thumbler_1channel", "Установите данный тумблер в положение I КАНАЛ", 1),
                                                                        actionsFactory.GetClickAction("main_thumbler_2channel", "Установите данный тумблер в положение II КАНАЛ", 1),
                                                                        actionsFactory.GetClickAction("main_thumbler_3channel", "Установите данный тумблер в положение III КАНАЛ", 1),
                                                                        actionsFactory.GetClickAction("main_thumbler_4channel", "Установите данный тумблер в положение IV КАНАЛ", 1),

                                                                        actionsFactory.GetClickAction("main_thumbler_simulator", "Установите данный тумблер в положение ОТКЛ.", 0),
                                                                        
                                                                        actionsFactory.GetClickAction("adv_reciever_1channel", "Установите данный тумблер в положение I КАНАЛ", 1),
                                                                        actionsFactory.GetClickAction("adv_reciever_2channel", "Установите данный тумблер в положение II КАНАЛ", 1),
                                                                        actionsFactory.GetClickAction("adv_reciever_3channel", "Установите данный тумблер в положение III КАНАЛ", 1),
                                                                        actionsFactory.GetClickAction("adv_reciever_4channel", "Установите данный тумблер в положение IV КАНАЛ", 1),

                                                                        actionsFactory.GetClickAction("adv_transmitter_1channel", "Установите данный тумблер в положение I КАНАЛ", 1),
                                                                        actionsFactory.GetClickAction("adv_transmitter_2channel", "Установите данный тумблер в положение II КАНАЛ", 1),
                                                                        actionsFactory.GetClickAction("adv_transmitter_3channel", "Установите данный тумблер в положение III КАНАЛ", 1),
                                                                        actionsFactory.GetClickAction("adv_transmitter_4channel", "Установите данный тумблер в положение IV КАНАЛ", 1),

                                                                        actionsFactory.GetClickAction("adv_antenna_equal", "Установите данный тумблер в положение Эквивалент", 1),
                                                                        actionsFactory.GetClickAction("adv_modulation", "Установите данный тумблер в положение ОТКЛ.", 0),
                                                                    })
                               };

            return newAlgorithm;
        }
    }
}