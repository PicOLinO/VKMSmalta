#region Usings

using System.Collections.Generic;
using VKMSmalta.Domain;

#endregion

namespace VKMSmalta.View.InnerPages.DSL.Other
{
    public class DependencyActionBuilder
    {
        private readonly Dictionary<int, int> dependencyValues;
        private int delayInSeconds;
        private string name;
        private DependencyType type;

        public DependencyActionBuilder()
        {
            dependencyValues = new Dictionary<int, int>();
        }

        public DependencyAction Please()
        {
            return new DependencyAction(type, name, dependencyValues, delayInSeconds);
        }

        public DependencyActionBuilder TypeOf(DependencyType type)
        {
            this.type = type;
            return this;
        }

        public DependencyActionBuilder WithDelay(int delayInSeconds)
        {
            this.delayInSeconds = delayInSeconds;
            return this;
        }

        public DependencyActionBuilder WithDependencyElementName(string name)
        {
            this.name = name;
            return this;
        }

        public DependencyActionBuilder WithDependencyValue(int sourceValue, int targetValue)
        {
            dependencyValues.Add(sourceValue, targetValue);
            return this;
        }
    }
}