public class Program
{
    
    public static void Main()
    {
        Console.ForegroundColor = ConsoleColor.White;
        HomePlay homePlay = new HomePlay();
        SelectionWithValidation selector1 = new SelectionWithValidation();
        selector1.AddSelectionAction(homePlay.Play_Adventure, "Play Adventure");
        selector1.ShowSelection();
    }
}   