namespace MediCare.Common.Enum
{
    public enum ResultStatusEnum
    {
        Success = 0,
        Error = 1,
        InvalidUserNameOrPassword = 3,
        Duplicated = 4,
        HttpError = 5,
        PinCodeNotExpired = 6,
        UserNotVerified = 7
    }
}
