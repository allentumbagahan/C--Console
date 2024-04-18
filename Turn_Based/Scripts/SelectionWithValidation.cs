using System;
using System.Linq;
using System.Collections.Generic;

public class SelectionWithValidation 
{
    //List<> SelectionList = new 
	private string Header;
	private string subHeader;
    private bool isAbletoExit;
    private string ExitMessage;
    public delegate void ActionCon();
	struct ActionType
    {
        public ActionCon action;
		public string actionName;
		
    }
    List<ActionType> ActionList = new List<ActionType>();
    public SelectionWithValidation()
    {

    }
	public SelectionWithValidation(bool isAbletoExit, string exitMessage)
    {
       this.isAbletoExit = isAbletoExit;
       this.ExitMessage = exitMessage;
    }
    public void ClearSelection()
    {
        ActionList.Clear();
    }
    public void InvokeSelection(int index)
    {
        ActionList[index].action.Invoke();
    }
    public void InvokeSelection()
    {
        Random random = new Random();
        ActionList[random.Next(0, ActionList.Count() - 1)].action.Invoke();
    }
    public void AddSelectionAction(ActionCon action, string actionName)
	{
        ActionType actionTemp = new ActionType();
		actionTemp.action = action;
		actionTemp.actionName = actionName;
        ActionList.Add(actionTemp);
    }  
    
    public void ShowSelection()
	{	
        int index = 0;
        int Selection_Size = ActionList.Count();
		Console.WriteLine("");
        Console.WriteLine($"Select Operation 1 - {Selection_Size}");
        foreach (var itemInAction in ActionList)
        {
            Console.WriteLine($"[{++index}] {itemInAction.actionName}");
        }
        if(isAbletoExit) Console.WriteLine($"[{ActionList.Count() + 1}] {ExitMessage}");
        try
        {
            ActionList[SelectOperation()].action.Invoke();
        }
        catch (System.Exception)
        {
            return;
        }
    }
	private  

    int SelectOperation()
	{
        string String_InputSelected;
		bool isSelectedAction = false;
        do
		{
            try
			{
                int Selection_Size = ActionList.Count();
                Console.WriteLine("Enter Action : ");
                String_InputSelected = Console.ReadLine();
                int parsedString = Int32.Parse(String_InputSelected);
				if(parsedString <= ActionList.Count() && parsedString > 0)
				{
                    isSelectedAction = true;
					return parsedString - 1;
                }
                else if(parsedString == ActionList.Count()+1)
                {
                    return -1;
                }
				else
				{
                    Console.WriteLine($"Select From 1 - {Selection_Size} ");
                }
				
            }
			catch(Exception err)
			{
                Console.WriteLine("Invalid Input");
            }
        }
        while(!isSelectedAction);
		return 0;
    }
}