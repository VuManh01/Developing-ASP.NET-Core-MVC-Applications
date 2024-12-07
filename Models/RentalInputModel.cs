using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComicSystem.Models
{
    public class RentalInputModel
{
    public int CustomerID { get; set; }
    public DateTime RentalDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public int ComicBookID { get; set; }
    public int Quantity { get; set; }
}

}