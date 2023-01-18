﻿using ECommerce.IdentityServer.Models;
using IdentityModel;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.IdentityServer.Services
{
    //kulanıcı giriş yaparken bilgilerinin doğrulunun kontrolü
    public class IdentityResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public IdentityResourceOwnerPasswordValidator(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var existUser = await _userManager.FindByEmailAsync(context.UserName);
            if (existUser == null)
            {
                var errors= new Dictionary<string, object>();
                errors.Add("errors", "email adresiniz veya şifreniz yanlıştır.");
                context.Result.CustomResponse = errors;
            }

            var passwordCheck= await _userManager.CheckPasswordAsync(existUser,context.Password);
            if (passwordCheck == false)
            {
                var errors = new Dictionary<string, object>();
                errors.Add("errors", "email adresiniz veya şifreniz yanlıştır.");
                context.Result.CustomResponse = errors;
            }

            context.Result = new GrantValidationResult(existUser.Id.ToString(), OidcConstants.AuthenticationMethods.Password);
        }
    }
}
