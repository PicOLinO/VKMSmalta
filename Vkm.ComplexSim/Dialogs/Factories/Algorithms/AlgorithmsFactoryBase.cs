namespace Vkm.ComplexSim.Dialogs.Factories.Algorithms
{
    public abstract class AlgorithmsFactoryBase
    {
        protected readonly IActionsFactory ActionsFactory;

        public AlgorithmsFactoryBase(IActionsFactory actionsFactory)
        {
            ActionsFactory = actionsFactory;
        }
    }
}