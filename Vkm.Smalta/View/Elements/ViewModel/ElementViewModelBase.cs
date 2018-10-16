#region Usings

using System;
using DevExpress.Mvvm;
using Vkm.Smalta.View.Hints.ViewModel;

#endregion

namespace Vkm.Smalta.View.Elements.ViewModel
{
    public class ElementViewModelBase : ViewModelBase
    {
        private readonly bool isInitialize;

        //TODO: width и height сделать для всех! Пока временное решение с нулями. Должны быть не по-умолчанию.
        protected ElementViewModelBase(int value, string name, int posTop, int posLeft, Enum page, int width = 0, int height = 0)
        {
            isInitialize = true;

            Name = name;
            Value = value;
            PosTop = posTop;
            PosLeft = posLeft;
            Page = page;
            Width = width == 0 ? double.NaN : width;
            Height = height == 0 ? double.NaN : height; ;

            isInitialize = false;
        }

        public HintViewModelBase Hint
        {
            get { return GetProperty(() => Hint); }
            set { SetProperty(() => Hint, value); }
        }

        public string ImageSource
        {
            get { return GetProperty(() => ImageSource); }
            set { SetProperty(() => ImageSource, value); }
        }

        public bool IsEnabled { get; set; } = true;

        public bool IsHintOpen
        {
            get { return GetProperty(() => IsHintOpen); }
            set { SetProperty(() => IsHintOpen, value); }
        }

        public string Name { get; }

        public Enum Page { get; set; }

        public double PosLeft
        {
            get { return GetProperty(() => PosLeft); }
            set { SetProperty(() => PosLeft, value); }
        }

        public double PosTop
        {
            get { return GetProperty(() => PosTop); }
            set { SetProperty(() => PosTop, value); }
        }

        public double Width
        {
            get { return GetProperty(() => Width); }
            set { SetProperty(() => Width, value); }
        }

        public double Height
        {
            get { return GetProperty(() => Height); }
            set { SetProperty(() => Height, value); }
        }

        public int Value
        {
            get { return GetProperty(() => Value); }
            set
            {
                SetProperty(() => Value, value);
                if (!isInitialize)
                {
                    OnValueChanged();
                }
            }
        }

        protected virtual void OnValueChanged()
        {
            Hint?.ClickNextCommand.RaiseCanExecuteChanged();
        }
    }
}