using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_DAPPER.Models.Responses
{
    public class ProductResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public bool Status { get; set; }

        public long CategoryId { get; set; }
        
    }
}