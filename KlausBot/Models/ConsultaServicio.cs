using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading;
using KlausBot.Models;
using Microsoft.Bot.Connector;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Builder.FormFlow.Advanced;


namespace KlausBot.Models
{
    public enum Servicio
    {
        Outlook,
        OneDrive,
        Word,
        Excel,
        PowerPoint,
        OneNote,
        //SharePoint,
        //MicrosoftTeams,
        //Publisher,
        //Access
    }

    [Serializable]
    [Template(TemplateUsage.NotUnderstood, "\"{0}\" no es uno de los servicios", "Esa no es una opción: \"{0}\".", "\"{0}\" no es una opción.")]
    public class ConsultaServicio
    {
        [Prompt("Con que tipo de servicio tienes problemas: {||}")]
        public Servicio? TipoDeServicio;

        public static IForm<ConsultaServicio> BuildForm()
        {
            OnCompletionAsyncDelegate<ConsultaServicio> processOrder = async (context, order) =>
            {
                var reply = context.MakeMessage();
                reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;

                var name = "Usuario";
                var servicio = "Servicio";
                context.UserData.TryGetValue<string>("Name", out name);
                context.PrivateConversationData.SetValue<string>("tipoDeServicio", order.TipoDeServicio.ToString());
                context.PrivateConversationData.TryGetValue<string>("tipoDeServicio", out servicio);

                await context.PostAsync($"Entonces estimado {name}, ¿En qué te puedo ayudar respecto a {servicio}? ");

                if (servicio == "Word")
                {
                    reply.Attachments = Respuestas.GetDestacadosWord();
                    await context.PostAsync($"Estos son algunos temas destacados de {servicio}");
                    await context.PostAsync(reply);
                    context.PrivateConversationData.SetValue<string>("tipoServicio", "Servicio");
                    return;
                }
                else if (servicio == "Excel")
                {
                    reply.Attachments = Respuestas.GetDestacadosExcel();
                    await context.PostAsync($"Estos son algunos temas destacados de {servicio}");
                    await context.PostAsync(reply);
                    context.PrivateConversationData.SetValue<string>("tipoServicio", "Servicio");
                    return;
                }
                else if (servicio == "PowerPoint")
                {
                    reply.Attachments = Respuestas.GetDestacadosPowerPoint();
                    await context.PostAsync($"Estos son algunos temas destacados de {servicio}");
                    await context.PostAsync(reply);
                    context.PrivateConversationData.SetValue<string>("tipoServicio", "Servicio");
                    return;
                }
                else if (servicio == "Outlook")
                {
                    reply.Attachments = Respuestas.GetDestacadosOutlook();
                    await context.PostAsync($"Estos son algunos temas destacados de {servicio}");
                    await context.PostAsync(reply);
                    context.PrivateConversationData.SetValue<string>("tipoServicio", "Servicio");
                    return;
                }
                else if (servicio == "OneDrive")
                {
                    reply.Attachments = Respuestas.GetDestacadosOneDrive();
                    await context.PostAsync($"Estos son algunos temas destacados de {servicio}");
                    await context.PostAsync(reply);
                    context.PrivateConversationData.SetValue<string>("tipoServicio", "Servicio");
                    return;
                }
                else if (servicio == "OneNote")
                {
                    reply.Attachments = Respuestas.GetDestacadosOneNote();
                    await context.PostAsync($"Estos son algunos temas destacados de {servicio}");
                    await context.PostAsync(reply);
                    context.PrivateConversationData.SetValue<string>("tipoServicio", "Servicio");
                    return;
                }
                else
                {
                    // Error: No se guardo el servicio del usuario 
                    await context.PostAsync("Usted no debería estar aquí");
                    return;
                }
            };

            return new FormBuilder<ConsultaServicio>()
                .Message("Bienvenido soy el bot de soporte para Office 365")
                .Field(nameof(TipoDeServicio))
                .Confirm("El servicio que has seleccionado es {TipoDeServicio}? (Si/No)")
                .OnCompletion(processOrder)
                .Build();
        }
    }
}