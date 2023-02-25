using System.ComponentModel;

namespace AnadoluParamApi.Base.Types
{
    public enum RoleEnum
    {
        [Description(Role.Admin)]
        Admin = 1,

        [Description(Role.Member)]
        Member = 2,
    }

    public class Role
    {
        public const string Admin = "admin";
        public const string Member = "member";
    }
}
