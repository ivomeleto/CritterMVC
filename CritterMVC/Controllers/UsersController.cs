﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Critter.Data;
using CritterMVC.ViewModels;
using Critter.Models;

namespace CritterMVC.Controllers
{
    [Authorize]
    public class UsersController : BaseController
    {
        public UsersController(ICritData data)
            :base(data)
        {
        }

        public ActionResult Index(string username)
        {
            var user = this.Data.Users
                .All()
                .FirstOrDefault(x => x.UserName == username);


            if (user == null)
            {
                return this.HttpNotFound("User does not exist! For real!");
            }

            var userViewModel = new UserViewModel()
            {
                Id = user.Id,
                UserName = user.UserName,
                AvatarUrl = user.AvatarUrl,
                PostedCrits = user.PostedCrits.Select(x => new CritViewModel()
                {
                    Id = x.CritId,
                    Author = x.AuthorUser,
                    Recipient = x.RecipientUser,
                    CreatedAt = x.CreatedAt,
                    Text = x.Text
                }),
                ReceivedCrits = user.ReceivedCrits.Select(x => new CritViewModel()
                {
                    Id = x.CritId,
                    Author = x.AuthorUser,
                    Recipient = x.RecipientUser,
                    CreatedAt = x.CreatedAt,
                    Text = x.Text
                })
            };
            
            return this.View(userViewModel);

            
        }
    }
}