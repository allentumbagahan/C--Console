using System; 
public class HomePlay 
    {
    private List<Monster> yourMonsters = new List<Monster>();
    public void Play_2Player()
    {
        
    }
    public void Play_Adventure ()
    {
        Shop shop = new Shop(yourMonsters);
        while (true)
        {
            try
            {
                SelectionWithValidation selector1 = new SelectionWithValidation();
                Console.Clear();
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
    public void FindMatch ()
    {
        try{
            SelectionWithValidation skillSelection = new SelectionWithValidation();
            SelectionWithValidation enemySkillSelection = new SelectionWithValidation();
            Random randomizer = new Random();
            Random randomizer2 = new Random();
            Monster enemy = new Monster("Enemy", ArtList.twinDog);
            Monster yourMonster = new Monster("Your monster", ArtList.pegasus);
            enemy.GenerateStats(1);
            yourMonster.GenerateStats(1);
            enemy.SetEnemy(yourMonster);
            yourMonster.SetEnemy(enemy);
            FrameUI frameUI = new FrameUI(60);
            frameUI.AddMonsters(enemy, yourMonster);
            while(enemy.Health > 0 && yourMonster.Health > 0)
            {
                skillSelection.ClearSelection();
                enemySkillSelection.ClearSelection();
                skillSelection.AddSelectionAction(yourMonster.DealDamage, $"Basic Attack (Deal {yourMonster.Attack} Damage)");
                //skillSelection.AddSelectionAction(yourMonster.AddShield, "Restore Shield");
                enemySkillSelection.AddSelectionAction(enemy.DealDamage, "Deal Damage");
                //enemySkillSelection.AddSelectionAction(enemy.AddShield, "Restore Shield");
                if(yourMonster.Health < yourMonster.MaxHealth && yourMonster.Rage > 10) skillSelection.AddSelectionAction(yourMonster.Heal, $"Regen (Heal {yourMonster.HpRegen} Health)"); 
                if(yourMonster.Rage >= 100) skillSelection.AddSelectionAction(yourMonster.UltimateSkill, "Ultimate Skill");
                if(enemy.Rage >= 100) enemySkillSelection.AddSelectionAction(enemy.UltimateSkill, "Ultimate Skill");
                if(enemy.Health < enemy.MaxHealth && enemy.Rage > 10) enemySkillSelection.AddSelectionAction(enemy.Heal, "Restore Health");
                if(enemy.Health < enemy.MaxHealth*0.6 && enemy.Rage > 10) enemySkillSelection.AddSelectionAction(enemy.Heal, "Restore Health");
                frameUI.RenderGame(-1);
                if(!yourMonster.isSkip()){
                    Console.WriteLine("\nChoose Your Action : ");
                    skillSelection.ShowSelection();
                    frameUI.RenderGame(1);
                    Thread.Sleep(300);
                    frameUI.RenderGame(-1);
                }
                if(enemy.Health <= 0) break;
                Thread.Sleep(500);
                if(!enemy.isSkip()) 
                {
                    frameUI.RenderGame(0);
                    Thread.Sleep(200);
                    enemySkillSelection.InvokeSelection();
                    frameUI.RenderGame(-1);
                    Thread.Sleep(200);
                }
            }
            if(enemy.Health <= 0){
                Console.Clear();
                Console.WriteLine(ArtList.GetArt("Chest_Close"));
                Thread.Sleep(1000);
                Console.Clear();
                Console.WriteLine(ArtList.GetArt("Chest_Open"));
                Thread.Sleep(2000);
            }

        }
        catch(Exception err)
        {
            Console.WriteLine("Error finding match" + err);
        }
    }
    
}