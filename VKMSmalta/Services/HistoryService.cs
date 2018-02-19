﻿using System;
using System.Collections.Generic;
using System.Linq;
using VKMSmalta.Domain;
using VKMSmalta.View.Elements.ViewModel;
using Action = VKMSmalta.Domain.Action;

namespace VKMSmalta.Services
{
    public class HistoryService : ServiceBase<HistoryService>
    {
        public List<Action> Actions { get; }

        public HistoryService()
        {
            Actions = new List<Action>();
        }

        public int GetValueByAlgorithm(Algorithm algorithm, List<IValuableNamedElement> elements)
        {
            var rightsCount = 0;

            foreach (var algorithmEndStateOfElement in algorithm.EndStateOfElements)
            {
                if (elements.Single(el => el.Name == algorithmEndStateOfElement.Key).Value == algorithmEndStateOfElement.Value)
                {
                    rightsCount++;
                }

                //TODO: Если оценка должна зависеть не от окончательного положения элементов, а от производимых действий пользователя - добавить сюда данную проверку. 
                //Действия пользователя брать из Actions этого класса.
            }

            if (rightsCount <= 0)
            {
                return 1;
            }
            else
            {
                return rightsCount * 5 / elements.Count;
            }
        }

        public void Reset()
        {
            Actions.Clear();
        }
    }
}