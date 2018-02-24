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
    public class BuscarDialog
    {
        private IDialogContext context;
        private LuisResult result;

        public BuscarDialog(IDialogContext context, LuisResult result)
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
            var accion= "Buscar";
            context.PrivateConversationData.SetValue<string>("Accion", accion);

            var estadoRespuesta = "True";
            var estadoRespuesta2 = "False";

            string confirmacionRespuesta1 = "Tengo esta respuesta para usted:";
            string confirmacionRespuesta2 = "Tengo estas respuestas para usted:";
            string preguntaNoRegistrada1 = "Lo siento, su pregunta no esta registrada, tal vez no escribió la pregunta correctamente";
            string preguntaNoRegistrada2 = "Lo siento, su pregunta no esta registrada";
            string opcionSecundarioDeRespuesta1 = "Pero esta respuesta le podría interesar:";
            string opcionSecundarioDeRespuesta2 = "Pero estas respuestas le podrían interesar:";
            string preguntaConsulta2 = "si necesita más información por favor hágamelo saber";
            string preguntaConsulta = "si tiene otra consulta por favor hágamelo saber"; 

            // Recorrido de la primera parte de la pregunta
            foreach (var entityP1 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra1"))
            {
                var palabra1 = entityP1.Entity.ToLower().Replace(" ", "");
                context.PrivateConversationData.SetValue<string>("Palabra1", palabra1);
                // -------------------------------------------------------------------
                if (palabra1 == "personas" || palabra1 == "persona" || palabra1 == "contactos" || palabra1 == "contacto")
                {
                    reply.Attachments = RespuestasOutlook.GetBuscarPersonasOutlook();
                    await context.PostAsync(confirmacionRespuesta1);
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                    return;
                }
                // -------------------------------------------------------------------
                else if (palabra1 == "mensajes" || palabra1 == "mensaje")
                {
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");
                        if (palabra2 == "busquedainstantanea" || palabra2 == "búsquedainstantánea" || palabra2 == "búsquedainstantanea" || palabra2 == "busquedainstantánea" || palabra2 == "búsqueda" || palabra2 == "busqueda")
                        {
                            reply.Attachments = RespuestasOutlook.GetBuscarMensajeBusquedaInstantanea();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = RespuestasOutlook.GetBuscarMensajeBusquedaInstantanea();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = RespuestasOutlook.GetBuscarMensajeBusquedaInstantanea();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    return;
                }
                // -------------------------------------------------------------------
                else if (palabra1 == "elementos" || palabra1 == "elemento")
                {
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");
                        if (palabra2 == "archivos" || palabra2 == "archivo")
                        {
                            reply.Attachments = RespuestasOutlook.GetBuscarElementosArchivosDatos();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = RespuestasOutlook.GetBuscarElementosArchivosDatos();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = RespuestasOutlook.GetBuscarElementosArchivosDatos();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    return;
                }
                // -------------------------------------------------------------------
                else if (palabra1 == "archivos" || palabra1 == "archivo")
                {
                    foreach (var servicio in result.Entities.Where(Entity => Entity.Type == "Servicio"))
                    {
                        var serv = servicio.Entity.ToLower().Replace(" ", "");
                        if (serv == "onedrive")
                        {
                            foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                            {
                                var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");
                                if (palabra2 == "ios")
                                {
                                    reply.Attachments = RespuestasOneDrive.GetBuscarTrabajarArchivosOneDriveIos();
                                    await context.PostAsync(confirmacionRespuesta1);
                                    await context.PostAsync(reply);
                                    await context.PostAsync(preguntaConsulta);
                                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                                    context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                                    return;
                                }
                                else if (palabra2 == "android")
                                {
                                    reply.Attachments = RespuestasOneDrive.GetBuscarTrabajarArchivosOneDriveAndroid();
                                    await context.PostAsync(confirmacionRespuesta1);
                                    await context.PostAsync(reply);
                                    await context.PostAsync(preguntaConsulta);
                                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                                    context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                                    return;
                                }
                                else if (palabra2 == "windowsphone")
                                {
                                    reply.Attachments = RespuestasOneDrive.GetBuscarTrabajarArchivosOneDriveWindowsPhone();
                                    await context.PostAsync(confirmacionRespuesta1);
                                    await context.PostAsync(reply);
                                    await context.PostAsync(preguntaConsulta);
                                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                                    context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                                    return;
                                }
                                else if (palabra2 == "sharepoint")
                                {
                                    reply.Attachments = RespuestasOneDrive.GetBuscarArchivosSharePointOneDrive();
                                    await context.PostAsync(confirmacionRespuesta1);
                                    await context.PostAsync(reply);
                                    await context.PostAsync(preguntaConsulta);
                                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                                    context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                                    return;
                                }
                                else
                                {
                                    reply.Attachments = RespuestasOneDrive.GetBuscarTrabajarArchivosOneDriveAndroid();
                                    await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                                    await context.PostAsync(reply);
                                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                                    return;
                                }
                            }
                            reply.Attachments = RespuestasOneDrive.GetBuscarOMoverArchivosOneDrive();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else if (serv == "outlook")
                        {
                            foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                            {
                                var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");
                                if (palabra2 == "datos" || palabra2 == "dato")
                                {
                                    reply.Attachments = RespuestasOutlook.GetBuscarArchivosDatosOutlook();
                                    await context.PostAsync(confirmacionRespuesta1);
                                    await context.PostAsync(reply);
                                    await context.PostAsync(preguntaConsulta);
                                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                                    context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                                    return;
                                }
                                else
                                {
                                    reply.Attachments = RespuestasOutlook.GetBuscarArchivosDatosOutlook();
                                    await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                                    await context.PostAsync(reply);
                                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                                    return;
                                }
                            }
                            reply.Attachments = RespuestasOutlook.GetBuscarArchivosDatosOutlook();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = RespuestasOneDrive.GetBuscarTrabajarArchivosOneDriveAndroid();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{serv}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                        }
                    }
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");
                        if (palabra2 == "datos" || palabra2 == "dato")
                        {
                            reply.Attachments = RespuestasOutlook.GetBuscarArchivosDatosOutlook();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else if (palabra2 == "sharepoint")
                        {
                            reply.Attachments = RespuestasOneDrive.GetBuscarArchivosSharePointOneDrive();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = RespuestasOutlook.GetBuscarArchivosDatosOutlook();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                        }
                    }
                    reply.Attachments = RespuestasOneDrive.GetBuscarArchivosOneDriveBuscarArchivosDatosOutlook();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta2);
                    await context.PostAsync(reply);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    return;
                }
                // -------------------------------------------------------------------
                else if (palabra1 == "referencias" || palabra1 == "referencia")
                {
                    // Se detectó el Servico de la pregunta
                    foreach (var serv in result.Entities.Where(Entity => Entity.Type == "Servicio"))
                    {
                        var servicioU = serv.Entity.ToLower().Replace(" ", "");
                        if (servicioU == "onenote" || servicioU == "OneNote")
                        {
                            reply.Attachments = RespuestasOneNote.GetBuscarReferenciasFacilmenteOneNote();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = RespuestasOneNote.GetBuscarReferenciasFacilmenteOneNote();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{servicioU}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                        }
                    }
                    // No se detectó el Servico de la pregunta
                    reply.Attachments = RespuestasOneNote.GetBuscarReferenciasFacilmenteOneNote();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    return;
                }
                // -------------------------------------------------------------------
                else if (palabra1 == "nota" || palabra1 == "notas")
                {
                    // Se detectó el Servico de la pregunta
                    foreach (var serv in result.Entities.Where(Entity => Entity.Type == "Servicio"))
                    {
                        var servicioU = serv.Entity.ToLower().Replace(" ", "");
                        if (servicioU == "onenote" || servicioU == "OneNote")
                        {
                            reply.Attachments = RespuestasOneNote.GetBuscarNotasOneNote();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = RespuestasOneNote.GetBuscarNotasOneNote();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{servicioU}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                        }
                    }
                    //obtener el producto si este a sido escodigo anteriormente
                    var servicio = "Servicio";
                    context.PrivateConversationData.TryGetValue<string>("tipoServicio", out servicio);
                    if (servicio == "OneNote" )
                    {
                        reply.Attachments = RespuestasOneNote.GetBuscarNotasOneNote();
                        await context.PostAsync(confirmacionRespuesta1);
                        await context.PostAsync(reply);
                        await context.PostAsync(preguntaConsulta);
                        context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                        return;
                    }
                    else
                    {
                        // No se detectó la segunda parte de la pregunta
                        reply.Attachments = RespuestasOneNote.GetBuscarNotasOneNote();
                        await context.PostAsync(preguntaNoRegistrada1);
                        await context.PostAsync(opcionSecundarioDeRespuesta1);
                        await context.PostAsync(reply);
                        await context.PostAsync(preguntaConsulta);
                        context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                        context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                        return;
                    }
                }
                else if (palabra1 == "fotos" || palabra1 == "foto")
                {
                    reply.Attachments = RespuestasOneDrive.GetOrganizarBuscarFotosOneDrive();
                    await context.PostAsync(confirmacionRespuesta1);
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                    return;
                }
                else if (palabra1 == "regla")
                {
                    reply.Attachments = RespuestasWord.GetMostrarOcultarReglaWord();
                    await context.PostAsync(confirmacionRespuesta1);
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                    return;
                }
                else if (palabra1 == "texto" || palabra1 == "texto" || palabra1 == "datos" || palabra1 == "dato")
                {
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");
                        if (palabra2 == "documentos" || palabra2 == "documento" || palabra2 == "archivo" || palabra2 == "archivos")
                        {
                            reply.Attachments = RespuestasWord.GetBuscarReemplazarTextoDatosDocumentoWord();
                            await context.PostAsync(confirmacionRespuesta2);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else if (palabra2 == "hoja" || palabra2 == "hojas")
                        {
                            reply.Attachments = RespuestasExcel.GetBuscarTextoNumerosHojaCalculo();
                            await context.PostAsync(confirmacionRespuesta2);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = RespuestasWord.GetBuscarReemplazarTextoDatosDocumentoWord();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta2);
                            await context.PostAsync(reply);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    // Se detecto el Servicio de la pregunta
                    foreach (var serv in result.Entities.Where(Entity => Entity.Type == "Servicio"))
                    {
                        var servicio1 = serv.Entity.ToLower().Replace(" ", "");

                        if (servicio1 == "word")
                        {
                            reply.Attachments = RespuestasWord.GetBuscarReemplazarTextoDatosDocumentoWord();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("tipoServicio", "Word");
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else if (servicio1 == "excel")
                        {
                            reply.Attachments = RespuestasExcel.GetBuscarTextoNumerosHojaCalculo();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("tipoServicio", "Excel");
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = RespuestasWord.GetBuscarReemplazarTextoDatosDocumentoWord();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, no se encuentra el servicio '{servicio1}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                        }
                    }
                    //obtener el producto si este a sido escodigo anteriormente
                    var servicio = "Servicio";
                    context.PrivateConversationData.TryGetValue<string>("tipoServicio", out servicio);
                    if (servicio == "Word" || servicio == "Outlook")
                    {
                        reply.Attachments = RespuestasWord.GetBuscarReemplazarTextoDatosDocumentoWord();
                        await context.PostAsync(confirmacionRespuesta1);
                        await context.PostAsync(reply);
                        await context.PostAsync(preguntaConsulta);
                        context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                        context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                        return;
                    }
                    else if (servicio == "Excel")
                    {
                        reply.Attachments = RespuestasExcel.GetBuscarTextoNumerosHojaCalculo();
                        await context.PostAsync(confirmacionRespuesta1);
                        await context.PostAsync(reply);
                        await context.PostAsync(preguntaConsulta);
                        context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                        context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                        return;
                    }
                    else
                    {
                        reply.Attachments = RespuestasWord.GetBuscarReemplazarTextoDatosDocumentoWord();
                        await context.PostAsync(preguntaNoRegistrada1);
                        await context.PostAsync(opcionSecundarioDeRespuesta1);
                        await context.PostAsync(reply);
                        await context.PostAsync(preguntaConsulta);
                        context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                        context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                        return;
                    }
                }
                else if (palabra1 == "vínculo" || palabra1 == "vínculos" || palabra1 == "vinculo" || palabra1 == "vinculos")
                {
                    reply.Attachments = RespuestasExcel.GetBuscarVinculosLibro();
                    await context.PostAsync(confirmacionRespuesta1);
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                    return;
                }
                else if (palabra1 == "referencia" || palabra1 == "referencias")
                {
                    reply.Attachments = RespuestasExcel.GetBuscarVinculosLibro();
                    await context.PostAsync(confirmacionRespuesta1);
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                    return;
                }
                else if (palabra1 == "celdas" || palabra1 == "celda")
                {
                    reply.Attachments = RespuestasExcel.GetBuscarCeldasOcultasHoja();
                    await context.PostAsync(confirmacionRespuesta1);
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                    return;
                }
                else if (palabra1 == "duplicado" || palabra1 == "duplicados")
                {
                    reply.Attachments = RespuestasExcel.GetBuscarDuplicadosExcel();
                    await context.PostAsync(confirmacionRespuesta1);
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                    return;
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