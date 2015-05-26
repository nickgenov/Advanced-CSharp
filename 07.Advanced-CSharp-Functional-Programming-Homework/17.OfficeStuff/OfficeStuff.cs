using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class OfficeStuff
{
    static void Main()
    {
        SortedDictionary<string, Dictionary<string, int>> data = new SortedDictionary<string, Dictionary<string, int>>();

        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();
            data = StoreOfficeData(input, data);
        }

        PrintOfficeData(data);
    }
    public static SortedDictionary<string, Dictionary<string, int>> StoreOfficeData(string input, SortedDictionary<string, Dictionary<string, int>> data)
    {
        string[] line = input.Split(new char[] { '|', '-', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        string company = line[0];
        string product = line[2];
        int amount = int.Parse(line[1]);

        if (data.ContainsKey(company))
        {
            Dictionary<string, int> products = data[company];
            if (products.ContainsKey(product))
            {
                products[product] += amount;
            }
            else
            {
                products[product] = amount;
            }
            data[company] = products;
        }
        else
        {
            Dictionary<string, int> products = new Dictionary<string, int>();
            products[product] = amount;
            data[company] = products;
        }

        return data;
    }
    public static void PrintOfficeData(SortedDictionary<string, Dictionary<string, int>> data)
    {
        foreach (var entry in data)
        {
            var key = entry.Key;
            var items = entry.Value;

            List<string> itemData = new List<string>();
            foreach (var item in items)
            {
                itemData.Add(string.Format("{0}-{1}", item.Key, item.Value));
            }
            string result = key.ToString() + ": " + string.Join(", ", itemData);
            Console.WriteLine(result);
        }
    }
}