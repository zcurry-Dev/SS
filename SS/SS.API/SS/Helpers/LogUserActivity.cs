using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using SS.Data.Interfaces;

namespace SS.Helpers
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
            if (resultContext.HttpContext.User.Identities.FirstOrDefault().IsAuthenticated)
            {
                await _user.UpdateLastActiveForUser(resultContext.HttpContext.User);
            }
        }
    }
}