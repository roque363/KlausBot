using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using Microsoft.Bot.Connector;

namespace KlausBot.Util
{
    public class RespuestasExcel
    {
        // -------------------------------------------------------------
        // PREGUNTAS DE EXCEL
        // -------------------------------------------------------------
        // ----------- DEFINICION ------------
        // Definicon de Excel
        public static IList<Attachment> GetExcelDefinicionCard()
        {
            return new List<Attachment>()
            {
                GetHeroCard(
                    "¿Qué es Excel?",
                    "Significad e historia de  Excel",
                    "Excel es un programa informático desarrollado por Microsoft y forma parte de Office. Excel se distingue de los demás programas porque nos permite trabajar con datos " +
                    "numéricos, es decir, podemos realizar cálculos, crear tablas o gráficos y también podemos analizar los datos con herramientas " +
                    "tan avanzadas como las tablas dinámicas.",
                    new CardImage(url: "https://policyviz.com/wp-content/uploads/2017/07/Excel-Logo.png")),
                GetVideoCard(
                    "Office 365 - Excel",
                    "Video sobre excel",
                    "https://wus-streaming-video-rt-microsoft-com.akamaized.net/ad1ced2a-75fd-4e49-9cbd-099a618cb778/f44d7b46-f1aa-4246-8c2d-b6aa6cd1_1920x1080_2762.mp4",
                    "https://support.office.com/es-es/article/Inicio-r%C3%A1pido-de-Excel-2016-94b00f50-5896-479c-b0c5-ff74603b35a3?ui=es-ES&rs=es-ES&ad=ES"),
            };
        }

