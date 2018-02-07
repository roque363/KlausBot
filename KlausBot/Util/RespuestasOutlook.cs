using System;
using System.Web;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;
using Microsoft.Bot.Connector;

namespace KlausBot.Util
{
    public class RespuestasOutlook
    {
        // ----------------------------------------------------------------------- 
        // PREGUNTAS DE OUTLOOK                                                    
        // ----------------------------------------------------------------------- 
        // DEFINICION
        // ---------------------
        // Definicion de Outlook
        public static IList<Attachment> GetOutlookDefinicion()
        {
            return new List<Attachment>()
            {
                GetHeroCard(
                    "¿Qué es Outlook?",
                    "",
                    "El nuevo Outlook es más que solo correo electrónico. Le mostraremos cómo organizar automáticamente su bandeja de entrada y " +
                    "lo ayudará a enfocarse en los correos electrónicos que más le importan. También obtienes un poderoso calendario para " +
                    "administrar tu día.",
                    new CardImage(url: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQIFH5814W1-9WxdGlN1QJHCxV-yKKwIeXu2hSnnLylJxsfp-NU")),
                GetVideoCard(
                    "Office 365 - Outlook",
                    "Video sobre Outlook",
                    "https://videocontent.osi.office.net/cccda7b4-2f70-4420-9409-c231ee8312ea/e05255a3-3279-464e-a0a1-237440b26c48_1280x720_3400.mp4",
                    "https://support.office.com/es-es/article/Video-What-is-Outlook-10f1fa35-f33a-4cb7-838c-a7f3e6228b20?ui=es-ES&rs=es-ES&ad=ES"),
                GetHeroCardV4(
                     new CardImage(
                         url: HttpContext.Current.Server.MapPath("~/Images/aprendizajeDeOutlook.png")),
                    new CardAction(
                        ActionTypes.OpenUrl, "Ver más información",
                        value: "https://support.office.com/es-es/article/aprendizaje-de-outlook-8a5b816d-9052-4190-a5eb-494512343cca?wt.mc_id=otc_home&ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // ---------------------
        // CREAR
        // ---------------------
        // Crear y enviar correo electrónico
        public static IList<Attachment> GetCrearEnviarCorreoElectronico()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Crear y enviar correo electrónico",
                    "",
                    "",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Inicio-r%C3%A1pido-de-Outlook-2016-e9da47c4-9b89-4b49-b945-a204aeea6726?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Crear un mensaje de correo electrónico
        public static IList<Attachment> GetCrearMensajeCorreoElectronico()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Crear un mensaje de correo electrónico",
                    "Se aplica a: Outlook 2016 Outlook 2013 Office para empresas Office 365 Pequeña Empresa Outlook 2010",
                    "",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Crear-un-mensaje-de-correo-electr%C3%B3nico-147208af-ca8e-4cdf-b71f-77ba81a54069?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Crear y agregar una firma a los mensajes
        public static IList<Attachment> GetCrearFirmaMensaje()
        {
            return new List<Attachment>()
            {
              GetVideoCard(
                    "Crear y agregar una firma a los mensajes",
                    "En Outlook puede crear firmas personalizadas para sus mensajes de correo electrónico. Puede incluir texto, imágenes, su tarjeta " +
                    "de presentación electrónica, un logotipo o incluso una imagen con su firma manuscrita. Puede configurarlo para que las firmas " +
                    "se agreguen automáticamente a todos los mensajes salientes o puede elegir qué mensajes incluirán una firma.",
                    "https://videocontent.osi.office.net/f6ae6849-cbd6-4863-a3c5-546e90246c45/dcb8a228-ebbc-47fe-a315-d62959b5de1a_1280x720_3400.mp4",
                    "https://support.office.com/es-es/article/Crear-y-agregar-una-firma-a-los-mensajes-8ee5d4f4-68fd-464a-a1c1-0e1c80bb27f2#ID0EAABAAA=2016,_2013"),
            };
        }

        // Crear o programar una cita
        public static IList<Attachment> GetCrearProgramarCita()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Crear o programar una cita",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010 Outlook 2007",
                    "Las citas son actividades programadas en el calendario que no implican invitar a otras personas ni reservar recursos. " +
                    "Puede convertir una cita en una reunión mediante la adición de los asistentes.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Crear-o-programar-una-cita-be84396a-0903-4e25-b31c-1c99ce0dacf2?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Crear y asignar categorías de color
        public static IList<Attachment> GetCrearAsignarCategoriasColor()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Crear y asignar categorías de color",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010 Outlook 2007",
                    "Categorías de color permiten identificar y agrupar elementos asociados en Microsoft Outlook fácilmente. " +
                    "Asignar una categoría de color a un grupo de elementos interrelacionados, como notas, contactos, citas y " +
                    "mensajes de correo electrónico, para que puede realizar un seguimiento y organizarlos rápidamente. ",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Crear-y-asignar-categor%C3%ADas-de-color-a1fde97e-15e1-4179-a1a0-8a91ef89b8dc")),
            };
        }

        // Crear una plantilla de mensaje de correo electrónico
        public static IList<Attachment> GetCrearPlantillaMensajeCorreoElectronico()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Crear una plantilla de mensaje de correo electrónico",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010",
                    "Use plantillas de correo electrónico para enviar mensajes que incluyan información que normalmente no cambie de " +
                    "un mensaje a otro. Redacte y guarde un mensaje como plantilla y vuelva a utilizarlo cuando lo necesite. " +
                    "Se puede agregar información nueva antes de enviar la plantilla como mensaje de correo.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Crear-una-plantilla-de-mensaje-de-correo-electr%C3%B3nico-43ec7142-4dd0-4351-8727-bd0977b6b2d1")),
            };
        }

