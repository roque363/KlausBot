using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using Newtonsoft.Json;
using KlausBot.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using KlausBot.Models;
using System.Collections.Generic;

namespace KlausBot
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            if (activity.Type == ActivityTypes.Message)
            {
                await Conversation.SendAsync(activity, MakeLuisDialog);
            }
            else
            {
                HandleSystemMessage(activity);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        internal static IDialog<ConsultaServicio> MakeLuisDialog()
        {
            return Chain.From(() => new LUISDialog(ConsultaServicio.BuildForm));
        }

        private async Task HandleSystemMessage(Activity message)
        {
            if (message.Type == ActivityTypes.DeleteUserData)
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == ActivityTypes.ConversationUpdate)
            {
                // Handle conversation state changes, like members being added and removed
                // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
                // Not available in all channels

                IConversationUpdateActivity iConversationUpdated = message as IConversationUpdateActivity;
                if (iConversationUpdated != null)
                {
                    ConnectorClient connector = new ConnectorClient(new System.Uri(message.ServiceUrl));

                    foreach (var member in iConversationUpdated.MembersAdded ?? System.Array.Empty<ChannelAccount>())
                    {
                        // if the bot is added, then
                        if (member.Id == iConversationUpdated.Recipient.Id)
                        {
                            Activity replyToConversation = message.CreateReply("");
                            replyToConversation.Attachments.Add(GetCardSaludos());
                            var reply = await connector.Conversations.SendToConversationAsync(replyToConversation);
                        }
                    }
                }

            }
            else if (message.Type == ActivityTypes.ContactRelationUpdate)
            {
                // Handle add/remove from contact lists
                // Activity.From + Activity.Action represent what happened
            }
            else if (message.Type == ActivityTypes.Typing)
            {
                // Handle knowing tha the user is typing
            }
            else if (message.Type == ActivityTypes.Ping)
            {
            }

            // return null;
        }

        private static Attachment GetCardSaludos()
        {
            var Saludocard = new ThumbnailCard
            {
                Title = "Hola",
                Subtitle = "¿En que puedo ayudarte?, Por favor se especificó en tu pregunta ",
                /*
                Buttons = new List<CardAction>
                {
                    new CardAction(ActionTypes.PostBack, "Consultas", value: "Consulta"),
                    new CardAction(ActionTypes.PostBack, "Requerimiento", value: "Requerimiento")
                }
                */
            };
            return Saludocard.ToAttachment();
        }

    }
}