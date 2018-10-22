using System;
using LiveCharts;

namespace Vkm.ComplexSim.View.Elements.ViewModel
{
    public class VkmOscilloscopeViewModel : ElementViewModelBase
    {
        public VkmOscilloscopeViewModel(int value, string name, int posTop, int posLeft, Enum page) : base(value, name, posTop, posLeft, page)
        {
        }

        public SeriesCollection SeriesCollection
        {
            get { return GetProperty(() => SeriesCollection); }
            set { SetProperty(() => SeriesCollection, value); }
        }
    }
}