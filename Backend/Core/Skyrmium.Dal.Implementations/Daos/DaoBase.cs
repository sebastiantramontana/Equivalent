using Skyrmium.Dal.Contracts.Daos;
using System;

namespace Skyrmium.Dal.Implementations.Daos
{
   public abstract class DaoBase : IDao
   {
      public Guid Id { get; set; }
   }
}
