namespace Vkm.Smalta.Dialogs.Factories.Algorithms
{
    public abstract class AlgorithmsFactoryBase
    {
        protected readonly ActionsFactory ActionsFactory;

        public AlgorithmsFactoryBase(ActionsFactory actionsFactory)
        {
            ActionsFactory = actionsFactory;
        }
    }
}