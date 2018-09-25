using System.Collections.Generic;
using Vkm.Smalta.Domain;

namespace Vkm.Smalta.Dialogs.Factories.Algorithms
{
    public class RlsOncAlgorithmsFactory : AlgorithmsFactoryBase
    {
        public RlsOncAlgorithmsFactory(IActionsFactory actionsFactory) : base(actionsFactory)
        {
        }

        public Algorithm GetDummyAlgorithm()
        {
            var startStateOfElements = new Dictionary<string, int>();
            var endStateOfElements = new Dictionary<string, int>();

            var newAlgorithm = new Algorithm(startStateOfElements, endStateOfElements)
            {
                Name = "Dummy",
                Actions = new LinkedList<Action>()
            };

            return newAlgorithm;
        }
    }
}