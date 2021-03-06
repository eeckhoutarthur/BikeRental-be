﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProjectBikeRental.DTO;
using ProjectBikeRental.Models;

namespace ProjectBikeRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ICustomerRepository _customerRepository;
        private readonly IConfiguration _config;

        public AccountController(
          SignInManager<IdentityUser> signInManager,
          UserManager<IdentityUser> userManager,
          ICustomerRepository customerRepository,
          IConfiguration config)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _customerRepository = customerRepository;
            _config = config;
        }

        /// <summary>
        /// Inloggen van een bestaande gebruiker
        /// </summary>
        /// <param name="model">De gegevens van de gebruiker</param>
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<string>> Login(LoginDTO model)
        {
            var user = await _userManager.FindByNameAsync(model.Email);

            if (user != null)
            {
                var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);

                if (result.Succeeded)
                {
                    string token = await GetTokenAsync(user);
                    return Created("", token); //returns only the token                    
                }
            }
            return BadRequest();
        }

        /// <summary>
        /// Registreren van een nieuwe gebruiker
        /// </summary>
        /// <param name="model">De gegevens van de nieuwe gebruiker</param>
        /// <returns></returns>
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<ActionResult<String>> Register(RegisterDTO model)
        {
            IdentityUser user = new IdentityUser { UserName = model.Email, Email = model.Email };
            Customer customer = new Customer { LastName = model.LastName, FirstName = model.FirstName, Email = model.Email,GSM = "0000"};
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddClaimAsync(user, new Claim("Rol", "user"));
                _customerRepository.Add(customer);
                _customerRepository.SaveChanges();
                string token = await GetTokenAsync(user);
                return Created("", token);
            }
            return BadRequest();
        }

        /// <summary>
        /// Controleert of de email nog kan gebruikt worden als username. Email is namelijk uniek
        /// </summary>
        /// <returns status="200">True wanneer de email nog niet is gebruikt. Zie bovenstaande server response na uitvoering.</returns>
        /// <param name="email">Email.</param>/
        [AllowAnonymous]
        [HttpGet("checkusername")]
        public async Task<ActionResult<Boolean>> CheckAvailableUserName(string email)
        {
            var user = await _userManager.FindByNameAsync(email);
            return user == null;
        }

        private async Task<string> GetTokenAsync(IdentityUser user)
        {
            var claims = new List<Claim>()
            {
              new Claim(JwtRegisteredClaimNames.Sub, user.Email),
              new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
            };
            var roleClaims = await _userManager.GetClaimsAsync(user);
            claims.AddRange(roleClaims);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(null, null, claims, expires: DateTime.Now.AddMinutes(30), signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
