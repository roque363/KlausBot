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

        // Crear y guardar una plantilla de PowerPoint
        public static IList<Attachment> GetCrearGuardarPlantillaPowerPoint()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Crear y guardar una plantilla de PowerPoint",
                    "Se aplica a: PowerPoint 2016 PowerPoint 2013 PowerPoint 2010 PowerPoint 2007",
                    "Siga los siguientes pasos:\r\r"+
                    ">1. Abra una presentación en blanco y, luego, en la pestaña **Vista**, en el grupo **Vistas Patrón**, seleccione **Patrón de diapositivas**.\r\r"+
                    ">2. En la pestaña **Patrón de diapositivas**, haga clic en **Temas** y elija uno.\r\r"+
                    ">3. Haga clic en **Insertar marcador de posición** y seleccione el tipo de marcador que quiere agregar.\r\r"+
                    ">4. Complete todos los cambios que desea realizar para crear su plantilla y guardelo.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Crear-y-guardar-una-plantilla-de-PowerPoint-ee4429ad-2a74-4100-82f7-50f8169c8aca")),
            };
        }

        //--------- APLICAR ---------
        //---------------------------
        // Aplicar una plantilla a una presentación
        public static IList<Attachment> GetAplicarPlantillaPresentacion()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Aplicar una plantilla a una presentación",
                    "Se aplica a: PowerPoint 2016 PowerPoint 2013 PowerPoint 2010 PowerPoint 2007 ",
                    "Siga los siguientes pasos:\r\r"+
                    ">1. En PowerPoint, haga clic en **archivo** y, a continuación, haga clic en **nuevo**.\r\r"+
                    ">2. Haga clic en **portada** y elija una plantilla para usar.\r\r"+
                    ">3. Haga clic en **Crear**.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Aplicar-una-plantilla-a-una-presentaci%C3%B3n-d3d4ece5-e965-45eb-9423-c34e61b34616")),

            };
        }

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

        //--- AGREGAR / INSERTAR ----
        //---------------------------
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

        // Agregar una tabla a una diapositiva
        public static IList<Attachment> GetAgregarTablaDiapositiva()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Agregar una tabla a una diapositiva",
                    "Se aplica a: PowerPoint 2016 PowerPoint 2013 PowerPoint 2010",
                    "Crear una tabla:\r\r"+
                    ">1. En la pestaña **Insertar**, seleccione **Tabla**.\r\r"+
                    ">2. Haga clic en **Insertar tabla** y escriba un número en las listas **Número de columnas** y **Número de filas**.\r\r"+
                    ">3. Haga clic en **Aceptar**",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Agregar-una-tabla-a-una-diapositiva-34f106c9-5320-4b89-9129-806e64b258ac")),
            };
        }

        // Agregar un hipervínculo a una diapositiva
        public static IList<Attachment> GetAgregarHipervinculoDiapositiva()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Agregar un hipervínculo a una diapositiva",
                    "Se aplica a: PowerPoint 2016 PowerPoint 2013",
                    "Puede agregar hipervínculos a una presentación para realizar una amplia variedad de cosas. Puede usar vínculos "+
                    "para acceder a otro lugar de la presentación rápidamente, abrir una presentación diferente o ir a un página web.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Agregar-un-hiperv%C3%ADnculo-a-una-diapositiva-239c6c94-d52f-480c-99ae-8b0acf7df6d9")),
            };
        }

        // Agregar un comentario de revisión
        public static IList<Attachment> GetAgregarComentariosRevision()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Agregar un comentario de revisión",
                    "Se aplica a: PowerPoint 2010",
                    "Cómo agregar comentarios en Power Point:\r\r"+
                    ">1. Seleccione el texto o el objeto o haga clic sobre una diapositiva\r\r"+
                    ">2. En la ficha **Revisar** en el grupo **Comentarios**, haga clic en **Nuevo comentario**.\r\r"+
                    ">3. Escriba los comentarios",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/revisi%C3%B3n-mostrar-revisiones-y-agregar-comentarios-9dacc2d3-0d0e-4ccf-a248-723689a1e8a7")),
            };
        }

        // Agregar una marca de agua "BORRADOR" al fondo de las diapositivas
        public static IList<Attachment> GetAgregarMarcaAguaDiapositivas()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Agregar una marca de agua 'BORRADOR' al fondo de las diapositivas",
                    "Se aplica a: PowerPoint 2016 PowerPoint 2013 PowerPoint 2010 PowerPoint 2007",
                    "PowerPoint no tiene una galería de marcas de agua prediseñadas como Word, pero puede agregar de forma manual"+
                    " un fondo del texto en las diapositivas para obtener el efecto de marca de agua.\r\r"+
                    ">![duck](https://support.content.office.net/es-es/media/b26111db-6b12-4332-ac2f-a14f45cef359.png)",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/agregar-una-marca-de-agua-borrador-al-fondo-de-las-diapositivas-ea4cc5f5-ea5d-4213-9c7d-ed01a7952ed0?ui=es-ES&rs=es-ES&ad=ES#OfficeVersion-WaterTxt=2016,_2013")),
            };
        }

        // Agregar color y diseños a Mis diapositivas con temas
        public static IList<Attachment> GetAgregarColorDiapositivas()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Agregar color y diseños a Mis diapositivas con temas",
                    "Se aplica a: PowerPoint 2016 PowerPoint 2013",
                    "Elegir un tema al abrir PowerPoint\r\r"+
                    ">1. Seleccione un tema.\r\r"+
                    ">![duck](https://support.content.office.net/es-es/media/b03b54a4-c861-4ea6-b847-4e8d0ec15565.png)\r\r"+
                    ">2. Elija una variación de color y haga clic en **Crear**.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/agregar-color-y-dise%C3%B1os-a-mis-diapositivas-con-temas-a54d6866-8c32-4fbc-b15d-6fcc4bd1edf6?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Agregar una diapositiva nueva
        public static IList<Attachment> GetAgregarDiapositivas()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Agregar una diapositiva nueva",
                    "Se aplica a: PowerPoint 2016 PowerPoint 2013 PowerPoint 2010 PowerPoint 2007",
                    "Agregar una diapositiva nueva:\r\r"+
                    ">1. En la pestaña **Vista**, haga clic en **Normal**.\r\r"+
                    ">2. Haga clic en la diapositiva detrás de la cual desea insertar la nueva diapositiva.\r\r"+
                    ">3. En la pestaña **Inicio**, haga clic en **Nueva diapositiva**.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/agregar-reorganizar-duplicar-y-eliminar-diapositivas-en-powerpoint-e35a232d-3fd0-4ee1-abee-d7d4d6da92fc?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Agregar una transición a una diapositiva
        public static IList<Attachment> GetAgregarTransicionesDiapositivas()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Agregar una transición a una diapositiva",
                    "Se aplica a: PowerPoint 2016 para Mac PowerPoint 2011 para Mac",
                    "Elegir un tema al abrir PowerPoint\r\r"+
                    ">1. En el panel Miniaturas, haga clic en la diapositiva a la que desea aplicar una transición."+
                    ">2. En la pestaña **Transiciones**, busque el efecto que más le guste y haga clic sobre él.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/agregar-editar-o-quitar-transiciones-entre-diapositivas-en-powerpoint-para-mac-937604f5-93f8-4f96-9232-8d55d7f0bead")),
            };
        }

        // Agregar o eliminar audio en una presentación de PowerPoint
        public static IList<Attachment> GetAgregarAudioPresentacion()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Agregar una transición a una diapositiva",
                    "Se aplica a: PowerPoint 2016 para Mac PowerPoint 2011 para Mac",
                    "Siga los siguientes pasos:\r\r"+
                    ">1. En la pestaña **Insertar** en el grupo **Multimedia**, haga clic en **Audio**."+
                    ">2. En la lista, haga clic en **Audio en mi PC**, busque y seleccione el clip de audio que quiere y, después, haga clic en **Insertar**.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/agregar-o-eliminar-audio-en-una-presentaci%C3%B3n-de-powerpoint-c3b2a9fd-2547-41d9-9182-3dfaa58f1316?ui=es-ES&rs=es-ES&ad=ES#OfficeVersion=2013,_2016")),
            };
        }

        // Agregar notas del orador a las diapositivas
        public static IList<Attachment> GetAgregarNotasOradorDiapositivas()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Agregar notas del orador a las diapositivas",
                    "Se aplica a: PowerPoint 2016 PowerPoint 2013 PowerPoint Online",
                    "Puede agregar notas que pueden ser consultadas más adelante mientras realiza una presentación con diapositivas a una audiencia."+
                    "El **panel Notas** es el lugar para almacenar información adicional que no necesita estar en la diapositiva.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Agregar-notas-del-orador-a-las-diapositivas-26985155-35f5-45ba-812b-e1bd3c48928e")),
            };
        }

        //--------- ANIMAR ----------
        //---------------------------
        // Animar texto u objetos
        public static IList<Attachment> GetAnimarTextoObjetosPowerPoint()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Animar texto u objetos",
                    "Se aplica a: PowerPoint 2016 PowerPoint 2013 PowerPoint 2010 PowerPoint 2007",
                    "Siga los siguientes pasos:\r\r"+
                    ">1. Selecciona el objeto o texto de la diapositiva que quieras animar.\r\r"+
                    ">2. En la pestaña **Animaciones** de la cinta, haga clic en **Agregar animación** y elija un efecto de animación.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Animar-texto-u-objetos-305a1c94-83b1-4778-8df5-fcf7a9b7b7c6")),
               };
        }

        // Animar un conjunto de objetos como un grupo
        public static IList<Attachment> GetAnimarConjuntoObjetosPowerPoint()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Animar un conjunto de objetos como un grupo",
                    "Se aplica a: PowerPoint 2016 PowerPoint 2013",
                    "Siga los siguientes pasos:\r\r"+
                    ">1. Mantenga presionada la tecla **Ctrl** y haga clic en todos los objetos que quiera animar conjuntamente\r\r"+
                    ">2. Haga clic derecho sobre los objetos seleccionados y después haga clic en **Agrupar**.\r\r"+
                    ">3. En la pestaña **Animación**, haga clic en el efecto de animación que desee aplicar al grupo",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Animar-un-conjunto-de-objetos-como-un-grupo-69f4fa42-b7eb-4381-8042-c3a20e0611bb")),
               };
        }

        // Animar una imagen de la diapositiva
        public static IList<Attachment> GetAnimarImagenDiapositiva()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Animar una imagen de la diapositiva",
                    "Se aplica a: PowerPoint Online ",
                    "Siga los siguientes pasos:\r\r"+
                    ">1. Seleccione una imagen.\r\r"+
                    ">2. En la pestaña **Animaciones**, elija un efecto de animación.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Animar-una-imagen-de-la-diapositiva-23334c65-c38d-407e-9fa4-e13a994bb098")),
               };
        }

        // Cómo puedo animar celdas, filas o columnas individuales de una tabla
        public static IList<Attachment> GetAnimarCeldasFilasColumenasTabla()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Animar una imagen de la diapositiva",
                    "Se aplica a: PowerPoint 2016 PowerPoint 2013 PowerPoint 2010 PowerPoint 2007",
                    "El proceso implica cambiar la tabla a un conjunto de objetos dibujados que luego se pueden 'desagrupar' y animar por separado.\r\r"+
                    "![duck](https://support.content.office.net/es-es/media/1ad81923-bb3b-4cb2-bf47-052f33f2e805.png)",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/c%c3%b3mo-puedo-animar-celdas-filas-o-columnas-individuales-de-una-tabla-a161e49c-3801-4385-95b4-de84253593d1?ui=es-ES&rs=es-ES&ad=ES")),
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

        //--- CAMBIAR / MODIFICAR ---
        //---------------------------
        // Modificar o responder a un comentario
        public static IList<Attachment> GetModificarComentarioPowerPoint()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Modificar o responder a un comentario",
                    "Se aplica a: PowerPoint 2016 PowerPoint 2013 PowerPoint 2010 PowerPoint 2007",
                    "Use el **panel Comentarios** para modificar los comentarios agregados.\r\r"+
                    ">* Haga clic en el texto del comentario que desea modificar.\r\r"+
                    ">* Se abrirá un cuadro de entrada de texto con el comentario.\r\r"+
                    ">* Realice los cambios oportunos y haga clic fuera del cuadro de comentarios para finalizar.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/agregar-cambiar-ocultar-o-eliminar-comentarios-en-una-presentaci%C3%B3n-a8f071fa-6e5d-4c37-a025-1cf48a76eb38")),
               };
        }

        // Cambiar el color de fondo de las diapositivas
        public static IList<Attachment> GetCambiarColorFondoDiapositivas()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Cambiar el color de fondo de las diapositivas",
                    "Se aplica a: PowerPoint 2016 PowerPoint 2013 PowerPoint 2010 PowerPoint 2007",
                    "Si decide que quiere agregar más contraste entre el fondo y el texto en las diapositivas, puede cambiar los colores de"+
                    " fondo a otro color sólido o degradado. Dar formato a los colores y el fondo de las diapositivas es una forma adecuada"+
                    " de generar interés visual.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Cambiar-el-color-de-fondo-de-las-diapositivas-3ac2075c-f51b-4fbd-b356-b4c6748ec966#OfficeVersion-BkgdColor=2016,_2013")),
               };
        }

        // Cambiar el tamaño de las diapositivas
        public static IList<Attachment> GetCambiarTamanoDiapositivas()
        {
            return new List<Attachment>()
            {
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

        // Cambiar el orden de reproducción de los efectos de animación
        public static IList<Attachment> GetCambiarOrdenReproduccionEfectosAnimacion()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Cambiar el orden de reproducción de los efectos de animación",
                    "Se aplica a: PowerPoint 2016 PowerPoint 2013",
                    "Si los efectos de animación no se reproducen en la secuencia que desea, puede reorganizar el orden.\r\r"+
                    ">1. Haga clic en el objeto de la diapositiva con los efectos de animación que desee cambiar.\r\r"+
                    ">2. En la pestaña **Animaciones**, haga clic en **Panel de animación**.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Cambiar-el-orden-de-reproducci%C3%B3n-de-los-efectos-de-animaci%C3%B3n-f41984c7-c5a6-4120-af1e-5208cf4295b4")),
               };
        }

        // Cambiar un efecto de animación
        public static IList<Attachment> GetCambiarEfectoAnimacion()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Cambiar un efecto de animación",
                    "Se aplica a: PowerPoint 2016 PowerPoint 2013 PowerPoint 2010 PowerPoint 2007",
                    "Siga los siguientes pasos:\r\r"+
                    ">1. Seleccione el objeto que tiene el efecto de animación que desea cambiar.\r\r"+
                    ">2. En la ficha **animaciones**, en el grupo **animación**, haga clic en el botón "+
                    "![duck](https://support.content.office.net/es-es/media/cf59dbdd-98bc-400e-a84b-4483044bf700.jpg) **más** y, a continuación, seleccione la nueva animación que desee.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/cambiar-o-quitar-un-efecto-de-animaci%C3%B3n-fb8a3ab0-f651-45e0-b5f0-b18ba2e7c711?ui=es-ES&rs=es-ES&ad=ES")),
               };
        }

        //--------- ELIMINAR --------
        //---------------------------
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

        // Quitar una marca de agua transparente de las diapositivas
        public static IList<Attachment> GetQuitarMarcaAguaDiapositivas()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Quitar una marca de agua transparente de las diapositivas",
                    "Se aplica a: PowerPoint 2016 PowerPoint 2013",
                    "Siga los siguientes pasos:\r\r"+
                    ">1. Haga clic en la pestaña **Vista** y luego en **Patrón de diapositivas**.\r\r"+
                    ">2. Haga clic en el patrón o diseño de diapositivas que contenga la marca de agua.\r\r"+
                    ">3. En la diapositiva, seleccione la imagen que quiere quitar y presione **Eliminar**.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Quitar-una-marca-de-agua-transparente-de-las-diapositivas-44f576d2-4e06-498c-9930-1b1dbd878ae2")),
            };
        }

        // Borrar todo el formato de texto
        public static IList<Attachment> GetBorrarFormatoTexto()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Borrar todo el formato de texto",
                    "Se aplica a: Word 2016 Outlook 2016 PowerPoint 2016 OneNote 2016 Publisher 2016",
                    "Siga los siguientes pasos:\r\r"+
                    ">1. Seleccione el texto que desea restablecer a su formato predeterminado.\r\r"+
                    ">2. En el grupo **Fuente** de la ficha **Inicio**, haga clic en **Borrar todo el formato**.\r\r"+
                    "![duck](https://support.content.office.net/es-es/media/bccd741c-5245-4291-9495-81e1320160f0.png).",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Borrar-todo-el-formato-de-texto-c094c4da-7f09-4cea-9a8d-c166949c9c80")),
            };
        }

        // Quitar un efecto de animación
        public static IList<Attachment> GetQuitarEfectoAnimacion()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Quitar un efecto de animación",
                    "Se aplica a: PowerPoint 2016 PowerPoint 2013 PowerPoint 2010 PowerPoint 2007",
                    "Siga los siguientes pasos:\r\r"+
                    ">1. En la pestaña de la **animación**, haga clic en **Panel de animación**.\r\r"+
                    ">2. Haga clic en el efecto animado y en el **Panel de animación**, haga clic en el efecto que desea quitar, haga clic en la flecha abajo y, a continuación, haga clic en **Quitar**.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/cambiar-o-quitar-un-efecto-de-animaci%C3%B3n-fb8a3ab0-f651-45e0-b5f0-b18ba2e7c711?ui=es-ES&rs=es-ES&ad=ES#__toc242245221&OfficeVersion=2016,_2013")),
            };
        }

        // Eliminar diapositivas en PowerPoint
        public static IList<Attachment> GetEliminarDiapositivas()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Eliminar diapositivas en PowerPoint",
                    "Se aplica a: PowerPoint 2016 PowerPoint 2013 PowerPoint 2010",
                    "En el panel de la izquierda, haga clic con el botón derecho en la miniatura de diapositiva que quiere eliminar (mantenga presionada la tecla"+
                    " CTRL para seleccionar varias diapositivas o mantenga presionada MAYÚS para seleccionar varias diapositivas seguidas) y, después, haga clic en **Eliminar diapositiva**.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/agregar-reorganizar-duplicar-y-eliminar-diapositivas-en-powerpoint-e35a232d-3fd0-4ee1-abee-d7d4d6da92fc")),
            };
        }

        //--------- GUARDAR ---------
        //---------------------------
        // Guardar y compartir una presentación en OneDrive
        public static IList<Attachment> GetGuardarCompartirPresentacionOneDrive()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Guardar y compartir una presentación en OneDrive",
                    "Se aplica a: PowerPoint 2016 PowerPoint 2013",
                    "Primero debe tener una cuenta de Microsoft\r\r"+
                    ">1. [Inicie sesión](https://onedrive.live.com/about/es-ES/) en OneDrive con la cuenta Microsoft.\r\r"+
                    ">2. Haga clic en **Archivo** > **Guardar como** > **Agregar un sitio** > **OneDrive**.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Guardar-y-compartir-una-presentaci%C3%B3n-en-OneDrive-cdbec569-a18f-4bdc-92e8-d07a8ab5eb95")),
               };
        }

        // Guardar una plantilla
        public static IList<Attachment> GetGuardarPlantillaPowerPoint()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Guardar una plantilla en Power Point",
                    "Se aplica a: PowerPoint 2016",
                    "Siga los siguientes pasos:\r\r"+
                    ">1. Vaya a **Archivo** > **Guardar como**.\r\r"+
                    ">2. Elija **Este equipo** y guárdelo donde usted desee.\r\r"+
                    ">3. En la lista **Guardar como tipo**, seleccione **Plantilla de PowerPoint** y luego haga clic en **Guardar**.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/guardar-una-plantilla-y-a-continuaci%c3%b3n-aplicarlo-a-una-nueva-presentaci%c3%b3n-58788ba9-02d5-4156-b59e-8f81e0c98e4f?ui=es-ES&rs=es-ES&ad=ES")),
               };
        }

        //-------- IMPORTAR ---------
        //---------------------------
        // Volver a usar (importar) las diapositivas de oStra presentación
        public static IList<Attachment> GetImportarDiapositivasPresentacion()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Importar diapositivas",
                    "Se aplica a: PowerPoint 2016 PowerPoint 2013 PowerPoint 2010 PowerPoint 2007",
                    "Puede agregar una o varias diapositivas a la presentación a otra, sin tener que abrir otro archivo.\r\r"+
                    "Cuando se importa una diapositiva de una presentación a otra, se trata simplemente de una copia del original.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Volver-a-usar-importar-las-diapositivas-de-otra-presentaci%C3%B3n-c67671cd-386b-45dd-a1b4-1e656458bb86")),
               };
        }

        //---------- USAR -----------
        //---------------------------
        // Usar una plantilla en Power Point
        public static IList<Attachment> GetUsarPlantillaPowerPoint()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Usar una plantilla en Power Point",
                    "Se aplica a: Excel 2016 para Mac PowerPoint 2016 para Mac Word 2016 para Mac",
                    "Para iniciar una nueva presentación basada en una plantilla, en el menú **Archivo**, haga clic en"+
                    " **nuevo a partir de plantilla** y, a continuación, seleccione la plantilla que desee usar.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/crear-y-usar-su-propia-plantilla-en-office-para-mac-a1b72758-61a0-4215-80eb-165c6c4bed04?ui=es-ES&rs=es-ES&ad=ES")),
               };
        }

        // Usar varios temas en una presentación
        public static IList<Attachment> GetUsarTemasPresentacion()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Usar varios temas en una presentación",
                    "Se aplica a: PowerPoint 2016 PowerPoint 2013 PowerPoint 2010 PowerPoint 2007",
                    "Siga los siguientes pasos:\r\r"+
                    ">1. En la ficha **Vista**, haga clic en **Patrón de diapositivas**.\r\r"+
                    ">2. En la ficha **Patrón de diapositivas**, escoja **Insertar patrón de diapositivas** y elija un tema\r\r"+
                    ">3. Cuando haya terminado la selección, haga clic en **Cerrar vista patrón**.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Usar-varios-temas-en-una-presentaci%C3%B3n-a5648a47-1a8b-49a7-a031-23eba396ca81")),
               };
        }

        // Usar la transición de morfo en PowerPoint
        public static IList<Attachment> GetUsarTransicionMorfoPowerPoint()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Usar la transición de transformación en PowerPoint",
                    "Se aplica a: PowerPoint 2016 PowerPoint Online PowerPoint para tabletas Android",
                    "La transición de transformación le permite animar un movimiento suave de una diapositiva a la siguiente, "+
                    "además puede crear la apariencia del movimiento en una amplia gama de cosas: texto, formas, imágenes, SmartArt, WordArt y gráficos.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/usar-la-transici%c3%b3n-de-morfo-en-powerpoint-8dd1c7b2-b935-44f5-a74c-741d8d9244ea?ui=es-ES&rs=es-ES&ad=ES")),
                GetVideoCard(
                    "",
                    "",
                    "https://videocontent.osi.office.net/4161aec5-e388-46e7-b96b-5e6171b89e3a/9a3b66d5-2d10-4957-bb79-5ab68de9c6c1_1280x720_3400.mp4",
                    "https://support.office.com/es-es/article/usar-la-transici%c3%b3n-de-morfo-en-powerpoint-8dd1c7b2-b935-44f5-a74c-741d8d9244ea?ui=es-ES&rs=es-ES&ad=ES"),
            };
        }

        //-------- TRABAJAR ---------
        //---------------------------
        // Trabajar conjuntamente en presentaciones de PowerPoint
        public static IList<Attachment> GetTrabajarConjuntamentePresentacionesPowerPoint()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Trabajar conjuntamente en presentaciones de PowerPoint",
                    "Se aplica a: Power Point",
                    "Siga los siguientes pasos:\r\r"+
                    ">1. Haga clic en **Compartir** en la esquina superior derecha de la cinta de opciones.\r\r"+
                    ">2. En **Invitar asistentes** escriba la dirección de correo del usuario con el que quiere compartir la presentación"+
                    ">3. Haga clic en **Compartir**",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/trabajar-conjuntamente-en-presentaciones-de-powerpoint-0c30ee3f-8674-4f0e-97be-89cf2892a34d?ui=es-ES&rs=es-ES&ad=ES")),
               };
        }

        //------ VER / MOSTRAR ------
        //---------------------------
        // Mostrar información de pie de página en las diapositivas
        public static IList<Attachment> GetMostrarInformacionPiePaginaDiapositiva()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Mostrar información de pie de página en las diapositivas",
                    "Se aplica a: PowerPoint 2016 PowerPoint 2013",
                    "Los pies de página suelen estar en la parte inferior de las diapositivas. Pueden contener la fecha y la hora,"+
                    " números de diapositiva y otros tipos de texto como el título de la presentación o 'Información confidencial de la empresa'.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Mostrar-informaci%C3%B3n-de-pie-de-p%C3%A1gina-en-las-diapositivas-ba490a83-6d39-4aa5-bd3b-e676020d8b6c")),
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

    }
}