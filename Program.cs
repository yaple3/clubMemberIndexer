namespace clubMemberIndexer
{
    internal class Program
    {
        public const int Size = 15;  // global variable
        private class ClubMembers
        {
            private readonly string[] Members = new string[Size];
            public string ClubType { get; set; }
            public string ClubLocation { get; set; }
            public string MeetingDate { get; set; }

            //constructor
            public ClubMembers()
            {
                for (int i = 0; i < Size; i++)
                {
                    Members[i] = string.Empty;
                }
                ClubType = string.Empty;
                ClubLocation = string.Empty;
                MeetingDate = string.Empty;
            }
            //indexer get and set methods
            public string this[int index]
            {
                get
                {
                    string tmp = index is >= 0 and <= (Size - 1) ? Members[index] : string.Empty;
                    return tmp;
                }
                set
                {
                    if (index is >= 0 and <= (Size - 1))
                    {
                        Members[index] = value;
                    }
                }

            }
        }

        private static void Main(string[] args)
        {
            ClubMembers DinnerClub = new();
            bool end = false;
            while (!end)
            {
                int sub = 0;
                while (sub is < 1 or > Size)
                {
                    Console.WriteLine($"Which club member do you want to enter (enter 1-{Size})?");
                    string input = Console.ReadLine();
                    if (input == "q")
                    {
                        end = true;
                        break;
                    }
                    while (!int.TryParse(input, out sub) || sub < 1 || sub > Size)
                    {
                        Console.WriteLine($"Enter a value between 1-{Size}");
                        input = Console.ReadLine();
                        if (input == "q")
                        {
                            end = true;
                            break;
                        }
                    }
                }
                if (end)
                {
                    break;
                }
                Console.WriteLine("Enter the name of the club member");
                DinnerClub[sub - 1] = Console.ReadLine();
                Console.WriteLine("Press enter to continue, q to stop adding members");
                string userInput = Console.ReadLine();
                if (userInput == "q")
                {
                    end = true;
                }
            }
            Console.WriteLine("What type of club is it?");
            DinnerClub.ClubType = Console.ReadLine();
            Console.WriteLine("Where does the club meet?");
            DinnerClub.ClubLocation = Console.ReadLine();
            Console.WriteLine("When does the club meet?");
            DinnerClub.MeetingDate = Console.ReadLine();

            Console.WriteLine($"Here is information on the club");
            Console.WriteLine($"ClubMembers Members");
            for (int i = 0; i < Size; i++)
            {
                if (DinnerClub[i] != string.Empty)
                {
                    Console.WriteLine(DinnerClub[i]);
                }
            }
            Console.WriteLine($"ClubType: {DinnerClub.ClubType}");
            Console.WriteLine($"ClubLocation: {DinnerClub.ClubLocation}");
            Console.WriteLine($"MeetingDate: {DinnerClub.MeetingDate}");
        }
    }
}