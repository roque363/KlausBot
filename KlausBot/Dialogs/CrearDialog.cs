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

            // Recorrido de la primera parte de la pregunta
            foreach (var entityP1 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra1"))
            {
                var palabra1 = entityP1.Entity.ToLower().Replace(" ", "");
                // -------------------------------------------------------------------
                // La primera parte de la pregunta es firma 
                if (palabra1 == "firma" || palabra1 == "firmas")
                {
                    // Recorrido de la segunda parte de la pregunta
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");

                        // La segunda parte de la prgunta es mensaje o correo
                        if (palabra2 == "mensaje" || palabra2 == "mensajes" || palabra2 == "correo" || palabra2 == "correos")
                        {
                            reply.Attachments = Respuestas.GetCrearFirmaMensaje();
                            await context.PostAsync(reply);
                            return;
                        }
                        else
                        {
                            await context.PostAsync("Lo siento, su pregunta no esta registrada");
                            await context.PostAsync($"O tal vez no escribió la correctamente '{palabra2}'?");
                            return;
                        }
                    }
                    // Si el usuario no ingreso la segunda parte de la pregunta
                    await context.PostAsync($"Lo siento, su pregunta no esta registrada");
                    await context.PostAsync("O tal vez no escribió la pregunta correctamente");
                    return;
                }
                // -------------------------------------------------------------------
                // La primera parte de la pregunta es categorías
                else if (palabra1 == "categoría" || palabra1 == "categoria" || palabra1 == "categorías" || palabra1 == "categorias")
                {
                    // Recorrido de la segunda parte de la pregunta
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");
                        // La segunda parte de la pregunta es colores
                        if (palabra2 == "color" || palabra2 == "colores")
                        {
                            reply.Attachments = Respuestas.GetCrearAsignarCategoriasColor();
                            await context.PostAsync(reply);
                            return;
                        }
                        else
                        {
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada");
                            await context.PostAsync($"O tal vez no escribió la correctamente '{palabra2}'?");
                            return;
                        }
                    }
                    // Si el usuario no ingreso la segunda parte de la pregunta
                    await context.PostAsync($"Lo siento, su pregunta no esta registrada");
                    await context.PostAsync($"O tal vez no escribió la pregunta correctamente");
                    return;
                }
                // -------------------------------------------------------------------
                // La primera parte de la pregunta es plantilla
                else if (palabra1 == "plantilla" || palabra1 == "plantillas")
                {
                    // Recorrido de la segunda parte de la pregunta
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");

                        if (palabra2 == "mensaje" || palabra2 == "mensajes")
                        {
                            reply.Attachments = Respuestas.GetCrearPlantillaMensajeCorreoElectronico();
                            await context.PostAsync(reply);
                            return;
                        }
                        else if (palabra2 == "correo" || palabra2 == "correos")
                        {
                            reply.Attachments = Respuestas.GetCrearPlantillaCorreoElectronico();
                            await context.PostAsync(reply);
                            return;
                        }
                        else
                        {
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada");
                            await context.PostAsync($"O tal vez no escribió correctamente '{palabra2}'?");
                            return;
                        }
                    }
                    // Si el usuario no ingreso la segunda parte de la pregunta
                    await context.PostAsync($"Lo siento, su pregunta no esta registrada");
                    await context.PostAsync("O tal vez no escribió la pregunta correctamente");
                    return;
                }
                // -------------------------------------------------------------------
                // La primera parte de la pregunta es carpetas
                else if (palabra1 == "carpeta" || palabra1 == "carpetas")
                {
                    // Recorrido de la segunda parte de la pregunta
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");

                        // La segunda parte de la pregunta es busqueda
                        if (palabra2 == "busqueda" || palabra2 == "busquedas" || palabra2 == "búsquedas" || palabra2 == "búsqueda")
                        {
                            reply.Attachments = Respuestas.GetUsarCrearCarpetasBusqueda();
                            await context.PostAsync(reply);
                            return;
                        }
                        else
                        {
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada");
                            await context.PostAsync($"O tal vez no escribió la correctamente '{palabra2}'?");
                            return;
                        }
                    }
                    // Si el usuario no ingreso la segunda parte de la pregunta
                    reply.Attachments = Respuestas.GetCrearUsarCarpetasPersonales();
                    await context.PostAsync(reply);
                    return;
                }
                // -------------------------------------------------------------------
                // La primera parte de la pregunta es tarea
                else if (palabra1 == "tarea" || palabra1 == "tareas")
                {
                    // Recorrido de la tercera parte de la pregunta es mensaje
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra3"))
                    {
                        var palabra3 = entityP2.Entity.ToLower().Replace(" ", "");
                        // La segunda parte de la pregunta es colores
                        if (palabra3 == "mensaje" || palabra3 == "mensajes" || palabra3 == "correo" || palabra3 == "correos")
                        {
                            reply.Attachments = Respuestas.GetCrearTareaAPartirMensaje();
                            await context.PostAsync(reply);
                            return;
                        }
                        else
                        {
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada");
                            await context.PostAsync($"O tal vez no escribió la correctamente '{palabra3}'?");
                            return;
                        }
                    }
                    // Si el usuario no ingreso la segunda parte de la pregunta
                    await context.PostAsync($"Lo siento, su pregunta no esta registrada");
                    await context.PostAsync($"O tal vez no escribió la pregunta correctamente");
                    return;
                }
                // -------------------------------------------------------------------
                // La primera parte de la pregunta es vista
                else if (palabra1 == "evento" || palabra1 == "eventos")
                {
                    reply.Attachments = Respuestas.GetCrearEventoQueDureTodoDia();
                    await context.PostAsync(reply);
                    return;
                }
                // -------------------------------------------------------------------
                // La primera parte de la pregunta es vista
                else if (palabra1 == "vista" || palabra1 == "vistas")
                {
                    reply.Attachments = Respuestas.GetCrearCambiarPersonalizarVista();
                    await context.PostAsync(reply);
                    return;
                }
                // -------------------------------------------------------------------
                // La primera parte de la pregunta es correo
                else if (palabra1 == "correo" || palabra1 == "correos")
                {
                    reply.Attachments = Respuestas.GetCrearMensajeCorreoElectronico();
                    await context.PostAsync(reply);
                    return;
                }
                // -------------------------------------------------------------------
                // La primera parte de la pregunta es cita
                else if (palabra1 == "cita" || palabra1 == "citas")
                {
                    reply.Attachments = Respuestas.GetCrearProgramarCita();
                    await context.PostAsync(reply);
                    return;
                }
                else
                {
                    await context.PostAsync($"Lo siento, su pregunta no esta registrada");
                    await context.PostAsync($"O tal vez no escribió correctamente la palabra '{palabra1}'?");
                    return;
                }
            }
            // Si el usuario no a ingresado la primera parte de la pregunta
            await context.PostAsync("Lo siento, su pregunta no esta registrada");
            reply.Attachments = Respuestas.GetConsultaV2();
            await context.PostAsync(reply);
            await context.PostAsync("O tal vez no escribió la pregunta correctamente");
            return;
        }

    }
}