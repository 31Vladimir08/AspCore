namespace BusinessLogic.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class DateRange
    {
        [DataType(DataType.Date)]
        public DateTime? FromDateTime { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ToDateTime { get; set; }
    }
}
