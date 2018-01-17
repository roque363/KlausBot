using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Bot.Connector;

namespace KlausBot.Models
{
    public class Respuestas
    {
        // ------------------------------------------------------------- 
        // PREGUNTAS DE OUTLOOK                                          
        // ------------------------------------------------------------- 
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

        // Definicon de Outlook
        public static IList<Attachment> GetOutlookDefinicionCard()
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

        // -------------------------------------------------------------
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

        // Enviar respuestas automáticas "Fuera de la oficina" de Outlook
        public static IList<Attachment> GetEnviarRespuestasAutomaticas()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Enviar respuestas automáticas 'Fuera de la oficina' de Outlook",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010 Outlook 2007",
                    "Solo puede enviar respuestas automáticas de fuera de la oficina siguiendo estos pasos si tiene cuenta de Office 365, " +
                    "Outlook.com o Exchange. Para el resto de cuentas de correo electrónico, vea Enviar y redirigir correo electrónico automáticamente.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Enviar-respuestas-autom%C3%A1ticas-Fuera-de-la-oficina-de-Outlook-9742f476-5348-4f9f-997f-5e208513bd67?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Crear una carpeta de búsqueda
        public static IList<Attachment> GetCrearCarpetaBúsqueda()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Crear una carpeta de búsqueda",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010",
                    "Una carpeta de búsqueda es una carpeta virtual que proporciona una vista de todos los elementos de correo electrónico " +
                    "que coinciden con criterios de búsqueda específicos. Por ejemplo, la carpeta de búsqueda Correo sin leer permite ver " +
                    "todos los mensajes no leídos en la misma carpeta aunque los mensajes estén guardados en varias ubicaciones del buzón.",
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

        // -------------------------------------------------------------
        // PREGUNTAS DE EXCEL
        // -------------------------------------------------------------
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

        // -------------------------------------------------------------
        // PREGUNTAS DE POWER POINT
        // -------------------------------------------------------------
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

        // -------------------------------------------------------------
        // PREGUNTAS DE WORD
        // -------------------------------------------------------------
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

        // -------------------------------------------------------------

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

        private static Attachment GetCardConsulta(string text, String value)
        {
            var Saludocard = new ThumbnailCard
            {
                Title = text,
                Buttons = new List<CardAction>
                {
                    new CardAction(ActionTypes.PostBack, "Consulta", value: value),
                }
            };
            return Saludocard.ToAttachment();
        }

        public static IList<Attachment> GetConsulta()
        {
            return new List<Attachment>()
            {
                GetCardConsulta(
                    "¿Tienes una consulta?",
                    "Consulta"),
            };
        }

    }

}