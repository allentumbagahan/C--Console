using System; 
public class HomePlay 
    {
    private List<Monster> yourMonsters = new List<Monster>();
    public void Play_Adventure ()
    {
        while (true)
        {
            try
            {
                Console.Clear();
                SelectionWithValidation selector1 = new SelectionWithValidation();
                selector1.AddSelectionAction(FindMatch, "Find Match");
                //selector1.AddSelectionAction(shop.GoToShop, "Visit Shop");
                selector1.ShowSelection();
            }
            catch(Exception err)
            {
                Console.WriteLine("Play Adv. error : " + err.Message);
            }
        }
    }
    void InMatch(Monster monster1, Monster monster2, SelectionWithValidation skill1, SelectionWithValidation skill2){
        FrameUI frameUI = new FrameUI(60);
        frameUI.AddMonsters(monster1, monster2);
        while(monster1.Health > 0 && monster2.Health > 0)
        {
            skill2.ClearSelection();
            skill1.ClearSelection();
            skill2.AddSelectionAction(monster2.DealDamage, $"Basic Attack (Deal {monster2.Attack} Damage)");
            //skill2.AddSelectionAction(monster2.AddShield, "Restore Shield");
            skill1.AddSelectionAction(monster1.DealDamage, "Deal Damage");
            //skill1.AddSelectionAction(monster1.AddShield, "Restore Shield");
            if(monster2.Health < monster2.MaxHealth && monster2.Rage > (monster2.HpRegen * 1.0f)/(monster2.MaxHealth* 1.0f)*45) skill2.AddSelectionAction(monster2.Heal, $"Regen (Heal {monster2.HpRegen} Health)"); 
            if(monster2.Rage >= 100) skill2.AddSelectionAction(monster2.UltimateSkill, "Ultimate Skill");
            if(monster1.Rage >= 100) skill1.AddSelectionAction(monster1.UltimateSkill, "Ultimate Skill");
            if(monster1.Health < monster1.MaxHealth && monster1.Rage > (monster1.HpRegen * 1.0f)/(monster1.MaxHealth* 1.0f)*45) skill1.AddSelectionAction(monster1.Heal, "Restore Health");
            if(monster1.Health < monster1.MaxHealth*0.6 && monster1.Rage > (monster1.HpRegen * 1.0f)/(monster1.MaxHealth* 1.0f)*45) skill1.AddSelectionAction(monster1.Heal, "Restore Health");
            frameUI.RenderGame(-1);
            if(!monster2.isSkip()){
                Console.WriteLine("\nChoose Your Action : ");
                skill2.ShowSelection();
                frameUI.RenderGame(1);
                Thread.Sleep(300);
                frameUI.RenderGame(-1);
            }
            if(monster1.Health <= 0) break;
            Thread.Sleep(500);
            if(!monster1.isSkip()) 
            {
                frameUI.RenderGame(0);
                Thread.Sleep(200);
                skill1.InvokeSelection();
                frameUI.RenderGame(-1);
                Thread.Sleep(200);
            }
        }
        return;
    }
    void ShowChestReward(Monster monster1, Monster monster2){
        if(monster1.Health <= 0){
                FrameUI frameUI = new FrameUI(60);
                Random random = new Random();
                int expGain = random.Next(6, 9);
                Console.Clear();
                Console.WriteLine( "\n\n\n" + ArtList.GetArt("Chest_Close").Replace("1", frameUI.AddTabs(((Console.WindowWidth - 38)/2)/8)));
                Thread.Sleep(1000);
                Console.Clear();
                Console.WriteLine(ArtList.GetArt("Chest_Open").Replace("1", frameUI.AddTabs(((Console.WindowWidth - 38)/2)/8) + " "));
                Console.WriteLine();
                Console.WriteLine($"Reward : \n Exp+{expGain}\n");
                Thread.Sleep(2000);
                monster2.AddExp(expGain);
                monster2.Health = monster2.MaxHealth; // recover hp
                monster2.Rage = 0; // recover hp
            }
        return;
    }
    public void FindMatch ()
    {
        try{
            SelectionWithValidation skillSelection = new SelectionWithValidation();
            SelectionWithValidation enemySkillSelection = new SelectionWithValidation();
            Random randomizer = new Random();
            Random randomizer2 = new Random();
            Monster yourMonster = new Monster("Your monster", ArtList.pegasus);
            yourMonster.GenerateStats(1);
            while(yourMonster.Health > 0)
            {
                Monster enemy = new Monster("Enemy", ArtList.twinDog);
                enemy.GenerateStats(yourMonster.Level);
                enemy.SetEnemy(yourMonster);
                yourMonster.SetEnemy(enemy);
                InMatch(enemy, yourMonster, enemySkillSelection, skillSelection);
                ShowChestReward(enemy, yourMonster);
            }

        }
        catch(Exception err)
        {
            Console.WriteLine("Error finding match" + err);
        }
    }
    
}