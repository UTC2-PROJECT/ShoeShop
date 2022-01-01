using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ShopSportShoes.Areas.Identity.Data;
using ShopSportShoes.Models;
using ShopSportShoes.Repositories;
using ShopSportShoes.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopSportShoes.Services
{
    public class UserManagerService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IPasswordHasher<IdentityUser> _passwordHasher;
        public UserManagerService(UserManager<IdentityUser> userManager, IPasswordHasher<IdentityUser> passwordHasher)
        {
            _userManager = userManager;
            _passwordHasher = passwordHasher;
        }

        public async Task<List<IdentityUser>> GetAllAsync()
        {
            var userRoles = await _userManager.GetUsersInRoleAsync("Admin");
            return userRoles.ToList();
        }

        public async Task<List<string>> GetRolesAsync(string email)
        {
            var identityUser = await _userManager.FindByEmailAsync(email);
            var roles = await _userManager.GetRolesAsync(identityUser);
            return roles.ToList();
        }

        public async Task CreateIdentityUserAsync(User user)
        {
            IdentityUser identityUser = new() { UserName = user.Name, Email = user.Email};
            await _userManager.CreateAsync(identityUser, user.Password);
            await _userManager.AddToRolesAsync(identityUser, user.Roles);
        }
        public async Task UpdateIdentityUserAsync(User user, List<string> currentRoles)
        {
            var identityUser = await _userManager.FindByEmailAsync(user.Email);
            identityUser.Email = user.Email;
            identityUser.UserName = user.Name;
            identityUser.PasswordHash = _passwordHasher.HashPassword(identityUser, user.Password);
            await _userManager.UpdateAsync(identityUser);

            await _userManager.RemoveFromRolesAsync(identityUser, currentRoles);
            await _userManager.AddToRolesAsync(identityUser, user.Roles);
        }
        public async Task DeleteUserByEmailAsync(string email)
        {
            var identityUser = await _userManager.FindByEmailAsync(email);
            await _userManager.DeleteAsync(identityUser);
        }
    }
}
