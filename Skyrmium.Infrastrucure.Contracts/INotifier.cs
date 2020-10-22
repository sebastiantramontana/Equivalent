using System;

namespace Skyrmium.Infrastrucure.Contracts
{
   public interface INotifier
   {
      void Notify(string title, string message, Severity severity);
      void Notify(string title, Exception exception);
   }
}
