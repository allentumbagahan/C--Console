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
    public void RenderGame()
    {
        Console.Clear();
        AddLine();
        Addtext($"DEF {AddValueTextView(enemy.Defense, 10)} ", false);
        Addtext($"ATK {AddValueTextView(enemy.Attack, 10)} ", false);
        Addtext($"HP {AddValueTextView(enemy.Health, 10)} ", false);
        Addtext($"HP Regen {AddValueTextView(enemy.HpRegen, 10)} ", false);
        AddLine();
        Console.WriteLine("\n" + (enemy.RenderingArt).Replace("1", AddSpace(widthSize/2)));
        Console.Write($"\n{AddSpace(((widthSize-2)/2)-2)}[ vs ]{AddSpace(Convert.ToInt32((widthSize-(1.5))/2)-2)}");
        Console.WriteLine("\n" + (yourMonster.RenderingArt).Replace("1", " "));
        AddLine();
        Addtext($" DEF {AddValueTextView(yourMonster.Defense, 10)}", true);
        Addtext($" ATK {AddValueTextView(yourMonster.Attack, 10)}", true);
        Addtext($" HP  {AddValueTextView(yourMonster.Health, 10)}", true);
        Addtext($"HP Regen {AddValueTextView(yourMonster.HpRegen, 10)} ", true);
        AddLine();
    }
    void AddLine()
    {
        Console.Write("\n|");
        for (int i = 0; i < widthSize-2; i++)
        {
            Console.Write("-");
        }
        Console.Write("|");
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