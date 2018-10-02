#region Usings

using Vkm.Smalta.Domain;

#endregion

namespace Vkm.Smalta.Dialogs.Factories
{
    public interface IActionsFactory
    {
        Action GetClickAction(string elementName, string hint, int accessibleValue, bool useInExamineCheck = true);
        Action GetIdleAction(string elementName, string hint, int accessibleValue, bool useInExamineCheck = false);
        Action GetInfoAction(string elementName, string hint, bool useInExamineCheck = false);
    }
}