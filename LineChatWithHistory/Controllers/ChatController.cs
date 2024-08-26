using isRock.LineBot;
using LineChatWithHistory.Models.Settings;
using Microsoft.AspNetCore.Mvc;

namespace LineChatWithHistory.Controllers;

public class ChatController : LineWebHookControllerBase
{
    private readonly string _adminUserId;
    private readonly Bot _bot;

    public ChatController(LineMessagingApiSettings lineMessagingApiSettingsSettings)
    {
        _adminUserId = lineMessagingApiSettingsSettings.UserId;
        ChannelAccessToken = lineMessagingApiSettingsSettings.ChannelAccessToken;
        _bot = new Bot(ChannelAccessToken);
    }

    [Route("api/LineBotChatWebHook")]
    public IActionResult Test()
    {
        try
        {
            if (IsLineVerify()) return Ok();
            foreach (var lineEvent in ReceivedMessage.events)
            {
                _bot.DisplayLoadingAnimation(lineEvent.source.userId, 10);
                string responseMessage = "test";
                _bot.ReplyMessage(lineEvent.replyToken, responseMessage);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            _bot.PushMessage(_adminUserId, "系統忙碌中，請稍後再試。");
            return Ok();
        }

        return Ok();
    }

    private bool IsLineVerify()
    {
        return ReceivedMessage.events == null || ReceivedMessage.events.Count() <= 0 ||
               ReceivedMessage.events.FirstOrDefault().replyToken == "00000000000000000000000000000000";
    }
}