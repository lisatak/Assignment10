using Assignment10.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment10.Components
{

    public class ContactTeamViewComponent : ViewComponent
    {
        //get context
        private BowlingLeagueContext _context;

        //constructor
        public ContactTeamViewComponent (BowlingLeagueContext ctx)
        {
            _context = ctx;
        }

        //save current team in viewbag (for highlighting currect team on page) and get each team name to be listed as buttons on the page
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedTeam = RouteData?.Values["teamid"];

            return View(_context.Teams
                .Distinct()
                .OrderBy(x => x)
                .ToList());
        }
        
    }
}
