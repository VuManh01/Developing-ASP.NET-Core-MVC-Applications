using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComicSystemAPI.Models
{
   public class Rental
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int ComicBookId { get; set; }
    public int Quantity { get; set; }
    public DateTime RentalDate { get; set; }
    public DateTime ReturnDate { get; set; }
}

}