using System;
using System.Collections.ObjectModel;
using DevExpress.Mvvm;
using VKMSmalta.Services;
using VKMSmalta.View.ViewModel;

namespace VKMSmalta.View.Elements.ViewModel
{
    public class ElementViewModelBase : ViewModelBase
    {

        private int hintsCounter;

        public ObservableCollection<HintViewModel> HintsCollection { get; set; }

        public string ImageSource
        {
            get { return GetProperty(() => ImageSource); }
            set { SetProperty(() => ImageSource, value); }
        }
        
        protected ElementViewModelBase()
        {
            hintsCounter = 0;
        }

        public bool IsHintOpen
        {
            get { return GetProperty(() => IsHintOpen); }
            set { SetProperty(() => IsHintOpen, value, IsHintOpenChanged); }
        }

        public HintViewModel Hint
        {
            get { return GetProperty(() => Hint); }
            set { SetProperty(() => Hint, value); }
        }

        private void IsHintOpenChanged()
        {
            if (IsHintOpen)
            {
                Hint = HintsCollection[hintsCounter];
                hintsCounter++;
            }
        }

        public double PosLeft { get; set; }
        public double PosTop { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        public string Name { get; set; }
    }
}