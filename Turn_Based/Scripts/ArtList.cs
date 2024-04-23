using System.Collections.Generic;
public class ArtList {
    public  static string bars = "▀ █ ▄";
    public static string elepant = "1 	     ___      ___\n1 	    /   \\~~~~/   \\\n1    _ _ _ _(      o  o    )\n1   '        \\___      ___/\n1  /             (\\   |(\n1 /|              /\\  |\n1  \\   /____\\    /  \\ |\n1   |_|      |__|    \"\"\n";
    public static string twinDog = "1          __\n1       __/o \\_\n1       \\____  \\  \n1           /   \\\n1    __    //\\   \\\n1___/o \\--//--\\   \\_/\n1\\_____  ___   \\  |\n1      ||   \\ | \\ |\n1     _||   _|| _||";
    public static string pegasus= "1          ,  ,\n1          \\\\ \\\\           \n1          ) \\\\ \\\\    _p_ \n1          )^\\))\\))  /  *\\ \n1           \\_|| || / /^`-' \n1  __       -\\ \\\\--/ / \n1 <'  \\\\___/   ___. )'\n1     `====\\ )___/\\\\ \n1          //     `\"\n1          \\\\    /  \\\n1          `\"";
    public static Dictionary<string, string> ArtListContainer = new Dictionary<string, string>();
    public static string chest_closed = "1\n       ____...------------...____1\n  _.-\"` /o/__ ____ __ __  __ \\o\\_`\"-._1\n.\'     / /                    \\ \\     \'.1\n|=====/o/======================\\o\\=====| 1\n|____/_/________..____..________\\_\\____|1\n/   _/ \\_          [|]         _/ \\_   \\1\n\\_________/____/_________\\____\\________/1\n |===\\!/========================\\!/===|1\n |   |=|          .---.         |=|   |1\n |===|o|=========/     \\========|o|===|1\n |   | |         \\() ()/        | |   |1\n |===|o|======{\'-.) A (.-\'}=====|o|===|1\n | __/ \\__     \'-.\\+++/.-\'    __/ \\__ |1\n |][][][]][][][][][{ }][][][][][][][][|1\n |  _\\o/   __  {.\' __  \'.} _   _\\o/  _|1\n \"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"";
    public static string chest_open = "1\n --.-.-.-.-.-.-.-[|]-.-.-.-.-.-.-.--1\n /\"================================\"\\1\n::::::::::::::::::::::::::::::::::::::1\n|| \\\\       \\\\           \\\\         ||1\n||  \\\\           \\\\   \\\\            ||1\n||                          \\\\      ||1\n||        \\\\             \\\\         ||1\n||              \\\\    \\\\       \\\\   ||1\n||__________________________________||1\n\\________\\____/_________/___\\________/1\n|===\\!/========================\\!/===|1\n|   |=|          .---.         |=|   |1\n|===|o|=========/     \\========|o|===|1\n|   | |         \\() ()/        | |   |1\n|===|o|======{\'-.) A (.-\'}=====|o|===|1\n| __/ \\__     \'-.\\+++/.-\'    __/ \\__ |1\n|][][][]][][][][][{ }][][][][][][][][|1\n|  _\\o/   __  {.\' __  \'.} _   _\\o/  _|1\n\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"";
    public static void SetArt()
    {
        ArtListContainer.Clear();
        ArtListContainer.Add("Elepant", elepant);
        ArtListContainer.Add("Twindog", twinDog);
        ArtListContainer.Add("Pegasus", pegasus);
        ArtListContainer.Add("Chest_Open", chest_open);
        ArtListContainer.Add("Chest_Close", chest_closed);
    }
    public static string GetArt(string artName)
    {
        SetArt();
        return ArtListContainer[artName];
    }
    public static string GetArt()
    {
        SetArt();
        try {
            Random random = new Random();
            return ArtListContainer[ArtListContainer.Keys.ToList()[random.Next(0, ArtListContainer.Keys.ToList().Count - 1)]];
        }
        catch(Exception err)
        {
            Console.WriteLine("" + err.Message);
            return "";
        }
    }
} 



