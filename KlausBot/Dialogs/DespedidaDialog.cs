using System;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Threading.Tasks;
using System.Collections.Generic;
using KlausBot.Models;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Builder.Dialogs;

namespace KlausBot.Dialogs
{
    public class DespedidaDialog
    {
        private IDialogContext context;
        private LuisResult result;

        public DespedidaDialog(IDialogContext context, LuisResult result)
        {
            this.context = context;
            this.result = result;
        }

        public async Task StartAsync()
        {
            Random rnd = new Random();

            // Despedida que puede generar el bot
            string[] despe = {
                "Espero poder ayudarle la prónxima vez, estoy dispinible las 24 horas del día",
                "¡Hasta pronto!",
                "¡Nos vemos pronto! \U0001F917",
                "¡Hasta la proxima!",
            };

            // Generate random indexes for despe
            int mIndex = rnd.Next(0, despe.Length);

            // Display the result.
            await context.PostAsync(despe[mIndex]);
            return;
        }
    }
}