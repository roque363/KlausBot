﻿using System;
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
    public class CambiarDialog
    {
        private IDialogContext context;
        private LuisResult result;

        public CambiarDialog(IDialogContext context, LuisResult result)
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
            var accion = "Cambiar";
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


            // Se detectó la primera parte de la pregunta
            foreach (var entityP1 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra1"))
            {
                var palabra1 = entityP1.Entity.ToLower().Replace(" ", "");
                context.PrivateConversationData.SetValue<string>("Palabra1", palabra1);
                // -------------------------------------------------------------------
                // La primera parte de la pregunta es modo o apariencia
                if (palabra1 == "modo" || palabra1 == "apariencia")
                {
                    // Se detectó  la segunda parte de la pregunta
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");
                        // La segunda parte de la pregunta es calendario
                        if (palabra2 == "calendario" || palabra2 == "calendarios")
                        {
                            reply.Attachments = RespuestasOutlook.GetCambiarModoVerCalendario();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else if (palabra2 == "sinconexión" || palabra2 == "conconexión" || palabra2 == "conexión" || palabra2 == "sinconexion" || palabra2 == "conconexion" || palabra2 == "conexion")
                        {
                            reply.Attachments = RespuestasOutlook.GetCambiarModoConexion();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = RespuestasOutlook.GetCambiarModo();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = RespuestasOutlook.GetCambiarModo();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta2);
                    return;
                }
                // -------------------------------------------------------------------
                // La primera parte de la pregunta es vista
                else if (palabra1 == "vista" || palabra1 == "vistas")
                {
                    // Se detectó el 'servicio' de la pregunta
                    foreach (var entity in result.Entities.Where(Entity => Entity.Type == "Servicio"))
                    {
                        var serv = entity.Entity.ToLower().Replace(" ", "");
                        if (serv == "outlook" || serv == "outlok")
                        {
                            reply.Attachments = RespuestasOutlook.GetCrearCambiarPersonalizarVista();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else if (serv == "word" || serv == "wrd")
                        {
                            reply.Attachments = RespuestasWord.GetCambiarVistaWord();
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
                            await context.PostAsync($"Lo siento, {serv} no esta registrado, consulte otra vez el servicio escribiendo ayuda");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                        }
                    }
                    // No se detectó el 'servicio' de la pregunta
                    // Se obtiene el servicio que esta guardado en cache
                    var servicio = "Servicio";
                    context.PrivateConversationData.TryGetValue<string>("tipoServicio", out servicio);
                    if (servicio == "Word")
                    {
                        reply.Attachments = RespuestasWord.GetCambiarVistaWord();
                        await context.PostAsync(confirmacionRespuesta1);
                        await context.PostAsync(reply);
                        await context.PostAsync(preguntaConsulta);
                        context.PrivateConversationData.SetValue<string>("tipoServicio", servicio);
                        context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                        context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                        return;
                    }
                    else if (servicio == "Outlook")
                    {
                        reply.Attachments = RespuestasOutlook.GetCrearCambiarPersonalizarVista();
                        await context.PostAsync(confirmacionRespuesta1);
                        await context.PostAsync(reply);
                        await context.PostAsync(preguntaConsulta);
                        context.PrivateConversationData.SetValue<string>("tipoServicio", servicio);
                        context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                        context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                        return;
                    }
                    else
                    {
                        reply.Attachments = RespuestasOutlook.GetCrearCambiarPersonalizarVista();
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
                // La primera parte de la pregunta es sonido
                else if (palabra1 == "sonido" || palabra1 == "sonidos")
                {
                    // Se detectó  la segunda parte de la pregunta
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");
                        // La segunda parte de la pregunta es mensaje
                        if (palabra2 == "mensajes" || palabra2 == "mensaje" || palabra2 == "correo" || palabra2 == "correos")
                        {
                            reply.Attachments = RespuestasOutlook.GetCambiarSonidoReproducidoMensajeCorreo();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = RespuestasOutlook.GetCambiarSonidoReproducidoMensajeCorreo();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = RespuestasOutlook.GetCambiarSonidoReproducidoMensajeCorreo();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    return;
                }
                // -------------------------------------------------------------------
                // ----------------> Verificar esta pregunta color - fuente (Se necesitan 4 Entities)< -----------------
                // La primera parte de la pregunta es color
                else if (palabra1 == "color" || palabra1 == "colores" || palabra1 == "fuente" || palabra1 == "fuentes")
                {
                    // Se detectó  la segunda parte de la pregunta
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");
                        if (palabra2 == "escribe" || palabra2 == "redacta" || palabra2 == "escribo" || palabra2 == "redacto")
                        {
                            // Se detectó  la tercera parte de la pregunta
                            foreach (var entityP3 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra3"))
                            {
                                var palabra3 = entityP3.Entity.ToLower().Replace(" ", "");
                                if (palabra3 == "mensaje" || palabra3 == "mensajes" || palabra3 == "correo" || palabra3 == "correos")
                                {
                                    reply.Attachments = RespuestasOutlook.GetCambiarColorTextoRedactaMensaje();
                                    await context.PostAsync(confirmacionRespuesta1);
                                    await context.PostAsync(reply);
                                    await context.PostAsync(preguntaConsulta);
                                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                                    context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                                    return;
                                }
                                else
                                {
                                    reply.Attachments = RespuestasOutlook.GetCambiarColorTextoRedactaMensaje();
                                    await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra3}'?");
                                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                                    await context.PostAsync(reply);
                                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                                    return;
                                }
                            }
                            // No se detectó la tercera parte de la pregunta
                            reply.Attachments = RespuestasOutlook.GetCambiarColorTextoRedactaMensaje();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else if (palabra2 == "pordefecto" || palabra2 == "predeterminado" || palabra2 == "predeterminada")
                        {
                            // Se detectó  la tercera parte de la pregunta
                            foreach (var entityP3 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra3"))
                            {
                                var palabra3 = entityP3.Entity.ToLower().Replace(" ", "");
                                if (palabra3 == "mensaje" || palabra3 == "mensajes" || palabra3 == "correoelectronico" || palabra3 == "correoelectrónico" || palabra3 == "correoselectronicos" || palabra3 == "correoselectrónicos" || palabra3 == "carta" || palabra3 == "cartas")
                                {
                                    reply.Attachments = RespuestasOutlook.GetCambiarColorTextoFuentePredeterminadoMensajes();
                                    await context.PostAsync(confirmacionRespuesta1);
                                    await context.PostAsync(reply);
                                    await context.PostAsync(preguntaConsulta);
                                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                                    context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                                    return;
                                }
                                else
                                {
                                    reply.Attachments = RespuestasOutlook.GetCambiarColorTextoFuentePredeterminadoMensajes();
                                    await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra3}'?");
                                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                                    await context.PostAsync(reply);
                                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                                    return;
                                }
                            }
                            // No se detectó la tercera parte de la pregunta
                            reply.Attachments = RespuestasOutlook.GetCambiarColorTextoFuentePredeterminadoMensajes();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else if (palabra2 == "fondo" || palabra2 == "fondos")
                        {
                            // Se detectó  la tercera parte de la pregunta
                            foreach (var entityP3 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra3"))
                            {
                                var palabra3 = entityP3.Entity.ToLower().Replace(" ", "");
                                if (palabra3 == "calendario" || palabra3 == "calendarios")
                                {
                                    // Se detectó el Servicio de la pregunta
                                    foreach (var entity in result.Entities.Where(Entity => Entity.Type == "Servicio"))
                                    {
                                        var serv = entity.Entity.ToLower().Replace(" ", "");
                                        if (serv == "outlook" || serv == "Outlook" || serv == "outlok")
                                        {
                                            reply.Attachments = RespuestasOutlook.GetCambiarColorFondoCalendario();
                                            await context.PostAsync(confirmacionRespuesta1);
                                            await context.PostAsync(reply);
                                            await context.PostAsync(preguntaConsulta);
                                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                                            return;
                                        }
                                        else
                                        {
                                            reply.Attachments = RespuestasOutlook.GetCambiarColorFondoCalendario();
                                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{serv}'?");
                                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                                            await context.PostAsync(reply);
                                            return;
                                        }
                                    }
                                    // No se detecto el Servicio de la pregunta
                                    // Obtener el producto si este a sido escodigo anteriormente
                                    var servicio = "Servicio";
                                    context.PrivateConversationData.TryGetValue<string>("tipoDeServicio", out servicio);
                                    if (servicio == "Outlook")
                                    {
                                        reply.Attachments = RespuestasOutlook.GetCambiarColorFondoCalendario();
                                        await context.PostAsync(confirmacionRespuesta1);
                                        await context.PostAsync(reply);
                                        await context.PostAsync(preguntaConsulta);
                                        context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                                        context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                                        return;
                                    }
                                    else
                                    {
                                        reply.Attachments = RespuestasOutlook.GetCambiarColorFondoCalendario();
                                        await context.PostAsync(confirmacionRespuesta1);
                                        await context.PostAsync(reply);
                                        await context.PostAsync(preguntaConsulta);
                                        context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                                        context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                                        return;
                                    }
                                }
                                else if (palabra3 == "pagina" || palabra3 == "paginas" || palabra3 == "página" || palabra3 == "páginas")
                                {
                                    // Se detectó el Servicio de la pregunta
                                    foreach (var entity in result.Entities.Where(Entity => Entity.Type == "Servicio"))
                                    {
                                        var serv = entity.Entity.ToLower().Replace(" ", "");
                                        if (serv == "onenote" || serv == "OneNote")
                                        {
                                            reply.Attachments = RespuestasOneNote.GetCambiarcolorfondopaginaOneNote();
                                            await context.PostAsync(confirmacionRespuesta1);
                                            await context.PostAsync(reply);
                                            await context.PostAsync(preguntaConsulta);
                                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                                            return;
                                        }
                                        else
                                        {
                                            reply.Attachments = RespuestasOneNote.GetCambiarcolorfondopaginaOneNote();
                                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{serv}'?");
                                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                                            await context.PostAsync(reply);
                                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                                            return;
                                        }
                                    }
                                    // No se detecto el Servicio de la pregunta
                                    // Obtener el producto si este a sido escodigo anteriormente
                                    var servicio = "Servicio";
                                    context.PrivateConversationData.TryGetValue<string>("tipoDeServicio", out servicio);
                                    if (servicio == "OneNote")
                                    {
                                        reply.Attachments = RespuestasOneNote.GetCambiarcolorfondopaginaOneNote();
                                        await context.PostAsync(confirmacionRespuesta1);
                                        await context.PostAsync(reply);
                                        await context.PostAsync(preguntaConsulta);
                                        context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                                        context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                                        return;
                                    }
                                    else
                                    {
                                        reply.Attachments = RespuestasOneNote.GetCambiarcolorfondopaginaOneNote();
                                        await context.PostAsync(confirmacionRespuesta1);
                                        await context.PostAsync(reply);
                                        await context.PostAsync(preguntaConsulta);
                                        context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                                        context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                                        return;
                                    }
                                }
                                else if (palabra3 == "documento" || palabra3 == "documentos" || palabra3 == "archivo" || palabra3 == "archivos")
                                {
                                    reply.Attachments = RespuestasWord.GetCambiarColorFondoDocumentoWord();
                                    await context.PostAsync(confirmacionRespuesta1);
                                    await context.PostAsync(reply);
                                    await context.PostAsync(preguntaConsulta);
                                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                                    return;
                                }
                                else if (palabra3 == "diapositiva" || palabra3 == "diapositivas")
                                {
                                    reply.Attachments = RespuestasPowerPoint.GetCambiarColorFondoDiapositivas();
                                    await context.PostAsync(confirmacionRespuesta1);
                                    await context.PostAsync(reply);
                                    await context.PostAsync(preguntaConsulta);
                                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                                    return;
                                }
                                else
                                {
                                    reply.Attachments = Respuestas.GetCambiarColorFondoOutlookOneDrive();
                                    await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra3}'?");
                                    await context.PostAsync(opcionSecundarioDeRespuesta2);
                                    await context.PostAsync(reply);
                                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                                    return;
                                }
                            }
                            // No se detecto la Tercera parte de la pregunta
                            // Se detectó el Servicio de la pregunta
                            foreach (var entity in result.Entities.Where(Entity => Entity.Type == "Servicio"))
                            {
                                var serv = entity.Entity.ToLower().Replace(" ", "");
                                if (serv == "outlook" || serv == "Outlook" || serv == "outlok")
                                {
                                    reply.Attachments = RespuestasOutlook.GetCambiarColorFondoCalendario();
                                    await context.PostAsync(confirmacionRespuesta1);
                                    await context.PostAsync(reply);
                                    await context.PostAsync(preguntaConsulta);
                                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                                    return;
                                }
                                else if (serv == "onenote" || serv == "OneNote")
                                {
                                    reply.Attachments = RespuestasOneNote.GetCambiarcolorfondopaginaOneNote();
                                    await context.PostAsync(confirmacionRespuesta1);
                                    await context.PostAsync(reply);
                                    await context.PostAsync(preguntaConsulta);
                                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                                    context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                                    return;
                                }
                                else
                                {
                                    reply.Attachments = Respuestas.GetCambiarColorFondoOutlookOneDrive();
                                    await context.PostAsync(preguntaNoRegistrada1);
                                    await context.PostAsync(opcionSecundarioDeRespuesta2);
                                    await context.PostAsync(reply);
                                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                                    return;
                                }
                            }
                            // No se detecto el Servicio de la pregunta
                            // Obtener el producto si este a sido escodigo anteriormente
                            var servicio2 = "Servicio";
                            context.PrivateConversationData.TryGetValue<string>("tipoDeServicio", out servicio2);
                            if (servicio2 == "OneNote")
                            {
                                reply.Attachments = RespuestasOneNote.GetCambiarcolorfondopaginaOneNote();
                                await context.PostAsync(confirmacionRespuesta1);
                                await context.PostAsync(reply);
                                await context.PostAsync(preguntaConsulta);
                                context.PrivateConversationData.SetValue<string>("tipoServicio", "OneNote");
                                context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                                context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                                return;
                            }
                            else if (servicio2 == "Outlook")
                            {
                                reply.Attachments = RespuestasOutlook.GetCambiarColorFondoCalendario();
                                await context.PostAsync(confirmacionRespuesta1);
                                await context.PostAsync(reply);
                                await context.PostAsync(preguntaConsulta);
                                context.PrivateConversationData.SetValue<string>("tipoServicio", "Outlook");
                                context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                                context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                                return;
                            }
                            else
                            {
                                reply.Attachments = Respuestas.GetCambiarColorFondoOutlookOneDrive();
                                await context.PostAsync(preguntaNoRegistrada1);
                                await context.PostAsync(opcionSecundarioDeRespuesta2);
                                await context.PostAsync(reply);
                                context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                                return;
                            }
                        }
                        else if (palabra2 == "mensajes" || palabra2 == "mensaje" || palabra2 == "correoelectronico" || palabra2 == "correoelectrónico" || palabra2 == "correoselectronicos" || palabra2 == "correoselectrónicos" || palabra2 == "carta" || palabra2 == "cartas")
                        {
                            // Se detectó  la tercera parte de la pregunta
                            foreach (var entityP3 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra3"))
                            {
                                var palabra3 = entityP3.Entity.ToLower().Replace(" ", "");

                                if (palabra3 == "asunto" || palabra3 == "asuntos" || palabra3 == "remitente" || palabra3 == "remitentes" || palabra3 == "destinatarios" || palabra3 == "destinatario")
                                {
                                    reply.Attachments = RespuestasOutlook.GetCambiarFuenteMensajesEntrantesRemitente();
                                    await context.PostAsync(confirmacionRespuesta1);
                                    await context.PostAsync(reply);
                                    await context.PostAsync(preguntaConsulta);
                                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                                    context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                                    return;
                                }
                                else
                                {
                                    reply.Attachments = RespuestasOutlook.GetCambiarFuenteMensajesEntrantesRemitente();
                                    await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra3}'?");
                                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                                    await context.PostAsync(reply);
                                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                                    return;
                                }
                            }
                            // No se detectó la segunda parte de la pregunta
                            reply.Attachments = RespuestasOutlook.GetAgregarColor();
                            await context.PostAsync(preguntaNoRegistrada1);
                            await context.PostAsync(opcionSecundarioDeRespuesta2);
                            await context.PostAsync(reply);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                        }
                        else if (palabra2 == "listas" || palabra2 == "lista")
                        {
                            // Se detectó  la tercera parte de la pregunta
                            foreach (var entityP3 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra3"))
                            {
                                var palabra3 = entityP3.Entity.ToLower().Replace(" ", "");
                                if (palabra3 == "mensaje" || palabra3 == "mensajes" || palabra3 == "correoelectronico" || palabra3 == "correoelectrónico" || palabra3 == "correoselectronicos" || palabra3 == "correoselectrónicos" || palabra3 == "carta" || palabra3 == "cartas")
                                {
                                    reply.Attachments = RespuestasOutlook.GetCambiarTamanoFuenteListaMensajes();
                                    await context.PostAsync(confirmacionRespuesta1);
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
                                    reply.Attachments = RespuestasOutlook.GetCambiarTamanoFuenteListaMensajes();
                                    await context.PostAsync(reply);
                                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                                    return;
                                }
                            }
                            // No se detectó la tercera parte de la pregunta
                            reply.Attachments = RespuestasOutlook.GetCambiarTamanoFuenteListaMensajes();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                        }
                        else if (palabra2 == "documento" || palabra2 == "documentos")
                        {
                            foreach (var serv in result.Entities.Where(Entity => Entity.Type == "Servicio"))
                            {
                                var servicio1 = serv.Entity.ToLower().Replace(" ", "");

                                if (servicio1 == "word")
                                {
                                    reply.Attachments = RespuestasWord.GetCambiarColorFondoDocumentoWord();
                                    await context.PostAsync(confirmacionRespuesta1);
                                    await context.PostAsync(reply);
                                    await context.PostAsync(preguntaConsulta);
                                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                                    context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                                    return;
                                }
                                else
                                {
                                    reply.Attachments = RespuestasWord.GetCambiarColorFondoDocumentoWord();
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
                                reply.Attachments = RespuestasWord.GetCambiarColorFondoDocumentoWord();
                                await context.PostAsync(confirmacionRespuesta1);
                                await context.PostAsync(reply);
                                await context.PostAsync(preguntaConsulta);
                                context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                                context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                                return;
                            }
                            else
                            {
                                // No se detectó la segunda parte de la pregunta
                                reply.Attachments = RespuestasWord.GetCambiarColorFondoDocumentoWord();
                                await context.PostAsync(preguntaNoRegistrada1);
                                await context.PostAsync(opcionSecundarioDeRespuesta1);
                                await context.PostAsync(reply);
                                await context.PostAsync(preguntaConsulta);
                                context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                                context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                                return;
                            }
                        }
                        else
                        {
                            reply.Attachments = Respuestas.GetCambiarColorFondoOutlookOneDrive();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta2);
                            await context.PostAsync(reply);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = Respuestas.GetCambiarColorFondoOutlookOneDrive();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta2);
                    await context.PostAsync(reply);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta2);
                    return;
                }
                // -------------------------------------------------------------------
                // La primera parte de la pregunta es tamaño fuente
                else if (palabra1 == "tamaño" || palabra1 == "tamaños")
                {
                    // Se detectó  la segunda parte de la pregunta
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");
                        if (palabra2 == "fuente" || palabra2 == "fuentes")
                        {
                            // Se detectó  la tercera parte de la pregunta
                            foreach (var entityP3 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra3"))
                            {
                                var palabra3 = entityP3.Entity.ToLower().Replace(" ", "");
                                if (palabra3 == "lista" || palabra3 == "listas")
                                {
                                    reply.Attachments = RespuestasOutlook.GetCambiarTamanoFuenteListaMensajes();
                                    await context.PostAsync(confirmacionRespuesta1);
                                    await context.PostAsync(preguntaConsulta);
                                    await context.PostAsync(reply);
                                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                                    context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                                    return;
                                }
                                else
                                {
                                    reply.Attachments = RespuestasOutlook.GetCambiarTamanoFuenteListaMensajes();
                                    await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra3}'?");
                                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                                    await context.PostAsync(reply);
                                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                                    return;
                                }
                            }
                            // No se detectó la tercera parte de la pregunta
                            reply.Attachments = RespuestasOutlook.GetCambiarTamanoFuenteListaMensajes();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(preguntaConsulta);
                            await context.PostAsync(reply);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                        }
                        else if (palabra2 == "diapositiva" || palabra2 == "diapositivas")
                        {
                            reply.Attachments = RespuestasPowerPoint.GetCambiarTamanoDiapositivas();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(preguntaConsulta);
                            await context.PostAsync(reply);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = Respuestas.GetCambiarTamanoFuenteListaMensajesTamanoDiapositivas();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = Respuestas.GetCambiarTamanoFuenteListaMensajesTamanoDiapositivas();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta2);
                    return;
                }
                // -------------------------------------------------------------------
                // La primera parte de la pregunta es nombre
                else if (palabra1 == "nombre" || palabra1 == "nombres")
                {
                    // Se detectó  la segunda parte de la pregunta
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");
                        if (palabra2 == "categoria" || palabra2 == "categoría" || palabra2 == "categorias" || palabra2 == "categorías" || palabra2 == "clases" || palabra2 == "clase")
                        {
                            reply.Attachments = RespuestasOutlook.GetCambiarNombreCategoriaColor();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                        }
                        else if (palabra2 == "carpeta" || palabra2 == "carpetas")
                        {
                            reply.Attachments = RespuestasOutlook.GetCambiarNombreCarpeta();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else if (palabra2 == "autor")
                        {
                            reply.Attachments = RespuestasWord.GetCambiarNombreAutorDocumento();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = RespuestasOutlook.GetCambiarNombreCarpetaYCategoria();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta2);
                            await context.PostAsync(reply);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = RespuestasOutlook.GetCambiarNombre();
                    await context.PostAsync(confirmacionRespuesta1);
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                    return;
                }
                // La primera parte de la pregunta es firma
                else if (palabra1 == "firma" || palabra1 == "firmas")
                {
                    // Se detectó la segunda parte de la pregunta
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");
                        if (palabra2 == "mensajes" || palabra2 == "mensaje" || palabra2 == "correo" || palabra2 == "correos")
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
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
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
                // La primera parte de la pregunta es cofiguracion
                else if (palabra1 == "configuración" || palabra1 == "configuracion" || palabra1 == "configuraciones")
                {
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");
                        if (palabra2 == "grupos" || palabra2 == "grupo")
                        {
                            foreach (var entityP3 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra3"))
                            {
                                var palabra3 = entityP3.Entity.ToLower().Replace(" ", "");

                                if (palabra3 == "envio" || palabra3 == "envios" || palabra3 == "envíos" || palabra3 == "envíos" || palabra3 == "recepcion" || palabra3 == "recepción")
                                {
                                    reply.Attachments = RespuestasOutlook.GetCambiarConfiguracionGruposEnvios();
                                    await context.PostAsync(confirmacionRespuesta1);
                                    await context.PostAsync(reply);
                                    await context.PostAsync(preguntaConsulta);
                                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                                    context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                                    return;
                                }
                                else
                                {
                                    reply.Attachments = RespuestasOutlook.GetCambiarConfiguracionGruposEnvios();
                                    await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra3}'?");
                                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                                    await context.PostAsync(reply);
                                    await context.PostAsync(preguntaConsulta);
                                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                                    context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                                    return;
                                }
                            }
                            // No se detectó la segunda parte de la pregunta
                            reply.Attachments = RespuestasOutlook.GetCambiarConfiguracionGruposEnvios();
                            await context.PostAsync(preguntaNoRegistrada1);
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = RespuestasOutlook.GetCambiarConfiguracionGruposEnvios();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = RespuestasOutlook.GetCambiarConfiguracionCorreo();
                    await context.PostAsync(confirmacionRespuesta1);
                    await context.PostAsync(preguntaConsulta);
                    await context.PostAsync(reply);
                    await context.PostAsync(reply);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    return;
                }
                else if (palabra1 == "ubicación" || palabra1 == "ubicaciones" || palabra1 == "ubicacion")
                {
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");
                        if (palabra2 == "mensajes" || palabra2 == "mensaje" || palabra2 == "correoelectronico" || palabra2 == "correoelectrónico" || palabra2 == "correoselectronicos" || palabra2 == "correoselectrónicos")
                        {
                            foreach (var entityP3 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra3"))
                            {
                                var palabra3 = entityP3.Entity.ToLower().Replace(" ", "");
                                if (palabra3 == "guardan" || palabra3 == "guardado" || palabra3 == "guarda" || palabra3 == "almacena" || palabra3 == "almacenados" || palabra3 == "guardados")
                                {
                                    reply.Attachments = RespuestasOutlook.GetCambiarUbicacionGuardanMensajes();
                                    await context.PostAsync(confirmacionRespuesta1);
                                    await context.PostAsync(reply);
                                    await context.PostAsync(preguntaConsulta);
                                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                                    context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                                    return;
                                }
                                else
                                {
                                    reply.Attachments = RespuestasOutlook.GetCambiarUbicacionGuardanMensajes();
                                    await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra3}'?");
                                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                                    await context.PostAsync(reply);
                                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                                    return;
                                }
                            }
                            reply.Attachments = RespuestasOutlook.GetCambiarUbicacionGuardanMensajes();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = RespuestasOutlook.GetCambiarUbicacionGuardanMensajes();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = RespuestasOutlook.GetCambiarUbicacionGuardanMensajes();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    return;
                }
                else if (palabra1 == "cita" || palabra1 == "citas" || palabra1 == "eventos" || palabra1 == "evento" || palabra1 == "reunión" || palabra1 == "reuniones")
                {
                    reply.Attachments = RespuestasOutlook.GetCambiarCitaOutlook();
                    await context.PostAsync(confirmacionRespuesta1);
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                    return;
                }
                else if (palabra1 == "nivel" || palabra1 == "niveles")
                {
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");
                        if (palabra2 == "nodeseado" || palabra2 == "nodeseados" || palabra2 == "detestables" || palabra2 == "detestable" || palabra2 == "bloqueado" || palabra2 == "bloqueados")
                        {
                            reply.Attachments = RespuestasOutlook.GetCambiarNivelProteccionFiltroCorreo();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = RespuestasOutlook.GetCambiarNivelProteccionFiltroCorreo();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = RespuestasOutlook.GetCambiarNivelProteccionFiltroCorreo();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    return;
                }
                else if (palabra1 == "usocompartido" || palabra1 == "compartido")
                {
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");
                        if (palabra2 == "archivos" || palabra2 == "archivo" || palabra2 == "carpetas" || palabra2 == "carpeta")
                        {
                            reply.Attachments = RespuestasOneDrive.GetCambiarUsoCompartidoArchivoOneDrive();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = RespuestasOneDrive.GetCambiarUsoCompartidoArchivoOneDrive();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = RespuestasOneDrive.GetCambiarUsoCompartidoArchivoOneDrive();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    return;
                }
                else if (palabra1 == "notas" || palabra1 == "nota" || palabra1 == "blocs de notas" || palabra1 == "bloc de notas" || palabra1 == "bloc" || palabra1 == "block")
                {
                    reply.Attachments = RespuestasOneNote.GetCambiarEntreBlocsNotasOneNote();
                    await context.PostAsync(confirmacionRespuesta1);
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    return;
                }
                else if (palabra1 == "letrasmayúsculas" || palabra1 == "letramayúscula" || palabra1 == "mayúscula" || palabra1 == "mayuscula" || palabra1 == "mayúsculas" || palabra1 == "mayusculas")
                {
                    reply.Attachments = RespuestasWord.GetCambiarMayusculasTextoWord();
                    await context.PostAsync(confirmacionRespuesta1);
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                    return;
                }
                else if (palabra1 == "interlineado")
                {
                    reply.Attachments = RespuestasWord.GetCambiarInterlineadoWord();
                    await context.PostAsync(confirmacionRespuesta1);
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                    return;
                }
                else if (palabra1 == "espacio" || palabra1 == "espacios")
                {
                    reply.Attachments = RespuestasWord.GetCambiarEspaciosTextoWord();
                    await context.PostAsync(confirmacionRespuesta1);
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                    return;
                }
                else if (palabra1 == "fondo" || palabra1 == "fondos")
                {
                    // Se detectó la segunda parte de la pregunta
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");
                        if (palabra2 == "documento" || palabra2 == "documentos" || palabra2 == "archivos" || palabra2 == "archivo")
                        {
                            reply.Attachments = RespuestasWord.GetCambiarColorFondoDocumentoWord();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = RespuestasWord.GetCambiarColorFondoDocumentoWord();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = RespuestasWord.GetCambiarColorFondoDocumentoWord();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    return;
                }
                else if (palabra1 == "bordes" || palabra1 == "borde")
                {
                    // Se detectó la segunda parte de la pregunta
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");
                        if (palabra2 == "documento" || palabra2 == "documentos" || palabra2 == "archivos" || palabra2 == "archivo")
                        {
                            reply.Attachments = RespuestasWord.GetCambiarBordeDocumentoWord();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else if (palabra2 == "cuadrodetexto" || palabra2 == "cuadrosdetexto")
                        {
                            reply.Attachments = RespuestasWord.GetCambiarBordeCuadroTextoWord();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = RespuestasWord.GetCambiarBordeWord();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = RespuestasWord.GetCambiarBordeWord();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    return;
                }
                else if (palabra1 == "encabezados" || palabra1 == "encabezado" || palabra1 == "piedepágina" || palabra1 == "piedepagina" || palabra1 == "piesdepágina" || palabra1 == "piesdepagina")
                {
                    reply.Attachments = RespuestasWord.GetModificarEncabezadoPiePagina();
                    await context.PostAsync(confirmacionRespuesta1);
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                    return;
                }
                else if (palabra1 == "espaciado" || palabra1 == "espaciado")
                {
                    // Recorrido del Servicio de la pregunta
                    foreach (var entity in result.Entities.Where(Entity => Entity.Type == "Servicio"))
                    {
                        var serv = entity.Entity.ToLower().Replace(" ", "");
                        if (serv == "word" || serv == "Word" || serv == "outlook" || serv == "Outlook")
                        {
                            reply.Attachments = RespuestasWord.GetAjustarSangriaEspaciado();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else if (serv == "outlook" || serv == "Outlook")
                        {
                            reply.Attachments = Respuestas.GetAjustarSangriaEspaciado();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = Respuestas.GetAjustarSangriaEspaciado();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, no se tiene registrado el servicio '{serv}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                        }
                    }
                    //obtener el producto si este a sido escodigo anteriormente
                    var servicio = "Servicio";
                    context.PrivateConversationData.TryGetValue<string>("tipoDeServicio", out servicio);
                    if (servicio == "Word" || servicio == "Outlook")
                    {
                        reply.Attachments = RespuestasWord.GetAjustarSangriaEspaciado();
                        await context.PostAsync(confirmacionRespuesta1);
                        await context.PostAsync(reply);
                        await context.PostAsync(preguntaConsulta);
                        context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                        context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                        return;
                    }
                    else
                    {
                        // No se detectó la segunda parte de la pregunta
                        reply.Attachments = Respuestas.GetAjustarSangriaEspaciado();
                        await context.PostAsync(preguntaNoRegistrada1);
                        await context.PostAsync(opcionSecundarioDeRespuesta1);
                        await context.PostAsync(reply);
                        context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                        return;
                    }
                }
                else if (palabra1 == "sangría" || palabra1 == "sangrías")
                {
                    // Recorrido del Servicio de la pregunta
                    foreach (var entity in result.Entities.Where(Entity => Entity.Type == "Servicio"))
                    {
                        var serv = entity.Entity.ToLower().Replace(" ", "");
                        if (serv == "word" || serv == "Word" || serv == "outlook" || serv == "Outlook")
                        {
                            reply.Attachments = RespuestasWord.GetAjustarSangriaEspaciado();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else if (serv == "outlook" || serv == "Outlook")
                        {
                            reply.Attachments = Respuestas.GetAjustarSangriaEspaciado();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = Respuestas.GetAjustarSangriaEspaciado();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, no se tiene registrado el servicio '{serv}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                        }
                    }
                    //obtener el producto si este a sido escodigo anteriormente
                    var servicio = "Servicio";
                    context.PrivateConversationData.TryGetValue<string>("tipoDeServicio", out servicio);
                    if (servicio == "Word" || servicio == "Outlook")
                    {
                        reply.Attachments = RespuestasWord.GetAjustarSangriaEspaciado();
                        await context.PostAsync(confirmacionRespuesta1);
                        await context.PostAsync(reply);
                        await context.PostAsync(preguntaConsulta);
                        context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                        context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                        return;
                    }
                    else
                    {
                        // No se detectó la segunda parte de la pregunta
                        reply.Attachments = Respuestas.GetAjustarSangriaEspaciado();
                        await context.PostAsync(preguntaNoRegistrada1);
                        await context.PostAsync(opcionSecundarioDeRespuesta1);
                        await context.PostAsync(reply);
                        context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                        return;
                    }
                }
                else if (palabra1 == "estilos" || palabra1 == "estilo")
                {
                    // Recorrido del Servicio de la pregunta
                    foreach (var entity in result.Entities.Where(Entity => Entity.Type == "Servicio"))
                    {
                        var serv = entity.Entity.ToLower().Replace(" ", "");
                        if (serv == "word" || serv == "Word" || serv == "outlook" || serv == "Outlook")
                        {
                            reply.Attachments = RespuestasWord.GetModificarEstiloExistente();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else if (serv == "outlook" || serv == "Outlook")
                        {
                            reply.Attachments = RespuestasWord.GetModificarEstiloExistente();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = RespuestasWord.GetModificarEstiloExistente();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, no se tiene registrado el servicio '{serv}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                        }
                    }
                    //obtener el producto si este a sido escodigo anteriormente
                    var servicio = "Servicio";
                    context.PrivateConversationData.TryGetValue<string>("tipoDeServicio", out servicio);
                    if (servicio == "Word" || servicio == "Outlook")
                    {
                        reply.Attachments = RespuestasWord.GetModificarEstiloExistente();
                        await context.PostAsync(confirmacionRespuesta1);
                        await context.PostAsync(reply);
                        await context.PostAsync(preguntaConsulta);
                        context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                        context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                        return;
                    }
                    else
                    {
                        // No se detectó la segunda parte de la pregunta
                        reply.Attachments = RespuestasWord.GetModificarEstiloExistente();
                        await context.PostAsync(preguntaNoRegistrada1);
                        await context.PostAsync(opcionSecundarioDeRespuesta1);
                        await context.PostAsync(reply);
                        context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                        return;
                    }
                }
                else if (palabra1 == "contraseñas" || palabra1 == "contraseña" || palabra1 == "password")
                {
                    reply.Attachments = Respuestas.GetRecuperarContraseñaMicrosoft();
                    await context.PostAsync(confirmacionRespuesta1);
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                    return;
                }
                else if (palabra1 == "comentarios" || palabra1 == "comentario")
                {
                    reply.Attachments = RespuestasPowerPoint.GetModificarComentarioPowerPoint();
                    await context.PostAsync(confirmacionRespuesta1);
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    return;
                }
                else if (palabra1 == "orden")
                {
                    // Se detectó la segunda parte de la pregunta
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");
                        if (palabra2 == "reproducción" || palabra2 == "reproduccion")
                        {
                            reply.Attachments = RespuestasPowerPoint.GetCambiarOrdenReproduccionEfectosAnimacion();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = RespuestasPowerPoint.GetCambiarOrdenReproduccionEfectosAnimacion();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = reply.Attachments = RespuestasPowerPoint.GetCambiarOrdenReproduccionEfectosAnimacion();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    return;
                }
                else if (palabra1 == "efecto" || palabra1 == "efectos")
                {
                    // Se detectó la segunda parte de la pregunta
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");
                        if (palabra2 == "animación" || palabra2 == "animacion" || palabra2 == "animaciones")
                        {
                            reply.Attachments = RespuestasPowerPoint.GetCambiarEfectoAnimacion();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = RespuestasPowerPoint.GetCambiarEfectoAnimacion();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = RespuestasPowerPoint.GetCambiarEfectoAnimacion();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
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
            // Si el usuario no ingreso la primera parte de la pregunta
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