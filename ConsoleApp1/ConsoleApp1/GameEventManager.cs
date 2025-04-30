using System;

public class GameEventManager
{
    private readonly Random rnd = new Random();
    private readonly Student student;

    public GameEventManager(Student s)
    {
        student = s;
        student.OnActionPerformed += LogAction;
        student.OnStatusChanged += LogStatus;
        student.OnCriticalCondition += HandleCritical;
    }

    public void TryTriggerRandomEvent()
    {
        int roll = rnd.Next(100);

        if (roll < 15)
        {
            student.PerformAction("eat"); 
            Console.WriteLine("[Подія] Мама принесла домашню їжу!");
        }
        else if (roll < 30)
        {
            student.PerformAction("sleep");
            Console.WriteLine("[Подія] Пари скасували — можеш поспати.");
        }
        else if (roll < 45)
        {
            student.PerformAction("game");
            Console.WriteLine("[Подія] Потрапив у гру з другом на ніч.");
        }
        else if (roll < 55)
        {
            Console.WriteLine("[Подія] Контрольна — якщо знання < 60, зменшення здоров’я.");
            if (student.Knowledge < 60)
            {
                Console.WriteLine("Не здав. Стрес ударив по здоров'ю.");
                student.PerformAction("walk");
            }
            else
            {
                Console.WriteLine("Склав! Знання +5.");
                student.PerformAction("study");
            }
        }
    }

    private void LogAction(string msg)
    {
        Console.WriteLine($"[Дія] {msg}");
    }

    private void LogStatus(string msg)
    {
        Console.WriteLine($"[Статус] {msg}");
    }

    private void HandleCritical(string warning)
    {
        Console.WriteLine($"[Увага] {warning}");
    }
}
