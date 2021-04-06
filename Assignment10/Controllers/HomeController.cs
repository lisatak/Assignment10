using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Assignment10.Models;
using Microsoft.EntityFrameworkCore;
using Assignment10.Models.ViewModels;

namespace Assignment10.Controllers
{
    public class HomeController : Controller
    {
        //set variables, get context
        private readonly ILogger<HomeController> _logger;
        private BowlingLeagueContext _context { get; set; }

        //constructor
        public HomeController(ILogger<HomeController> logger, BowlingLeagueContext ctx)
        {
            _logger = logger;
            _context = ctx;
        }

        //get index page
        public IActionResult Index(long? teamid, string teamname, int pageNum = 1)
        {
            //set number of bowlers per page
            int pageSize = 5;

            //return view with bowlers information
            return View(new IndexViewModel
            {
                //get the correct bowlers for the page
                Bowlers = (_context.Bowlers
                    //display all bowlers if no team has been selected
                    .Where(b => b.TeamId == teamid || teamid == null)
                    .OrderBy(b => b.BowlerFirstName)
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize)
                    .ToList()),

                //get the correct page navigation
                PageNumberingInfo = new PageNumberingInfo
                {
                    NumItemsPerPage = pageSize,
                    CurrentPage = pageNum,

                    //If no team has been selected, then det the full count. 
                    //Otherwise, only count the number from the team that has been selected. 
                    TotalNumItems = (teamid == null ? _context.Bowlers.Count() : 
                        _context.Bowlers.Where(x => x.TeamId == teamid).Count())
                },

                //pass team name
                TeamName = teamname
            });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
