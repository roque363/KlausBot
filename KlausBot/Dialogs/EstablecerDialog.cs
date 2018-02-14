using System;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Threading.Tasks;
using System.Collections.Generic;
using KlausBot.Models;
using KlausBot.Util;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Builder.Dialogs;

namespace KlausBot.Dialogs
{
    public class EstablecerDialog
    {
        private IDialogContext context;
        private LuisResult result;

        public EstablecerDialog(IDialogContext context, LuisResult result)
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
            var accion = "Establecer";
            context.PrivateConversationData.SetValue<string>("Accion", accion);

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
                // -------------------------------------------------------------------
                if (palabra1 == "aviso" || palabra1 == "avisos")
                {
                    reply.Attachments = RespuestasOutlook.GetEstablecerAvisoOutlook();
                    await context.PostAsync(confirmacionRespuesta1);
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    return;
                }
                // -------------------------------------------------------------------
                else if (palabra1 == "márgen" || palabra1 == "márgenes" || palabra1 == "margen" || palabra1 == "margenes")
                {
                    // Se detectó la segunda parte de la pregunta
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");
                        if (palabra2 == "página" || palabra2 == "pagina" || palabra2 == "páginas" || palabra2 == "paginas")
                        {
                            reply.Attachments = RespuestasWord.GetEstablecerMargenesPaginaWord();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = RespuestasWord.GetEstablecerMargenesPaginaWord();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = RespuestasWord.GetEstablecerMargenesPaginaWord();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    return;
                }
                // -------------------------------------------------------------------
                else if (palabra1 == "tabulación" || palabra1 == "tabulacion" || palabra1 == "tabulaciones")
                {
                    reply.Attachments = RespuestasWord.GetEstablecerDesactivarQuitarTabulaciones();
                    await context.PostAsync(confirmacionRespuesta1);
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    return;
                }
                // -------------------------------------------------------------------
                else if (palabra1 == "regla" || palabra1 == "reglas")
                {
                    // Se detectó la segunda parte de la pregunta
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");
                        if (palabra2 == "combinación" || palabra2 == "combinacion" || palabra2 == "combinaciones")
                        {
                            reply.Attachments = RespuestasWord.GetEstablecerReglasCombinacionCorrespondencia();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = RespuestasWord.GetEstablecerReglasCombinacionCorrespondencia();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = RespuestasWord.GetEstablecerReglasCombinacionCorrespondencia();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    return;
                }
                // -------------------------------------------------------------------
                else
                {
                    reply.Attachments = RespuestasOutlook.GetEstablecerAvisoOutlook();
                    await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra1}'?");
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta2);
                    return;
                }
            }
            // No se detectó la primera parte de la pregunta
            await context.PostAsync(preguntaNoRegistrada2);
            reply.Attachments = Respuestas.GetConsultaV2();
            await context.PostAsync(reply);
            await context.PostAsync("O tal vez no escribió la pregunta correctamente");
            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta2);
            return;
        }
    }
}