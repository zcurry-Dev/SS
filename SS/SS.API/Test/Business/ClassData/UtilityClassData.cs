using System.Collections;
using System.Collections.Generic;
using SS.Business.Models.Utility;

namespace Test.Business.ClassData
{
    public class CityToCreateParamsData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                    new CityToCreateDto
                    {
                        CityName = "Test City Name",
                        StateId = 1
                    },
                };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class UsZipCodeToCreateParamsData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                    new UsZipCodeToCreateDto
                    {
                        ZipCode = "99999",
                        CityId = 1
                    },
                };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}