// Create instance of enemy
Enemy Grunt = new Enemy("Grunt");

// Three attacks
Attack FlyingSwordFish = new Attack("Flying Sword Fish", 20);
Attack ShushStick = new Attack("ShushStick", 8);
Attack ElectricBeyblade = new Attack("Electric Beyblade", 13);

Grunt.AttackList.Add(FlyingSwordFish);
Grunt.AttackList.Add(ShushStick);
Grunt.AttackList.Add(ElectricBeyblade);

Console.WriteLine(Grunt.RandomAttack().Name);