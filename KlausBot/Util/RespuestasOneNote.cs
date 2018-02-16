using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using Microsoft.Bot.Connector;

namespace KlausBot.Util
{
    public class RespuestasOneNote
    {
        //---------------------------------------------------------------
        // PREGUNTAS DE ONE NOTE
        //---------------------------------------------------------------
        // Tareas básicas en Microsoft OneNote 2013
        public static IList<Attachment> GetAgregarArchivosOneNote()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Tareas básicas en Microsoft OneNote 2013",
                    "Se aplica a: OneNote 2013",
                    "OneNote puede conservar toda la información acerca de un asunto o un proyecto en un único lugar, incluidas las copias de archivos y documentos relacionados.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/tareas-b%C3%A1sicas-en-microsoft-onenote-2013-da73c095-e082-4276-acf9-8728ca8b08ab")),
            };
        }

        // ----------- DEFINICION ------------
        // Definicon de OneNote
        public static IList<Attachment> GetOneNoteDefinicion()
        {
            return new List<Attachment>()
            {
                GetVideoCard(
                    "¿Qué es OneNote?",
                    "Video sobre OneNote",
                    "https://videocontent.osi.office.net/06986140-d923-4649-9fb1-0a5860f892bd/3ac7679f-8354-4cf8-874a-b0af053c0de4_1280x720_3400.mp4",
                    "https://support.office.com/es-es/article/v%C3%ADdeo-%C2%BFqu%C3%A9-es-onenote-be6cc6cc-3ca7-4f46-8876-5000f013c563?ui=es-ES&rs=es-ES&ad=ES"),
            };
        }

        //------------- ABRIR ---------------
        //-----------------------------------
        // Abrir un bloc de notas en OneNote para Windows 10
        public static IList<Attachment> GetAbrirBlocNotasOneNote()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Abrir un bloc de notas en OneNote",
                    "Se aplica a: OneNote para Windows 10",
                    "Cuando comience a usar OneNote para Windows 10, se abre el Bloc de notas de forma predeterminada " +
                    "de la cuenta que ha iniciado sesión.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/abrir-un-bloc-de-notas-en-onenote-para-windows-10-34f08dac-f7d5-4f0d-9f1c-5eb17a4c07c2?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Abrir blocs de notas que otras personas hayan compartido conmigo
        public static IList<Attachment> GetAbrirBlocNotasCompartidoOneNote()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Abrir blocs de notas que otras personas hayan compartido conmigo",
                    "Se aplica a: OneNote para iOS",
                    "1. Pulse **Más blocs de notas**.\r\r" +
                    "2. Busque el bloc de notas que se ha compartido con usted. Se marcará como 'Compartido por'",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Abrir-blocs-de-notas-que-otras-personas-hayan-compartido-conmigo-F5B5B7F4-E516-4D27-BC36-C8A64F31E347")),
            };
        }

        //------- AGREGAR / INSERTAR ---------
        //------------------------------------
        // Insertar contenido en OneNote
        public static IList<Attachment> GetInsertarContenidoOneNote()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Insertar contenido en OneNote",
                    "Se aplica a: OneNote 2016, OneNote 2016 para Mac, OneNote Online, OneNote para Windows 10",
                    "Puede incrustar una amplia variedad de contenido de otros orígenes en OneNote, como documentos, " +
                    "vídeos, clips de audio y más: insertar, pegar o vincular a él directamente en las notas.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/insertar-contenido-en-onenote-fd5abf7d-abd4-4902-8e5f-93088c45b11d?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Insertar contenido en OneNote
        public static IList<Attachment> GetInsertarArchivoOneNote()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Insertar un archivo en OneNote para Windows 10",
                    "Se aplica a: OneNote para Windows 10",
                    "Insertar un archivo en OneNote para Windows 10 facilita la mantener todas sus notas organizadas. " +
                    "Puede insertar un archivo como datos adjuntos para que pueda abrir una copia del archivo en OneNote.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/insertar-un-archivo-en-onenote-para-windows-10-5fc09a27-71b3-4e92-9eb6-3b0be9380374?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Agregar un vínculo en OneNote para Windows 10
        public static IList<Attachment> GetAgregarVinculoOneNote()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Agregar un vínculo en OneNote",
                    "Se aplica a: OneNote para Windows 10",
                    "Puede dar formato al texto en OneNote Preview para Windows 10 para convertirlo en un vínculo.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/agregar-un-v%C3%ADnculo-en-onenote-para-windows-10-64987380-d100-4751-97d0-bb2515fe095a?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Insertar una tabla en OneNote para Windows 10
        public static IList<Attachment> GetInsertarTablaOneNote()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Insertar una tabla en OneNote",
                    "Se aplica a: OneNote para Windows 10",
                    "Si desea organizar visualmente la información en las notas, puede insertar y dar formato " +
                    "a una tabla en OneNote para Windows 10.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/insertar-una-tabla-en-onenote-para-windows-10-35052542-ca8e-42fe-be3f-bc5c748a14b1?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Agregar una imagen a una página en OneNote para Windows 10
        public static IList<Attachment> GetInserImagenPaginaOneNote()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Agregar una imagen a una página en OneNote",
                    "Se aplica a: OneNote para Windows 10",
                    "Puede agregar una imagen en cualquier página de OneNote Preview para Windows 10.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/agregar-una-imagen-a-una-p%C3%A1gina-en-onenote-para-windows-10-bbdebae3-eb58-4923-b627-e4db3dace5ab?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Inserte vídeos en línea en OneNote para Windows 10
        public static IList<Attachment> GetInserteVideosLineaOneNote()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Inserte vídeos en línea en OneNote",
                    "Se aplica a: OneNote para Windows 10",
                    "Agregar vídeos a las notas es una excelente forma de crear los blocs de notas interactivas " +
                    "que puede compartir con o distribuir a otras personas.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/inserte-v%C3%ADdeos-en-l%C3%ADnea-en-onenote-para-windows-10-bea22b6e-04dc-4f3d-a04b-bdeb26f3f522?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Agregar contenido y notas a un grupo
        public static IList<Attachment> GetAgregaContenidoNotasGrupo()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Agregar contenido y notas a un grupo",
                    "Se aplica a: Microsoft Teams",
                    "Puede cargar archivos directamente a la ficha Archivos en cualquier canal. Solo tiene que hacer clic en " +
                    "**Archivos** en la parte superior y, a continuación, hacer clic en **Cargar**.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Agregar-contenido-y-notas-a-un-grupo-1edae27c-25c8-4c1e-9a6d-c06cfb3e4c44")),
            };
        }

        //------------- BUSCAR --------------
        //-----------------------------------
        // Buscar referencias del documento fácilmente dentro de OneNote para Windows 10
        public static IList<Attachment> GetBuscarReferenciasFacilmenteOneNote()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Buscar referencias del documento fácilmente dentro de OneNote",
                    "Se aplica a: OneNote para Windows 10",
                    "Investigador en OneNote le ayuda a encontrar temas e incorporar los orígenes de confianza y el contenido " +
                    "de un documento de investigación en unos cuantos pasos.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/buscar-referencias-del-documento-f%C3%A1cilmente-dentro-de-onenote-para-windows-10-62eed90e-f712-4b4a-8476-51ed0f1152d4?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Buscar notas en OneNote para Windows 10
        public static IList<Attachment> GetBuscarNotasOneNote()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Buscar notas en OneNote",
                    "Se aplica a: OneNote para Windows 10",
                    "OneNote puede buscar texto escrito, notas escritas a mano y palabras que aparecen en las imágenes insertadas.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/buscar-notas-en-onenote-para-windows-10-01f1da59-8b41-4dc7-b060-9a220ad2ec57?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        //------------- CREAR ---------------
        //-----------------------------------
        // Crear un nuevo bloc de notas en OneNote para Windows 10
        public static IList<Attachment> GetCrearBlocNotasOneNote()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Crear un nuevo bloc de notas en OneNote",
                    "Se aplica a: OneNote para Windows 10",
                    "A veces, resulta útil crear varios blocs de notas para distintas ocasiones, como trabajo, " +
                    "escuela o proyectos de inicio. " +
                    "Aquí le mostramos cómo crear blocs de notas en OneNote para Windows 10.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/crear-un-nuevo-bloc-de-notas-en-onenote-para-windows-10-dfd0f332-30d5-4333-98e0-f3619802d323?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Crear vínculos a blocs de notas, secciones, páginas y los párrafos de OneNote para Windows 10
        public static IList<Attachment> GetCrearVinculosOneNote()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Crear vínculos a blocs de notas, secciones, páginas y los párrafos",
                    "Se aplica a: OneNote para Windows 10",
                    "Es fácil crear y compartir vínculos a partes específicas de las notas, ya sea para el Bloc de notas " +
                    "completo, determinadas secciones o páginas o incluso a un párrafo específico en una página.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/crear-v%C3%ADnculos-a-blocs-de-notas-secciones-p%C3%A1ginas-y-los-p%C3%A1rrafos-de-onenote-para-windows-10-48dd0e82-623c-405d-b63a-df4eaf55c72a?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        //------------ CAMBIAR --------------
        //-----------------------------------
        // Cambiar el color de fondo de una página en OneNote para Windows 10
        public static IList<Attachment> GetCambiarcolorfondopaginaOneNote()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Cambiar el color de fondo de una página en OneNote",
                    "Se aplica a: OneNote para Windows 10",
                    "Para elegir un nuevo color para el fondo de la página actual, haga lo siguiente:\n" +
                    ">1. Abra la página cuyo color de fondo que desee cambiar.\n" +
                    ">2. En la ficha vista, haga clic o puntee en Color de página.\n" +
                    ">3. Haga clic o puntee en el color que desee.\n",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/cambiar-el-color-de-fondo-de-una-p%C3%A1gina-en-onenote-para-windows-10-c9265c78-a9b4-4cce-9ee3-46a2bb9e50f6?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Cambiar entre blocs de notas en OneNote para Windows 10
        public static IList<Attachment> GetCambiarEntreBlocsNotasOneNote()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Cambiar entre blocs de notas en OneNote",
                    "Se aplica a: OneNote para Windows 10",
                    "Si suele trabajar con varios blocs de notas, puede cambiar fácilmente entre ellas.\n" +
                    "1. En cualquier página, haga clic en el botón de **Blocs de notas mostrar**\n" +
                    "2. En la lista de blocs de notas que se abre, haga clic en el nombre del Bloc de notas que desea cambiar.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/cambiar-entre-blocs-de-notas-en-onenote-para-windows-10-cb4e53ec-3fad-40a7-b109-1eb0cd718275?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        //----------- COMPARTIR -------------
        //-----------------------------------
        //Compartir una página de notas o un bloc de notas completo
        public static IList<Attachment> GetCompartirPaginaDeNotasBlocDeNotasOneNote()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Compartir una página de notas o un bloc de notas completo desde OneNote para Windows 10",
                    "Se aplica a: OneNote para Windows 10",
                    "Compartir notas es fácil en OneNote para Windows 10. Puede compartir un bloc de notas completo y permitir que los participantes "+
                    "del bloc de notas vean o editen las notas. Incluso si el bloc de notas está almacenado en su cuenta personal de OneDrive, puede compartir una única página de notas que otros usuarios puedan ver.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/compartir-una-p%C3%A1gina-de-notas-o-un-bloc-de-notas-completo-desde-onenote-para-windows-10-d4a74a14-44a3-411e-8fb5-06e73ddf047f?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        //------------ GUARDAR --------------
        //-----------------------------------
        // Guardar notas y blocs de notas
        public static IList<Attachment> GetGuardarNotasBlocsNotas()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Guardar notas y blocs de notas",
                    "Se aplica a: OneNote para Mac, OneNote Online, OneNote para Windows 10",
                    "A diferencia de lo que ocurre en las aplicaciones de Microsoft Office, en OneNote no hay un comando " +
                    "para guardar porque no es necesario guardar manualmente el trabajo.\n" +
                    "OneNote recuerda y guarda de forma automática continua todo lo que usted hace  mientras escribe, edita, " +
                    "da formato, organiza, busca y comparte sus notas. Incluso puede salir de OneNote cuando lo desee sin cerrar " +
                    "los blocs de notas ni guardar manualmente el trabajo.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Guardar-notas-y-blocs-de-notas-57fbb66a-7ebb-44e1-b33c-33b89c7f7e58#top")),
            };
        }

        //------------ IMPRIMIR -------------
        //-----------------------------------
        // Imprimir notas en OneNote para Windows 10
        public static IList<Attachment> GetImprimirNotasBlocsNotas()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Imprimir notas en OneNote",
                    "Se aplica a: OneNote para Windows 10",
                    "siempre que sea necesaria una copia impresa de las notas, puede imprimir fácilmente una sola página, " +
                    "una sección completa o un bloc de notas completo.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/imprimir-notas-en-onenote-para-windows-10-45edbbc5-fbb8-453f-99c7-aaadebe5c06a?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        //-------- UTILIZAR / USAR ----------
        //-----------------------------------
        // Utilizar diferentes versiones de OneNote en el mismo equipo
        public static IList<Attachment> GetUtilizaDiferentesVersionesOneNote()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Utilizar diferentes versiones de OneNote en el mismo equipo",
                    "Se aplica a: OneNote para Windows 10",
                    "Windows, cuando detecta varias versiones de OneNote, es posible que le pida que seleccione la versión de " +
                    "OneNote que desee usar como aplicación predeterminada. Si omite esta solicitud o cambia de opinión sobre " +
                    "la selección, puede cambiar manualmente esta configuración en cualquier momento.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/imprimir-notas-en-onenote-para-windows-10-45edbbc5-fbb8-453f-99c7-aaadebe5c06a?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Usar varias cuentas de Microsoft con OneNote para Windows 10
        public static IList<Attachment> GetUsarVariasCuentasMicrosoftOneNote()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Usar varias cuentas de Microsoft con OneNote para Windows 10",
                    "Se aplica a: OneNote para Windows 10",
                    "Si usa más de una cuenta de Microsoft, como Hotmail, Live.com o Outlook.com, puede utilizar cualquiera " +
                    "de estas cuentas con OneNote para Windows 10.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/usar-varias-cuentas-de-microsoft-con-onenote-para-windows-10-5afff855-54ee-47e4-a773-db048d4ac299?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        //------ RESOLVER / SOLUCIONAR -------
        //------------------------------------
        // Convertir y resolver ecuaciones matemáticas en OneNote para Windows 10
        public static IList<Attachment> GetResolverEcuaciones()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Convertir y resolver ecuaciones matemáticas en OneNote",
                    "Se aplica a: OneNote para Windows 10",
                    "**Nota:** " +
                    "Esta característica solo está disponibles si se tiene una [suscripción a Office 365](https://products.office.com/es-ES/buy/office). " +
                    "Si es suscriptor de Office 365, [asegúrese de tener la versión más reciente de Office](https://support.office.com/es-es/article/%C2%BFc%C3%B3mo-actualizo-a-office-2016-ee68f6cf-422f-464a-82ec-385f65391350?ui=es-ES&rs=es-ES&ad=ES).",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/imprimir-notas-en-onenote-para-windows-10-45edbbc5-fbb8-453f-99c7-aaadebe5c06a?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Solucionar problemas en OneNote para Windows 10
        public static IList<Attachment> GetSolucionarProblemasOneNote()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Solucionar problemas en OneNote",
                    "Se aplica a: OneNote para Windows 10",
                    "Este artículo contiene consejos para solucionar los problemas que pueden surgir al usar la vista " +
                    "previa de OneNote en Windows 10.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/solucionar-problemas-en-onenote-para-windows-10-942b006c-46ac-4300-a629-7fac5ae4dc70?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Resolver el error 0xE0000007 ("Tuvimos un problema de sincronización del Bloc de notas") en OneNote
        public static IList<Attachment> GetResolverErrorOneNote()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Resolver el error 0xE0000007 en OneNote",
                    "Se aplica a: OneNote 2016, OneNote para Mac, OneNote para teléfonos Android, OneNote para iOS, OneNote para Windows 10",
                    "**Problema:**\n" +
                    "* Cuando intente sincronizar los cambios a cualquier bloc de notas de Microsoft OneNote, puede producirse el error siguiente:\n" +
                    "* Se produjo un problema de sincronización del bloc de notas. (Código de error: 0xE0000007)",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/resolver-el-error-0xe0000007-tuvimos-un-problema-de-sincronizaci%C3%B3n-del-bloc-de-notas-en-onenote-b303eed4-4c9f-45af-bc52-810ddca86e83?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // ¿Por qué ya no funciona la herramienta de recorte de pantalla?
        public static IList<Attachment> GetNoFuncionaHerramientaRecorteOneNote()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "¿Por qué ya no funciona la herramienta de recorte de pantalla?",
                    "Se aplica a: OneNote 2016, OneNote 2013, OneNote Online, OneNote para Windows 10",
                    "Método abreviado de teclado de OneNote para los recortes de pantalla ha cambiado con las actualizaciones para el sistema operativo Windows.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/%C2%BFpor-qu%C3%A9-ya-no-funciona-la-herramienta-de-recorte-de-pantalla-311c21ff-68d9-4e2a-8769-ede9faafdb17?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Solucionar problemas en OneNote para Windows 10
        // Resolver el error 0xE0000007 ("Tuvimos un problema de sincronización del Bloc de notas") en OneNote
        // ¿Por qué ya no funciona la herramienta de recorte de pantalla?
        public static IList<Attachment> GetSolucionarOneNote()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Solucionar problemas en OneNote",
                    "Se aplica a: OneNote para Windows 10",
                    "Este artículo contiene consejos para solucionar los problemas que pueden surgir al usar la vista " +
                    "previa de OneNote en Windows 10.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/solucionar-problemas-en-onenote-para-windows-10-942b006c-46ac-4300-a629-7fac5ae4dc70?ui=es-ES&rs=es-ES&ad=ES")),
                GetHeroCardV2(
                    "Resolver el error 0xE0000007 en OneNote",
                    "Se aplica a: OneNote 2016, OneNote para Mac, OneNote para teléfonos Android, OneNote para iOS, OneNote para Windows 10",
                    "**Problema:**\n" +
                    "* Cuando intente sincronizar los cambios a cualquier bloc de notas de Microsoft OneNote, puede producirse el error siguiente:\n" +
                    "* Se produjo un problema de sincronización del bloc de notas. (Código de error: 0xE0000007)",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/resolver-el-error-0xe0000007-tuvimos-un-problema-de-sincronizaci%C3%B3n-del-bloc-de-notas-en-onenote-b303eed4-4c9f-45af-bc52-810ddca86e83?ui=es-ES&rs=es-ES&ad=ES")),
                GetHeroCardV2(
                    "¿Por qué ya no funciona la herramienta de recorte de pantalla?",
                    "Se aplica a: OneNote 2016, OneNote 2013, OneNote Online, OneNote para Windows 10",
                    "Método abreviado de teclado de OneNote para los recortes de pantalla ha cambiado con las actualizaciones para el sistema operativo Windows.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/%C2%BFpor-qu%C3%A9-ya-no-funciona-la-herramienta-de-recorte-de-pantalla-311c21ff-68d9-4e2a-8769-ede9faafdb17?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        //------------ REVISAR -------------
        //-----------------------------------
        // Revisar la ortografía en OneNote para Windows 10
        public static IList<Attachment> GetRevisarOrtografiAOneNote()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Revisar la ortografía en OneNote",
                    "Se aplica a: OneNote para Windows 10",
                    "**Este articulo contiene:**\n" +
                    "* Revisar la ortografía mientras escribe\n" +
                    "* Revisar la ortografía en otro idioma",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/revisar-la-ortograf%C3%ADa-en-onenote-para-windows-10-91d36aa5-637c-4dcc-8a0f-acdd9a6f2acb?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        //------------- EDITAR --------------
        //-----------------------------------
        // Editar, recortar o girar imágenes en OneNote para Windows 10
        public static IList<Attachment> GetRevisarImegenAOneNote()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Revisar la ortografía en OneNote",
                    "Se aplica a: OneNote para Windows 10",
                    "Edición de imágenes en OneNote para Windows 10 se limita a girar imágenes insertadas y fotos en " +
                    "incrementos de 90 grados.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/editar-recortar-o-girar-im%C3%A1genes-en-onenote-para-windows-10-d216f04e-b2a7-4bd8-a7e2-753735f02ae7?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        //------------- ENVIAR --------------
        //-----------------------------------
        // Enviar fotos e imágenes de otras aplicaciones a OneNote para Windows 10
        public static IList<Attachment> GetEnviarFotosImágenesDeOtrasAplicacionesOneNote()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Enviar fotos e imágenes de otras aplicaciones a OneNote",
                    "Se aplica a: OneNote para Windows 10",
                    "Puede importar imágenes fácilmente en sus notas desde cualquier otra aplicación de Windows 10, como Fotos.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/enviar-fotos-e-im%C3%A1genes-de-otras-aplicaciones-a-onenote-para-windows-10-02e66db1-eb04-4297-a41b-b82648aa843d?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Enviar documentos y archivos a OneNote para Windows 10
        public static IList<Attachment> GetEnviarDocumentosArchivosOneNote()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Enviar documentos y archivos a OneNote",
                    "Se aplica a: OneNote para Windows 10",
                    "Enviar a OneNote le permite capturar información desde cualquier aplicación y enviarlo a una " +
                    "página en OneNote para Windows 10.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/enviar-documentos-y-archivos-a-onenote-para-windows-10-2e6b3ce8-3172-43b5-bb45-deee8ab3dee2")),
            };
        }

        //---------- SINCRONIZAR ------------
        //-----------------------------------
        // Sincronizar blocs de notas en OneNote para Windows 10
        public static IList<Attachment> GetSincronizarBlocsNotasOneNote()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Sincronizar blocs de notas en OneNote",
                    "Se aplica a: OneNote para Windows 10",
                    "OneNote para Windows 10 sincroniza automáticamente todas las notas por usted. Si lo prefiere, puede " +
                    "sincronizar blocs de notas de forma manual cuando lo desee.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/sincronizar-blocs-de-notas-en-onenote-para-windows-10-21cb4629-3ef4-4220-8539-d01d29491e6a?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        //----------- PROTEGER --------------
        //-----------------------------------
        // Proteger las notas con contraseña en OneNote para Windows 10
        public static IList<Attachment> GetProtegerNotasContraseñaOneNote()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Proteger las notas con contraseña en OneNote",
                    "Se aplica a: OneNote para Windows 10",
                    "Si utiliza OneNote en la escuela, en el trabajo, o en casa, las contraseñas le permiten " +
                    "controlar el acceso a determinadas secciones de los blocs de notas.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/proteger-las-notas-con-contrase%C3%B1a-en-onenote-para-windows-10-a2fd9183-c864-4653-9c4e-714a116a4ab7?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        //----------- TRABAJAR --------------
        //-----------------------------------
        // Trabajar con páginas y secciones en OneNote para Windows 10
        public static IList<Attachment> GetTrabajarPaginasSeccionesOneNote()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Trabajar con páginas y secciones en OneNote",
                    "Se aplica a: OneNote para Windows 10",
                    "Páginas y secciones en OneNote para Windows 10 son muy similares a las páginas y secciones " +
                    "de la aplicación de OneNote para Microsoft Store que podría estar acostumbrado de Windows 8.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/trabajar-con-p%C3%A1ginas-y-secciones-en-onenote-para-windows-10-bb25a523-6d37-44ca-b707-1bdd10190f99?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        //-----------------------------------------------------------------

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

    }
}