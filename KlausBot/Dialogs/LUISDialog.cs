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
    //[LuisModel("cd076119-b212-4414-a71d-3874bb7a5ab6", "755c923dc1fe4acb91201cbd955e7a71")]
    [LuisModel("82f3e996-7431-4211-a195-8cc9ca1a600d", "55b706c0133e457e9f928188adeabe1e")]

    [Serializable]
    public class LUISDialog : LuisDialog<ConsultaServicio>
    { 
        private readonly BuildFormDelegate<ConsultaServicio> consultaServicio;

        public LUISDialog(BuildFormDelegate<ConsultaServicio> servicioConsultado)
        {
            this.consultaServicio = servicioConsultado;
        }

        [LuisIntent("")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Lo siento no se lo que quieres decir.");
            context.Wait(MessageReceived);
        }

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
            context.PrivateConversationData.TryGetValue<string>("tipoServicio", out servicio);
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

        [LuisIntent("Consulta.Crear")]
        public async Task ConsultaCrear(IDialogContext context, LuisResult result)
        {
            var reply = context.MakeMessage();
            reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;

            foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))// Primera parte de la pregunta
            {
                foreach (var entityP1 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra1"))// Segunda parte de la pregunta
                {
                    var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");
                    var palabra1 = entityP1.Entity.ToLower().Replace(" ", "");

                    // El usuario escribio en su pregunta la palabra mensaje o correo
                    if (palabra2 == "mensaje" || palabra2 == "mensajes" || palabra2 == "correo" || palabra2 == "correos")
                    {
                        // El usuario escribio en su pregunta la palabra firma
                        if (palabra1 == "firma" || palabra1 == "firmas")
                        {
                            reply.Attachments = Respuestas.GetCrearFirmaMensaje();
                            await context.PostAsync(reply);
                            context.Wait(MessageReceived);
                            return;
                        }
                        else
                        {
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada");
                            context.Wait(MessageReceived);
                            return;
                        }
                    }
                    else
                    {
                        await context.PostAsync($"Lo siento, su pregunta no esta registrada");
                        context.Wait(MessageReceived);
                        return;
                    }

                }
            }   
        }

        [LuisIntent("Consulta.Recuperar")]
        public async Task ConsultaRecuperar(IDialogContext context, LuisResult result)
        {
            var reply = context.MakeMessage();
            reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;

            foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))// Segunda parte de la pregunta
            {
                foreach (var entityP1 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra1"))// Primera parte de la pregunta
                {
                    var palabra1 = entityP1.Entity.ToLower().Replace(" ", "");
                    var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");

                    // El usuario escribio en su pregunta la palabra elemento 
                    if (palabra1 == "elemento" || palabra1 == "elementos")
                    {
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
                            context.Wait(MessageReceived);
                            return;
                        }
                    }
                    // El usuario escribio en su pregunta la palabra mensaje
                    else if (palabra1 == "mensaje" || palabra1 == "mensajes")
                    {
                        reply.Attachments = Respuestas.GetRecuperarMensajeDespuésEnviarlo();
                        await context.PostAsync(reply);
                        context.Wait(MessageReceived);
                        return;
                    }
                    else
                    {
                        await context.PostAsync($"Lo siento, su pregunta no esta registrada");
                        context.Wait(MessageReceived);
                        return;
                    }

                }
            }
        }

    }
}