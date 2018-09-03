#region Usings

using System.Collections.Generic;
using System.Linq;
using Vkm.Smalta.Domain;
using Vkm.Smalta.View.Elements.ViewModel.Interfaces;

#endregion

namespace Vkm.Smalta.Services
{
    public class HistoryService
    {
        public HistoryService()
        {
            Actions = new List<Action>();
        }

        public List<Action> Actions { get; }

        public int GetValueByAlgorithmByEndStateOfElements(Algorithm algorithm, List<IValuableNamedElement> elements)
        {
            var rightsCount = 0;
            var allCount = 0;

            foreach (var algorithmEndStateOfElement in algorithm.EndStateOfElements)
            {
                allCount++;
                if (elements.Single(el => el.Name == algorithmEndStateOfElement.Key).Value == algorithmEndStateOfElement.Value)
                {
                    rightsCount++;
                }
            }

            if (allCount == 0)
            {
                return -1;
            }

            var value = rightsCount * 5 / allCount;

            return value <= 0
                       ? 1
                       : value;
        }

        public int GetValueByAlgorithmByUserActions(Algorithm algorithm, List<IValuableNamedElement> elements)
        {
            //TODO: Несовершенно. Ужасно написано, нужна оптимизация с точки зрения не производительности, а бизнес-логики.

            var ethalonActionsCount = algorithm.Actions.Count(a => a.UseInExamineCheck);
            
            var previousRightActionIndex = 0;

            double ethalonActionsInUserActionsCount = 0;
            double rightOrderOfUserActionsCount = 0;

            var wrongActionsCount = 0;

            for (var i = 0; i < Actions.Count; i++)
            {
                var userAction = Actions[i];
                var actionIsRight = false;
                for (var j = 0; j < algorithm.Actions.Count; j++)
                {
                    var ethalonAction = algorithm.Actions.ElementAt(j);
                    if (ethalonAction.Name == userAction.Name && ethalonAction.ParentElementName == userAction.ParentElementName && ethalonAction.UseInExamineCheck)
                    {
                        ethalonActionsInUserActionsCount++;
                        actionIsRight = true;
                        if (j >= previousRightActionIndex)
                        {
                            previousRightActionIndex = j;
                            rightOrderOfUserActionsCount++;
                        }
                        break;
                    }
                }

                if (!actionIsRight && userAction.Name == ActionName.Click)
                {
                    wrongActionsCount++;
                }
            }

            if (ethalonActionsCount == 0)
            {
                return -1; 
            }

            if (ethalonActionsInUserActionsCount > ethalonActionsCount)
                ethalonActionsInUserActionsCount = ethalonActionsCount;
            if (rightOrderOfUserActionsCount > ethalonActionsCount)
                rightOrderOfUserActionsCount = ethalonActionsCount;

            var examineResult = new ExamineResultProperties
                                {
                                    PercentageOfEthalonActionsInUserActions = ethalonActionsInUserActionsCount / ethalonActionsCount,
                                    PercentageOfEthalonActionsRightOrderInUserActions = rightOrderOfUserActionsCount / ethalonActionsCount,
                                    WrongActionsCount = wrongActionsCount
                                };

            var value = examineResult.GetValue();

            return value <= 0
                       ? 1
                       : value;
        }

        public void Reset()
        {
            Actions.Clear();
        }
    }
}