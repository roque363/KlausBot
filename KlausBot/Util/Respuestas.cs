using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Bot.Connector;

namespace KlausBot.Util
{
    public class Respuestas
    {
        // Imagenes en 600px - 300px
        // -------------------------------------------------------------
        // PREGUNTAS DE EXCEL
        // -------------------------------------------------------------
        // DEFINICION        // ---------------------
        // Definicon de Excel
        public static IList<Attachment> GetExcelDefinicionCard()
        {
            return new List<Attachment>()
            {
                GetHeroCard(
                    "¿Qué es Excel?",
                    "Significad e historia de  Excel",
                    "Excel es un programa informático desarrollado por Microsoft y forma parte de Office que es una suite ofimática la cual incluye " +
                    "otros programas como Word y PowerPoint. Excel se distingue de los demás programas porque nos permite trabajar con datos " +
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

        // -------------------------------------------------------------
        // PREGUNTAS DE POWER POINT
        // -------------------------------------------------------------
        // DEFINICION
        // --------------------
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

        // -------------------------------------------------------------
        // PREGUNTAS DE ONE NOTE
        // -------------------------------------------------------------
        // Adjuntar archivos en one note
        public static IList<Attachment> GetAgregarArchivosOneNote()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Cómo adjuntar un arhivo en One Note",
                    "Se aplica a: OneNote 2013",
                    "OneNote puede conservar toda la información acerca de un asunto o un proyecto en un único lugar, incluidas las copias de archivos y documentos relacionados.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/tareas-b%C3%A1sicas-en-microsoft-onenote-2013-da73c095-e082-4276-acf9-8728ca8b08ab")),
            };
        }

        // -------------------------------------------------------------
        // PREGUNTAS DE WORD
        // -------------------------------------------------------------
        // DEFINICION
        // --------------------
        // Definicon de Word
        public static IList<Attachment> GetWordDefinicionCard()
        {
            return new List<Attachment>()
            {
                GetHeroCard(
                    "¿Qué es Word?",
                    "",
                    "Microsoft Word es un programa informático orientado al procesamiento de textos. Fue creado por la empresa Microsoft, y viene " +
                    "integrado predeterminadamente en el paquete ofimático denominado Microsoft Office.",
                    new CardImage(url: "https://www.adslzone.net/app/uploads/2017/01/word-ms.jpg")),
                GetVideoCard(
                    "Office 365 - Word",
                    "Video sobre Word",
                    "https://videocontent.osi.office.net/92cbca43-f999-4546-9aa4-e9a0a0494579/626d11f6-fbdf-4f5c-987f-952a73376352_1280x720_3400.mp4",
                    "https://support.office.com/es-es/article/V%C3%ADdeo-%C2%BFQu%C3%A9-es-Word-aee9c7ff-f9c5-415f-80dc-103ad5e344d7"),
            };
        }

