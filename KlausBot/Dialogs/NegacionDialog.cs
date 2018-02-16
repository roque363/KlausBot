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
    public class NegacionDialog
    {
        private IDialogContext context;
        private LuisResult result;

        public NegacionDialog(IDialogContext context, LuisResult result)
        {
            this.context = context;
            this.result = result;
        }

        public async Task StartAsync()
        {
            var reply = context.MakeMessage();
            reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;

            // Obtener el estado de la respuesta (*Saber si el bot pregunto sobre otra pregunta*)
            var estadoRespuesta = "EstadoRespuesta";
            context.PrivateConversationData.TryGetValue<string>("EstadoRespuesta", out estadoRespuesta);

            if (estadoRespuesta == "True")
            {
                // Display the result
                await context.PostAsync("");
                context.PrivateConversationData.SetValue<string>("EstadoRespuesta", "False");
                return;
            }
            else if (estadoRespuesta == "False")
            {
                // Display the result
                reply.Attachments = Respuestas.GetConsultaV2();
                await context.PostAsync("Lo siento, acaso tienes una consulta");
                await context.PostAsync(reply);
                return;
            }
            else
            {
                // Display the result
                reply.Attachments = Respuestas.GetConsultaV2();
                await context.PostAsync("Lo siento, acaso tienes una consulta");
                await context.PostAsync(reply);
                return;
            }
        }
    }
}