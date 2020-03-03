
namespace CarPooling.Models
{
    public enum MainMenu
    {
        Login = 1,
        Signup,
        Exit
    };

    public enum HomeMenu
    {
        CreateRide = 1,
        BookARide,
        ViewStatus,
        AddNewCar,
        ModifyRide,
        DeleteRide,
        UpdateAccountDetail,
        DeleteUserAccount,
        SignOut,
        Exit,
    };

    public enum BookingStatusMenu
    {
        RideOffer = 1,
        RideRequest,
        RiderDetail,
        SignOut,
        Exit
    };

    public enum UpdateUserDetailMenu
    {
        Name = 1,
        Mobile,
        Email,
        Address,
        DrivingLicence,
        Signout,
        Exit
    };

    public enum ConfirmationResponse
    {
        Yes = 1,
        No
    };

    public enum BookingStatus
    {
        Confirm = 1,
        Rejected,
        Pending,
        Completed,
        Cancel
    };

    public enum UserType
    {
        Owner,
        Traveller
    }

    public enum RideStatus
    {
        Pending,
        Cancel,
        Completed
    }
}

