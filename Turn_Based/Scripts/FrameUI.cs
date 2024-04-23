public class FrameUI : IOutputPositioner
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
        DisplayToCenter($"{AddSpace(((widthSize-2)/2)-2)}[ vs ]{AddSpace(Convert.ToInt32((widthSize-(1.5))/2)-2)}", true);
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
        Addtext($" HP {Health}/{maxHealth}  [{AddSpace(Convert.ToInt32(10 - (percentage/10)))}{bar}] {Convert.ToInt32(percentage)}%", true);
        AddLine(1);
    }
    public void showStatusBar(Monster monster, bool isBottomBar)
    {
        AddLine(0);
        showHealthBar(monster.Health, monster.MaxHealth);
        Addtext($" ATK   {AddValueTextView(monster.Attack, 10)} ", $" DEF   {AddValueTextView(monster.Defense, 10)} ");
        Addtext($" REGEN {AddValueTextView(monster.HpRegen, 10)} ", $" RAGE  {AddValueTextView(monster.Rage, 10)} ");
        Addtext($" PEN   {AddValueTextView(monster.Penetration, 10)} ", $" SPEED {AddValueTextView(monster.Speed, 10)} ");
        Addtext($" LVL   {AddValueTextView(monster.Level, 10)} ", $" EXP {AddValueTextView(monster.Exp, 10)} ");
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
        DisplayToCenter(res, true);
    }
    public void Addtext(string text, bool isRight)
    {
        string res = "║";
        if(!isRight){
           res = res + AddSpace((widthSize-2)-text.ToCharArray().Length);
        }
        res = res + text;
        if(isRight){
           res = res + AddSpace((widthSize-2)-text.ToCharArray().Length);
        }
        res = res + "║";
        DisplayToCenter(res, true);
    }
    public void Addtext(string text1, string text2)
    {
        string res = "║";
        res = res + text1;
        res = res + AddSpace((widthSize-2)-(text1.ToCharArray().Length + text2.ToCharArray().Length));
        res = res + text2;
        res = res + "║";
        DisplayToCenter(res, true);
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
    string AddTabs(int num)
    {
        string tabs = "";
        for (int i = 0; i < num; i++)
        {
            tabs = tabs + "\t";
        }
        return tabs;
    }
    string AddValueTextView(int value, int maxText)
    { 
        string res = "[";
        res = res + AddSpace((maxText-2) - Convert.ToString(value).ToCharArray().Length);
        res = res + value + "]";
        return res;
    }
    public void DisplayToCenter(string text, bool isNextLine)
    {
        int spaces = (Console.WindowWidth - widthSize)/2;
        Console.Write($"{((isNextLine)? "\n" : "")}{AddSpace(spaces)}{text}");
    }
}