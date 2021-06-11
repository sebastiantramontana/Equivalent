using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skyrmium.Api.Implementations.Errors
{
   public enum ErrorType
   {
      Bussiness,
      DataNotFound,
      EntityAlreadyExists,
      MissingIdForUpdate,
      MissingIdForDelete,
   }
}
