using System.Collections;
using System.Collections.Generic;
using SS.Business.Models.User;

namespace Test.Business.ClassData
{
    public class UserForRegisterData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                    new UserForRegisterDto
                    {
                        FirstName = "First",
                        LastName = "Last",
                        Email = "Email",
                        UserName = "UserName",
                        Password = "Password"
                    },
                };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class UserWithPasswordData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                    new UserDto
                    {
                        Id = 1,
                        FirstName = "First",
                        LastName = "Last",
                        Email = "Email",
                        UserName = "UserName",
                        DisplayName = "DisplayName"
                    },
                    "password"
                };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class UserData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                    new UserDto
                    {
                        Id = 1,
                        FirstName = "First",
                        LastName = "Last",
                        Email = "Email",
                        UserName = "UserName",
                        DisplayName = "DisplayName"
                    },
                };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}