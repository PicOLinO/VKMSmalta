using System;
using System.Collections.ObjectModel;
using DevExpress.Mvvm;
using VKMSmalta.Services;
using VKMSmalta.View.ViewModel;

namespace VKMSmalta.View.Elements.ViewModel
{
    public class ElementViewModelBase : ViewModelBase
    {
        public double PosLeft { get; set; }
        public double PosTop { get; set; }
        public string Name { get; set; }
        public virtual int Value { get; set; }
        
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

        public HintViewModel Hint
        {
            get { return GetProperty(() => Hint); }
            set { SetProperty(() => Hint, value); }
        }

        public bool IsEnabled { get; set; } = true;

        public ElementViewModelBase(int value, string name)
        {
            Name = name;
            Value = value;
        }
    }
}