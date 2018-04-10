using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameOfLife.API.Models
{
    public class NextDataRequest
    {
        public int[,] Data { get; set; }
    }
}
