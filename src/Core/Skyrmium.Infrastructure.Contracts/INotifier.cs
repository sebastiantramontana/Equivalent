using System;

namespace Skyrmium.Infrastructure.Contracts
{
   public interface INotifier
   {
      void Notify(string title, string message, Severity severity);
      void Notify(string title, Exception exception);
   }
}
