using System.Collections.Generic;
using System.Linq;

namespace TravelCardsSortingLibrary
{
    public static class TravelCardsSortingUtils
    {
        public static List<TravelCard> SortTravelCards(List<TravelCard> cardsList2)
        {
            List<TravelCard> cardsList = new List<TravelCard>(cardsList2);
            TravelCard[] sortedList = new TravelCard[cardsList.Count];

            var departureToDestination = cardsList.ToDictionary(card => card.DeparturePoint, card => card.DestinationPoint);
            var destinationToDeparture = cardsList.ToDictionary(card => card.DestinationPoint, card => card.DeparturePoint);
            int leftIndex = 0;
            int rightIndex = cardsList.Count - 1;

            int i = 0;

            while (cardsList.Count > 0)
            {
                foreach (TravelCard card in cardsList)
                {
                    if (!destinationToDeparture.ContainsKey(card.DeparturePoint))
                    {
                        sortedList[leftIndex] = card;
                        RemoveSortedCard(cardsList, card, departureToDestination, destinationToDeparture);
                        leftIndex++;
                        break;
                    }

                    if (!departureToDestination.ContainsKey(card.DestinationPoint))
                    {
                        sortedList[rightIndex] = card;
                        RemoveSortedCard(cardsList, card, departureToDestination, destinationToDeparture);
                        rightIndex--;
                        break;
                    }
                }
                i++;
            }

            return sortedList.ToList();
        }

        private static void RemoveSortedCard(List<TravelCard> cardsList, TravelCard card, Dictionary<string, string> departureToDestination,
            Dictionary<string, string> destinationToDeparture)
        {
            cardsList.Remove(card);
            departureToDestination.Remove(card.DeparturePoint);
            destinationToDeparture.Remove(card.DestinationPoint);
        }
    }
}
