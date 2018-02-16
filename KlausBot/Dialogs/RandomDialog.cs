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
    public class RandomDialog
    {
        private IDialogContext context;
        private LuisResult result;

        public RandomDialog(IDialogContext context, LuisResult result)
        {
            this.context = context;
            this.result = result;
        }

        public async Task StartAsync()
        {
            var reply = context.MakeMessage();
            reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;

            var estadoPregunta2 = "False";
            var estadoRespuesta2 = "False";

            Random rnd = new Random();
            // Dudas que puede generar el bot
            string[] random = {
                "Perdón, no entiendo lo que estas diciendo \U0001F615",
                "Perdón, no entendí lo que necesitas \U0001F615",
                "Perdón, no entendí lo que quieres decir \U0001F615",
                "Perdón, no entendí lo que necesitas \U0001F615",
            };

            // Generate random indexes for none
            int mIndex = rnd.Next(0, random.Length);

            // Display the result
            await context.PostAsync(random[mIndex]);
            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta2);
            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta2);
            return;
        }
    }
}