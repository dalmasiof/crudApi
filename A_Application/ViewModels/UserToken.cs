using System;
using System.Collections.Generic;

namespace crudApi.A_Application.ViewModels
{
  public class UserToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public string Name { get; set; }
    }
}