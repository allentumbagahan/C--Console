public class Shop {
    private List<Monster> monstersSells;
    private List<Monster> yourMonsters;
    public Shop(List<Monster> yourMonsters) {
        this.yourMonsters = yourMonsters;
        monstersSells = new List<Monster>();
        GenerateMonsterToSell();
    }
    void ItemsShop ()
    {

    }
    
    void ShowMonsters()
    {
        Console.Clear();
        SelectionWithValidation shopSelection = new SelectionWithValidation(true, "Back");
        foreach (var item in monstersSells)
        {
            string renderingItemtemp = "\n" + (item.RenderingArt).Replace("1", "\t");
            shopSelection.AddSelectionAction(null, renderingItemtemp);
        }
        shopSelection.ShowSelection();
    }
    public void GoToShop()
    {
        Console.Clear();
        SelectionWithValidation shopSelection = new SelectionWithValidation(true, "Back");
        shopSelection.AddSelectionAction(ShowMonsters, "Buy Monster");
        shopSelection.AddSelectionAction(ItemsShop, "Buy Items");
        shopSelection.AddSelectionAction(ItemsShop, "Upgrade Monster");
        shopSelection.ShowSelection();
    }
    public void GenerateMonsterToSell()
    {
        try {
            for (int i = 0; i < 3; i++)
            {
                Monster monster = new Monster("Enemy", ArtList.GetArt());
                monster.GenerateStats(1);
                monstersSells.Add(monster);      
            }
        }
        catch (Exception ex) {
            Console.WriteLine("Generate Selling Monster Error : " + ex + ArtList.GetArt());
        }
    }
}