#region Usings

using System.Collections.Generic;
using Vkm.Smalta.Domain;
using Vkm.Smalta.Services;

#endregion

namespace Vkm.Smalta.Dialogs.Factories
{
    public class AlgorithmsFactory
    {
        private readonly ActionsFactory actionsFactory;

        public AlgorithmsFactory(ActionsFactory actionsFactory)
        {
            this.actionsFactory = actionsFactory;
        }

        public Algorithm GetLaunchAlgorithm()
        {
            var startStateOfElements = new Dictionary<string, int>
                                       {
                                           {"lo01p_1cooler", 1},
                                           {"lo01p_2cooler", 1},
                                           {"lo01r_lamp_network_27v", 1},
                                           {"lo01r_lamp_equal", 1},
                                           {"lo01r_lamp_+10v", 1},
                                           {"lo01p_thumbler_light", 1},
                                           {"lo01p_thumbler_1channel", 1},
                                           {"lo01p_thumbler_2channel", 1},
                                           {"lo01p_thumbler_3channel", 1},
                                           {"lo01p_thumbler_4channel", 1},
                                           {"lo01p_thumbler_simulator", 0},
                                           {"lo01r_reciever_1channel", 1},
                                           {"lo01r_reciever_2channel", 1},
                                           {"lo01r_reciever_3channel", 1},
                                           {"lo01r_reciever_4channel", 1},
                                           {"lo01r_transmitter_1channel", 1},
                                           {"lo01r_transmitter_2channel", 1},
                                           {"lo01r_transmitter_3channel", 1},
                                           {"lo01r_transmitter_4channel", 1},
                                           {"lo01r_antenna_equal", 1},
                                           {"lo01r_modulation", 0},
                                           {"lo01k_modulation_13channel", 1},
                                           {"lo01k_modulation_24channel", 1}
                                       };

            var endStateOfElements = new Dictionary<string, int>();

            var newAlgorithm = new Algorithm(startStateOfElements, endStateOfElements)
                               {
                                   Name = "Включение изделия ЛО01",
                                   Actions = new LinkedList<Action>(new[]
                                                                    {
                                                                        actionsFactory.GetClickAction("lo01p_button_reciever_glow_on", "Включите ПРОГРЕВ", 1),
                                                                        actionsFactory.GetIdleAction("lo01r_lamp_heating", "Дождитесь окончания прогрева", 0, true),

                                                                        actionsFactory.GetIdleAction("lo01p_reciever_1channel", "Дождитесь включения высокого напряжения. Должны загореться лампы транспарантов", 1),
                                                                        actionsFactory.GetInfoAction("lo01p_reciever_1channel_arrow", "Заметьте, что стрелки индикаторов \"ПРИЕМ\" показывают значения менее 20 мкА"),

                                                                        actionsFactory.GetClickAction("lo01p_button_transmitter_on", "Теперь включите передатчик", 1),

                                                                        actionsFactory.GetInfoAction("lo01p_transmitter_1channel_arrow", "Заметьте, что стрелки индикаторов \"ПЕРЕДАЧА\" показывают значения более 10 мкА"),

                                                                        actionsFactory.GetClickAction("lo01p_thumbler_simulator", "Включите имитатор", 1),
                                                                        actionsFactory.GetClickAction("lo01i_thumbler_2generator", "Включите генератор 2", 1),

                                                                        actionsFactory.GetInfoAction("lo01p_reciever_1channel_arrow", "Заметьте, что стрелки индикаторов \"ПРИЕМ\" показывают завышенные значения"),
                                                                        actionsFactory.GetInfoAction("lo01p_transmitter_1channel_arrow", "А стрелки индикаторов \"ПЕРЕДАЧА\" отклонились от первоначального значения")
                                                                    })
                               };

            return newAlgorithm;
        }

