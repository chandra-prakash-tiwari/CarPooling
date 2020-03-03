
namespace CarPooling.Models
{
    public class Constant
    {
        public static readonly string MainMenuOptions = "1. Login\n2. Signup\n3. Exit";

        public static readonly string UserMainMenuOptions = "1. Create ride \n2. Book a ride \n3. View request status\n4. Add new car \n5. Modify ride details\n6. Delete ride\n7. Update account details\n8. Delete account\n9. SignOut\n10. Exit";

        public static readonly string RequestStatusOptions = "1. Ride request status\n2. Booking request status\n3. View booking details\n4. SignOut\n5. Exit";

        public static readonly string UpdateUserDetailOptions = "1. Name\n2. Mobile number\n3. Email\n4. Address\n5. Driving licence\n6. Signout\n7. Exit";

        public static readonly string EndRideOptions = "1. Owner\n2. Rider\n3. MainMenu\n4. SignOut\n5. Exit";

        public static readonly string RideResponseOptions = "1. Confirm\n2. Rejected\n3. Waiting";

        public static readonly string UpdateDetailsResponse = "Your details has been updated";

        public static readonly string DeleteAccoutResponse = "You account has been deleted";

        public static readonly string Confirmation = "1. Yes\n2. No";

        public static readonly string InvalidAvailableSeats = "Available seat is less or equal to max capacity";

        public static readonly string InvalidCredentials = "Enter valid credentials";

        public static readonly string ErrorFound = "Sorry some error has found try another time";

        public static readonly string InvalidBookingRequest = "You can not book this ride offer";

        public static readonly string RequestSentToOwner = "Request has been sent to owner. if he/she approve then enjoy your Ride";

        public static readonly string NoRides = "No rides available for this route";

        public static readonly string NoRideOfferCreated = "You have not created any offer request";

        public static readonly string NoCarsAdded = "No cars added. First add car";

        public static readonly string AllowRide = "Now you add ride";

        public static readonly string SeatsFull = "Ride full";

        public static readonly string SeatConfirmed = "You accepted this seat";

        public static readonly string NoRequests = "No requests";

        public static readonly string InValidInput = "Please enter valid value";

        public static readonly string InValidDate = "Please enter valid date";

        public static readonly string City = "City : ";

        public static readonly string UserId = "User id : ";

        public static readonly string Password = "Password : ";

        public static readonly string Name = "Name : ";

        public static readonly string Email = "Email : ";

        public static readonly string Address = "Address : ";

        public static readonly string MobileNumber = "Mobile number : ";

        public static readonly string DrivingLicence = "Driving licence : ";

        public static readonly string CarDetails = "Car details  ";

        public static readonly string CarNumber = "Number : ";

        public static readonly string CarModel = "Car model : ";

        public static readonly string CarMaxSeats = "Max seats : ";

        public static readonly string AvailableSeats = "Available seats : ";

        public static readonly string Pincode = "Pincode : ";

        public static readonly string From = "From ";

        public static readonly string To = "To ";

        public static readonly string TravellingDate = "Travelling Date : ";

        public static readonly string LandMark = "Landmark : ";

        public static readonly string NoOfBookedSeats = "No of booked seats : ";

        public static readonly string ConfirmedBooking = "Your booking has been confirmed. Please contact with owner for more details";

        public static readonly string RejectedBooking = "Booking request has been rejected by the owner";

        public static readonly string WaitingBooking = "Waiting for owner response";

        public static readonly string NoOfViaPlaces = "No of via places : ";

        public static readonly string UserNameNotAvailable = "Sorry this username has taken by someone. Please choose another username";

        public static readonly string ViaPoint = "Via Cities : ";

        public static readonly string Distance = " Distance : ";

        public static readonly string TravellingRate = "Travelling rate(per KM) : ";

        public static readonly string OwnerNotification = "\nSomeone wants to travel with you give response his/her!!!";

        public static readonly string CarSelection = "Select one car for create ride or for returing mainmenu press 0";

        public static readonly string RideSelection = "Select above booking or for exit press 0";

        public static readonly string CorrectSelection = "Select correct booking!!";
    }
}
