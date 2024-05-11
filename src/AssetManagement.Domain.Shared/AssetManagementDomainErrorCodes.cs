namespace AssetManagement
{
    public static class AssetManagementDomainErrorCodes
    {
        // Asset related errors
        public const int AssetAlreadyExists = 1001;
        public const int AssetNotFound = 1002;
        public const int AssetCheckoutFailed = 1003;
        public const int AssetCheckinFailed = 1004;

        // User related errors
        public const int UserNotFound = 2001;
        public const int UserNotAuthorized = 2002;

        // General errors
        public const int UnknownError = 9999;
    }
}
