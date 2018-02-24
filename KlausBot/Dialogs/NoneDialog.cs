using System;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Threading.Tasks;
using KlausBot.Util;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Builder.Dialogs;

namespace KlausBot.Dialogs
{
    public class NoneDialog
    {
        private IDialogContext context;
        private LuisResult result;

        public NoneDialog(IDialogContext context, LuisResult result)
        {
            this.context = context;
            this.result = result;
        }

        public async Task StartAsync()
        {
            var estadoPregunta2 = "False";
            var estadoRespuesta2 = "False";
            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta2);
            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta2);

            Random rnd = new Random();
            // Dudas que puede generar el bot
            string[] none = {
                "Perdón, no entiendo lo que estas diciendo \U0001F615",
                "Perdón, no entendí lo que necesitas \U0001F615",
                "Perdón, no entendí lo que quieres decir \U0001F615",
                "Perdón, no entendí lo que necesitas \U0001F615",
            };

            // Generate random indexes for none
            int mIndex = rnd.Next(0, none.Length);

            var reply = context.MakeMessage();
            reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;
            reply.Attachments = Respuestas.GetConsulta();

            // Display the result.
            await context.PostAsync(none[mIndex]);
            await context.PostAsync(reply);
            return;
        }
    }
}