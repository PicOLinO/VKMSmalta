using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using VKMSmalta.Services;
using VKMSmalta.View.Elements.ViewModel;

namespace VKMSmalta.View.Elements
{
    public class ElementBase : UserControl, IDisposable
    {
        private ElementBase movingObject;
        private double firstXPos, firstYPos;

        public ElementBase()
        {
            SnapsToDevicePixels = false;
            AllowDrop = true;

            if (DependencyContainer.Instance.IsDebug)
            {
                Loaded += OnLoaded;
                MouseLeftButtonDown += OnMouseLeftButtonDown;
                PreviewMouseLeftButtonUp += OnPreviewMouseLeftButtonUp;
                MouseMove += OnMouseMove;
                Unloaded += OnUnloaded;
            }
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            var vm = DataContext as ElementViewModelBase;
            var toolTip = new ToolTip { Content = vm.Name };
            ToolTip = toolTip;
        }

        private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // In this event, we get the current mouse position on the control to use it in the MouseMove event.
            var element = sender as ElementBase;
            var canvas = element.Tag as Canvas;

            firstXPos = e.GetPosition(element).X;
            firstYPos = e.GetPosition(element).Y;

            movingObject = element;

            // Put the image currently being dragged on top of the others
            var top = Panel.GetZIndex(element);
            foreach (ContentPresenter child in canvas.Children)
                if (top < Panel.GetZIndex(child))
                    top = Panel.GetZIndex(child);
            Panel.SetZIndex(element, top + 1);
        }

        private void OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var element = sender as ElementBase;
            var canvas = element.Tag as Canvas;

            movingObject = null;

            // Put the image currently being dragged on top of the others
            var top = Panel.GetZIndex(element);
            foreach (ContentPresenter child in canvas.Children)
                if (top > Panel.GetZIndex(child))
                    top = Panel.GetZIndex(child);
            Panel.SetZIndex(element, top + 1);
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && sender == movingObject)
            {
                var element = sender as ElementBase;
                var elementVm = element.DataContext as ElementViewModelBase;
                var canvas = element.Tag as Canvas;

                double newLeft = e.GetPosition(canvas).X - firstXPos - canvas.Margin.Left;
                // newLeft inside canvas right-border?
                if (newLeft > canvas.Margin.Left + canvas.ActualWidth - element.ActualWidth)
                    newLeft = canvas.Margin.Left + canvas.ActualWidth - element.ActualWidth;
                // newLeft inside canvas left-border?
                else if (newLeft < canvas.Margin.Left)
                    newLeft = canvas.Margin.Left;
                elementVm.PosLeft = newLeft;

                double newTop = e.GetPosition(canvas).Y - firstYPos - canvas.Margin.Top;
                // newTop inside canvas bottom-border?
                if (newTop > canvas.Margin.Top + canvas.ActualHeight - element.ActualHeight)
                    newTop = canvas.Margin.Top + canvas.ActualHeight - element.ActualHeight;
                // newTop inside canvas top-border?
                else if (newTop < canvas.Margin.Top)
                    newTop = canvas.Margin.Top;
                elementVm.PosTop = newTop;
            }
        }

        private void OnUnloaded(object sender, RoutedEventArgs e)
        {
            Dispose();
        }

        #region IDisposable

        private void ReleaseUnmanagedResources()
        {
            Loaded -= OnLoaded;
            MouseLeftButtonDown -= OnMouseLeftButtonDown;
            PreviewMouseLeftButtonUp -= OnPreviewMouseLeftButtonUp;
            MouseMove -= OnMouseMove;
            Unloaded -= OnUnloaded;
        }

        public void Dispose()
        {
            ReleaseUnmanagedResources();
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}