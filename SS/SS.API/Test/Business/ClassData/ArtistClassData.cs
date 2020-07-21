using System;
using System.Collections;
using System.Collections.Generic;
using SS.Business.Models.Artist;
using SS.Business.Pagination;

namespace Test.Business.ClassData
{
    public class ArtistToCreateParamsData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                    new ArtistToCreateDto
                    {
                        Name = "New Artist",
                    },
                };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class ArtistPageParamsData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                    new ArtistPageParams
                    {
                        PN = 1,
                        OrderBy = "",
                        Search = "",
                        // IPP = 10
                    },
                };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class ArtistUpdateAndIdParamsData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            var now = new DateTime();
            yield return new object[] {
                1,
                new ArtistForUpdateDto
                {
                    Id = 1,
                    Name = "testName",
                    CareerBeginDate = now,
                    Group = true,
                    Verified = false,
                    HomeCountryId = 1,
                    CurrentCountryId = 1,
                    CreatedBy = 1,
                    CreatedDate = now,
                    HomeUsCity= "homeCity",
                    HomeUsZipcode = "99999",
                    HomeWorldRegion = "",
                    HomeWorldCity = "",
                    HomeUsStateId = 1,
                    HomeUsCityId = 1
                },
            };
            yield return new object[]{
                1,
                new ArtistForUpdateDto
                {
                    Id = 1,
                    Name = "testName",
                    CareerBeginDate = now,
                    Group = true,
                    Verified = false,
                    HomeCountryId = 1,
                    CurrentCountryId = 1,
                    CreatedBy = 1,
                    CreatedDate = now,
                    HomeUsCity= "homeCity",
                    HomeUsZipcode = "99999",
                    HomeWorldRegion = "",
                    HomeWorldCity = "",
                    HomeUsStateId = 1,
                    // HomeUsCityId = 1
                },
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}