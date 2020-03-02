
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
        Exit,
        CreateRide,
        BookARide,
        ViewStatus,
        AddNewCar,
        ModifyRide,
        DeleteRide,
        UpdateAccountDetail,
        DeleteUserAccount,
        SignOut,
    };

    public enum BookingStatusMenu
    {
        RideOffer = 1,
        RideRequest,
        RiderDetail,
        SignOut,
        Exit
    };

    public enum RideEndMenu
    {
        Owner = 1,
        Rider,
        MainMenu,
        SignOut,
        Exit
    }

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

