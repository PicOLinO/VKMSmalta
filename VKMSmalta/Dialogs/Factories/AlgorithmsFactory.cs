#region Usings

using System;
using System.Collections.Generic;
using VKMSmalta.Domain;
using VKMSmalta.Services;
using Action = VKMSmalta.Domain.Action;

#endregion

namespace VKMSmalta.Dialogs.Factories
{
    public class AlgorithmsFactory
    {
        private readonly HintService hintService;
        private readonly ActionsFactory actionsFactory;

        public AlgorithmsFactory(HintService hintService)
        {
            this.hintService = hintService;
            actionsFactory = new ActionsFactory(hintService);
        }

        public Algorithm GetPrepareToLaunchAlgorithm()
        {
            var startStateOfElements = new Dictionary<string, int>
                                       {
                                           {"l001p_thumbler_simulator", 1},
                                           {"l001r_modulation", 4},
                                       };

            var endStateOfElements = new Dictionary<string, int>
                                     {
                                         {"l001p_thumbler_light", 1},
                                         {"l001p_thumbler_1channel", 1},
                                         {"l001p_thumbler_2channel", 1},
                                         {"l001p_thumbler_3channel", 1},
                                         {"l001p_thumbler_4channel", 1},
                                         {"l001p_thumbler_simulator", 0},
                                         {"l001r_reciever_1channel", 1},
                                         {"l001r_reciever_2channel", 1},
                                         {"l001r_reciever_3channel", 1},
                                         {"l001r_reciever_4channel", 1},
                                         {"l001r_transmitter_1channel", 1},
                                         {"l001r_transmitter_2channel", 1},
                                         {"l001r_transmitter_3channel", 1},
                                         {"l001r_transmitter_4channel", 1},
                                         {"l001r_antenna_equal", 1},
                                         {"l001r_modulation", 0},
                                         {"l001k_modulation_13channel", 1},
                                         {"l001k_modulation_24channel", 1}
                                     };

            var newAlgorithm = new Algorithm(startStateOfElements, endStateOfElements)
                               {
                                   Name = "Подготовка изделия Л001 к включению",
                                   Actions = new LinkedList<Action>(new[]
                                                                    {
                                                                        actionsFactory.GetClickAction("l001p_thumbler_light", "Установите данный тумблер в положение ПОДСВЕТ", 1),

                                                                        actionsFactory.GetClickAction("l001p_thumbler_1channel", "Установите данный тумблер в положение I КАНАЛ", 1),
                                                                        actionsFactory.GetClickAction("l001p_thumbler_2channel", "Установите данный тумблер в положение II КАНАЛ", 1),
                                                                        actionsFactory.GetClickAction("l001p_thumbler_3channel", "Установите данный тумблер в положение III КАНАЛ", 1),
                                                                        actionsFactory.GetClickAction("l001p_thumbler_4channel", "Установите данный тумблер в положение IV КАНАЛ", 1),

                                                                        actionsFactory.GetClickAction("l001p_thumbler_simulator", "Установите данный тумблер в положение ОТКЛ.", 0),

                                                                        actionsFactory.GetClickAction("l001r_reciever_1channel", "Установите данный тумблер в положение I КАНАЛ", 1),
                                                                        actionsFactory.GetClickAction("l001r_reciever_2channel", "Установите данный тумблер в положение II КАНАЛ", 1),
                                                                        actionsFactory.GetClickAction("l001r_reciever_3channel", "Установите данный тумблер в положение III КАНАЛ", 1),
                                                                        actionsFactory.GetClickAction("l001r_reciever_4channel", "Установите данный тумблер в положение IV КАНАЛ", 1),

                                                                        actionsFactory.GetClickAction("l001r_transmitter_1channel", "Установите данный тумблер в положение I КАНАЛ", 1),
                                                                        actionsFactory.GetClickAction("l001r_transmitter_2channel", "Установите данный тумблер в положение II КАНАЛ", 1),
                                                                        actionsFactory.GetClickAction("l001r_transmitter_3channel", "Установите данный тумблер в положение III КАНАЛ", 1),
                                                                        actionsFactory.GetClickAction("l001r_transmitter_4channel", "Установите данный тумблер в положение IV КАНАЛ", 1),

                                                                        actionsFactory.GetClickAction("l001r_antenna_equal", "Установите данный тумблер в положение Эквивалент", 1),
                                                                        actionsFactory.GetClickAction("l001r_modulation", "Установите данный тумблер в положение ОТКЛ.", 0),

                                                                        actionsFactory.GetClickAction("l001k_modulation_13channel", "Установите данный тумблер в положение ВКЛ.", 1),
                                                                        actionsFactory.GetClickAction("l001k_modulation_24channel", "Установите данный тумблер в положение ВКЛ.", 1)
                                                                    })
                               };

            return newAlgorithm;
        }

        public Algorithm GetLaunchAlgorithm()
        {
            var startStateOfElements = new Dictionary<string, int>
                                       {
                                           {"l001p_1cooler", 1},
                                           {"l001p_2cooler", 1},
                                           {"l001r_lamp_network_27v", 1},
                                           {"l001r_lamp_equal", 1},
                                           {"l001r_lamp_+10v", 1},
                                           {"l001p_thumbler_1channel", 1},
                                           {"l001p_thumbler_2channel", 1},
                                           {"l001p_thumbler_3channel", 1},
                                           {"l001p_thumbler_4channel", 1},
                                       };

            var endStateOfElements = new Dictionary<string, int>
                                     {
                                     };

            var newAlgorithm = new Algorithm(startStateOfElements, endStateOfElements)
                               {
                                   Name = "Включение изделия Л001",
                                   Actions = new LinkedList<Action>(new []
                                                                    {
                                                                        actionsFactory.GetClickAction("l001p_button_reciever_glow_on", "Включите ПРОГРЕВ", 1),
                                                                        actionsFactory.GetIdleAction("l001r_lamp_heating", "Дождитесь окончания прогрева", 0),
                                                                    })
                               };

            return newAlgorithm;
        }
    }
}