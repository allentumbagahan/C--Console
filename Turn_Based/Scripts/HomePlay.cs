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
        Monster enemy = new Monster("Enemy", 100, randomizer.Next(2, 10), randomizer.Next(2, 10),  randomizer.Next(1, 10), ArtList.twinDog);
        Monster yourMonster = new Monster("Enemy", 100, randomizer2.Next(2, 10), randomizer2.Next(2, 10), randomizer.Next(1, 10), ArtList.elepant);
        enemy.SetEnemy(yourMonster);
        yourMonster.SetEnemy(enemy);
        FrameUI frameUI = new FrameUI(60);
        frameUI.AddMonsters(enemy, yourMonster);
        skillSelection.AddSelectionAction(yourMonster.DealDamage, "Deal Damage");
        skillSelection.AddSelectionAction(yourMonster.Heal, "Restore Health");
        skillSelection.AddSelectionAction(yourMonster.AddShield, "Restore Shield");
        skillSelection.AddSelectionAction(yourMonster.UltimateSkill, "Ultimate Skill");
        enemySkillSelection.AddSelectionAction(enemy.DealDamage, "Deal Damage");
        enemySkillSelection.AddSelectionAction(enemy.Heal, "Restore Health");

        while(enemy.Health > 0 && yourMonster.Health > 0)
        {
            frameUI.RenderGame(-1);
            skillSelection.ShowSelection();
            frameUI.RenderGame(1);
            Thread.Sleep(300);
            frameUI.RenderGame(-1);
            Thread.Sleep(500);
            frameUI.RenderGame(0);
            Thread.Sleep(200);
            enemySkillSelection.InvokeSelection(randomizer.Next(0, 1));
            frameUI.RenderGame(-1);
            Thread.Sleep(200);
        }
    }
    
}