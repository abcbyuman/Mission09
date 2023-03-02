using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09.Models.ViewModels
{
    public class PageInfo
    {
        public int TotalNumProjects { get; set; }
        public int ProjectPerPage { get; set; }
        public int CurrentPage { get; set; }

        //Determine how many pages we need
        public int TotalPages => (int) Math.Ceiling((double) TotalNumProjects / ProjectPerPage);
    }
}
