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
    public class EnviarDialog
    {
        private IDialogContext context;
        private LuisResult result;

        public EnviarDialog(IDialogContext context, LuisResult result)
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

            // Recorrido de la primera parte de la pregunta
            foreach (var entityP1 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra1"))
            {
                var palabra1 = entityP1.Entity.ToLower().Replace(" ", "");
                context.PrivateConversationData.SetValue<string>("Palabra1", palabra1);
                if (palabra1 == "correoelectrónico" || palabra1 == "correoelectronico" || palabra1 == "correoselectrónicos" || palabra1 == "correoselectronicos" || palabra1 == "correos" || palabra1 == "correo" || palabra1 == "mensajes" || palabra1 == "mensaje")
                {
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");
                        if (palabra2 == "plantillas" || palabra2 == "plantillas")
                        {
                            reply.Attachments = Respuestas.GetEnviarMensajeBasadoPlantilla();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            return;
                        }
                        else if (palabra2 == "lista" || palabra2 == "listas" || palabra2 == "grupo" || palabra2 == "grupos")
                        {
                            reply.Attachments = Respuestas.GetEnviarMensajeGrupoContactos();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            return;
                        }
                        else if (palabra2 == "reunión" || palabra2 == "reunion" || palabra2 == "reuniones")
                        {
                            reply.Attachments = Respuestas.GetReenviarReuniónOutlook();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = Respuestas.GetEnviarRespuestasIntencio2();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta2);
                            await context.PostAsync(reply);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = Respuestas.GetReenviarYEnviarMensajeOutlook();
                    await context.PostAsync(confirmacionRespuesta2);
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                    return;
                }
                else if (palabra1 == "respuestasautomaticas" || palabra1 == "respuestaautomatica" || palabra1 == "respuestasautomáticas" || palabra1 == "respuestaautomática" || palabra1 == "respuestasfuera" || palabra1 == "respuestafuera")
                {
                    reply.Attachments = Respuestas.GetEnviarRespuestasAutomaticasFueraOficinaOutlook();
                    await context.PostAsync(confirmacionRespuesta1);
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                    return;
                }
                else if (palabra1 == "reenviar" || palabra1 == "reenvío" || palabra1 == "reenvio")
                {
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");
                        if (palabra2 == "reunión" || palabra2 == "reunion" || palabra2 == "reuniones")
                        {
                            reply.Attachments = Respuestas.GetReenviarReuniónOutlook();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            return;
                        }
                        else if (palabra2 == "correoelectrónico" || palabra2 == "correoelectronico" || palabra2 == "correoselectrónicos" || palabra2 == "correoselectronicos" || palabra2 == "correos" || palabra2 == "correo" || palabra2 == "mensajes" || palabra2 == "mensaje")
                        {
                            reply.Attachments = Respuestas.GetReenviarMensajeOutlook();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = Respuestas.GetReenviarReuniónOutlookYMensajeOutlook();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta2);
                            await context.PostAsync(reply);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = Respuestas.GetReenviarReuniónOutlookYMensajeOutlook();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta2);
                    await context.PostAsync(reply);
                    return;
                }
                else
                {
                    await context.PostAsync(preguntaNoRegistrada2);
                    await context.PostAsync($"O tal vez no escribió correctamente la palabra '{palabra1}'?");
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