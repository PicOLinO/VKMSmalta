using System;
using System.Collections.Generic;
using VKMSmalta.Domain;

namespace VKMSmalta.View.DSL.Other
{
    public class DependencyActionBuilder
    {
        private string name;
        private readonly Dictionary<int, int> dependencyValues;
        private int delayInSeconds;

        public DependencyActionBuilder()
        {
            dependencyValues = new Dictionary<int, int>();
        }

        public DependencyActionBuilder WithDependencyElementName(string name)
        {
            this.name = name;
            return this;
        }

        public DependencyActionBuilder WithDefaultDependencyValues(DependencyActionsDefaultValues defaultValuesAction)
        {
            switch (defaultValuesAction)
            {
                case DependencyActionsDefaultValues.EqualsTwoCount:
                    dependencyValues.Add(0, 0);
                    dependencyValues.Add(1, 1);
                    break;
                case DependencyActionsDefaultValues.ReverseTwoCount:
                    dependencyValues.Add(0,1);
                    dependencyValues.Add(1,0);
                    break;
                case DependencyActionsDefaultValues.ToZeroTwoCount:
                    dependencyValues.Add(0,0);
                    dependencyValues.Add(1,0);
                    break;
                case DependencyActionsDefaultValues.ToFiveOneCount:
                    dependencyValues.Add(1,5);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(defaultValuesAction), defaultValuesAction, null);
            }

            return this;
        }

        public DependencyActionBuilder WithDelay(int delayInSeconds)
        {
            this.delayInSeconds = delayInSeconds;
            return this;
        }

        public DependencyAction Please()
        {
            return new DependencyAction(name, dependencyValues, delayInSeconds);
        }
    }
}