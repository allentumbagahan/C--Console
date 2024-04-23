//inheritance
public class FrameUI : TextMethods
{
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
        Console.ForegroundColor = ConsoleColor.Red;
        if(indexOfMoveMonster == 0) { Console.WriteLine("\n" + (enemy.RenderingArt).Replace("1", $"{AddTabs(Convert.ToInt32(((Console.WindowWidth - widthSize)/2)/8)+3)}")); } 
        else { Console.WriteLine("\n" + (enemy.RenderingArt).Replace("1", $"{AddTabs(Convert.ToInt32(((Console.WindowWidth - widthSize)/2)/8)+5)}")); }
        Console.ForegroundColor = ConsoleColor.White;
        DisplayToCenter($"{AddSpace(((widthSize-2)/2)-2)}[ vs ]{AddSpace(Convert.ToInt32((widthSize-(1.5))/2)-2)}", true, widthSize);
        Console.ForegroundColor = ConsoleColor.Green;
        if(indexOfMoveMonster == 1) { Console.WriteLine("\n" + (yourMonster.RenderingArt).Replace("1 ", $"{AddTabs(Convert.ToInt32(((Console.WindowWidth - widthSize)/2)/8)+3)}")); }
        else { Console.WriteLine("\n" + (yourMonster.RenderingArt).Replace("1 ", $"{AddTabs(Convert.ToInt32(((Console.WindowWidth - widthSize)/2)/8))}")); }
        Console.ForegroundColor = ConsoleColor.White;
        showStatusBar(yourMonster, true);
        
    }
    void showHealthBar (int Health, int maxHealth)
    {   
        float percentage = Health*10.0f/maxHealth*10.0f;
        string bar = "";
        for (int i = 0; i < Convert.ToInt32(percentage/10); i++)
        {
            bar = bar + "█";
        }
        Addtext($" HP {Health}/{maxHealth}  [{AddSpace(Convert.ToInt32(10 - (percentage/10)))}{bar}] {Convert.ToInt32(percentage)}%", true, widthSize);
        AddLine(1);
    }
    public void showStatusBar(Monster monster, bool isBottomBar)
    {
        AddLine(0);
        showHealthBar(monster.Health, monster.MaxHealth);
        Addtext($" ATK   {AddValueTextView(monster.Attack, 10)} ", $" DEF   {AddValueTextView(monster.Defense, 10)} ", widthSize);
        Addtext($" REGEN {AddValueTextView(monster.HpRegen, 10)} ", $" RAGE  {AddValueTextView(monster.Rage, 10)} ", widthSize);
        Addtext($" PEN   {AddValueTextView(monster.Penetration, 10)} ", $" SPEED {AddValueTextView(monster.Speed, 10)} ", widthSize);
        Addtext($" LVL   {AddValueTextView(monster.Level, 10)} ", $" EXP {AddValueTextView($"{monster.Exp}/{10}", 10)} ", widthSize);
        AddLine(2);
    }
    public void AddLine(int position)
    {
        // top    - 0
        // center - 1
        // bottom - 2
        char left = '|';
        char right = '|';
        string res = "";
        switch(position)
        {
            case 0 :
                left = '╔';
                right = '╗';
                break;
            case 1 :
                left = '╠';
                right = '╣';
                break;
            case 2 :
                left = '╚';
                right = '╝';
                break;
        }
        res = res + left;
        for (int i = 0; i < widthSize-2; i++)
        {
            res = res + "═";
        }
        res = res + right;
        DisplayToCenter(res, true, widthSize);
    }


    //poly
    string AddValueTextView(int value, int maxText)
    { 
        string res = "[";
        res = res + AddSpace((maxText-2) - Convert.ToString(value).ToCharArray().Length);
        res = res + value + "]";
        return res;
    }
    string AddValueTextView(string value, int maxText)
    { 
        string res = "[";
        res = res + AddSpace((maxText-2) - Convert.ToString(value).ToCharArray().Length);
        res = res + value + "]";
        return res;
    }
    
}