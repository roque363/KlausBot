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
    public class EliminarDialog
    {
        private IDialogContext context;
        private LuisResult result;

        public EliminarDialog(IDialogContext context, LuisResult result)
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
            var accion = "Eliminar";
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
                context.PrivateConversationData.SetValue<string>("Palabra1", palabra1);
                // -------------------------------------------------------------------
                if (palabra1 == "categoría" || palabra1 == "categorías" || palabra1 == "categoria" || palabra1 == "categorias")
                {
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");
                        if (palabra2 == "color")
                        {
                            reply.Attachments = RespuestasOutlook.GetEliminarCategoriaColor();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = RespuestasOutlook.GetEliminarCategoriaColor();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = RespuestasOutlook.GetEliminarCategoriaColor();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    return;
                }
                else if (palabra1 == "archivos" || palabra1 == "archivo" || palabra1 == "carpetas" || palabra1 == "carpeta")
                {
                    reply.Attachments = RespuestasOneDrive.GetEliminarArchivosCarpetasOneDrive();
                    await context.PostAsync(confirmacionRespuesta1);
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                    return;
                }
                else if (palabra1 == "comentario" || palabra1 == "comentarios")
                {
                    foreach (var entity in result.Entities.Where(Entity => Entity.Type == "Servicio"))
                    {
                        var serv = entity.Entity.ToLower().Replace(" ", "");
                        if (serv == "word")
                        {
                            reply.Attachments = RespuestasWord.GetQuitarComentariosWord();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else if (serv == "powerpoint")
                        {
                            reply.Attachments = RespuestasPowerPoint.GetEliminarComentariosPowerPoint();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                        }
                        else
                        {
                            reply.Attachments = Respuestas.GetEliminarComentarios();
                            await context.PostAsync($"Lo siento, {serv} no esta registrado, consulte otra vez el servicio escribiendo ayuda");
                            await context.PostAsync(opcionSecundarioDeRespuesta2);
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
                        reply.Attachments = RespuestasWord.GetQuitarComentariosWord();
                        await context.PostAsync(confirmacionRespuesta1);
                        await context.PostAsync(reply);
                        await context.PostAsync(preguntaConsulta);
                        context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                        context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                        return;
                    }
                    else if (servicio == "PowerPoint")
                    {
                        reply.Attachments = RespuestasPowerPoint.GetEliminarComentariosPowerPoint();
                        await context.PostAsync(confirmacionRespuesta1);
                        await context.PostAsync(reply);
                        await context.PostAsync(preguntaConsulta);
                        context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                        context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                        return;
                    }
                    else
                    {
                        reply.Attachments = Respuestas.GetEliminarComentarios();
                        await context.PostAsync(preguntaNoRegistrada1);
                        await context.PostAsync(opcionSecundarioDeRespuesta2);
                        await context.PostAsync(reply);
                        context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                        return;
                    }
                }
                else if (palabra1 == "marca" || palabra1 == "marcas" || palabra1 == "marcasderevisión" || palabra1 == "marcasderevision")
                {
                    reply.Attachments = RespuestasWord.GetQuitarMarcasRevision();
                    await context.PostAsync(confirmacionRespuesta1);
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                    return;
                }
                else if (palabra1 == "hipervínculo" || palabra1 == "hipervinculo" || palabra1 == "hipervínculos" || palabra1 == "hipervinculos")
                {
                    reply.Attachments = RespuestasWord.GetQuitarHipervinculos();
                    await context.PostAsync(confirmacionRespuesta1);
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                    return;
                }
                else if (palabra1 == "salto" || palabra1 == "saltos")
                {
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");
                        if (palabra2 == "página" || palabra2 == "pagina")
                        {
                            reply.Attachments = RespuestasWord.GetQuitarSaltoPagina();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else if (palabra2 == "sección" || palabra2 == "seccion")
                        {
                            reply.Attachments = RespuestasWord.GetEliminarSaltoSeccion();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = RespuestasWord.GetQuitarSaltoPaginaEliminarSaltoSeccion();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta2);
                            await context.PostAsync(reply);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = RespuestasWord.GetQuitarSaltoPaginaEliminarSaltoSeccion();
                    await context.PostAsync(preguntaNoRegistrada2);
                    await context.PostAsync(opcionSecundarioDeRespuesta2);
                    await context.PostAsync(reply);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    return;
                }
                else if (palabra1 == "número" || palabra1 == "numero" || palabra1 == "números" || palabra1 == "numeros")
                {
                    reply.Attachments = RespuestasWord.GetQuitarNumerosPagina();
                    await context.PostAsync(confirmacionRespuesta1);
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                    return;
                }
                else if (palabra1 == "encabezados" || palabra1 == "encabezado" || palabra1 == "piedepágina" || palabra1 == "piedepagina" || palabra1 == "piesdepágina" || palabra1 == "piesdepagina")
                {
                    foreach (var entity in result.Entities.Where(Entity => Entity.Type == "Servicio"))
                    {
                        var serv = entity.Entity.ToLower().Replace(" ", "");
                        if (serv == "word")
                        {
                            reply.Attachments = RespuestasWord.GetEliminarCambiarEncabezadoPiePagina();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else if (serv == "powerpoint")
                        {
                            reply.Attachments = RespuestasPowerPoint.GetEliminarCambiarInformacionEncabezadoPiePagina();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = RespuestasPowerPoint.GetEliminarCambiarEncabezadoPiePaginaWordPowerPoint();
                            await context.PostAsync($"Lo siento, {serv} no esta registrado, consulte otra vez el servicio escribiendo ayuda");
                            await context.PostAsync(opcionSecundarioDeRespuesta2);
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
                        reply.Attachments = RespuestasWord.GetEliminarCambiarEncabezadoPiePagina();
                        await context.PostAsync(confirmacionRespuesta1);
                        await context.PostAsync(reply);
                        await context.PostAsync(preguntaConsulta);
                        context.PrivateConversationData.SetValue<string>("tipoServicio", "Word");
                        context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                        context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                        return;
                    }
                    else if (servicio == "Power Point" || servicio == "PowerPoint")
                    {
                        reply.Attachments = RespuestasPowerPoint.GetEliminarCambiarInformacionEncabezadoPiePagina();
                        await context.PostAsync(confirmacionRespuesta1);
                        await context.PostAsync(reply);
                        await context.PostAsync(preguntaConsulta);
                        context.PrivateConversationData.SetValue<string>("tipoServicio", "PowerPoint");
                        context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                        context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                        return;
                    }
                    else
                    {
                        reply.Attachments = RespuestasPowerPoint.GetEliminarCambiarEncabezadoPiePaginaWordPowerPoint();
                        await context.PostAsync(preguntaNoRegistrada1);
                        await context.PostAsync(opcionSecundarioDeRespuesta1);
                        await context.PostAsync(reply);
                        context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                        return;
                    }
                }
                else if (palabra1 == "marcadeagua" || palabra1 == "marcasdeagua")
                {
                    // Recorrido del Servicio de la pregunta
                    foreach (var entity in result.Entities.Where(Entity => Entity.Type == "Servicio"))
                    {
                        var serv = entity.Entity.ToLower().Replace(" ", "");
                        if (serv == "word")
                        {
                            reply.Attachments = RespuestasWord.GetQuitarMarcaAgua();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("tipoServicio", "Word");
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else if (serv == "powerpoint")
                        {
                            reply.Attachments = RespuestasPowerPoint.GetQuitarMarcaAguaDiapositivas();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("tipoServicio", "PowerPoint");
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = Respuestas.GetQuitarMarcaAgua();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, no se tiene registrado el servicio '{serv}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta2);
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
                    if (servicio == "Word")
                    {
                        reply.Attachments = RespuestasWord.GetQuitarMarcaAgua();
                        await context.PostAsync(confirmacionRespuesta1);
                        await context.PostAsync(reply);
                        await context.PostAsync(preguntaConsulta);
                        context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                        context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                        return;
                    }
                    else if (servicio == "PowerPoint")
                    {
                        reply.Attachments = RespuestasPowerPoint.GetQuitarMarcaAguaDiapositivas();
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
                        reply.Attachments = Respuestas.GetQuitarMarcaAgua();
                        await context.PostAsync(preguntaNoRegistrada1);
                        await context.PostAsync(opcionSecundarioDeRespuesta2);
                        await context.PostAsync(reply);
                        await context.PostAsync(preguntaConsulta);
                        context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                        context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                        return;
                    }
                }
                else if (palabra1 == "contraseña" || palabra1 == "contraseñas")
                {
                    // Recorrido de la segunda parte de la pregunta
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");
                        if (palabra2 == "archivos" || palabra2 == "archivos" || palabra2 == "documento" || palabra2 == "documentos" || palabra2 == "hoja" || palabra2 == "hojas" || palabra2 == "libro" || palabra2 == "libros")
                        {
                            reply.Attachments = RespuestasExcel.GetQuitarContrasenaHojaCalculolibroExcel();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = RespuestasExcel.GetQuitarContrasenaHojaCalculolibroExcel();
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
                    reply.Attachments = RespuestasExcel.GetQuitarContrasenaHojaCalculolibroExcel();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    return;
                }
                else if (palabra1 == "valor" || palabra1 == "valores" || palabra1 == "variable" || palabra1 == "variables" || palabra1 == "palabra" || palabra1 == "palabras")
                {
                    // Recorrido de la segunda parte de la pregunta
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");
                        if (palabra2 == "duplicado" || palabra2 == "duplicados" || palabra2 == "duplicada" || palabra2 == "duplicadas")
                        {
                            reply.Attachments = RespuestasExcel.GetQuitarValoresDuplicados();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = RespuestasExcel.GetQuitarValoresDuplicados();
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
                    reply.Attachments = RespuestasExcel.GetQuitarValoresDuplicados();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    return;
                }
                else if (palabra1 == "duplicados" || palabra1 == "duplicado")
                {
                    reply.Attachments = RespuestasExcel.GetQuitarValoresDuplicados();
                    await context.PostAsync(confirmacionRespuesta1);
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                    return;
                }
                else if (palabra1 == "borde" || palabra1 == "bordes")
                {
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");
                        if (palabra2 == "celda" || palabra2 == "celdas")
                        {
                            reply.Attachments = RespuestasExcel.GetInsertarQuitarBordesCeldaHojaCalculo();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = RespuestasExcel.GetInsertarQuitarBordesCeldaHojaCalculo();
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
                    reply.Attachments = RespuestasExcel.GetInsertarQuitarBordesCeldaHojaCalculo();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    return;
                }
                else if (palabra1 == "formato" || palabra1 == "formatos")
                {
                    // Recorrido del Servicio de la pregunta
                    foreach (var entity in result.Entities.Where(Entity => Entity.Type == "Servicio"))
                    {
                        var serv = entity.Entity.ToLower().Replace(" ", "");
                        if (serv == "excel")
                        {
                            reply.Attachments = RespuestasExcel.GetQuitarFormatoCondicionalExcel();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("tipoServicio", "Excel");
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else if (serv == "word")
                        {
                            reply.Attachments = RespuestasWord.GetBorrarFormatoTexto();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("tipoServicio", "Word");
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else if (serv == "powerpoint")
                        {
                            reply.Attachments = RespuestasPowerPoint.GetBorrarFormatoTexto();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("tipoServicio", "PowerPoint");
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = Respuestas.GetBorrarFormatoWordExcel();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, no se tiene registrado el servicio '{serv}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta2);
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
                    if (servicio == "Excel")
                    {
                        reply.Attachments = RespuestasExcel.GetQuitarFormatoCondicionalExcel();
                        await context.PostAsync(confirmacionRespuesta1);
                        await context.PostAsync(reply);
                        await context.PostAsync(preguntaConsulta);
                        context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                        context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                        return;
                    }
                    else if (servicio == "Word")
                    {
                        reply.Attachments = RespuestasWord.GetBorrarFormatoTexto();
                        await context.PostAsync(confirmacionRespuesta1);
                        await context.PostAsync(reply);
                        await context.PostAsync(preguntaConsulta);
                        context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                        context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                        return;
                    }
                    else if (servicio == "PowerPoint")
                    {
                        reply.Attachments = RespuestasPowerPoint.GetBorrarFormatoTexto();
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
                        reply.Attachments = Respuestas.GetBorrarFormatoWordExcel();
                        await context.PostAsync(preguntaNoRegistrada1);
                        await context.PostAsync(opcionSecundarioDeRespuesta2);
                        await context.PostAsync(reply);
                        await context.PostAsync(preguntaConsulta);
                        context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                        context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                        return;
                    }
                }
                else if (palabra1 == "diapositiva" || palabra1 == "diapositivas")
                {
                    reply.Attachments = RespuestasPowerPoint.GetEliminarDiapositivas();
                    await context.PostAsync(confirmacionRespuesta1);
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                    return;
                }
                else if (palabra1 == "efecto" || palabra1 == "efectos")
                {
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");
                        if (palabra2 == "animación" || palabra2 == "animacion" || palabra2 == "animaciones")
                        {
                            reply.Attachments = RespuestasPowerPoint.GetQuitarEfectoAnimacion();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = RespuestasPowerPoint.GetQuitarEfectoAnimacion();
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
                    reply.Attachments = reply.Attachments = RespuestasPowerPoint.GetQuitarEfectoAnimacion();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    return;
                }
                else if (palabra1 == "animación" || palabra1 == "animacion" || palabra1 == "animaciones")
                {
                    reply.Attachments = RespuestasPowerPoint.GetQuitarEfectoAnimacion();
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