        // Adjuntar archivos en excel
        public static IList<Attachment> GetAdjuntarArchivosExcel()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Insertar un objeto en la hoja de cálculo de Excel",
                    "Se aplica a: Excel 2016 Excel 2013 Excel 2010 Excel 2007",
                    "Puede usar vinculación e incrustación de objetos (OLE) para incluir contenido de otros programas, como Word o Excel.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/insertar-un-objeto-en-la-hoja-de-c%C3%A1lculo-de-excel-e73867b2-2988-4116-8d85-f5769ea435ba")),
            };
        }

        //CREAR
        //---------------------
        // Crear una tabla en el estilo que desee
        public static IList<Attachment> GetCrearTablaExcel()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Crear o eliminar una tabla de Excel",
                    "Se aplica a: Excel 2016 Excel 2013 Excel 2010 Excel 2007 Excel 2016 para Mac Excel para Mac 2011",
                    "Siga los siguientes pasos para crear una tabla:\r\r"+
                    ">1. Seleccione cualquier rango de celdas que desea incluir en la tabla.\r\r"+
                    ">2. En la pestaña **Inicio**, haga clic en **Estilos** > **Dar formato como tabla** > seleccione un estilo en la **Galería de estilos** de tabla.\r\r"+
                    ">3. Excel resaltará automáticamente el rango de datos de la tabla, si todo esta bien haga click en **Aceptar**.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/crear-o-eliminar-una-tabla-de-excel-e81aa349-b006-4f8a-9806-5af9df0ac664")),
            };
        }

        // Crear un gráfico con gráficos recomendados
        public static IList<Attachment> GetCrearGraficoExcel()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Crear un gráfico con gráficos recomendados",
                    "Se aplica a: Excel 2016 Excel 2013",
                    "Pruebe el comando **Gráficos recomendados** de la pestaña **Insertar** para crear con rapidez un gráfico que sea justo el adecuado para sus datos.\r\r"+
                    ">1. [Seleccione los datos](https://support.office.com/es-es/article/seleccionar-datos-para-un-gr%C3%A1fico-5fca57b7-8c52-4e09-979a-631085113862?ui=es-ES&rs=es-ES&ad=ES) para los que desea crear un gráfico.\r\r"+
                    ">2. Haga clic en **Insertar** > **Tablas dinámicas recomendadas**.\r\r"+
                    ">3. En la pestaña **Gráficos recomendados**, escoja el gráfico de su preferencia y haga clic en **Aceptar**.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/crear-un-gr%C3%A1fico-con-gr%C3%A1ficos-recomendados-cd131b77-79c7-4537-a438-8db20cea84c0?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }
        // Crear un gráfico de Excel en Word y crear un gráfico con gráficos recomendados
        public static IList<Attachment> GetCrearGraficoWordExcel()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Crear un gráfico de Excel en Word",
                    "Se aplica a: Word 2013",
                     "Siga los siguientes pasos:\r\r"+
                    ">1. En su documento de Word, haga clic en **Insertar** > **Gráfico**.\r\r"+
                    ">2. Seleccione el tipo de gráfico que quiera, como una columna o un gráfico circular, y haga clic en **Aceptar**.\r\r"+
                    ">3. Introduzca sus datos en una hoja de cálculo que se abre automáticamente con el gráfico.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Crear-un-gr%C3%A1fico-de-Excel-en-Word-11a7d2f0-4487-4a9b-bbc6-d50916cd4a57")),
                GetHeroCardV2(
                    "Crear un gráfico con gráficos recomendados",
                    "Se aplica a: Excel 2016 Excel 2013",
                    "Pruebe el comando **Gráficos recomendados** de la pestaña **Insertar** para crear con rapidez un gráfico que sea justo el adecuado para sus datos.\r\r"+
                    ">1. [Seleccione los datos](https://support.office.com/es-es/article/seleccionar-datos-para-un-gr%C3%A1fico-5fca57b7-8c52-4e09-979a-631085113862?ui=es-ES&rs=es-ES&ad=ES) para los que desea crear un gráfico.\r\r"+
                    ">2. Haga clic en **Insertar** > **Tablas dinámicas recomendadas**.\r\r"+
                    ">3. En la pestaña **Gráficos recomendados**, escoja el gráfico de su preferencia y haga clic en **Aceptar**.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/crear-un-gr%C3%A1fico-con-gr%C3%A1ficos-recomendados-cd131b77-79c7-4537-a438-8db20cea84c0?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }
        // Crear e imprimir etiquetas postales para una lista de direcciones en Excel
        public static IList<Attachment> GetCrearEtiquetasPostalesExcel()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Crear e imprimir etiquetas postales para una lista de direcciones en Excel",
                    "Se aplica a: Excel 2016 Excel 2013 Excel 2010",
                    "Para crear e imprimir las etiquetas postales, primero debe preparar los datos de la hoja de cálculo en Excel y "+
                    "utilizar después Word para configurar, organizar, revisar e imprimir las etiquetas postales."+
                    "Si desea utilizar etiquetas de dirección para realizar envíos masivos de correo a su lista de direcciones, puede "+
                    "usar la combinación de correspondencia para crear una hoja de etiquetas de dirección.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Crear-e-imprimir-etiquetas-postales-para-una-lista-de-direcciones-en-Excel-d9484315-5123-48ae-bc58-2e8dcf271252")),
               };
        }
        // Crear etiquetas Word y Crear e imprimir etiquetas postales para una lista de direcciones en Excel
        public static IList<Attachment> GetCrearEtiquetasWordEtiquetasPostalesExcel()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Crear una lista de comprobación en Word",
                    "Se aplica a: Word 2016 Word 2013 Word 2010 Word 2007 Word Starter 2010",
                    "Para un lote de etiquetas diferentes, se recomienda empezar el documento desde una plantilla de etiqueta. "+
                    "Para buscar una, vaya a la pestaña **Archivo** en Word, haga clic en **Nuevo** y, a continuación, en el cuadro"+
                    " de búsqueda, escriba etiquetas y presione Entrar. O bien, en el explorador, consulte [plantillas de etiquetas en templates.office.com](https://templates.office.com/en-us/Labels).\r\r"+
                    "Si desea saber como crear etiquetas de dirección de retorno haga clic [aquí](https://support.office.com/es-es/article/Crear-etiquetas-de-remite-be712991-16dd-4b9e-810e-35b5320c922b)",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/hacer-una-lista-de-comprobaci%C3%B3n-en-word-dd04fa4f-2ca7-4543-8818-c469eca9f45c?ui=es-ES&rs=es-ES&ad=ES")),

                GetHeroCardV2(
                    "Crear e imprimir etiquetas postales para una lista de direcciones en Excel",
                    "Se aplica a: Excel 2016 Excel 2013 Excel 2010",
                    "Para crear e imprimir las etiquetas postales, primero debe preparar los datos de la hoja de cálculo en Excel y "+
                    "utilizar después Word para configurar, organizar, revisar e imprimir las etiquetas postales."+
                    "Si desea utilizar etiquetas de dirección para realizar envíos masivos de correo a su lista de direcciones, puede "+
                    "usar la combinación de correspondencia para crear una hoja de etiquetas de dirección.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Crear-e-imprimir-etiquetas-postales-para-una-lista-de-direcciones-en-Excel-d9484315-5123-48ae-bc58-2e8dcf271252")),
               };
        }

        // COMPARTIR
        // ---------------------
        //Compartir el libro de Excel con otros usuarios
        public static IList<Attachment> GetCompartirLibrosExcelOtrosUsuarios()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Compartir el libro de Excel con otros usuarios",
                    "Se aplica a: Excel 2016 Excel 2016 para Mac",
                    ">1. Si ha cargado el archivo, haga clic en el nombre de archivo para abrirlo. El libro se abrirá en una pestaña nueva en el explorador web.\r\r"+
                    ">2. Haga clic en el botón Editar en Excel. Si no se encuentra este botón, haga clic en Editar en el exploradory, después, haga clic en Editar en Excel después de que se vuelva a cargar la página.\r\r"+
                    ">3. Cuando el archivo se abra en el programa Excel, haga clic en Compartir en la esquina superior derecha.\r\r"+
                    ">4. Escriba las direcciones de correo electrónico en el cuadro Invitar a personas y sepárelas entre sí con un punto y coma. Asegúrese de seleccionar Puede editar. Cuando haya terminado, haga clic en el botón Enviar.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/compartir-el-libro-de-excel-con-otros-usuarios-8d8a52bb-03c3-4933-ab6c-330aabf1e589?ui=es-ES&rs=es-ES&ad=ES")),
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