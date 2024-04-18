using System.Collections.Generic;
public class ArtList {
    public  static string bars = "▀ █ ▄";
    public static string elepant = "1 	     ___      ___\n1 	    /   \\~~~~/   \\\n1    _ _ _ _(      o  o    )\n1   '        \\___      ___/\n1  /             (\\   |(\n1 /|              /\\  |\n1  \\   /____\\    /  \\ |\n1   |_|      |__|    \"\"\n";
    public static string twinDog = "1          __\n1       __/o \\_\n1       \\____  \\  \n1           /   \\\n1    __    //\\   \\\n1___/o \\--//--\\   \\_/\n1\\_____  ___   \\  |\n1      ||   \\ | \\ |\n1     _||   _|| _||";
    public static string pegasus= "1          ,  ,\n1          \\\\ \\\\           \n1          ) \\\\ \\\\    _p_ \n1          )^\\))\\))  /  *\\ \n1           \\_|| || / /^`-' \n1  __       -\\ \\\\--/ / \n1 <'  \\\\___/   ___. )'\n1     `====\\ )___/\\\\ \n1          //     `\"\n1          \\\\    /  \\\n1          `\"";
    public static Dictionary<string, string> ArtListContainer = new Dictionary<string, string>();
    public static void SetArt()
    {
        ArtListContainer.Clear();
        ArtListContainer.Add("Elepant", elepant);
        ArtListContainer.Add("Twindog", twinDog);
        ArtListContainer.Add("Pegasus", pegasus);
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