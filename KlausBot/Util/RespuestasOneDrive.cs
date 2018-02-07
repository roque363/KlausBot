using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using Microsoft.Bot.Connector;

namespace KlausBot.Util
{
    public class RespuestasOneDrive
    {
        // ----------------------------------------------------------------------- 
        // PREGUNTAS DE ONE DRIVE                                               
        // ----------------------------------------------------------------------- 
        // ----------- DEFINICION -----------
        // ----------------------------------------
        // Descripcion de One Drive
        public static IList<Attachment> GetOneDriveDefinicion()
        {
            return new List<Attachment>()
            {
                GetHeroCard(
                    "¿Qué es One Drive?",
                    "",
                    "OneDrive (antes SkyDrive, Microsoft SkyDrive, Windows Live SkyDrive y Windows Live Folders) es un servicio de alojamiento " +
                    "de archivos. Fue estrenado el 18 de febrero de 2014. Actualmente, este servicio ofrece 5 GB de almacenamiento gratuito, más " +
                    "15 GB para el álbum de cámara, los cuales se les ha retirado a muchos usuarios, que habían adquirido ese derecho por la compra de algún smartphone Lumia.",
                    new CardImage(url: "http://blogswin.blob.core.windows.net/win/sites/9/2014/01/OneDrive-Logo.png")),
                GetVideoCard(
                    "Office 365 - One Drive",
                    "Video sobre One Drive",
                    "https://videocontent.osi.office.net/06986140-d923-4649-9fb1-0a5860f892bd/3ac7679f-8354-4cf8-874a-b0af053c0de4_1280x720_3400.mp4",
                    "https://support.office.com/es-es/article/v%C3%ADdeo-%C2%BFqu%C3%A9-es-onenote-be6cc6cc-3ca7-4f46-8876-5000f013c563?ui=es-ES&rs=es-ES&ad=ES"),
            };
        }

