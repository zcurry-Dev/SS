using System;
using Microsoft.AspNetCore.Http;

namespace SS.API.Helpers
{
    public static class Extensions
    {
        public static void AddApplicationError(this HttpResponse response, string message)
        {
            response.Headers.Add("Application-Error", message);
            response.Headers.Add("Access-Control-Expose-Headers", "Application-Error");
            response.Headers.Add("Access-Control-Allow-Origin", "*");
        }

        public static int CalculateArtistYearsActive(this DateTime theDateTime)
        {
            // var yearsActive = DateTime.Today.Year - theDateTime.Year;
            var yearsActive = DateTime.Today.Year - theDateTime.Year + 1;
            if (theDateTime.AddYears(yearsActive) > DateTime.Today) { yearsActive--; }

            return yearsActive;
        }
    }
}