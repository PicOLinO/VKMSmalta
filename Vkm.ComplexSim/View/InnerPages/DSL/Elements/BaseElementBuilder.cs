#region Usings

using System;
using System.Collections.Generic;
using DevExpress.Mvvm;
using Vkm.ComplexSim.View.Elements.ViewModel;
using Vkm.ComplexSim.View.Images;

#endregion

namespace Vkm.ComplexSim.View.InnerPages.DSL.Elements
{
    public abstract class BaseElementBuilder<TBuilder, TViewModel> where TBuilder : BaseElementBuilder<TBuilder, TViewModel> 
                                                                   where TViewModel : ElementViewModelBase
    {
        protected string Name;
        protected Enum Page;
        protected int PosLeft;
        protected int PosTop;
        protected int RotationDegrees;
        protected int Value;
        protected int Width;
        protected int Height;

        protected IImagesRepository ImagesRepository => ServiceContainer.Default.GetService<IImagesRepository>();

        public TBuilder WithSize(int width, int height)
        {
            Width = width;
            Height = height;
            return (TBuilder)this;
        }

        public TBuilder At(int posTop, int posLeft)
        {
            PosTop = posTop;
            PosLeft = posLeft;
            return (TBuilder)this;
        }

        public TBuilder On(Enum page)
        {
            Page = page;
            return (TBuilder)this;
        }

        public TBuilder WithName(string name)
        {
            Name = name;
            return (TBuilder)this;
        }

        public TBuilder WithStartupRotation(int rotationDegrees)
        {
            RotationDegrees = rotationDegrees;
            return (TBuilder)this;
        }

        public TBuilder WithValue(int value)
        {
            Value = value;
            return (TBuilder)this;
        }

        public TBuilder WithValueFrom(IDictionary<string, int> startupValuesDictionary, int defaultValue = 0)
        {
            Value = startupValuesDictionary.TryGetValue(Name, out var value)
                        ? value
                        : defaultValue;
            return (TBuilder)this;
        }

        public abstract TViewModel Please();
    }
}