using System;

namespace SS.Business.Calculations
{
    public static class ArtistCalculations
    {
        public static int CalculateArtistYearsActive(DateTime begin, DateTime? end)
        {
            int yearsActive = 0;
            if (!end.HasValue)
            {
                yearsActive = DateTime.Today.Year - begin.Year;
            }
            else
            {
                yearsActive = end.Value.Year - begin.Year;
            }

            if (begin.AddYears(yearsActive) > DateTime.Today && yearsActive > 0) { yearsActive--; }

            return yearsActive;
        }
    }
}