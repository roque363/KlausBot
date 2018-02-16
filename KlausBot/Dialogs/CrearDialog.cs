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
    public class CrearDialog
    {
        private IDialogContext context;
        private LuisResult result;

        public CrearDialog(IDialogContext context, LuisResult result)
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
            var accion = "Crear";
            context.PrivateConversationData.SetValue<string>("Accion", accion);

            var estadoRespuesta = "True";

            string confirmacionRespuesta1 = "Tengo esta respuesta para usted:";
            string confirmacionRespuesta2 = "Tengo estas respuestas para usted:";
            string preguntaNoRegistrada1 = "Lo siento, su pregunta no esta registrada, tal vez no escribió la pregunta correctamente";
            string preguntaNoRegistrada2 = "Lo siento, su pregunta no esta registrada";
            string opcionSecundarioDeRespuesta1 = "Pero esta respuesta le podría interesar:";
            string opcionSecundarioDeRespuesta2 = "Pero estas respuestas le podrían interesar:";
            string preguntaConsulta = "si tiene otra consulta por favor hágamelo saber";

            // Se detectó la primera parte de la pregunta
            foreach (var entityP1 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra1"))
            {
                var palabra1 = entityP1.Entity.ToLower().Replace(" ", "");
                context.PrivateConversationData.SetValue<string>("Palabra1", palabra1);
                // -------------------------------------------------------------------
                // La primera parte de la pregunta es firma 
                if (palabra1 == "firma" || palabra1 == "firmas")
                {
                    // Se detectó  la segunda parte de la pregunta
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");

                        // La segunda parte de la prgunta es mensaje o correo
                        if (palabra2 == "mensaje" || palabra2 == "mensajes" || palabra2 == "correo" || palabra2 == "correos")
                        {
                            reply.Attachments = RespuestasOutlook.GetCrearFirmaMensaje();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = RespuestasOutlook.GetCrearFirmaMensaje();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = RespuestasOutlook.GetCrearFirmaMensaje();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    return;
                }
                // -------------------------------------------------------------------
                // La primera parte de la pregunta es categorías
                else if (palabra1 == "categoría" || palabra1 == "categoria" || palabra1 == "categorías" || palabra1 == "categorias")
                {
                    // Se detectó la segunda parte de la pregunta
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");
                        // La segunda parte de la pregunta es colores
                        if (palabra2 == "color" || palabra2 == "colores")
                        {
                            reply.Attachments = RespuestasOutlook.GetCrearAsignarCategoriasColor();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = RespuestasOutlook.GetCrearAsignarCategoriasColor();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = RespuestasOutlook.GetCrearAsignarCategoriasColor();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    return;
                }
                // -------------------------------------------------------------------
                // La primera parte de la pregunta es plantilla
                else if (palabra1 == "plantilla" || palabra1 == "plantillas")
                {
                    // Se detectó la segunda parte de la pregunta
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");

                        if (palabra2 == "mensaje" || palabra2 == "mensajes")
                        {
                            await context.PostAsync(confirmacionRespuesta1);
                            reply.Attachments = RespuestasOutlook.GetCrearPlantillaMensajeCorreoElectronico();
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else if (palabra2 == "correo" || palabra2 == "correos")
                        {
                            await context.PostAsync(confirmacionRespuesta1);
                            reply.Attachments = RespuestasOutlook.GetCrearPlantillaCorreoElectronico();
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = RespuestasOutlook.GetCrearPlantillaMensajeCorreoElectronico();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = RespuestasOutlook.GetCrearPlantillaCorreoElectronico();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    return;
                }
                // -------------------------------------------------------------------
                // La primera parte de la pregunta es carpetas
                else if (palabra1 == "carpeta" || palabra1 == "carpetas")
                {
                    // Se detectó el Servicio de la pregunta
                    foreach (var entity in result.Entities.Where(Entity => Entity.Type == "Servicio"))
                    {
                        var serv = entity.Entity.ToLower().Replace(" ", "");
                        if (serv == "outlook" || serv == "outlok")
                        {
                            reply.Attachments = RespuestasOutlook.GetUsarCrearCarpetasBusqueda();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else if (serv == "onedrive")
                        {
                            reply.Attachments = RespuestasOneDrive.GetCrearArchivosCarpetasOneDrive();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = RespuestasOutlook.GetCrearCambiarPersonalizarVista();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{serv}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                        }
                    }
                    // Se detectó la segunda parte de la pregunta
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");
                        // La segunda parte de la pregunta es busqueda
                        if (palabra2 == "busqueda" || palabra2 == "busquedas" || palabra2 == "búsquedas" || palabra2 == "búsqueda")
                        {
                            await context.PostAsync(confirmacionRespuesta1);
                            reply.Attachments = RespuestasOutlook.GetUsarCrearCarpetasBusqueda();
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = RespuestasOutlook.GetUsarCrearCarpetasBusqueda();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = RespuestasOutlook.GetUsarCrearCarpetasBusqueda();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    return;
                }
                // -------------------------------------------------------------------
                // La primera parte de la pregunta es tarea
                else if (palabra1 == "tarea" || palabra1 == "tareas")
                {
                    // Se detectó la tercera parte de la pregunta
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra3"))
                    {
                        var palabra3 = entityP2.Entity.ToLower().Replace(" ", "");
                        // La segunda parte de la pregunta es colores
                        if (palabra3 == "mensaje" || palabra3 == "mensajes" || palabra3 == "correo" || palabra3 == "correos")
                        {
                            await context.PostAsync(confirmacionRespuesta1);
                            reply.Attachments = RespuestasOutlook.GetCrearTareaAPartirMensaje();
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = RespuestasOutlook.GetCrearTareaYAPartirDeMensaje();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra3}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta2);
                            await context.PostAsync(reply);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = RespuestasOutlook.GetCrearTareaYAPartirDeMensaje();
                    await context.PostAsync(confirmacionRespuesta2);
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                    return;
                }
                // -------------------------------------------------------------------
                // La primera parte de la pregunta es grupo
                else if (palabra1 == "grupo" || palabra1 == "grupos")
                {
                    // Se detectó la segunda parte de la pregunta
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");
                        // La segunda parte de la pregunta es contactos
                        if (palabra2 == "contactos" || palabra2 == "contacto")
                        {
                            await context.PostAsync(confirmacionRespuesta1);
                            reply.Attachments = RespuestasOutlook.GetCrearGrupoContactosListaDistribucionOutlook();
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = RespuestasOutlook.GetCrearGrupoContactosListaDistribucionOutlook();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = RespuestasOutlook.GetCrearGrupoContactosListaDistribucionOutlook();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    return;
                }
                // -------------------------------------------------------------------
                // La primera parte de la pregunta es diseño
                else if (palabra1 == "diseño" || palabra1 == "diseños")
                {
                    // Se detectó la segunda parte de la pregunta
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra3"))
                    {
                        var palabra3 = entityP2.Entity.ToLower().Replace(" ", "");
                        // La segunda parte de la pregunta es colores
                        if (palabra3 == "mensaje" || palabra3 == "mensajes" || palabra3 == "correo" || palabra3 == "correos")
                        {
                            reply.Attachments = RespuestasOutlook.GetCrearDiseñosDePlantillaParaMensajesV2();
                            await context.PostAsync(confirmacionRespuesta2);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = RespuestasOutlook.GetCrearDiseñosFondoParaMensajes();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra3}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = RespuestasOutlook.GetCrearDiseñosFondoParaMensajes();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    return;
                }
                // -------------------------------------------------------------------
                // La primera parte de la pregunta es archivo
                else if (palabra1 == "archivos" || palabra1 == "archivo")
                {
                    // Se detectó el servicio de la pregunta
                    foreach (var serv in result.Entities.Where(Entity => Entity.Type == "Servicio"))
                    {
                        var servicioU = serv.Entity.ToLower().Replace(" ", "");
                        // El servicio de la pregunta es word
                        if (servicioU == "word" || servicioU == "Word")
                        {
                                reply.Attachments = RespuestasWord.GetCrearDocumentoWord();
                                await context.PostAsync(confirmacionRespuesta1);
                                await context.PostAsync(reply);
                                await context.PostAsync(preguntaConsulta);
                                context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else if(servicioU == "onedrive" || servicioU == "OneDrive")
                        {
                            reply.Attachments = RespuestasOneDrive.GetCrearArchivosCarpetasOneDrive();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("tipoServicio", "OneDrive");
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = RespuestasOneDrive.GetCrearArchivosCarpetasOneDrive();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{servicioU }'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                        }
                    }
                    // obtener el producto si este a sido escodigo anteriormente
                    var servicio = "Servicio";
                    context.PrivateConversationData.TryGetValue<string>("tipoDeServicio", out servicio);
                    if (servicio == "OneDrive")
                    {
                        reply.Attachments = RespuestasOneDrive.GetCrearArchivosCarpetasOneDrive();
                        await context.PostAsync(confirmacionRespuesta1);
                        await context.PostAsync(reply);
                        await context.PostAsync(preguntaConsulta);
                        context.PrivateConversationData.SetValue<string>("tipoServicio", "Servicio");
                        context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                        context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                        return;
                    }
                    else if (servicio == "Word")
                    {
                        reply.Attachments = RespuestasWord.GetCrearDocumentoWord();
                        await context.PostAsync(confirmacionRespuesta1);
                        await context.PostAsync(reply);
                        await context.PostAsync(preguntaConsulta);
                        context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                        context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                        return;
                    }
                    else
                    {
                        reply.Attachments = RespuestasOneDrive.GetCrearArchivosCarpetasOneDrive();
                        await context.PostAsync($"Lo siento, su pregunta no esta registrada, debe escribir un servicio?");
                        await context.PostAsync(opcionSecundarioDeRespuesta1);
                        await context.PostAsync(reply);
                        context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                        return;
                    }
                }
                // -------------------------------------------------------------------
                // La primera parte de la pregunta es documentos
                else if (palabra1 == "documentos" || palabra1 == "documento")
                {
                    // Se detectó el Servicio de la pregunta
                    foreach (var serv in result.Entities.Where(Entity => Entity.Type == "Servicio"))
                    {
                        var servicio = serv.Entity.ToLower().Replace(" ", "");
                        // La segunda parte de la pregunta es colores
                        if (servicio == "word" || servicio == "Word")
                        {
                            reply.Attachments = RespuestasWord.GetCrearDocumentoWord();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                        }
                        else if (servicio == "onedrive" || servicio == "OneDrive")
                        {
                            reply.Attachments = RespuestasOneDrive.GetCrearDocumentoDesdeOneDrive();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = RespuestasOneDrive.GetCrearArchivosCarpetasOneDrive();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{servicio}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = RespuestasOneDrive.GetCrearDocumentoDesdeOneDrive();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    return;
                }
                // -------------------------------------------------------------------
                // La primera parte de la pregunta es vista
                else if (palabra1 == "evento" || palabra1 == "eventos")
                {
                    await context.PostAsync(confirmacionRespuesta1);
                    reply.Attachments = RespuestasOutlook.GetCrearEventoQueDureTodoDia();
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                    return;
                }
                // -------------------------------------------------------------------
                // La primera parte de la pregunta es bloc de notas
                else if (palabra1 == "blocdenotas" || palabra1 == "nuevoblocdenotas" || palabra1 == "bloc" || palabra1 == "block")
                {
                    // Se detectó el Servicio de la pregunta
                    foreach (var serv in result.Entities.Where(Entity => Entity.Type == "Servicio"))
                    {
                        var servicio1 = serv.Entity.ToLower().Replace(" ", "");
                        // La segunda parte de la pregunta es One Note
                        if (servicio1 == "onenote" || servicio1 == "OneNote" || servicio1 == "One Note" || servicio1 == "one note")
                        {
                            reply.Attachments = RespuestasOneNote.GetCrearBlocNotasOneNote();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("tipoDeServicio", servicio1);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = RespuestasOneNote.GetCrearBlocNotasOneNote();
                            await context.PostAsync($"Lo siento, ese servicio no esta registrado, tal vez no escribió correctamente la palabra '{servicio1}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                        }
                    }
                    // No se detectó el Servicio de la pregunta
                    // Obtener el producto si este a sido escodigo anteriormente
                    var servicio = "Servicio";
                    context.PrivateConversationData.TryGetValue<string>("tipoDeServicio", out servicio);
                    if (servicio == "OneNote")
                    {
                        reply.Attachments = RespuestasOneNote.GetCrearBlocNotasOneNote();
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
                        reply.Attachments = RespuestasOneNote.GetCrearBlocNotasOneNote();
                        await context.PostAsync(confirmacionRespuesta1);
                        await context.PostAsync(reply);
                        await context.PostAsync(preguntaConsulta);
                        context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                        context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                        return;
                    }
                }
                // -------------------------------------------------------------------
                // La primera parte de la pregunta es vinculo
                else if (palabra1 == "vínculo" || palabra1 == "vínculos" || palabra1 == "vinculo" || palabra1 == "vinculos")
                {
                    // Se detectó el Servicio de la pregunta
                    foreach (var serv in result.Entities.Where(Entity => Entity.Type == "Servicio"))
                    {
                        var servicio1 = serv.Entity.ToLower().Replace(" ", "");
                        // La segunda parte de la pregunta es One Note
                        if (servicio1 == "onenote" || servicio1 == "OneNote" || servicio1 == "One Note" || servicio1 == "one note")
                        {
                            reply.Attachments = RespuestasOneNote.GetCrearVinculosOneNote();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("tipoDeServicio", servicio1);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = RespuestasOneNote.GetCrearVinculosOneNote();
                            await context.PostAsync($"Lo siento, ese servicio no esta registrado, tal vez no escribió correctamente la palabra '{servicio1}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                        }
                    }
                    // No se detectó el Servico parte de la pregunta
                    reply.Attachments = RespuestasOneNote.GetCrearVinculosOneNote();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    return;
                }
                // -------------------------------------------------------------------
                // La primera parte de la pregunta es vista
                else if (palabra1 == "vista" || palabra1 == "vistas")
                {
                    await context.PostAsync(confirmacionRespuesta1);
                    reply.Attachments = RespuestasOutlook.GetCrearCambiarPersonalizarVista();
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                    return;
                }
                // -------------------------------------------------------------------
                // La primera parte de la pregunta es correo
                else if (palabra1 == "correo" || palabra1 == "correos" || palabra1 == "mensaje" || palabra1 == "mensajes" || palabra1 == "correoelectronico")
                {
                    reply.Attachments = RespuestasOutlook.GetCrearMensajeCorreoElectronico();
                    await context.PostAsync(confirmacionRespuesta1);
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                    context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    return;
                }
                // -------------------------------------------------------------------
                // La primera parte de la pregunta es correo
                else if (palabra1 == "hipervínculo" || palabra1 == "hipervinculo" || palabra1 == "hipervínculos" || palabra1 == "hipervinculos")
                {
                    reply.Attachments = RespuestasOutlook.GetCrearModificarHipervínculo();
                    await context.PostAsync(confirmacionRespuesta1);
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                    context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    return;
                }
                // -------------------------------------------------------------------
                // La primera parte de la pregunta es cita
                else if (palabra1 == "cita" || palabra1 == "citas")
                {
                    reply.Attachments = RespuestasOutlook.GetCrearProgramarCita();
                    await context.PostAsync(confirmacionRespuesta1);
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                    context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    return;
                }
                // -------------------------------------------------------------------
                // La primera parte de la pregunta es cuenta
                else if (palabra1 == "cuentas" || palabra1 == "cuenta")
                {
                    reply.Attachments = RespuestasOneDrive.GetCrearCuentaOneDrive();
                    await context.PostAsync(confirmacionRespuesta1);
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                    return;
                }
                // -------------------------------------------------------------------
                else if (palabra1 == "sangría" || palabra1 == "sangria" || palabra1 == "sangrías" || palabra1 == "sangrias")
                {
                    foreach (var serv in result.Entities.Where(Entity => Entity.Type == "Servicio"))
                    {
                        var servicio1 = serv.Entity.ToLower().Replace(" ", "");

                        if (servicio1 == "word")
                        {
                            reply.Attachments = RespuestasWord.GetCrearSangria();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = RespuestasWord.GetCrearSangria();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, no se encuentra el servicio '{servicio1}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                    }
                    //obtener el producto si este a sido escodigo anteriormente
                    var servicio = "Servicio";
                    context.PrivateConversationData.TryGetValue<string>("tipoDeServicio", out servicio);
                    if (servicio == "Word" || servicio == "Outlook")
                    {
                        reply.Attachments = RespuestasWord.GetCrearSangria();
                        await context.PostAsync(confirmacionRespuesta1);
                        await context.PostAsync(reply);
                        await context.PostAsync(preguntaConsulta);
                        context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                        return;
                    }
                    else
                    {
                        // No se detectó la segunda parte de la pregunta
                        reply.Attachments = RespuestasWord.GetCrearSangria();
                        await context.PostAsync(preguntaNoRegistrada1);
                        await context.PostAsync(opcionSecundarioDeRespuesta1);
                        await context.PostAsync(reply);
                        await context.PostAsync(preguntaConsulta);
                        context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                        context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                        return;
                    }
                }
                // -------------------------------------------------------------------
                else if (palabra1 == "tabla" || palabra1 == "tablas")
                {
                    foreach (var entity in result.Entities.Where(Entity => Entity.Type == "Servicio"))
                    {
                        var serv = entity.Entity.ToLower().Replace(" ", "");
                        if (serv == "word")
                        {
                            reply.Attachments = RespuestasWord.GetCrearTablaContenidoWord();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else if (serv == "excel")
                        {
                            reply.Attachments = RespuestasExcel.GetCrearTablaExcel();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = Respuestas.GetCrearTabla();
                            await context.PostAsync($"Lo siento, {serv} no esta registrado, consulte otra vez el servicio escribiendo ayuda");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = Respuestas.GetCrearTabla();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    return;
                }
                // -------------------------------------------------------------------
                else if (palabra1 == "gráfico" || palabra1 == "grafico" || palabra1 == "gráficos" || palabra1 == "graficos")
                {
                    foreach (var entity in result.Entities.Where(Entity => Entity.Type == "Servicio"))
                    {
                        var serv = entity.Entity.ToLower().Replace(" ", "");
                        if (serv == "word")
                        {
                            reply.Attachments = RespuestasWord.GetCrearGraficoWord();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else if (serv == "excel")
                        {
                            reply.Attachments = RespuestasExcel.GetCrearGraficoExcel();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = RespuestasExcel.GetCrearGraficoWordExcel();
                            await context.PostAsync($"Lo siento, {serv} no esta registrado, consulte otra vez el servicio escribiendo ayuda");
                            await context.PostAsync(opcionSecundarioDeRespuesta2);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = RespuestasExcel.GetCrearGraficoWordExcel();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta2);
                    await context.PostAsync(reply);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    return;
                }
                // -------------------------------------------------------------------
                else if (palabra1 == "formulario" || palabra1 == "formularios")
                {
                    reply.Attachments = RespuestasWord.GetCrearFormularioWord();
                    await context.PostAsync(confirmacionRespuesta1);
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                    return;
                }
                // -------------------------------------------------------------------
                else if (palabra1 == "lista" || palabra1 == "listas")
                {
                    // Se detectó  la segunda parte de la pregunta
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");

                        // La segunda parte de la prgunta es mensaje o correo
                        if (palabra2 == "comprobación" || palabra2 == "comprobacion" || palabra2 == "comprobaciones")
                        {
                            reply.Attachments = RespuestasWord.GetCrearListaComprobacion();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else if (palabra2 == "combinación" || palabra2 == "combinacion" || palabra2 == "combinaciones")
                        {
                            reply.Attachments = RespuestasWord.GetCrearListaCombinacionCorrespondencia();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = RespuestasWord.GetCrearListaComprobacionListaCombinacion();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = RespuestasWord.GetCrearListaComprobacionListaCombinacion();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    return;
                }
                // -------------------------------------------------------------------
                else if (palabra1 == "etiqueta" || palabra1 == "etiquetas")
                {
                    foreach (var entity in result.Entities.Where(Entity => Entity.Type == "Servicio"))
                    {
                        var serv = entity.Entity.ToLower().Replace(" ", "");
                        if (serv == "word")
                        {
                            reply.Attachments = RespuestasWord.GetCrearImprimirEtiquetasWord();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else if (serv == "excel")
                        {
                            reply.Attachments = RespuestasExcel.GetCrearEtiquetasPostalesExcel();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = RespuestasExcel.GetCrearEtiquetasWordEtiquetasPostalesExcel();
                            await context.PostAsync($"Lo siento, {serv} no esta registrado, consulte otra vez el servicio escribiendo ayuda");
                            await context.PostAsync(opcionSecundarioDeRespuesta2);
                            await context.PostAsync(reply);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = RespuestasExcel.GetCrearEtiquetasWordEtiquetasPostalesExcel();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta2);
                    await context.PostAsync(reply);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    return;
                }
                // -------------------------------------------------------------------
                else if (palabra1 == "estilos" || palabra1 == "estilo")
                {
                    reply.Attachments = RespuestasWord.GetCrearEstiloDocumento();
                    await context.PostAsync(confirmacionRespuesta1);
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                    return;
                }
                // -------------------------------------------------------------------
                else if (palabra1 == "combinación" || palabra1 == "combinacion" || palabra1 == "combinaciones")
                {
                    reply.Attachments = RespuestasWord.GetCombinarCorrespondenciaHojaCalculo();
                    await context.PostAsync(confirmacionRespuesta1);
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                    return;
                }
                // -------------------------------------------------------------------
                else
                {
                    await context.PostAsync(preguntaNoRegistrada2);
                    await context.PostAsync($"O tal vez no escribió correctamente la palabra '{palabra1}'?");
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
