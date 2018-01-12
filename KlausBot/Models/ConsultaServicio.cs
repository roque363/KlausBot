using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;

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
        SharePoint,
        MicrosoftTeams,
        Publisher,
        Access
    }

    [Serializable]
    public class ConsultaServicio
    {
        public Servicio? TipoDeServicio;

        public static IForm<ConsultaServicio> BuildForm()
        {
            return new FormBuilder<ConsultaServicio>()
                .Message("Bienvenido al centro de atención para Office 365").OnCompletion(async (context, order) =>
                {
                    var name = "Usuario";
                    var servicio = "Servicio";
                    context.UserData.TryGetValue<string>("Name", out name);
                    context.PrivateConversationData.SetValue<string>(
                        "tipoServicio", order.TipoDeServicio.ToString());
                    context.PrivateConversationData.TryGetValue<string>("tipoServicio", out servicio);

                    await context.PostAsync($"Entonces estimado {name}, ¿Cúal es su duda respecto a {servicio}? ");
                })
                .Build();
        }
    }
}