        // Crear un documento Word
        public static IList<Attachment> GetCrearDocumentoWord()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Crear un documento",
                    "Se aplica a: Word 2016 Word 2013 Word 2010 Word 2007 Word Online",
                    "Empezar a usar un documento básico en Microsoft Office Word es tan fácil como abrir un documento nuevo o existente, y empezar a escribir. ",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/crear-un-documento-3aa3c766-9733-4f60-9efa-de245467c13d")),
            };
        }

        // Cambiar vista en Word
        public static IList<Attachment> GetCambiarVistaWord()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Cómo cambiar la vista predeterminada a la vista Borrador en Word",
                    "Se aplica a: Word 2016 Microsoft Word 2013Microsoft Word 2010Microsoft Office Word 2007",
                    "Para cambiar la vista predeterminada a la vista borrador cuando se abre un documento de Word 2007",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.microsoft.com/es-es/help/919599/how-to-change-the-default-view-to-draft-view-in-word")),
            };
        }

        // Adjuntar archivos en word
        public static IList<Attachment> GetAgregarArchivosWord()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Insertar un documento en Word",
                    "Se aplica a: Word 2016 Word 2013 Word 2010 Word 2007",
                    "Puede insertar el contenido de documentos de Microsoft Office Word creados previamente en un documento de Microsoft Office Word nuevo o diferente.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/insertar-un-documento-en-word-274128e5-4da7-4cb8-b65f-3d8b585e03f1")),
            };
        }

        // -------------------------------------------------------------
        // TEMAS DESTACADOS
        // -------------------------------------------------------------
        // Temas destacados de Outlook
        public static IList<Attachment> GetDestacadosOutlook()
        {
            return new List<Attachment>()
            {
                // Novedades en Outlook 2016 para Windows
                GetHeroCardV4(
                    new CardImage(url: HttpContext.Current.Server.MapPath("~/Images/Outlook/Destacados/destacadosOutlook1.png")),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-ES/article/Novedades-en-Outlook-2016-para-Windows-51c81e7a-de25-4a34-a7fe-bd79f8e48647")),
                // Crear y agregar una firma a los mensajes
                 GetHeroCardV4(
                    new CardImage(url: HttpContext.Current.Server.MapPath("~/Images/Outlook/Destacados/destacadosOutlook2.png")),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Crear-y-agregar-una-firma-a-los-mensajes-8ee5d4f4-68fd-464a-a1c1-0e1c80bb27f2#ID0EAABAAA=2016,_2013")),
                // Enviar respuestas automáticas "Fuera de la oficina" de Outlook
                GetHeroCardV4(
                    new CardImage(url: HttpContext.Current.Server.MapPath("~/Images/Outlook/Destacados/destacadosOutlook3.png")),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Enviar-respuestas-autom%C3%A1ticas-Fuera-de-la-oficina-de-Outlook-9742f476-5348-4f9f-997f-5e208513bd67?ui=es-ES&rs=es-ES&ad=ES")),
                // Importar contactos desde Gmail
                GetHeroCardV4(
                    new CardImage(url: HttpContext.Current.Server.MapPath("~/Images/Outlook/Destacados/destacadosOutlook4.png")),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Importar-contactos-desde-Gmail-ad99d439-04b6-4001-a266-c170df721291?ui=es-ES&rs=es-ES&ad=ES")),
                // Importar contactos a Outlook
                GetHeroCardV4(
                    new CardImage(url: HttpContext.Current.Server.MapPath("~/Images/Outlook/Destacados/destacadosOutlook5.png")),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-ES/article/Importar-contactos-a-Outlook-bb796340-b58a-46c1-90c7-b549b8f3c5f8")),
                // Recuperar elementos eliminados en Outlook para Windows
                GetHeroCardV4(
                    new CardImage(url: HttpContext.Current.Server.MapPath("~/Images/Outlook/Destacados/destacadosOutlook6.png")),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Recuperar-elementos-eliminados-en-Outlook-para-Windows-49e81f3c-c8f4-4426-a0b9-c0fd751d48ce?ui=es-ES&rs=es-ES&ad=ES")),
                // Recuperar o reemplazar un mensaje después de enviarlo
                GetHeroCardV4(
                    new CardImage(url: HttpContext.Current.Server.MapPath("~/Images/Outlook/Destacados/destacadosOutlook7.png")),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Recuperar-o-reemplazar-un-mensaje-despu%C3%A9s-de-enviarlo-35027f88-d655-4554-b4f8-6c0729a723a0?ui=es-ES&rs=es-ES&ad=ES")),
                // Outlook no responde, se detiene en «Procesando», deja de funcionar, se inmoviliza o se bloquea
                GetHeroCardV4(
                    new CardImage(url: HttpContext.Current.Server.MapPath("~/Images/Outlook/Destacados/destacadosOutlook8.png")),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Outlook-no-responde-se-detiene-en-%C2%ABProcesando%C2%BB-deja-de-funcionar-se-inmoviliza-o-se-bloquea-5c313d04-64af-4441-82d2-44e5a43eee5a?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Temas destacados de OneDrive
        public static IList<Attachment> GetDestacadosOneDrive()
        {
            return new List<Attachment>()
            {
                // ¿Qué es OneDrive para la Empresa?
                GetHeroCardV4(
                    new CardImage(url: HttpContext.Current.Server.MapPath("~/Images/OneDrive/Destacados/1.png")),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-ES/article/%C2%BFQu%C3%A9-es-OneDrive-para-la-Empresa-187f90af-056f-47c0-9656-cc0ddca7fdc2")),
                // ¿Qué versión de OneDrive uso?
                 GetHeroCardV4(
                    new CardImage(url: HttpContext.Current.Server.MapPath("~/Images/OneDrive/Destacados/2.png")),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/%C2%BFQu%C3%A9-versi%C3%B3n-de-OneDrve-uso-19246eae-8a51-490a-8d97-a645c151f2ba?ui=es-ES&rs=es-ES&ad=ES")),
                // Cargar fotografías y archivos en OneDrive
                GetHeroCardV4(
                    new CardImage(url: HttpContext.Current.Server.MapPath("~/Images/OneDrive/Destacados/3.png")),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-ES/article/Cargar-fotograf%C3%ADas-y-archivos-en-OneDrive-b00ad3fe-6643-4b16-9212-de00ef02b586")),
                // Recuperar archivos de tu equipo
                GetHeroCardV4(
                    new CardImage(url: HttpContext.Current.Server.MapPath("~/Images/OneDrive/Destacados/4.png")),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Recuperar-archivos-de-tu-equipo-70761550-519c-4d45-b780-5a613b2f8822?ui=es-ES&rs=es-ES&ad=ES")),
                // Compartir archivos y carpetas de OneDrive
                GetHeroCardV4(
                    new CardImage(url: HttpContext.Current.Server.MapPath("~/Images/OneDrive/Destacados/5.png")),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-ES/article/Compartir-archivos-y-carpetas-de-OneDrive-9fcc2f7d-de0c-4cec-93b0-a82024800c07")),
                // Usar OneDrive para Android
                GetHeroCardV4(
                    new CardImage(url: HttpContext.Current.Server.MapPath("~/Images/OneDrive/Destacados/6.png")),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-ES/article/Usar-OneDrive-para-Android-eee1d31c-792d-41d4-8132-f9621b39eb36")),
                // Solucionar problemas de sincronización de OneDrive
                GetHeroCardV4(
                    new CardImage(url: HttpContext.Current.Server.MapPath("~/Images/OneDrive/Destacados/7.png")),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-ES/article/Solucionar-problemas-de-sincronizaci%C3%B3n-de-OneDrive-0899b115-05f7-45ec-95b2-e4cc8c4670b2")),
                // Configurar el equipo para sincronizar los archivos de OneDrive para la Empresa en Office 365
                GetHeroCardV4(
                    new CardImage(url: HttpContext.Current.Server.MapPath("~/Images/OneDrive/Destacados/8.png")),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Configurar-el-equipo-para-sincronizar-los-archivos-de-OneDrive-para-la-Empresa-en-Office-365-23e1f12b-d896-4cb1-a238-f91d19827a16?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Temas destacados de Word
        public static IList<Attachment> GetDestacadosWord()
        {
            return new List<Attachment>()
            {
                // Novedades de Word 2016 para Windows
                GetHeroCardV4(
                    new CardImage(url: HttpContext.Current.Server.MapPath("~/Images/Word/Destacados/1.png")),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Novedades-de-Word-2016-para-Windows-4219dfb5-23fc-4853-95aa-b13a674a6670?ui=es-ES&rs=es-ES&ad=ES")),
                // Descargar plantillas pregeneradas gratuitas
                 GetHeroCardV4(
                    new CardImage(url: HttpContext.Current.Server.MapPath("~/Images/Word/Destacados/2.png")),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-ES/article/Descargar-plantillas-pregeneradas-gratuitas-29f2a18d-29a6-4a07-998b-cfe5ff7ffbbb")),
                // Realizar un seguimiento de los cambios en Word
                GetHeroCardV4(
                    new CardImage(url: HttpContext.Current.Server.MapPath("~/Images/Word/Destacados/3.png")),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Realizar-un-seguimiento-de-los-cambios-en-Word-197ba630-0f5f-4a8e-9a77-3712475e806a?ui=es-ES&rs=es-ES&ad=ES")),
                // Cambiar o establecer la fuente predeterminada
                GetHeroCardV4(
                    new CardImage(url: HttpContext.Current.Server.MapPath("~/Images/Word/Destacados/4.png")),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-ES/article/Cambiar-o-establecer-la-fuente-predeterminada-20f72414-2c42-4b53-9654-d07a92b9294a")),
                // Agregar un gráfico al documento en Word
                GetHeroCardV4(
                    new CardImage(url: HttpContext.Current.Server.MapPath("~/Images/Word/Destacados/5.png")),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Agregar-un-gr%C3%A1fico-al-documento-en-Word-ff48e3eb-5e04-4368-a39e-20df7c798932?ui=es-ES&rs=es-ES&ad=ES")),
                // Soporte de accesibilidad para Word
                GetHeroCardV4(
                    new CardImage(url: HttpContext.Current.Server.MapPath("~/Images/Word/Destacados/6.png")),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-ES/article/Soporte-de-accesibilidad-para-Word-c014d8b8-4ef3-4a7a-935d-295663f3343c")),
                // Iniciar la numeración de páginas más adelante en el documento
                GetHeroCardV4(
                    new CardImage(url: HttpContext.Current.Server.MapPath("~/Images/Word/Destacados/7.png")),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-ES/article/Iniciar-la-numeraci%C3%B3n-de-p%C3%A1ginas-m%C3%A1s-adelante-en-el-documento%C2%A0-c73e3d55-d722-4bd0-886e-0b0bd0eb3f02")),
                // Eliminar o cambiar un encabezado o pie de página de una sola página
                GetHeroCardV4(
                    new CardImage(url: HttpContext.Current.Server.MapPath("~/Images/Word/Destacados/8.png")),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Eliminar-o-cambiar-un-encabezado-o-pie-de-p%C3%A1gina-de-una-sola-p%C3%A1gina-a9b6c963-a3e1-4de1-9142-ca1be1dba7ff?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Temas destacados de Excel
        public static IList<Attachment> GetDestacadosExcel()
        {
            return new List<Attachment>()
            {
                // Novedades en Excel 2016 para Windows
                GetHeroCardV4(
                    new CardImage(url: HttpContext.Current.Server.MapPath("~/Images/Excel/Destacados/1.png")),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-ES/article/Novedades-en-Excel-2016-para-Windows-5fdb9208-ff33-45b6-9e08-1f5cdb3a6c73")),
                // Mover o copiar hojas de cálculo o los datos que contienen
                 GetHeroCardV4(
                    new CardImage(url: HttpContext.Current.Server.MapPath("~/Images/Excel/Destacados/2.png")),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Mover-o-copiar-hojas-de-c%C3%A1lculo-o-los-datos-que-contienen-47207967-bbb2-4e95-9b5c-3c174aa69328?ui=es-ES&rs=es-ES&ad=ES")),
                // Crear una lista desplegable
                GetHeroCardV4(
                    new CardImage(url: HttpContext.Current.Server.MapPath("~/Images/Excel/Destacados/3.png")),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-ES/article/Crear-una-lista-desplegable-7693307a-59ef-400a-b769-c5402dce407b")),
                // Guardar un libro con otro formato de archivo
                 GetHeroCardV4(
                    new CardImage(url: HttpContext.Current.Server.MapPath("~/Images/Excel/Destacados/4.png")),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-ES/article/guardar-un-libro-con-otro-formato-de-archivo-6a16c862-4a36-48f9-a300-c2ca0065286e")),
                // Calcular la diferencia entre dos fechas
                GetHeroCardV4(
                    new CardImage(url: HttpContext.Current.Server.MapPath("~/Images/Excel/Destacados/5.png")),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-ES/article/Calcular-la-diferencia-entre-dos-fechas-8235e7c9-b430-44ca-9425-46100a162f38")),
                // Inmovilizar paneles para bloquear filas y columnas
                GetHeroCardV4(
                    new CardImage(url: HttpContext.Current.Server.MapPath("~/Images/Excel/Destacados/6.png")),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-ES/article/Inmovilizar-paneles-para-bloquear-filas-y-columnas-dab2ffc9-020d-4026-8121-67dd25f2508f")),
                // Funciones de Excel (por orden alfabético)
                GetHeroCardV4(
                    new CardImage(url: HttpContext.Current.Server.MapPath("~/Images/Excel/Destacados/7.png")),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Funciones-de-Excel-por-orden-alfab%C3%A9tico-b3944572-255d-4efb-bb96-c6d90033e188?ui=es-ES&rs=es-ES&ad=ES")),
                // Cómo evitar la ruptura de las fórmulas
                GetHeroCardV4(
                    new CardImage(url: HttpContext.Current.Server.MapPath("~/Images/Excel/Destacados/8.png")),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-ES/article/C%C3%B3mo-evitar-la-ruptura-de-las-f%C3%B3rmulas-8309381d-33e8-42f6-b889-84ef6df1d586")),
                // Soporte de accesibilidad para Excel
                GetHeroCardV4(
                    new CardImage(url: HttpContext.Current.Server.MapPath("~/Images/Excel/Destacados/9.png")),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-ES/article/Soporte-de-accesibilidad-para-Excel-0976b140-7033-4e2d-8887-187280701bf8")),
            };
        }

        // Temas destacados de PowerPoint
        public static IList<Attachment> GetDestacadosPowerPoint()
        {
            return new List<Attachment>()
            {
                // Formatos de archivo de audio y vídeo compatibles con PowerPoint
                GetHeroCardV4(
                    new CardImage(url: HttpContext.Current.Server.MapPath("~/Images/PowerPoint/Destacados/1.png")),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/formatos-de-archivo-de-audio-y-v%C3%ADdeo-compatibles-con-powerpoint-d8b12450-26db-4c7b-a5c1-593d3418fb59?wt.mc_id=ppt_home&ui=es-ES&rs=es-ES&ad=ES")),
                // Agregar imágenes prediseñadas a un archivo
                 GetHeroCardV4(
                    new CardImage(url: HttpContext.Current.Server.MapPath("~/Images/PowerPoint/Destacados/2.png")),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Agregar-im%C3%A1genes-predise%C3%B1adas-a-un-archivo-0a01ae25-973c-4c2c-8eaf-8c8e1f9ab530?wt.mc_id=ppt_home&ui=es-ES&rs=es-ES&ad=ES")),
                // Convertir una presentación en un vídeo
                GetHeroCardV4(
                    new CardImage(url: HttpContext.Current.Server.MapPath("~/Images/PowerPoint/Destacados/3.png")),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Convertir-una-presentaci%C3%B3n-en-un-v%C3%ADdeo-c140551f-cb37-4818-b5d4-3e30815c3e83?wt.mc_id=ppt_home&ui=es-ES&rs=es-ES&ad=ES")),
                // Agregar una marca de agua "BORRADOR" al fondo de las diapositivas
                GetHeroCardV4(
                    new CardImage(url: HttpContext.Current.Server.MapPath("~/Images/PowerPoint/Destacados/4.png")),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Agregar-una-marca-de-agua-BORRADOR-al-fondo-de-las-diapositivas-ea4cc5f5-ea5d-4213-9c7d-ed01a7952ed0?wt.mc_id=ppt_home&ui=es-ES&rs=es-ES&ad=ES")),
                // Ver las notas del orador al exponer una presentación con diapositivas
                GetHeroCardV4(
                    new CardImage(url: HttpContext.Current.Server.MapPath("~/Images/PowerPoint/Destacados/5.png")),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/iniciar-la-presentaci%C3%B3n-y-ver-las-notas-en-la-vista-moderador-4de90e28-487e-435c-9401-eb49a3801257?wt.mc_id=ppt_home&ui=es-ES&rs=es-ES&ad=ES")),
                // Reproducir música durante toda la presentación con diapositivas
                GetHeroCardV4(
                    new CardImage(url: HttpContext.Current.Server.MapPath("~/Images/PowerPoint/Destacados/6.png")),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Reproducir-m%C3%BAsica-durante-toda-la-presentaci%C3%B3n-con-diapositivas-b01ded6a-28c8-473a-971a-6dfa92cc9367?wt.mc_id=ppt_home&ui=es-ES&rs=es-ES&ad=ES")),
                // ¿Qué es un patrón de diapositivas?
                GetHeroCardV4(
                    new CardImage(url: HttpContext.Current.Server.MapPath("~/Images/PowerPoint/Destacados/7.png")),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-ES/article/%C2%BFQu%C3%A9-es-un-patr%C3%B3n-de-diapositivas-b9abb2a0-7aef-4257-a14e-4329c904da54?wt.mc_id=ppt_home")),
                // Soporte de accesibilidad para PowerPoint
                GetHeroCardV4(
                    new CardImage(url: HttpContext.Current.Server.MapPath("~/Images/PowerPoint/Destacados/8.png")),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-ES/article/Soporte-de-accesibilidad-para-PowerPoint-9d2b646d-0b79-4135-a570-b8c7ad33ac2f?wt.mc_id=ppt_home")),
            };
        }

        // Temas destacados de OneNote
        public static IList<Attachment> GetDestacadosOneNote()
        {
            return new List<Attachment>()
            {
                // Novedades de OneNote para Windows 10
                GetHeroCardV4(
                    new CardImage(url: HttpContext.Current.Server.MapPath("~/Images/OneNote/Destacados/1.png")),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Novedades-de-OneNote-para-Windows-10-1477d5de-f4fd-4943-b18a-ff17091161ea?ui=es-ES&rs=es-ES&ad=ES")),
                // Introducción al nuevo OneNote
                 GetHeroCardV4(
                    new CardImage(url: HttpContext.Current.Server.MapPath("~/Images/OneNote/Destacados/2.png")),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-ES/article/Introducci%C3%B3n-al-nuevo-OneNote-ab84fcc2-f845-41ac-9c29-89b0720c8eb3")),
                // Tareas básicas en OneNote para Windows 10
                GetHeroCardV4(
                    new CardImage(url: HttpContext.Current.Server.MapPath("~/Images/OneNote/Destacados/3.png")),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Tareas-básicas-en-OneNote-para-Windows-10-081573f8-2e8f-45e5-bf16-0900d4d3331f?ui=es-ES&rs=es-ES&ad=ES")),
                // Enviar fotos e imágenes de otras aplicaciones a OneNote
                GetHeroCardV4(
                    new CardImage(url: HttpContext.Current.Server.MapPath("~/Images/OneNote/Destacados/4.png")),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Enviar-fotos-e-im%C3%A1genes-de-otras-aplicaciones-a-OneNote-para-Windows-10-02e66db1-eb04-4297-a41b-b82648aa843d?ui=es-ES&rs=es-ES&ad=ES")),
                // Sincronizar blocs de notas en OneNote 
                GetHeroCardV4(
                    new CardImage(url: HttpContext.Current.Server.MapPath("~/Images/OneNote/Destacados/5.png")),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Sincronizar-blocs-de-notas-en-OneNote-para-Windows-10-21cb4629-3ef4-4220-8539-d01d29491e6a?ui=es-ES&rs=es-ES&ad=ES")),
                // Compartir una página de notas o un bloc de notas completo
                GetHeroCardV4(
                    new CardImage(url: HttpContext.Current.Server.MapPath("~/Images/OneNote/Destacados/6.png")),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Compartir-una-p%C3%A1gina-de-notas-o-un-bloc-de-notas-completo-desde-OneNote-para-Windows-10-d4a74a14-44a3-411e-8fb5-06e73ddf047f?ui=es-ES&rs=es-ES&ad=ES")),
                // Proteger las notas con contraseña en OneNote para Windows 10
                GetHeroCardV4(
                    new CardImage(url: HttpContext.Current.Server.MapPath("~/Images/OneNote/Destacados/7.png")),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Proteger-las-notas-con-contrase%C3%B1a-en-OneNote-para-Windows-10-a2fd9183-c864-4653-9c4e-714a116a4ab7?ui=es-ES&rs=es-ES&ad=ES")),
                // Solucionar problemas en OneNote para Windows 10
                GetHeroCardV4(
                    new CardImage(url: HttpContext.Current.Server.MapPath("~/Images/OneNote/Destacados/8.png")),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Solucionar-problemas-en-OneNote-para-Windows-10-942b006c-46ac-4300-a629-7fac5ae4dc70?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // -------------------------------------------------------------
        // PREGUNTAS CON VARIOS SERVICIOS
        // -------------------------------------------------------------
        // Abrir archivos en su dispositivo móvil
        // Abrir y cerrar archivos de datos de Outlook (.pst)
        public static IList<Attachment> GetAbrirArchivosOneDriveOutlook()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                "Abrir archivos en su dispositivo móvil",
                "Se aplica a: OneDrive para la Empresa OneDrive",
                "Primero: pulse el archivo para obtener una vista previa. Segundo: Pulse el icono de la aplicación de Office en la parte superior para abrir el archivo.",
                new CardAction(ActionTypes.OpenUrl, "Ver más información",
                value: "https://support.office.com/es-es/article/inicio-r%C3%A1pido-de-onedrive-a5710114-6aeb-4bf5-a336-dffa7cc0b77a?ui=es-ES&rs=es-ES&ad=ES#ID0EAABAAA=Seguir_conectado")),
                GetHeroCardV2(
                    "Abrir y cerrar archivos de datos de Outlook (.pst)",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010 Outlook 2007",
                    "Outlook es parte de su rutina diaria. Se usa para enviar mensajes de correo electrónico, configurar eventos del calendario y crear tareas y otros elementos.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Abrir-y-cerrar-Archivos-de-datos-de-Outlook-pst-381b776d-7511-45a0-953a-0935c79d24f2")),
            };
        }

        // -------------------------------------------------------------

        public static IList<Attachment> GetConsulta()
        {
            return new List<Attachment>()
            {
                GetCardConsulta(
                    "¿Tienes una consulta?",
                    "Consulta"),
            };
        }

        public static IList<Attachment> GetConsultaV2()
        {
            return new List<Attachment>()
            {
                GetCardConsulta(
                    "Para más ayuda seleccione 'consulta'",
                    "Consulta"),
            };
        }

        public static IList<Attachment> GetConfirmacion()
        {
            return new List<Attachment>()
            {
                GetCardDoubleAction(
                    "Si",
                    "si",
                    "No",
                    "no"),
            };
        }

        // -------------------------------------------------------------

        // Titulo, Subtitulo, Texto y Imagen
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

        // Titulo, Subtitulo, Texto y Accion
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

        // Titulo y Accion (No recomendado de usar *demasiado simple*) 
        private static Attachment GetHeroCardV3(string title, CardAction cardAction)
        {
            var heroCard = new HeroCard
            {
                Title = title,
                Buttons = new List<CardAction>() { cardAction },
            };
            return heroCard.ToAttachment();
        }

        // Imagen y Accion
        private static Attachment GetHeroCardV4(CardImage cardImage, CardAction cardAction)
        {
            var heroCard = new HeroCard
            {
                Images = new List<CardImage>() { cardImage },
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

        private static Attachment GetCardConsulta(string text, String value)
        {
            var Saludocard = new ThumbnailCard
            {
                Text = text,
                Buttons = new List<CardAction>
                {
                    new CardAction(ActionTypes.PostBack, "Consulta", value: value),
                }
            };
            return Saludocard.ToAttachment();
        }

        private static Attachment GetCardDoubleAction(string firstAction,string action1 , string secondAction, string action2)
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