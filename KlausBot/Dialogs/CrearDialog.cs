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
                            reply.Attachments = Respuestas.GetCrearAsignarCategoriasColor();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = Respuestas.GetCrearAsignarCategoriasColor();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = Respuestas.GetCrearAsignarCategoriasColor();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
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
                            reply.Attachments = Respuestas.GetCrearPlantillaMensajeCorreoElectronico();
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            return;
                        }
                        else if (palabra2 == "correo" || palabra2 == "correos")
                        {
                            await context.PostAsync(confirmacionRespuesta1);
                            reply.Attachments = Respuestas.GetCrearPlantillaCorreoElectronico();
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = Respuestas.GetCrearPlantillaMensajeCorreoElectronico();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = Respuestas.GetCrearPlantillaCorreoElectronico();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
                    return;
                }
                // -------------------------------------------------------------------
                // La primera parte de la pregunta es carpetas
                else if (palabra1 == "carpeta" || palabra1 == "carpetas")
                {
                    // Se detectó la segunda parte de la pregunta
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");
                        // La segunda parte de la pregunta es busqueda
                        if (palabra2 == "busqueda" || palabra2 == "busquedas" || palabra2 == "búsquedas" || palabra2 == "búsqueda")
                        {
                            await context.PostAsync(confirmacionRespuesta1);
                            reply.Attachments = Respuestas.GetUsarCrearCarpetasBusqueda();
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = Respuestas.GetUsarCrearCarpetasBusqueda();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = Respuestas.GetUsarCrearCarpetasBusqueda();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
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
                            reply.Attachments = Respuestas.GetCrearTareaAPartirMensaje();
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = Respuestas.GetCrearTareaYAPartirDeMensaje();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra3}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta2);
                            await context.PostAsync(reply);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = Respuestas.GetCrearTareaYAPartirDeMensaje();
                    await context.PostAsync(confirmacionRespuesta2);
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
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
                            reply.Attachments = Respuestas.GetCrearGrupoContactosListaDistribucionOutlook();
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = Respuestas.GetCrearGrupoContactosListaDistribucionOutlook();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = Respuestas.GetCrearGrupoContactosListaDistribucionOutlook();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
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
                            reply.Attachments = Respuestas.GetCrearDiseñosFondoParaMensajes();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = Respuestas.GetCrearDiseñosFondoParaMensajes();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra3}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = Respuestas.GetCrearDiseñosFondoParaMensajes();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
                    return;
                }
                // -------------------------------------------------------------------
                // La primera parte de la pregunta es vista
                else if (palabra1 == "evento" || palabra1 == "eventos")
                {
                    await context.PostAsync(confirmacionRespuesta1);
                    reply.Attachments = Respuestas.GetCrearEventoQueDureTodoDia();
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                    return;
                }
                // -------------------------------------------------------------------
                // La primera parte de la pregunta es vista
                else if (palabra1 == "vista" || palabra1 == "vistas")
                {
                    await context.PostAsync(confirmacionRespuesta1);
                    reply.Attachments = Respuestas.GetCrearCambiarPersonalizarVista();
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                    return;
                }
                // -------------------------------------------------------------------
                // La primera parte de la pregunta es correo
                else if (palabra1 == "correo" || palabra1 == "correos" || palabra1 == "mensaje" || palabra1 == "mensajes" || palabra1 == "correoelectronico")
                {
                    reply.Attachments = Respuestas.GetCrearMensajeCorreoElectronico();
                    await context.PostAsync(confirmacionRespuesta1);
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                    return;
                }
                // -------------------------------------------------------------------
                // La primera parte de la pregunta es cita
                else if (palabra1 == "cita" || palabra1 == "citas")
                {
                    reply.Attachments = Respuestas.GetCrearProgramarCita();
                    await context.PostAsync(confirmacionRespuesta1);
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                    return;
                }
                // -------------------------------------------------------------------
                else
                {
                    await context.PostAsync(preguntaNoRegistrada2);
                    await context.PostAsync($"O tal vez no escribió correctamente la palabra '{palabra1}'?");
                    return;
                }
            }
            // No se detectó la primera parte de la pregunta
            await context.PostAsync(preguntaNoRegistrada2);
            reply.Attachments = Respuestas.GetConsultaV2();
            await context.PostAsync(reply);
            await context.PostAsync("O tal vez no escribió la pregunta correctamente");
            return;
        }

    }
}
