#region Usings

using System;
using DevExpress.Mvvm;
using Vkm.Smalta.View.Hints.ViewModel;

#endregion

namespace Vkm.Smalta.View.Elements.ViewModel
{
    public class ElementViewModelBase : ViewModelBase
    {        protected ElementViewModelBase(int value, string name, int posTop, int posLeft, Enum page)
        {

            Name = name;
            Value = value;
            PosTop = posTop;
            PosLeft = posLeft;
            Page = page;
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

        public int Value
        {
            get { return GetProperty(() => Value); }
            set { SetProperty(() => Value, value, OnValueChanged); }
        }

        protected virtual void OnValueChanged()
        {
            Hint?.ClickNextCommand.RaiseCanExecuteChanged();
        }
    }
}