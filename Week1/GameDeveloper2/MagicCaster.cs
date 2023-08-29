public class MagicCaster:Enemy
{
    public MagicCaster():base("Ranged Fighter", 5000)
    {
        AttackList.Add(new Attack("Fireball", 25));
        AttackList.Add(new Attack("Lightning Strike", 20));
        AttackList.Add(new Attack("Staff Strike", 10));
    }
    public void Heal(Enemy Target)
    {
        Target.Health += 40;
        Console.WriteLine($"{Target.Name} is at {Target.Health} health.");
        
    }
}