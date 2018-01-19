using System;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using KlausBot.Models;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;

namespace KlausBot.Dialogs
{
    //[LuisModel("cd076119-b212-4414-a71d-3874bb7a5ab6", "755c923dc1fe4acb91201cbd955e7a71")] KlausBot
    [LuisModel("26132056-47a4-4f3b-9c71-ee6e5fa0dad3", "2a755c441df445349b5d17f491219153")]

    [Serializable]
    public class LUISDialog : LuisDialog<ConsultaServicio>
    { 
        private readonly BuildFormDelegate<ConsultaServicio> consultaServicio;

        public LUISDialog(BuildFormDelegate<ConsultaServicio> servicioConsultado)
        {
            this.consultaServicio = servicioConsultado;
        }

        // No se reconoce la accion del usuario
        [LuisIntent("")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            var reply = context.MakeMessage();
            reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;

            await context.PostAsync("Perdon, no entiendo lo que estas diciendo");

            reply.Attachments = Respuestas.GetConsulta();
            await context.PostAsync(reply);
            context.Wait(MessageReceived);
            return;
        }

        // El usuario tiene una accion de saludo
        [LuisIntent("Saludo")]
        public async Task Saludo(IDialogContext context, LuisResult result)
        {
            context.Call(new SaludoDialog(), Callback);
        }

        private async Task Callback(IDialogContext context, IAwaitable<object> result)
        {
            context.Wait(MessageReceived);
        }

        [LuisIntent("Consulta.ServicioGeneral")]
        public async Task ConsultaServicio(IDialogContext context, LuisResult result)
        {
            var formularioRegistro = new FormDialog<ConsultaServicio>(new ConsultaServicio(), this.consultaServicio, FormOptions.PromptInStart);
            context.Call<ConsultaServicio>(formularioRegistro, Callback);
        }

        [LuisIntent("Otros")]
        public async Task Pregunta(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"Lo siento, pero solo te veo como un amigo");
            await context.PostAsync("ademas no quiero arruinar la bonita amistad que tenemos");
            context.Wait(MessageReceived);
            return;
        }

        [LuisIntent("Consulta.DefinicionServicio")]
        public async Task DefinicionServicio(IDialogContext context, LuisResult result)
        {
            var reply = context.MakeMessage();
            reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;

            //obtener el producto si este fue elegido de forma explicita
            foreach (var entity in result.Entities.Where(Entity => Entity.Type == "Servicio"))
            {
                var value = entity.Entity.ToLower().Replace(" ", "");

                if (value == "outlook" || value == "outlok")
                {
                    reply.Attachments = Respuestas.GetOutlookDefinicionCard();
                    await context.PostAsync(reply);
                    context.Wait(MessageReceived);
                    return;
                }
                else if (value == "excel")
                {
                    reply.Attachments = Respuestas.GetExcelDefinicionCard();
                    await context.PostAsync(reply);
                    context.Wait(MessageReceived);
                    return;
                }
                else if (value == "powerpoint" || value == "power point")
                {
                    reply.Attachments = Respuestas.GetPowerPointDefinicionCard();
                    await context.PostAsync(reply);
                    context.Wait(MessageReceived);
                    return;
                }
                else if (value == "word")
                {
                    reply.Attachments = Respuestas.GetWordDefinicionCard();
                    await context.PostAsync(reply);
                    context.Wait(MessageReceived);
                    return;
                }
                else
                {
                    await context.PostAsync($"Lo siento, {value} no esta registrado, consulte otra vez el servicio escribiendo ayuda");
                    context.Wait(MessageReceived);
                    return;
                }
            }

            //obtener el producto si este a sido escodigo anteriormente
            var servicio = "Servicio";
            context.PrivateConversationData.TryGetValue<string>("tipoDeServicio", out servicio);
            if (servicio == "Word")
            {
                reply.Attachments = Respuestas.GetWordDefinicionCard();
                await context.PostAsync(reply);
                context.Wait(MessageReceived);
                context.PrivateConversationData.SetValue<string>("tipoServicio", "Servicio");
                return;
            }
            else if (servicio == "Excel") 
            {
                reply.Attachments = Respuestas.GetExcelDefinicionCard();
                await context.PostAsync(reply);
                context.Wait(MessageReceived);
                context.PrivateConversationData.SetValue<string>("tipoServicio", "Servicio");
                return;
            }
            else if (servicio == "Outlook")
            {
                reply.Attachments = Respuestas.GetOutlookDefinicionCard();
                await context.PostAsync(reply);
                context.Wait(MessageReceived);
                context.PrivateConversationData.SetValue<string>("tipoServicio", "Servicio");
                return;
            }
            else if (servicio == "PowerPoint")
            {
                reply.Attachments = Respuestas.GetPowerPointDefinicionCard();
                await context.PostAsync(reply);
                context.Wait(MessageReceived);
                context.PrivateConversationData.SetValue<string>("tipoServicio", "Servicio");
                return;
            }
        }

