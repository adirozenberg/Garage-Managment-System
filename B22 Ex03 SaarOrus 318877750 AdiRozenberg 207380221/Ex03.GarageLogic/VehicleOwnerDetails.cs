namespace Ex03.GarageLogic
{
    public class VehicleOwnerDetails
    {
        private readonly string r_OwnerName;
        private readonly int r_OwnerPhoneNumber;

        public string OwnerName
        {
            get { return r_OwnerName; }
        }

        public int OwnerPhoneNumber
        {
            get { return r_OwnerPhoneNumber; }
        }

        public VehicleOwnerDetails(string i_OwnerName, int i_OwnerPhoneNumber)
        {
            r_OwnerName = i_OwnerName;
            r_OwnerPhoneNumber = i_OwnerPhoneNumber;
        }
    }
}