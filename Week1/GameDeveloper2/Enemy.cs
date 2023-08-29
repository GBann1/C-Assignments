using Internal;

public class Enemy
{
    public string Name;
    public int Health;
    public List<Attack> AttackList;
    public Enemy(string name)
    {
        Name = name;
        Health = 100;
        AttackList = new List<Attack>();
    }

    public Attack RandomAttack()
    {
        Random rand = new Random();
        return AttackList[rand.Next(AttackList.Count)];
    }
    public void PreformAttack(Enemy Target, Attack ChosenAttack)
    {
        Target.Health -= ChosenAttack.DamageAmount;
        Console.WriteLine($"{Name} attacks {Target.Name}, dealing {ChosenAttack.DamageAmount} damage and reducing {Target.Name}'s health to {Target.Health}!!");
    }
}