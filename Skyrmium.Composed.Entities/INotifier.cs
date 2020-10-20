using System;
using System.Collections.Generic;
using System.Text;

namespace Skyrmium.Composed.Entities
{
    public interface INotifier
    {
        void Notify(string title, string message, Severity severity);
        void Notify(string title, Exception exception);
    }
}