        public Algorithm GetPrepareToLaunchAlgorithm()
        {
            var startStateOfElements = new Dictionary<string, int>
                                       {
                                           {"lo01p_thumbler_simulator", 1},
                                           {"lo01p_simulator", 1},
                                           {"lo01r_modulation", 4}
                                       };

            var endStateOfElements = new Dictionary<string, int>
                                     {
                                         {"lo01p_thumbler_light", 1},
                                         {"lo01p_thumbler_1channel", 1},
                                         {"lo01p_thumbler_2channel", 1},
                                         {"lo01p_thumbler_3channel", 1},
                                         {"lo01p_thumbler_4channel", 1},
                                         {"lo01p_thumbler_simulator", 0},
                                         {"lo01r_reciever_1channel", 1},
                                         {"lo01r_reciever_2channel", 1},
                                         {"lo01r_reciever_3channel", 1},
                                         {"lo01r_reciever_4channel", 1},
                                         {"lo01r_transmitter_1channel", 1},
                                         {"lo01r_transmitter_2channel", 1},
                                         {"lo01r_transmitter_3channel", 1},
                                         {"lo01r_transmitter_4channel", 1},
                                         {"lo01r_antenna_equal", 1},
                                         {"lo01r_modulation", 0},
                                         {"lo01k_modulation_13channel", 1},
                                         {"lo01k_modulation_24channel", 1}
                                     };

            var newAlgorithm = new Algorithm(startStateOfElements, endStateOfElements)
                               {
                                   Name = "Подготовка изделия ЛО01 к включению",
                                   Actions = new LinkedList<Action>(new[]
                                                                    {
                                                                        actionsFactory.GetClickAction("lo01p_thumbler_light", "Установите данный тумблер в положение ПОДСВЕТ", 1),

                                                                        actionsFactory.GetClickAction("lo01p_thumbler_1channel", "Установите данный тумблер в положение I КАНАЛ", 1),
                                                                        actionsFactory.GetClickAction("lo01p_thumbler_2channel", "Установите данный тумблер в положение II КАНАЛ", 1),
                                                                        actionsFactory.GetClickAction("lo01p_thumbler_3channel", "Установите данный тумблер в положение III КАНАЛ", 1),
                                                                        actionsFactory.GetClickAction("lo01p_thumbler_4channel", "Установите данный тумблер в положение IV КАНАЛ", 1),

                                                                        actionsFactory.GetClickAction("lo01p_thumbler_simulator", "Установите данный тумблер в положение ОТКЛ.", 0),

                                                                        actionsFactory.GetClickAction("lo01r_reciever_1channel", "Установите данный тумблер в положение I КАНАЛ", 1),
                                                                        actionsFactory.GetClickAction("lo01r_reciever_2channel", "Установите данный тумблер в положение II КАНАЛ", 1),
                                                                        actionsFactory.GetClickAction("lo01r_reciever_3channel", "Установите данный тумблер в положение III КАНАЛ", 1),
                                                                        actionsFactory.GetClickAction("lo01r_reciever_4channel", "Установите данный тумблер в положение IV КАНАЛ", 1),

                                                                        actionsFactory.GetClickAction("lo01r_transmitter_1channel", "Установите данный тумблер в положение I КАНАЛ", 1),
                                                                        actionsFactory.GetClickAction("lo01r_transmitter_2channel", "Установите данный тумблер в положение II КАНАЛ", 1),
                                                                        actionsFactory.GetClickAction("lo01r_transmitter_3channel", "Установите данный тумблер в положение III КАНАЛ", 1),
                                                                        actionsFactory.GetClickAction("lo01r_transmitter_4channel", "Установите данный тумблер в положение IV КАНАЛ", 1),

                                                                        actionsFactory.GetClickAction("lo01r_antenna_equal", "Установите данный тумблер в положение Эквивалент", 1),
                                                                        actionsFactory.GetClickAction("lo01r_modulation", "Установите данный тумблер в положение ОТКЛ.", 0),

                                                                        actionsFactory.GetClickAction("lo01k_modulation_13channel", "Установите данный тумблер в положение ВКЛ.", 1),
                                                                        actionsFactory.GetClickAction("lo01k_modulation_24channel", "Установите данный тумблер в положение ВКЛ.", 1)
                                                                    })
                               };

            return newAlgorithm;
        }

