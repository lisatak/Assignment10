using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment10.Models.ViewModels
{
    //This is for all the paging at the bottom of the page
    public class PageNumberingInfo
    {
        public int NumItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalNumItems { get; set; }

        //Calculate the Number of Pages
        public int NumPages => (int) Math.Ceiling((decimal)TotalNumItems / NumItemsPerPage);
    }
}
