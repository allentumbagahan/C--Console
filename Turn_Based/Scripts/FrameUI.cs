public class FrameUI {
    private Monster enemy;
    private Monster yourMonster;
    private int widthSize;
    
    public FrameUI(int widthSize) {
        this.widthSize = widthSize;
    }
    public void AddMonsters( Monster monster1, Monster yourMonster){
        this.enemy = monster1;
        this.yourMonster = yourMonster;
    }
    public void RenderGame(int indexOfMoveMonster)
    {
        Console.Clear();
        showStatusBar(enemy, false);
        if(indexOfMoveMonster == 0) { Console.WriteLine("\n" + (enemy.RenderingArt).Replace("1", "\t\t\t")); } 
        else { Console.WriteLine("\n" + (enemy.RenderingArt).Replace("1", "\t\t\t\t\t")); }
        Console.Write($"\n{AddSpace(((widthSize-2)/2)-2)}[ vs ]{AddSpace(Convert.ToInt32((widthSize-(1.5))/2)-2)}");
        if(indexOfMoveMonster == 1) { Console.WriteLine("\n" + (yourMonster.RenderingArt).Replace("1 ", "\t\t\t")); }
        else { Console.WriteLine("\n" + (yourMonster.RenderingArt).Replace("1 ", "\t")); }
        showStatusBar(yourMonster, true);
    }
    void showHealthBar (int Health)
    {   
        string bar = "";
        for (int i = 0; i < Health/10; i++)
        {
            bar = bar + "█";
        }
        Addtext($" HP   [{AddSpace(10-(Health/10))}{bar}] {Health}%", true);
        AddLine();
    }
    void showStatusBar(Monster monster, bool isBottomBar)
    {
        AddLine();
        showHealthBar(monster.Health);
        Addtext($" DEF   {AddValueTextView(monster.Defense, 10)} ", isBottomBar);
        Addtext($" ATK   {AddValueTextView(monster.Attack, 10)} ", isBottomBar);
        Addtext($" Regen {AddValueTextView(monster.HpRegen, 10)} ", isBottomBar);
        AddLine();
    }
    void AddLine(int position)
    {
        // top    - 0
        // center - 1
        // bottom - 2
        Console.Write("\n╔");
        for (int i = 0; i < widthSize-2; i++)
        {
            Console.Write("═");
        }
        Console.Write("╗");
    }
    void Addtext(string text, bool isRight)
    {
        string res = "|";
        if(!isRight){
           res = res + AddSpace((widthSize-2)-text.ToCharArray().Length);
        }
        res = res + text;
        if(isRight){
           res = res + AddSpace((widthSize-2)-text.ToCharArray().Length);
        }
        res = res + "|";
        Console.Write("\n" + res);
    }
    string AddSpace(int num)
    {
        string spaces = "";
        for (int i = 0; i < num; i++)
        {
            spaces = spaces + " ";
        }
        return spaces;
    }
    string AddValueTextView(int value, int maxText)
    { 
        string res = "[";
        res = res + AddSpace((maxText-2) - Convert.ToString(value).ToCharArray().Length);
        res = res + value + "]";
        return res;
    }
}