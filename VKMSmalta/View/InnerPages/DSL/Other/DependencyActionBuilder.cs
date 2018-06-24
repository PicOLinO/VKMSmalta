using System.Collections.Generic;
using VKMSmalta.Domain;

namespace VKMSmalta.View.InnerPages.DSL.Other
{
    public class DependencyActionBuilder
    {
        private DependencyType type;
        private string name;
        private readonly Dictionary<int, int> dependencyValues;
        private int delayInSeconds;

        public DependencyActionBuilder()
        {
            dependencyValues = new Dictionary<int, int>();
        }

        public DependencyActionBuilder TypeOf(DependencyType type)
        {
            this.type = type;
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

        public DependencyActionBuilder WithDelay(int delayInSeconds)
        {
            this.delayInSeconds = delayInSeconds;
            return this;
        }

        public DependencyAction Please()
        {
            return new DependencyAction(type, name, dependencyValues, delayInSeconds);
        }
    }
}