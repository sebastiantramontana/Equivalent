using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skyrmium.Dal.Contracts
{
   public interface IDao
   {
      long Id { get; set; }
      Guid DistributedId { get; set; }
   }
}
