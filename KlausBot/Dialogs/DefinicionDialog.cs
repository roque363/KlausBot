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
    public class DefinicionDialog
    {
        private IDialogContext context; 
        private LuisResult result;

        public DefinicionDialog(IDialogContext context, LuisResult result)
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
            var accion = "Definicion";
            context.PrivateConversationData.SetValue<string>("Accion", accion);

            var estadoRespuesta = "True";

            string confirmacionRespuesta1 = "Tengo esta respuesta para usted:";
            string confirmacionRespuesta2 = "Tengo estas respuestas para usted:";
            string preguntaNoRegistrada1 = "Lo siento, su pregunta no esta registrada, tal vez no escribió la pregunta correctamente";
            string preguntaNoRegistrada2 = "Lo siento, su pregunta no esta registrada";
            string opcionSecundarioDeRespuesta1 = "Pero esta respuesta le podría interesar:";
            string opcionSecundarioDeRespuesta2 = "Pero estas respuestas le podrían interesar:";
            string preguntaConsulta = "si tiene otra consulta por favor hágamelo saber";

            foreach (var entityP1 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra1"))
            {
                var palabra1 = entityP1.Entity.ToLower().Replace(" ", "");
                context.PrivateConversationData.SetValue<string>("Palabra1", palabra1);
                // -------------------------------------------------------------------
                if (palabra1 == "archivodepetición" || palabra1 == "archivodepeticion")
                {
                    reply.Attachments = RespuestasOneDrive.GetDefinicionArchivoPeticion();
                    await context.PostAsync(confirmacionRespuesta1);
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                    return;
                }
                else if (palabra1 == "plan" || palabra1 == "planes" || palabra1 == "precio" || palabra1 == "precios")
                {
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");
                        if (palabra2 == "almacenamiento" || palabra2 == "almacenamientos")
                        {
                            foreach (var entityP3 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra3"))
                            {
                                var palabra3 = entityP3.Entity.ToLower().Replace(" ", "");
                                if (palabra3 == "región" || palabra3 == "regiones" || palabra3 == "país" || palabra3 == "paises")
                                {
                                    reply.Attachments = RespuestasOneDrive.GetPlanesAlmacenamientoPaisOneDrive();
                                    await context.PostAsync(confirmacionRespuesta1);
                                    await context.PostAsync(reply);
                                    await context.PostAsync(preguntaConsulta);
                                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                                    context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                                    return;
                                }
                                else
                                {
                                    reply.Attachments = RespuestasOneDrive.GetPlanesAlmacenamientoPaisOneDrive();
                                    await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                                    await context.PostAsync(reply);
                                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                                    return;
                                }
                            }
                            reply.Attachments = RespuestasOneDrive.GetPlanesAlmacenamientoPaisOneDrive();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = RespuestasOneDrive.GetPlanesAlmacenamientoPaisOneDrive();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = RespuestasOneDrive.GetPlanesAlmacenamientoPaisOneDrive();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    return;
                }
                else if (palabra1 == "formatos" || palabra1 == "formato")
                {
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");
                        if (palabra2 == "videos" || palabra2 == "video")
                        {
                            reply.Attachments = RespuestasOneDrive.GetFormatoVideoPermitidosOneDrive();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = RespuestasOneDrive.GetFormatoVideoPermitidosOneDrive();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    return;
                }
                else if (palabra1 == "requisitos" || palabra1 == "requesito")
                {
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");
                        if (palabra2 == "sistema" || palabra2 == "equipo")
                        {
                            reply.Attachments = RespuestasOneDrive.GetRequisitosSistemaOneDrive();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = RespuestasOneDrive.GetRequisitosSistemaOneDrive();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    return;
                }
                else if (palabra1 == "firma" || palabra1 == "firmas")
                {
                    reply.Attachments = Respuestas.GetDefinicionFirmaDigital();
                    await context.PostAsync(confirmacionRespuesta1);
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                    return;
                }
                else
                {
                    await context.PostAsync(preguntaNoRegistrada2);
                    await context.PostAsync($"O tal vez no escribió correctamente la palabra '{palabra1}'?");
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    return;
                }
            }
            // Obtener el producto si este fue elegido de forma explicita
            foreach (var entity in result.Entities.Where(Entity => Entity.Type == "Servicio"))
            {
                var value = entity.Entity.ToLower().Replace(" ", "");

                if (value == "outlook" || value == "outlok")
                {
                    reply.Attachments = RespuestasOutlook.GetOutlookDefinicion();
                    await context.PostAsync(confirmacionRespuesta1);
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                    context.PrivateConversationData.SetValue<string>("tipoServicio", "Outlook");
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                    return;
                }
                else if (value == "onedrive" || value == "One Drive" || value == "OneDrive")
                {
                    reply.Attachments = RespuestasOneDrive.GetOneDriveDefinicion();
                    await context.PostAsync(confirmacionRespuesta1);
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                    return;
                }
                else if (value == "excel")
                {
                    reply.Attachments = RespuestasExcel.GetExcelDefinicionCard();
                    await context.PostAsync(confirmacionRespuesta1);
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                    return;
                }
                else if (value == "powerpoint" || value == "power point")
                {
                    reply.Attachments = RespuestasPowerPoint.GetPowerPointDefinicionCard();
                    await context.PostAsync(confirmacionRespuesta1);
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                    return;
                }
                else if (value == "word")
                {
                    reply.Attachments = RespuestasWord.GetWordDefinicionCard();
                    await context.PostAsync(confirmacionRespuesta1);
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                    return;
                }
                else if (value == "onenote" || value == "OneNote")
                {
                    reply.Attachments = RespuestasOneNote.GetOneNoteDefinicion();
                    await context.PostAsync(confirmacionRespuesta1);
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                    return;
                }
                else
                {
                    await context.PostAsync($"Lo siento, '{value}' no esta registrado como servicio");
                    reply.Attachments = Respuestas.GetConsultaV2();
                    await context.PostAsync(reply);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    return;
                }
            }

            //obtener el producto si este a sido escodigo anteriormente
            var servicio = "Servicio";
            context.PrivateConversationData.TryGetValue<string>("tipoDeServicio", out servicio);
            if (servicio == "Word")
            {
                reply.Attachments = RespuestasWord.GetWordDefinicionCard();
                await context.PostAsync(confirmacionRespuesta1);
                await context.PostAsync(reply);
                await context.PostAsync(preguntaConsulta);
                context.PrivateConversationData.SetValue<string>("tipoServicio", "Word");
                context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                return;
            }
            else if (servicio == "Excel")
            {
                reply.Attachments = RespuestasExcel.GetExcelDefinicionCard();
                await context.PostAsync(confirmacionRespuesta1);
                await context.PostAsync(reply);
                await context.PostAsync(preguntaConsulta);
                context.PrivateConversationData.SetValue<string>("tipoServicio", "Excel");
                context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                return;
            }
            else if (servicio == "Outlook")
            {
                reply.Attachments = RespuestasOutlook.GetOutlookDefinicion();
                await context.PostAsync(confirmacionRespuesta1);
                await context.PostAsync(reply);
                await context.PostAsync(preguntaConsulta);
                context.PrivateConversationData.SetValue<string>("tipoServicio", "Outlook");
                context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                return;
            }
            else if (servicio == "OneDrive")
            {
                reply.Attachments = RespuestasOneDrive.GetOneDriveDefinicion();
                await context.PostAsync(confirmacionRespuesta1);
                await context.PostAsync(reply);
                await context.PostAsync(preguntaConsulta);
                context.PrivateConversationData.SetValue<string>("tipoServicio", "OneDrive");
                context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                return;
            }
            else if (servicio == "PowerPoint")
            {
                reply.Attachments = RespuestasPowerPoint.GetPowerPointDefinicionCard();
                await context.PostAsync(confirmacionRespuesta1);
                await context.PostAsync(reply);
                await context.PostAsync(preguntaConsulta);
                context.PrivateConversationData.SetValue<string>("tipoServicio", "PowerPoint");
                context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta2);
                context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                return;
            }
            else if (servicio == "OneNote")
            {
                reply.Attachments = RespuestasOneNote.GetOneNoteDefinicion();
                await context.PostAsync(confirmacionRespuesta1);
                await context.PostAsync(reply);
                await context.PostAsync(preguntaConsulta);
                context.PrivateConversationData.SetValue<string>("tipoServicio", "OneNote");
                context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                return;
            }
            else
            {
                // Si el usuario no a ingresado la primera parte de la pregunta
                await context.PostAsync("Lo siento, su pregunta no esta registrada");
                reply.Attachments = Respuestas.GetConsultaV2();
                await context.PostAsync(reply);
                await context.PostAsync("O tal vez no escribió la pregunta correctamente");
                context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta2);
                return;
            }
        }
    }
}