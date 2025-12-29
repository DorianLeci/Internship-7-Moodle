using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Application.Users.Response.User;
using Internship_7_Moodle.Presentation.Actions;
using Internship_7_Moodle.Presentation.Helpers.ConsoleHelpers;
using Spectre.Console;
namespace Internship_7_Moodle.Presentation.Helpers.Writers;

public static partial class Writer
{
    public static class Chat
    {
            public static void ChatErrorWriter(AppResult<ChatResponse> result)
    {
        Common.ErrorWriter(result,"[red]Nije moguće otvoriti chat[/]");
    }

    private static void ChatHeaderWriter(ChatResponse chatResponse)
    {
        var otherUserName = chatResponse.OtherUserName;
        AnsiConsole.Write(new Panel($"Chat sa: [yellow]{otherUserName}[/]")
        {
            Header = new PanelHeader("[green]Privatni chat[/]", Justify.Center),
            Border = BoxBorder.Rounded
        });
    }
    public static async Task ChatWriter(ChatResponse chatResponse,UserActions userActions,int scrollOffset,int panelHeight)
    {            
        ConsoleHelper.ClearAndSleep(0);
        ChatHeaderWriter(chatResponse);

        const string hasReadMarkup = "[blue]✓✓[/]";
        const string hasNotReadMarkup="[grey]✓✓[/]";

        var grid = new Grid();
        grid.AddColumn(new GridColumn { Width = 50 });
        grid.AddColumn(new GridColumn { Width = 50 });

        
        var visibleMsg= await UpdateMessageList(chatResponse, userActions, scrollOffset,panelHeight);
        
        foreach (var msg in visibleMsg)
        {
            var isCurrentUser = msg.SenderId == chatResponse.CurrentUserId;
            var senderName=msg.SenderId==chatResponse.CurrentUserId ? "[blue]Ti[/]" : $"[yellow]{msg.SenderName}[/]";
            
            var infoTable = new Table()
            {
                Border = TableBorder.None,
                ShowHeaders = false,
            };

            infoTable.AddColumn("");
            infoTable.AddRow($"[grey]{msg.SentAt}[/] {(isCurrentUser ? (msg.IsRead? hasReadMarkup : hasNotReadMarkup): "") }");
            
            var panel = new Panel(new Rows(new Markup(msg.Content),infoTable))
            {
                Header = new PanelHeader(senderName, Justify.Left),
                Border = BoxBorder.Heavy,
                BorderStyle=isCurrentUser ? new Style(Color.BlueViolet) : new Style(Color.Grey),
                
            };
            
            var emptyPanel = new Panel(" ") 
            {
                Border = BoxBorder.None,
                Padding = new Padding(0),
                Expand = true
            };
            if(isCurrentUser)
                grid.AddRow(panel,emptyPanel);

            else
                grid.AddRow(emptyPanel,panel);   
            
        }
        AnsiConsole.Write(grid);
        
    }

    private static async Task<List<PrivateMessageResponse>> UpdateMessageList(ChatResponse chatResponse,UserActions userActions,int scrollOffset,int panelHeight)
    {
        var visibleMsg = chatResponse.Messages
            .Skip(Math.Max(0, scrollOffset))
            .Take(panelHeight)
            .ToList();
        
        var visibleUnreadMsg = visibleMsg
            .Where(m => m.ReceiverId == chatResponse.CurrentUserId && !m.IsRead)
            .Select(m => m.MessageId)
            .ToList();
        
        if(visibleUnreadMsg.Count>0)
            await userActions.UpdateUnreadMessagesAsync(visibleUnreadMsg);
        
        return visibleMsg;
    }
    
    }
}