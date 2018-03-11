using System;
using System.Collections.Generic;
using VKMSmalta.Domain;

namespace VKMSmalta.View.DSL.Other
{
    public class DependencyActionBuilder
    {
        private string name;
        private readonly Dictionary<int, int> dependencyValues;

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
                case DependencyActionsDefaultValues.OneToOneEqualsTwoCount:
                    dependencyValues.Add(0, 0);
                    dependencyValues.Add(1, 1);
                    break;
                case DependencyActionsDefaultValues.OneToOneReverseTwoCount:
                    dependencyValues.Add(0,1);
                    dependencyValues.Add(1,0);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(defaultValuesAction), defaultValuesAction, null);
            }

            return this;
        }

        public DependencyAction Please()
        {
            return new DependencyAction(name, dependencyValues);
        }
    }
}