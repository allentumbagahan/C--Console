public class Program
{
    
    public static void Main()
    {
        HomePlay homePlay = new HomePlay();
        SelectionWithValidation selector1 = new SelectionWithValidation();
        selector1.AddSelectionAction(homePlay.Play_Adventure, "Play Adventure");
        selector1.ShowSelection();
    }
}   