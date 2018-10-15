#region Usings

using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using Vkm.Smalta.Services;
using Vkm.Smalta.View.Elements.ViewModel;
using Vkm.Smalta.View.Hints;
using ToolTip = System.Windows.Controls.ToolTip;

#endregion

namespace Vkm.Smalta.View.Elements
{
    public abstract class ElementBase : UserControl, IDisposable
    {
        private double firstXPos, firstYPos;
        private ElementBase movingObject;

        public ElementBase()
        {
            //Hack for XAML designer to avoid exceptions by code below. Example: Trying to get App throws Null Reference exception
            if (DesignerProperties.GetIsInDesignMode(this))
            {
                return;
            }

            SnapsToDevicePixels = false;
            AllowDrop = true;

            Loaded += OnLoaded;

            if (!App.IsDebug)
            {
                return;
            }

            MouseLeftButtonDown += OnMouseLeftButtonDown;
            PreviewMouseLeftButtonUp += OnPreviewMouseLeftButtonUp;
            MouseMove += OnMouseMove;
            Unloaded += OnUnloaded;
        }

        private IAppContext App => DependencyContainer.GetApp();

        private void CreateHint(ElementViewModelBase vm)
        {
            var hintView = new Hint();
            var hintBinding = new Binding
                              {
                                  Source = vm,
                                  Path = new PropertyPath("Hint"),
                                  Mode = BindingMode.OneWay,
                                  UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
                              };

            var hintPopup = new Popup
                            {
                                StaysOpen = true,
                                Placement = PlacementMode.Right,
                                MinWidth = 170,
                                MinHeight = 60,
                                VerticalOffset = 20,
                                HorizontalOffset = 10,
                                PopupAnimation = PopupAnimation.Fade,
                                AllowsTransparency = true,
                                Child = hintView
                            };
            var isOpenBinding = new Binding
                                {
                                    Source = vm,
                                    Path = new PropertyPath("IsHintOpen"),
                                    Mode = BindingMode.OneWay,
                                    UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
                                };

            var children = LogicalTreeHelper.GetChildren(this);
            foreach (var element in children)
            {
                if (element is Grid grid)
                {
                    hintPopup.PlacementTarget = grid;
                    grid.Children.Add(hintPopup);
                }
            }

            BindingOperations.SetBinding(hintPopup, Popup.IsOpenProperty, isOpenBinding);
            BindingOperations.SetBinding(hintView, DataContextProperty, hintBinding);
        }
        
        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            var vm = DataContext as ElementViewModelBase;
            CreateHint(vm);

            if (App.IsDebug)
            {
                var content = $"{vm?.Name} ({vm?.PosTop}, {vm?.PosLeft})";
                var toolTip = new ToolTip {Content = content};
                ToolTip = toolTip;
            }
        }

        private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var element = sender as ElementBase;
            var canvas = element?.Tag as Canvas;

            firstXPos = e.GetPosition(element).X;
            firstYPos = e.GetPosition(element).Y;

            movingObject = element;

            var top = Panel.GetZIndex(element ?? throw new InvalidOperationException());
            if (canvas?.Children != null)
            {
                foreach (ContentPresenter child in canvas.Children)
                {
                    if (top < Panel.GetZIndex(child))
                    {
                        top = Panel.GetZIndex(child);
                    }
                }
            }

            Panel.SetZIndex(element, top + 1);
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && Equals(sender, movingObject))
            {
                var element = sender as ElementBase;
                var elementVm = element?.DataContext as ElementViewModelBase;
                var canvas = element?.Tag as Canvas;

                if (canvas != null)
                {
                    var newLeft = e.GetPosition(canvas).X - firstXPos - canvas.Margin.Left;
                    if (newLeft > canvas.Margin.Left + canvas.ActualWidth - element.ActualWidth)
                    {
                        newLeft = canvas.Margin.Left + canvas.ActualWidth - element.ActualWidth;
                    }
                    else if (newLeft < canvas.Margin.Left)
                    {
                        newLeft = canvas.Margin.Left;
                    }

                    if (elementVm != null)
                    {
                        elementVm.PosLeft = newLeft;
                    }
                }

                if (canvas == null)
                {
                    return;
                }

                var newTop = e.GetPosition(canvas).Y - firstYPos - canvas.Margin.Top;
                if (newTop > canvas.Margin.Top + canvas.ActualHeight - element.ActualHeight)
                {
                    newTop = canvas.Margin.Top + canvas.ActualHeight - element.ActualHeight;
                }
                else if (newTop < canvas.Margin.Top)
                {
                    newTop = canvas.Margin.Top;
                }

                if (elementVm != null)
                {
                    elementVm.PosTop = newTop;
                }

                ((ToolTip) ToolTip).Content = $"{elementVm?.Name} ({elementVm?.PosTop}, {elementVm?.PosLeft})";
            }
        }

        private void OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var element = sender as ElementBase;
            var canvas = element?.Tag as Canvas;

            movingObject = null;

            var top = Panel.GetZIndex(element ?? throw new InvalidOperationException());
            if (canvas != null)
            {
                foreach (ContentPresenter child in canvas.Children)
                {
                    if (top > Panel.GetZIndex(child))
                    {
                        top = Panel.GetZIndex(child);
                    }
                }
            }

            Panel.SetZIndex(element, top + 1);
        }

        private void OnUnloaded(object sender, RoutedEventArgs e)
        {
            Dispose();
        }

        private void ReleaseUnmanagedResources()
        {
            Loaded -= OnLoaded;
            MouseLeftButtonDown -= OnMouseLeftButtonDown;
            PreviewMouseLeftButtonUp -= OnPreviewMouseLeftButtonUp;
            MouseMove -= OnMouseMove;
            Unloaded -= OnUnloaded;
        }

        #region IDisposable

        public void Dispose()
        {
            ReleaseUnmanagedResources();
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}