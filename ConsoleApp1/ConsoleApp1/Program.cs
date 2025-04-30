using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        GameManager game = new GameManager();
        game.Start();
    }
}
