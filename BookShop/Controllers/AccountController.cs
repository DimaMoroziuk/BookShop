using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DAL.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;

namespace BookShop.Controllers
{
    public class AccountController : ApiController
    {
        [Route("api/User/Register")]
        [HttpPost]
        //[AllowAnonymous]
        public IdentityResult Register(AccountModel model) {
            var userStore = new UserStore<ApplicationUser>(new ApplicationDbContext());
            var manager = new UserManager<ApplicationUser>(userStore);
            var user = new ApplicationUser() { UserName = model.UserName, Email = model.Email };
            user.FullName = model.FullName;
            IdentityResult result = manager.Create(user, model.Password);
            return result;
        }

        [HttpGet]
        [Route("api/GetUserClaims")]
        [Authorize]
        public AccountModel GetUserClaims() {
            var identityClaims = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identityClaims.Claims;
            AccountModel model = new AccountModel()
            {
                UserName = identityClaims.FindFirst("Username").Value,
                Email = identityClaims.FindFirst("Email").Value,
                FullName = identityClaims.FindFirst("FullName").Value,
                LoggedOn = identityClaims.FindFirst("LoggedOn").Value
            };
            return model;
        }
        }

   }

