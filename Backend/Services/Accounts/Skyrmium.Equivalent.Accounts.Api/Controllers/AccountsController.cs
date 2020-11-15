using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Skyrmium.Equivalent.Accounts.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Skyrmium.Equivalent.Accounts.Api.Controllers
{
   [ApiController]
   [Route("[controller]")]
   public class AccountsController : ControllerBase
   {
      private readonly ILogger<AccountsController> _logger;

      public AccountsController(ILogger<AccountsController> logger)
      {
         _logger = logger;
      }

      [HttpGet]
      public IEnumerable<Account> Get()
      {
         return Array.Empty<Account>();
      }
   }
}
