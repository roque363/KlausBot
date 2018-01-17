using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading;
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
    [Template(TemplateUsage.NotUnderstood, "\"{0}\" no es uno de los servicios", "Esa no es una opción: \"{0}\".")]
    public class ConsultaServicio
    {
        [Prompt("Con que tipo de servicio tienes problemas: {||}")]
        public Servicio? TipoDeServicio;

        public static IForm<ConsultaServicio> BuildForm()
        {
            OnCompletionAsyncDelegate<ConsultaServicio> processOrder = async (context, order) =>
            {
                var name = "Usuario";
                var servicio = "Servicio";
                context.UserData.TryGetValue<string>("Name", out name);
                context.PrivateConversationData.SetValue<string>("tipoDeServicio", order.TipoDeServicio.ToString());
                context.PrivateConversationData.TryGetValue<string>("tipoDeServicio", out servicio);

                await context.PostAsync($"Entonces estimado {name}, ¿Cúal es su duda respecto a {servicio}? ");
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