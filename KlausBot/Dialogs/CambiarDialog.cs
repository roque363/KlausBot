﻿using System;
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
                            reply.Attachments = Respuestas.GetCambiarModoVerCalendario();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = Respuestas.GetCambiarModoVerCalendario();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = Respuestas.GetCambiarModoVerCalendario();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
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
                            reply.Attachments = Respuestas.GetCrearCambiarPersonalizarVista();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            return;
                        }
                        else if (serv == "word" || serv == "wrd")
                        {
                            reply.Attachments = Respuestas.GetCambiarVistaWord();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = Respuestas.GetCrearCambiarPersonalizarVista();
                            await context.PostAsync($"Lo siento, {serv} no esta registrado, consulte otra vez el servicio escribiendo ayuda");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            return;
                        }
                    }
                    // No se detectó el 'servicio' de la pregunta
                    // Se obtiene el servicio que esta guardado en cache
                    var servicio = "Servicio";
                    context.PrivateConversationData.TryGetValue<string>("tipoServicio", out servicio);
                    if (servicio == "Word")
                    {
                        reply.Attachments = Respuestas.GetCambiarVistaWord();
                        await context.PostAsync(confirmacionRespuesta1);
                        await context.PostAsync(reply);
                        context.PrivateConversationData.SetValue<string>("tipoServicio", "Servicio");
                        return;
                    }
                    else if (servicio == "Outlook")
                    {
                        reply.Attachments = Respuestas.GetCrearCambiarPersonalizarVista();
                        await context.PostAsync(confirmacionRespuesta1);
                        await context.PostAsync(reply);
                        await context.PostAsync(preguntaConsulta);
                        context.PrivateConversationData.SetValue<string>("tipoServicio", "Servicio");
                        return;
                    }
                    else
                    {
                        reply.Attachments = Respuestas.GetCrearCambiarPersonalizarVista();
                        await context.PostAsync(preguntaNoRegistrada1);
                        await context.PostAsync(opcionSecundarioDeRespuesta1);
                        await context.PostAsync(reply);
                        await context.PostAsync(preguntaConsulta);
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
                            reply.Attachments = Respuestas.GetCambiarSonidoReproducidoMensajeCorreo();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = Respuestas.GetCambiarSonidoReproducidoMensajeCorreo();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = Respuestas.GetCambiarSonidoReproducidoMensajeCorreo();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
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
                            reply.Attachments = Respuestas.GetCambiarNombreCategoriaColor();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = Respuestas.GetCambiarNombreCategoriaColor();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = Respuestas.GetCambiarNombreCategoriaColor();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
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
                                    reply.Attachments = Respuestas.GetCambiarColorTextoRedactaMensaje();
                                    await context.PostAsync(confirmacionRespuesta1);
                                    await context.PostAsync(reply);
                                    await context.PostAsync(preguntaConsulta);
                                    return;
                                }
                                else
                                {
                                    reply.Attachments = Respuestas.GetCambiarColorTextoRedactaMensaje();
                                    await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra3}'?");
                                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                                    await context.PostAsync(reply);
                                    return;
                                }
                            }
                            // No se detectó la tercera parte de la pregunta
                            reply.Attachments = Respuestas.GetCambiarColorTextoRedactaMensaje();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
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
                                    reply.Attachments = Respuestas.GetCambiarColorTextoFuentePredeterminadoMensajes();
                                    await context.PostAsync(confirmacionRespuesta1);
                                    await context.PostAsync(reply);
                                    await context.PostAsync(preguntaConsulta);
                                    return;
                                }
                                else
                                {
                                    reply.Attachments = Respuestas.GetCambiarColorTextoFuentePredeterminadoMensajes();
                                    await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra3}'?");
                                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                                    await context.PostAsync(reply);
                                    return;
                                }
                            }
                            // No se detectó la tercera parte de la pregunta
                            reply.Attachments = Respuestas.GetCambiarColorTextoFuentePredeterminadoMensajes();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
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
                                    reply.Attachments = Respuestas.GetCambiarColorFondoCalendario();
                                    await context.PostAsync(confirmacionRespuesta1);
                                    await context.PostAsync(reply);
                                    await context.PostAsync(preguntaConsulta);
                                    return;
                                }
                                else
                                {
                                    reply.Attachments = Respuestas.GetCambiarColorFondoCalendario();
                                    await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra3}'?");
                                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                                    await context.PostAsync(reply);
                                    return;
                                }
                            }
                            // No se detectó la tercera parte de la pregunta
                            reply.Attachments = Respuestas.GetCambiarColorFondoCalendario();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(preguntaConsulta);
                            await context.PostAsync(reply);
                            return;

                        }
                        else if (palabra2 == "mensajes" || palabra2 == "mensaje" || palabra2 == "correoelectronico" || palabra2 == "correoelectrónico" || palabra2 == "correoselectronicos" || palabra2 == "correoselectrónicos" || palabra2 == "carta" || palabra2 == "cartas")
                        {
                            // Se detectó  la tercera parte de la pregunta
                            foreach (var entityP3 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra3"))
                            {
                                var palabra3 = entityP3.Entity.ToLower().Replace(" ", "");

                                if (palabra3 == "asunto" || palabra3 == "asuntos" || palabra3 == "remitente" || palabra3 == "remitentes" || palabra3 == "destinatarios" || palabra3 == "destinatario")
                                {
                                    reply.Attachments = Respuestas.GetCambiarFuenteMensajesEntrantesRemitente();
                                    await context.PostAsync(confirmacionRespuesta1);
                                    await context.PostAsync(reply);
                                    await context.PostAsync(preguntaConsulta);
                                    return;
                                }
                                else
                                {
                                    reply.Attachments = Respuestas.GetCambiarFuenteMensajesEntrantesRemitente();
                                    await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra3}'?");
                                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                                    await context.PostAsync(reply);
                                    return;
                                }
                            }
                            // No se detectó la segunda parte de la pregunta
                            reply.Attachments = Respuestas.GetAgregarColor();
                            await context.PostAsync(preguntaNoRegistrada1);
                            await context.PostAsync(opcionSecundarioDeRespuesta2);
                            await context.PostAsync(reply);
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
                                    reply.Attachments = Respuestas.GetCambiarTamanoFuenteListaMensajes();
                                    await context.PostAsync(confirmacionRespuesta1);
                                    await context.PostAsync(preguntaConsulta);
                                    await context.PostAsync(reply);
                                    return;
                                }
                                else
                                {
                                    reply.Attachments = Respuestas.GetCrearDiseñosFondoParaMensajes();
                                    await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra3}'?");
                                    reply.Attachments = Respuestas.GetCambiarTamanoFuenteListaMensajes();
                                    await context.PostAsync(reply);
                                    return;
                                }
                            }
                            // No se detectó la tercera parte de la pregunta
                            reply.Attachments = Respuestas.GetCambiarTamanoFuenteListaMensajes();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            return;
                        }
                        else
                        {
                            reply.Attachments = Respuestas.GetAgregarColor();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta2);
                            await context.PostAsync(reply);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = Respuestas.GetAgregarColor();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta2);
                    await context.PostAsync(reply);
                    return;
                }
                // -------------------------------------------------------------------
                // La primera parte de la pregunta es tamaño fuente
                else if (palabra1 == "tamañodefuente" || palabra1 == "tamañosdefuentes" || palabra1 == "tamaño de fuente")
                {
                    // Se detectó  la segunda parte de la pregunta
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");
                        if (palabra2 == "lista" || palabra2 == "listas")
                        {
                            // Se detectó  la tercera parte de la pregunta
                            foreach (var entityP3 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra3"))
                            {
                                var palabra3 = entityP3.Entity.ToLower().Replace(" ", "");
                                if (palabra3 == "mensaje" || palabra3 == "mensajes" || palabra3 == "correo" || palabra3 == "correo")
                                {
                                    reply.Attachments = Respuestas.GetCambiarTamanoFuenteListaMensajes();
                                    await context.PostAsync(confirmacionRespuesta1);
                                    await context.PostAsync(preguntaConsulta);
                                    await context.PostAsync(reply);
                                    return;
                                }
                                else
                                {
                                    reply.Attachments = Respuestas.GetCrearDiseñosFondoParaMensajes();
                                    await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra3}'?");
                                    reply.Attachments = Respuestas.GetCambiarTamanoFuenteListaMensajes();
                                    await context.PostAsync(reply);
                                    return;
                                }
                            }
                            // No se detectó la tercera parte de la pregunta
                            reply.Attachments = Respuestas.GetCambiarTamanoFuenteListaMensajes();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(preguntaConsulta);
                            await context.PostAsync(reply);
                            return;
                        }
                        else
                        {
                            reply.Attachments = Respuestas.GetCambiarTamanoFuenteListaMensajes();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = Respuestas.GetCambiarTamanoFuenteListaMensajes();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
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
                            reply.Attachments = Respuestas.GetCambiarNombreCategoriaColor();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            return;
                        }
                        else
                        {
                            reply.Attachments = Respuestas.GetCambiarNombreCategoriaColor();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = Respuestas.GetCambiarNombreCategoriaColor();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
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
                            reply.Attachments = Respuestas.GetCrearFirmaMensaje();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = Respuestas.GetCrearFirmaMensaje();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = Respuestas.GetCrearFirmaMensaje();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
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
                                    reply.Attachments = Respuestas.GetCambiarConfiguracionGruposEnvios();
                                    await context.PostAsync(confirmacionRespuesta1);
                                    await context.PostAsync(preguntaConsulta);
                                    await context.PostAsync(reply);
                                    return;
                                }
                                else
                                {
                                    reply.Attachments = Respuestas.GetCambiarConfiguracionGruposEnvios();
                                    await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra3}'?");
                                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                                    await context.PostAsync(reply);
                                    return;
                                }
                            }
                            // No se detectó la segunda parte de la pregunta
                            reply.Attachments = Respuestas.GetCambiarConfiguracionGruposEnvios();
                            await context.PostAsync(preguntaNoRegistrada1);
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            return;
                        }
                        else
                        {
                            reply.Attachments = Respuestas.GetCambiarConfiguracionGruposEnvios();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = Respuestas.GetCambiarConfiguracionGruposEnvios();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
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
                                    reply.Attachments = Respuestas.GetCambiarUbicacionGuardanMensajes();
                                    await context.PostAsync(confirmacionRespuesta1);
                                    await context.PostAsync(preguntaConsulta);
                                    await context.PostAsync(reply);
                                    return;
                                }
                                else
                                {
                                    reply.Attachments = Respuestas.GetCambiarUbicacionGuardanMensajes();
                                    await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra3}'?");
                                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                                    await context.PostAsync(reply);
                                    return;
                                }
                            }
                            reply.Attachments = Respuestas.GetCambiarUbicacionGuardanMensajes();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            return;
                        }
                        else
                        {
                            reply.Attachments = Respuestas.GetCambiarUbicacionGuardanMensajes();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = Respuestas.GetCambiarUbicacionGuardanMensajes();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
                    return;
                }
                else if (palabra1 == "cita" || palabra1 == "citas" || palabra1 == "eventos" || palabra1 == "evento" || palabra1 == "reunión" || palabra1 == "reuniones")
                {
                    reply.Attachments = Respuestas.GetCambiarCitaOutlook();
                    await context.PostAsync(confirmacionRespuesta1);
                    await context.PostAsync(reply);
                    return;
                }
                else if (palabra1 == "nivel" || palabra1 == "niveles" || palabra1 == "level" || palabra1 == "levels")
                {
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");
                        if (palabra2 == "nodeseado" || palabra2 == "nodeseados" || palabra2 == "detestables" || palabra2 == "detestable" || palabra2 == "bloqueado" || palabra2 == "bloqueados")
                        {
                            reply.Attachments = Respuestas.GetCambiarNivelProteccionFiltroCorreo();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(preguntaConsulta);
                            await context.PostAsync(reply);
                            return;
                        }
                        else
                        {
                            reply.Attachments = Respuestas.GetCambiarNivelProteccionFiltroCorreo();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            return;
                        }
                    }
                    // Si el usuario no ingreso la segunda parte de la pregunta
                    await context.PostAsync($"Lo siento, su pregunta no esta registrada");
                    await context.PostAsync("O tal vez no escribió la pregunta correctamente");
                    return;
                }
                else
                {
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = Respuestas.GetCambiarNivelProteccionFiltroCorreo();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
                    return;
                }
            }
            // Si el usuario no ingreso la primera parte de la pregunta
            await context.PostAsync(preguntaNoRegistrada2);
            reply.Attachments = Respuestas.GetConsultaV2();
            await context.PostAsync(reply);
            await context.PostAsync("O tal vez no escribió la pregunta correctamente");
            return;
        }
    }
}