using System;

namespace Project.AppFrontendDomain.Pang.Data.Saveable
{
    [Serializable]
    public class UserData
    {
        public const string UserDataKey = "userData";

        public string currentLevelId;
    }
}