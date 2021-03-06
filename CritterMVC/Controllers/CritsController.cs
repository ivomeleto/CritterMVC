﻿using System;
using System.Linq;
using System.Web.Mvc;
using Critter.Data;
using CritterMVC.ViewModels;
using Critter.Models;

namespace CritterMVC.Controllers
{
    public class CritsController : BaseController
    {
        public CritsController(ICritData data)
            : base(data)
        {

        }
        // GET: Crits
        public ActionResult Index()
        {
            //TODO reverse crits order of appearance
            var crits = this.Data.Crit
                .All().Select(CritViewModel.ViewModel)
                .OrderByDescending(x => x.CreatedAt).Take(10);
            return this.View(crits);
        }

        public ActionResult AddCrit()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult AddCrit([Bind(Include = "Text")] Crit crit)
        {
            crit.AuthorUser = this.UserProfile;
            crit.CreatedAt = DateTime.Now;

            if (ModelState.IsValid)
            {
                this.Data.Crit.Add(crit);
                this.Data.Crit.SaveChanges();
            }

            return RedirectToAction("Index", "Crits");
        }

        //public ActionResult AddVote(Crit crit)
        //{
        //    crit.Votes.Add(new Vote()
        //    {
        //        User = this.UserProfile
        //    });
        //    this.Data.Crit.Update(crit);
        //    this.Data.SaveChanges();

        //    return this.Content(crit.Votes.Count.ToString());
        //}

        public ActionResult PostAllCrits()
        {
            var crits = this.Data.Crit
                .All().Select(CritViewModel.ViewModel)
                .OrderByDescending(x => x.CreatedAt).Take(10);
            return this.View(crits);
        }

       
    }
}