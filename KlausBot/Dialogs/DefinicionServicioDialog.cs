using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Threading.Tasks;
using KlausBot.Models;
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

            //obtener el producto si este fue elegido de forma explicita
            foreach (var entity in result.Entities.Where(Entity => Entity.Type == "Servicio"))
            {
                var value = entity.Entity.ToLower().Replace(" ", "");

                if (value == "outlook" || value == "outlok")
                {
                    reply.Attachments = Respuestas.GetOutlookDefinicionCard();
                    await context.PostAsync("");
                    await context.PostAsync(reply);
                    return;
                }
                else if (value == "excel")
                {
                    reply.Attachments = Respuestas.GetExcelDefinicionCard();
                    await context.PostAsync(reply);
                    return;
                }
                else if (value == "powerpoint" || value == "power point")
                {
                    reply.Attachments = Respuestas.GetPowerPointDefinicionCard();
                    await context.PostAsync(reply);
                    return;
                }
                else if (value == "word")
                {
                    reply.Attachments = Respuestas.GetWordDefinicionCard();
                    await context.PostAsync(reply);
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
                await context.PostAsync(reply);
                //context.Wait(MessageReceived);
                context.PrivateConversationData.SetValue<string>("tipoServicio", "Servicio");
                return;
            }
            else if (servicio == "Excel")
            {
                reply.Attachments = Respuestas.GetExcelDefinicionCard();
                await context.PostAsync(reply);
                //context.Wait(MessageReceived);
                context.PrivateConversationData.SetValue<string>("tipoServicio", "Servicio");
                return;
            }
            else if (servicio == "Outlook")
            {
                reply.Attachments = Respuestas.GetOutlookDefinicionCard();
                await context.PostAsync(reply);
                //context.Wait(MessageReceived);
                context.PrivateConversationData.SetValue<string>("tipoServicio", "Servicio");
                return;
            }
            else if (servicio == "PowerPoint")
            {
                reply.Attachments = Respuestas.GetPowerPointDefinicionCard();
                await context.PostAsync(reply);
                //context.Wait(MessageReceived);
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