﻿using System;
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
    public class RevisarDialog
    {
        private IDialogContext context;
        private LuisResult result;

        public RevisarDialog(IDialogContext context, LuisResult result)
        {
            this.context = context;
            this.result = result;
        }

        public async Task StartAsync()
        {
            var reply = context.MakeMessage();
            reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;

            var estadoPregunta = "True";
            var estadoPregunta2 = "False";
            var accion = "Revisar";
            context.PrivateConversationData.SetValue<string>("Accion", accion);

            var estadoRespuesta = "True";
            var estadoRespuesta2 = "False";

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
                // Se guarda la primera parte de la pregunta
                context.PrivateConversationData.SetValue<string>("Palabra1", palabra1);
                // -------------------------------------------------------------------
                if (palabra1 == "ortografia" || palabra1 == "ortografía")
                {
                    // Se detectó el Servico de la pregunta
                    foreach (var serv in result.Entities.Where(Entity => Entity.Type == "Servicio"))
                    {
                        var servicio1 = serv.Entity.ToLower().Replace(" ", "");
                        if (servicio1 == "onenote" || servicio1 == "OneNote")
                        {
                            reply.Attachments = RespuestasOneNote.GetRevisarOrtografiAOneNote();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else if (servicio1 == "word" || servicio1 == "excel" || servicio1 == "powerpoint" || servicio1 == "outlook" || servicio1 == "office")
                        {
                            reply.Attachments = Respuestas.GetRevisarOrtografiaOffice();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = Respuestas.GetRevisarOrtografiaOffice();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente el servicio '{servicio1}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                        }
                    }
                    // No se detectó el Servicio de la pregunta
                    // Se obtiene el servicio que esta guardado en cache
                    var servicio = "Servicio";
                    context.PrivateConversationData.TryGetValue<string>("tipoServicio", out servicio);
                    if (servicio == "OneNote" || servicio == "onenote")
                    {
                        reply.Attachments = RespuestasOneNote.GetRevisarOrtografiAOneNote();
                        await context.PostAsync(confirmacionRespuesta1);
                        await context.PostAsync(reply);
                        await context.PostAsync(preguntaConsulta);
                        context.PrivateConversationData.SetValue<string>("tipoServicio", "Servicio");
                        context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                        context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                        return;
                    }
                    else
                    {
                        reply.Attachments = Respuestas.GetRevisarOrtografiaOffice();
                        await context.PostAsync(preguntaNoRegistrada1);
                        await context.PostAsync(opcionSecundarioDeRespuesta1);
                        await context.PostAsync(reply);
                        context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                        return;
                    }
                }
                else
                {
                    await context.PostAsync(preguntaNoRegistrada2);
                    await context.PostAsync($"O tal vez no escribió correctamente la palabra '{palabra1}'?");
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta2);
                    context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta2);
                    return;
                }
            }
            // No se detectó la primera parte de la pregunta
            await context.PostAsync(preguntaNoRegistrada2);
            reply.Attachments = Respuestas.GetConsultaV2();
            await context.PostAsync(reply);
            await context.PostAsync("O tal vez no escribió la pregunta correctamente");
            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta2);
            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta2);
            return;
        }
    }
}