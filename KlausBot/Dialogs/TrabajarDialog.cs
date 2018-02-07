using System;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using KlausBot.Models;
using KlausBot.Util;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Builder.Dialogs;

namespace KlausBot.Dialogs
{
    public class TrabajarDialog
    {
        private IDialogContext context;
        private LuisResult result;

        public TrabajarDialog(IDialogContext context, LuisResult result)
        {
            this.context = context;
            this.result = result;
        }

        public async Task StartAsync()
        {
            var accion = "Trabajar";
            context.PrivateConversationData.SetValue<string>("Accion", accion);

            string preguntaConsulta = "¿Tiene alguna otra consulta?";
            string confirmacionRespuesta1 = "Tengo esta respuesta para usted:";
            string confirmacionRespuesta2 = "Tengo estas respuestas para usted:";
            string preguntaNoRegistrada1 = "Lo siento, su pregunta no esta registrada, tal vez no escribió la pregunta correctamente";
            string preguntaNoRegistrada2 = "Lo siento, su pregunta no esta registrada";
            string opcionSecundarioDeRespuesta1 = "Pero esta respuesta le podría interesar:";
            string opcionSecundarioDeRespuesta2 = "Pero estas respuestas le podrían interesar:";

            var reply = context.MakeMessage();
            reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;

            // Recorrido de la primera parte de la pregunta
            foreach (var entityP1 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra1"))
            {
                var palabra1 = entityP1.Entity.ToLower().Replace(" ", "");
                if (palabra1 == "conjunta" || palabra1 == "colaborativa")
                {
                    reply.Attachments = RespuestasOneDrive.GetTrabajarManeraConjuntaOfficeOneDrive();
                    await context.PostAsync(confirmacionRespuesta1);
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                    return;
                }
                else
                {
                    reply.Attachments = RespuestasOneDrive.GetTrabajarManeraConjuntaOfficeOneDrive();
                    await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra1}'?");
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
                    return;
                }
            }
            // No se detectó la primera parte de la pregunta
            await context.PostAsync(preguntaNoRegistrada2);
            reply.Attachments = Respuestas.GetConsultaV2();
            await context.PostAsync(reply);
            await context.PostAsync("O tal vez no escribió la pregunta correctamente");
            return;
        }
    }
}