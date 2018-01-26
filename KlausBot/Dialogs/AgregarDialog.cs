using System;
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
    public class AgregarDialog
    {
        private IDialogContext context;
        private LuisResult result;

        public AgregarDialog(IDialogContext context, LuisResult result)
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

            // Recorrido de la primera parte de la pregunta
            foreach (var entityP1 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra1"))
            {
                var palabra1 = entityP1.Entity.ToLower().Replace(" ", "");
                if (palabra1 == "contacto" || palabra1 == "contactos" || palabra1 == "nombres" || palabra1 == "nombre" || palabra1 == "personas" || palabra1 == "persona" || palabra1 == "contactos" || palabra1 == "contacto" || palabra1 == "correos" || palabra1 == "correo" || palabra1 == "emails" || palabra1 == "email" || palabra1 == "correoselectronicos" || palabra1 == "correoselectrónicos" || palabra1 == "correoelectronico" || palabra1 == "correoelectrónico")
                {
                    // Recorrido de la segunda parte de la pregunta
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");
                        if (palabra2 == "lista" || palabra2 == "listas" || palabra2 == "grupos" || palabra2 == "grupo")
                        {
                            // Recorrido de la tercera parte de la pregunta
                            foreach (var entityP3 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra3"))
                            {
                                var palabra3 = entityP3.Entity.ToLower().Replace(" ", "");
                                if (palabra3 == "bloqueados" || palabra3 == "bloqueado" || palabra3 == "nodeseados" || palabra3 == "nodeseadas" || palabra3 == "detestable" || palabra3 == "detestables")
                                {
                                    reply.Attachments = Respuestas.GetNombresListasBloqueados();
                                    await context.PostAsync(confirmacionRespuesta1);
                                    await context.PostAsync(reply);
                                    return;
                                }
                                else if (palabra3 == "contacto" || palabra3 == "contactos")
                                {
                                    reply.Attachments = Respuestas.GetAgregarContactoListaContactos();
                                    await context.PostAsync(confirmacionRespuesta1);
                                    await context.PostAsync(reply);
                                    return;
                                }
                                else
                                {
                                    reply.Attachments = Respuestas.GetContactoYLista();
                                    await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra3}'?");
                                    await context.PostAsync(opcionSecundarioDeRespuesta2);
                                    await context.PostAsync(reply);
                                    return;
                                }
                            }
                            // No se detectó la tercera parte de la pregunta
                            reply.Attachments = Respuestas.GetContactoYLista();
                            await context.PostAsync(preguntaNoRegistrada1);
                            await context.PostAsync(opcionSecundarioDeRespuesta2);
                            await context.PostAsync(reply);
                            return;
                        }
                        else if (palabra2 == "categoria" || palabra2 == "categorias" || palabra2 == "categorías" || palabra2 == "categoría")
                        {
                            reply.Attachments = Respuestas.GetAgregarPersonasCategoriasColor();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            return;
                        }
                        else
                        {
                            reply.Attachments = Respuestas.GetContactoYListaYCategorias();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta2);
                            await context.PostAsync(reply);
                            return;
                        }

                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = Respuestas.GetContactoYListaYCategorias();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta2);
                    await context.PostAsync(reply);
                    return;
                }
                else if (palabra1 == "graficos" || palabra1 == "grafico" || palabra1 == "gráficos" || palabra1 == "gráfico")
                {
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");
                        if (palabra2 == "mensajes" || palabra2 == "mensaje")
                        {
                            reply.Attachments = Respuestas.GetAgregarGraficosMensajesOutlook();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            //context.Wait(MessageReceived);
                            return;
                        }
                        else
                        {
                            reply.Attachments = Respuestas.GetAgregarGraficosMensajesOutlook();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = Respuestas.GetAgregarGraficosMensajesOutlook();
                    await context.PostAsync($"Quizás desees saber como agregar gráficos a tus mensajes de Outlook, mira, tengo esto: ");
                    await context.PostAsync(reply);
                    return;
                }
                else if (palabra1 == "tabla" || palabra1 == "tablas")
                {
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");
                        if (palabra2 == "mensajes" || palabra2 == "mensaje")
                        {
                            reply.Attachments = Respuestas.GetAgregarTablasMensajeOutlook();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            return;
                        }
                        else
                        {
                            reply.Attachments = Respuestas.GetAgregarTablasMensajeOutlook();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = Respuestas.GetAgregarTablasMensajeOutlook();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
                    return;
                }
                else if (palabra1 == "confirmaciones" || palabra1 == "conformación" || palabra1 == "confirmacion")
                {
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");
                        if (palabra2 == "lectura" || palabra2 == "lecturas")
                        {
                            reply.Attachments = Respuestas.GetAgregarConfirmacionLecturaNotificacionEntrega();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            return;
                        }
                        else if (palabra2 == "entregas" || palabra2 == "entrega")
                        {
                            reply.Attachments = Respuestas.GetAgregarConfirmacionEntregaRealizarSeguimiento();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            return;
                        }
                        else
                        {
                            reply.Attachments = Respuestas.GetAgregarConfirmacionLecturaNotificacionEntregaYLectura();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = Respuestas.GetAgregarConfirmacionLecturaNotificacionEntregaYLectura();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta2);
                    await context.PostAsync(reply);
                    return;
                }
                else if (palabra1 == "notificaciones" || palabra1 == "notificación" || palabra1 == "notificacion")
                {
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");
                        if (palabra2 == "entrega" || palabra2 == "entregas")
                        {
                            reply.Attachments = Respuestas.GetAgregarConfirmacionLecturaNotificacionEntrega();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            return;
                        }
                        else
                        {
                            reply.Attachments = Respuestas.GetAgregarConfirmacionLecturaNotificacionEntrega();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = Respuestas.GetAgregarConfirmacionLecturaNotificacionEntrega();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
                    return;
                }
                else if (palabra1 == "seguimiento" || palabra1 == "seguimientos")
                {
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");
                        if (palabra2 == "mensaje" || palabra2 == "mensajes")
                        {
                            reply.Attachments = Respuestas.GetAgregarSeguimientoMensajesOutlook();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            return;
                        }
                        else
                        {
                            reply.Attachments = Respuestas.GetAgregarSeguimientoMensajesOutlook();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = Respuestas.GetAgregarSeguimientoMensajesOutlook();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
                    return;
                }
                else if (palabra1 == "díasnolaborables" || palabra1 == "diasnolaborables" || palabra1 == "feriados" || palabra1 == "feriado")
                {
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");
                        if (palabra2 == "calendario" || palabra2 == "calendarios")
                        {
                            reply.Attachments = Respuestas.GetAgregarFeriadosCalendarioOutlook();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            return;
                        }
                        else
                        {
                            reply.Attachments = Respuestas.GetAgregarFeriadosCalendarioOutlook();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = Respuestas.GetAgregarFeriadosCalendarioOutlook();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
                    return;
                }
                else if (palabra1 == "firmas" || palabra1 == "firma")
                {
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");
                        if (palabra2 == "mensajes" || palabra2 == "mensaje")
                        {
                            reply.Attachments = Respuestas.GetCrearFirmaMensaje();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            return;
                        }
                        else
                        {
                            reply.Attachments = Respuestas.GetCrearFirmaMensaje();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            return;
                        }

                    }
                    reply.Attachments = Respuestas.GetCrearFirmaMensaje();
                    await context.PostAsync($"Quizás desea saber como agregar una firma en mensajes de correo, acá tengo esto:");
                    await context.PostAsync(reply);
                    await context.PostAsync($"Caso contrario, la pregunta no se encuentra registrada o vuelva a escribir correctamente la pregunta.");
                    return;
                }
                else if (palabra1 == "tarjetas" || palabra1 == "tarjeta")
                {
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");
                        if (palabra2 == "firma" || palabra2 == "firmas")
                        {
                            reply.Attachments = Respuestas.GetIncluirTarjetaPresentacionFirmaCorreo();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            return;
                        }
                        else
                        {
                            reply.Attachments = Respuestas.GetIncluirTarjetaPresentacionFirmaCorreo();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            return;
                        }

                    }
                    await context.PostAsync($"Quizás desea saber como añadir una tarjeta de presentación electrónica en una firma de correo, acá tengo esto:");
                    reply.Attachments = Respuestas.GetIncluirTarjetaPresentacionFirmaCorreo();
                    await context.PostAsync(reply);
                    await context.PostAsync($"Caso contrario, la pregunta no se encuentra registrada o vuelva a escribir correctamente la pregunta.");
                    return;
                }
                else if (palabra1 == "hipervínculo" || palabra1 == "hipervinculo" || palabra1 == "hipervínculos" || palabra1 == "hipervinculos")
                {
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");
                        if (palabra2 == "firma" || palabra2 == "firmas")
                        {
                            reply.Attachments = Respuestas.GetInsertarHipervinculosFirmaCorreo();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            return;
                        }
                        else
                        {
                            reply.Attachments = Respuestas.GetInsertarHipervinculosFirmaCorreo();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            return;
                        }

                    }
                    await context.PostAsync($"Quizás desea saber como incluir un hipervínculo de una red social a tu firma de correo electrónico, tengo esto: ");
                    reply.Attachments = Respuestas.GetInsertarHipervinculosFirmaCorreo();
                    await context.PostAsync(reply);
                    await context.PostAsync($"Caso contrario, la pregunta no se encuentra registrada o vuelva a escribir correctamente la pregunta.");
                    return;
                }
                else if (palabra1 == "archivos" || palabra1 == "archivo")
                {
                    foreach (var entity in result.Entities.Where(Entity => Entity.Type == "Servicio"))
                    {
                        var serv = entity.Entity.ToLower().Replace(" ", "");
                        if (serv == "outlook" || serv == "outlok")
                        {
                            reply.Attachments = Respuestas.GetAdjuntarArchivosOutlook();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            return;
                        }
                        else if (serv == "word" || serv == "wrd")
                        {
                            reply.Attachments = Respuestas.GetAgregarArchivosWord();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            return;
                        }
                        else if (serv == "excel" || serv == "excl")
                        {
                            reply.Attachments = Respuestas.GetAdjuntarArchivosExcel();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            return;
                        }
                        else if (serv == "powerpoint" || serv == "pwrpoint" || serv == "pwrpt" || serv == "powerpt")
                        {
                            reply.Attachments = Respuestas.GetAdjuntarArchivosPowerPoint();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            return;
                        }
                        else if (serv == "onenote" || serv == "noenote" || serv == "note")
                        {
                            reply.Attachments = Respuestas.GetAgregarArchivosOneNote();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
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

                    //obtener el producto si este a sido escogido anteriormente
                    var servicio = "Servicio";
                    context.PrivateConversationData.TryGetValue<string>("tipoServicio", out servicio);
                    switch (servicio)
                    {
                        case "Word":
                            reply.Attachments = Respuestas.GetAgregarArchivosWord();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            context.PrivateConversationData.SetValue<string>("tipoServicio", "Servicio");
                            return;

                        case "Outlook":
                            reply.Attachments = Respuestas.GetAdjuntarArchivosOutlook();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            context.PrivateConversationData.SetValue<string>("tipoServicio", "Servicio");
                            return;
                        case "Excel":
                            reply.Attachments = Respuestas.GetAdjuntarArchivosExcel();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            context.PrivateConversationData.SetValue<string>("tipoServicio", "Servicio");
                            return;
                        case "PowerPoint":
                            reply.Attachments = Respuestas.GetAdjuntarArchivosPowerPoint();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            context.PrivateConversationData.SetValue<string>("tipoServicio", "Servicio");
                            return;
                        case "OneNote":
                            reply.Attachments = Respuestas.GetAgregarArchivosOneNote();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            context.PrivateConversationData.SetValue<string>("tipoServicio", "Servicio");
                            return;
                    }

                    await context.PostAsync("Por favor haga click en 'Consulta' o escribalo, seleccione el servicio y vuelva a hacer la pregunta.");
                    reply.Attachments = Respuestas.GetConsulta();
                    await context.PostAsync(reply);
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