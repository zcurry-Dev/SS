using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using SS.API.Data.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.AspNetCore.Identity;
using SS.API.Models;

namespace SS.API.Helpers
{
    public class LogUserActivity : IAsyncActionFilter
    {
        private readonly UserManager<Ssuser> _userManager;
        public LogUserActivity(UserManager<Ssuser> userManager)
        {
            _userManager = userManager;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var resultContext = await next();

            var user = await _userManager.GetUserAsync(resultContext.HttpContext.User);
            user.LastActive = DateTime.Now;

            await _userManager.UpdateAsync(user);
        }
    }
}