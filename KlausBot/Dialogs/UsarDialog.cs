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

            foreach (var entityP1 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra1"))
            {
                var palabra1 = entityP1.Entity.ToLower().Replace(" ", "");

                if (palabra1 == "@menciones" || palabra1 == "@" || palabra1 == "@mencion")
                {
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");

                        if (palabra2 == "atención" || palabra2 == "atencion")
                        {
                            reply.Attachments = Respuestas.GetUsarArrobaLlamarAtencion();
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
                    // Si el usuario no ingreso la segunda parte de la pregunta
                    await context.PostAsync($"Lo siento, su pregunta no esta registrada");
                    reply.Attachments = Respuestas.GetConsultaV2();
                    await context.PostAsync(reply);
                    await context.PostAsync("O tal vez no escribió la pregunta correctamente");
                    return;
                }
                else if (palabra1 == "asistente")
                {
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");

                        if (palabra2 == "programación" || palabra2 == "programacion")
                        {
                            reply.Attachments = Respuestas.GetUsarAsistenteProgramacion();
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
                    // Si el usuario no ingreso la segunda parte de la pregunta
                    await context.PostAsync($"Lo siento, su pregunta no esta registrada");
                    reply.Attachments = Respuestas.GetConsultaV2();
                    await context.PostAsync(reply);
                    await context.PostAsync("O tal vez no escribió la pregunta correctamente");
                    return;
                }
                else if (palabra1 == "calendarios" || palabra1 == "calendario")
                {
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");

                        if (palabra2 == "adecuada" || palabra2 == "recomendados" || palabra2 == "mejorforma" || palabra2 == "adecuadas")
                        {
                            reply.Attachments = Respuestas.GetUsarCalendarioManeraAdecuadaOutlook();
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
                    // Si el usuario no ingreso la segunda parte de la pregunta
                    await context.PostAsync($"Lo siento, su pregunta no esta registrada");
                    reply.Attachments = Respuestas.GetConsultaV2();
                    await context.PostAsync(reply);
                    await context.PostAsync("O tal vez no escribió la pregunta correctamente");
                    return;
                }
                else if (palabra1 == "carpeta" || palabra1 == "carpetas")
                {
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");

                        if (palabra2 == "busqueda" || palabra2 == "búsqueda" || palabra2 == "busquedas" || palabra2 == "búsquedas")
                        {
                            reply.Attachments = Respuestas.GetUsarCrearCarpetasBusqueda();
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
                    // Si el usuario no ingreso la segunda parte de la pregunta
                    await context.PostAsync($"Lo siento, su pregunta no esta registrada");
                    reply.Attachments = Respuestas.GetConsultaV2();
                    await context.PostAsync(reply);
                    await context.PostAsync("O tal vez no escribió la pregunta correctamente");
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
                                    reply.Attachments = Respuestas.GetUsarFiltrosCorreoNoDeseadoControlarMensajes();
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
                            // Si el usuario no ingreso la tercera parte de la pregunta
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada");
                            reply.Attachments = Respuestas.GetConsultaV2();
                            await context.PostAsync(reply);
                            await context.PostAsync("O tal vez no escribió la pregunta correctamente");
                            return;
                        }
                        else
                        {
                            await context.PostAsync($"¿{palabra2}?, por favor vuelva a escribir la consulta correctamente");
                            //context.Wait(MessageReceived);
                            return;
                        }
                    }
                    // Si el usuario no ingreso la segunda parte de la pregunta
                    await context.PostAsync($"Lo siento, su pregunta no esta registrada");
                    reply.Attachments = Respuestas.GetConsultaV2();
                    await context.PostAsync(reply);
                    await context.PostAsync("O tal vez no escribió la pregunta correctamente");
                    return;
                }
                else if (palabra1 == "limpieza")
                {
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");

                        if (palabra2 == "conversación" || palabra2 == "conversaciones" || palabra2 == "charla" || palabra2 == "charlas")
                        {
                            reply.Attachments = Respuestas.GetUsarLimpiezaConversacion();
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
                    // Si el usuario no ingreso la segunda parte de la pregunta
                    await context.PostAsync($"Lo siento, su pregunta no esta registrada");
                    reply.Attachments = Respuestas.GetConsultaV2();
                    await context.PostAsync(reply);
                    await context.PostAsync("O tal vez no escribió la pregunta correctamente");
                    return;
                }
                else if (palabra1 == "correos" || palabra1 == "correo")
                {
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");

                        if (palabra2 == "mensajes" || palabra2 == "mensaje")
                        {
                            reply.Attachments = Respuestas.GetUsarCorreosOrganizarBajaPrioridad();
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
                    // Si el usuario no ingreso la segunda parte de la pregunta
                    await context.PostAsync($"Lo siento, su pregunta no esta registrada");
                    reply.Attachments = Respuestas.GetConsultaV2();
                    await context.PostAsync(reply);
                    await context.PostAsync("O tal vez no escribió la pregunta correctamente");
                    return;
                }
                else
                {
                    await context.PostAsync($"Lo siento, su pregunta no esta registrada");
                    await context.PostAsync($"O tal vez no escribió correctamente la palabra '{palabra1}'?");
                    //context.Wait(MessageReceived);
                    return;
                }

            }
            // Si el usuario no ingreso la primera parte de la pregunta
            await context.PostAsync($"Lo siento, su pregunta no esta registrada");
            reply.Attachments = Respuestas.GetConsultaV2();
            await context.PostAsync(reply);
            await context.PostAsync("O tal vez no escribió la pregunta correctamente");
            return;
        }
    }
}