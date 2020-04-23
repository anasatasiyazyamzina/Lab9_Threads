using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLGUI.EventsLib
{
    public class FilterChangeEventArgs : EventArgs
    {
        public string Param { get; internal set; }

        public FilterChangeEventArgs(string paramValue)
        {
            Param = paramValue;
        }
    }
    public class SetTimerEventArgs : EventArgs
    {
        public string Param { get; internal set; }

        public SetTimerEventArgs(string paramValue)
        {
            Param = paramValue;
        }
    }
}
