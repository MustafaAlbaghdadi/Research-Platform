using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspcore_api_db_jwt.Shared
{
    public static class UserType
    {
        // ReSharper disable once InconsistentNaming
        public const string ADMIN = "ADMIN";
        // ReSharper disable once InconsistentNaming
        public const string CLIENT = "CLIENT";

        public const string ADMIN_OR_CLIENT = "ADMIN_OR_CLIENT";
    }
    public static class LoginClaimKey
    {
        // ReSharper disable once InconsistentNaming
        public const string USER_TYPE = "UserType";

        // ReSharper disable once InconsistentNaming
        public const string USERNAME = "Username";

        // ReSharper disable once InconsistentNaming
        public const string USER_ID = "UserId";


    }


}
