// Create instance of enemy
MeleeFighter Carl = new MeleeFighter();
RangedFighter Dave = new RangedFighter();
MagicCaster Kevin = new MagicCaster();

Carl.PerformAttack(Dave,Carl.AttackList[1]);
Carl.Rage(Kevin);
Dave.PerformAttack(Carl, Dave.AttackList[0]);
Dave.Dash();
Dave.PerformAttack(Carl, Dave.AttackList[0]);
Kevin.PerformAttack(Carl,Kevin.AttackList[0]);
Kevin.Heal(Dave);
Kevin.Heal(Kevin);
