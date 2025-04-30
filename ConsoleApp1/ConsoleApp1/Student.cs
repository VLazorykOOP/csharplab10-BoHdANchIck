using System;

public class Student
{
    public int Knowledge { get; private set; }
    public int Energy { get; private set; }
    public int Mood { get; private set; }
    public int Health { get; private set; }
    public int Money { get; private set; }

    public event Action<string> OnActionPerformed;
    public event Action<string> OnStatusChanged;
    public event Action<string> OnCriticalCondition;

    public Student()
    {
        Knowledge = 50;
        Energy = 100;
        Mood = 70;
        Health = 100;
        Money = 100;
    }

    public void PerformAction(string action)
    {
        switch (action.ToLower())
        {
            case "study":
                Knowledge += 10;
                Energy -= 20;
                Mood -= 5;
                Trigger("Відвідав заняття");
                break;
            case "sleep":
                Energy += 30;
                Mood += 5;
                Trigger("Поспав");
                break;
            case "eat":
                Energy += 10;
                Health += 5;
                Money -= 15;
                Trigger("Поїв");
                break;
            case "game":
                Mood += 15;
                Energy -= 10;
                Trigger("Грав у комп'ютерні ігри");
                break;
            case "walk":
                Mood += 10;
                Health += 3;
                Energy -= 5;
                Trigger("Прогулявся на свіжому повітрі");
                break;
            default:
                Trigger("Нічого не робив");
                break;
        }

        ClampValues();
        ReportStatus();
        CheckCriticalConditions();
    }

    private void Trigger(string msg)
    {
        OnActionPerformed?.Invoke(msg);
    }

    private void ReportStatus()
    {
        OnStatusChanged?.Invoke($"Знання: {Knowledge}, Енергія: {Energy}, Настрій: {Mood}, Здоров’я: {Health}, Гроші: {Money}");
    }

    private void CheckCriticalConditions()
    {
        if (Energy <= 10)
            OnCriticalCondition?.Invoke("Енергія майже на нулі!");

        if (Health <= 15)
            OnCriticalCondition?.Invoke("Здоров’я критичне!");

        if (Money < 0)
            OnCriticalCondition?.Invoke("Гроші закінчились!");
    }

    private void ClampValues()
    {
        Knowledge = Math.Clamp(Knowledge, 0, 150);
        Energy = Math.Clamp(Energy, 0, 120);
        Mood = Math.Clamp(Mood, 0, 120);
        Health = Math.Clamp(Health, 0, 120);
        Money = Math.Clamp(Money, -100, 999);
    }
}
