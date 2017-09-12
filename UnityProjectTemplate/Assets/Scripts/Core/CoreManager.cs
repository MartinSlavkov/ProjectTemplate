using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core
{
    public class CoreManager
    {
        public EventAggregator EventAgreggator;

        public CoreManager(EventAggregator aggregator)
        {
            EventAgreggator = aggregator;
        }

    }
}
