using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class PINValidation
{
    static void Main()
    {
        string name = Console.ReadLine();
        string gender = Console.ReadLine();
        string PIN = Console.ReadLine();

        bool validName = CheckFullName(name);
        bool validPIN = CheckPINValidity(PIN, gender);

        if (validName && validPIN)
        {
            Console.Write("{\"name\":\"");
            Console.Write(name);
            Console.Write("\",\"gender\":\"");
            Console.Write(gender);
            Console.Write("\",\"pin\":\"");
            Console.Write(PIN);
            Console.WriteLine("\"}");
        }
        else
        {
            Console.WriteLine("<h2>Incorrect data</h2>");
        }

    }
    public static bool CheckPINValidity(string PIN, string gender)
    {
        long num;
        bool validPIN = true;
        if (long.TryParse(PIN, out num) == false)
        {
            validPIN = false;
        }
        else if (PIN.Length != 10)
        {
            validPIN = false;
        }
        else if (ChecksumPIN(PIN) != int.Parse(PIN[9].ToString()))
        {
            validPIN = false;
        }
        else if (gender == "male" && int.Parse(PIN[8].ToString()) % 2 != 0 ||
            gender == "female" && int.Parse(PIN[8].ToString()) % 2 != 1)
        {
            validPIN = false;
        }
        else
        {
            int year = int.Parse(PIN.Substring(0, 2));
            int month = int.Parse(PIN.Substring(2, 2));
            int day = int.Parse(PIN.Substring(4, 2));
            if ((month > 0 && month <= 12 || month > 20 && month <= 32 || 
                month > 40 && month <= 52) == false)
            {
                validPIN = false;
            }
            if ((day > 0 && day <= 31) == false )
            {
                validPIN = false; 
            }
        }
        return validPIN;
    }
    public static int ChecksumPIN(string PIN)
    {
        int sum = 0;
        sum += int.Parse(PIN[0].ToString()) * 2;
        sum += int.Parse(PIN[1].ToString()) * 4;
        sum += int.Parse(PIN[2].ToString()) * 8;
        sum += int.Parse(PIN[3].ToString()) * 5;
        sum += int.Parse(PIN[4].ToString()) * 10;
        sum += int.Parse(PIN[5].ToString()) * 9;
        sum += int.Parse(PIN[6].ToString()) * 7;
        sum += int.Parse(PIN[7].ToString()) * 3;
        sum += int.Parse(PIN[8].ToString()) * 6;

        int checkSum = sum % 11;
        if (checkSum == 10)
        {
            checkSum = 0;
        }
        return checkSum;
    }
    public static bool CheckFullName(string inputString)
    {
        string[] name = inputString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
        bool validName = false;
        if (name.Length != 2)
        {
            validName = false;
        }
        else
        {
            string firstName = name[0];
            string lastName = name[1];
            if (CheckName(firstName) && CheckName(lastName))
            {
                validName = true;
            }
        }
        return validName;
    }
    public static bool CheckName(string name)
    {
        bool validName = true;
        if (char.IsUpper(name[0]) == true)
        {
            foreach (var character in name)
            {
                if (char.IsLetter(character) == false)
                {
                    validName = false;
                    break;
                }
            }
        }
        else
        {
            validName = false;
        }
        return validName;
    }
}