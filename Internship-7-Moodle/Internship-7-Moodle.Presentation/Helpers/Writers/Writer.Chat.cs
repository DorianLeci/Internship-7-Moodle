using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Application.Users.Response.User;
using Internship_7_Moodle.Presentation.Actions;
using Internship_7_Moodle.Presentation.Helpers.ConsoleHelpers;
using Internship_7_Moodle.Presentation.Helpers.UiState;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace Internship_7_Moodle.Presentation.Helpers.Writers;

public static partial class Writer
{
    public static class Chat
    {
            public static void ChatErrorWriter(AppResult<ChatResponse> result)
    {
        Common.ErrorWriter(result,"[red]Nije moguće otvoriti chat[/]");
    }

    // private static void ChatHeaderWriter(ChatResponse chatResponse)
    // {
    //     var otherUserName = chatResponse.OtherUserName;
    //     AnsiConsole.Write(new Panel($"Chat sa: [yellow]{otherUserName}[/]")
    //     {
    //         Header = new PanelHeader("[green]Privatni chat[/]", Justify.Center),
    //         Border = BoxBorder.Rounded
    //     });
    // }

    public static async Task RunChatLive(ChatUiState state,UserActions actions)
    {
        await AnsiConsole.Live(BuildLayout(state))
            .AutoClear(false)
            .StartAsync( async ctx =>
            {
                while (!state.Exit)
                {
                    bool atBottom = state.ScrollOffset >= state.Chat.Messages.Count - state.MaxVisibleMessages;
                    
                    var refreshResult = await state.UserActions.GetChatAsync(state.Chat.CurrentUserId, state.Chat.OtherUserId);
                    if (refreshResult.IsFailure || refreshResult.Value == null)
                    {
                        Writer.Chat.ChatErrorWriter(refreshResult);
                        ConsoleHelper.ClearAndSleep(2000, "[blue]Izlazak...[/]");
                        return;
                    }
                    
                    state.Chat.Messages = refreshResult.Value.Messages;                   
                    if (atBottom)
                        state.ScrollOffset = Math.Max(0, state.Chat.Messages.Count - state.MaxVisibleMessages);
                    
                    await UpdateMessageList(refreshResult.Value,state.UserActions);
                    
                    ctx.UpdateTarget(BuildLayout(state));
                    
                    while (Console.KeyAvailable)
                    {
                        var key = Console.ReadKey(true);
                        switch (key.Key)
                        {
                            case ConsoleKey.Enter:
                            {
                                var text = state.InputBuffer.Trim();
                                state.InputBuffer = "";
                                
                                if (string.Equals(text, "/exit", StringComparison.InvariantCultureIgnoreCase))
                                {
                                    state.Exit = true;
                                    state.Error="[blue]\nIzlazak...[/]";
                                    break;
                                }

                                if (!string.IsNullOrWhiteSpace(text))
                                {
                                    var result=await actions.SendPrivateMessageAsync(state.Chat.CurrentUserId, state.Chat.OtherUserId,text);

                                    if (result.IsFailure)
                                    {
                                        state.Error = '\n' + string.Join("\n",
                                            result.Errors.Select(e => $"[red]{e.Message}[/]"));
                                    }

                                    else
                                        state.Error = "\n" + "[green]Uspješno unesena nova poruka[/]";

                                    ctx.UpdateTarget(BuildLayout(state));

                                    _ = Task.Run(async () =>
                                    {
                                        await Task.Delay(3000);
                                        state.Error = null;
                                    });
                                }

                                break;
                            }
                            case ConsoleKey.UpArrow:
                                state.ScrollOffset--;
                    
                                if (state.ScrollOffset < 0)
                                    state.ScrollOffset = 0;
                                break;
                            
                            case ConsoleKey.DownArrow:
                                state.ScrollOffset++;

                                if (state.ScrollOffset >(state.Chat.Messages.Count - state.MaxVisibleMessages))
                                    state.ScrollOffset = state.Chat.Messages.Count - state.MaxVisibleMessages;
                                break;
                            
                            case ConsoleKey.Backspace when state.InputBuffer.Length > 0:
                                state.InputBuffer = state.InputBuffer[..^1];
                                break;
                            
                            default:
                            {
                                if (!char.IsControl(key.KeyChar))
                                    state.InputBuffer += key.KeyChar;
                                break;
                            } 
                        }
                    }
                    
                    ctx.UpdateTarget(BuildLayout(state));
                }
            });

    }
    
    private static Rows BuildLayout(ChatUiState state)
    {
        const string hasReadMarkup = "[blue]✓✓[/]";
        const string hasNotReadMarkup = "[grey]✓✓[/]";

        var chatGrid = new Grid();
        chatGrid.AddColumn(new GridColumn { Width = 50 });
        chatGrid.AddColumn(new GridColumn { Width = 50 });
        
        var visibleMessages=state.Chat.Messages
            .Skip(Math.Max(0, state.ScrollOffset))
            .Take(state.MaxVisibleMessages)
            .ToList();


        foreach (var msg in visibleMessages)
        {
            bool isCurrentUser = msg.SenderId == state.Chat.CurrentUserId;
            string senderName = isCurrentUser ? "[blue]Ti[/]" : $"[yellow]{msg.SenderName}[/]";

            var infoTable = new Table()
            {
                Border = TableBorder.None,
                ShowHeaders = false
            };
            infoTable.AddColumn("");
            infoTable.AddRow(
                $"[grey]{msg.SentAt:HH:mm}[/] {(isCurrentUser ? (msg.IsRead ? hasReadMarkup : hasNotReadMarkup) : "")}");

            var panel = new Panel(new Rows(new Markup(msg.Content), infoTable))
            {
                Header = new PanelHeader(senderName, Justify.Left),
                Border = BoxBorder.Heavy,
                BorderStyle = isCurrentUser ? new Style(Color.BlueViolet) : new Style(Color.Grey)
            };

            var emptyPanel = new Panel(" ")
            {
                Border = BoxBorder.None,
                Padding = new Padding(0),
                Expand = true
            };

            if (isCurrentUser)
                chatGrid.AddRow(panel, emptyPanel);
            else
                chatGrid.AddRow(emptyPanel, panel);
        }

        var statusText = state.Error ?? "\n[blue]Upiši poruku | exit za izlaz[/]";

        var statusPanel = new Panel(new Markup(statusText))
        {
            Border = BoxBorder.None,
        };
        var inputPanel = new Panel($"> {state.InputBuffer}")
        {
            Border = BoxBorder.Square
        };
        
        return new Rows(chatGrid, statusPanel,inputPanel);
    }


    private static async Task UpdateMessageList(ChatResponse response,UserActions userActions)
    {
        
        var visibleUnreadMsg = response.Messages
            .Where(m => m.ReceiverId == response.CurrentUserId && !m.IsRead)
            .Select(m => m.MessageId)
            .ToList();
        
        if(visibleUnreadMsg.Count>0)
            await userActions.UpdateUnreadMessagesAsync(visibleUnreadMsg);
        
    }
    
    }
}