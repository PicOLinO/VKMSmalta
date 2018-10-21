#region Usings

using System.Collections.Generic;
using Vkm.Smalta.Domain;

#endregion

namespace Vkm.Smalta.Dialogs.Factories.Algorithms
{
    public class RlsOncAlgorithmsFactory : AlgorithmsFactoryBase
    {
        public RlsOncAlgorithmsFactory(IActionsFactory actionsFactory) : base(actionsFactory)
        {
        }

        public Algorithm GetPrepareToLaunchAlgorithm()
        {
            var startStateOfElements = new Dictionary<string, int>();
            var endStateOfElements = new Dictionary<string, int>();

            var newAlgorithm = new Algorithm(startStateOfElements, endStateOfElements)
                               {
                                   Name = "Подготовка лабораторной установки к работе",
                                   Actions = new LinkedList<Action>()
                               };

            return newAlgorithm;
        }

        public Algorithm GetDependencyOfNoiseCoefficientByWidthOfImpulsesInPack()
        {
            var startStateOfElements = new Dictionary<string, int>();
            var endStateOfElements = new Dictionary<string, int>();

            var newAlgorithm = new Algorithm(startStateOfElements, endStateOfElements)
                               {
                                   Name = "Снятие зависимости коэффициента подавления от длительности импульсов в пачке",
                                   Actions = new LinkedList<Action>(new[]
                                                                    {
                                                                        ActionsFactory.GetClickAction("cps_wheel_signal_noise", "Путем поворота (колесиком мышки) данного колеса прокрутки\nдобейтесь устойчивого появления цели на экране индикатора", 50),
                                                                        ActionsFactory.GetInfoAction("radar_target_1", "Как можно заметить, цель отчетливо видно на индикаторе"),

                                                                        ActionsFactory.GetClickAction("cps_stepwheel_noisetype", "Осуществим подавление цели, для этого переключите вид поставляемых помех на \"Прямошумовая помеха\"", 3),
                                                                        ActionsFactory.GetClickAction("cps_stepwheel_generator_mode", "Переключите режим работы станции РЛС в положение \"Работа\"", 2),
                                                                        ActionsFactory.GetClickAction("station_thumbler_speed", "Переключите режим работы РЛС в положение \"Медленно\"", 1),

                                                                        ActionsFactory.GetClickAction("cps_wheel_noise", "Прокрутите данное колесо прокрутки для максимального увеличения помехового сигнала", 50),
                                                                        ActionsFactory.GetInfoAction("radar_target_1", "Как можно видеть, цель полностью засвечена помехой"),

                                                                        ActionsFactory.GetClickAction("cps_stepwheel_generator_mode", "Поставьте режим работы станции в положение \"Измерение\"", 0),
                                                                        ActionsFactory.GetClickAction("cps_stepwheel_noisetype", "Переключите вид поставляемой помехи на \"ЧМШ\"", 1),
                                                                        //TODO: Продолжить
                                                                    })
                               };

            return newAlgorithm;
        }

        public Algorithm GetDependencyOfNoiseCoefficientByWidthOfImpulsesInPackForFrontwayNoise()
        {
            var startStateOfElements = new Dictionary<string, int>();
            var endStateOfElements = new Dictionary<string, int>();

            var newAlgorithm = new Algorithm(startStateOfElements, endStateOfElements)
                               {
                                   Name = "Снятие зависимости коэффициента подавления от длительности импульсов в пачке для прямошумовой помехи",
                                   Actions = new LinkedList<Action>()
                               };

            return newAlgorithm;
        }
    }
}