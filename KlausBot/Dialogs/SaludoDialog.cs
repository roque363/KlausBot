using System;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Internals.Fibers;

namespace KlausBot.Dialogs
{
    [Serializable]
    public class SaludoDialog : IDialog
    {
        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync("Hola soy Klaus Bot");
            await Respond(context);

            var userName = String.Empty;
            context.UserData.TryGetValue<string>("Name", out userName);
            if (string.IsNullOrEmpty(userName))
            {
                context.Wait(MessageReceivedAsync);
            }
            else
            {
                context.Done(userName);
            }
        }

        private static async Task Respond(IDialogContext context)
        {
            var userName = String.Empty;
            context.UserData.TryGetValue<string>("Name", out userName);
            if (string.IsNullOrEmpty(userName))
            {
                await context.PostAsync("¿Cual es tu nombre?");
                context.UserData.SetValue<bool>("GetName", true);
            }
            else
            {
                await context.PostAsync(String.Format("Hola {0}. ¿Como puedo ayudarte hoy?", userName));
            }
        }

        public async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            var message = await argument;
            var userName = String.Empty;
            var getName = false;
            context.UserData.TryGetValue<string>("Name", out userName);
            context.UserData.TryGetValue<bool>("GetName", out getName);

            if (getName)
            {
                userName = message.Text;
                context.UserData.SetValue<string>("Name", userName);
                context.UserData.SetValue<bool>("GetName", false);
            }

            await Respond(context);
            context.Done(message);
        }

    }

}