using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotByDot.Core.Domain.Models
{
    public class CircleSet
    {
        public int Id { get; set; }
        public List<Circle> Circles { get; set; } = new();
    }
}
