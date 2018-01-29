using System;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using KlausBot.Models;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Builder.Dialogs;

namespace KlausBot.Dialogs
{
    public class AplicarDialog
    {
        private IDialogContext context;
        private LuisResult result;

        public AplicarDialog(IDialogContext context, LuisResult result)
        {
            this.context = context;
            this.result = result;
        }
        public async Task StartAsync()
        {
            var reply = context.MakeMessage();
            reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;

            string preguntaConsulta = "¿Tiene alguna otra consulta?";
            string confirmacionRespuesta1 = "Tengo esta respuesta para usted:";
            string confirmacionRespuesta2 = "Tengo estas respuestas para usted:";
            string preguntaNoRegistrada1 = "Lo siento, su pregunta no esta registrada, tal vez no escribió la pregunta correctamente";
            string preguntaNoRegistrada2 = "Lo siento, su pregunta no esta registrada";
            string opcionSecundarioDeRespuesta1 = "Pero esta respuesta le podría interesar:";
            string opcionSecundarioDeRespuesta2 = "Pero estas respuestas le podrían interesar:";

            // Recorrido de la primera parte de la pregunta
            foreach (var entityP1 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra1"))
            {
                var palabra1 = entityP1.Entity.ToLower().Replace(" ", "");
                context.PrivateConversationData.SetValue<string>("Palabra1", palabra1);
                if (palabra1 == "categoría" || palabra1 == "categorías" || palabra1 == "categoria" || palabra1 == "categorias")
                {
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");
                        if (palabra2 == "color")
                        {
                            reply.Attachments = RespuestasOutlook.GetCrearAsignarCategoriasColor();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = RespuestasOutlook.GetCrearAsignarCategoriasColor();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            return;
                        }
                    }
                    await context.PostAsync($"Quizás desea saber como asignar categorías de color, tengo esto: ");
                    reply.Attachments = RespuestasOutlook.GetCrearAsignarCategoriasColor();
                    await context.PostAsync(reply);
                    await context.PostAsync($"Caso contrario, la pregunta no se encuentra registrada o vuelva a escribir correctamente la pregunta.");
                    return;

                }
                else if (palabra1 == "diseñosdefondo" || palabra1 == "diseñosdefondos" || palabra1 == "fondos" || palabra1 == "fondo" || palabra1 == "mensajes" || palabra1 == "mensaje")
                {
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");
                        if (palabra2 == "mensajes" || palabra2 == "mensaje")
                        {
                            reply.Attachments = RespuestasOutlook.GetAplicarFondosTemasMensajes();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = RespuestasOutlook.GetAplicarFondosTemasMensajes();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            return;
                        }
                    }
                    await context.PostAsync($"Quizás desea saber como aplicar un tema a mensajes de correo, tengo esto: ");
                    reply.Attachments = RespuestasOutlook.GetAplicarFondosTemasMensajes();
                    await context.PostAsync(reply);
                    await context.PostAsync($"Caso contrario, la pregunta no se encuentra registrada o vuelva a escribir correctamente la pregunta.");
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