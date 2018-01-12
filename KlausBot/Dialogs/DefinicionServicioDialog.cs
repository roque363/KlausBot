using System;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Internals.Fibers;

namespace KlausBot.Dialogs
{
    [Serializable]
    public class DefinicionServicioDialog : IDialog
    {
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
        }

        public async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            //--------------------------------
            //obtener el producto si este fue elegido de forma explicita
            foreach (var entity in argument.Entities.Where(Entity => Entity.Type == "Servicio"))
            {
                var value = entity.Entity.ToLower().Replace(" ", "");
                //var value = entity.Entity.ToLower();

                if (value == "outlook" || value == "outlok")
                {
                    var reply = context.MakeMessage();
                    reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;
                    reply.Attachments = GetOutlookDefinicionCard();

                    await context.PostAsync(reply);
                    context.Wait(MessageReceivedAsync);
                    return;
                }
                else if (value == "excel")
                {
                    var reply = context.MakeMessage();
                    reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;
                    reply.Attachments = GetExcelDefinicionCard();

                    await context.PostAsync(reply);
                    context.Wait(MessageReceivedAsync);
                    return;
                }
                else if (value == "powerpoint" || value == "power point")
                {
                    var reply = context.MakeMessage();
                    reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;
                    reply.Attachments = GetPowerPointDefinicionCard();

                    await context.PostAsync(reply);
                    context.Wait(MessageReceivedAsync);
                    context.PrivateConversationData.SetValue<string>("tipoServicio", "Servicio");
                    return;
                }
                else if (value == "word")
                {
                    var reply = context.MakeMessage();
                    reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;
                    reply.Attachments = GetWordDefinicionCard();

                    await context.PostAsync(reply);
                    context.Wait(MessageReceivedAsync);
                    return;
                }
                else
                {
                    await context.PostAsync($"Lo siento, {value} no esta registrado, consulte otra vez el servicio escribiendo ayuda");
                    context.Wait(MessageReceivedAsync);
                    return;
                }

            }
            //------------------------

