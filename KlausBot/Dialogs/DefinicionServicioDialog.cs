using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Threading.Tasks;
using KlausBot.Models;
using KlausBot.Util;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Builder.Dialogs;

namespace KlausBot.Dialogs
{
    [Serializable]
    public class DefinicionServicioDialog
    {
        private IDialogContext context; 
        private LuisResult result;

        public DefinicionServicioDialog(IDialogContext context, LuisResult result)
        {
            this.context = context;
            this.result = result;
        }

        public async Task StartAsync()
        {
            var reply = context.MakeMessage();
            reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;

            string confirmacionRespuesta1 = "Tengo esta respuesta para usted:";
            string confirmacionRespuesta2 = "Tengo estas respuestas para usted:";
            string preguntaNoRegistrada1 = "Lo siento, su pregunta no esta registrada, tal vez no escribió la pregunta correctamente";
            string preguntaNoRegistrada2 = "Lo siento, su pregunta no esta registrada";
            string opcionSecundarioDeRespuesta1 = "Pero esta respuesta le podría interesar:";
            string opcionSecundarioDeRespuesta2 = "Pero estas respuestas le podrían interesar:";
            string preguntaConsulta = "si tiene otra consulta por favor hágamelo saber";

            //obtener el producto si este fue elegido de forma explicita
            foreach (var entity in result.Entities.Where(Entity => Entity.Type == "Servicio"))
            {
                var value = entity.Entity.ToLower().Replace(" ", "");

                if (value == "outlook" || value == "outlok")
                {
                    reply.Attachments = RespuestasOutlook.GetOutlookDefinicion();
                    await context.PostAsync(confirmacionRespuesta1);
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                    return;
                }
                else if (value == "OneDrive" || value == "One Drive")
                {
                    reply.Attachments = RespuestasOneDrive.GetOneDriveDefinicion();
                    await context.PostAsync(confirmacionRespuesta1);
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                    return;
                }
                else if (value == "excel")
                {
                    reply.Attachments = Respuestas.GetExcelDefinicionCard();
                    await context.PostAsync(confirmacionRespuesta1);
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                    return;
                }
                else if (value == "powerpoint" || value == "power point")
                {
                    reply.Attachments = Respuestas.GetPowerPointDefinicionCard();
                    await context.PostAsync(confirmacionRespuesta1);
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                    return;
                }
                else if (value == "word")
                {
                    reply.Attachments = Respuestas.GetWordDefinicionCard();
                    await context.PostAsync(confirmacionRespuesta1);
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                    return;
                }
                else
                {
                    await context.PostAsync($"Lo siento, '{value}' no esta registrado como servicio");
                    reply.Attachments = Respuestas.GetConsultaV2();
                    await context.PostAsync(reply);
                    return;
                }
            }

            //obtener el producto si este a sido escodigo anteriormente
            var servicio = "Servicio";
            context.PrivateConversationData.TryGetValue<string>("tipoDeServicio", out servicio);
            if (servicio == "Word")
            {
                reply.Attachments = Respuestas.GetWordDefinicionCard();
                await context.PostAsync(confirmacionRespuesta1);
                await context.PostAsync(reply);
                await context.PostAsync(preguntaConsulta);
                context.PrivateConversationData.SetValue<string>("tipoServicio", "Servicio");
                return;
            }
            else if (servicio == "Excel")
            {
                reply.Attachments = Respuestas.GetExcelDefinicionCard();
                await context.PostAsync(confirmacionRespuesta1);
                await context.PostAsync(reply);
                await context.PostAsync(preguntaConsulta);
                context.PrivateConversationData.SetValue<string>("tipoServicio", "Servicio");
                return;
            }
            else if (servicio == "Outlook")
            {
                reply.Attachments = RespuestasOutlook.GetOutlookDefinicion();
                await context.PostAsync(confirmacionRespuesta1);
                await context.PostAsync(reply);
                await context.PostAsync(preguntaConsulta);
                context.PrivateConversationData.SetValue<string>("tipoServicio", "Servicio");
                return;
            }
            else if (servicio == "OneDrive")
            {
                reply.Attachments = RespuestasOneDrive.GetOneDriveDefinicion();
                await context.PostAsync(confirmacionRespuesta1);
                await context.PostAsync(reply);
                await context.PostAsync(preguntaConsulta);
                context.PrivateConversationData.SetValue<string>("tipoServicio", "Servicio");
                return;
            }
            else if (servicio == "PowerPoint")
            {
                reply.Attachments = Respuestas.GetPowerPointDefinicionCard();
                await context.PostAsync(confirmacionRespuesta1);
                await context.PostAsync(reply);
                await context.PostAsync(preguntaConsulta);
                context.PrivateConversationData.SetValue<string>("tipoServicio", "Servicio");
                return;
            }
            else
            {
                // Si el usuario no a ingresado la primera parte de la pregunta
                await context.PostAsync("Lo siento, su pregunta no esta registrada");
                reply.Attachments = Respuestas.GetConsultaV2();
                await context.PostAsync(reply);
                await context.PostAsync("O tal vez no escribió la pregunta correctamente");
                return;
            }
        }
    }
}