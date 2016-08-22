﻿using Api.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : BaseController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;            
        }

        [HttpPost]
        [Route("[action]")]
        public async System.Threading.Tasks.Task<IActionResult> SignIn([FromBody]dynamic loginViewModel)
        {
            if (loginViewModel == null)
            {
                throw new System.ArgumentNullException(nameof(loginViewModel));
            }

            //var error = await _signInManager.PreSignInCheck(user);
            //if (error != null)
            //{
            //    return error;
            //}

            //if (await IsLockedOut(user))
            //{
            //    return await LockedOut(user);
            //}
            string password = loginViewModel.Password;
            string username = loginViewModel.Email;

            var user = await _userManager.FindByNameAsync(username);
                       
            if (await _userManager.CheckPasswordAsync(user, password))
            {
                //await ResetLockout(user);
                //return SignInResult.Success;
                return new ObjectResult(_userManager.FindByEmailAsync(user.Email));
            }

            //Logger.LogWarning(2, "User {userId} failed to provide the correct password.", await UserManager.GetUserIdAsync(user));

            //if (_userManager.SupportsUserLockout && lockoutOnFailure)
            //{
            //    // If lockout is requested, increment access failed count which might lock out the user
            //    await _userManager.AccessFailedAsync(user);
            //    if (await _userManager.IsLockedOutAsync(user))
            //    {
            //        return await LockedOut(user);
            //    }
            //}
            //return SignInResult.Failed;
            // If we got this far, something failed, redisplay form
            return new BadRequestObjectResult(Microsoft.AspNetCore.Identity.SignInResult.Failed);
        }
    }
}