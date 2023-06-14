using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baalhyttebooking
{
    public class Reservationer
    {
    public int ID { get; set; }
        public Dictionary<int, Reservation> Reservations { get; set; }

        public Reservationer(int id)
        {
            ID = id;
            Reservations = new Dictionary<int, Reservation>();
        }

        public void RegistrerReservation(Reservation reservation)
        {
            if (ReservationOK(reservation))
            {
                Reservations.Add(reservation.ID, reservation);
                Console.WriteLine("Reservationen er blevet registreret.");
            }
            else
            {
                Console.WriteLine("Reservationen kunne ikke registreres.");
            }
        }

        public void PrintReservationer()
        {
            foreach (var reservation in Reservations.Values)
            {
                Console.WriteLine(reservation);
            }
        }

        public void FjernReservation(Reservation reservation)
        {
            if (Reservations.ContainsKey(reservation.ID))
            {
                Reservations.Remove(reservation.ID);
                Console.WriteLine("Reservationen er blevet fjernet.");
            }
            else
            {
                Console.WriteLine("Reservationen blev ikke fundet.");
            }
        }

        public int AntalReservationer(Boernegruppe bGruppe)
        {
            int count = 0;
            foreach (var reservation in Reservations.Values)
            {
                if (reservation.Boernegruppe == bGruppe)
                {
                    count++;
                }
            }
            return count;
        }

        public bool ReservationLedig(Reservation reservation)
        {
            foreach (var existingReservation in Reservations.Values)
            {
                if (existingReservation.Tidspunkt == reservation.Tidspunkt)
                {
                    return false;
                }
            }
            return true;
        }

        public bool ReservationsTidspunktOK(Reservation reservation)
        {
            if (reservation.Tidspunkt.DayOfWeek != DayOfWeek.Thursday)
            {
                return false;
            }

            List<int> gyldigeTimer = new List<int> { 12, 14, 16, 18, 20 };
            if (!gyldigeTimer.Contains(reservation.Tidspunkt.Hour))
            {
                return false;
            }

            if (reservation.Tidspunkt.Minute != 0 || reservation.Tidspunkt.Second != 0 || reservation.Tidspunkt.Millisecond != 0)
            {
                return false;
            }

            return true;
        }

        public bool ReservationOK(Reservation reservation)
        {
            if (reservation.Boernegruppe == null)
            {
                Console.WriteLine("Reservationen skal have en reference til en Børnegruppe.");
                return false;
            }

            if (AntalReservationer(reservation.Boernegruppe) >= 2)
            {
                Console.WriteLine("Antallet af reservationer for denne Børnegruppe er allerede 2 eller mere.");
                return false;
            }

            if (!ReservationLedig(reservation))
            {
                Console.WriteLine("Tidspunktet for reservationen er optaget.");
                return false;
            }

            if (!ReservationsTidspunktOK(reservation))
            {
                Console.WriteLine("Tidspunktet for reservationen er ikke gyldigt.");
                return false;
            }

            return true;
        }
    }


}
