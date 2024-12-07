using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComicSystemAPI.Models
{
    public class ComicBook
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double PricePerDay { get; set; }
}

}