        // Definicion de archivo de petición
        public static IList<Attachment> GetDefinicionArchivoPeticion()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Obtenga más información sobre OneDrive archivos a petición",
                    "Se aplica a: Office para empresas OneDrive para la Empresa OneDrive",
                    "Archivos a petición le ayuda a obtener acceso a todos los archivos en OneDrive sin tener que descargar todos ellos y usar el espacio de almacenamiento en el dispositivo.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/obtenga-m%C3%A1s-informaci%C3%B3n-sobre-onedrive-archivos-a-petici%C3%B3n-0e6860d3-d9f3-4971-b321-7092438fb38e?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        //Planes de almacenamiento de OneDrive por país o región
        public static IList<Attachment> GetPlanesAlmacenamientoPaisOneDrive()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Planes de almacenamiento de OneDrive por país o región",
                    "Se aplica a: Office.com OneDrive",
                    "La información de los planes se encontrarán dentro del link, ten en cuenta que si ya tienes una suscripción a OneDrive, no podrás ver los precios en otros países o regiones.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Planes-de-almacenamiento-de-OneDrive-por-pa%C3%ADs-o-regi%C3%B3n-e00ef3b3-a37b-4d0a-9995-a0bbdd74c0ef")),
            };
        }

        //Formatos de vídeo que se pueden reproducir en el sitio web de OneDrive
        public static IList<Attachment> GetFormatoVideoPermitidosOneDrive()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Formatos de vídeo que se pueden reproducir en el sitio web de OneDrive",
                    "Se aplica a: OneDrive",
                    "Puede reproducir archivos de audio y vídeo mayoría, incluidos mp4, archivos de película de Apple y QuickTime directamente desde el sitio Web de OneDrive.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Formatos-de-v%C3%ADdeo-que-se-pueden-reproducir-en-el-sitio-web-de-OneDrive-07c008b2-70e4-4ced-8a9b-f25bed77196a")),
            };
        }

        //Requisitos del sistema de OneDrive
        public static IList<Attachment> GetRequisitosSistemaOneDrive()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Requisitos del sistema de OneDrive",
                    "Se aplica a: OneDrive",
                    "La aplicación de escritorio de sincronización de OneDrive requiere lo siguiente: Sistema operativo(versión de 32 bits o de 64 bits de Windows 10, Windows 8/8.1 o Windows 7),"+
                    " procesador(1,6 GHz o superior), memoria(1 GB de RAM o más), resolución(1024 x 576 como mínimo), conexión a internet(se recomienda disponer de acceso a Internet de alta velocidad),"+
                    " sistemas de archivos(NTFS o HFS + (no distingue mayúsculas de minúsculas)).",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/requisitos-del-sistema-de-onedrive-cc0cb2b8-f446-445c-9b52-d3c2627d681e?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        //----------- CARGAR -----------
        //------------------------------------

        // Cargar archivos en One Drive
        public static IList<Attachment> GetCargarArchivosOneDrive()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Cómo cargar archivos en One Drive",
                    "Se aplica a: OneDrive",
                    "Puede agregar archivos a OneDrive de muchas maneras diferentes y luego tenerlos disponibles desde cualquier lugar.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/v%C3%ADdeo-cargar-archivos-y-carpetas-en-onedrive-para-la-empresa-5bd927ad-d186-495c-93e8-7ca116fe7b83?ui=es-ES&rs=es-ES&ad=ES")),

            };
        }

        //------ COPIAR ----------
        //--------------------------------
        // Copiar archivos y carpetas entre OneDrive para la Empresa y sitios de SharePoint
        public static IList<Attachment> GetCopiarArchivosCarpetasOneDriveSharePoint()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                "Copiar archivos o carpetas entre OneDrive y SharePoint",
                "Se aplica a: SharePoint Online OneDrive para la Empresa Centro de administración de SharePoint Online SharePoint Online Small Business",
                "Cuando desee compartir archivos con algún equipo de diferente procedencia, o incluso dar a otros equipos la propiedad, puede copiar archivos entre OneDrive for Business "+
                "y un sitio de SharePoint. Puede copiar archivos y carpetas de OneDrive a SharePoint, de SharePoint a OneDrive, dentro de un sitio SharePoint o entre sitios. Incluso puede"+
                " copiar archivos de la unidad OneDrive de otra persona a su propia unidad OneDrive.",
                new CardAction(ActionTypes.OpenUrl, "Ver información",
                value: "https://support.office.com/es-es/article/Copiar-archivos-y-carpetas-entre-OneDrive-para-la-Empresa-y-sitios-de-SharePoint-67a6323e-7fd4-4254-99a8-35613492a82f")),
            };
        }

        //----------- CREAR -----------
        //-----------------------------------

        // Crear archivos y carpetas en One Drive
        public static IList<Attachment> GetCrearArchivosCarpetasOneDrive()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Crear archivos y carpetas en One Drive",
                    "Se aplica a: OneDrive",
                    "Al crear archivos y carpetas en OneDrive, podrá obtener acceso a ellos desde cualquier lugar.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/v%C3%ADdeo-crear-archivos-y-carpetas-en-onedrive-profesional-o-educativo-e1f59717-2f02-494d-93c6-8ef9613e82ba#ID0EAABAAA=Transcripci%C3%B3n")),
                GetVideoCard(
                    "Office 365 - One Drive",
                    "Video sobre One Drive",
                    "https://videocontent.osi.office.net/9d21dd5f-3dd6-46d2-a10c-bb2b06053a56/ef4f6aa7-1bf9-4139-84eb-c6384f553da0_1280x720_3400.mp4",
                    "https://support.office.com/es-es/article/v%C3%ADdeo-crear-archivos-y-carpetas-en-onedrive-profesional-o-educativo-e1f59717-2f02-494d-93c6-8ef9613e82ba"),
            };
        }

        // Crear archivos y carpetas en One Drive o crear carpetas de busqueda en Outlook
        public static IList<Attachment> GetCrearArchivosCarpetasOneDriveCarpetasBusquedaOutlook()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Crear archivos y carpetas en One Drive",
                    "Se aplica a: OneDrive",
                    "Al crear archivos y carpetas en OneDrive, podrá obtener acceso a ellos desde cualquier lugar.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/v%C3%ADdeo-crear-archivos-y-carpetas-en-onedrive-profesional-o-educativo-e1f59717-2f02-494d-93c6-8ef9613e82ba#ID0EAABAAA=Transcripci%C3%B3n")),
                GetHeroCardV2(
                    "Usar carpetas de búsqueda para buscar mensajes u otros elementos de Outlook",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010",
                    "Una carpeta de búsqueda es una carpeta virtual que proporciona una vista de todos los elementos de correo electrónico " +
                    "que coinciden con criterios de búsqueda específicos.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Usar-carpetas-de-b%C3%BAsqueda-para-buscar-mensajes-u-otros-elementos-de-Outlook-c1807038-01e4-475e-8869-0ccab0a56dc5?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Crear documento desde One drive
        public static IList<Attachment> GetCrearDocumentoDesdeOneDrive()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Crear un documento desde OneDrive para la Empresa",
                    "Se aplica a: SharePoint Online Office para empresas Administración de Office 365, ...",
                    "Puede crear nuevos documentos de Office directamente desde OneDrive para la Empresa. Necesitará Office Web Apps Server para ver el menú Nuevo.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Crear-un-documento-desde-OneDrive-para-la-Empresa-4c54ddbf-e112-4165-b855-049e7dfec340")),
            };
        }

        // Crear cuenta en One Drive
        public static IList<Attachment> GetCrearCuentaOneDrive()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Crear una cuenta",
                    "Se aplica a: One Drive.",
                    "Puede iniciar sesión si tiene una cuenta de Microsoft para Xbox, Skype o Outlook.com.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/v%C3%ADdeo-iniciar-sesi%C3%B3n-o-crear-una-cuenta-de-onedrive-6c63b4e3-c92f-4f52-80e2-237c798cec1e#ID0EAABAAA=Transcripci%C3%B3n")),
            };
        }

        //--------GUARDAR----------
        //-----------------------------------

        // Guardar archivos en One Drive
        public static IList<Attachment> GetGuardarDocumentoOneDrive()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Guardar un documento en su OneDrive desde Office 2010",
                    "Se aplica a: Excel 2010 Word 2010 PowerPoint 2010 OneNote 2010",
                    "Al guardar un documento en OneDrive, el documento se almacena en una ubicación central a la que puede tener acceso desde prácticamente cualquier lugar.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/guardar-un-documento-en-su-onedrive-desde-office-2010-b9e0c0a9-2bd7-42cf-9178-24d60c51ac75")),
            };
        }

        // Guardar fotos y videos en One Drive
        public static IList<Attachment> GetGuardarFotosVideosOneDrive()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Guardar fotos y vídeos automáticamente en OneDrive",
                    "Se aplica a: Office.com OneDrive",
                    "Si tienes OneDrive en tu equipo y conectas un teléfono, cámara u otro dispositivo, te puede aparecer una pregunta sobre si quieres agregar las fotos y vídeos de ese dispositivo a OneDrive.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Guardar-fotos-y-v%C3%ADdeos-autom%C3%A1ticamente-en-OneDrive-42a0202d-c944-4ebc-bb17-32d0082226f8")),
            };
        }

        // Guardar automáticamente capturas de pantalla en OneDrive
        public static IList<Attachment> GetGuardarCapturasPantallaOneDrive()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Guardar automáticamente capturas de pantalla en OneDrive",
                    "Se aplica a: OneDrive",
                    "Si tienes OneDrive en tu equipo y realizas una captura de pantalla, tal vez se te pregunte si quieres guardar automáticamente tus capturas de pantalla en OneDrive. ",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/guardar-autom%C3%A1ticamente-capturas-de-pantalla-en-onedrive-d04df71c-1cb0-4ad6-9f9c-b08494d79d6a?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        //----- ENCONTRAR ------
        //--------------------------------
        //Encontrar archivos perdidos o que faltan en OneDrive
        public static IList<Attachment> GetEncontrarArchivosPerdidosFaltanOneDrive()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                "Encontrar archivos perdidos o que faltan en OneDrive",
                "Se aplica a: Office.com OneDrive",
                "Puedes buscar archivos, fotos e incluso texto dentro de archivos y fotos. Selecciona Buscar en la barra superior y escribe la frase que quieras en el cuadro de búsqueda. Funciona también en la aplicación móvil de OneDrive. ",
                new CardAction(ActionTypes.OpenUrl, "Ver información",
                value: "https://support.office.com/es-es/article/Encontrar-archivos-perdidos-o-que-faltan-en-OneDrive-0d929e0d-8682-4295-982b-4bd75a3daa01")),
            };
        }

        //-------- COMPARTIR --------
        //-----------------------------------

        //Compartir carpetas en One Drive y compartir carpeta de contactos en Outlook
        public static IList<Attachment> GetCompartirCarpetasOneDriveCarpetaContactosOutlook()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Compartir archivos y carpetas en One Drive",
                    "Se aplica a: OneDrive",
                    "Con OneDrive, puede compartir sus fotos y archivos personales con otros usuarios, controlar si pueden verlos o editarlos e incluso trabajar en colaboración en documentos al mismo tiempo.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/v%C3%ADdeo-compartir-archivos-y-carpetas-en-onedrive-3fcefa26-1371-401e-8c04-589de81ed5eb")),
                GetHeroCardV2(
                    "Compartir una carpeta de contactos con otros usuarios",
                    "Se aplica a: Outlook 2016 Outlook 2013 Office para empresas Office 365 Pequeña Empresa Outlook 2010 Outlook 2007",
                    "Puede compartir cualquiera de las carpetas de contactos de cuenta de Exchange Server con otra persona que también está usando una cuenta de Exchange Server en su organización.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Compartir-una-carpeta-de-contactos-con-otros-usuarios-ce5a40d1-bc9f-4f5d-a2aa-5ec388573821")),
            };
        }

        // Compartir archivos o carpetas en One Drive
        public static IList<Attachment> GetCompartirArchivosCarpetasOneDrive()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2("Compartir archivos y carpetas en One Drive",
                "Se aplica a: OneDrive",
                "Con OneDrive, puede compartir sus fotos y archivos personales con otros usuarios, controlar si pueden verlos o editarlos e incluso trabajar en colaboración en documentos al mismo tiempo.",
                new CardAction(ActionTypes.OpenUrl, "Ver más información",
                value: "https://support.office.com/es-es/article/v%C3%ADdeo-compartir-archivos-y-carpetas-en-onedrive-3fcefa26-1371-401e-8c04-589de81ed5eb")),
            };
        }

        // Compartir archivos One Drive para Android
        public static IList<Attachment> GetCompartirArchivosOneDriveAndroid()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2("Compartir archivos en OneDrive para Android",
                "Se aplica a: OneDrive para la Empresa OneDrive",
                "Puede compartir fotos, OneDrive archivos y carpetas de la aplicación OneDrive en su dispositivo Android igual que en un PC o Mac.",
                new CardAction(ActionTypes.OpenUrl, "Ver más información",
                value: "https://support.office.com/es-es/article/Compartir-archivos-en-OneDrive-para-Android-69147161-d132-4170-ad63-7d241fa8e6dc")),
            };
        }

        //-------- AGREGAR ----------
        //-----------------------------------

        // Agregar carpetas compartidas a OneDrive y sincronizarlas
        public static IList<Attachment> GetAgregarCarpetasCompartidasOneDrive()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2("Agregar carpetas compartidas a OneDrive y sincronizarlas",
                "Se aplica a: Office.com OneDrive",
                "Cuando alguien comparta una carpeta y te proporcione permisos de edición, agrega la carpeta compartida a tu propio OneDrive para que te resulte más fácil editar y trabajar con ella y su contenido.",
                new CardAction(ActionTypes.OpenUrl, "Ver más información",
                value: "https://support.office.com/es-es/article/Agregar-carpetas-compartidas-a-OneDrive-y-sincronizarlas-8a63cd47-1526-4cd8-bd09-ee3f9bfc1504")),
            };
        }

        // Agregar cuenta de OneDrive para la empresa en Android
        public static IList<Attachment> GetAgregarCuentaOneDriveAndroid()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2("Agregar cuenta de OneDrive para la empresa en Android",
                "Se aplica a: OneDrive para la Empresa OneDrive",
                "Usar la aplicación OneDrive en su dispositivo Android para trabajar con su cuenta personal OneDrive, así como las cuentas de OneDrive para la empresa.",
                new CardAction(ActionTypes.OpenUrl, "Ver más información",
                value: "https://support.office.com/es-es/article/Agregar-OneDrive-para-la-Empresa-en-Android-babc9692-fb53-40b4-8b24-6b83ff95455e")),
            };
        }

        // Insertar archivos directamente en tu sitio web o blog
        public static IList<Attachment> GetInsertarArchivosSitioWebBlog()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                "Insertar archivos directamente en tu sitio web o blog",
                "Se aplica a: Office.com OneDrive",
                "Si tiene un sitio web o un blog, es muy fácil y rápido incluir fotos, vídeos, documentos de Office y otros archivos desde OneDrive. "+
                "Incluso puedes personalizar el modo en que los libros de Excel insertados se muestran a otras personas.",
                new CardAction(ActionTypes.OpenUrl, "Ver más información",
                value: "https://support.office.com/es-es/article/insertar-archivos-directamente-en-tu-sitio-web-o-blog-ed07dd52-8bdb-431d-96a5-cbe8a80b7418?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        //-------- ABRIR ----------
        //---------------------------------

        // Abrir archivos en su dispositivo móvil
        public static IList<Attachment> GetAbrirArchivosDispositivoMovilOneDrive()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                "Abrir archivos en su dispositivo móvil",
                "Se aplica a: OneDrive para la Empresa OneDrive",
                "Primero: pulse el archivo para obtener una vista previa. Segundo: Pulse el icono de la aplicación de Office en la parte superior para abrir el archivo.",
                new CardAction(ActionTypes.OpenUrl, "Ver más información",
                value: "https://support.office.com/es-es/article/inicio-r%C3%A1pido-de-onedrive-a5710114-6aeb-4bf5-a336-dffa7cc0b77a?ui=es-ES&rs=es-ES&ad=ES#ID0EAABAAA=Seguir_conectado")),
            };
        }

        //----- SINCRONIZAR ------
        //--------------------------------
        //Sincronizar la carpeta de documentos con OneDrive
        public static IList<Attachment> GetSincronizarCarpetaDocumentosOneDrive()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                "Sincronizar la carpeta de documentos con OneDrive",
                "Se aplica a: OneDrive para la Empresa OneDrive",
                "¿Desea sincronizar automáticamente la carpeta de documentos con OneDrive o OneDrive para la Empresa ? Siga este procedimiento.",
                new CardAction(ActionTypes.OpenUrl, "Ver información",
                value: "https://support.office.com/es-es/article/Sincronizar-la-carpeta-de-documentos-con-OneDrive-0f4ddfd3-4a72-4013-9d94-181dab6be19a")),
            };
        }

        //------- MOVER ----------
        //--------------------------------
        //Ordenar, cambiar el nombre o mover fotos y archivos en OneDrive
        public static IList<Attachment> GetCambiarNombreMoverFotosArhivosOneDrive()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                "Ordenar, cambiar el nombre o mover fotos y archivos en OneDrive",
                "Se aplica a: Office.com OneDrive",
                "Después de cargar fotos y archivos en OneDrive, puedes reorganizarlos, cambiarles el nombre y moverlos al sitio web de OneDrive para tenerlos organizados. Es posible que tengas que iniciar sesión con tu cuenta Microsoft.",
                new CardAction(ActionTypes.OpenUrl, "Ver información",
                value: "https://support.office.com/es-es/article/ordenar-cambiar-el-nombre-o-mover-fotos-y-archivos-en-onedrive-01628e6d-9d2c-4298-a1f0-933e5b20a8bf?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        //------TRABAJAR-ONE DRIVE--------
        //--------------------------------
        //Trabajar de manera conjunta en documentos de Office en OneDrive
        public static IList<Attachment> GetTrabajarManeraConjuntaOfficeOneDrive()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                "Trabajar de manera conjunta en documentos de Office en One Drive",
                "Se aplica a: Excel Online Word Online PowerPoint Online OneNote Online Office.com",
                "Con Office Online es fácil trabajar con otras personas porque puede enviar vínculos a documentos en lugar de enviar datos adjuntos. De este modo, ahorrará almacenamiento "+
                "de correo electrónico y evitará tener que conciliar varias versiones del mismo documento.",
                new CardAction(ActionTypes.OpenUrl, "Ver información",
                value: "https://support.office.com/es-es/article/trabajar-de-manera-conjunta-en-documentos-de-office-en-onedrive-ea3807bc-2b73-406f-a8c9-a493de18258b")),
            };
        }

        //----- ESTABLECER --------
        //---------------------------------

        // Establecer la ubicación de almacenamiento de los archivos
        public static IList<Attachment> GetEstablecerUbicacionAlmacenamientoArchivosOneDrive()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                "Establecer la ubicación de almacenamiento de los archivos",
                "Se aplica a: One Drive",
                "Use la configuración de la aplicación OneDrive para cambiar la ubicación de almacenamiento de los archivos predeterminada.",
                new CardAction(ActionTypes.OpenUrl, "Ver más información",
                value: "https://support.office.com/es-es/article/los-archivos-se-guardan-en-onedrive-de-manera-predeterminada-en-windows-10-33da0077-770c-4bda-b61e-8c8e8ca70ac7?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        //--------- BUSCAR --------
        //---------------------------------

        // Buscar y mover los archivos
        public static IList<Attachment> GetBuscarOMoverArchivosOneDrive()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                "Buscar y mover los archivos",
                "Se aplica a: One Drive",
                "Las carpetas Documentos e Imágenes están disponibles tanto en Este equipo como en OneDrive, por lo que es posible que haya confusiones."+
                " Si ha guardado por error un archivo (por ejemplo, en la carpeta Documentos de su PC en lugar de la de OneDrive), use el Explorador de "+
                "archivos o la aplicación OneDrive para arrastrar los archivos donde desee.",
                new CardAction(ActionTypes.OpenUrl, "Ver más información",
                value: "https://support.office.com/es-es/article/los-archivos-se-guardan-en-onedrive-de-manera-predeterminada-en-windows-10-33da0077-770c-4bda-b61e-8c8e8ca70ac7?ui=es-ES&rs=es-ES&ad=ES")),

            };
        }

        // Buscar archivos en OneDrive o buscar archivos de datos de Outlook
        public static IList<Attachment> GetBuscarArchivosOneDriveBuscarArchivosDatosOutlook()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                "Buscar y mover los archivos",
                "Se aplica a: One Drive",
                "Las carpetas Documentos e Imágenes están disponibles tanto en Este equipo como en OneDrive, por lo que es posible que haya confusiones."+
                " Si ha guardado por error un archivo (por ejemplo, en la carpeta Documentos de su PC en lugar de la de OneDrive), use el Explorador de "+
                "archivos o la aplicación OneDrive para arrastrar los archivos donde desee.",
                new CardAction(ActionTypes.OpenUrl, "Ver más información",
                value: "https://support.office.com/es-es/article/los-archivos-se-guardan-en-onedrive-de-manera-predeterminada-en-windows-10-33da0077-770c-4bda-b61e-8c8e8ca70ac7?ui=es-ES&rs=es-ES&ad=ES")),
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

        // Buscar archivos de SharePoint en One Drive

        public static IList<Attachment> GetBuscarArchivosSharePointOneDrive()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                "Buscar archivos de SharePoint en OneDrive",
                "Se aplica a: OneDrive para la Empresa",
                "Si usa OneDrive en la web, puede obtener acceso a sus archivos de SharePoint sin salir de OneDrive. "+
                "Los sitios de SharePoint que siga o con los que interactuó recientemente aparecerán en una lista "+
                "debajo del nombre de la organización.",
                new CardAction(ActionTypes.OpenUrl, "Ver más información",
                value: "https://support.office.com/es-es/article/Buscar-archivos-de-SharePoint-en-OneDrive-9275de7b-0b0b-40ee-8fa2-b17d1b0727d0")),

            };
        }
        // Buscar y trabajar con archivos de OneDrive en iOS
        public static IList<Attachment> GetBuscarTrabajarArchivosOneDriveIos()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                "Buscar y trabajar con archivos de OneDrive en iOS",
                "Se aplica a: OneDrive",
                "Use la aplicación OneDrive para guardar, mover, cargar o descargar archivos y fotos.",
                new CardAction(ActionTypes.OpenUrl, "Ver más información",
                value: "https://support.office.com/es-es/article/Buscar-y-trabajar-con-archivos-de-OneDrive-en-iOS-fddb9917-2379-45ba-85e3-9e4ec46821dc")),

            };
        }

        // Buscar y trabajar con archivos de OneDrive en Android
        public static IList<Attachment> GetBuscarTrabajarArchivosOneDriveAndroid()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                "Buscar y trabajar con archivos de OneDrive en Android",
                "Se aplica a: OneDrive",
                "Use la aplicación OneDrive para Android para guardar, mover, cargar o descargar archivos.",
                new CardAction(ActionTypes.OpenUrl, "Ver más información",
                value: "https://support.office.com/es-es/article/Buscar-y-trabajar-con-archivos-de-OneDrive-en-Android-3ced081c-8ea8-40ab-b744-052dffe48590")),

            };
        }

        //Buscar y trabajar con archivos de OneDrive en Windows phone
        public static IList<Attachment> GetBuscarTrabajarArchivosOneDriveWindowsPhone()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                "Buscar y trabajar con archivos de OneDrive en Windows phone",
                "Se aplica a: OneDrive",
                "Cargar y trabajar con archivos en OneDrive en Windows phone, al igual que en el equipo. Cargar y guardar cualquier tipo de archivo, incluidos documentos, fotos, vídeos y archivos de música.",
                new CardAction(ActionTypes.OpenUrl, "Ver más información",
                value: "https://support.office.com/es-es/article/Buscar-y-trabajar-con-archivos-de-OneDrive-en-Windows-Phone-4d53b245-0a37-404d-bbe2-0b45df9b8cf8")),

            };
        }

        //------- ELIMINAR -------
        //--------------------------------
        //Eliminar archivos o carpetas en OneDrive
        public static IList<Attachment> GetEliminarArchivosCarpetasOneDrive()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                "Eliminar archivos o carpetas en OneDrive",
                "Se aplica a: OneDrive para la Empresa OneDrive OneDrive para la Empresa ofrecido por 21Vianet.",
                "Puede eliminar archivos específicos en OneDrive, o puede eliminar carpetas enteras y todos los archivos en ellos. Si necesita, es "+
                "posible que pueda para recuperar los archivos eliminados de la Papelera de reciclaje de OneDrive.",
                new CardAction(ActionTypes.OpenUrl, "Ver más información",
                value: "https://support.office.com/es-es/article/eliminar-archivos-o-carpetas-en-onedrive-21fe345a-e488-4fa7-932b-f053c1bebe8a?ui=es-ES&rs=es-ES&ad=ES")),

            };
        }

        //------- RECUPERAR --------
        //----------------------------------
        //Restaurar carpetas o archivos eliminados
        public static IList<Attachment> GetRestaurarArchivosEliminados()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                "Eliminar o restaurar archivos y carpetas en OneDrive",
                "Se aplica a: OneDrive para la Empresa Office.com OneDrive OneDrive para la Empresa ofrecido por 21Vianet.",
                "Puedes borrar o restaurar archivos concretos de OneDrive o carpetas enteras, junto con todos los archivos que contengan.",
                new CardAction(ActionTypes.OpenUrl, "Ver más información",
                value: "https://support.office.com/es-es/article/eliminar-o-restaurar-archivos-y-carpetas-en-onedrive-949ada80-0026-4db3-a953-c99083e6a84f?ui=es-ES&rs=es-ES&ad=ES")),
                GetVideoCard(
                    "Office 365 - One Drive",
                    "Video sobre One Drive",
                    "https://videocontent.osi.office.net/9ae26578-6412-455f-aa40-6d1a8df5b847/dc309662-8f74-49b3-b4cc-623d52105178_1280x720_3400.mp4",
                    "https://support.office.com/es-es/article/eliminar-o-restaurar-archivos-y-carpetas-en-onedrive-949ada80-0026-4db3-a953-c99083e6a84f?ui=es-ES&rs=es-ES&ad=ES"),

            };
        }

        //Restaurar una versión anterior de un archivo en OneDrive
        public static IList<Attachment> GetRestaurarVersionArchivoOneDrive()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                "Restaurar una versión anterior de un archivo en OneDrive",
                "Se aplica a: OneDrive para la Empresa SharePoint Server 2013 Enterprise SharePoint Server 2013 SharePoint Server 2016 OneDrive.",
                "Con el historial de la versión en línea, puede ver y restaurar versiones anteriores de todos los archivos en su OneDrive. "+
                "Historial de versiones funciona con todos los tipos de archivo, incluidos archivos PDF, archivos de CAD, fotos y vídeos.",
                new CardAction(ActionTypes.OpenUrl, "Ver más información",
                value: "https://support.office.com/es-es/article/restaurar-una-versi%C3%B3n-anterior-de-un-archivo-en-onedrive-159cad6d-d76e-4981-88ef-de6e96c93893?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        //Recuperar archivos de tu equipo
        public static IList<Attachment> GetRecuperarArchivosEquipo()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                "Recuperar archivos de tu equipo",
                "Se aplica a: Office.com OneDrive",
                "Si tienes instalada la aplicación de escritorio OneDrive para Windows en un equipo, puedes usar la característica Capturar"+
                " archivos para acceder a todos los archivos y carpetas de ese equipo a través del sitio web de OneDrive.",
                new CardAction(ActionTypes.OpenUrl, "Ver más información",
                value: "https://support.office.com/es-es/article/recuperar-archivos-de-tu-equipo-70761550-519c-4d45-b780-5a613b2f8822?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        //------- ORGANIZAR --------
        //----------------------------------
        //Organizar y buscar fotos en OneDrive
        public static IList<Attachment> GetOrganizarBuscarFotosOneDrive()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                "Organizar y buscar fotos en OneDrive",
                "Se aplica a: OneDrive",
                "Después de cargar fotos, OneDrive le ayuda a organizar y buscar sus fotos con características como búsqueda "+
                "de fotografías, etiquetas y álbumes.",
                new CardAction(ActionTypes.OpenUrl, "Ver más información",
                value: "https://support.office.com/es-es/article/Organizar-y-buscar-fotos-en-OneDrive-6a9b0298-f504-4992-af0e-45e2f270afc9")),
            };
        }

        //------- VER --------
        //----------------------------
        //Ver archivos compartidos con usted en OneDrive
        public static IList<Attachment> GetVerArchivosCompartidosOneDrive()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                "Ver archivos compartidos con usted en OneDrive",
                "Se aplica a: OneDrive para la Empresa OneDrive",
                "El compartido (OneDrive- Personal) o compartido conmigo (OneDrive- Business) vista muestra los archivos que otros usuarios "+
                "comparten con usted. Después de que alguien comparte un archivo con usted, dicho archivo aparecerán automáticamente en el compartido o compartido conmigo lista.",
                new CardAction(ActionTypes.OpenUrl, "Ver más información",
                value: "https://support.office.com/es-es/article/ver-archivos-compartidos-con-usted-en-onedrive-2c14e8e6-4e52-4c61-9778-7155d33534a1?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        //------- USAR --------
        //----------------------------
        //Usar OneDrive en iOS
        public static IList<Attachment> GetUsarOneDriveIos()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                "Usar OneDrive en iOS",
                "Se aplica a: Office para empresas OneDrive para la Empresa OneDrive",
                "A continuación se muestran los conceptos básicos sobre el uso de la aplicación OneDrive para iPhone, iPad y iPod Touch. Descarga la aplicación para iOS.",
                new CardAction(ActionTypes.OpenUrl, "Ver más información",
                value: "https://support.office.com/es-es/article/Usar-OneDrive-en-iOS-08d5c5b2-ccc6-40eb-a244-fe3597a3c247")),
            };
        }

        //Usar OneDrive para la empresa en iOS
        public static IList<Attachment> GetUsarOneDriveEmpresaIos()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                "Usar OneDrive para la empresa en iOS",
                "Se aplica a: OneDrive para la Empresa OneDrive",
                "Usar la aplicación OneDrive en el dispositivo de iPad, iPhone o iPod Touch para trabajar con sus cuentas de OneDrive para la empresa , así como su cuenta personal OneDrive.",
                new CardAction(ActionTypes.OpenUrl, "Ver más información",
                value: "https://support.office.com/es-es/article/Usar-OneDrive-para-la-Empresa-en-iOS-ed5af2c2-39a8-4684-a17c-fcde3742d4be")),
            };
        }

        //Usar One Drive en iOS y tambien para la empresa
        public static IList<Attachment> GetUsarOneDriveEmpresaOneDriveIos()
        {
            return new List<Attachment>()
            {
                 GetHeroCardV2(
                "Usar OneDrive en iOS",
                "Se aplica a: Office para empresas OneDrive para la Empresa OneDrive",
                "A continuación se muestran los conceptos básicos sobre el uso de la aplicación OneDrive para iPhone, iPad y iPod Touch. Descarga la aplicación para iOS.",
                new CardAction(ActionTypes.OpenUrl, "Ver más información",
                value: "https://support.office.com/es-es/article/Usar-OneDrive-en-iOS-08d5c5b2-ccc6-40eb-a244-fe3597a3c247")),

                GetHeroCardV2(
                "Usar OneDrive para la empresa en iOS",
                "Se aplica a: OneDrive para la Empresa OneDrive",
                "Usar la aplicación OneDrive en el dispositivo de iPad, iPhone o iPod Touch para trabajar con sus cuentas de OneDrive para la empresa , así como su cuenta personal OneDrive.",
                new CardAction(ActionTypes.OpenUrl, "Ver más información",
                value: "https://support.office.com/es-es/article/Usar-OneDrive-para-la-Empresa-en-iOS-ed5af2c2-39a8-4684-a17c-fcde3742d4be")),
            };
        }

        //Usar OneDrive para Android
        public static IList<Attachment> GetUsarOneDriveAndroid()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                "Usar OneDrive para Android",
                "Se aplica a: Office para empresas OneDrive para la Empresa OneDrive",
                "Después de que descargue la aplicación OneDrive, expanda las secciones siguientes para obtener información sobre cómo usarla.",
                new CardAction(ActionTypes.OpenUrl, "Ver más información",
                value: "https://support.office.com/es-es/article/Usar-OneDrive-para-Android-eee1d31c-792d-41d4-8132-f9621b39eb36")),
            };
        }

        //Usar OneDrive en Windows Phone
        public static IList<Attachment> GetUsarOneDriveWindowsPhone()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                "Usar OneDrive en Windows Phone",
                "Se aplica a: OneDrive para la Empresa OneDrive",
                "Los pasos y sugerencias para las tareas más comunes con la aplicación OneDrive para Windows Phone, se enceuntran dentro del link.",
                new CardAction(ActionTypes.OpenUrl, "Ver más información",
                value: "https://support.office.com/es-es/article/Usar-OneDrive-en-Windows-Phone-6d8496dd-7e1e-44fa-8dc8-b8cf6ef6a1a9")),
            };
        }

        //Usar OneDrive para la Empresa en Windows Phone 
        public static IList<Attachment> GetUsarOneDriveEmpresaWindowsPhone()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                "Usar OneDrive para la Empresa en Windows Phone",
                "Se aplica a: OneDrive para la Empresa OneDrive",
                "Acceso a sus cuentas de OneDrive para la Empresa en Windows phone con la misma App OneDrive con la aplicación para cargar, compartir"+
                " y trabajar con archivos en su cuenta de OneDrive para la Empresa es la misma que está trabajando con su cuenta personal.",
                new CardAction(ActionTypes.OpenUrl, "Ver más información",
                value: "https://support.office.com/es-es/article/usar-onedrive-para-la-empresa-en-windows-phone-6b0e1e05-2b8c-48fa-8820-7f25e2290fca?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        //Usar One Drive en Windows Phone y tambien para la empresa
        public static IList<Attachment> GetUsarOneDriveEmpresaOneDriveWindowsPhone()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                "Usar OneDrive en Windows Phone",
                "Se aplica a: OneDrive para la Empresa OneDrive",
                "Los pasos y sugerencias para las tareas más comunes con la aplicación OneDrive para Windows Phone, se enceuntran dentro del link.",
                new CardAction(ActionTypes.OpenUrl, "Ver más información",
                value: "https://support.office.com/es-es/article/Usar-OneDrive-en-Windows-Phone-6d8496dd-7e1e-44fa-8dc8-b8cf6ef6a1a9")),
                 GetHeroCardV2(
                "Usar OneDrive para la Empresa en Windows Phone",
                "Se aplica a: OneDrive para la Empresa OneDrive",
                "Acceso a sus cuentas de OneDrive para la Empresa en Windows phone con la misma App OneDrive con la aplicación para cargar, compartir"+
                " y trabajar con archivos en su cuenta de OneDrive para la Empresa es la misma que está trabajando con su cuenta personal.",
                new CardAction(ActionTypes.OpenUrl, "Ver más información",
                value: "https://support.office.com/es-es/article/usar-onedrive-para-la-empresa-en-windows-phone-6b0e1e05-2b8c-48fa-8820-7f25e2290fca?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Usar OneDrive en iOS
        // Usar OneDrive para Android
        // Usar OneDrive en Windows Phone
        public static IList<Attachment> GetUsarOneDrive()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                "Usar OneDrive en iOS",
                "Se aplica a: Office para empresas OneDrive para la Empresa OneDrive",
                "A continuación se muestran los conceptos básicos sobre el uso de la aplicación OneDrive para iPhone, iPad y iPod Touch. Descarga la aplicación para iOS.",
                new CardAction(ActionTypes.OpenUrl, "Ver más información",
                value: "https://support.office.com/es-es/article/Usar-OneDrive-en-iOS-08d5c5b2-ccc6-40eb-a244-fe3597a3c247")),
                GetHeroCardV2(
                "Usar OneDrive para Android",
                "Se aplica a: Office para empresas OneDrive para la Empresa OneDrive",
                "Después de que descargue la aplicación OneDrive, expanda las secciones siguientes para obtener información sobre cómo usarla.",
                new CardAction(ActionTypes.OpenUrl, "Ver más información",
                value: "https://support.office.com/es-es/article/Usar-OneDrive-para-Android-eee1d31c-792d-41d4-8132-f9621b39eb36")),
                GetHeroCardV2(
                "Usar OneDrive en Windows Phone",
                "Se aplica a: OneDrive para la Empresa OneDrive",
                "Los pasos y sugerencias para las tareas más comunes con la aplicación OneDrive para Windows Phone, se enceuntran dentro del link.",
                new CardAction(ActionTypes.OpenUrl, "Ver más información",
                value: "https://support.office.com/es-es/article/Usar-OneDrive-en-Windows-Phone-6d8496dd-7e1e-44fa-8dc8-b8cf6ef6a1a9")),
            };
        }

        //------- CAMBIAR --------
        //----------------------------
        //Detener o cambiar el uso compartido
        public static IList<Attachment> GetCambiarUsoCompartidoArchivoOneDrive()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                "Detener o cambiar el uso compartido",
                "Se aplica a: OneDrive",
                "Si es el propietario del archivo o tiene permisos de edición, puede detener o cambiar los permisos de uso compartido.",
                new CardAction(ActionTypes.OpenUrl, "Ver información",
                value: "https://support.office.com/es-es/article/inicio-r%C3%A1pido-de-onedrive-a5710114-6aeb-4bf5-a336-dffa7cc0b77a?ui=es-ES&rs=es-ES&ad=ES#ID0EAABAAA=Colaborar")),
            };
        }

        //------- DESACTIVAR --------
        //----------------------------
        //Detener o cambiar el uso compartido
        public static IList<Attachment> GetDesactivarDesinstalarOneDrive()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                "Desactivar o desinstalar OneDrive",
                "Se aplica a: SharePoint Online Office para empresas Administración de Office 365, ...",
                "Si no quiere usar OneDrive, la solución más sencilla es desvincularlo.",
                new CardAction(ActionTypes.OpenUrl, "Ver información",
                value: "https://support.office.com/es-es/article/Desactivar-o-desinstalar-OneDrive-f32a17ce-3336-40fe-9c38-6efb09f944b0")),
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