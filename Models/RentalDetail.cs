using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComicSystem.Models
{
    public class RentalDetail
{
    public int RentalDetailID { get; set; }
    public int RentalID { get; set; }
    public int ComicBookID { get; set; }
    public int Quantity { get; set; }
    public decimal PricePerDay { get; set; }

    public Rental Rental { get; set; }
    public ComicBook ComicBook { get; set; }
}

}