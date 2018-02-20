using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Bot.Connector;

namespace KlausBot.Util
{
    public class Respuestas
    {
        // -------------------------------------------------------------
        // PREGUNTAS GENERALES
        // -------------------------------------------------------------
        // Imagenes en 600px - 300px
        // HttpContext.Current.Server.MapPath("")

        // ------------- TEMAS DESTACADOS ---------------
        // ----------------------------------------------
        // Temas destacados de Outlook
        public static IList<Attachment> GetDestacadosOutlook()
        {
            return new List<Attachment>()
            {
                // Novedades en Outlook 2016 para Windows
                GetHeroCardV4(
                    new CardImage(url: "http://klausbotv1.azurewebsites.net/Images/Outlook/Destacados/destacadosOutlook1.png"),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-ES/article/Novedades-en-Outlook-2016-para-Windows-51c81e7a-de25-4a34-a7fe-bd79f8e48647")),
                // Crear y agregar una firma a los mensajes
                 GetHeroCardV4(
                    new CardImage(url: "http://klausbotv1.azurewebsites.net/Images/Outlook/Destacados/destacadosOutlook2.png"),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Crear-y-agregar-una-firma-a-los-mensajes-8ee5d4f4-68fd-464a-a1c1-0e1c80bb27f2#ID0EAABAAA=2016,_2013")),
                // Enviar respuestas automáticas "Fuera de la oficina" de Outlook
                GetHeroCardV4(
                    new CardImage(url: "http://klausbotv1.azurewebsites.net/Images/Outlook/Destacados/destacadosOutlook3.png"),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Enviar-respuestas-autom%C3%A1ticas-Fuera-de-la-oficina-de-Outlook-9742f476-5348-4f9f-997f-5e208513bd67?ui=es-ES&rs=es-ES&ad=ES")),
                // Importar contactos desde Gmail
                GetHeroCardV4(
                    new CardImage(url: "http://klausbotv1.azurewebsites.net/Images/Outlook/Destacados/destacadosOutlook4.png"),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Importar-contactos-desde-Gmail-ad99d439-04b6-4001-a266-c170df721291?ui=es-ES&rs=es-ES&ad=ES")),
                // Importar contactos a Outlook
                GetHeroCardV4(
                    new CardImage(url: "http://klausbotv1.azurewebsites.net/Images/Outlook/Destacados/destacadosOutlook5.png"),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-ES/article/Importar-contactos-a-Outlook-bb796340-b58a-46c1-90c7-b549b8f3c5f8")),
                // Recuperar elementos eliminados en Outlook para Windows
                GetHeroCardV4(
                    new CardImage(url: "http://klausbotv1.azurewebsites.net/Images/Outlook/Destacados/destacadosOutlook6.png"),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Recuperar-elementos-eliminados-en-Outlook-para-Windows-49e81f3c-c8f4-4426-a0b9-c0fd751d48ce?ui=es-ES&rs=es-ES&ad=ES")),
                // Recuperar o reemplazar un mensaje después de enviarlo
                GetHeroCardV4(
                    new CardImage(url: "http://klausbotv1.azurewebsites.net/Images/Outlook/Destacados/destacadosOutlook7.png"),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Recuperar-o-reemplazar-un-mensaje-despu%C3%A9s-de-enviarlo-35027f88-d655-4554-b4f8-6c0729a723a0?ui=es-ES&rs=es-ES&ad=ES")),
                // Outlook no responde, se detiene en «Procesando», deja de funcionar, se inmoviliza o se bloquea
                GetHeroCardV4(
                    new CardImage(url:"http://klausbotv1.azurewebsites.net/Images/Outlook/Destacados/destacadosOutlook8.png"),
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
                    new CardImage(url: "http://klausbotv1.azurewebsites.net/Images/OneDrive/Destacados/1.png"),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-ES/article/%C2%BFQu%C3%A9-es-OneDrive-para-la-Empresa-187f90af-056f-47c0-9656-cc0ddca7fdc2")),
                // ¿Qué versión de OneDrive uso?
                 GetHeroCardV4(
                    new CardImage(url:"http://klausbotv1.azurewebsites.net/Images/OneDrive/Destacados/2.png"),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/%C2%BFQu%C3%A9-versi%C3%B3n-de-OneDrve-uso-19246eae-8a51-490a-8d97-a645c151f2ba?ui=es-ES&rs=es-ES&ad=ES")),
                // Cargar fotografías y archivos en OneDrive
                GetHeroCardV4(
                    new CardImage(url:"http://klausbotv1.azurewebsites.net/Images/OneDrive/Destacados/3.png"),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-ES/article/Cargar-fotograf%C3%ADas-y-archivos-en-OneDrive-b00ad3fe-6643-4b16-9212-de00ef02b586")),
                // Recuperar archivos de tu equipo
                GetHeroCardV4(
                    new CardImage(url:"http://klausbotv1.azurewebsites.net/Images/OneDrive/Destacados/4.png"),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Recuperar-archivos-de-tu-equipo-70761550-519c-4d45-b780-5a613b2f8822?ui=es-ES&rs=es-ES&ad=ES")),
                // Compartir archivos y carpetas de OneDrive
                GetHeroCardV4(
                    new CardImage(url:"http://klausbotv1.azurewebsites.net/Images/OneDrive/Destacados/5.png"),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-ES/article/Compartir-archivos-y-carpetas-de-OneDrive-9fcc2f7d-de0c-4cec-93b0-a82024800c07")),
                // Usar OneDrive para Android
                GetHeroCardV4(
                    new CardImage(url:"http://klausbotv1.azurewebsites.net/Images/OneDrive/Destacados/6.png"),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-ES/article/Usar-OneDrive-para-Android-eee1d31c-792d-41d4-8132-f9621b39eb36")),
                // Solucionar problemas de sincronización de OneDrive
                GetHeroCardV4(
                    new CardImage(url:"http://klausbotv1.azurewebsites.net/Images/OneDrive/Destacados/7.png"),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-ES/article/Solucionar-problemas-de-sincronizaci%C3%B3n-de-OneDrive-0899b115-05f7-45ec-95b2-e4cc8c4670b2")),
                // Configurar el equipo para sincronizar los archivos de OneDrive para la Empresa en Office 365
                GetHeroCardV4(
                    new CardImage(url:"http://klausbotv1.azurewebsites.net/Images/OneDrive/Destacados/8.png"),
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
                    new CardImage(url:"http://klausbotv1.azurewebsites.net/Images/Word/Destacados/1.png"),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Novedades-de-Word-2016-para-Windows-4219dfb5-23fc-4853-95aa-b13a674a6670?ui=es-ES&rs=es-ES&ad=ES")),
                // Descargar plantillas pregeneradas gratuitas
                 GetHeroCardV4(
                    new CardImage(url:"http://klausbotv1.azurewebsites.net/Images/Word/Destacados/2.png"),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-ES/article/Descargar-plantillas-pregeneradas-gratuitas-29f2a18d-29a6-4a07-998b-cfe5ff7ffbbb")),
                // Realizar un seguimiento de los cambios en Word
                GetHeroCardV4(
                    new CardImage(url: "http://klausbotv1.azurewebsites.net/Images/Word/Destacados/3.png"),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Realizar-un-seguimiento-de-los-cambios-en-Word-197ba630-0f5f-4a8e-9a77-3712475e806a?ui=es-ES&rs=es-ES&ad=ES")),
                // Cambiar o establecer la fuente predeterminada
                GetHeroCardV4(
                    new CardImage(url: "http://klausbotv1.azurewebsites.net/Images/Word/Destacados/4.png"),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-ES/article/Cambiar-o-establecer-la-fuente-predeterminada-20f72414-2c42-4b53-9654-d07a92b9294a")),
                // Agregar un gráfico al documento en Word
                GetHeroCardV4(
                    new CardImage(url: "http://klausbotv1.azurewebsites.net/Images/Word/Destacados/5.png"),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Agregar-un-gr%C3%A1fico-al-documento-en-Word-ff48e3eb-5e04-4368-a39e-20df7c798932?ui=es-ES&rs=es-ES&ad=ES")),
                // Soporte de accesibilidad para Word
                GetHeroCardV4(
                    new CardImage(url:"http://klausbotv1.azurewebsites.net/Images/Word/Destacados/6.png"),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-ES/article/Soporte-de-accesibilidad-para-Word-c014d8b8-4ef3-4a7a-935d-295663f3343c")),
                // Iniciar la numeración de páginas más adelante en el documento
                GetHeroCardV4(
                    new CardImage(url:"http://klausbotv1.azurewebsites.net/Images/Word/Destacados/7.png"),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-ES/article/Iniciar-la-numeraci%C3%B3n-de-p%C3%A1ginas-m%C3%A1s-adelante-en-el-documento%C2%A0-c73e3d55-d722-4bd0-886e-0b0bd0eb3f02")),
                // Eliminar o cambiar un encabezado o pie de página de una sola página
                GetHeroCardV4(
                    new CardImage(url:"http://klausbotv1.azurewebsites.net/Images/Word/Destacados/8.png"),
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
                    new CardImage(url:"http://klausbotv1.azurewebsites.net/Images/Excel/Destacados/1.png"),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-ES/article/Novedades-en-Excel-2016-para-Windows-5fdb9208-ff33-45b6-9e08-1f5cdb3a6c73")),
                // Mover o copiar hojas de cálculo o los datos que contienen
                 GetHeroCardV4(
                    new CardImage(url:"http://klausbotv1.azurewebsites.net/Images/Excel/Destacados/2.png"),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Mover-o-copiar-hojas-de-c%C3%A1lculo-o-los-datos-que-contienen-47207967-bbb2-4e95-9b5c-3c174aa69328?ui=es-ES&rs=es-ES&ad=ES")),
                // Crear una lista desplegable
                GetHeroCardV4(
                    new CardImage(url: "http://klausbotv1.azurewebsites.net/Images/Excel/Destacados/3.png"),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-ES/article/Crear-una-lista-desplegable-7693307a-59ef-400a-b769-c5402dce407b")),
                // Guardar un libro con otro formato de archivo
                 GetHeroCardV4(
                    new CardImage(url:"http://klausbotv1.azurewebsites.net/Images/Excel/Destacados/4.png"),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-ES/article/guardar-un-libro-con-otro-formato-de-archivo-6a16c862-4a36-48f9-a300-c2ca0065286e")),
                // Calcular la diferencia entre dos fechas
                GetHeroCardV4(
                    new CardImage(url:"http://klausbotv1.azurewebsites.net/Images/Excel/Destacados/5.png"),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-ES/article/Calcular-la-diferencia-entre-dos-fechas-8235e7c9-b430-44ca-9425-46100a162f38")),
                // Inmovilizar paneles para bloquear filas y columnas
                GetHeroCardV4(
                    new CardImage(url:"http://klausbotv1.azurewebsites.net/Images/Excel/Destacados/6.png"),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-ES/article/Inmovilizar-paneles-para-bloquear-filas-y-columnas-dab2ffc9-020d-4026-8121-67dd25f2508f")),
                // Funciones de Excel (por orden alfabético)
                GetHeroCardV4(
                    new CardImage(url:"http://klausbotv1.azurewebsites.net/Images/Excel/Destacados/7.png"),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Funciones-de-Excel-por-orden-alfab%C3%A9tico-b3944572-255d-4efb-bb96-c6d90033e188?ui=es-ES&rs=es-ES&ad=ES")),
                // Cómo evitar la ruptura de las fórmulas
                GetHeroCardV4(
                    new CardImage(url: "http://klausbotv1.azurewebsites.net/Images/Excel/Destacados/8.png"),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-ES/article/C%C3%B3mo-evitar-la-ruptura-de-las-f%C3%B3rmulas-8309381d-33e8-42f6-b889-84ef6df1d586")),
                // Soporte de accesibilidad para Excel
                GetHeroCardV4(
                    new CardImage(url:"http://klausbotv1.azurewebsites.net/Images/Excel/Destacados/9.png"),
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
                    new CardImage(url:"http://klausbotv1.azurewebsites.net/Images/PowerPoint/Destacados/1.png"),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/formatos-de-archivo-de-audio-y-v%C3%ADdeo-compatibles-con-powerpoint-d8b12450-26db-4c7b-a5c1-593d3418fb59?wt.mc_id=ppt_home&ui=es-ES&rs=es-ES&ad=ES")),
                // Agregar imágenes prediseñadas a un archivo
                 GetHeroCardV4(
                    new CardImage(url:"http://klausbotv1.azurewebsites.net/Images/PowerPoint/Destacados/2.png"),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Agregar-im%C3%A1genes-predise%C3%B1adas-a-un-archivo-0a01ae25-973c-4c2c-8eaf-8c8e1f9ab530?wt.mc_id=ppt_home&ui=es-ES&rs=es-ES&ad=ES")),
                // Convertir una presentación en un vídeo
                GetHeroCardV4(
                    new CardImage(url:"http://klausbotv1.azurewebsites.net/Images/PowerPoint/Destacados/3.png"),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Convertir-una-presentaci%C3%B3n-en-un-v%C3%ADdeo-c140551f-cb37-4818-b5d4-3e30815c3e83?wt.mc_id=ppt_home&ui=es-ES&rs=es-ES&ad=ES")),
                // Agregar una marca de agua "BORRADOR" al fondo de las diapositivas
                GetHeroCardV4(
                    new CardImage(url:"http://klausbotv1.azurewebsites.net/Images/PowerPoint/Destacados/4.png"),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Agregar-una-marca-de-agua-BORRADOR-al-fondo-de-las-diapositivas-ea4cc5f5-ea5d-4213-9c7d-ed01a7952ed0?wt.mc_id=ppt_home&ui=es-ES&rs=es-ES&ad=ES")),
                // Ver las notas del orador al exponer una presentación con diapositivas
                GetHeroCardV4(
                    new CardImage(url:"http://klausbotv1.azurewebsites.net/Images/PowerPoint/Destacados/5.png"),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/iniciar-la-presentaci%C3%B3n-y-ver-las-notas-en-la-vista-moderador-4de90e28-487e-435c-9401-eb49a3801257?wt.mc_id=ppt_home&ui=es-ES&rs=es-ES&ad=ES")),
                // Reproducir música durante toda la presentación con diapositivas
                GetHeroCardV4(
                    new CardImage(url:"http://klausbotv1.azurewebsites.net/Images/PowerPoint/Destacados/6.png"),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Reproducir-m%C3%BAsica-durante-toda-la-presentaci%C3%B3n-con-diapositivas-b01ded6a-28c8-473a-971a-6dfa92cc9367?wt.mc_id=ppt_home&ui=es-ES&rs=es-ES&ad=ES")),
                // ¿Qué es un patrón de diapositivas?
                GetHeroCardV4(
                    new CardImage(url:"http://klausbotv1.azurewebsites.net/Images/PowerPoint/Destacados/7.png"),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-ES/article/%C2%BFQu%C3%A9-es-un-patr%C3%B3n-de-diapositivas-b9abb2a0-7aef-4257-a14e-4329c904da54?wt.mc_id=ppt_home")),
                // Soporte de accesibilidad para PowerPoint
                GetHeroCardV4(
                    new CardImage(url:"http://klausbotv1.azurewebsites.net/Images/PowerPoint/Destacados/8.png"),
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
                    new CardImage(url:"http://klausbotv1.azurewebsites.net/Images/OneNote/Destacados/1.png"),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Novedades-de-OneNote-para-Windows-10-1477d5de-f4fd-4943-b18a-ff17091161ea?ui=es-ES&rs=es-ES&ad=ES")),
                // Introducción al nuevo OneNote
                 GetHeroCardV4(
                    new CardImage(url:"http://klausbotv1.azurewebsites.net/Images/OneNote/Destacados/2.png"),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-ES/article/Introducci%C3%B3n-al-nuevo-OneNote-ab84fcc2-f845-41ac-9c29-89b0720c8eb3")),
                // Tareas básicas en OneNote para Windows 10
                GetHeroCardV4(
                    new CardImage(url:"http://klausbotv1.azurewebsites.net/Images/OneNote/Destacados/3.png"),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Tareas-básicas-en-OneNote-para-Windows-10-081573f8-2e8f-45e5-bf16-0900d4d3331f?ui=es-ES&rs=es-ES&ad=ES")),
                // Enviar fotos e imágenes de otras aplicaciones a OneNote
                GetHeroCardV4(
                    new CardImage(url:"http://klausbotv1.azurewebsites.net/Images/OneNote/Destacados/4.png"),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Enviar-fotos-e-im%C3%A1genes-de-otras-aplicaciones-a-OneNote-para-Windows-10-02e66db1-eb04-4297-a41b-b82648aa843d?ui=es-ES&rs=es-ES&ad=ES")),
                // Sincronizar blocs de notas en OneNote 
                GetHeroCardV4(
                    new CardImage(url:"http://klausbotv1.azurewebsites.net/Images/OneNote/Destacados/5.png"),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Sincronizar-blocs-de-notas-en-OneNote-para-Windows-10-21cb4629-3ef4-4220-8539-d01d29491e6a?ui=es-ES&rs=es-ES&ad=ES")),
                // Compartir una página de notas o un bloc de notas completo
                GetHeroCardV4(
                    new CardImage(url:"http://klausbotv1.azurewebsites.net/Images/OneNote/Destacados/6.png"),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Compartir-una-p%C3%A1gina-de-notas-o-un-bloc-de-notas-completo-desde-OneNote-para-Windows-10-d4a74a14-44a3-411e-8fb5-06e73ddf047f?ui=es-ES&rs=es-ES&ad=ES")),
                // Proteger las notas con contraseña en OneNote para Windows 10
                GetHeroCardV4(
                    new CardImage(url:"http://klausbotv1.azurewebsites.net/Images/OneNote/Destacados/7.png"),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Proteger-las-notas-con-contrase%C3%B1a-en-OneNote-para-Windows-10-a2fd9183-c864-4653-9c4e-714a116a4ab7?ui=es-ES&rs=es-ES&ad=ES")),
                // Solucionar problemas en OneNote para Windows 10
                GetHeroCardV4(
                    new CardImage(url: "http://klausbotv1.azurewebsites.net/Images/OneNote/Destacados/8.png"),
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Solucionar-problemas-en-OneNote-para-Windows-10-942b006c-46ac-4300-a629-7fac5ae4dc70?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // --------- PREGUNTAS SOBRE MICROSOFT -----------
        // -----------------------------------------------
        // Recuperar la cuenta de Microsoft
        public static IList<Attachment> GetRecuperarCuentaMicrosoft()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                "Recuperar la cuenta de Microsoft",
                "Se aplica a: Microsoft account",
                "El formulario de recuperación de cuenta es la última opción que debes usar para recuperar tu cuenta.",
                new CardAction(ActionTypes.OpenUrl, "Ver más información",
                value: "https://support.microsoft.com/es-es/help/17875/microsoft-account-recover")),
            };
        }

        // Cómo restablecer la contraseña de tu cuenta de Microsoft
        public static IList<Attachment> GetRecuperarContraseñaMicrosoft()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                "Cómo restablecer la contraseña de tu cuenta de Microsoft",
                "Se aplica a: Microsoft account",
                "Si has olvidado la contraseña que usas para iniciar sesión en servicios como, por ejemplo, Outlook.com, Skype, OneDrive y Xbox Live, quizás tengas que restablecerla.",
                new CardAction(ActionTypes.OpenUrl, "Ver más información",
                value: "https://support.microsoft.com/es-es/help/4026971/microsoft-account-how-to-reset-your-password")),
            };
        }

        // ------------ PREGUNTAS SOBRE OFFICE ------------
        // ------------------------------------------------
        // Insertar imágenes en office 
        public static IList<Attachment> GetAgregarImagen()
        {
            return new List<Attachment>()
            {
               GetHeroCardV2(
                    "Insertar imágenes",
                    "Se aplica a: Excel, Word, Outlook, PowerPoint, OneNote, Publisher",
                    "Office ya no ofrece imágenes prediseñadas en sus aplicaciones, pero le ayuda a buscar imágenes " +
                    "en línea para que las inserte en sus archivos. ",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Insertar-im%C3%A1genes-3c51edf4-22e1-460a-b372-9329a8724344")),
            };
        }

        // Insertar un símbolo o carácter especial en office 
        public static IList<Attachment> GetInsertarCaracterEspecialOffice()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Insertar un símbolo o carácter especial",
                    "Se aplica a: Excel 2016, Word 2016, Outlook 2016, Publisher 2010,  Word Starter 2010",
                    "**¿Qué desea hacer?:**\r\r"+
                    ">1. [Insertar un símbolo](https://support.office.com/es-es/article/Insertar-un-s%C3%ADmbolo-o-car%C3%A1cter-especial-81e64967-74c0-4fd9-814a-3aa867d4cfce#bm1)\r\r"+
                    ">2. [Insertar un carácter especial](https://support.office.com/es-es/article/Insertar-un-s%C3%ADmbolo-o-car%C3%A1cter-especial-81e64967-74c0-4fd9-814a-3aa867d4cfce#bm2)\r\r"+
                    ">3. [Insertar un carácter Unicode](https://support.office.com/es-es/article/Insertar-un-s%C3%ADmbolo-o-car%C3%A1cter-especial-81e64967-74c0-4fd9-814a-3aa867d4cfce#bm3)",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Insertar-un-s%C3%ADmbolo-o-car%C3%A1cter-especial-81e64967-74c0-4fd9-814a-3aa867d4cfce")),
            };
        }

        // Agregar un PDF a un archivo de Office
        public static IList<Attachment> GetAgregarPDFArchivoOffice()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Agregar un PDF a un archivo de Office",
                    "Se aplica a: Excel 2016 Word 2016 Outlook 2016 PowerPoint 2016 OneNote 2016 Publisher 2016",
                    "Vea cómo insertar un archivo en formato PDF en un archivo de Office como un objeto. Puede "+
                    "cambiar el tamaño de un objeto, pero no puede editarlo después de insertarlo. Necesitará tener "+
                    "instalado Adobe Acrobat o Adobe Reader para ver o leer archivos PDF.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Agregar-un-PDF-a-un-archivo-de-Office-74819342-8f00-4ab4-bcbe-0f3df15ab0dc#ID0EAABAAA=2016,_2013,_2010")),
            };
        }

        // Agregar o quitar una firma digital en archivos de Office
        public static IList<Attachment> GetAgregarQuitarFirmaOffice()
        {
            return new List<Attachment>()
            {
               GetHeroCardV2(
                    "Agregar o quitar una firma digital en archivos de Office",
                    "Se aplica a: Excel, Word, Outlook, PowerPoint, Word Starter 2010",
                    "En este artículo se explican las firmas digitales (también conocidas como identificación digital), para qué se " +
                    "puede usar y cómo se pueden usar firmas digitales",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Agregar-o-quitar-una-firma-digital-en-archivos-de-Office-70D26DC9-BE10-46F1-8EFA-719C8B3F1A2D#__toc311526850")),
            };
        }

        // Agregar un PDF a un archivo de Office
        public static IList<Attachment> GetAgregarArchivo()
        {
            return new List<Attachment>()
            {
               GetHeroCardV2(
                    "Agregar o quitar una firma digital en archivos de Office",
                    "Se aplica a: Office",
                    "Vea cómo se inserta un archivo PDF en un archivo de Office como archivo adjunto. Puede cambiar el tamaño del objeto, " +
                    "pero no podrá editarlo una vez que lo haya insertado. ",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Agregar-un-PDF-a-un-archivo-de-Office-74819342-8F00-4AB4-BCBE-0F3DF15AB0DC")),
               GetHeroCardV2(
                    "Crear un archivo de datos de Outlook para guardar la información",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010 Outlook 2007",
                    "Los archivos de datos de Outlook (.pst) se guardan en el equipo dentro de la carpeta Documentos/Archivos de Outlook.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Crear-un-archivo-de-datos-de-Outlook-para-guardar-la-informaci%C3%B3n-17a13ca2-df52-48e8-b933-4c84c2aabe7c")),
            };
        }

        // Aplicar o quitar estilos y efectos de los objetos en office 
        public static IList<Attachment> GetAplicarEstilos()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Aplicar o quitar estilos y efectos de los objetos",
                    "Se aplica a: Excel para Mac, PowerPoint para Mac, Word para Mac",
                    "**Aplicar un estilo**\r\r"+
                    ">1. Haga clic en el objeto que desea cambiar y, a continuación, haga clic en la ficha **formato**.\r\r"+
                    ">2. Haga clic en la opción que quiera.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/aplicar-o-quitar-estilos-y-efectos-de-los-objetos-6f916fb0-5b31-4d5d-8de7-11d44abfd0c7")),
               };
        }

        // Crear y Usar su propia plantilla en Office para Mac
        public static IList<Attachment> GetUsarPlantilla()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Crear y usar su propia plantilla en Office para Mac",
                    "Se aplica a: Excel 2016 para Mac, PowerPoint 2016 para Mac, Word 2016 para Mac",
                    "Para crear una plantilla, puede empezar con un documento, presentación, o libro que ya ha creado, uno que haya descargado o " +
                    "uno nuevo que desea personalizar en cualquier número de formas.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/crear-y-usar-su-propia-plantilla-en-office-para-mac-a1b72758-61a0-4215-80eb-165c6c4bed04?ui=es-ES&rs=es-ES&ad=ES")),
               };
        }

        // Firmas digitales y certificados en office 
        public static IList<Attachment> GetDefinicionFirmaDigital()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "¿Qué es una firma digital?",
                    "Se aplica a: Excel 2016 Word 2016 PowerPoint 2016 Access 2016 Visio Professional 2016",
                    "Una firma digital es un sello de autenticación electrónico cifrado en información digital, como mensajes de correo, "+
                    "macros o documentos electrónicos. La firma constata que la información proviene del firmante y no se ha modificado.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Firmas-digitales-y-certificados-8186cd15-e7ac-4a16-8597-22bd163e8e96#__toc311530578")),
            };
        }

        // Revisar la ortografía y gramática en Office
        public static IList<Attachment> GetRevisarOrtografiaOffice()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Revisar la ortografía y gramática en Office",
                    "Se aplica a: Office",
                    "Puede revisar la ortografía y la gramática a la vez ejecutando el corrector ortográfico y gramatical, o " +
                    "revisar la ortografía y la gramática automáticamente y realizar correcciones mientras trabaja. ",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/revisar-la-ortograf%C3%ADa-y-gram%C3%A1tica-en-office-5cdeced7-d81d-47de-9096-efd0ee909227?ui=es-ES&rs=es-ES&ad=ES")),
                };
        }

        // Guardar o convertir a PDF o XPS
        public static IList<Attachment> GetGuardarArchivoPDF()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Guardar o convertir a PDF o XPS",
                    "Se aplica a: Office",
                    "Puede usar los programas de Office para guardar sus archivos o convertirlos en archivos PDF a fin de compartirlos " +
                    "o imprimirlos mediante impresoras comerciales.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/guardar-o-convertir-a-pdf-o-xps-d85416c5-7d77-4fd6-a216-6f4bf7c7c110?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Agregar o quitar una firma digital en archivos de Office
        public static IList<Attachment> GetAgregarFirmaDigitalArhivosOffice()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Agregar o quitar una firma digital en archivos de Office",
                    "Se aplica a: Excel 2016, Word 2016, PowerPoint 2016, Word Starter 2010",
                    "En este artículo se explican las firmas digitales , para qué se pueden usar y cómo se pueden usar " +
                    "firmas digitales en los siguientes programas de Microsoft Office: Word, Excel y PowerPoint.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Agregar-o-quitar-una-firma-digital-en-archivos-de-Office-70d26dc9-be10-46f1-8efa-719c8b3f1a2d#__toc311526848")),
            };
        }

        // -------- PREGUNTAS CON VARIOS SERVICIOS --------
        // ------------------------------------------------
        // ---------- ABRIR -------------
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

        // ---------- CAMBIAR------------
        // Como cambiar el color de fondo del calendario
        // Cambiar el color de fondo de una página en OneNote para Windows 10
        public static IList<Attachment> GetCambiarColorFondoOutlookOneDrive()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Como cambiar el color de fondo del calendario",
                    "Se aplica a: Outlook 2016 Outlook 2013",
                    "El cambio del color de fondo es una forma rápida de hacer que su calendario sea diferente. Esto resulta " +
                    "especialmente útil si trabaja con [múltiples calendarios](https://support.office.com/es-es/article/crear-calendarios-adicionales-4b5570c4-e95d-4673-b38a-2b8ead5f00ee?ui=es-ES&rs=es-ES&ad=ES).",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Cambiar-el-color-de-fondo-del-calendario-3c544857-8446-46a5-ab9c-07b6af6e5091")),
                GetHeroCardV2(
                    "Cambiar el color de fondo de una página en OneNote",
                    "Se aplica a: OneNote para Windows 10",
                    "Para elegir un nuevo color para la página actual, haga lo siguiente:\r\r" +
                    ">1. Abra la página cuyo color de fondo que desee cambiar.\r\r" +
                    ">2. En la ficha vista, haga clic o puntee en Color de página.\r\r" +
                    ">3. Haga clic o puntee en el color que desee.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/cambiar-el-color-de-fondo-de-una-p%C3%A1gina-en-onenote-para-windows-10-c9265c78-a9b4-4cce-9ee3-46a2bb9e50f6?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Cambiar la fuente o el tamaño de fuente en la lista de mensajes
        // Cambiar el tamaño de las diapositivas
        public static IList<Attachment> GetCambiarTamanoFuenteListaMensajesTamanoDiapositivas()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Cambiar la fuente o el tamaño de fuente en la lista de mensajes",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010 Outlook 2007",
                    "Para buscar más rápidamente a través de la Bandeja de entrada, desea ampliar el texto de las líneas de asunto"+
                    " y el encabezado de columna, o cambiar la fuente para facilitar la lectura.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Cambiar-la-fuente-o-el-tama%C3%B1o-de-fuente-en-la-lista-de-mensajes-57bd24a6-1f85-45ac-a657-fba877d3fe00?ui=es-ES&rs=es-ES&ad=ES")),
                GetHeroCardV2(
                    "Cambiar el tamaño de las diapositivas",
                    "Se aplica a: PowerPoint 2016 PowerPoint 2013 PowerPoint 2010 PowerPoint 2016",
                    "Para cambiar el tamaño de las diapositivas\r\r"+
                    ">* Vaya a la pestaña Diseño de la cinta de opciones\r\r"+
                    ">* Seleccione el **tamaño de diapositiva**",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Cambiar-el-tama%C3%B1o-de-las-diapositivas-040a811c-be43-40b9-8d04-0de5ed79987e")),
               };
        }

        // ---------- CREAR -------------
        public static IList<Attachment> GetCrearDocumento()
        {
            return new List<Attachment>()
            {
                GetVideoCard(
                    "Crear archivos y carpetas en One Drive",
                    "Video sobre One Drive",
                    "https://videocontent.osi.office.net/9d21dd5f-3dd6-46d2-a10c-bb2b06053a56/ef4f6aa7-1bf9-4139-84eb-c6384f553da0_1280x720_3400.mp4",
                    "https://support.office.com/es-es/article/v%C3%ADdeo-crear-archivos-y-carpetas-en-onedrive-profesional-o-educativo-e1f59717-2f02-494d-93c6-8ef9613e82ba"),
                GetHeroCardV2(
                    "Crear un documento",
                    "Se aplica a: Word 2016, Word 2013, Word 2010, Word 2007, Word Online",
                    "Empezar a usar un documento básico en Microsoft Office Word es tan fácil como abrir un documento nuevo o " +
                    "existente, y empezar a escribir. ",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/crear-un-documento-3aa3c766-9733-4f60-9efa-de245467c13d")),
            };
        }

        // --------- IMPRIMIR -----------
        // Imprimir notas en OneNote para Windows 10
        // Imprimir contactos, mensajes u otros elementos de Outlook
        public static IList<Attachment> GetImprimirOutlookOneNote()
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
                GetHeroCardV2(
                    "Imprimir contactos, mensajes u otros elementos de Outlook",
                    "Se aplica a: Outlook 2016 Outlook 2013 Office para empresas Office 365 Pequeña Empresa Outlook 2010 Outlook 2007",
                    "Puede imprimir mensajes, contactos, calendarios, reuniones y tareas en Outlook. Cada tipo de elemento de " +
                    "Outlook tiene varias opciones de impresión.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Imprimir-contactos-mensajes-u-otros-elementos-de-Outlook-d2c0b12b-e308-41ce-9016-a3089ebdbe38?ui=es-ES&rs=es-HN&ad=PE")),
            };
        }

        // ---- INSERTAR / AGREGAR ------
        // Insertar Archivos
        public static IList<Attachment> GetInsertarArchivo()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Insertar un archivo en OneNote para Windows 10",
                    "Se aplica a: OneNote para Windows 10",
                    "Puede insertar un archivo como datos adjuntos para que pueda abrir una copia del archivo en OneNote.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/insertar-un-archivo-en-onenote-para-windows-10-5fc09a27-71b3-4e92-9eb6-3b0be9380374?ui=es-ES&rs=es-ES&ad=ES")),
                GetHeroCardV2(
                    "Insertar un objeto en la hoja de cálculo de Excel",
                    "Se aplica a: Excel 2016, Excel 2013, Excel 2010, Excel 2007",
                    "Puede usar vinculación e incrustación de objetos (OLE) para incluir contenido de otros programas, como Word o Excel.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/insertar-un-objeto-en-la-hoja-de-c%C3%A1lculo-de-excel-e73867b2-2988-4116-8d85-f5769ea435ba")),
                GetHeroCardV2(
                    "Adjuntar archivos o insertar imágenes en mensajes de correo de Outlook",
                    "Se aplica a: Outlook 2016, Outlook 2013, Outlook 2010, Outlook 2007",
                    " Outlook permite elegir rápidamente si quiere enviar el documento como un archivo adjunto tradicional o cargarlo en " +
                    "OneDrive y compartir un vínculo al archivo. Para resolver problemas al adjuntar archivos, vea [Solucionar problemas con datos adjuntos](https://support.office.com/es-es/article/Adjuntar-archivos-o-insertar-im%C3%A1genes-en-mensajes-de-correo-de-Outlook-bdfafef5-792a-42b1-9a7b-84512d7de7fc?ui=es-ES&rs=es-HN&ad=PE#bk_fix).",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Adjuntar-archivos-o-insertar-im%C3%A1genes-en-mensajes-de-correo-de-Outlook-bdfafef5-792a-42b1-9a7b-84512d7de7fc?ui=es-ES&rs=es-HN&ad=PE")),
                GetHeroCardV2(
                    "Insertar una hoja de cálculo o algún archivo en PowerPoint",
                    "Se aplica a: PowerPoint 2016 PowerPoint 2013",
                    "Puede vincular datos de una hoja de cálculo guardada Excel a la presentación de PowerPoint si tiene PowerPoint 2013 o posterior.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/insertar-una-hoja-de-c%C3%A1lculo-de-excel-en-powerpoint-0690708a-5ce6-41b4-923f-11d57554138d")),
            };
        }

        // Insertar una tabla en OneNote para Windows 10
        // Como agregar tablas a mensajes en Outlook
        // Agregar Tabla Office
        public static IList<Attachment> GetInsertarTabla()
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
                 GetHeroCardV2(
                    "Como agregar tablas a mensajes en Outlook",
                    "Se aplica a: Outlook 2016 Outlook 2013 Outlook 2010",
                    "Si ha intentado alguna vez alinear filas y columnas de texto manualmente con espacios, sabrá lo frustrante que puede ser.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Agregar-una-tabla-a-un-mensaje-59766ab4-0fe5-4520-ba0b-e34f8b8cd025")),
                  GetHeroCardV2(
                    "Insertar o dibujar una tabla",
                    "Se aplica a: Word",
                    "Para insertar rápidamente una tabla básica, haga clic en Insertar > Tabla y mueva el cursor sobre la cuadrícula " +
                    "hasta que haya resaltado el número de columnas y filas que desee.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/insertar-o-dibujar-una-tabla-a138f745-73ef-4879-b99a-2f3d38be612a?ui=es-ES&rs=es-ES&ad=ES")),
                  GetHeroCardV2(
                    "Crear o eliminar una tabla de Excel",
                    "Se aplica a: Excel",
                    "Cuando se crea una tabla, se obtiene filtrado integrado, ordenación, sombreado de fila mediante filas con bandas " +
                    "y la posibilidad de usar diferentes fórmulas en una fila de totales.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/crear-o-eliminar-una-tabla-de-excel-e81aa349-b006-4f8a-9806-5af9df0ac664")),
                  GetHeroCardV2(
                    "Agregar una tabla a una diapositiva",
                    "Se aplica a: PowerPoint 2016 PowerPoint 2013 PowerPoint 2010",
                    " Puede crear y aplicar formato a una tabla en PowerPoint, copiar y pegar una tabla desde Word, copiar y pegar un grupo de " +
                    "celdas desde Excel o insertar una hoja de cálculo Excel en la presentación de PowerPoint.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Agregar-una-tabla-a-una-diapositiva-34f106c9-5320-4b89-9129-806e64b258ac")),
            };
        }

        // Agregar un encabezado o pie de página Word / Power Point
        public static IList<Attachment> GetAgregarEncabezadoPiePaginaWordPowerPoint()
        {
            return new List<Attachment>()
            {
                 GetHeroCardV2(
                    "Agregar un encabezado o pie de página",
                    "Se aplica a: Word",
                    "Agregue títulos, números de página o fechas a todas las páginas de un documento con encabezados y pies de página.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/agregar-un-encabezado-o-pie-de-p%C3%A1gina-b87ee4df-abc1-41f8-995b-b39f6d99c7ed?ui=es-ES&rs=es-HN&ad=PE")),
                 GetHeroCardV2(
                    "Agregar un encabezado o pie de página a documentos o notas",
                    "Se aplica a: PowerPoint 2016 PowerPoint 2013 PowerPoint 2010 PowerPoint 2007",
                    "En PowerPoint, notas y documentos tiene encabezados y pies de página. Diapositivas tienen sólo pies de página.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/agregar-un-encabezado-o-pie-de-p%C3%A1gina-a-documentos-o-notas-882efcea-35cd-4b68-ac0b-041ae1ba7099?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Agregar firma a los mensajes Outlook
        // Agregar o quitar una firma digital en archivos de Office
        public static IList<Attachment> GetAgregarFirma()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Agregar o quitar una firma digital en archivos de Office",
                    "Se aplica a: Excel 2016, Word 2016, PowerPoint 2016, Word Starter 2010",
                    "En este artículo se explican las firmas digitales , para qué se puede usar y cómo se pueden usar " +
                    "firmas digitales en los siguientes programas de Microsoft Office: Word, Excel y PowerPoint.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Agregar-o-quitar-una-firma-digital-en-archivos-de-Office-70d26dc9-be10-46f1-8efa-719c8b3f1a2d#__toc311526848")),
                GetVideoCard(
                    "Agregar una firma a los mensajes en Outlook",
                    "Ver cómo hacerlo",
                    "https://videocontent.osi.office.net/f6ae6849-cbd6-4863-a3c5-546e90246c45/dcb8a228-ebbc-47fe-a315-d62959b5de1a_1280x720_3400.mp4",
                    "https://support.office.com/es-es/article/Crear-y-agregar-una-firma-a-los-mensajes-8ee5d4f4-68fd-464a-a1c1-0e1c80bb27f2#ID0EAABAAA=2016,_2013"),

            };
        }

        // Agregar texto a una diapositiva - Power Point
        // Inserta texto automáticamente -  Word
        public static IList<Attachment> GetAgregarTextoWordPowerPoint()
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
                GetHeroCardV2(
                    "Inserta texto automáticamente",
                    "Se aplica a: Word 2016 Word 2013 Word 2010 Word 2007",
                    "En Word, puede insertar texto automáticamente con ambos bloques de texto con formato previo desde la Galería "+
                    "de Autotexto o con palabras, frases y oraciones que Word completa automáticamente después de que ha escrito "+
                    "solamente algunos caracteres.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/inserta-texto-autom%C3%A1ticamente-0bc40cab-f49c-4e06-bcb2-cd43c1674d1b?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Insertar y reproducir un archivo de vídeo
        // Inserte vídeos en línea en OneNote para Windows 10
        public static IList<Attachment> GetInsertarArchivoVideoPowerPointOneNote()
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
                GetHeroCardV2(
                    "Inserte vídeos en línea en OneNote",
                    "Se aplica a: OneNote para Windows 10",
                    "Agregar vídeos a las notas es una excelente forma de crear los blocs de notas interactivas " +
                    "que puede compartir con o distribuir a otras personas.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/inserte-v%C3%ADdeos-en-l%C3%ADnea-en-onenote-para-windows-10-bea22b6e-04dc-4f3d-a04b-bdeb26f3f522?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Insertar una marca de agua en Word
        public static IList<Attachment> GetAgregarMarcaAguaWordPowerPoint()
        {
            return new List<Attachment>()
            {
                 GetHeroCardV2(
                    "Insertar una marca de agua en Word",
                    "Se aplica a: Word 2016 Word 2013 Word 2010 Word 2007",
                    "Las marcas de agua son texto o imágenes que se colocan detrás del texto en el documento. Puede agregar " +
                    "marcas de agua de texto, como Borrador o Confidencial, al documento.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/insertar-una-marca-de-agua-en-word-f90f26a5-2101-4a75-bbfe-f27ef05002de")),

                GetHeroCardV2(
                    "Agregar una marca de agua 'BORRADOR' al fondo de las diapositivas",
                    "Se aplica a: PowerPoint 2016 PowerPoint 2013 PowerPoint 2010 PowerPoint 2007",
                    "PowerPoint no tiene una galería de marcas de agua prediseñadas como Word, pero puede agregar de forma manual"+
                    " un fondo del texto en las diapositivas para obtener el efecto de marca de agua.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/agregar-una-marca-de-agua-borrador-al-fondo-de-las-diapositivas-ea4cc5f5-ea5d-4213-9c7d-ed01a7952ed0?ui=es-ES&rs=es-ES&ad=ES#OfficeVersion-WaterTxt=2016,_2013")),
                };
        }

        //---------- COLABORAR ----------
        // Colaborar en documentos de Word con coautoría en tiempo real 
        // Trabajar o colaborar de manera conjunta en documentos de Office en OneDrive
        public static IList<Attachment> GetTrabajarManeraConjunta()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Colaborar en documentos de Word con coautoría en tiempo real",
                    "Se aplica a: Word 2016, Word para Mac, Word Online, Word para iPad, Word para iPhone, Word para teléfonos y tabletas Android",
                    "Si usted y sus compañeros desean colaborar en un documento, use la coautoría en tiempo real para ver los cambios " +
                    "de todos los usuarios al mismo tiempo que se producen. La colaboración es un proceso simple de tres pasos:",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/colaborar-en-documentos-de-word-con-coautor%C3%ADa-en-tiempo-real-7dd3040c-3f30-4fdd-bab0-8586492a1f1d?ui=es-ES&rs=es-ES&ad=ES")),
                GetHeroCardV2(
                    "Trabajar de manera conjunta en documentos de Office en One Drive",
                    "Se aplica a: Excel Online, Word Online, PowerPoint Online, OneNote Online, Office.com",
                    "Con Office Online puede enviar vínculos a documentos en lugar de enviar datos adjuntos. De este modo, ahorrará " +
                    "almacenamiento de correo electrónico y evitará tener que conciliar varias versiones del mismo documento.",
                    new CardAction(ActionTypes.OpenUrl, "Ver información",
                    value: "https://support.office.com/es-es/article/trabajar-de-manera-conjunta-en-documentos-de-office-en-onedrive-ea3807bc-2b73-406f-a8c9-a493de18258b")),
            };
        }

