using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baalhyttebooking
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Beelhyttebooking;");
            Console.WriteLine();
            Console.WriteLine("Opgave 1.Opret Klassen Boernegruppen");
            Console.WriteLine();
            Boernegruppe b1 = new Boernegruppe("1", "navn1", "putterne", 7);
            Boernegruppe b2 = new Boernegruppe("2", "navn2", "mellem", 13);
            Console.WriteLine(b1);
            Console.WriteLine(b2);
            Console.WriteLine();

            Console.WriteLine("Opgave 2.Opret Klassen Reservation");
            Console.WriteLine();
            Reservation r1 = new Reservation(1, new DateTime(2023, 6, 14), b1);
            Reservation r2 = new Reservation(2, new DateTime(2023, 6, 15), b2);
            Console.WriteLine(r1);
            Console.WriteLine(r2);

            Console.WriteLine("Opgave 6. Opret CRUD Metoder");
            Console.WriteLine();
            Reservationer reservationer = new Reservationer(2023);
            Boernegruppe g1 = new Boernegruppe("001", "Gruppe 1", "pusling", 5);
            Boernegruppe g2 = new Boernegruppe("002", "Gruppe 2", "tumling", 7);

            Reservation reservation1 = new Reservation(1, new DateTime(2023, 6, 20, 12, 0, 0), g1);
            Reservation reservation2 = new Reservation(2, new DateTime(2023, 6, 22, 14, 0, 0), g2);

            //Registrer reservation
            reservationer.RegistrerReservation(reservation1);
            reservationer.RegistrerReservation(reservation2);


            Console.WriteLine("Udskriv alle reservationer:");
            reservationer.PrintReservationer();
            Console.WriteLine();

            // Fjern en reservation
            reservationer.FjernReservation(reservation1);

            // Udskriv alle reservationer igen
            Console.WriteLine("Efter fjernelse af reservation:");
            reservationer.PrintReservationer();
            Console.WriteLine();


        }
    }
}