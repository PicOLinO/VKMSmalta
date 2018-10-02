#region Usings

using System;
using DevExpress.Mvvm;
using Vkm.Smalta.View.Elements.ViewModel.Interfaces;
using Vkm.Smalta.View.Hints.ViewModel;

#endregion

namespace Vkm.Smalta.View.Elements.ViewModel
{
    public class ElementViewModelBase : ViewModelBase
    {
        private readonly bool isInitialize;

        protected ElementViewModelBase(int value, string name)
        {
            isInitialize = true;

            Name = name;
            Value = value;

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

        protected virtual void OnValueChanged()
        {
            Hint?.ClickNextCommand.RaiseCanExecuteChanged();
        }

        #region IValuableNamedElement

        public string Name { get; set; }

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

        #endregion
    }
}