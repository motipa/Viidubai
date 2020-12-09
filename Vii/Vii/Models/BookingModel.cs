using System;
using System.Collections.Generic;
using System.Text;

namespace Vii.Models
{
    public class BookingModel
    {
        public string customerName { get; set; }
        public DateTime fromDate { get; set; }
        public TimeSpan Time { get; set; }
        public string bookedTable { get; set; }
        public string venue { get; set; }
        public int bookedCount { get; set; }
        public int numberOfPerson { get; set; }
        public string specialNote { get; set; }
        public string shisha { get; set; }

    }
}
