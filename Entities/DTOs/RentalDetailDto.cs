using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class RentalDetailDto:IDto
    {
        public int RentalId { get; set; }
        public string CarName { get; set; }
        public string CompanyName { get; set; }
        public DateTime RentDate { get; set; } //Kiralama Tarihi
        public DateTime ReturnDate { get; set; } //Teslim Tarihi
    }
}
