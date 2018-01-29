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
    public class ConsultaSecundariaDialog
    {
        private IDialogContext context;
        private LuisResult result;

        public ConsultaSecundariaDialog(IDialogContext context, LuisResult result)
        {
            this.context = context;
            this.result = result;
        }

        public async Task StartAsync()
        {
            //obtener el producto si este a sido escodigo anteriormente
            var servicio = "Servicio";
            context.PrivateConversationData.TryGetValue<string>("tipoDeServicio", out servicio);

            //obtener la Pregunta::Palabra2 si este a sido escodigo anteriormente
            var palabra1 = "Palabra1";
            context.PrivateConversationData.TryGetValue<string>("Palabra1", out palabra1);

            await context.PostAsync(servicio);
            await context.PostAsync(palabra1);
        }
    }
}