        // Crear una plantilla de correo electrónico
        public static IList<Attachment> GetCrearPlantillaCorreoElectronico()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Crear una plantilla de correo electrónico",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010",
                    "Use plantillas de correo electrónico para enviar mensajes que incluyan información que normalmente no cambie de " +
                    "un mensaje a otro. Redacte y guarde un mensaje como plantilla y vuelva a utilizarlo cuando lo necesite. Se puede " +
                    "agregar información nueva antes de enviar la plantilla como mensaje de correo.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/crear-una-plantilla-de-correo-electr%C3%B3nico-d14aff6f-b5be-4144-8979-2dca68a96215")),
            };
        }

        // Crear un evento que dure todo el día
        public static IList<Attachment> GetCrearEventoQueDureTodoDia()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Crear un evento que dure todo el día",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010",
                    "Un evento es una actividad que dura 24 horas o más. Una feria de muestras, un seminario o unas vacaciones son ejemplos de eventos.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Crear-un-evento-que-dure-todo-el-d%C3%ADa-52420de0-8f5a-41b2-a165-070588896c25?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Crear, cambiar o personalizar una vista
        public static IList<Attachment> GetCrearCambiarPersonalizarVista()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Crear, cambiar o personalizar una vista",
                    "",
                    "Cada carpeta Outlook, como la Bandeja de entrada y calendario, muestra sus elementos en un diseño de una vista. " +
                    "Cada carpeta tiene varias vistas predefinidas que puede elegir entre y puede crear vistas personalizadas.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Crear-cambiar-o-personalizar-una-vista-f693f3d9-0037-4fa0-9376-3a57b6337b71")),
            };
        }

        // Crear y usar carpetas personales
        public static IList<Attachment> GetCrearUsarCarpetasPersonales()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Crear y usar carpetas personales",
                    "",
                    "Si le gusta usar carpetas para administrar el correo electrónico, debería conocer las carpetas personales. Las carpetas " +
                    "personales funcionan igual que las carpetas habituales. Es lo que ocurre en segundo plano lo que las diferencia. Realice " +
                    "este breve curso para obtener más información y conocer aspectos sobre el archivado y la importación y exportación de correo " +
                    "electrónico a una cuenta diferente.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Crear-y-usar-carpetas-personales-archivos-de-datos-de-Outlook-cc784f7c-70c4-495d-bcbf-f3fcb679651f?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Usar o crear carpetas de búsqueda para buscar mensajes u otros elementos de Outlook
        public static IList<Attachment> GetUsarCrearCarpetasBusqueda()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Usar carpetas de búsqueda para buscar mensajes u otros elementos de Outlook",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010",
                    "Una carpeta de búsqueda es una carpeta virtual que proporciona una vista de todos los elementos de correo electrónico " +
                    "que coinciden con criterios de búsqueda específicos.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Usar-carpetas-de-b%C3%BAsqueda-para-buscar-mensajes-u-otros-elementos-de-Outlook-c1807038-01e4-475e-8869-0ccab0a56dc5?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Crear diseños de fondo para los mensajes de correo electrónico
        public static IList<Attachment> GetCrearDiseñosFondoParaMensajes()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Crear diseños de fondo para los mensajes de correo electrónico",
                    "Se aplica a: Outlook 2016 Outlook 2013",
                    "os diseños de fondo y los temas son un conjunto de elementos de diseño unificados y combinaciones de color. " +
                    "Especifican fuentes, viñetas, colores de fondo, líneas horizontales, imágenes y otros elementos de diseño que " +
                    "se incluirán en los mensajes de correo electrónico salientes.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Crear-dise%C3%B1os-de-fondo-para-los-mensajes-de-correo-electr%C3%B3nico-b5552ece-8f09-49ce-81a1-c1b7d347914f")),
            };
        }

        // Crear diseños de fondo para los mensajes de correo electrónico
        public static IList<Attachment> GetCrearDiseñosDePlantillaParaMensajesV2()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Crear diseños de fondo para los mensajes de correo electrónico",
                    "Se aplica a: Outlook 2016 Outlook 2013",
                    "os diseños de fondo y los temas son un conjunto de elementos de diseño unificados y combinaciones de color. " +
                    "Especifican fuentes, viñetas, colores de fondo, líneas horizontales, imágenes y otros elementos de diseño que " +
                    "se incluirán en los mensajes de correo electrónico salientes.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Crear-dise%C3%B1os-de-fondo-para-los-mensajes-de-correo-electr%C3%B3nico-b5552ece-8f09-49ce-81a1-c1b7d347914f")),
               GetVideoCard(
                    " Diseña tu propia plantilla para los emails",
                    "Puede diseñar, crear y usar diseños de fondo personales en un mensaje de correo electrónico de Outlook.",
                    "https://videocontent.osi.office.net/f9a2eaa7-3903-4c08-ab17-e657ea6d5313/b49b96b9-9bfd-4db0-be61-f33bc9159f2b_1280x720_3400.mp4",
                    "https://support.office.com/es-es/article/dise%C3%B1ar-dise%C3%B1os-de-fondo-personales-b059b1be-5875-40ca-8399-ad0fb7dd21cd"),

            };
        }

        // Crear un grupo de contactos o una lista de distribución en Outlook
        public static IList<Attachment> GetCrearGrupoContactosListaDistribucionOutlook()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Crear un grupo de contactos o una lista de distribución en Outlook",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010 Outlook 2007",
                    "Use un grupo de contactos (anteriormente denominado “lista de distribución”) para enviar un mensaje de correo electrónico " +
                    "a varias personas (un equipo del proyecto, un comité o incluso solo un grupo de amigos) sin tener que agregar cada nombre " +
                    "cada vez que desea escribirles.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Crear-un-grupo-de-contactos-o-una-lista-de-distribuci%C3%B3n-en-Outlook-88ff6c60-0a1d-4b54-8c9d-9e1a71bc3023?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Crear tareas y elementos de tarea
        public static IList<Attachment> GetCrearTareasEelementosTarea()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Crear tareas y elementos de tarea",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010 Outlook 2007",
                    "Muchas personas llevan una lista de tareas pendientes, en papel, en una hoja de cálculo, o mediante una combinación " +
                    "de papel y medios electrónicos. En Outlook, puede combinar sus diversas listas en una, mejorada con avisos y seguimientos.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Crear-tareas-y-elementos-de-tarea-45a94e7b-a4ee-46ea-9823-c3423c0eab8e?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Crear una tarea a partir de un mensaje
        public static IList<Attachment> GetCrearTareaAPartirMensaje()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Crear una tarea a partir de un mensaje",
                    "Se aplica a: Outlook 2016 Outlook 2013",
                    "Si desea crear una tarea basada en el contenido de un mensaje de correo electrónico, no tiene que volver a especificar " +
                    "toda la información. En su lugar, haga clic en el mensaje y arrástrelo a tareas en el barra de navegación.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Crear-una-tarea-a-partir-de-un-mensaje-40deff88-941a-4fc0-aba1-7d929d947795")),
            };
        }

        // Crear una tarea a partir de un mensaje && Crear tareas y elementos de tarea
        public static IList<Attachment> GetCrearTareaYAPartirDeMensaje()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Crear tareas y elementos de tarea",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010 Outlook 2007",
                    "Muchas personas llevan una lista de tareas pendientes, en papel, en una hoja de cálculo, o mediante una combinación " +
                    "de papel y medios electrónicos. En Outlook, puede combinar sus diversas listas en una, mejorada con avisos y seguimientos.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Crear-tareas-y-elementos-de-tarea-45a94e7b-a4ee-46ea-9823-c3423c0eab8e?ui=es-ES&rs=es-ES&ad=ES")),
                GetHeroCardV2(
                    "Crear una tarea a partir de un mensaje",
                    "Se aplica a: Outlook 2016 Outlook 2013",
                    "Si desea crear una tarea basada en el contenido de un mensaje de correo electrónico, no tiene que volver a especificar " +
                    "toda la información. En su lugar, haga clic en el mensaje y arrástrelo a tareas en el barra de navegación.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Crear-una-tarea-a-partir-de-un-mensaje-40deff88-941a-4fc0-aba1-7d929d947795")),
            };
        }

        // Crear un grupo de contactos desde una lista de contactos en Excel
        public static IList<Attachment> GetCrearGrupoContactosDesdeListaContactosExcel()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Crear un grupo de contactos desde una lista de contactos en Excel",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010 Outlook 2007",
                    "Use un grupo de contactos (anteriormente denominado “lista de distribución”) para enviar un mensaje de " +
                    "correo electrónico a varias personas (un equipo del proyecto, un comité o incluso solo un grupo de amigos) sin " +
                    "tener que agregar cada nombre cada vez que desea escribirles.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Crear-un-grupo-de-contactos-o-una-lista-de-distribuci%C3%B3n-en-Outlook-88ff6c60-0a1d-4b54-8c9d-9e1a71bc3023?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Crear o Agregar color
        public static IList<Attachment> GetAgregarColor()
        {
            return new List<Attachment>()
            {
                 GetHeroCardV2(
                    "Como cambiar el color del texto a medida que se redacta un mensaje de correo electrónico",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010 Outlook 2007",
                    "Cuando escribe un mensaje de correo electrónico, puede cambiar el color del texto de un carácter, una palabra o cualquier texto seleccionado.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Cambiar-el-color-del-texto-a-medida-que-se-redacta-un-mensaje-de-correo-electr%C3%B3nico-8be7e0d8-61cd-40eb-8db1-5cf94434bd66")),
                 GetHeroCardV2(
                    "Como cambiar el color del texto o la fuente predeterminada de los mensajes de correo",
                    "Outlook",
                    "En Outlook, la fuente se establece automáticamente para que crear, responder o reenviar un mensaje de correo electrónico es Calibri de 11 puntos.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Cambiar-el-color-del-texto-o-la-fuente-predeterminada-de-los-mensajes-de-correo-59b9860e-6dc0-48a1-9b07-6d8ea13ac5ca?ui=es-ES&rs=es-ES&ad=ES")),
                 GetHeroCardV2(
                    "Como cambiar el color de fondo del calendario",
                    "Se aplica a: Outlook 2016 Outlook 2013",
                    "El cambio del color de fondo es una forma rápida de hacer que su calendario sea diferente. Esto resulta especialmente útil si trabaja con múltiples calendarios.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Cambiar-el-color-de-fondo-del-calendario-3c544857-8446-46a5-ab9c-07b6af6e5091")),
                 GetHeroCardV2(
                    "Como cambiar automáticamente las fuentes y los colores de los mensajes entrantes según el remitente, el asunto o los destinatarios",
                    "Outlook",
                    "Formato condicional es una forma de hacer que los mensajes entrantes que cumplen las condiciones definidas destaquen en la lista de mensajes mediante el uso de colores, fuentes y estilos.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Cambiar-autom%C3%A1ticamente-las-fuentes-y-los-colores-de-los-mensajes-entrantes-seg%C3%BAn-el-remitente-el-asunto-o-los-destinatarios-ee281b41-5be4-47e4-81fb-1d8a202870df")),
                 GetHeroCardV2(
                    "Como cambiar el nombre de una categoría de color",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010 Outlook 2007",
                    "Las categorías de color son una excelente forma de agrupar visualmente mensajes, tareas, contactos o eventos de calendario que se parecen.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Cambiar-el-nombre-de-una-categor%C3%ADa-de-color-692ab131-525a-467b-8cbd-4b08346d5346")),
            };
        }

        // Crear sondeos en mensajes de correo y revisar los resultados
        public static IList<Attachment> GetCrearSondeosMensajesRevisarResultados()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Crear sondeos en mensajes de correo y revisar los resultados",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010 Outlook 2007",
                    "Es fácil crear un sondeo en Microsoft Outlook, incluyendo los botones de voto en un mensaje de correo electrónico. " +
                    "Cuando los destinatarios responden a un sondeo, puede automáticamente incluir los resultados de la votación en Outlook " +
                    "o exportar las respuestas a una hoja de cálculo Excel.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Crear-sondeos-en-mensajes-de-correo-y-revisar-los-resultados-4d10e079-8ea1-489a-a79c-18cb71ae12dd?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // ---------------------
        // RECUPERAR
        // ---------------------
        // Recuperar elementos eliminados en Outlook para Windows
        public static IList<Attachment> GetRecuperarElementosEliminados()
        {
            return new List<Attachment>()
            {
              GetVideoCard(
                    "Recuperar elementos eliminados en Outlook para Windows",
                    "Si elimina por error un elemento de su buzón de Outlook, la mayoría de las veces podrá recuperarlo. El primer lugar para buscar " +
                    "es la carpeta Elementos eliminados. Si no lo encuentra aquí, el siguiente sitio donde debe buscar es la carpeta Elementos " +
                    "recuperables, a la que puede obtener acceso mediante la herramienta Recuperar elementos eliminados.",
                    "https://videocontent.osi.office.net/02f522dc-fe56-4372-9d3c-509d21e75607/383313bc-c172-464b-b9f0-5353d7b7706e__H264_3400kbps_AAC_und_ch2_96kbps.mp4",
                    "https://support.office.com/es-es/article/Recuperar-elementos-eliminados-en-Outlook-para-Windows-49e81f3c-c8f4-4426-a0b9-c0fd751d48ce?ui=es-ES&rs=es-ES&ad=ES"),
            };
        }

        // Recuperar o reemplazar un mensaje después de enviarlo
        public static IList<Attachment> GetRecuperarMensajeDespuésEnviarlo()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Recuperar o reemplazar un mensaje después de enviarlo",
                    "",
                    "Con la recuperación de mensajes, un mensaje enviado se recupera de los buzones de los destinatarios que aún no lo hayan abierto. " +
                    "También puede reemplazarlo con un mensaje de sustitución. Por ejemplo, si olvidó incluir un dato adjunto, puede intentar " +
                    "recuperar el mensaje y luego enviar un mensaje de reemplazo con el dato adjunto.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Recuperar-o-reemplazar-un-mensaje-despu%C3%A9s-de-enviarlo-35027f88-d655-4554-b4f8-6c0729a723a0?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // ---------------------
        // AGREGAR Y INCLUIR Y INSERTAR
        // ---------------------
        // Agregar algun contacto en outlook
        public static IList<Attachment> GetAgregarContacto()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Como agregar un contacto en Outlook",
                    "Se aplica a: Outlook 2016 Outlook 2013",
                    "Vamos a ver cómo podemos agregar un nuevo contacto en Outlook. En Outlook, agregar un nuevo contacto no es necesario para poder enviarle un correo ya que podemos enviar un correo a cualquier dirección. Aún así tener un contacto agregado nos permitirá poder hablar con él a través del chat de Outlook, próximamente en Skype y organizar nuestros contactos conocidos. Por todo esto veremos hoy cómo podemos agregar un nuevo contacto en Outlook.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/agregar-un-contacto-e1dc4548-3bd6-4644-aecd-47b5728f7b0d")),
                GetVideoCardV2(
                    "Office 365 - Outlook",
                    "Ayuda sobre como agregar un contacto",
                    "https://www.youtube.com/watch?v=LQ1yev-dpXY"
                    )
            };
        }

        // Agregar persona a una lista de contactos
        public static IList<Attachment> GetAgregarContactoListaContactos()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Como agregar alguna persona a un grupo de contactos",
                    "Se aplica a: Outlook 2016 Outlook 2013",
                    "Use un grupo de contactos (anteriormente denominado “lista de distribución”) para enviar un mensaje de correo electrónico a varias personas (un equipo de proyecto, un comité o incluso solo un grupo de amigos) sin tener que agregar cada nombre cada vez que desea escribirles.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/agregar-personas-a-un-grupo-de-contactos-0c6c3bee-0529-4d87-822f-026620072e28")),
            };
        }

        // Como agregar contactos a categorías de color
        public static IList<Attachment> GetAgregarPersonasCategoriasColor()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Como agregar contactos a categorías de color",
                    "Se aplica a: Outlook 2016 Outlook 2013",
                    "¿Su lista de contactos empieza a ser abrumadora? La forma más rápida de organizar los contactos es mediante colores (por ejemplo, azul para los compañeros, rojo para familiares y amigos o verde para las organizaciones y miembros de la comunidad).",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/agregar-contactos-a-categor%C3%ADas-de-color-4d4e6521-aee8-4929-bea3-4a12e830fbfb")),

            };
        }

        // Como agregar gráficos a mensajes en Outlook
        public static IList<Attachment> GetAgregarGraficosMensajesOutlook()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Como agregar gráficos a mensajes en Outlook",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010",
                    "Si una línea tras de otra de texto sin formato aburre a sus destinatarios, convierta su mensaje en una obra maestra visual con cinco tipos distintos de gráficos.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/agregar-gr%C3%A1ficos-a-mensajes-en-outlook-114bb251-861f-41cd-b20f-7e7289630c5b")),

            };
        }

        // Como agregar tablas a mensajes en Outlook
        public static IList<Attachment> GetAgregarTablasMensajeOutlook()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Como agregar tablas a mensajes en Outlook",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010",
                    "Si ha intentado alguna vez alinear filas y columnas de texto manualmente con espacios, sabrá lo frustrante que puede ser.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Agregar-una-tabla-a-un-mensaje-59766ab4-0fe5-4520-ba0b-e34f8b8cd025")),
            };
        }

        // Como agregar una confirmacion de lectura o una notificación de entreega
        public static IList<Attachment> GetAgregarConfirmacionLecturaNotificacionEntrega()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Como agregar una confirmacion de lectura o una notificación de entreega",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010 Outlook 2007",
                    "Una confirmación de entrega confirma la entrega del mensaje de correo electrónico al buzón del destinatario, pero no si el destinatario lo ha visto o leído.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Agregar-y-solicitar-confirmaciones-de-lectura-y-notificaciones-de-entrega-a34bf70a-4c2c-4461-b2a1-12e4a7a92141")),

            };
        }

        // Agregar la confirmación de entrega para realizar un seguimiento de un mensaje de correo electrónico
        public static IList<Attachment> GetAgregarConfirmacionEntregaRealizarSeguimiento()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Agregar la confirmación de entrega para realizar un seguimiento de un mensaje de correo electrónico",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010 Outlook 2007",
                    "Una confirmación de entrega indica que un mensaje de correo se ha enviado al buzón del destinatario, pero no si el destinatario lo ha visto o leído.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/agregar-la-confirmaci%C3%B3n-de-entrega-para-realizar-un-seguimiento-de-un-mensaje-de-correo-electr%C3%B3nico-69cd1b39-2300-482d-96c6-22e2f4a96848")),

            };
        }

        // Agregar una confirmacion de lectura o una notificación de entrega
        // Agregar la confirmación de entrega para realizar un seguimiento de un mensaje de correo electrónico
        public static IList<Attachment> GetAgregarConfirmacionLecturaNotificacionEntregaYLectura()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Como agregar una confirmacion de lectura o una notificación de entreega",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010 Outlook 2007",
                    "Una confirmación de entrega confirma la entrega del mensaje de correo electrónico al buzón del destinatario, pero no si el destinatario lo ha visto o leído.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Agregar-y-solicitar-confirmaciones-de-lectura-y-notificaciones-de-entrega-a34bf70a-4c2c-4461-b2a1-12e4a7a92141")),
                GetHeroCardV2(
                    "Agregar la confirmación de entrega para realizar un seguimiento de un mensaje de correo electrónico",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010 Outlook 2007",
                    "Una confirmación de entrega indica que un mensaje de correo se ha enviado al buzón del destinatario, pero no si el destinatario lo ha visto o leído.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/agregar-la-confirmaci%C3%B3n-de-entrega-para-realizar-un-seguimiento-de-un-mensaje-de-correo-electr%C3%B3nico-69cd1b39-2300-482d-96c6-22e2f4a96848")),

            };
        }

        // Como agregar la confirmación de entrega para realizar un seguimiento de un mensaje de correo electrónico
        public static IList<Attachment> GetAgregarSeguimientoMensajesOutlook()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Como agregar la confirmación de entrega para realizar un seguimiento de un mensaje de correo electrónico",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010 Outlook 2007",
                    "Una confirmación de entrega indica que un mensaje de correo se ha enviado al buzón del destinatario, pero no si el destinatario lo ha visto o leído. Una confirmación de lectura avisa cuando se abre un mensaje.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Agregar-la-confirmaci%C3%B3n-de-entrega-para-realizar-un-seguimiento-de-un-mensaje-de-correo-electr%C3%B3nico-69cd1b39-2300-482d-96c6-22e2f4a96848?ui=es-ES&rs=es-HN&ad=PE")),

            };
        }

        // Como agregar días no laborables a tu calendario en Outlook
        public static IList<Attachment> GetAgregarFeriadosCalendarioOutlook()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Agregar días festivos a su calendario de Outlook para Windows",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010",
                    "Al empezar a usar Outlook 2013 o Outlook 2016 para Windows, allí no se encuentran los días no laborables" +
                    " en el calendario. Aunque puede agregar días no laborables para uno o varios países.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/agregar-d%C3%ADas-festivos-a-su-calendario-de-outlook-para-windows-f16d872f-8dad-4750-bb7c-166e72c26977")),

            };
        }

        // Adjuntar o agregar archivos en outlook
        public static IList<Attachment> GetAdjuntarArchivosOutlook()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Adjuntar archivos o insertar imágenes en mensajes de correo de Outlook",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010 Outlook 2007",
                    "Es fácil adjuntar imágenes, archivos, contactos, mensajes de correo y muchos otros elementos a los mensajes de Outlook. Outlook"
                    +" realiza un seguimiento de los documentos con los que ha trabajado recientemente, independientemente de que estén almacenados en el equipo o se guarden en OneDrive (solo en la nube).",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Adjuntar-archivos-o-insertar-im%C3%A1genes-en-mensajes-de-correo-de-Outlook-bdfafef5-792a-42b1-9a7b-84512d7de7fc?ui=es-ES&rs=es-HN&ad=PE")),

            };
        }

        // Incluir una tarjeta de presentación electrónica en una firma de correo electrónico
        public static IList<Attachment> GetIncluirTarjetaPresentacionFirmaCorreo()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Incluir una tarjeta de presentación electrónica en una firma de correo electrónico",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010 Outlook 2007",
                    "Agregando su Tarjeta de presentación electrónica a su firma de correo electrónico,"
                    +" puede incluir la información de contacto en cada mensaje que envíe.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Incluir-una-tarjeta-de-presentaci%C3%B3n-electr%C3%B3nica-en-una-firma-de-correo-electr%C3%B3nico-fe50a63b-34e5-44c5-b68f-849afdc28ab0?ui=es-ES&rs=es-HN&ad=PE")),

            };
        }

        // Crear o modificar o insertar un hipervínculo
        public static IList<Attachment> GetCrearModificarHipervínculo()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Crear o modificar un hipervínculo",
                    "Se aplica a: Excel, Word, Outlook, PowerPoint, Office",
                    "La forma más rápida de crear un hipervínculo básico en un documento de Office es presionar ENTRAR o la barra espaciadora después de escribir la dirección de una página web existente, como http://www.contoso.com. Office convierte automáticamente la dirección en un vínculo.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/crear-o-modificar-un-hiperv%C3%ADnculo-5d8c0804-f998-4143-86b1-1199735e07bf")),

            };
        }

        // Insertar hipervínculos de Facebook o Twitter en la firma de correo electrónico
        public static IList<Attachment> GetInsertarHipervinculosFirmaCorreo()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Insertar hipervínculos de Facebook o Twitter en la firma de correo electrónico",
                    "SSe aplica a: Outlook 2016 Outlook 2013",
                    "Puede modificar su firma de correo electrónico o cree uno nuevo para incluir "
                    +"vínculos a perfiles de Facebook o Twitter. Para empezar, asegúrese de que guarde copias de los iconos de Facebook y Twitter en su equipo.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Insertar-hiperv%C3%ADnculos-a-Facebook-y-Twitter-en-la-firma-de-correo-electr%C3%B3nico-40833df1-9459-48f0-b90f-0f6e66536206")),

            };
        }

        // ---------------------
        // BLOQUEAR
        // ---------------------
        // Bloquear a un remitente de correo
        public static IList<Attachment> GetNombresListasBloqueados()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Bloquear a un remitente de correo",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010 Outlook 2007",
                    "Como parte de sus criterios de filtrado, el filtro de correo electrónico no deseado de Outlook comprueba los remitentes de mensajes con las listas de direcciones de correo electrónico y dominios de Internet designados como seguro o bloqueado.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Bloquear-a-un-remitente-de-correo-b29fd867-cac9-40d8-aed1-659e06a706e4?ui=es-ES&rs=es-HN&ad=PE")),

            };
        }

        // ---------------------
        // CAMBIAR
        // ---------------------
        // Cambiar el modo de ver el calendario de Outlook
        public static IList<Attachment> GetCambiarModoVerCalendario()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Cambiar el modo de ver el calendario de Outlook",
                    "Se aplica a: Outlook 2016 Outlook 2013",
                    "",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Cambiar-el-modo-en-que-ve-el-calendario-de-Outlook-a4e0dfd2-89a1-4770-9197-a3e786f4cd8f?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Cambiar el nombre para mostrar lo que ven los destinatarios de correo electrónico
        public static IList<Attachment> GetCambiarNombre()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Cambiar el nombre para mostrar lo que ven los destinatarios de correo electrónico",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010 Outlook 2007",
                    "Si los destinatarios de correo electrónico ven solo una parte de su nombre, pero quiere que vean el " +
                    "nombre completo, puede realizar fácilmente el cambio deseado. La presentación puede mostrar solo una " +
                    "parte del nombre si no escribió su nombre completo al configurar su cuenta de correo por primera vez.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/cambiar-el-nombre-para-mostrar-lo-que-ven-los-destinatarios-de-correo-electr%C3%B3nico-2b53331a-ba2a-4803-88dc-ac9fe376c8a9")),
            };
        }

        // Mover o cambiar el nombre de una carpeta en Outlook.com
        public static IList<Attachment> GetCambiarNombreCarpeta()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Mover o cambiar el nombre de una carpeta en Outlook.com",
                    "Se aplica a: Outlook.com",
                    "Puede arrastrar una carpeta en Outlook.com a un nuevo lugar en la jerarquía de carpetas, o bien " +
                    "puede usar la opción mover en el menú contextual. También puede cambiar el nombre de las carpetas que cree.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Mover-o-cambiar-el-nombre-de-una-carpeta-en-Outlook-com-c9c66fed-8a7c-426a-afc6-0d46a72080fb")),
            };
        }

        // Mover o cambiar el nombre de una carpeta en Outlook.com
        // Como cambiar el nombre de una categoría de color
        public static IList<Attachment> GetCambiarNombreCarpetaYCategoria()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Mover o cambiar el nombre de una carpeta en Outlook.com",
                    "Se aplica a: Outlook.com",
                    "Puede arrastrar una carpeta en Outlook.com a un nuevo lugar en la jerarquía de carpetas, o bien " +
                    "puede usar la opción mover en el menú contextual. También puede cambiar el nombre de las carpetas que cree.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Mover-o-cambiar-el-nombre-de-una-carpeta-en-Outlook-com-c9c66fed-8a7c-426a-afc6-0d46a72080fb")),
                 GetHeroCardV2(
                    "Como cambiar el nombre de una categoría de color",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010 Outlook 2007",
                    "Las categorías de color son una excelente forma de agrupar visualmente mensajes, tareas, contactos o eventos de calendario que se parecen.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Cambiar-el-nombre-de-una-categor%C3%ADa-de-color-692ab131-525a-467b-8cbd-4b08346d5346")),
            };
        }

        // Cambiar el sonido reproducido cuando se recibe un mensaje de correo
        public static IList<Attachment> GetCambiarSonidoReproducidoMensajeCorreo()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Cambiar el sonido reproducido cuando se recibe un mensaje de correo",
                    "Se aplica a: Outlook 2016 Outlook 2013",
                    "Cambiar el sonido de Windows mediante el Panel de Control. Si desea desactivar el sonido, use la vista Backstage en Outlook.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Cambiar-el-sonido-reproducido-cuando-se-recibe-un-mensaje-de-correo-cbf254a8-008c-4dce-a02f-b9c87fa8097a?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Como cambiar el nombre de una categoría de color
        public static IList<Attachment> GetCambiarNombreCategoriaColor()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Como cambiar el nombre de una categoría de color",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010 Outlook 2007",
                    "Las categorías de color son una excelente forma de agrupar visualmente mensajes, tareas, contactos o eventos de calendario que se parecen.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Cambiar-el-nombre-de-una-categor%C3%ADa-de-color-692ab131-525a-467b-8cbd-4b08346d5346")),
            };
        }

        // Como cambiar el color del texto a medida que se redacta un mensaje de correo electrónico
        public static IList<Attachment> GetCambiarColorTextoRedactaMensaje()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Como cambiar el color del texto a medida que se redacta un mensaje de correo electrónico",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010 Outlook 2007",
                    "Cuando escribe un mensaje de correo electrónico, puede cambiar el color del texto de un carácter, una palabra o cualquier texto seleccionado.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Cambiar-el-color-del-texto-a-medida-que-se-redacta-un-mensaje-de-correo-electr%C3%B3nico-8be7e0d8-61cd-40eb-8db1-5cf94434bd66")),
            };
        }

        // Como cambiar el color del texto o la fuente predeterminada de los mensajes de correo
        public static IList<Attachment> GetCambiarColorTextoFuentePredeterminadoMensajes()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Como cambiar el color del texto o la fuente predeterminada de los mensajes de correo",
                    "Outlook",
                    "En Outlook, la fuente se establece automáticamente para que crear, responder o reenviar un mensaje de correo electrónico es Calibri de 11 puntos.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Cambiar-el-color-del-texto-o-la-fuente-predeterminada-de-los-mensajes-de-correo-59b9860e-6dc0-48a1-9b07-6d8ea13ac5ca?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Como cambiar el color de fondo del calendario
        public static IList<Attachment> GetCambiarColorFondoCalendario()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Como cambiar el color de fondo del calendario",
                    "Se aplica a: Outlook 2016 Outlook 2013",
                    "El cambio del color de fondo es una forma rápida de hacer que su calendario sea diferente. Esto resulta especialmente útil si trabaja con múltiples calendarios.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Cambiar-el-color-de-fondo-del-calendario-3c544857-8446-46a5-ab9c-07b6af6e5091")),
            };
        }

        // Como cambiar automáticamente las fuentes y los colores de los mensajes entrantes según el remitente, el asunto o los destinatarios
        public static IList<Attachment> GetCambiarFuenteMensajesEntrantesRemitente()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Como cambiar automáticamente las fuentes y los colores de los mensajes entrantes según el remitente, el asunto o los destinatarios",
                    "Outlook",
                    "Formato condicional es una forma de hacer que los mensajes entrantes que cumplen las condiciones definidas destaquen en la lista de mensajes mediante el uso de colores, fuentes y estilos.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Cambiar-autom%C3%A1ticamente-las-fuentes-y-los-colores-de-los-mensajes-entrantes-seg%C3%BAn-el-remitente-el-asunto-o-los-destinatarios-ee281b41-5be4-47e4-81fb-1d8a202870df")),
            };
        }

        // Cambiar la fuente o el tamaño de fuente en la lista de mensajes
        public static IList<Attachment> GetCambiarTamanoFuenteListaMensajes()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Cambiar la fuente o el tamaño de fuente en la lista de mensajes",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010 Outlook 2007",
                    "Para buscar más rápidamente a través de la Bandeja de entrada, desea ampliar el texto de las líneas de asunto y el encabezado de columna, o cambiar la fuente para facilitar la lectura.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Cambiar-la-fuente-o-el-tama%C3%B1o-de-fuente-en-la-lista-de-mensajes-57bd24a6-1f85-45ac-a657-fba877d3fe00?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Como cambiar configuración del grupo de envío o recepción
        public static IList<Attachment> GetCambiarConfiguracionGruposEnvios()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Como cambiar configuración del grupo de envío o recepción",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010 Outlook 2007",
                    "Una vez que haya agregado cuentas a Outlook, puede cambiar la frecuencia con Outlook comprueba si hay nuevo correo electrónico de cada cuenta, así como la frecuencia con Outlook envía los mensajes salientes de cada cuenta.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Cambiar-configuraci%C3%B3n-del-grupo-de-env%C3%ADo-o-recepci%C3%B3n-7184f59d-c194-44d7-973a-7af568a918d0?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Como cambiar la ubicación donde se guardan los mensajes de correo electrónico enviado
        public static IList<Attachment> GetCambiarUbicacionGuardanMensajes()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Como cambiar la ubicación donde se guardan los mensajes de correo electrónico enviado",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010 Outlook 2007",
                    "En Outlook, puede especificar la carpeta donde se guardan los elementos de correo electrónico enviado.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Cambiar-la-ubicaci%C3%B3n-donde-se-guardan-los-mensajes-de-correo-electr%C3%B3nico-enviado-bd95ef3b-8c04-466a-8576-d1ce0eabeb2c?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Como cambiar una cita, una reunión o un evento
        public static IList<Attachment> GetCambiarCitaOutlook()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Como cambiar una cita, una reunión o un evento",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010",
                    "Puede cambiar una cita, una reunión o un evento para actualizar el calendario de Outlook y para que otras personas puedan informarse de los cambios de programación.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Cambiar-una-cita-una-reuni%C3%B3n-o-un-evento-29b44f7a-8938-4b99-b98d-3efcf45f7613")),
            };
        }

        // Como cambiar el nivel de protección en el filtro de correo no deseado
        public static IList<Attachment> GetCambiarNivelProteccionFiltroCorreo()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Como cambiar el nivel de protección en el filtro de correo no deseado",
                    "Se aplica a: Outlook 2016 Outlook 2013",
                    "Correo electrónico no deseado, también conocido como correo no deseado, puede resultar bastante molesto en su Bandeja de entrada. El filtro de correo electrónico no deseado en Outlook identifica mensajes que probablemente correo no deseado y los mueven a la carpeta Correo no deseado.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Cambiar-el-nivel-de-protecci%C3%B3n-en-el-filtro-de-correo-no-deseado-ef21aec7-6eb5-4457-8b94-93f13fc275cb?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Prácticas recomendadas para las organizaciones cuando se usa el calendario de Outlook
        public static IList<Attachment> GetUsarCalendarioManeraAdecuadaOutlook()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Prácticas recomendadas para las organizaciones cuando se usa el calendario de Outlook",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010 Outlook 2007",
                    "El calendario de Outlook está completamente integrado con el correo electrónico, los contactos y otras características, lo que lo convierte en una de las funciones más apreciadas de Outlook.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Pr%C3%A1cticas-recomendadas-para-las-organizaciones-cuando-se-usa-el-calendario-de-Outlook-d93f72d3-2361-4e0d-8d6a-5c4939c17f39?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Configuración de Correo
        public static IList<Attachment> GetCambiarConfiguracionCorreo()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Configuración de Correo",
                    "Se aplica a: Outlook Web App",
                    "Personalizar la configuración para los mensajes que envía y recibe con Outlook Web App. Puede hacer cosas como configurar una firma se agregue a los mensajes que envíe o controlar el seguimiento de mensajes.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/cambiar-la-foto-y-la-informaci%C3%B3n-de-cuenta-en-outlook-en-la-web-b2dbb289-851d-4bed-93c3-3e136f5659ec")),

            };
        }

        // ---------------------
        // USAR
        // ---------------------
        // Usar los filtros de correo electrónico no deseado para controlar los mensajes que se pueden ver
        public static IList<Attachment> GetUsarFiltrosCorreoNoDeseadoControlarMensajes()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Usar los filtros de correo electrónico no deseado para controlar los mensajes que se pueden ver",
                    "Se aplica a: Outlook 2016 Outlook 2013",
                    "El Filtro de correo electrónico no deseado de Outlook comprueba el remitente de todos los mensajes entrantes con las listas de direcciones de correo electrónico y los dominios de Internet: la parte de la dirección de correo electrónico después del símbolo @: designado como seguro o bloqueado.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Usar-los-filtros-de-correo-electr%C3%B3nico-no-deseado-para-controlar-los-mensajes-que-ve-274ae301-5db2-4aad-be21-25413cede077?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Usar la limpieza de conversación para eliminar mensajes redundantes
        public static IList<Attachment> GetUsarLimpiezaConversacion()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Usar la limpieza de conversación para eliminar mensajes redundantes",
                    "Se aplica a: Outlook 2016 Outlook 2013 Office para empresas Office 365 Pequeña Empresa",
                    "La característica Limpieza de conversación de Outlook reduce el número de mensajes contenidos en las carpetas de correo. Los mensajes redundantes de una conversación se mueven a la carpeta Elementos eliminados.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Usar-Limpieza-de-conversaci%C3%B3n-para-eliminar-mensajes-redundantes-70179d54-fa57-48ce-95fd-416d72e5ccd4?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Usar otros correos para organizar mensajes de baja prioridad en Outlook
        public static IList<Attachment> GetUsarCorreosOrganizarBajaPrioridad()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Usar otros correos para organizar mensajes de baja prioridad en Outlook",
                    "Se aplica a: Outlook 2016 Outlook 2013",
                    "En Outlook 2016 para Windows, 'Otros correos'puede ayudarle a filtrar correo electrónico de baja prioridad para que pueda dedicarle más tiempo a los mensajes más importantes.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Usar-Otros-correos-para-organizar-mensajes-de-baja-prioridad-en-Outlook-7b50c5db-7704-4e55-8a1b-dfc7bf1eafa0")),
            };
        }

        // Usar las @menciones para llamar la atención de un usuario
        public static IList<Attachment> GetUsarArrobaLlamarAtencion()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Usar las @menciones para llamar la atención de un usuario",
                    "Se aplica a: Outlook 2016 Outlook 2016 para Mac Outlook en la web para Office 365 Empresa Outlook.com Outlook en la web para Exchange Server 2016",
                    "Si desea llamar la atención de alguien en un mensaje de correo electrónico o una invitación a la reunión, puede escribir el símbolo @, seguido por su nombre en el cuerpo del mensaje de correo electrónico o una reunión invitar.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/usar-las-menciones-para-llamar-la-atenci%C3%B3n-de-un-usuario-90701709-5dc1-41c7-aa48-b01d4a46e8c7")),
            };
        }

        // Usar el asistente para programación
        public static IList<Attachment> GetUsarAsistenteProgramacion()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Usar el asistente para programación",
                    "Outlook",
                    "En este vídeo aprenderá a usar el Asistente para programación para que le resulte más fácil administrar reuniones complejas con un gran número de asistentes.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/usar-el-asistente-para-programaci%C3%B3n-a7bf1aee-bee6-46d6-a126-194ed04fbe09#ID0EAABAAA=Informaci%C3%B3n_general")),
                GetVideoCard(
                    "Office 365 - Outlook",
                    "Usar el asistente para programación",
                    "https://videocontent.osi.office.net/8b47f9db-6dc9-4bee-9719-bd52745f8b58/318c1ac2-885d-44ab-a6f5-0ab6dcd75055_1280x720_3400.mp4",
                    ""),
            };
        }

        // ---------------------
        // BUSCAR
        // ---------------------
        // Buscar personas o contactos en outlook
        public static IList<Attachment> GetBuscarPersonasOutlook()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Buscar personas y contactos",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010 Outlook 2007",
                    "Bien tenga unos pocos contactos, varios cientos o más que mil, hay ocasiones en que desea buscar un contacto en lugar de desplazarse por una larga lista de contactos.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Buscar-personas-y-contactos-f868749b-31a4-4fba-a936-b778cbb8f1cb")),

            };
        }

        // Buscar mensajes en outlook
        public static IList<Attachment> GetBuscarMensajesOutlook()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Buscar y filtrar mensajes",
                    "Outlook",
                    "La búsqueda es una potente herramienta para ayudarle a encontrar los mensajes de correo electrónico en cualquier lugar en Outlook.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Buscar-y-filtrar-mensajes-3e32b06d-a2d9-4a66-922f-78b77c41b97f#ID0EAABAAA=P%C3%B3ngalo_en_pr%C3%A1ctica")),
                GetVideoCard(
                    "Office 365 - Outlook",
                    "Buscar y filtrar mensajes",
                    "https://videocontent.osi.office.net/1823715a-6c4f-4bb7-a7e3-973ad1fc1891/1bb06f49-bb0c-4489-8804-0d53123cb8dc_1280x720_3400.mp4",
                    "https://support.office.com/es-es/article/Buscar-y-filtrar-mensajes-3e32b06d-a2d9-4a66-922f-78b77c41b97f#ID0EAABAAA=P%C3%B3ngalo_en_pr%C3%A1ctica"),
            };
        }

        // Buscar un mensaje o elemento con Búsqueda instantánea
        public static IList<Attachment> GetBuscarMensajeBusquedaInstantanea()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Buscar un mensaje o elemento con Búsqueda instantánea",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010 Outlook 2007 Office 2007",
                    "¿Necesita encontrar un mensaje importante en su bandeja de entrada o carpeta abarrotada? La búsqueda instantánea le ayuda a encontrar rápidamente elementos en Outlook.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Buscar-un-mensaje-o-elemento-con-B%C3%BAsqueda-instant%C3%A1nea-69748862-5976-47b9-98e8-ed179f1b9e4d")),

            };
        }

        // Buscar elementos en un archivo de datos de Outlook (.pst)
        public static IList<Attachment> GetBuscarElementosArchivosDatos()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Abrir y buscar elementos en un archivo de datos de Outlook (.pst)",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010 Outlook 2007",
                    "Si usa una cuenta POP o IMAP, toda la información de Outlook se almacenan en un archivo de datos de Outlook, también conocido como un Archivo de carpetas personales (.pst).",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Abrir-y-buscar-elementos-en-un-Archivo-de-datos-de-Outlook-pst-2e2b55a4-f681-4b93-90cb-31d39349fb95")),

            };
        }

        //Buscar y transferir archivos de datos de Outlook de un equipo a otro
        public static IList<Attachment> GetBuscarArchivosDatosOutlook()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Buscar y transferir archivos de datos de Outlook de un equipo a otro",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010 Outlook 2007",
                    "Outlook guarda información de copia de seguridad en varias ubicaciones diferentes. Dependiendo "+
                    "del tipo de cuenta que tenga, puede hacer una copia de los correos electrónicos, la libreta "+
                    "personal de direcciones, la configuración del panel de navegación, las firmas, las plantillas y más.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Buscar-y-transferir-archivos-de-datos-de-Outlook-de-un-equipo-a-otro-0996ece3-57c6-49bc-977b-0d1892e2aacc?ui=es-ES&rs=es-ES&ad=ES")),

            };
        }

        // ---------------------
        // EDITAR
        // ---------------------
        //Editar un contacto
        public static IList<Attachment> GetEditarContactosOutlook()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Editar un contacto",
                    "Se aplica a: Outlook 2016 Outlook 2013",
                    "Puede agregar información acerca de los contactos, como sus cumpleaños y aniversarios, o los nombres de sus esposos e hijos.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Editar-un-contacto-2925f5d8-6092-4c74-9331-e6915df59fc2")),

            };
        }

        // ---------------------
        // VER
        // ---------------------
        // Ver simultáneamente varios calendarios
        public static IList<Attachment> GetVerCalendarioSimultaneamente()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Ver simultáneamente varios calendarios",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010 Outlook 2007",
                    "Puede ver varios calendarios simultáneamente en paralelo o combinados en una vista superpuesta apilada que le permitirá ver la disponibilidad en varios calendarios.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Ver-simult%C3%A1neamente-varios-calendarios-fffa8783-0556-4ea1-ba62-3ed8a95a903c")),
            };
        }

        // Ver tareas en Outlook
        public static IList<Attachment> GetVerTareasOutlook()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Ver las tareas",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010 Outlook 2007",
                    "Las tareas se muestran en tres lugares de Outlook: en la Barra Tareas pendientes, en tareas y en la lista de tareas diarias en el calendario.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Ver-las-tareas-2146bc92-2d5c-407f-a619-2b2e372b2ca2?ui=es-ES&rs=es-HN&ad=PE")),
            };
        }

        // Ver solo los mensajes no leídos 
        public static IList<Attachment> GetVerSoloMensajesNoLeidos()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Ver solo los mensajes no leídos",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010 Outlook 2007",
                    "La Bandeja de entrada o cualquier carpeta de correo se pueden filtrar para mostrar solo los mensajes no leídos. " +
                    "De forma predeterminada, los mensajes no leídos aparecen en negrita en el lista de mensajes.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Ver-solo-los-mensajes-no-le%C3%ADdos-f2c8450c-9cd0-4037-a5d3-26f6946727ca")),
            };
        }

        // Ver mensajes de correo electrónico por conversación
        public static IList<Attachment> GetVerMensajesCorreoElectronicoConversacion()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Ver mensajes de correo electrónico por conversación",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010 Outlook 2007",
                    "Cuando se cambia a la vista de organización por conversaciones, los mensajes que tienen el mismo asunto aparecen" +
                    " como un grupo o una colección de mensajes.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Ver-mensajes-de-correo-electr%C3%B3nico-por-conversaci%C3%B3n-0eeec76c-f59b-4834-98e6-05cfdfa9fb07?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Ver solo los mensajes no leídos Y Correos electrónicos por conversación
        public static IList<Attachment> GetVerSoloMensajesNoLeidosYConversacion()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Ver solo los mensajes no leídos",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010 Outlook 2007",
                    "La Bandeja de entrada o cualquier carpeta de correo se pueden filtrar para mostrar solo los mensajes no leídos. " +
                    "De forma predeterminada, los mensajes no leídos aparecen en negrita en el lista de mensajes.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Ver-solo-los-mensajes-no-le%C3%ADdos-f2c8450c-9cd0-4037-a5d3-26f6946727ca")),
                GetHeroCardV2(
                    "Ver mensajes de correo electrónico por conversación",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010 Outlook 2007",
                    "Cuando se cambia a la vista de organización por conversaciones, los mensajes que tienen el mismo asunto aparecen" +
                    " como un grupo o una colección de mensajes.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Ver-mensajes-de-correo-electr%C3%B3nico-por-conversaci%C3%B3n-0eeec76c-f59b-4834-98e6-05cfdfa9fb07?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Ver encabezados de mensajes de correo electrónico
        public static IList<Attachment> GetVerEncabezadosMensajesCorreoElectronico()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Ver encabezados de mensajes de correo electrónico",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010 Outlook 2007",
                    "Encabezados de mensajes de correo electrónico proporcionan una lista de detalles técnicos sobre el mensaje, " +
                    "como el remitente, el software utilizado para redactarlo y los servidores de correo electrónico que ha pasado hasta " +
                    "llegar al destinatario.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Ver-encabezados-de-mensajes-de-correo-electr%C3%B3nico-cd039382-dc6e-4264-ac74-c048563d212c")),
            };
        }

        // Mostrar, ocultar y ver el campo de copia carbón oculta (CCO)
        public static IList<Attachment> GetMostrarOcultarVerCampoCopiaCarbonOculta()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Mostrar, ocultar y ver el campo de copia carbón oculta (CCO)",
                    "Se aplica a: Outlook 2016 Outlook 2013",
                    "Si agrega el nombre de un destinatario al cuadro CCO (copia carbón oculta) en un mensaje de correo electrónico, " +
                    "se enviará una copia del mensaje al destinatario que especifique. Los destinatarios que se agreguen al cuadro CCO no se " +
                    "mostrarán al resto de los destinatarios que reciban el mensaje.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Mostrar-ocultar-y-ver-el-campo-de-copia-carb%C3%B3n-oculta-CCO-04304e27-63a2-4276-8884-5077fba0e229?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // ---------------------
        // REENVIAR Y ENVIAR Y RESPONDER
        // ---------------------
        // Enviar un mensaje de correo electrónico a un grupo de contactos
        public static IList<Attachment> GetAplicarFondosTemasMensajes()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Aplicar diseños de fondo, fondos o temas a mensajes de correo electrónico",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010 Outlook 2007",
                    "Diseño de fondo en Microsoft Outlook incluye fondos y las tramas y ofrece "+
                    "un conjunto de elementos de diseño unificado como fuentes, viñetas, colores y efectos.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Aplicar-dise%C3%B1os-de-fondo-fondos-o-temas-a-mensajes-de-correo-electr%C3%B3nico-e24fc237-62e1-4361-82a3-d8a7467d2b7e?ui=es-ES&rs=es-ES&ad=ES")),

            };
        }

        // Enviar un mensaje de correo basado en una plantilla
        public static IList<Attachment> GetEnviarMensajeBasadoPlantilla()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Enviar un mensaje de correo basado en una plantilla",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010 Outlook 2007",
                    "Utilice plantillas de correo electrónico para enviar mensajes que incluyan información que no cambie con frecuencia de un mensaje a otro. ",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Enviar-un-mensaje-de-correo-basado-en-una-plantilla-56c645fc-1b25-4059-808b-55ee72b6bc2d")),
            };
        }

        // Enviar un mensaje de correo electrónico a un grupo de contactos
        public static IList<Attachment> GetEnviarMensajeGrupoContactos()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Enviar un mensaje de correo electrónico a un grupo de contactos",
                    "Se aplica a: Outlook 2016 Outlook 2013",
                    "Use un grupo de contactos (denominado anteriormente “lista de distribución”) para enviar un mensaje de correo electrónico a varias personas "+
                    "(un equipo del proyecto, un comité o incluso un grupo de amigos) sin tener que agregar cada nombre cada vez que les escribe. ",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Enviar-un-mensaje-de-correo-electr%C3%B3nico-a-un-grupo-de-contactos-1c97fcb2-0ed4-41e6-b401-58f9d7d40e39")),

            };
        }

        // Enviar respuestas automáticas "Fuera de la oficina" de Outlook
        public static IList<Attachment> GetEnviarRespuestasAutomaticasFueraOficinaOutlook()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Enviar respuestas automáticas 'Fuera de la oficina' de Outlook",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010 Outlook 2007",
                    "Hay dos formas de enviar respuestas de fuera de la oficina automáticas. El uso de cada una de ellas dependerá del tipo de cuenta de correo electrónico que tenga.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Enviar-respuestas-autom%C3%A1ticas-Fuera-de-la-oficina-de-Outlook-9742f476-5348-4f9f-997f-5e208513bd67?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Enviar respuestas Intencion2
        public static IList<Attachment> GetEnviarRespuestasIntencio2()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Enviar respuestas automáticas 'Fuera de la oficina' de Outlook",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010 Outlook 2007",
                    "Hay dos formas de enviar respuestas de fuera de la oficina automáticas. El uso de cada una de ellas dependerá del tipo de cuenta de correo electrónico que tenga.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Enviar-respuestas-autom%C3%A1ticas-Fuera-de-la-oficina-de-Outlook-9742f476-5348-4f9f-997f-5e208513bd67?ui=es-ES&rs=es-ES&ad=ES")),
                GetHeroCardV2(
                    "Reenviar una reunión",
                    "Se aplica a: Outlook 2016 Outlook 2013",
                    "Existen dos maneras de reenviar una reunión, dependiendo de si la reunión está en su calendario o en su correo electrónico.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Reenviar-una-reuni%C3%B3n-94f2df68-8109-4334-8bfa-f5c013dc1578")),
                GetHeroCardV2(
                    "Enviar un mensaje de correo electrónico a un grupo de contactos",
                    "Se aplica a: Outlook 2016 Outlook 2013",
                    "Use un grupo de contactos (denominado anteriormente “lista de distribución”) para enviar un mensaje de correo electrónico a varias personas "+
                    "(un equipo del proyecto, un comité o incluso un grupo de amigos) sin tener que agregar cada nombre cada vez que les escribe. ",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Enviar-un-mensaje-de-correo-electr%C3%B3nico-a-un-grupo-de-contactos-1c97fcb2-0ed4-41e6-b401-58f9d7d40e39")),
                GetHeroCardV2(
                    "Enviar un mensaje de correo basado en una plantilla",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010 Outlook 2007",
                    "Utilice plantillas de correo electrónico para enviar mensajes que incluyan información que no cambie con frecuencia de un mensaje a otro. ",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Enviar-un-mensaje-de-correo-basado-en-una-plantilla-56c645fc-1b25-4059-808b-55ee72b6bc2d")),
            };
        }

        // Enviar un mensaje de correo electrónico a un grupo de contactos
        public static IList<Attachment> GetEliminarCategoriaColor()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Eliminar una categoría de color",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010 Outlook 2007",
                    "Puede eliminar una categoría de color de la lista de categorías si"+
                    " ya no la desea o puede quitar una categoría de color de los elementos que categorizó previamente.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Eliminar-una-categor%C3%ADa-de-color-417b871e-67f0-41b7-b3db-c4ffed19810e")),

            };
        }

        // Reenviar una reunión
        public static IList<Attachment> GetReenviarReuniónOutlook()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Reenviar una reunión",
                    "Se aplica a: Outlook 2016 Outlook 2013",
                    "Existen dos maneras de reenviar una reunión, dependiendo de si la reunión está en su calendario o en su correo electrónico.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Reenviar-una-reuni%C3%B3n-94f2df68-8109-4334-8bfa-f5c013dc1578")),
            };
        }

        // Responder o reenviar un mensaje de correo electrónico
        public static IList<Attachment> GetReenviarMensajeOutlook()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Responder o reenviar un mensaje de correo electrónico",
                    "Se aplica a: Outlook 2016 Outlook 2013 Office para empresas Office 365 Pequeña Empresa Outlook 2010 Outlook 2007",
                    "Cuando recibe un mensaje, puede enviar una respuesta solo al remitente o si hay varios destinatarios puede incluirlos también. Además, tiene la opción de reenviar el mensaje a otras personas.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Responder-o-reenviar-un-mensaje-de-correo-electr%C3%B3nico-a843f8d3-01b0-48da-96f5-a71f70d0d7c8?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Responder o reenviar un mensaje de correo electrónico
        public static IList<Attachment> GetReenviarYEnviarMensajeOutlook()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Responder o reenviar un mensaje de correo electrónico",
                    "Se aplica a: Outlook 2016 Outlook 2013 Office para empresas Office 365 Pequeña Empresa Outlook 2010 Outlook 2007",
                    "Cuando recibe un mensaje, puede enviar una respuesta solo al remitente o si hay varios destinatarios puede incluirlos también. Además, tiene la opción de reenviar el mensaje a otras personas.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Responder-o-reenviar-un-mensaje-de-correo-electr%C3%B3nico-a843f8d3-01b0-48da-96f5-a71f70d0d7c8?ui=es-ES&rs=es-ES&ad=ES")),
                 GetHeroCardV2(
                    "Crear y enviar correo electrónico",
                    "",
                    "",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Inicio-r%C3%A1pido-de-Outlook-2016-e9da47c4-9b89-4b49-b945-a204aeea6726?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Reenviar una reunión
        public static IList<Attachment> GetReenviarReuniónOutlookYMensajeOutlook()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Reenviar una reunión",
                    "Se aplica a: Outlook 2016 Outlook 2013",
                    "Existen dos maneras de reenviar una reunión, dependiendo de si la reunión está en su calendario o en su correo electrónico.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Reenviar-una-reuni%C3%B3n-94f2df68-8109-4334-8bfa-f5c013dc1578")),
                GetHeroCardV2(
                    "Responder o reenviar un mensaje de correo electrónico",
                    "Se aplica a: Outlook 2016 Outlook 2013 Office para empresas Office 365 Pequeña Empresa Outlook 2010 Outlook 2007",
                    "Cuando recibe un mensaje, puede enviar una respuesta solo al remitente o si hay varios destinatarios puede incluirlos también. Además, tiene la opción de reenviar el mensaje a otras personas.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Responder-o-reenviar-un-mensaje-de-correo-electr%C3%B3nico-a843f8d3-01b0-48da-96f5-a71f70d0d7c8?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // ---------------------
        // ORGANIZAR
        // ---------------------
        //Organizar el calendario con categorías de colores
        public static IList<Attachment> GetOrganizarCalendariosCategorias()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Organizar el calendario con categorías de colores",
                    "Se aplica a: Outlook 2013",
                    "Si tiene muchas citas y reuniones en el calendario de Outlook, agregue categorías de colores para poder examinar y asociar visualmente elementos parecidos.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Organizar-el-calendario-con-categor%C3%ADas-de-colores-74688307-88d1-40cb-98c2-92c5d7aa2e97?ui=es-ES&rs=es-ES&ad=ES")),

            };
        }

        // --------------------
        // ESTABLECER
        // --------------------
        // Establecer o quitar avisos
        public static IList<Attachment> GetEstablecerAvisoOutlook()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Establecer o quitar avisos",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010 Outlook 2007",
                    "Deje que Outlook sea su reloj de alarma personal. Establezca avisos que le informen de cuándo se aproxima una reunión o una cita.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Establecer-o-quitar-avisos-7a992377-ca93-4ddd-a711-851ef3597925")),

            };
        }

        // GetContacto Y Lista
        public static IList<Attachment> GetContactoYBloqueados()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Bloquear a un remitente de correo",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010 Outlook 2007",
                    "Como parte de sus criterios de filtrado, el filtro de correo electrónico no deseado de Outlook comprueba los remitentes de mensajes con las listas de direcciones de correo electrónico y dominios de Internet designados como seguro o bloqueado.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Bloquear-a-un-remitente-de-correo-b29fd867-cac9-40d8-aed1-659e06a706e4?ui=es-ES&rs=es-HN&ad=PE")),
                GetHeroCardV2(
                    "Como agregar alguna persona a un grupo de contactos",
                    "Se aplica a: Outlook 2016 Outlook 2013",
                    "Use un grupo de contactos (anteriormente denominado “lista de distribución”) para enviar un mensaje de correo electrónico a varias personas (un equipo de proyecto, un comité o incluso solo un grupo de amigos) sin tener que agregar cada nombre cada vez que desea escribirles.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/agregar-personas-a-un-grupo-de-contactos-0c6c3bee-0529-4d87-822f-026620072e28")),
            };
        }

        // GetContacto Y Lista Y Categorias
        public static IList<Attachment> GetContactoYListaYCategorias()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Bloquear a un remitente de correo",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010 Outlook 2007",
                    "Como parte de sus criterios de filtrado, el filtro de correo electrónico no deseado de Outlook comprueba los remitentes de mensajes con las listas de direcciones de correo electrónico y dominios de Internet designados como seguro o bloqueado.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Bloquear-a-un-remitente-de-correo-b29fd867-cac9-40d8-aed1-659e06a706e4?ui=es-ES&rs=es-HN&ad=PE")),
                GetHeroCardV2(
                    "Como agregar alguna persona a un grupo de contactos",
                    "Se aplica a: Outlook 2016 Outlook 2013",
                    "Use un grupo de contactos (anteriormente denominado “lista de distribución”) para enviar un mensaje de correo electrónico a varias personas (un equipo de proyecto, un comité o incluso solo un grupo de amigos) sin tener que agregar cada nombre cada vez que desea escribirles.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/agregar-personas-a-un-grupo-de-contactos-0c6c3bee-0529-4d87-822f-026620072e28")),
                GetHeroCardV2(
                    "Crear y asignar categorías de color",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010 Outlook 2007",
                    "Categorías de color permiten identificar y agrupar elementos asociados en Microsoft Outlook fácilmente. " +
                    "Asignar una categoría de color a un grupo de elementos interrelacionados, como notas, contactos, citas y " +
                    "mensajes de correo electrónico, para que puede realizar un seguimiento y organizarlos rápidamente. ",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Crear-y-asignar-categor%C3%ADas-de-color-a1fde97e-15e1-4179-a1a0-8a91ef89b8dc")),
            };
        }

        // ---------------------
        // ABRIR Y CERRAR
        // ---------------------
        // Abrir y cerrar archivos de datos de Outlook (.pst)
        public static IList<Attachment> GetAbrirArchivosDatosOutlook()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Abrir y cerrar archivos de datos de Outlook (.pst)",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010 Outlook 2007",
                    "Outlook es parte de su rutina diaria. Se usa para enviar mensajes de correo electrónico, configurar eventos del calendario y crear tareas y otros elementos.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Abrir-y-cerrar-Archivos-de-datos-de-Outlook-pst-381b776d-7511-45a0-953a-0935c79d24f2")),

            };
        }

        // Abrir y cerrar archivos
        public static IList<Attachment> GetRespuestaAbrirDialog()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Abrir y cerrar archivos de datos de Outlook (.pst)",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010 Outlook 2007",
                    "Outlook es parte de su rutina diaria. Se usa para enviar mensajes de correo electrónico, configurar eventos del calendario y crear tareas y otros elementos.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Abrir-y-cerrar-Archivos-de-datos-de-Outlook-pst-381b776d-7511-45a0-953a-0935c79d24f2")),
                GetHeroCardV2(
                    "Abrir y buscar elementos en un archivo de datos de Outlook (.pst)",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010 Outlook 2007",
                    "Si usa una cuenta POP o IMAP, toda la información de Outlook se almacenan en un archivo de datos de Outlook, también conocido como un Archivo de carpetas personales (.pst).",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Abrir-y-buscar-elementos-en-un-Archivo-de-datos-de-Outlook-pst-2e2b55a4-f681-4b93-90cb-31d39349fb95")),

            };
        }

        // ---------------------
        // GUARDAR
        // ---------------------
        // Guardar mensaje en outlook
        public static IList<Attachment> GetGuardarMensajeOutlook()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Guardar un mensaje",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010 Outlook 2007",
                    "Outlook ofrece varias opciones para guardar un mensaje de correo electrónico. Un mensaje que recibe, por ejemplo, se puede guardar como un archivo en el equipo.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Guardar-un-mensaje-4821bcd4-7687-4d6d-a486-b89a291a56e2")),

            };
        }

        // ---------------------
        // IMPRIMIR
        // ---------------------
        // Imprimir contactos, mensajes u otros elementos de Outlook
        public static IList<Attachment> GetImprimirContactosMensajesOutlook()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Imprimir contactos, mensajes u otros elementos de Outlook",
                    "Se aplica a: Outlook 2016 Outlook 2013 Office para empresas Office 365 Pequeña Empresa Outlook 2010 Outlook 2007",
                    "Puede imprimir mensajes, contactos, calendarios, reuniones y tareas en Outlook. Cada tipo de elemento de Outlook tiene varias opciones de impresión.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Imprimir-contactos-mensajes-u-otros-elementos-de-Outlook-d2c0b12b-e308-41ce-9016-a3089ebdbe38?ui=es-ES&rs=es-HN&ad=PE")),

            };
        }

        // ---------------------
        // OBTENER
        // ---------------------
        // Obtener un id digital
        public static IList<Attachment> GetObtenerIdDigitalOutlook()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                     "Obtener un id. digital",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010 Outlook 2007",
                    "Un identificador digital le permite enviar mensajes firmados digitalmente con Microsoft Outlook. Un identificador digital, también "+
                    "denominado certificado digital, le ayuda a demostrar su identidad y a evitar la manipulación de mensajes para proteger la autenticidad "+
                    "de un mensaje de correo electrónico.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Obtener-un-Id-digital-0eaa0ab9-b8a2-4a7e-828b-9bded6370b7b")),

            };
        }

        //Obtener información sobre cómo navegar en Outlook con características de accesibilidad
        public static IList<Attachment> GetObtenerInformacionNavegarOutlook()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Obtener información sobre cómo navegar en Outlook con características de accesibilidad",
                    "Se aplica a: Outlook 2016 Outlook 2016 para Mac Outlook en la web para Office 365 Empresa Outlook.com Calendario de Outlook para Windows 10 Outlook para iOS y Android Outlook para Windows Phone 10 ...",
                    "Este artículo va dirigido a los usuarios que usan un programa de lector de pantalla con los productos de Office y forma parte del conjunto de contenido de accesibilidad de Office.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Obtener-informaci%C3%B3n-sobre-c%C3%B3mo-navegar-en-Outlook-con-caracter%C3%ADsticas-de-accesibilidad-3dfe1380-ee04-4399-a3ff-800d3d4362a1?ui=es-ES&rs=es-ES&ad=ES")),

            };
        }

        // ---------------------
        // COMPARTIR
        // ---------------------
        //Compartir una carpeta de contactos con otros usuarios
        public static IList<Attachment> GetCompartirCarpetaContactosUsuarios()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Compartir una carpeta de contactos con otros usuarios",
                    "Se aplica a: Outlook 2016 Outlook 2013 Office para empresas Office 365 Pequeña Empresa Outlook 2010 Outlook 2007",
                    "Puede compartir cualquiera de las carpetas de contactos de cuenta de Exchange Server con otra persona que también está usando una cuenta de Exchange Server en su organización.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Compartir-una-carpeta-de-contactos-con-otros-usuarios-ce5a40d1-bc9f-4f5d-a2aa-5ec388573821")),

            };
        }

        // ---------------------
        //EXPORTAR
        //----------------------
        //Exportar un calendario de Outlook a Google Calendar
        public static IList<Attachment> GetExportarCalendarioGoogleCalendar()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Exportar un calendario de Outlook a Google Calendar",
                    "Se aplica a: Outlook 2016 Outlook 2013",
                    "Cuando exporta su calendario de Outlook a Google Calendar, está exportando una instantánea del calendario. Cualquier cambio que realice en su calendario de Outlook no se reflejará automáticamente en Google Calendar.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Exportar-un-Calendario-de-Outlook-a-Google-Calendar-662fa3bb-0794-4b18-add8-9968b665f4e6")),

            };
        }

        //Exportar o hacer una copia de seguridad del correo electrónico, los contactos y el calendario a un archivo .pst de Outlook
        public static IList<Attachment> GetExportarCorreoContactosCalendarioOutlook()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Exportar o hacer una copia de seguridad del correo electrónico, los contactos y el calendario a un archivo .pst de Outlook",
                    "Se aplica a: Outlook 2016 Outlook 2013 Office para empresas Administración de Office 365, ...",
                    "Cuando en el equipo se instala una aplicación Outlook, como Outlook 2016, puede usarla para transferir el correo electrónico, los contactos y los elementos de calendario desde una cuenta de correo a otra.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Exportar-o-hacer-una-copia-de-seguridad-del-correo-electr%C3%B3nico-los-contactos-y-el-calendario-a-un-archivo-pst-de-Outlook-14252b52-3075-4e9b-be4e-ff9ef1068f91")),

            };
        }

        //---------------------
        //IMPORTAR
        //---------------------
        //Importar Gmail a Outlook
        public static IList<Attachment> GetImportarGmailOutlook()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Importar Gmail a Outlook",
                    "Se aplica a: Outlook 2016 Outlook 2013 Office para empresas Administración de Office 365, ...",
                    "Cuando cambia al correo electrónico de Office 365 desde otro servicio como Gmail (o Yahoo! o AOL) tiene dos opciones: Importar una copia de todos los mensajes antiguos a la cuenta de Office 365 y conectar una cuenta de correo antigua a Outlook",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Imprimir-contactos-mensajes-u-otros-elementos-de-Outlook-d2c0b12b-e308-41ce-9016-a3089ebdbe38?ui=es-ES&rs=es-HN&ad=PE")),
                GetVideoCard(
                    "Office 365 - Outlook",
                    "Importar Gmail a Outlook",
                    "https://videocontent.osi.office.net/50d42c82-ee90-4ef8-995a-a36eb8a04a8a/1ca01592-9571-4fd4-bb2b-dab502ad3bf0__H264_3400kbps_AAC_und_ch2_96kbps.mp4",
                    "https://support.office.com/es-es/article/Imprimir-contactos-mensajes-u-otros-elementos-de-Outlook-d2c0b12b-e308-41ce-9016-a3089ebdbe38?ui=es-ES&rs=es-HN&ad=PE"),

            };
        }

        //Importar contactos a Outlook
        public static IList<Attachment> GetImportarContactosOutlook()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Importar contactos a Outlook",
                    "Se aplica a: Outlook 2016 Outlook 2013 Office para empresas Administración de Office 365, ...",
                    "Outlook dispone de un asistente para importar y exportar que facilita la importación de contactos desde un archivo CSV.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/importar-contactos-a-outlook-bb796340-b58a-46c1-90c7-b549b8f3c5f8")),

            };
        }

        // ----------------------------------------------------------------------- 
        // PREGUNTAS SECUNDARIAS DE OUTLOOK                                                    
        // ----------------------------------------------------------------------- 

        // Firma en los mensajes
        public static IList<Attachment> GetFirma()
        {
            return new List<Attachment>()
            {
              GetVideoCard(
                    "Agrega firmas a los correos eléctrónicos",
                    "Cree, edite y adjunte una firma a los mensajes de correo electrónico que envíe, responda y reenvíe.",
                    "https://videocontent.osi.office.net/fb74c9d6-32b8-4fef-9b86-aac0b12abee5/00662c0a-de3a-4378-a16e-01369b724b1b_1280x720_3400.mp4",
                    "https://support.office.com/es-es/article/Agregar-firmas-a-los-mensajes-31fb24f9-e698-4789-b92a-f0e777f774ca#ID0EAABAAA=P%C3%B3ngalo_en_pr%C3%A1ctica"),
            };
        }

        // Utilice las categorías en Outlook.com o en Outlook en la web
        public static IList<Attachment> GetUtiliceCategoriasOutlook()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Utilice las categorías en Outlook.com o en Outlook en la web",
                    "Se aplica a: Outlook en la web para Office 365 Empresa Outlook.com Outlook en la web para Exchange Server 2016",
                    "Categorías le permiten identificar y agrupar mensajes en Outlook.com o Outlook en la Web fácilmente. " +
                    "Elegir entre categorías predeterminadas o crear sus propios y asignar una o varias categorías a sus mensajes.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/utilice-las-categor%C3%ADas-en-outlook-com-o-en-outlook-en-la-web-a0f709a4-9bd8-45d7-a2b3-b6f8c299e079")),
            };
        }

        // Enviar un mensaje de correo basado en una plantilla
        public static IList<Attachment> GetCrearPlantilla()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Enviar un mensaje de correo basado en una plantilla",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010 Outlook 2007",
                    "Usar plantillas de correo electrónico para enviar mensajes que incluyen información que no cambia",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/enviar-un-mensaje-de-correo-basado-en-una-plantilla-56c645fc-1b25-4059-808b-55ee72b6bc2d")),
            };
        }

        // Creando y asignando tareas
        public static IList<Attachment> GetCreandoAsignandoTareas()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Creando y asignando tareas",
                    "Se aplica a: Outlook",
                    "Cree, edite y marque como completadas las tareas o elimine una tarea.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/crear-y-actualizar-tareas-6de6ee52-751b-4405-b389-850572b15306")),
            };
        }

        // Crear Grupo
        public static IList<Attachment> GetCrearGrupo()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Crear un grupo en Outlook",
                    "Última actualización: Octubre de 2017",
                    "Grupos es una característica de Office 365 que proporciona un área de trabajo compartida para colaborar y compartir.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/crear-un-grupo-en-outlook-04d0c9cf-6864-423c-a380-4fa858f27102")),
            };
        }

        // Crear diseños en Outlook
        public static IList<Attachment> GetCrearDiseños()
        {
            return new List<Attachment>()
            {
                GetVideoCard(
                    "Diseña tu propia plantilla para los emails",
                    "Puede diseñar, crear y usar diseños de fondo personales en un mensaje de correo electrónico de Outlook.",
                    "https://videocontent.osi.office.net/f9a2eaa7-3903-4c08-ab17-e657ea6d5313/b49b96b9-9bfd-4db0-be61-f33bc9159f2b_1280x720_3400.mp4",
                    "https://support.office.com/es-es/article/dise%C3%B1ar-dise%C3%B1os-de-fondo-personales-b059b1be-5875-40ca-8399-ad0fb7dd21cd"),
            };
        }

        // Crear, modificar o eliminar una convocatoria de reunión o una cita en Outlook en la web o Outlook.com
        public static IList<Attachment> GetCrearEvento()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Crear, modificar o eliminar una convocatoria de reunión o una cita en Outlook en la web o Outlook.com",
                    "Se aplica a: Office para empresas Office 365 Pequeña Empresa Outlook en la web para Office 365 Empresa Outlook.com",
                    "Puede crear, modificar o eliminar una convocatoria de reunión o una cita enOutlook.com yOutlook en la Web.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/crear-modificar-o-eliminar-una-convocatoria-de-reuni%C3%B3n-o-una-cita-en-outlook-en-la-web-o-outlook-com-541383fd-35b7-49a6-b4c8-2ee75af2f40a")),
            };
        }

        // Crear un mensaje de correo electrónico
        public static IList<Attachment> GetCrearMensaje()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Crear un mensaje de correo electrónico",
                    "Se aplica a: Outlook 2010",
                    "",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Crear-un-mensaje-de-correo-electr%C3%B3nico-83eb5c08-15e1-4936-8bf9-f476d38a5182")),
            };
        }

        // Crear o Agregar una cita o un evento
        public static IList<Attachment> GetCrearAgregarCitaEvento()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Crear una cita o un evento",
                    "Se aplica a: Outlook",
                    "Programe una cita para informar a otros usuarios de Outlook de su disponibilidad (libre, ocupado, provisional o fuera de la oficina).",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/programar-citas-6e6ddec6-5983-4c42-9652-b99e120206fb")),
            };
        }

        // Buscar elementos
        public static IList<Attachment> GetBuscarElemento()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Abrir o importar elementos desde un archivo de datos de Outlook sin conexión (.ost)",
                    "Se aplica a: Outlook 2016 Outlook 2010",
                    "Microsoft Outlook 2010 no admite abrir o importar elementos de un Archivo de datos de Outlook sin conexión (.ost) manualmente.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/abrir-o-importar-elementos-desde-un-archivo-de-datos-de-outlook-sin-conexi%C3%B3n-ost-a584963e-a66d-4d9d-8845-31cb270f6880")),
                GetHeroCardV2(
                    "Buscar elementos mediante una búsqueda básica en Outlook para Mac",
                    "Se aplica a: Office para empresas Office 365 Pequeña Empresa Outlook 2016 para Mac Office 2016 para Mac Outlook para Mac 2011",
                    "Realizar una búsqueda básica en Outlook.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/buscar-elementos-mediante-una-b%C3%BAsqueda-b%C3%A1sica-en-outlook-para-mac-53b60f65-25b7-4582-9c5e-4adf16e503a1")),
            };
        }

        // Agregar rápidamente nuevos contactos en Outlook
        public static IList<Attachment> GetAgregarRapidamenteContactos()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Agregar rápidamente nuevos contactos en Outlook",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010 Outlook 2007",
                    "En muchos casos, no hay tener que escribir toda la información de un nuevo contacto en Microsoft Office Outlook 2007. Estos algunos métodos abreviados para simplificar su trabajo.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/agregar-r%C3%A1pidamente-nuevos-contactos-en-outlook-6a18568a-73c7-42c8-957c-a59ae1175976")),
            };
        }

        // Usar gráficos en mensajes de correo electrónico
        public static IList<Attachment> GetUsarGráficos()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Usar gráficos en mensajes de correo electrónico",
                    "Se aplica a: Outlook 2007",
                    "En este artículo:Acerca de los diagramas y gráficos en Outlook 2007, Elija un tipo de gráfico e insertar datos, Organizar los datos para un gráfico",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/usar-gr%C3%A1ficos-en-mensajes-de-correo-electr%C3%B3nico-126637af-c599-4378-adf9-3adaa66c307e")),
            };
        }

        // Insertar o crear tablas
        // Insertar, cambiar o eliminar una tabla en Outlook.com
        public static IList<Attachment> GetAgregarTablas()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Insertar o crear tablas",
                    "Se aplica a: Outlook 2007",
                    "En Microsoft Outlook, puede insertar una tabla en un mensaje de correo electrónico, o puede insertar una tabla en otra tabla para crear una tabla más compleja.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/insertar-o-crear-tablas-8a638153-3149-4185-995c-3e11faae93f4")),
                 GetHeroCardV2(
                    "Insertar, cambiar o eliminar una tabla en Outlook.com",
                    "Se aplica a: Outlook en la web para Office 365 Empresa Outlook.com",
                    "Puede insertar una tabla en mensajes de correo electrónico Outlook en la Web o calendarios para ayudarle a organizar los datos.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/insertar-cambiar-o-eliminar-una-tabla-en-outlook-com-8a2916f7-a2f5-4c71-944a-658d56342d4c")),
            };
        }

        // Agregar y solicitar confirmaciones de lectura y notificaciones de entrega
        public static IList<Attachment> GetAgregarConfirmacion()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Agregar y solicitar confirmaciones de lectura y notificaciones de entrega",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010 Outlook 2007",
                    "Una confirmación de entrega confirma la entrega del mensaje de correo electrónico al buzón del destinatario",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/agregar-y-solicitar-confirmaciones-de-lectura-y-notificaciones-de-entrega-a34bf70a-4c2c-4461-b2a1-12e4a7a92141")),
            };
        }

        // Activar y desactivar las alertas de escritorio
        public static IList<Attachment> GetActivarDesactivarAlertas()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Activar y desactivar las alertas de escritorio",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010 Outlook 2007",
                    "Una Alerta de escritorio es una notificación que aparece en su escritorio cuando recibe un nuevo mensaje de " +
                    "correo electrónico, una convocatoria de reunión o una solicitud de tarea. De manera predeterminada, las Alertas " +
                    "de escritorio están activadas.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/activar-y-desactivar-las-alertas-de-escritorio-9940c70e-b306-442e-a856-d94b20318481")),
            };
        }

        // Agregar la confirmación de entrega para realizar un seguimiento de un mensaje de correo electrónico
        public static IList<Attachment> GetSeguimiento()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Agregar la confirmación de entrega para realizar un seguimiento de un mensaje de correo electrónico",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010 Outlook 2007",
                    "Una confirmación de entrega indica que un mensaje de correo se ha enviado al buzón del destinatario, pero no si el destinatario lo ha visto o leído. Una confirmación de lectura avisa cuando se abre un mensaje. En ambos casos, recibirá un mensaje de notificación en la Bandeja de entrada.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/agregar-la-confirmaci%C3%B3n-de-entrega-para-realizar-un-seguimiento-de-un-mensaje-de-correo-electr%C3%B3nico-69cd1b39-2300-482d-96c6-22e2f4a96848")),
            };
        }

        // Agregar tiempo de fuera de la oficina en los calendarios de Outlook de compañeros
        // Agregar días no laborables o festividades al calendario
        public static IList<Attachment> GetAgregarDiasNoLaborables()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Agregar tiempo de fuera de la oficina en los calendarios de Outlook de compañeros",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010 Outlook 2007",
                    "Este artículo explica cómo agregar personalizada las convocatorias de reunión de todo el día a " +
                    "calendarios de compañeros de trabajo, sin que ello afecte el tiempo libre disponible en sus calendarios.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/agregar-la-confirmaci%C3%B3n-de-entrega-para-realizar-un-seguimiento-de-un-mensaje-de-correo-electr%C3%B3nico-69cd1b39-2300-482d-96c6-22e2f4a96848")),
                GetHeroCardV2(
                    "Agregar días no laborables o festividades al calendario",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010 Outlook 2007",
                    "Un calendario personal no está completo sin los días no laborables. Y puede agregarlos con Outlook. " +
                    "O quizás quiera agregar sus propios días no laborables y fechas importantes, como cumpleaños, fechas " +
                    "escolares y vacaciones de la empresa. ",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/agregar-la-confirmaci%C3%B3n-de-entrega-para-realizar-un-seguimiento-de-un-mensaje-de-correo-electr%C3%B3nico-69cd1b39-2300-482d-96c6-22e2f4a96848")),
            };
        }

        // Agregar o editar una imagen de una tarjeta de presentación electrónica
        public static IList<Attachment> GetTarjeta()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Agregar o editar una imagen de una tarjeta de presentación electrónica",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010 Outlook 2007",
                    "Si está creando una tarjeta para usted o edita una tarjeta que ha recibido de otra persona, puede " +
                    "agregar o cambiar las imágenes en una tarjeta de presentación electrónica.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Agregar-o-editar-una-imagen-de-una-tarjeta-de-presentaci%C3%B3n-electr%C3%B3nica-92939924-fa42-4756-b4d5-b3b5ad762b35")),
            };
        }

        // Crear o quitar un hipervínculo en un mensaje en Outlook para Mac
        public static IList<Attachment> GetCrearQUitarHipervínculoParaMac()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Crear o quitar un hipervínculo en un mensaje en Outlook para Mac",
                    "Se aplica a: Office para empresas Office 365 Pequeña Empresa Outlook 2016 para Mac Office 2016 para Mac Outlook para Mac 2011",
                    "Suede agregar vínculos al cuerpo de los mensajes de correo electrónico y mostrarlos como direcciones URL completas o como cualquier texto que elija.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/crear-o-quitar-un-hiperv%C3%ADnculo-en-un-mensaje-en-outlook-para-mac-956c3c5a-d331-4669-bfdb-e735d37bf7fc")),

            };
        }

        // Crear diseños de fondo para los mensajes de correo electrónico
        public static IList<Attachment> GetCrearDiseñosParaMensajes()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Crear diseños de fondo para los mensajes de correo electrónico",
                    "Se aplica a: Outlook 2010",
                    "Los diseños de fondo y los temas son un conjunto de elementos de diseño unificados y combinaciones de color. Especifican fuentes, viñetas, colores de fondo, líneas horizontales, imágenes y otros elementos de diseño que se incluirán en los mensajes de correo electrónico salientes.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/crear-dise%C3%B1os-de-fondo-para-los-mensajes-de-correo-electr%C3%B3nico-6742573e-4bdf-411e-99cf-b358a79ac3ff")),

            };
        }

        // Buscar en Correo y Contactos en Outlook.com
        public static IList<Attachment> GetBuscarsCorreoContactos()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Buscar en Correo y Contactos en Outlook.com",
                    "Se aplica a: Outlook.com",
                    "Busque mensajes y contactos en Outlook.com usando el cuadro Buscar en Correo y en Contactos de la parte superior de la página.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/buscar-en-correo-y-contactos-en-outlook-com-88108edf-028e-4306-b87e-7400bbb40aa7")),

            };
        }

        // Administrar el correo electrónico no deseado
        // Administrar los contactos y la lista de contactos
        // Agregar rápidamente nuevos contactos en Outlook
        public static IList<Attachment> GetAgregarYBloquearContactos()
        {
            return new List<Attachment>()
            {
                GetVideoCard(
                    " Administrar el correo electrónico no deseado",
                    "Para poner automáticamente el spam en la carpeta Correo no deseado, utilice la lista Remitentes bloqueados. " +
                    "Para evitar que determinados mensajes se marquen como correo no deseado, agregue personas a la lista " +
                    "Remitentes seguros.",
                    "https://videocontent.osi.office.net/27093c65-8438-4202-b9b0-0e72305b6407/4abaadc5-edfd-402c-b25a-900546654fc8_1280x720_3400.mp4",
                    "https://support.office.com/es-es/article/administrar-correo-no-deseado-con-las-listas-remitentes-bloqueados-y-remitentes-seguros-ed960552-eac9-41e5-a9bf-e7e706fefa88"),
                GetHeroCardV2(
                    "Agregar rápidamente nuevos contactos en Outlook",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010 Outlook 2007",
                    "En muchos casos, no hay tener que escribir toda la información de un nuevo contacto en Microsoft Office Outlook 2007. Estos algunos métodos abreviados para simplificar su trabajo.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/agregar-r%C3%A1pidamente-nuevos-contactos-en-outlook-6a18568a-73c7-42c8-957c-a59ae1175976")),
                GetHeroCardV2(
                    "Agregar personas a la Libreta de direcciones",
                    "Se aplica a: Outlook 2010",
                    "El Libreta de direcciones es un contenedor para todos los contactos. Esto significa que cada carpeta de " +
                    "contactos, como el trabajo, casa, sociales, clientes potenciales, etc., es un subconjunto de la libreta " +
                    "de direcciones.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/buscar-en-correo-y-contactos-en-outlook-com-88108edf-028e-4306-b87e-7400bbb40aa7")),

            };
        }

        // Cambiar un tema y establecerlo como predeterminado en Outlook o en Access
        public static IList<Attachment> GetCambiarTema()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Cambiar un tema y establecerlo como predeterminado en Outlook o en Access",
                    "Se aplica a: Outlook 2016 Access 2016 Outlook 2013 Access 2013",
                    "Cambiar una combinación de color o el tema de documento puede ser confusa. Para cambiar el tema actual, cambie a otro, o crear un nuevo tema, use los comandos ligeramente diferentes, dependiendo de qué aplicación esté utilizando:",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/buscar-en-correo-y-contactos-en-outlook-com-88108edf-028e-4306-b87e-7400bbb40aa7")),

            };
        }

        // Definir la fuente o el color del texto de los mensajes enviados
        public static IList<Attachment> GetDefinirFuente()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Definir la fuente o el color del texto de los mensajes enviados",
                    "Se aplica a: Outlook 2016 Outlook 2013 Office para empresas Office 365 Pequeña Empresa Outlook 2010",
                    "Puede cambiar la fuente y el color, tamaño y el estilo, como negrita o cursiva para todos los mensajes que envíe. Por ejemplo, puede cambiar el color del texto del mensaje o usar la fuente Arial en lugar de la predeterminada Calibri.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/definir-la-fuente-o-el-color-del-texto-de-los-mensajes-enviados-83425b7b-4acc-4e94-8c04-fa1e31790318")),

            };
        }

        // Cambiar la foto o el nombre de perfil en Outlook.com
        public static IList<Attachment> GetCambiarNombrePerfil()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Cambiar la foto o el nombre de perfil en Outlook.com",
                    "Se aplica a: Outlook 2016 Outlook 2013 Office para empresas Office 365 Pequeña Empresa Outlook 2010",
                    "",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/cambiar-la-foto-y-la-informaci%C3%B3n-de-cuenta-en-outlook-en-la-web-b2dbb289-851d-4bed-93c3-3e136f5659ec")),

            };
        }

        // Camabiar configuración de la visualización del correo
        public static IList<Attachment> GetCambiarConfiguracionVisualizacionCorreo()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Configuración de la visualización del correo",
                    "Se aplica a: Outlook Web App",
                    "Use la configuración de la visualización para establecer la apariencia de la lista de mensajes, el panel de lectura y la vista de conversación.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Configuraci%C3%B3n-de-la-visualizaci%C3%B3n-del-correo-a62ead01-4e64-45a8-a497-f462589956de")),

            };
        }

        // Cambiar la zona horaria para una cita o reunión
        public static IList<Attachment> GetCambiarZonaHorariaCita()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Cambiar la zona horaria para una cita o reunión",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010 Outlook 2007",
                    "Puede cambiar la zona horaria para una sola reunión o cita y mantener no afecta la zona horaria de su PC.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Cambiar-la-zona-horaria-para-una-cita-o-reuni%C3%B3n-C5485AB4-9DDD-4EAB-92B3-10217FE5FB08")),

            };
        }

        // Agregar, editar o eliminar una categoría en Business Contact Manager
        public static IList<Attachment> GetAgregarEditarEliminarCategoriaBusiness()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Agregar, editar o eliminar una categoría en Business Contact Manager",
                    "Se aplica a: Outlook 2007 Office 2007",
                    "Puede usar categorías en Business Contact Manager para Outlook para realizar un seguimiento de sus cuentas, contactos profesionales, oportunidades y proyectos profesionales modo significativo relacionadas con sus interacciones de negocio con ellos.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Agregar-editar-o-eliminar-una-categor%C3%ADa-en-Business-Contact-Manager-d0e58768-87d8-4c68-b824-580b093c4e81")),

            };
        }

        // ----------------------------------------------------------------------- 
        // PREGUNTAS NO IMPLEMENTADAS 

        // Mantener las próximas citas y reuniones siempre a la vista
        public static IList<Attachment> GetMantenerCitasReunionesVista()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Mantener las próximas citas y reuniones siempre a la vista",
                    "Se aplica a: Outlook 2016 Outlook 2013",
                    "",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Mantener-las-pr%C3%B3ximas-citas-y-reuniones-siempre-a-la-vista-0dc3d54c-9ae9-4285-9439-4f675244aae0")),
            };
        }

        // Marcar un mensaje como leído o como no leído
        public static IList<Attachment> GetMarcarMensajeComoLeidoONoLeido()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Marcar un mensaje como leído o como no leído",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010 Outlook 2007",
                    "En la Bandeja de entrada, los mensajes no leídos aparecen en negrita. Cuando haga clic en ellos y, después, en otro elemento, " +
                    "el título del mensaje dejará de estar en negrita, lo que pone de manifiesto que se ha leído.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Marcar-un-mensaje-como-le%C3%ADdo-o-como-no-le%C3%ADdo-59b44298-08c2-4eb7-8128-ea0fb7f52720")),
            };
        }

        // Activar y desactivar las alertas de escritorio
        public static IList<Attachment> GetActivarDesactivarAlertasEscritorio()
        {
            return new List<Attachment>()
            {
                GetVideoCard(
                    "Activar y desactivar las alertas de escritorio",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010 Outlook 2007",
                    "https://videocontent.osi.office.net/367cb3e3-121b-4e18-9662-1055bf6757ab/7a6cc676-5ef0-44c6-a7be-aa84ebd2bd08_1280x720_3400.mp4",
                    "https://support.office.com/es-es/article/Activar-y-desactivar-las-alertas-de-escritorio-9940c70e-b306-442e-a856-d94b20318481?ui=es-ES&rs=es-ES&ad=ES"),
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

        private Image DrawText(String text, Font font, Color textColor, Color backColor)
        {
            //first, create a dummy bitmap just to get a graphics object
            Image img = new Bitmap(1, 1);
            Graphics drawing = Graphics.FromImage(img);

            //measure the string to see how big the image needs to be
            SizeF textSize = drawing.MeasureString(text, font);

            //free up the dummy image and old graphics object
            img.Dispose();
            drawing.Dispose();

            //create a new image of the right size
            img = new Bitmap((int)textSize.Width, (int)textSize.Height);

            drawing = Graphics.FromImage(img);

            //paint the background
            drawing.Clear(backColor);

            //create a brush for the text
            Brush textBrush = new SolidBrush(textColor);

            drawing.DrawString(text, font, textBrush, 0, 0);

            drawing.Save();

            textBrush.Dispose();
            drawing.Dispose();

            return img;

        }

    }

}