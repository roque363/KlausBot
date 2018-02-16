using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using Microsoft.Bot.Connector;

namespace KlausBot.Util
{
    public class RespuestasPowerPoint
    {
        //-------------------------------------------------------------
        // PREGUNTAS DE POWER POINT
        //-------------------------------------------------------------
        //-------- DEFINICION --------
        // ---------------------------
        // Definicon de Power Point
        public static IList<Attachment> GetPowerPointDefinicionCard()
        {
            return new List<Attachment>()
            {
                GetHeroCard(
                    "¿Qué es PowerPoint?",
                    "",
                    "PowerPoint es un programa de presentación con diapositivas que forma parte del conjunto de herramientas de Microsoft Office. " +
                    "Con PowerPoint, es fácil crear y presentar ideas, así como colaborar en ellas, de una forma visualmente atractiva y dinámica.",
                    new CardImage(url: "http://tdescargas.org/wp-content/uploads/2017/07/C%C3%B3mo-mejorar-un-Power-Point.png")),
                GetVideoCard(
                    "Office 365 - PowerPoint",
                    "Video sobre PowerPoint",
                    "https://videocontent.osi.office.net/f8bfaba3-fab6-400f-b58a-f8d80b455682/2c0bd7ad-139b-45d7-932a-12f38dd4a01c_1280x720_3400.mp4",
                    "https://products.office.com/es-mx/what-is-powerpoint"),
            };
        }

