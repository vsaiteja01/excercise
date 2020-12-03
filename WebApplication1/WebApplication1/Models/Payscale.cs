using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class Payscale
    {
        public string PayBand { get; set; }
        public double? BasicSalary { get; set; }
        public double? Hra { get; set; }
        public double? Ta { get; set; }
        public double? Da { get; set; }
        public double? NetSalary { get; set; }
        public double? InHandSalary { get; set; }
    }
}