        //----------- AJUSTAR -----------
        // Ajustar la sangría y el espaciado Word / Outlook
        public static IList<Attachment> GetAjustarSangriaEspaciado()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Ajustar la sangría y el espaciado",
                    "Se aplica a: Word 2016, Outlook 2016, Word 2013, Outlook 2013",
                    "Puede cambiar la sangría, la distancia del párrafo desde el margen izquierdo o derecho, y el espaciado en el documento.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Ajustar-la-sangr%C3%ADa-y-el-espaciado-36239d98-14c5-411e-a880-1ddf25d65cd6")),
            };
        }

        //------------ CREAR ------------
        // Crear una tabla de contenido en Word
        // Crear tabla en Excel
        public static IList<Attachment> GetCrearTabla()
        {
            return new List<Attachment>()
            {
                 GetHeroCardV2(
                    "Crear una tabla de contenido en Word",
                    "Se aplica a: Word 2016, Word 2013, Word 2010, Word 2007",
                    "Para crear una tabla de contenido, en primer lugar, necesitará aplicar los estilos de título al texto que desea " +
                    "incluir en dicha tabla. Luego, **Word** la generará automáticamente a partir de esos títulos.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Crear-una-tabla-de-contenido-en-Word-882e8564-0edb-435e-84b5-1d8552ccf0c0")),

                GetHeroCardV2(
                    "Crear o eliminar una tabla de Excel",
                    "Se aplica a: Excel",
                    "Cuando se crea una tabla en una hoja de cálculo de Excel, se obtiene filtrado integrado, ordenación, sombreado de " +
                    "fila mediante filas con bandas y la posibilidad de usar diferentes fórmulas en una fila de totales.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/crear-o-eliminar-una-tabla-de-excel-e81aa349-b006-4f8a-9806-5af9df0ac664")),
            };
        }

        //------------ USAR -------------
        // Usar una fórmula en una tabla de Word o de Outlook
        public static IList<Attachment> GetUsarFormulaWordOutlook()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Usar una fórmula en una tabla de Word o de Outlook",
                    "Se aplica a: Word 2016 Outlook 2016 Word 2013 Outlook 2013",
                    "Seleccione la celda de la tabla donde desee mostrar los resultados.\r\r"+
                    "E inserte el comando **Fórmula** que se encuentra en la pestaña **Diseño** en **Herramientas de tabla**, en el grupo **Datos**.\r\r"+
                    "![duck](https://support.content.office.net/es-es/media/28bc04f3-5a31-457c-b4d4-437b3581d341.jpg)",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/usar-una-f%C3%B3rmula-en-una-tabla-de-word-o-de-outlook-cbd0596e-ea8a-485e-a35d-b2cb2c4f3e27")),
                };
        }

        // Usar fórmulas en Excel
        // Usar una fórmula en una tabla de Word o de Outlook
        public static IList<Attachment> GetUsarFormulaWordOutlookExcel()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Información general sobre fórmulas en Excel",
                    "Se aplica a: Excel 2016 Excel 2013 Excel 2010 Excel 2007",
                    "En excel una fórmula siempre empieza con un signo igual (=), que puede ir seguido de números, operadores matemáticos (como los signos + o - "+
                    "para sumar o restar) y funciones integradas de **Excel**, que pueden ampliar el poder de una fórmula.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/informaci%C3%B3n-general-sobre-f%C3%B3rmulas-en-excel-ecfdc708-9162-49e8-b993-c311f47ca173")),

                GetHeroCardV2(
                    "Usar una fórmula en una tabla de Word o de Outlook",
                    "Se aplica a: Word 2016 Outlook 2016 Word 2013 Outlook 2013",
                    "Seleccione la celda de la tabla donde desee mostrar los resultados.\r\r"+
                    "E inserte el comando **Fórmula** que se encuentra en la pestaña **Diseño** en **Herramientas de tabla**, en el grupo **Datos**.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/usar-una-f%C3%B3rmula-en-una-tabla-de-word-o-de-outlook-cbd0596e-ea8a-485e-a35d-b2cb2c4f3e27")),
                };
        }

        //---------- COMPARTIR ----------
        public static IList<Attachment> GetCompartirArchivos()
        {
            return new List<Attachment>()
            {
            GetHeroCardV2(
                    "Compartir el documento en Word 2016 para Windows",
                    "Se aplica a: Word 2016",
                    "Al compartir sus archivos mediante OneDrive o SharePoint Online para Office 365, puede invitar a personas para el " +
                    "documento directamente desde Word o enviar un archivo PDF o Word como datos adjuntos de correo electrónico.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Compartir-el-documento-en-Word-2016-para-Windows-d39f3cd8-0aa0-412f-9a35-1abba926d354")),
            GetHeroCardV2(
                    "Compartir el libro de Excel",
                    "Se aplica a: Excel 2016 Excel 2016 para Mac",
                    "Compartir los libros con otras personas resulta más fácil que nunca con Excel.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/compartir-el-libro-de-excel-con-otros-usuarios-8d8a52bb-03c3-4933-ab6c-330aabf1e589?ui=es-ES&rs=es-ES&ad=ES")),
            GetHeroCardV2(
                    "Compartir la presentación de PowerPoint 2016",
                    "Se aplica a: PowerPoint 2016",
                    "Al compartir una presentación con OneDrive u Office 365 SharePoint, puede hacer todo su uso compartido desde PowerPoint.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/compartir-la-presentaci%C3%B3n-de-powerpoint-2016-con-otros-usuarios-a6308d9d-a0a8-443b-8e1c-0f4983f0afd1")),
            GetHeroCardV2("Compartir archivos y carpetas en One Drive",
                "Se aplica a: OneDrive",
                "Los archivos y carpetas que almacene en OneDrive son privados hasta que decida compartirlos. Asimismo, puede " +
                "[dejar de compartirlos](https://support.office.com/es-es/article/dejar-de-compartir-archivos-o-carpetas-de-onedrive-o-cambiar-los-permisos-0a36470f-d7fe-40a0-bd74-0ac6c1e13323?ui=es-ES&rs=es-ES&ad=ES) en cualquier momento.",
                new CardAction(ActionTypes.OpenUrl, "Ver más información",
                value: "https://support.office.com/es-es/article/compartir-archivos-y-carpetas-de-onedrive-9fcc2f7d-de0c-4cec-93b0-a82024800c07")),

            };
        }

        //---------- ELIMINAR -----------
        // Eliminar comentarios POWERPOINT / WORD
        public static IList<Attachment> GetEliminarComentarios()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Realizar un seguimiento de los cambios en Word",
                    "Se aplica a: Word 2016",
                    "Cuando desee ver quién ha realicen cambios en el documento, active la característica control de cambios. También " +
                    "puede elegir qué cambios aceptar o rechazar y puede ver y eliminar comentarios.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/quitar-los-cambios-realizados-y-los-comentarios-en-word-2016-para-windows-7966b497-7e04-4a13-8d41-53a3ffa00c25?ui=es-ES&rs=es-ES&ad=ES")),
                GetHeroCardV2(
                    "Agregar, cambiar, ocultar o eliminar comentarios en una presentación",
                    "Se aplica a: PowerPoint 2016 PowerPoint 2013 PowerPoint 2010 PowerPoint 2007",
                    "El Panel de comentarios es la manera más rápida de editar, ocultar o eliminar los comentarios en la presentación.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/agregar-cambiar-ocultar-o-eliminar-comentarios-en-una-presentaci%C3%B3n-a8f071fa-6e5d-4c37-a025-1cf48a76eb38?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Quitar una marca de agua Word
        // Quitar una marca de agua transparente de las diapositivas
        public static IList<Attachment> GetQuitarMarcaAgua()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Eliminar o cambiar un encabezado o pie de página de una sola página",
                    "Se aplica a: Word",
                    "Puede quitar una marca de agua de un documento si lo desea.\r\r"+
                    ">1. Abra el documento donde quiera quitar la marca de agua.\r\r"+
                    ">2. Vaya a la pestaña **Diseño** y, en el grupo **Fondo de página**, seleccione **Marca de agua**.\r\r"+
                    ">3. Seleccione **Quitar marca de agua**.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/quitar-una-marca-de-agua-636cc588-489d-46c4-a03f-07f3f4820029?ui=es-ES&rs=es-HN&ad=PE")),
                GetHeroCardV2(
                    "Quitar una marca de agua transparente de las diapositivas",
                    "Se aplica a: PowerPoint",
                    "Siga los siguientes pasos:\r\r"+
                    ">1. Haga clic en la pestaña **Vista** y luego en **Patrón de diapositivas**.\r\r"+
                    ">2. Haga clic en el patrón o diseño de diapositivas que contenga la marca de agua.\r\r"+
                    ">3. En la diapositiva, seleccione la imagen que quiere quitar y presione **Eliminar**.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Quitar-una-marca-de-agua-transparente-de-las-diapositivas-44f576d2-4e06-498c-9930-1b1dbd878ae2")),
            };
        }

        // Quitar formato condicional Excel
        // Borrar todo el formato de texto PowerPoint y Word
        public static IList<Attachment> GetBorrarFormatoWordExcel()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Quitar formato condicional",
                    "Se aplica a: Excel 2016 Excel 2013",
                    "Siga los siguientes pasos:\r\r"+
                    ">1. Seleccione el rango de celdas.\r\r"+
                    ">2. Haga clic en el botón **Lente de análisis rápido** ![duck](https://support.content.office.net/es-es/media/d569b32d-d9c4-4676-b46e-ee17543dd843.jpg).\r\r"+
                    ">3. Haga clic en **Borrar formato**.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Quitar-formato-condicional-a3a74584-96fe-44ea-8a84-e726ce81094b")),
                GetHeroCardV2(
                    "Borrar todo el formato de texto",
                    "Se aplica a: Word 2016 Outlook 2016 PowerPoint 2016 OneNote 2016 Publisher 2016",
                    "Puede borrar fácilmente todo el formato (como el formato de negrita, subrayado, cursiva, color, superíndice, subíndice, etc.) " +
                    "del texto y restablecer el texto a sus estilos de formato predeterminados.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Borrar-todo-el-formato-de-texto-c094c4da-7f09-4cea-9a8d-c166949c9c80")),
            };
        }

        //----------- CARDS DE CONSULTA -------------
        //-------------------------------------------
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

        public static IList<Attachment> GetConsultaV3()
        {
            return new List<Attachment>()
            {
                GetCardConsulta(
                    "",
                    "Consulta"),
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

    }
}