        //-------- COMPARTIR --------
        //---------------------------
        // Compartir la presentación de PowerPoint 2016 con otros usuarios
        public static IList<Attachment> GetCompartirPresentacionPowerPoint()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Compartir la presentación de PowerPoint 2016 con otros usuarios",
                    "Se aplica a: PowerPoint 2016",
                    ">1. Cree un borrador de la presentación. Cuando esté listo para compartir con otros usuarios, seleccione Compartir en la esquina superior derecha de la cinta de opciones.\r\r"+
                    ">2. Si aún no ha guardado la presentación en OneDrive o en Office 365 SharePoint, ahora se le solicitará que lo haga.\r\r"+
                    ">3. Una vez que la presentación se guarda en una ubicación compartida, a continuación, puede invitar a otros usuarios a trabajar en él también. En el cuadro en Invitar a personas, escriba la dirección de correo electrónico de la persona que le gustaría compartir con."+
                    " Si ya tiene información de contacto de la persona almacenado, sólo se puede especificar el nombre.\r\r"+
                    ">4. Cuando haya terminado, haga clic en el botón Compartir.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/compartir-la-presentaci%C3%B3n-de-powerpoint-2016-con-otros-usuarios-a6308d9d-a0a8-443b-8e1c-0f4983f0afd1")),
            };
        }

        // Compartir la autoría de una presentación con PowerPoint Online
        public static IList<Attachment> GetCompartirAutoriaPresentacionPowerPoint()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Compartir la autoría de una presentación con PowerPoint Online",
                    "Se aplica a: PowerPoint Online",
                    "Cualquier presentación almacenada en OneDrive o SharePoint Online puede trabajar en varios editores en PowerPoint Online. Puede agregar comentarios y editar por separado o simultáneamente.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/compartir-y-compartir-la-autor%C3%ADa-de-una-presentaci%C3%B3n-con-powerpoint-online-20b2c606-6140-4b0c-8540-159c3d248255?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // ELIMINAR
        //---------------------
        // Eliminar comentarios en Power Point
        public static IList<Attachment> GetEliminarComentariosPowerPoint()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Eliminar comentarios en Power Point",
                    "Se aplica a: PowerPoint 2016 PowerPoint 2013 PowerPoint 2010 PowerPoint 2007",
                    "Eliminar comentarios:\r\r"+
                    ">* **En la diapositiva:**    Haga clic en el icono de comentarios ![duck](https://support.content.office.net/es-es/media/5280372e-4b53-4d30-8c78-3a60a066ec23.png) del comentario que desea eliminar y, a continuación, haga clic en Eliminar comentario.\r\r"+
                    ">* **En el panel Comentarios:**    Haga clic en el comentario que desea eliminar y, luego, haga clic en la **X** negra.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/agregar-cambiar-ocultar-o-eliminar-comentarios-en-una-presentaci%C3%B3n-a8f071fa-6e5d-4c37-a025-1cf48a76eb38?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Cambiar o eliminar información de encabezado y pie de página en una presentación
        public static IList<Attachment> GetEliminarCambiarInformacionEncabezadoPiePagina()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Cambiar o eliminar información de encabezado y pie de página en una presentación",
                    "Se aplica a: PowerPoint 2010 y PowerPoint 2007",
                    "Eliminar información de encabezado y pie de página de las diapositivas:\r\r"+
                    ">1. Seleccione la diapositiva que contiene el encabezado o pie de página que desea cambiar.\r\r"+
                    ">2. En la pestaña **Insertar**, en el grupo **Texto**, seleccione **Encabezado y pie de página**.\r\r"+
                    ">3. En el cuadro de diálogo **Encabezado y pie de página**, en la ficha **Diapositiva**, desactive las casillas de verificación correspondientes a las opciones que desee eliminar del encabezado o pie de página.\r\r"+
                    ">4. Haga clic en **Aplicar a todo**.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/cambiar-o-eliminar-informaci%C3%B3n-de-encabezado-y-pie-de-p%C3%A1gina-en-una-presentaci%C3%B3n-5695469d-eaf5-412a-b0ce-e6b7d11082a2")),
            };
        }
        // Cambiar o eliminar información de encabezado y pie de página en una presentación
        public static IList<Attachment> GetEliminarCambiarEncabezadoPiePaginaWordPowerPoint()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Eliminar o cambiar un encabezado o pie de página de una sola página",
                    "Se aplica a: Word 2016 Word 2013 Word 2010 Word 2007 Word Online",
                    "Para eliminar o cambiar el encabezado o pie de página en la primera página haga lo siguiente:\r\r"+
                    ">1. Haga doble clic en el área de encabezado o pie de página (en la parte superior o inferior de la página) para abrir **Herramientas para encabezado y pie de página**.\r\r"+
                    ">2. Active la casilla **Primera página diferente**.\r\r"+
                    ">3. Si el documento incluye un encabezado o pie de página, se quitará de la primera página automáticamente.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/eliminar-o-cambiar-un-encabezado-o-pie-de-p%C3%A1gina-de-una-sola-p%C3%A1gina-a9b6c963-a3e1-4de1-9142-ca1be1dba7ff?ui=es-ES&rs=es-HN&ad=PE")),
                GetHeroCardV2(
                    "Cambiar o eliminar información de encabezado y pie de página en una presentación",
                    "Se aplica a: PowerPoint 2010 y PowerPoint 2007",
                    "Eliminar información de encabezado y pie de página de las diapositivas:\r\r"+
                    ">1. Seleccione la diapositiva que contiene el encabezado o pie de página que desea cambiar.\r\r"+
                    ">2. En la pestaña **Insertar**, en el grupo **Texto**, seleccione **Encabezado y pie de página**.\r\r"+
                    ">3. En el cuadro de diálogo **Encabezado y pie de página**, en la ficha **Diapositiva**, desactive las casillas de verificación correspondientes a las opciones que desee eliminar del encabezado o pie de página.\r\r"+
                    ">4. Haga clic en **Aplicar a todo**.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/cambiar-o-eliminar-informaci%C3%B3n-de-encabezado-y-pie-de-p%C3%A1gina-en-una-presentaci%C3%B3n-5695469d-eaf5-412a-b0ce-e6b7d11082a2")),
            };
        }

        // Adjuntar archivos en power point
        public static IList<Attachment> GetAdjuntarArchivosPowerPoint()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Insertar una hoja de cálculo o algún archivo en PowerPoint",
                    "Se aplica a: PowerPoint 2016 PowerPoint 2013",
                    "Puede vincular datos de una hoja de cálculo guardada Excel a la presentación de PowerPoint si tiene PowerPoint 2013 o posterior.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/insertar-una-hoja-de-c%C3%A1lculo-de-excel-en-powerpoint-0690708a-5ce6-41b4-923f-11d57554138d")),
            };
        }

        // ----------------------------------------------------------------------- 

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

        private static Attachment GetHeroCardV2(string title, string subtitle, string text, CardAction cardAction)
        {
            var heroCard = new HeroCard
            {
                Title = title,
                Subtitle = subtitle,
                Text = text,
                Buttons = new List<CardAction>() { cardAction },
            };
            return heroCard.ToAttachment();
        }

        private static Attachment GetHeroCardV3(string title, CardAction cardAction)
        {
            var heroCard = new HeroCard
            {
                Title = title,
                Buttons = new List<CardAction>() { cardAction },
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

        private static Attachment GetVideoCardV2(string title, string text, string url)
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
                        Type = ActionTypes.OpenUrl
                    }
                }
            };
            return videoCard.ToAttachment();
        }

        private static Attachment GetCardDoubleAction(string firstAction, string action1, string secondAction, string action2)
        {
            var Saludocard = new ThumbnailCard
            {
                Buttons = new List<CardAction>
                {
                    new CardAction(ActionTypes.ImBack, firstAction, value: action1),
                    new CardAction(ActionTypes.ImBack, firstAction, value: action2),
                }
            };
            return Saludocard.ToAttachment();
        }

    }
}