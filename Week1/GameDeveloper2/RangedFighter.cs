public class RangedFighter : Enemy
{
    public int Distance = 5;

    public RangedFighter():base("Ranged Fighter", 5000)
    {
        AttackList.Add(new Attack("Shoot an Arrow", 20));
        AttackList.Add(new Attack("Throw a Knife", 15));
    }
    public override void PerformAttack(Enemy Target, Attack ChosenAttack)
    {
        if (Distance < 10){
            Console.WriteLine("Enemy is too close");
        }
        else{
            base.PerformAttack(Target, ChosenAttack);
        }
    }
    public void Dash()
    {
        Distance = 20;
    }
}