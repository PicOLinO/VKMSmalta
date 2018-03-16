using System;
using System.Collections.ObjectModel;
using DevExpress.Mvvm;
using VKMSmalta.Services;
using VKMSmalta.Services.Navigate;
using VKMSmalta.View.Elements.ViewModel.Interfaces;
using VKMSmalta.View.Hints.ViewModel;
using VKMSmalta.View.ViewModel;

namespace VKMSmalta.View.Elements.ViewModel
{
    public class ElementViewModelBase : ViewModelBase, IValuableNamedElement
    {
        private readonly bool isInitialize;

        public string Name { get; set; }
        public InnerRegionPage Page { get; set; }

        public double PosTop
        {
            get { return GetProperty(() => PosTop); }
            set { SetProperty(() => PosTop, value); }
        }

        public double PosLeft
        {
            get { return GetProperty(() => PosLeft); }
            set { SetProperty(() => PosLeft, value); }
        }

        public int Value
        {
            get { return GetProperty(() => Value); }
            set {
                SetProperty(() => Value, value);
                if (!isInitialize)
                {
                    OnValueChanged();
                }
            }
        }

        public string ImageSource
        {
            get { return GetProperty(() => ImageSource); }
            set { SetProperty(() => ImageSource, value); }
        }

        public bool IsHintOpen
        {
            get { return GetProperty(() => IsHintOpen); }
            set { SetProperty(() => IsHintOpen, value); }
        }

        public HintViewModelBase Hint
        {
            get { return GetProperty(() => Hint); }
            set { SetProperty(() => Hint, value); }
        }

        public bool IsEnabled { get; set; } = true;

        public ElementViewModelBase(int value, string name)
        {
            isInitialize = true;

            Name = name;
            Value = value;

            isInitialize = false;
        }

        protected virtual void OnValueChanged()
        {
            Hint?.ClickNextCommand.RaiseCanExecuteChanged();
        }
    }
}