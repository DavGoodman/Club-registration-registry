using static System.Net.Mime.MediaTypeNames;

namespace StartList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Club> clubs = new List<Club>();
            List<string> clubNames = new List<string>();
            List<Registration> registrations = new List<Registration>();

            foreach (var line in File.ReadLines("startlist.csv"))
            {
                var parts = line.Split(',');

                // removing the " "
                for (int i = 0; i < parts.Length; i++)
                {
                    parts[i] = parts[i].Replace("\"", "");
                }
                
                string startNum = parts[0];
                string name = parts[1];
                string club = parts[2];
                string nationality = parts[3];
                string group = parts[4];
                string _class = parts[5];



                //Console.WriteLine($"startNum: {startNum}\nName: {name}\n" +
                //                  $"Club: {club}\nNationality: {nationality}\n" +
                //                  $"Group: {group}\nClass: {_class}\n");

                var newRegistration = (new Registration
                {
                    startNum = startNum != "" ? Convert.ToInt32(startNum) : null,
                    name = name,
                    club = club,
                    nationaility = nationality,
                    group = group,
                    _class = _class
                });
                registrations.Add(newRegistration);


                if(club == "") {}
                else if (!clubNames.Contains(club))
                {
                    Club newClub = new Club(club);
                    newClub.Registrations.Add(newRegistration);
                    clubs.Add(newClub);
                    clubNames.Add(club);
                }
                else
                {
                    foreach (var _club in clubs)
                    {
                        if (_club.ClubName == club) _club.Registrations.Add(newRegistration);
                    }
                }
            }

            WriteTxtFiles(clubs);

        }



        public static void WriteTxtFiles(List<Club> clubs)
        {
            string text = "";
            foreach (var club in clubs)
            {
                text = $"{club.ClubName} has {club.Registrations.Count} registered members:\n\n";

                foreach (var r in club.Registrations)
                {
                    text += $"startNum: {r.startNum}\nName: {r.name}\n" +
                            $"Nationality: {r.nationaility}\n" +
                            $"Group: {r.group}\nClass: {r._class}\n\n";
                }

                Console.WriteLine(text);

                string clubName = club.ClubName.Replace(" ", "_");
                clubName = clubName.Replace("/", "-");
                string path = $"C:\\Users\\david\\C#\\basics\\StartList\\StartList\\texts\\{clubName}.txt";
                //Check if the file exists
                if (!File.Exists(path))
                {
                    using (StreamWriter writer = File.CreateText(path))
                    {
                        writer.WriteLine(text);
                    }
                }
            }

           

             
                

        }

    }
}