        // La accion del usuario es crear 
        [LuisIntent("Consulta.Crear")]
        public async Task ConsultaCrear(IDialogContext context, LuisResult result)
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
                            context.Wait(MessageReceived);
                            return;
                        }
                        else
                        {
                            await context.PostAsync("Lo siento, su pregunta no esta registrada");
                            await context.PostAsync("O tal vez no escribió la pregunta correctamente");
                            context.Wait(MessageReceived);
                            return;
                        }
                    }
                    // Si el usuario no ingreso la segunda parte de la pregunta
                    await context.PostAsync($"Lo siento, su pregunta no esta registrada");
                    await context.PostAsync("O tal vez no escribió la pregunta correctamente");
                    context.Wait(MessageReceived);
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
                            context.Wait(MessageReceived);
                            return;
                        }
                        else
                        {
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada");
                            await context.PostAsync("O tal vez no escribió la pregunta correctamente");
                            context.Wait(MessageReceived);
                            return;
                        }
                    }
                    // Si el usuario no ingreso la segunda parte de la pregunta
                    await context.PostAsync($"Lo siento, su pregunta no esta registrada");
                    await context.PostAsync("O tal vez no escribió la pregunta correctamente");
                    context.Wait(MessageReceived);
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
                            context.Wait(MessageReceived);
                            return;
                        }
                        else if (palabra2 == "correo" || palabra2 == "correos")
                        {
                            reply.Attachments = Respuestas.GetCrearPlantillaCorreoElectronico();
                            await context.PostAsync(reply);
                            context.Wait(MessageReceived);
                            return;
                        }
                        else
                        {
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada");
                            await context.PostAsync("O tal vez no escribió la pregunta correctamente");
                            context.Wait(MessageReceived);
                            return;
                        }
                    }
                    // Si el usuario no ingreso la segunda parte de la pregunta
                    await context.PostAsync($"Lo siento, su pregunta no esta registrada");
                    await context.PostAsync("O tal vez no escribió la pregunta correctamente");
                    context.Wait(MessageReceived);
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
                            context.Wait(MessageReceived);
                            return;
                        }
                        else
                        {
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada");
                            await context.PostAsync("O tal vez no escribió la pregunta correctamente");
                            context.Wait(MessageReceived);
                            return;
                        }
                    }
                    // Si el usuario no ingreso la segunda parte de la pregunta
                    reply.Attachments = Respuestas.GetCrearUsarCarpetasPersonales();
                    await context.PostAsync(reply);
                    context.Wait(MessageReceived);
                    return;
                }
                // -------------------------------------------------------------------
                // La primera parte de la pregunta es vista
                else if (palabra1 == "evento" || palabra1 == "eventos")
                {
                    reply.Attachments = Respuestas.GetCrearEventoQueDureTodoDia();
                    await context.PostAsync(reply);
                    context.Wait(MessageReceived);
                    return;
                }
                // -------------------------------------------------------------------
                // La primera parte de la pregunta es vista
                else if (palabra1 == "vista" || palabra1 == "vistas")
                {
                    reply.Attachments = Respuestas.GetCrearCambiarPersonalizarVista();
                    await context.PostAsync(reply);
                    context.Wait(MessageReceived);
                    return;
                }
                // -------------------------------------------------------------------
                // La primera parte de la pregunta es correo
                else if (palabra1 == "correo" || palabra1 == "correos")
                {
                    reply.Attachments = Respuestas.GetCrearMensajeCorreoElectronico();
                    await context.PostAsync(reply);
                    context.Wait(MessageReceived);
                    return;
                }
                // -------------------------------------------------------------------
                // La primera parte de la pregunta es cita
                else if (palabra1 == "cita" || palabra1 == "citas")
                {
                    reply.Attachments = Respuestas.GetCrearProgramarCita();
                    await context.PostAsync(reply);
                    context.Wait(MessageReceived);
                    return;
                }
                else
                {
                    await context.PostAsync($"Lo siento, su pregunta no esta registrada");
                    await context.PostAsync("O tal vez no escribió la pregunta correctamente");
                    context.Wait(MessageReceived);
                    return;
                }
            }
            // Si el usuario no a ingresado la primera parte de la pregunta
            await context.PostAsync("Lo siento, su pregunta no esta registrada");
            await context.PostAsync("O tal vez no escribió la pregunta correctamente");
            context.Wait(MessageReceived);
            return;
        }

        // La accion del usuario es cambiar
        [LuisIntent("Consulta.Cambiar")]
        public async Task ConsultaCambiar(IDialogContext context, LuisResult result)
        {
            var reply = context.MakeMessage();
            reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;

            // Recorrido de la primera parte de la pregunta
            foreach (var entityP1 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra1"))
            {
                var palabra1 = entityP1.Entity.ToLower().Replace(" ", "");

                // La primera parte de la pregunta es firma 
                if (palabra1 == "modo" || palabra1 == "apariencia")
                {
                    // Recorrido de la segunda parte de la pregunta
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");

                        // La segunda parte de la prgunta es mensaje o correo
                        if (palabra2 == "calendario" || palabra2 == "calendarios")
                        {
                            reply.Attachments = Respuestas.GetCambiarModoVerCalendario();
                            await context.PostAsync(reply);
                            context.Wait(MessageReceived);
                            return;
                        }
                        else
                        {
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada");
                            await context.PostAsync("O tal vez no escribió la pregunta correctamente");
                            context.Wait(MessageReceived);
                            return;
                        }
                    }
                    // Si el usuario no ingreso la segunda parte de la pregunta
                    await context.PostAsync($"Lo siento, su pregunta no esta registrada");
                    await context.PostAsync("O tal vez no escribió la pregunta correctamente");
                    context.Wait(MessageReceived);
                    return;
                }
                else
                {
                    await context.PostAsync($"Lo siento, su pregunta no esta registrada");
                    await context.PostAsync("O tal vez no escribió la pregunta correctamente");
                    context.Wait(MessageReceived);
                    return;
                }
            }
        }  

        // La accion del usuairo es recuperar 
        [LuisIntent("Consulta.Recuperar")]
        public async Task ConsultaRecuperar(IDialogContext context, LuisResult result)
        {
            var reply = context.MakeMessage();
            reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;

            // Recorrido de la segunda parte de la pregunta
            foreach (var entityP1 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra1"))
            {
                var palabra1 = entityP1.Entity.ToLower().Replace(" ", "");

                // El usuario escribio en su pregunta la palabra elemento 
                if (palabra1 == "elemento" || palabra1 == "elementos")
                {
                    // Recorrido de la primera parte de la pregunta
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");

                        // El usuario escribio en su pregunta la palabra eliminado
                        if (palabra2 == "eliminado" || palabra2 == "eliminados")
                        {
                            reply.Attachments = Respuestas.GetRecuperarElementosEliminados();
                            await context.PostAsync(reply);
                            context.Wait(MessageReceived);
                            return;
                        }
                        else
                        {
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada");
                            await context.PostAsync("O tal vez no escribió la pregunta correctamente");
                            context.Wait(MessageReceived);
                            return;
                        }
                    }
                    // Si el usuario no ingreso la segunda parte de la pregunta
                    await context.PostAsync($"Lo siento, su pregunta no esta registrada");
                    await context.PostAsync("O tal vez no escribió la pregunta correctamente");
                    context.Wait(MessageReceived);
                    return;
                }
                // El usuario escribio en su pregunta la palabra mensaje
                else if (palabra1 == "mensaje" || palabra1 == "mensajes" || palabra1 == "correo" || palabra1 == "correos")
                {
                    reply.Attachments = Respuestas.GetRecuperarMensajeDespuésEnviarlo();
                    await context.PostAsync(reply);
                    context.Wait(MessageReceived);
                    return;
                }
                else
                {
                    await context.PostAsync($"Lo siento, su pregunta no esta registrada");
                    await context.PostAsync("O tal vez no escribió la pregunta correctamente");
                    context.Wait(MessageReceived);
                    return;
                }
            }
        }

        [LuisIntent("Consulta.Agregar")]
        public async Task ConsultaAgregar(IDialogContext context, LuisResult result)
        {
            await new AgregarDialog(context, result).StartAsync();
        }

    }
}
