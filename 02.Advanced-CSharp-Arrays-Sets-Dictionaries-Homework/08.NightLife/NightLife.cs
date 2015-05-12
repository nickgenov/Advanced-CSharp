using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class NightLife
{
    static void Main()
    {
        Dictionary<string, SortedDictionary<string, SortedSet<string>>> nightLifeData = new Dictionary<string, SortedDictionary<string, SortedSet<string>>>();
        string input = Console.ReadLine();

        while (input != "END")
        {
            string[] data = input.Split(';');
            string city = data[0];
            string venue = data[1];
            string performer = data[2];

            if (nightLifeData.ContainsKey(city) == false)
            {
                SortedDictionary<string, SortedSet<string>> venueData = new SortedDictionary<string, SortedSet<string>>();
                SortedSet<string> performers = new SortedSet<string>();
                performers.Add(performer);
                venueData[venue] = performers;

                nightLifeData[city] = venueData;
            }
            else
            {
                SortedDictionary<string, SortedSet<string>> venueData = nightLifeData[city];
                if (venueData.ContainsKey(venue))
                {
                    venueData[venue].Add(performer);
                }
                else
                {
                    SortedSet<string> performers = new SortedSet<string>();
                    performers.Add(performer);
                    venueData[venue] = performers;
                }
            }
            input = Console.ReadLine();
        }

        foreach (KeyValuePair<string, SortedDictionary<string, SortedSet<string>>> entry in nightLifeData)
        {
            string city = entry.Key;
            Console.WriteLine(city);

            SortedDictionary<string, SortedSet<string>> venueData = entry.Value;
            Console.Write("->");

            foreach (KeyValuePair<string, SortedSet<string>> entryVenue in venueData)
            {
                string venue = entryVenue.Key;
                SortedSet<string> performers = entryVenue.Value;

                Console.Write("{0}: ", venue);
                Console.WriteLine(string.Join(", ", performers));             
            }
        }
    }
}