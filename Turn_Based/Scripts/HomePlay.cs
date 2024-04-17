public class HomePlay 
    {
    private List<Monster> yourMonsters = new List<Monster>();
    public void Play_Adventure ()
    {
        ArtList artList = new ArtList();
    
        SelectionWithValidation selector1 = new SelectionWithValidation();
        Console.Clear();
        selector1.AddSelectionAction(FindMatch, "Find Match");
        selector1.AddSelectionAction(FindMatch, "Check your monster");
        selector1.ShowSelection();
    }
    public void FindMatch ()
    {
        SelectionWithValidation skillSelection = new SelectionWithValidation();
        SelectionWithValidation enemySkillSelection = new SelectionWithValidation();
        Random randomizer = new Random();
        Random randomizer2 = new Random();
        Monster enemy = new Monster("Enemy", ArtList.twinDog);
        Monster yourMonster = new Monster("Enemy", ArtList.pegasus);
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
            skillSelection.AddSelectionAction(yourMonster.DealDamage, "Deal Damage");
            //skillSelection.AddSelectionAction(yourMonster.AddShield, "Restore Shield");
            enemySkillSelection.AddSelectionAction(enemy.DealDamage, "Deal Damage");
            //enemySkillSelection.AddSelectionAction(enemy.AddShield, "Restore Shield");
            if(yourMonster.Health < 100) skillSelection.AddSelectionAction(yourMonster.Heal, "Restore Health"); 
            if(yourMonster.Mana >= 100) skillSelection.AddSelectionAction(yourMonster.UltimateSkill, "Ultimate Skill");
            if(enemy.Mana >= 100) enemySkillSelection.AddSelectionAction(enemy.UltimateSkill, "Ultimate Skill");
            if(enemy.Health < 100) enemySkillSelection.AddSelectionAction(enemy.Heal, "Restore Health");
            frameUI.RenderGame(-1);
            skillSelection.ShowSelection();
            frameUI.RenderGame(1);
            Thread.Sleep(300);
            frameUI.RenderGame(-1);
            Thread.Sleep(500);
            frameUI.RenderGame(0);
            Thread.Sleep(200);
            enemySkillSelection.InvokeSelection();
            frameUI.RenderGame(-1);
            Thread.Sleep(200);
        }
    }
    
}