            //obtener el producto si este a sido escodigo anteriormente
            var servicio = "Servicio";
            context.PrivateConversationData.TryGetValue<string>("tipoServicio", out servicio);
            if (servicio == "Word")
            {
                var reply = context.MakeMessage();
                reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;
                reply.Attachments = GetWordDefinicionCard();

                await context.PostAsync(reply);
                context.Wait(MessageReceivedAsync);
                context.PrivateConversationData.SetValue<string>("tipoServicio", "Servicio");
                return;
            }
            else if (servicio == "Excel")
            {
                var reply = context.MakeMessage();
                reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;
                reply.Attachments = GetExcelDefinicionCard();

                await context.PostAsync(reply);
                context.Wait(MessageReceivedAsync);
                context.PrivateConversationData.SetValue<string>("tipoServicio", "Servicio");
                return;
            }
            else if (servicio == "outlook" || servicio == "outlok")
            {
                var reply = context.MakeMessage();
                reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;
                reply.Attachments = GetOutlookDefinicionCard();

                await context.PostAsync(reply);
                context.Wait(MessageReceivedAsync);
                return;
            }
            else if (servicio == "PowerPoint")
            {
                var reply = context.MakeMessage();
                reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;
                reply.Attachments = GetPowerPointDefinicionCard();

                await context.PostAsync(reply);
                context.Wait(MessageReceivedAsync);
                context.PrivateConversationData.SetValue<string>("tipoServicio", "Servicio");
                return;
            }
        }

        private static Attachment GetHeroCard(string title, string subtitle, string text, CardImage cardImage)
        {
            var heroCard = new HeroCard
            {
                Title = title,
                Subtitle = subtitle,
                Text = text,
                Images = new List<CardImage>() { cardImage },
                //Buttons = new List<CardAction>() { cardAction },
            };

            return heroCard.ToAttachment();
        }

        private static Attachment GetThumbnailCard(string title, string subtitle, string text, CardImage cardImage, CardAction cardAction)
        {
            var heroCard = new ThumbnailCard
            {
                Title = title,
                Subtitle = subtitle,
                Text = text,
                Images = new List<CardImage>() { cardImage },
                Buttons = new List<CardAction>() { cardAction },
            };

            return heroCard.ToAttachment();
        }

        private static Attachment GetVideoCard(string title, string text, string url, string value)
        {
            var videoCard = new VideoCard
            {
                Title = title,
                Text = text,
                Media = new List<MediaUrl> {
                    new MediaUrl() {
                        Url = url
                    }
                },
                Buttons = new List<CardAction> {
                    new CardAction() {
                        Title = "Ver más información",
                        Type = ActionTypes.OpenUrl,
                        Value = value
                    }
                }
            };

            return videoCard.ToAttachment();
        }

        private static IList<Attachment> GetOutlookDefinicionCard()
        {
            return new List<Attachment>()
            {
                GetHeroCard(
                    "¿Qué es Outlook?",
                    "",
                    "El nuevo Outlook es más que solo correo electrónico. Le mostraremos cómo organizar automáticamente su bandeja de entrada y lo ayudará a enfocarse en los correos electrónicos que más le importan. También obtienes un poderoso calendario para administrar tu día.",
                    new CardImage(url: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQIFH5814W1-9WxdGlN1QJHCxV-yKKwIeXu2hSnnLylJxsfp-NU")),
                GetVideoCard(
                    "Office 365 - Outlook",
                    "Video sobre Outlook",
                    "https://videocontent.osi.office.net/cccda7b4-2f70-4420-9409-c231ee8312ea/e05255a3-3279-464e-a0a1-237440b26c48_1280x720_3400.mp4",
                    "https://support.office.com/es-es/article/Video-What-is-Outlook-10f1fa35-f33a-4cb7-838c-a7f3e6228b20?ui=es-ES&rs=es-ES&ad=ES"),
            };
        }

        private static IList<Attachment> GetExcelDefinicionCard()
        {
            return new List<Attachment>()
            {
                GetHeroCard(
                    "¿Qué es Excel?",
                    "Significad e historia de  Excel",
                    "Excel es un programa informático desarrollado por Microsoft y forma parte de Office que es una suite ofimática la cual incluye otros programas como Word y PowerPoint. Excel se distingue de los demás programas porque nos permite trabajar con datos numéricos, es decir, podemos realizar cálculos, crear tablas o gráficos y también podemos analizar los datos con herramientas tan avanzadas como las tablas dinámicas.",
                    new CardImage(url: "https://policyviz.com/wp-content/uploads/2017/07/Excel-Logo.png")),
                GetVideoCard(
                    "Office 365 - Excel",
                    "Video sobre excel",
                    "https://wus-streaming-video-rt-microsoft-com.akamaized.net/ad1ced2a-75fd-4e49-9cbd-099a618cb778/f44d7b46-f1aa-4246-8c2d-b6aa6cd1_1920x1080_2762.mp4",
                    "https://support.office.com/es-es/article/Inicio-r%C3%A1pido-de-Excel-2016-94b00f50-5896-479c-b0c5-ff74603b35a3?ui=es-ES&rs=es-ES&ad=ES"),
            };
        }

        private static IList<Attachment> GetPowerPointDefinicionCard()
        {
            return new List<Attachment>()
            {
                GetHeroCard(
                    "¿Qué es PowerPoint?",
                    "",
                    "PowerPoint es un programa de presentación con diapositivas que forma parte del conjunto de herramientas de Microsoft Office. Con PowerPoint, es fácil crear y presentar ideas, así como colaborar en ellas, de una forma visualmente atractiva y dinámica.",
                    new CardImage(url: "http://tdescargas.org/wp-content/uploads/2017/07/C%C3%B3mo-mejorar-un-Power-Point.png")),
                GetVideoCard(
                    "Office 365 - PowerPoint",
                    "Video sobre PowerPoint",
                    "https://videocontent.osi.office.net/f8bfaba3-fab6-400f-b58a-f8d80b455682/2c0bd7ad-139b-45d7-932a-12f38dd4a01c_1280x720_3400.mp4",
                    "https://products.office.com/es-mx/what-is-powerpoint"),
            };
        }

        private static IList<Attachment> GetWordDefinicionCard()
        {
            return new List<Attachment>()
            {
                GetHeroCard(
                    "¿Qué es Word?",
                    "",
                    "Microsoft Word es un programa informático orientado al procesamiento de textos. Fue creado por la empresa Microsoft, y viene integrado predeterminadamente en el paquete ofimático denominado Microsoft Office.",
                    new CardImage(url: "https://www.adslzone.net/app/uploads/2017/01/word-ms.jpg")),
                GetVideoCard(
                    "Office 365 - Word",
                    "Video sobre Word",
                    "https://videocontent.osi.office.net/92cbca43-f999-4546-9aa4-e9a0a0494579/626d11f6-fbdf-4f5c-987f-952a73376352_1280x720_3400.mp4",
                    "https://products.office.com/es-mx/what-is-powerpoint"),
            };
        }

    }
}