using System;
using System.IO.Pipes;
using System.Net.Http;
using System.Threading.Tasks;

class program 
{
    static readonly HttpClient client = new HttpClient();
    string[] nationList = { "USA", "Japan", "Mexico", "United Kingdom" };
    string currency = "";
    char currencySign = ' ';
    private static void Main() 
    {
        program Program = new program();
        Console.WriteLine("Hello, what is your home nation?");
        foreach (string nation in Program.nationList) 
        {
            Console.WriteLine(nation);
        }
        string originNation = Console.ReadLine();
        Tuple<string, char> originTuple = Program.currencyType(originNation);
        Console.WriteLine("What nation are you trying to go to?");
        foreach (string nation in Program.nationList)
        {
            Console.WriteLine(nation);
        }
        string destinationNation = Console.ReadLine();
        Tuple<string, char> destinationTuple = Program.currencyType(destinationNation);
        Console.WriteLine("How much money are you trying to convert?");
        string input = Console.ReadLine();
        double input1 = Convert.ToInt32(input);
        Console.WriteLine(Program.currencySign + "" + Program.Conversion(originNation, destinationNation, input1));

    }
    public Tuple<string, char> currencyType(string nation) 
    {
        switch (nation) 
        {
            case "USA":
                currency = "Dollar";
                currencySign = '$';
                break;
            case "Japan":
                currency = "Yen";
                currencySign = '¥';
                break;
            case "Mexico":
                currency = "Peso";
                currencySign = '₱';
                break;
            case "United Kingdom":
                currency = "Pounds";
                currencySign = '£';
                break;
            default:
                currency = "Invalid Origin or Destination nation";
                break;
        }
        return Tuple.Create(currency, currencySign);
    }
    public double Conversion(string originNation, string destinationNation, double exchange) 
    {
        double result = 0;
        switch (originNation, destinationNation) 
        {
            case ("USA", "USA"):
                result = exchange;
                break;
            case ("USA", "Japan"):
                result = exchange * 134.31;
                    break;
            case ("USA", "Mexico"):
                result = exchange * 18.05;
                break;
            case ("USA", "United Kingdom"):
                result = exchange * 0.81;
                break;
            case ("Mexico", "Mexico"):
                result = exchange;
                break;
            case ("Mexico", "USA"):
                result = exchange / 18.05;
                break;
            case ("Mexico", "United Kingdom"):
                result = exchange * 0.045;
                break;
            case ("Mexico", "Japan"):
                result = exchange * 7.44;
                break;
            case ("United Kingdom", "United Kingdom"):
                result = exchange;
                break;
            case ("United Kingdom", "USA"):
                result = exchange / 0.81;
                break;
            case ("Japan", "Japan"):
                result = exchange;
                break;
            case ("Japan", "USA"):
                result = exchange / 134.31;
                break;
            case ("Japan", "Mexico"):
                result = exchange * 0.13;
                break;
            case ("Japan", "United Kingdom"):
                result = exchange * 0.0060;
                break;
        }
        return result;
    }
}