using System;

enum DoorState
{
    Suljettu,
    Auki,
    Lukittu
}

class Door
{
    private DoorState state;

    public Door()
    {
        state = DoorState.Suljettu;
    }

    public void OpenLock()
    {
        if (state == DoorState.Lukittu)
        {
            Console.WriteLine("Lukko avattu.");
            state = DoorState.Suljettu;
        }
        else
        {
            Console.WriteLine("Ovi on jo auki tai ei lukittu.");
        }
    }

    public void OpenDoor()
    {
        if (state == DoorState.Suljettu)
        {
            Console.WriteLine("Ovi avattu.");
            state = DoorState.Auki;
        }
        else if (state == DoorState.Auki)
        {
            Console.WriteLine("Ovi on jo auki.");
        }
        else
        {
            Console.WriteLine("Ovi on lukittu. Avaa lukko ensin.");
        }
    }

    public void CloseDoor()
    {
        if (state == DoorState.Auki)
        {
            Console.WriteLine("Ovi suljettu.");
            state = DoorState.Suljettu;
        }
        else
        {
            Console.WriteLine("Ovi on jo kiinni.");
        }
    }

    public void LockDoor()
    {
        if (state == DoorState.Suljettu)
        {
            Console.WriteLine("Ovi lukittu.");
            state = DoorState.Lukittu;
        }
        else if (state == DoorState.Lukittu)
        {
            Console.WriteLine("Ovi on jo lukittu.");
        }
        else
        {
            Console.WriteLine("Ovi on auki. Sulje ovi ensin.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Door door = new Door();
        while (true)
        {
            Console.Write("Syötä komento (Avaa lukko, Avaa, Sulje, Lukitse tai Lopeta): ");
            string command = Console.ReadLine().Trim();
            switch (command)
            {
                case "Avaa lukko":
                    door.OpenLock();
                    break;
                case "Avaa":
                    door.OpenDoor();
                    break;
                case "Sulje":
                    door.CloseDoor();
                    break;
                case "Lukitse":
                    door.LockDoor();
                    break;
                case "Lopeta":
                    Console.WriteLine("Ohjelma suljetaan.");
                    return;
                default:
                    Console.WriteLine("En ymmärtänyt. Sallitut komennot ovat yllä. Osaatko lukea?");
                    break;
            }
        }
    }
}
