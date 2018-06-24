#region Usings

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using VKMSmalta.Services;
using VKMSmalta.View.Elements.ViewModel;

#endregion

namespace VKMSmalta.View.Elements
{
    public class ElementBase : UserControl, IDisposable
    {
        private double firstXPos, firstYPos;
        private ElementBase movingObject;

        public ElementBase()
        {
            SnapsToDevicePixels = false;
            AllowDrop = true;

            if (!App.IsDebug)
            {
                return;
            }

            Loaded += OnLoaded;
            MouseLeftButtonDown += OnMouseLeftButtonDown;
            PreviewMouseLeftButtonUp += OnPreviewMouseLeftButtonUp;
            MouseMove += OnMouseMove;
            Unloaded += OnUnloaded;
        }

        private AppGlobal App => DependencyContainer.GetApp();

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            var vm = DataContext as ElementViewModelBase;
            var toolTip = new ToolTip {Content = vm?.Name};
            ToolTip = toolTip;
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