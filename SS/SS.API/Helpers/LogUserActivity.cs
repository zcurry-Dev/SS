using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using SS.API.Data.Interfaces;

namespace SS.API.Helpers
{
    public class LogUserActivity : IAsyncActionFilter
    {
        private readonly IUserDataRepository _user;
        public LogUserActivity(IUserDataRepository user)
        {
            _user = user;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var resultContext = await next();

            await _user.UpdateLastActiveForUser(resultContext.HttpContext.User);
        }
    }
}