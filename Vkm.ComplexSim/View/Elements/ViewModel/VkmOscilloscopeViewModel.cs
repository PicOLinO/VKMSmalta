﻿using System;
using LiveCharts;

namespace Vkm.ComplexSim.View.Elements.ViewModel
{
    public class VkmOscilloscopeViewModel : ElementViewModelBase
    {
        public VkmOscilloscopeViewModel(int value, string name, int posTop, int posLeft, Enum page, int width, int height) : base(value, name, posTop, posLeft, page, width, height)
        {
        }

        public SeriesCollection SeriesCollection
        {
            get { return GetProperty(() => SeriesCollection); }
            set { SetProperty(() => SeriesCollection, value); }
        }
    }
}