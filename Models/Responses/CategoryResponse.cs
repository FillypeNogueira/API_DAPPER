using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_DAPPER.Models.Responses
{
    public class CategoryResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool Status { get; set; }
        
    }
}