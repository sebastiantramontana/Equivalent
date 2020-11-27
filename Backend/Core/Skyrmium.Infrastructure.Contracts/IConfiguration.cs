using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skyrmium.Infrastructure.Contracts
{
   public interface IConfiguration
   {
      string StringConnection { get; }
   }
}
