using Menu = Lang.Constants.Menu;
using Calc = Lang.Constants.Calc;
using Season = Lang.Constants.Season;
using ExMessage = Lang.Constants.ExMessage;
using Host;
using System;

do
{
    Console.Write(Menu.ENOM);

    if (!int.TryParse(Console.ReadLine(), out var month)
        || !(month >= 1 && month <= 12))
    {
        Console.Write(Menu.WI);
        continue;
    }

    DayCount(month);
    SeasonCalculation(month);

    Console.WriteLine(Menu.Exit);
}
while (Console.ReadKey().Key != ConsoleKey.Escape);

void DayCount(int month)
{
    string daysCount;
    switch (month)
    {
        case 2:
            daysCount = Calc.Feb;
            break;
        case 4:
        case 6:
        case 9:
        case 11:
            daysCount = Calc.Apr;
            break;
        case 1:
        case 3:
        case 5:
        case 7:
        case 8:
        case 10:
        case 12:
            daysCount = Calc.Jan;
            break;
        default:
            throw new ArgumentException(ExMessage.BE);
    }

    var monthEnum = (MoNa)month;
    Console.WriteLine(string.Format(Calc.DOM, monthEnum, daysCount));
}
void SeasonCalculation(int month)
{
    string season;
    if (month == 12 || month == 1 || month == 2)
    {
        season = Season.W;
    }
    else if (month >= 3 && month <= 5)
    {
        season = Season.S;
    }
    else if (month >= 6 && month <= 8)
    {
        season = Season.Sum;
    }
    else if (month >= 9 && month <= 11)
    {
        season = Season.F;
    }
    else
    {
        throw new ArgumentException(ExMessage.BE);
    }

    var monthEnum = (MoNa)month;
    Console.WriteLine(string.Format(Calc.SOM, monthEnum, season));
}