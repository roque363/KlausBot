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
using Microsoft.Bot.Builder.FormFlow;

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

            // Recorrido de la primera parte de la pregunta
            foreach (var entityP1 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra1"))
            {
                var palabra1 = entityP1.Entity.ToLower().Replace(" ", "");
                if (palabra1 == "contacto" || palabra1 == "contactos" || palabra1 == "nombres" || palabra1 == "nombre" || palabra1 == "personas" || palabra1 == "persona" || palabra1 == "contactos" || palabra1 == "contacto" || palabra1 == "correos" || palabra1 == "correo" || palabra1 == "emails" || palabra1 == "email" || palabra1 == "correoselectronicos" || palabra1 == "correoselectrónicos" || palabra1 == "correoelectronico" || palabra1 == "correoelectrónico")
                {
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");
                        if (palabra2 == "lista" || palabra2 == "listas" || palabra2 == "grupos" || palabra2 == "grupo")
                        {
                            foreach (var entityP3 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra3"))
                            {
                                var palabra3 = entityP3.Entity.ToLower().Replace(" ", "");
                                if (palabra3 == "bloqueados" || palabra3 == "bloqueado" || palabra3 == "nodeseados" || palabra3 == "nodeseadas" || palabra3 == "detestable" || palabra3 == "detestables")
                                {
                                    reply.Attachments = Respuestas.GetNombresListasBloqueados();
                                    await context.PostAsync(reply);
                                    //context.Wait(MessageReceived);
                                    return;
                                }
                                else if (palabra3 == "contacto" || palabra3 == "contactos")
                                {
                                    reply.Attachments = Respuestas.GetAgregarContactoListaContactos();
                                    await context.PostAsync(reply);
                                    //context.Wait(MessageReceived);
                                    return;
                                }
                                else
                                {
                                    await context.PostAsync($"¿{palabra3}?, por favor vuelva a escribir la consulta correctamente");
                                    //context.Wait(MessageReceived);
                                    return;
                                }
                            }
                            reply.Attachments = Respuestas.GetAgregarContactoListaContactos();
                            await context.PostAsync(reply);
                            //context.Wait(MessageReceived);
                            return;
                        }
                        else if (palabra2 == "categoria" || palabra2 == "categorias" || palabra2 == "categorías" || palabra2 == "categoría")
                        {
                            reply.Attachments = Respuestas.GetAgregarPersonasCategoriasColor();
                            await context.PostAsync(reply);
                            //context.Wait(MessageReceived);
                            return;
                        }
                        else
                        {
                            await context.PostAsync($"¿{palabra2}?, por favor vuelva a escribir la consulta correctamente");
                            //context.Wait(MessageReceived);
                            return;
                        }

                    }

                    reply.Attachments = Respuestas.GetAgregarContacto();
                    await context.PostAsync(reply);
                    //context.Wait(MessageReceived);
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
                            await context.PostAsync(reply);
                            //context.Wait(MessageReceived);
                            return;
                        }
                        else
                        {
                            await context.PostAsync($"¿{palabra2}?, por favor vuelva a escribir la consulta correctamente");
                            //context.Wait(MessageReceived);
                            return;
                        }

                    }

                }
                else if (palabra1 == "tabla" || palabra1 == "tablas")
                {
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");
                        if (palabra2 == "mensajes" || palabra2 == "mensaje")
                        {
                            reply.Attachments = Respuestas.GetAgregarTablasMensajeOutlook();
                            await context.PostAsync(reply);
                            //context.Wait(MessageReceived);
                            return;
                        }
                        else
                        {
                            await context.PostAsync($"¿{palabra2}?, por favor vuelva a escribir la consulta correctamente");
                            //context.Wait(MessageReceived);
                            return;
                        }

                    }

                }
                else if (palabra1 == "confirmaciones" || palabra1 == "conformación" || palabra1 == "confirmacion")
                {
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");
                        if (palabra2 == "lectura" || palabra2 == "lecturas")
                        {
                            reply.Attachments = Respuestas.GetAgregarConfirmacionLecturaNotificacionEntrega();
                            await context.PostAsync(reply);
                            //context.Wait(MessageReceived);
                            return;
                        }
                        else if (palabra2 == "entregas" || palabra2 == "entrega")
                        {
                            reply.Attachments = Respuestas.GetAgregarConfirmacionEntregaRealizarSeguimiento();
                            await context.PostAsync(reply);
                            //context.Wait(MessageReceived);
                            return;
                        }
                        else
                        {
                            await context.PostAsync($"¿{palabra2}?, por favor vuelva a escribir la consulta correctamente");
                            //context.Wait(MessageReceived);
                            return;
                        }

                    }
                }
                else if (palabra1 == "notificaciones" || palabra1 == "notificación" || palabra1 == "notificacion")
                {
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");
                        if (palabra2 == "entrega" || palabra2 == "entregas")
                        {
                            reply.Attachments = Respuestas.GetAgregarConfirmacionLecturaNotificacionEntrega();
                            await context.PostAsync(reply);
                            //context.Wait(MessageReceived);
                            return;
                        }
                        else
                        {
                            await context.PostAsync($"¿{palabra2}?, por favor vuelva a escribir la consulta correctamente");
                            //context.Wait(MessageReceived);
                            return;
                        }

                    }
                }
                else if (palabra1 == "seguimiento" || palabra1 == "seguimientos")
                {
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");
                        if (palabra2 == "mensaje" || palabra2 == "mensajes")
                        {
                            reply.Attachments = Respuestas.GetAgregarSeguimientoMensajesOutlook();
                            await context.PostAsync(reply);
                            //context.Wait(MessageReceived);
                            return;
                        }
                        else
                        {
                            await context.PostAsync($"¿{palabra2}?, por favor vuelva a escribir la consulta correctamente");
                            //context.Wait(MessageReceived);
                            return;
                        }

                    }
                }
                else if (palabra1 == "díasnolaborables" || palabra1 == "diasnolaborables" || palabra1 == "feriados" || palabra1 == "feriado")
                {
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");
                        if (palabra2 == "calendario" || palabra2 == "calendarios")
                        {
                            reply.Attachments = Respuestas.GetAgregarFeriadosCalendarioOutlook();
                            await context.PostAsync(reply);
                            //context.Wait(MessageReceived);
                            return;
                        }
                        else
                        {
                            await context.PostAsync($"¿{palabra2}?, por favor vuelva a escribir la consulta correctamente");
                            //context.Wait(MessageReceived);
                            return;
                        }

                    }
                }
                else
                {
                    await context.PostAsync($"¿{palabra1}?, por favor vuelva a escribir la consulta correctamente");
                    //context.Wait(MessageReceived);
                    return;
                }

            }
        }


    }
}