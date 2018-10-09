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
                                   Actions = new LinkedList<Action>()
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