        public Algorithm GetStopAlgorithm()
        {
            var startStateOfElements = new Dictionary<string, int>
                                       {
                                           {"lo01p_1cooler", 1},
                                           {"lo01p_2cooler", 1},
                                           {"lo01r_lamp_network_27v", 1},
                                           {"lo01r_lamp_equal", 1},
                                           {"lo01r_lamp_+10v", 1},
                                           {"lo01p_thumbler_light", 1},
                                           {"lo01p_thumbler_1channel", 1},
                                           {"lo01p_thumbler_2channel", 1},
                                           {"lo01p_thumbler_3channel", 1},
                                           {"lo01p_thumbler_4channel", 1},
                                           {"lo01r_reciever_1channel", 1},
                                           {"lo01r_reciever_2channel", 1},
                                           {"lo01r_reciever_3channel", 1},
                                           {"lo01r_reciever_4channel", 1},
                                           {"lo01r_transmitter_1channel", 1},
                                           {"lo01r_transmitter_2channel", 1},
                                           {"lo01r_transmitter_3channel", 1},
                                           {"lo01r_transmitter_4channel", 1},
                                           {"lo01r_antenna_equal", 1},
                                           {"lo01r_modulation", 0},
                                           {"lo01k_modulation_13channel", 1},
                                           {"lo01k_modulation_24channel", 1},
                                           {"lo01p_button_reciever_glow_on", 1},
                                           {"lo01p_glow_on", 1},
                                           {"lo01r_lamp_heating", 0},
                                           {"lo01p_reciever_1channel", 1},
                                           {"lo01p_reciever_2channel", 1},
                                           {"lo01p_reciever_3channel", 1},
                                           {"lo01p_reciever_4channel", 1},
                                           {"lo01p_transmitter_1channel", 1},
                                           {"lo01p_transmitter_2channel", 1},
                                           {"lo01p_transmitter_3channel", 1},
                                           {"lo01p_transmitter_4channel", 1},
                                           {"lo01p_reciever_1channel_arrow", 6},
                                           {"lo01p_reciever_2channel_arrow", 6},
                                           {"lo01p_reciever_3channel_arrow", 6},
                                           {"lo01p_reciever_4channel_arrow", 6},
                                           {"lo01p_button_transmitter_on", 1},
                                           {"lo01p_transmitter_1channel_arrow", 3},
                                           {"lo01p_transmitter_2channel_arrow", 3},
                                           {"lo01p_transmitter_3channel_arrow", 3},
                                           {"lo01p_transmitter_4channel_arrow", 3},
                                           {"lo01p_thumbler_simulator", 1},
                                           {"lo01p_simulator", 1},
                                           {"lo01i_thumbler_2generator", 1}
                                       };

            var endStateOfElements = new Dictionary<string, int>();

            var newAlgorithm = new Algorithm(startStateOfElements, endStateOfElements)
                               {
                                   Name = "Выключение изделия ЛО01",
                                   Actions = new LinkedList<Action>(new[]
                                                                    {
                                                                        actionsFactory.GetClickAction("lo01p_thumbler_simulator", "Отключите имитатор", 0),
                                                                        actionsFactory.GetClickAction("lo01p_button_transmitter_off", "Отключите передатчик", 1),
                                                                        actionsFactory.GetClickAction("lo01p_button_reciever_glow_off", "Отключите приемник", 1),
                                                                        actionsFactory.GetIdleAction("lo01p_glow_on", "Дождитесь выключения накала", 0, true)
                                                                    })
                               };

            return newAlgorithm;
        }
    }
}