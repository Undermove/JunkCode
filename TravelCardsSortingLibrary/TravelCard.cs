namespace TravelCardsSortingLibrary
{
    public class TravelCard
    {
        public TravelCard(string departurePoint, string destinationPoint)
        {
            this.DeparturePoint = departurePoint;
            this.DestinationPoint = destinationPoint;
        }

        public string DeparturePoint { get; }

        public string DestinationPoint { get; }
    }
}
