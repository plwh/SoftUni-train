using System;

namespace _02.Reservation
{
    class Program
    {
        static void Main(string[] args)
        {
            int reservationDay = int.Parse(Console.ReadLine());
            int reservationMonth = int.Parse(Console.ReadLine());
            int accomodationDay = int.Parse(Console.ReadLine());
            int accomodationMonth = int.Parse(Console.ReadLine());
            int leaveDay = int.Parse(Console.ReadLine());
            int leaveMonth = int.Parse(Console.ReadLine());

            double price = 30;
            int days = leaveDay - accomodationDay;

            if (reservationDay <= accomodationDay - 10)
            {
                price = 25 * days;
            }
            else if (reservationMonth < accomodationMonth)
            {
                price = 25 * days;
                price -= (price * 0.2);
            }
            else 
            {
                price *= days;
            }

            Console.WriteLine($"Your stay from {accomodationDay}/{accomodationMonth} to {leaveDay}/{leaveMonth} will cost {price:F2}");
        }
    }
}
