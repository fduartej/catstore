using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace catstore.DTO.gorest
{
    public class Users
    {
         public int id { get; set; }
         public string? name { get; set; }
         public string? email { get; set; }
         public string? gender { get; set; }

    }
}