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
    public class UsarDialog
    {
        private IDialogContext context;
        private LuisResult result;

        public UsarDialog(IDialogContext context, LuisResult result)
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

            foreach (var entityP1 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra1"))
            {
                var palabra1 = entityP1.Entity.ToLower().Replace(" ", "");
                context.PrivateConversationData.SetValue<string>("Palabra1", palabra1);
                if (palabra1 == "@menciones" || palabra1 == "@" || palabra1 == "@mencion")
                {
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");

                        if (palabra2 == "atención" || palabra2 == "atencion")
                        {
                            reply.Attachments = RespuestasOutlook.GetUsarArrobaLlamarAtencion();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = RespuestasOutlook.GetUsarArrobaLlamarAtencion();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = RespuestasOutlook.GetUsarArrobaLlamarAtencion();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
                    return;
                }
                else if (palabra1 == "asistente")
                {
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");

                        if (palabra2 == "programación" || palabra2 == "programacion")
                        {
                            reply.Attachments = RespuestasOutlook.GetUsarAsistenteProgramacion();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = RespuestasOutlook.GetUsarAsistenteProgramacion();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = RespuestasOutlook.GetUsarAsistenteProgramacion();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
                    return;
                }
                else if (palabra1 == "calendarios" || palabra1 == "calendario")
                {
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");

                        if (palabra2 == "adecuada" || palabra2 == "recomendados" || palabra2 == "mejorforma" || palabra2 == "adecuadas")
                        {
                            reply.Attachments = RespuestasOutlook.GetUsarCalendarioManeraAdecuadaOutlook();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = RespuestasOutlook.GetUsarCalendarioManeraAdecuadaOutlook();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = RespuestasOutlook.GetUsarCalendarioManeraAdecuadaOutlook();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
                    return;
                }
                else if (palabra1 == "carpeta" || palabra1 == "carpetas")
                {
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");

                        if (palabra2 == "busqueda" || palabra2 == "búsqueda" || palabra2 == "busquedas" || palabra2 == "búsquedas")
                        {
                            reply.Attachments = RespuestasOutlook.GetUsarCrearCarpetasBusqueda();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = RespuestasOutlook.GetUsarCrearCarpetasBusqueda();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = RespuestasOutlook.GetUsarCrearCarpetasBusqueda();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
                    return;
                }
                else if (palabra1 == "filtros" || palabra1 == "filtro")
                {
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");

                        if (palabra2 == "detestable" || palabra2 == "detestables" || palabra2 == "nodeseado" || palabra2 == "nodeseados")
                        {
                            foreach (var entityP3 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra3"))
                            {
                                var palabra3 = entityP3.Entity.ToLower().Replace(" ", "");

                                if (palabra3 == "mensajes" || palabra3 == "mensaje" || palabra3 == "correo" || palabra3 == "correos")
                                {
                                    reply.Attachments = RespuestasOutlook.GetUsarFiltrosCorreoNoDeseadoControlarMensajes();
                                    await context.PostAsync(confirmacionRespuesta1);
                                    await context.PostAsync(reply);
                                    await context.PostAsync(preguntaConsulta);
                                    return;
                                }
                                else
                                {
                                    reply.Attachments = RespuestasOutlook.GetUsarFiltrosCorreoNoDeseadoControlarMensajes();
                                    await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra3}'?");
                                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                                    await context.PostAsync(reply);
                                    return;
                                }
                            }
                            reply.Attachments = RespuestasOutlook.GetUsarFiltrosCorreoNoDeseadoControlarMensajes();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = RespuestasOutlook.GetUsarFiltrosCorreoNoDeseadoControlarMensajes();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = RespuestasOutlook.GetUsarFiltrosCorreoNoDeseadoControlarMensajes();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
                    return;
                }
                else if (palabra1 == "limpieza")
                {
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");

                        if (palabra2 == "conversación" || palabra2 == "conversaciones" || palabra2 == "charla" || palabra2 == "charlas")
                        {
                            reply.Attachments = RespuestasOutlook.GetUsarLimpiezaConversacion();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = RespuestasOutlook.GetUsarLimpiezaConversacion();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = RespuestasOutlook.GetUsarLimpiezaConversacion();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
                    return;
                }
                else if (palabra1 == "correos" || palabra1 == "correo")
                {
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");

                        if (palabra2 == "mensajes" || palabra2 == "mensaje")
                        {
                            reply.Attachments = RespuestasOutlook.GetUsarCorreosOrganizarBajaPrioridad();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = RespuestasOutlook.GetUsarCorreosOrganizarBajaPrioridad();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = RespuestasOutlook.GetUsarCorreosOrganizarBajaPrioridad();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
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
            foreach (var serv in result.Entities.Where(Entity => Entity.Type == "Servicio"))
            {
                var servicioU = serv.Entity.ToLower().Replace(" ", "");
                if (servicioU == "onedrive")
                {
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");
                        if (palabra2 == "windowsphone")
                        {
                            reply.Attachments = RespuestasOneDrive.GetUsarOneDriveEmpresaOneDriveWindowsPhone();
                            await context.PostAsync(preguntaNoRegistrada1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            return;
                        }
                        else if (palabra2 == "android")
                        {
                            reply.Attachments = RespuestasOneDrive.GetUsarOneDriveAndroid();
                            await context.PostAsync(preguntaNoRegistrada1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            return;
                        }
                        else if (palabra2 == "ios")
                        {
                            reply.Attachments = RespuestasOneDrive.GetUsarOneDriveEmpresaOneDriveIos();
                            await context.PostAsync(preguntaNoRegistrada1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = RespuestasOneDrive.GetUsarOneDrive();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = RespuestasOneDrive.GetUsarOneDrive();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
                    return;
                }
                else
                {
                    await context.PostAsync($"Lo siento, su pregunta no esta registrada");
                    await context.PostAsync($"O tal vez no la escribió correctamente, ¿{servicioU}?");
                    return;
                }
            }
            //obtener el producto si este a sido escodigo anteriormente
            var servicio = "Servicio";
            context.PrivateConversationData.TryGetValue<string>("tipoDeServicio", out servicio);
            if (servicio == "OneDrive")
            {
                foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                {
                    var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");
                    if (palabra2 == "windowsphone")
                    {
                        reply.Attachments = RespuestasOneDrive.GetUsarOneDriveEmpresaOneDriveWindowsPhone();
                        await context.PostAsync(preguntaNoRegistrada1);
                        await context.PostAsync(reply);
                        await context.PostAsync(preguntaConsulta);
                        return;
                    }
                    else if (palabra2 == "android")
                    {
                        reply.Attachments = RespuestasOneDrive.GetUsarOneDriveAndroid();
                        await context.PostAsync(preguntaNoRegistrada1);
                        await context.PostAsync(reply);
                        await context.PostAsync(preguntaConsulta);
                        return;
                    }
                    else if (palabra2 == "ios")
                    {
                        reply.Attachments = RespuestasOneDrive.GetUsarOneDriveEmpresaOneDriveIos();
                        await context.PostAsync(preguntaNoRegistrada1);
                        await context.PostAsync(reply);
                        await context.PostAsync(preguntaConsulta);
                        return;
                    }
                    else
                    {
                        reply.Attachments = RespuestasOneDrive.GetUsarOneDrive();
                        await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                        await context.PostAsync(opcionSecundarioDeRespuesta1);
                        await context.PostAsync(reply);
                        return;
                    }
                }
                // No se detectó la segunda parte de la pregunta
                reply.Attachments = RespuestasOneDrive.GetUsarOneDrive();
                await context.PostAsync(preguntaNoRegistrada1);
                await context.PostAsync(opcionSecundarioDeRespuesta1);
                await context.PostAsync(reply);
                return;
            }
            else
            {
                // Si el usuario no ingreso la primera parte de la pregunta
                await context.PostAsync(preguntaNoRegistrada2);
                reply.Attachments = Respuestas.GetConsultaV2();
                await context.PostAsync(reply);
                await context.PostAsync("O tal vez no escribió la pregunta correctamente");
                return;
            }
        }
    }
}