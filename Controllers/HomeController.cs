﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsORM.Models;


namespace SportsORM.Controllers
{
    public class HomeController : Controller
    {

        private static Context _context;

        public HomeController(Context DBContext)
        {
            _context = DBContext;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.BaseballLeagues = _context.Leagues
                .Where(l => l.Sport.Contains("Baseball"))
                .ToList();
            return View();
        }

        [HttpGet("level_1")]
        public IActionResult Level1()
        {
            ViewBag.Leagues = _context.Leagues.Where(x => x.Name.Contains("Women")).ToList();
            ViewBag.Hockey = _context.Leagues.Where(x => x.Sport.Contains("Hockey")).ToList();
            ViewBag.NotFootball = _context.Leagues.Where(x => !x.Sport.Contains("Football")).ToList();
            ViewBag.Conferences = _context.Leagues.Where(x => x.Name.Contains("Conference")).ToList();
            ViewBag.Atlantic = _context.Leagues.Where(x => x.Name.Contains("Atlantic")).ToList();

            ViewBag.Dallas = _context.Teams.Where(x => x.Location.Contains("Dallas")).ToList();
            ViewBag.Raptors = _context.Teams.Where(x => x.TeamName.Contains("Raptors")).ToList();
            ViewBag.City = _context.Teams.Where(x => x.Location.Contains("City")).ToList();
            ViewBag.TStart = _context.Teams.Where(x => x.TeamName.StartsWith("T")).ToList();
            ViewBag.AlphaLocation = _context.Teams.OrderBy(x => x.Location).ToList();
            ViewBag.ReverseAlpha = _context.Teams.OrderByDescending(x => x.TeamName).ToList();
            return View();
        }

        [HttpGet("level_2")]
        public IActionResult Level2()
        {
            return View();
        }

        [HttpGet("level_3")]
        public IActionResult Level3()
        {
            return View();
        }

    }
}