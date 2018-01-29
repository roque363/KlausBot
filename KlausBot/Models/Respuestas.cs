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

        // gregar una confirmacion de lectura o una notificación de entreega
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
                    "Como agregar días no laborables a tu calendario en Outlook",
                    "Se aplica a: Outlook 2016 Outlook 2013",
                    "Cuando exporta su calendario de Outlook a Google Calendar, está exportando una instantánea del calendario. Cualquier cambio que realice en su calendario de Outlook no se reflejará automáticamente en Google Calendar.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Exportar-un-Calendario-de-Outlook-a-Google-Calendar-662fa3bb-0794-4b18-add8-9968b665f4e6")),

            };
        }

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

        // Crear un grupo de contactos desde una lista de contactos en Exce
        public static IList<Attachment> GetCrearGrupoContactosDesdeListaContactosExcel()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Crear un grupo de contactos desde una lista de contactos en Exce",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010 Outlook 2007",
                    "Use un grupo de contactos (anteriormente denominado “lista de distribución”) para enviar un mensaje de " +
                    "correo electrónico a varias personas (un equipo del proyecto, un comité o incluso solo un grupo de amigos) sin " +
                    "tener que agregar cada nombre cada vez que desea escribirles.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Crear-un-grupo-de-contactos-o-una-lista-de-distribuci%C3%B3n-en-Outlook-88ff6c60-0a1d-4b54-8c9d-9e1a71bc3023?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Crear un grupo de contactos desde una lista de contactos en Exce
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

        // incluir una tarjeta de presentación electrónica en una firma de correo electrónico
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

        // insertar hipervínculos de Facebook o Twitter en la firma de correo electrónico
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

        // adjuntar archivos en outlook
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

        //Responder o reenviar un mensaje de correo electrónico
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

        //Responder o reenviar un mensaje de correo electrónico
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

        //Enviar un mensaje de correo electrónico a un grupo de contactos
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

        //Establecer o quitar avisos
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

        // GetContacto Y Lista
        public static IList<Attachment> GetContactoYLista()
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

        //Abrir y cerrar archivos de datos de Outlook (.pst)
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

        //Abrir y cerrar archivos de datos de Outlook (.pst)
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

        //----------GUARDAR-OUTLOOK----------------
        //-----------------------------------------
        //Guardar mensaje en outlook
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

        //----------IMPRIMIR-OUTLOOK-------------
        //---------------------------------------
        //Imprimir contactos, mensajes u otros elementos de Outlook
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

        //----------OBTENER-OUTLOOK----------------
        //-----------------------------------------
        //Obtener un id digital
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

        // Ver solo los mensajes no leídos Y correo electrónico por conversación Y
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
        // -------------------------------------------------------------´´
        // Temas destacados de Outlook
        public static IList<Attachment> GetDestacadosOutlook()
        {
            return new List<Attachment>()
            {
                // Novedades en Outlook 2016 para Windows
                GetHeroCardV3(
                    "Novedades en Outlook 2016 para Windows",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-ES/article/Novedades-en-Outlook-2016-para-Windows-51c81e7a-de25-4a34-a7fe-bd79f8e48647")),
                // Crear y agregar una firma a los mensajes
                 GetHeroCardV3(
                    "Crear y agregar una firma a los mensajes",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Crear-y-agregar-una-firma-a-los-mensajes-8ee5d4f4-68fd-464a-a1c1-0e1c80bb27f2#ID0EAABAAA=2016,_2013")),
                // Enviar respuestas automáticas "Fuera de la oficina" de Outlook
                GetHeroCardV3(
                    "Enviar respuestas automáticas Fuera de la oficina",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Enviar-respuestas-autom%C3%A1ticas-Fuera-de-la-oficina-de-Outlook-9742f476-5348-4f9f-997f-5e208513bd67?ui=es-ES&rs=es-ES&ad=ES")),
                // Importar contactos desde Gmail
                GetHeroCardV3(
                    "Importar contactos desde Gmail",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Importar-contactos-desde-Gmail-ad99d439-04b6-4001-a266-c170df721291?ui=es-ES&rs=es-ES&ad=ES")),
                // Importar contactos a Outlook
                GetHeroCardV3(
                    "Importar contactos a Outlook",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-ES/article/Importar-contactos-a-Outlook-bb796340-b58a-46c1-90c7-b549b8f3c5f8")),
                // Recuperar elementos eliminados en Outlook para Windows
                GetHeroCardV3(
                    "Recuperar elementos eliminados en Outlook para Windows",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Recuperar-elementos-eliminados-en-Outlook-para-Windows-49e81f3c-c8f4-4426-a0b9-c0fd751d48ce?ui=es-ES&rs=es-ES&ad=ES")),
                // Recuperar o reemplazar un mensaje después de enviarlo
                GetHeroCardV3(
                    "Recuperar o reemplazar un mensaje después de enviarlo",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Recuperar-o-reemplazar-un-mensaje-despu%C3%A9s-de-enviarlo-35027f88-d655-4554-b4f8-6c0729a723a0?ui=es-ES&rs=es-ES&ad=ES")),
                // Outlook no responde, se detiene en «Procesando», deja de funcionar, se inmoviliza o se bloquea
                GetHeroCardV3(
                    "Outlook no responde, se bloquea o deja de funcionar",
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
                GetHeroCardV3(
                    "¿Qué es OneDrive para la Empresa?",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-ES/article/%C2%BFQu%C3%A9-es-OneDrive-para-la-Empresa-187f90af-056f-47c0-9656-cc0ddca7fdc2")),
                // ¿Qué versión de OneDrive uso?
                 GetHeroCardV3(
                    "¿Qué versión de OneDrive uso?",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/%C2%BFQu%C3%A9-versi%C3%B3n-de-OneDrve-uso-19246eae-8a51-490a-8d97-a645c151f2ba?ui=es-ES&rs=es-ES&ad=ES")),
                // Cargar fotografías y archivos en OneDrive
                GetHeroCardV3(
                    "Cargar fotografías y archivos en OneDrive",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-ES/article/Cargar-fotograf%C3%ADas-y-archivos-en-OneDrive-b00ad3fe-6643-4b16-9212-de00ef02b586")),
                // Recuperar archivos de tu equipo
                GetHeroCardV3(
                    "Recuperar archivos de tu equipo",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Recuperar-archivos-de-tu-equipo-70761550-519c-4d45-b780-5a613b2f8822?ui=es-ES&rs=es-ES&ad=ES")),
                // Compartir archivos y carpetas de OneDrive
                GetHeroCardV3(
                    "Compartir archivos y carpetas de OneDrive",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-ES/article/Compartir-archivos-y-carpetas-de-OneDrive-9fcc2f7d-de0c-4cec-93b0-a82024800c07")),
                // Usar OneDrive para Android
                GetHeroCardV3(
                    "Usar OneDrive para Android",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-ES/article/Usar-OneDrive-para-Android-eee1d31c-792d-41d4-8132-f9621b39eb36")),
                // Solucionar problemas de sincronización de OneDrive
                GetHeroCardV3(
                    "Solucionar problemas de sincronización de OneDrive",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-ES/article/Solucionar-problemas-de-sincronizaci%C3%B3n-de-OneDrive-0899b115-05f7-45ec-95b2-e4cc8c4670b2")),
                // Configurar el equipo para sincronizar los archivos de OneDrive para la Empresa en Office 365
                GetHeroCardV3(
                    "Configurar el equipo para sincronizar los archivos",
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
                GetHeroCardV3(
                    "Novedades de Word 2016 para Windows",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Novedades-de-Word-2016-para-Windows-4219dfb5-23fc-4853-95aa-b13a674a6670?ui=es-ES&rs=es-ES&ad=ES")),
                // Descargar plantillas pregeneradas gratuitas
                 GetHeroCardV3(
                    "Descargar plantillas pregeneradas gratuitas",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-ES/article/Descargar-plantillas-pregeneradas-gratuitas-29f2a18d-29a6-4a07-998b-cfe5ff7ffbbb")),
                // Realizar un seguimiento de los cambios en Word
                GetHeroCardV3(
                    "Realizar un seguimiento de los cambios en Word",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Realizar-un-seguimiento-de-los-cambios-en-Word-197ba630-0f5f-4a8e-9a77-3712475e806a?ui=es-ES&rs=es-ES&ad=ES")),
                // Cambiar o establecer la fuente predeterminada
                GetHeroCardV3(
                    "Cambiar o establecer la fuente predeterminada",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-ES/article/Cambiar-o-establecer-la-fuente-predeterminada-20f72414-2c42-4b53-9654-d07a92b9294a")),
                // Agregar un gráfico al documento en Word
                GetHeroCardV3(
                    "Agregar un gráfico al documento en Word",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Agregar-un-gr%C3%A1fico-al-documento-en-Word-ff48e3eb-5e04-4368-a39e-20df7c798932?ui=es-ES&rs=es-ES&ad=ES")),
                // Soporte de accesibilidad para Word
                GetHeroCardV3(
                    "Soporte de accesibilidad para Word",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-ES/article/Soporte-de-accesibilidad-para-Word-c014d8b8-4ef3-4a7a-935d-295663f3343c")),
                // Iniciar la numeración de página más adelante en el documento
                GetHeroCardV3(
                    "Iniciar la numeración de página más adelante en el documento",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-ES/article/Iniciar-la-numeraci%C3%B3n-de-p%C3%A1ginas-m%C3%A1s-adelante-en-el-documento%C2%A0-c73e3d55-d722-4bd0-886e-0b0bd0eb3f02")),
                // Eliminar o cambiar un encabezado o pie de página de una sola página
                GetHeroCardV3(
                    "Eliminar o cambiar un encabezado o pie de página de una sola página",
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
                GetHeroCardV3(
                    "Novedades en Excel 2016 para Windows",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-ES/article/Novedades-en-Excel-2016-para-Windows-5fdb9208-ff33-45b6-9e08-1f5cdb3a6c73")),
                // Mover o copiar hojas de cálculo o los datos que contienen
                 GetHeroCardV3(
                    "Mover o copiar hojas de cálculo o los datos que contienen",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Mover-o-copiar-hojas-de-c%C3%A1lculo-o-los-datos-que-contienen-47207967-bbb2-4e95-9b5c-3c174aa69328?ui=es-ES&rs=es-ES&ad=ES")),
                // Crear una lista desplegable
                GetHeroCardV3(
                    "Crear una lista desplegable",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-ES/article/Crear-una-lista-desplegable-7693307a-59ef-400a-b769-c5402dce407b")),
                // Calcular la diferencia entre dos fechas
                GetHeroCardV3(
                    "Calcular la diferencia entre dos fechas",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-ES/article/Calcular-la-diferencia-entre-dos-fechas-8235e7c9-b430-44ca-9425-46100a162f38")),
                // Inmovilizar paneles para bloquear filas y columnas
                GetHeroCardV3(
                    "Inmovilizar paneles para bloquear filas y columnas",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-ES/article/Inmovilizar-paneles-para-bloquear-filas-y-columnas-dab2ffc9-020d-4026-8121-67dd25f2508f")),
                // Funciones de Excel (por orden alfabético)
                GetHeroCardV3(
                    "Funciones de Excel (por orden alfabético)",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Funciones-de-Excel-por-orden-alfab%C3%A9tico-b3944572-255d-4efb-bb96-c6d90033e188?ui=es-ES&rs=es-ES&ad=ES")),
                // Cómo evitar la ruptura de las fórmulas
                GetHeroCardV3(
                    "Cómo evitar la ruptura de las fórmulas",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-ES/article/C%C3%B3mo-evitar-la-ruptura-de-las-f%C3%B3rmulas-8309381d-33e8-42f6-b889-84ef6df1d586")),
                // Soporte de accesibilidad para Excel
                GetHeroCardV3(
                    "Soporte de accesibilidad para Excel",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-ES/article/Soporte-de-accesibilidad-para-Excel-0976b140-7033-4e2d-8887-187280701bf8")),
            };
        }

        // Temas destacados de PowerPoint
        public static IList<Attachment> GetDestacadosPowerPoint()
        {
            return new List<Attachment>()
            {
                // Novedades en Outlook 2016 para Windows
                GetHeroCardV3(
                    "Novedades en Outlook 2016 para Windows",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-ES/article/Novedades-en-Outlook-2016-para-Windows-51c81e7a-de25-4a34-a7fe-bd79f8e48647")),
                // Agregar imágenes prediseñadas a un archivo
                 GetHeroCardV3(
                    "Agregar imágenes prediseñadas a un archivo",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Agregar-im%C3%A1genes-predise%C3%B1adas-a-un-archivo-0a01ae25-973c-4c2c-8eaf-8c8e1f9ab530?wt.mc_id=ppt_home&ui=es-ES&rs=es-ES&ad=ES")),
                // Convertir una presentación en un vídeo
                GetHeroCardV3(
                    "Convertir una presentación en un vídeo",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Convertir-una-presentaci%C3%B3n-en-un-v%C3%ADdeo-c140551f-cb37-4818-b5d4-3e30815c3e83?wt.mc_id=ppt_home&ui=es-ES&rs=es-ES&ad=ES")),
                // Agregar una marca de agua "BORRADOR" al fondo de las diapositivas
                GetHeroCardV3(
                    "Agregar una marca de agua 'BORRADOR' al fondo de las diapositivas",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Agregar-una-marca-de-agua-BORRADOR-al-fondo-de-las-diapositivas-ea4cc5f5-ea5d-4213-9c7d-ed01a7952ed0?wt.mc_id=ppt_home&ui=es-ES&rs=es-ES&ad=ES")),
                // Importar contactos a Outlook
                GetHeroCardV3(
                    "Importar contactos a Outlook",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-ES/article/Importar-contactos-a-Outlook-bb796340-b58a-46c1-90c7-b549b8f3c5f8")),
                // Reproducir música durante toda la presentación con diapositivas
                GetHeroCardV3(
                    "Reproducir música durante toda la presentación con diapositivas",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Reproducir-m%C3%BAsica-durante-toda-la-presentaci%C3%B3n-con-diapositivas-b01ded6a-28c8-473a-971a-6dfa92cc9367?wt.mc_id=ppt_home&ui=es-ES&rs=es-ES&ad=ES")),
                // ¿Qué es un patrón de diapositivas?
                GetHeroCardV3(
                    "¿Qué es un patrón de diapositivas?",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-ES/article/%C2%BFQu%C3%A9-es-un-patr%C3%B3n-de-diapositivas-b9abb2a0-7aef-4257-a14e-4329c904da54?wt.mc_id=ppt_home")),
                // Soporte de accesibilidad para PowerPoint
                GetHeroCardV3(
                    "Soporte de accesibilidad para PowerPoint",
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
                GetHeroCardV3(
                    "Novedades de OneNote para Windows 10",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Novedades-de-OneNote-para-Windows-10-1477d5de-f4fd-4943-b18a-ff17091161ea?ui=es-ES&rs=es-ES&ad=ES")),
                // Introducción al nuevo OneNote
                 GetHeroCardV3(
                    "Introducción al nuevo OneNote",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-ES/article/Introducci%C3%B3n-al-nuevo-OneNote-ab84fcc2-f845-41ac-9c29-89b0720c8eb3")),
                // Tareas básicas en OneNote para Windows 10
                GetHeroCardV3(
                    "Tareas básicas en OneNote para Windows 10",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Tareas-básicas-en-OneNote-para-Windows-10-081573f8-2e8f-45e5-bf16-0900d4d3331f?ui=es-ES&rs=es-ES&ad=ES")),
                // Enviar fotos e imágenes de otras aplicaciones a OneNote
                GetHeroCardV3(
                    "Enviar fotos e imágenes de otras aplicaciones a OneNote",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Enviar-fotos-e-im%C3%A1genes-de-otras-aplicaciones-a-OneNote-para-Windows-10-02e66db1-eb04-4297-a41b-b82648aa843d?ui=es-ES&rs=es-ES&ad=ES")),
                // Sincronizar blocs de notas en OneNote 
                GetHeroCardV3(
                    "Sincronizar blocs de notas en OneNote ",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Sincronizar-blocs-de-notas-en-OneNote-para-Windows-10-21cb4629-3ef4-4220-8539-d01d29491e6a?ui=es-ES&rs=es-ES&ad=ES")),
                // Compartir una página de notas o un bloc de notas completo
                GetHeroCardV3(
                    "Compartir una página de notas o un bloc de notas completo",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Compartir-una-p%C3%A1gina-de-notas-o-un-bloc-de-notas-completo-desde-OneNote-para-Windows-10-d4a74a14-44a3-411e-8fb5-06e73ddf047f?ui=es-ES&rs=es-ES&ad=ES")),
                // Proteger las notas con contraseña en OneNote para Windows 10
                GetHeroCardV3(
                    "Proteger las notas con contraseña en OneNote para Windows 10",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Proteger-las-notas-con-contrase%C3%B1a-en-OneNote-para-Windows-10-a2fd9183-c864-4653-9c4e-714a116a4ab7?ui=es-ES&rs=es-ES&ad=ES")),
                // Solucionar problemas en OneNote para Windows 10
                GetHeroCardV3(
                    "Solucionar problemas en OneNote para Windows 10",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Solucionar-problemas-en-OneNote-para-Windows-10-942b006c-46ac-4300-a629-7fac5ae4dc70?ui=es-ES&rs=es-ES&ad=ES")),
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