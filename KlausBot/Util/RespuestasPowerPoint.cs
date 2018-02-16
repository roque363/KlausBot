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

        //---------- CREAR ----------
        //---------------------------
        // Crear una presentación básica en cuatro pasos en PowerPoint
        public static IList<Attachment> GetCrearPresentacionPowerPoint()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Crear una presentación básica en cuatro pasos en PowerPoint",
                    "Se aplica a: PowerPoint 2016 PowerPoint 2013 PowerPoint 2010 PowerPoint 2016 para Mac",
                    "Siga los siguientes pasos:\r\r"+
                    ">1. En la pestaña **Diseño**, haga clic en el tema que desee.\r\r"+
                    ">2. En la pestaña **Inicio**, haga clic en **Nueva diapositiva**.\r\r"+
                    ">3. En la pestaña **Transiciones**, haga clic en la transición que desee.\r\r"+
                    ">4. Haga clic en **Aplicar en todo**\r\r"+
                    "Si desea saber como crear una presentación autoejecutable haga clic [aquí](https://support.office.com/es-es/article/Crear-una-presentaci%C3%B3n-autoejecutable-57fc41ae-f36a-4fb5-94a3-52d5bc466037)",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/crear-una-presentaci%C3%B3n-b%C3%A1sica-en-cuatro-pasos-en-powerpoint-076863ce-0107-428d-a0e4-08ad8cea8ce9")),
            };
        }

        // Crear o personalizar un patrón de diapositivas
        public static IList<Attachment> GetCrearPersonalizarPatronDiapositivas()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Crear o personalizar un patrón de diapositivas",
                    "Se aplica a: PowerPoint 2016 PowerPoint 2013 PowerPoint 2010 PowerPoint 2007",
                    "En la vista **Patrón de diapositivas**, el patrón de diapositivas aparece en la parte superior del panel de miniaturas con sus respectivos diseños.\r\r"+
                    "Usted puede cambiar el patrón moviendo las diapositivas donde mejor le parezca.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Crear-o-personalizar-un-patr%C3%B3n-de-diapositivas-036d317b-3251-4237-8ddc-22f4668e2b56")),
                };
        }

        // Utilizar o crear temas en PowerPoint
        public static IList<Attachment> GetUtilizarCrearTemasPowerPoint()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Utilizar o crear temas en PowerPoint",
                    "Se aplica a: PowerPoint 2016 PowerPoint 2013 PowerPoint 2010 PowerPoint 2007",
                    "Puede usar temas en PowerPoint para simplificar el proceso de creación de presentaciones de aspecto profesional. Puede crear su propio"+
                    " tema que contiene colores personalizados, fuentes y efectos, empiece por un tema integrado y cambiar su configuración. A continuación, "+
                    "puede guardar la configuración como un nuevo tema en la Galería de temas.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/utilizar-o-crear-temas-en-powerpoint-83e68627-2c17-454a-9fd8-62deb81951a6?ui=es-ES&rs=es-ES&ad=ES")),
                };
        }

        // Crear un organigrama
        public static IList<Attachment> GetCrearOrganigrama()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Crear un organigrama",
                    "Se aplica a: Excel 2016 Word 2016 Outlook 2016 PowerPoint 2016",
                    "Crear un organigrama\r\r"+
                    ">1. En el grupo **Ilustraciones** de la pestaña **Insertar**, haga clic en **SmartArt**.\r\r"+
                    ">2. En la galería **Elegir un gráfico SmartArt**, haga clic en **Jerarquía**, haga clic en un diseño de organigrama y luego **Aceptar** \r\r"+
                    "Si desea saber como crear un organigrama con una plantilla haga clic [aquí](https://support.office.com/es-es/article/Crear-un-organigrama-en-PowerPoint-con-una-plantilla-d361c25f-665e-4d2c-bfc9-133763511a85)",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Crear-un-organigrama-9b51f667-11b7-4971-a757-a08a36684ee6")),
                };
        }

        // Crear una escala de tiempo
        public static IList<Attachment> GetCrearEscalaTiempo()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Crear una escala de tiempo",
                    "Se aplica a: Excel 2016 Word 2016 Outlook 2016 PowerPoint 2016",
                    "Crear una escala de tiempo\r\r"+
                    ">1. En la ficha **Insertar**, haga clic en **SmartArt**.\r\r"+
                    ">2. En la galería **Elegir un gráfico SmartArt**, haga clic en **proceso** y, a continuación, haga doble clic en un diseño de escala de tiempo.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Crear-una-escala-de-tiempo-9c4448a9-99c7-4b0e-8eff-0dcf535f223c")),
                };
        }

        //--------- APLICAR ---------
        //---------------------------
        // Aplicar varios efectos de animación a un objeto
        public static IList<Attachment> GetAplicarVariosEfectosAnimacion()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Aplicar varios efectos de animación a un objeto",
                    "Se aplica a: PowerPoint 2016 PowerPoint 2013",
                    "Siga los siguientes pasos:\r\r"+
                    ">1. Seleccione el objeto de la diapositiva que desee animar.\r\r"+
                    ">2. En la pestaña **Animaciones**, haga clic en **Panel de animación**.\r\r"+
                    ">3. Haga clic en **Agregar animación** y elija un efecto de animación.\r\r",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/aplicar-varios-efectos-de-animaci%C3%B3n-a-un-objeto-9bb7b925-ab0f-47d4-bc11-85d939194bed")),
            };
        }

        // Insertar y reproducir un archivo de vídeo
        public static IList<Attachment> GetInsertarArchivoVideo()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Insertar y reproducir un archivo de vídeo",
                    "Se aplica a: PowerPoint 2016 PowerPoint 2013 PowerPoint 2010 PowerPoint 2007",
                    "Insertar un vídeo almacenado en su equipo\r\r"+
                    ">1. En la pestaña **Insertar**, haga clic en la flecha situada debajo de **Video** y luego en **Video en Mi PC**.\r\r"+
                    ">2. En el cuadro de diálogo **Insertar vídeo**, haga clic en el vídeo que desea y a continuación, haga clic en **Insertar**.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/insertar-y-reproducir-un-archivo-de-v%C3%ADdeo-desde-su-equipo-o-desde-onedrive-f3fcbd3e-5f86-4320-8aea-31bff480ed02?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Agregar texto a una diapositiva
        public static IList<Attachment> GetAgregarTextoDiapositiva()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Agregar texto a una diapositiva",
                    "Se aplica a: PowerPoint 2016 PowerPoint 2013 PowerPoint 2010",
                    "Puede agregar texto a una diapositiva de PowerPoint o a un patrón de diapositivas insertando un cuadro de texto y escribiendo dentro de ese cuadro. "+
                    "También puede eliminar ese texto seleccionando el texto o el cuadro completo y agregar texto a marcadores de posición y formas.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/agregar-texto-a-una-diapositiva-11b8b646-f775-4b77-a512-ca51bb54b26c")),
            };
        }

        // Agregar un encabezado o pie de página a documentos o notas
        public static IList<Attachment> GetAgregarEncabezadoPiePaginaPowerPoint()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Agregar un encabezado o pie de página a documentos o notas",
                    "Se aplica a: PowerPoint 2016 PowerPoint 2013 PowerPoint 2010 PowerPoint 2007",
                    "En PowerPoint, notas y documentos tiene encabezados y pies de página. Diapositivas tienen sólo pies de página."+
                    " Haga click en **Ver más información** para ver instrucciones detalladas.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/agregar-un-encabezado-o-pie-de-p%C3%A1gina-a-documentos-o-notas-882efcea-35cd-4b68-ac0b-041ae1ba7099?ui=es-ES&rs=es-ES&ad=ES")),
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