using System;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Internals.Fibers;
using KlausBot.Models;
using KlausBot.Util;


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
            Random rnd = new Random();
            // Saludos que puede generar el bot
            string[] saludos = {
                "¡Hola! {0}, ¿en qué te puedo ayudar? \U0001F601",
                "¡Bienvenido! {0} \U0001F601 ¿en qué te puedo ayudar?",
                "Qué tal {0} \U0001F601, ¿cómo puedo ayudarte?",
                "Buen día {0} \U0001F601, cuéntame, ¿en que puedo ayudarte?"
            };

            // Generate random indexes for saludos
            int mIndex = rnd.Next(0, saludos.Length);

            var userName = String.Empty;
            context.UserData.TryGetValue<string>("Name", out userName);
            if (string.IsNullOrEmpty(userName))
            {
                await context.PostAsync("¿Cual es tu nombre?");
                context.UserData.SetValue<bool>("GetName", true);
            }
            else
            {
                var reply = context.MakeMessage();
                reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;

                // Display the result.
                await context.PostAsync(String.Format(saludos[mIndex], userName));
                reply.Attachments = Respuestas.GetConsulta();
                await context.PostAsync(reply);
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