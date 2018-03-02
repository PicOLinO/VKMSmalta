using System;
using System.Collections.Generic;
using DevExpress.Mvvm;
using DevExpress.Mvvm.Native;
using VKMSmalta.Domain;

namespace VKMSmalta.View.Elements.ViewModel
{
    public sealed class VkmThumblerViewModel : ClickableElementViewModelBase, IValuableNamedElement
    {
        private int value;
        private readonly string imageOffSource;
        private readonly string imageOnSource;

        private List<DependencyAction> DependencyActions { get; }
        private bool IsInitialize { get; }

        public int StartupRotation
        {
            get { return GetProperty(() => StartupRotation); }
            set { SetProperty(() => StartupRotation, value); }
        }

        public override int Value
        {
            get => value;
            set
            {
                this.value = value;
                switch (value)
                {
                    case 0:
                        ImageSource = imageOffSource;
                        break;
                    case 1:
                        ImageSource = imageOnSource;
                        break;
                    default:
                        throw new IndexOutOfRangeException();
                }

                if (DependencyActions != null && !IsInitialize)
                {
                    NotifyDependedElements(value);
                }
            }
        }
        
        public VkmThumblerViewModel(int value, 
                                    string name, 
                                    List<DependencyAction> dependencyActions = null, 
                                    string imageOffSource = "/VKMSmalta;component/View/Images/ThumblerOff.png", 
                                    string imageOnSource = "/VKMSmalta;component/View/Images/ThumblerOn.png") : base(value, name)
        {
            IsInitialize = true;

            this.imageOffSource = imageOffSource;
            this.imageOnSource = imageOnSource;
            DependencyActions = dependencyActions;
            Value = value;

            IsInitialize = false;
        }

        protected override void OnClick()
        {
            base.OnClick();

            Value = Value == 0 ? 1 : 0;

            SendActionToHistoryService();
        }

        private void NotifyDependedElements(int value)
        {
            foreach (var dependencyAction in DependencyActions)
            {
                dependencyAction.SetDependencyElementValue(value);
            }
        }
    }
}