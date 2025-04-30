using System;
using System.Collections.Generic;

public class GameManager
{
    private Student student;
    private GameEventManager eventManager;

    private readonly List<string> possibleActions = new()
    {
        "study", "sleep", "eat", "game", "walk"
    };

    public void Start()
    {
        student = new Student();
        eventManager = new GameEventManager(student);

        for (int day = 1; day <= 5; day++)
        {
            Console.WriteLine($"\n===== День {day} =====");

            foreach (string period in new[] { "Ранок", "День", "Вечір" })
            {
                Console.WriteLine($"\n-- {period} --");
                ShowActions();
                string chosen = GetPlayerChoice();
                student.PerformAction(chosen);
                eventManager.TryTriggerRandomEvent();
            }

            Console.WriteLine("\nКінець дня.\n");
        }

        EndGame();
    }

    private void ShowActions()
    {
        Console.WriteLine("Обери дію:");
        for (int i = 0; i < possibleActions.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {TranslateAction(possibleActions[i])}");
        }
    }

    private string GetPlayerChoice()
    {
        while (true)
        {
            Console.Write("Вибір: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int index) && index >= 1 && index <= possibleActions.Count)
                return possibleActions[index - 1];

            Console.WriteLine("Неправильний вибір. Спробуй ще раз.");
        }
    }

    private string TranslateAction(string act)
    {
        return act switch
        {
            "study" => "Відвідувати заняття",
            "sleep" => "Поспати",
            "eat" => "Поїсти",
            "game" => "Пограти в ігри",
            "walk" => "Прогулянка",
            _ => act
        };
    }

    private void EndGame()
    {
        int score = student.Knowledge + student.Health + student.Mood + student.Energy + student.Money;

        Console.WriteLine("\n=== Підсумок гри ===");
        Console.WriteLine($"Загальний рахунок: {score}");

        if (score >= 400)
            Console.WriteLine("Ти – легендарний студент!");
        else if (score >= 300)
            Console.WriteLine("Ти – зразковий студент.");
        else if (score >= 200)
            Console.WriteLine("Міг би краще.");
        else
            Console.WriteLine("На жаль, тебе відрахували...");
    }
}
