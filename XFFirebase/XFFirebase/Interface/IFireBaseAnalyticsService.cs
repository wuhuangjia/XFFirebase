using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFFirebase.Interface
{
    public interface IFireBaseAnalyticsService
    {
        void LogEvent(string name, Dictionary<string, object> boundle);

    }
}
