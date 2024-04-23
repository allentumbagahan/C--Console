//inheritace
public class TextMethods : OutputPositioner {
    //poly
    public void Addtext(string text, bool isRight, int widthSize)
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
        DisplayToCenter(res, true, widthSize);
    }
    public void Addtext(string text1, string text2, int widthSize)
    {
        string res = "║";
        res = res + text1;
        res = res + AddSpace((widthSize-2)-(text1.ToCharArray().Length + text2.ToCharArray().Length));
        res = res + text2;
        res = res + "║";
        DisplayToCenter(res, true, widthSize);
    }
    public string AddSpace(int num)
    {
        string spaces = "";
        for (int i = 0; i < num; i++)
        {
            spaces = spaces + " ";
        }
        return spaces;
    }
    public string AddTabs(int num)
    {
        string tabs = "";
        for (int i = 0; i < num; i++)
        {
            tabs = tabs + "\t";
        }
        return tabs;
    }
    public override void DisplayToCenter(string text, bool isNextLine, int widthSize)
    {
        int spaces = (Console.WindowWidth - widthSize)/2;
        Console.Write($"{((isNextLine)? "\n" : "")}{AddSpace(spaces)}{text}");
    }
}