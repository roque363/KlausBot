using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using Microsoft.Bot.Connector;
namespace KlausBot.Util
{
    public class RespuestasWord
    {
        // -------------------------------------------------------------
        // PREGUNTAS DE WORD
        // -------------------------------------------------------------
        //-------- DEFINICION --------
        //----------------------------
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

        //--------- TRABAJAR ---------
        //----------------------------
        //Colaborar en documentos de Word con coautoría en tiempo real
        public static IList<Attachment> GetTrabajarCoAutoriaTiempoReal()
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
            };
        }

        //---------- COMBINAR --------
        //----------------------------
        //Combinar documentos
        public static IList<Attachment> GetCombinarDocumentosWord()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Combinar documentos",
                    "Se aplica a: Word 2016 Word 2013 Word 2010 Word 2007",
                    "Una vez que envíe un documento a revisar, puede que le devuelvan muchas copias con sugerencias y correcciones " +
                    "que no quiere omitir. Si se da el caso, combine todas estas ediciones e ideas en un documento.\r\r" +
                    "Si no va a compartir los documentos con otros usuarios, puede combinarlos mediante copiar y pegar.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/combinar-documentos-f8f07f09-4461-4376-b041-89ad67412cfe")),
            };
        }

        //Combinar correspondencia con una hoja de cálculo de Excel
        public static IList<Attachment> GetCombinarCorrespondenciaHojaCalculo()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Combinar correspondencia con una hoja de cálculo de Excel",
                    "Se aplica a: Word 2016 Word 2013 Word 2010",
                    "La combinación de correspondencia se usa para crear varios documentos a la vez. Estos documentos " +
                    "tienen un diseño, formato, texto y gráficos idénticos.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/combinar-correspondencia-con-una-hoja-de-c%C3%A1lculo-de-excel-858c7d7f-5cc0-4ba1-9a7b-0a948fa3d7d3")),
            };
        }

        //--------- CAMBIAR ----------
        //----------------------------
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

        //--------- AGREGAR ----------
        //----------------------------
        // Adjuntar archivos en word
        public static IList<Attachment> GetAgregarArchivosWord()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Insertar un documento en Word",
                    "Se aplica a: Word 2016 Word 2013 Word 2010 Word 2007",
                    "Puede insertar el contenido de documentos de Microsoft Office Word creados previamente en un " +
                    "documento de Microsoft Office Word nuevo o diferente.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/insertar-un-documento-en-word-274128e5-4da7-4cb8-b65f-3d8b585e03f1")),
            };
        }

        // Agregar un comentario en Word
        public static IList<Attachment> GetAgregarComentarioWord()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Insertar comentarios en Word",
                    "Se aplica a: Word 2016, Word 2013, Word 2010, Word 2007",
                    "Como insertar un comentario en Word:\r\r"+
                    ">1. Seleccione el texto o elemento sobre el que quiera agregar un comentario o haga clic al final del texto.\r\r"+
                    ">2. En la pestaña Revisar, en el grupo Comentarios, haga clic en Nuevo comentario.\r\r"+
                    ">![duck](https://support.content.office.net/es-es/media/5a49f0e2-171e-4b05-871b-8ef4a0545f1c.gif)",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Insertar-o-eliminar-comentarios-8D3F868A-867E-4DF2-8C68-BF96671641E2")),
            };
        }

        // Insertar una firma 
        // Agregar o quitar una firma digital en archivos de Office
        public static IList<Attachment> GetAgregarFirmaDigitalArhivosOffice()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Agregar o quitar una firma digital en archivos de Office",
                    "Se aplica a: Excel 2016 Word 2016 PowerPoint 2016 Word Starter 2010",
                    "En este artículo se explican las firmas digitales , para qué se pueden usar y cómo se pueden usar " +
                    "firmas digitales en los siguientes programas de Microsoft Office: Word, Excel y PowerPoint.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Agregar-o-quitar-una-firma-digital-en-archivos-de-Office-70d26dc9-be10-46f1-8efa-719c8b3f1a2d#__toc311526848")),
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

        // Insertar un símbolo o carácter especial 
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

        // Inserta texto automáticamente
        public static IList<Attachment> GetInsertarTextoAutomaticamenteWord()
        {
            return new List<Attachment>()
            {
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

        // Agregar o editar palabras en un diccionario del corrector ortográfico
        public static IList<Attachment> GetAgregarPalabrasDiccionarioCorrectorOrtografico()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Agregar o editar palabras en un diccionario del corrector ortográfico",
                    "Se aplica a: Excel, Word, Outlook, PowerPoint, OneNote, Publisher, Access",
                    "El corrector ortográfico compara las palabras del documento con las del diccionario principal de Office.\r\r" +
                    "Para obtener información sobre la corrección ortográfica en otro idioma, " +
                    "vea [Revisar la ortografía y la gramática en otro idioma](https://support.office.com/es-es/article/revisar-ortograf%C3%ADa-y-gram%C3%A1tica-en-otro-idioma-667ba67a-a202-42fd-8596-edc1fa320e00?ui=es-ES&rs=es-ES&ad=ES).",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/agregar-o-editar-palabras-en-un-diccionario-del-corrector-ortogr%C3%A1fico-56e5c373-29f8-4d11-baf6-87151725c0dc?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Insertar el recuento de palabras en un documento
        public static IList<Attachment> GetInsertarRecuentoPalabrasDocumento()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Insertar el recuento de palabras en un documento",
                    "Se aplica a: Word 2016 Word 2013 Word 2010 Word 2007",
                    "Siga los siguientes pasos:\r\r"+
                    ">1. Haga clic en el lugar del documento donde desea que aparezca el recuento de palabras.\r\r"+
                    ">2. Haga clic en **Insertar** > **Elementos rápidos** > **Campo**.\r\r"+
                    ">3. En la lista **Nombres de campos**, haga clic en **NumWords** y después en **Aceptar**.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/usar-los-campos-para-insertar-el-recuento-de-palabras-en-un-documento-8696d5ae-25bb-4173-a76f-00f213a2fa63?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Agregar o eliminar marcadores en un documento de Word o un mensaje de Outlook
        public static IList<Attachment> GetAgregarMarcadoresDocumentoWorMensajeOutlook()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Agregar o eliminar marcadores en un documento de Word o un mensaje de Outlook",
                    "Se aplica a: Word 2016, Outlook 2016",
                    "Agregar marcador en una ubicación:\r\r"+
                    ">1. Seleccione el texto, imagen o el punto del documento en el que quiere insertar un marcador.\r\r"+
                    ">2. Haga clic en **Insertar** > **Marcador**.\r\r"+
                    ">3. En **nombre del marcador**, escriba un nombre y haga clic en **Agregar**.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/agregar-o-eliminar-marcadores-en-un-documento-de-word-o-un-mensaje-de-outlook-f68d781f-0150-4583-a90e-a4009d99c2a0?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Insertar un salto de página
        public static IList<Attachment> GetInsertarSaltoPagina()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Insertar un salto de página",
                    "Se aplica a: Word 2016, Visio 2013, Word 2010, Word 2007, Word Online, Word Starter 2010",
                    "Al crear un documento, Word inserta automáticamente un salto de página al final de cada página. Puede agregar " +
                    "de forma manual un salto de página en cualquier otra ubicación del documento",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/insertar-un-salto-de-p%C3%A1gina-7613ff46-96e5-4e46-9491-40d7d410a043?ui=es-ES&rs=es-HN&ad=PE")),
                };
        }

        // Insertar un salto de sección
        public static IList<Attachment> GetInsertarSaltoSeccion()
        {
            return new List<Attachment>()
            {
               GetHeroCardV2(
                    "Insertar un salto de sección",
                    "Se aplica a: Word 2016 Word 2013 Word 2010 Word 2007 Word Starter 2010",
                    "Use los saltos de secciones para dividir y dar formato a documentos de todos los tamaños.\r\r"+
                    "También puede [eliminar un salto de sección ](https://support.office.com/es-es/article/eliminar-un-salto-de-secci%C3%B3n-1e12f200-7215-4688-a55a-5130f383dc5f) agregado anteriormente.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Insertar-un-salto-de-secci%C3%B3n-eef20fd8-e38c-4ba6-a027-e503bdf8375c")),
             };
        }

        // Insertar un salto de página y sección
        public static IList<Attachment> GetInsertarSaltoPaginaSeccion()
        {
            return new List<Attachment>()
            {
                 GetHeroCardV2(
                    "Insertar un salto de página",
                    "Se aplica a: Word 2016, Visio 2013, Word 2010, Word 2007, Word Online, Word Starter 2010",
                    "Al crear un documento, Word inserta automáticamente un salto de página al final de cada página. Puede agregar " +
                    "de forma manual un salto de página en cualquier otra ubicación del documento",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/insertar-un-salto-de-p%C3%A1gina-7613ff46-96e5-4e46-9491-40d7d410a043?ui=es-ES&rs=es-HN&ad=PE")),
                GetHeroCardV2(
                    "Insertar un salto de sección",
                    "Se aplica a: Word 2016 Word 2013 Word 2010 Word 2007 Word Starter 2010",
                    "Use los saltos de secciones para dividir y dar formato a documentos de todos los tamaños.\r\r"+
                    "También puede [eliminar un salto de sección](https://support.office.com/es-es/article/eliminar-un-salto-de-secci%C3%B3n-1e12f200-7215-4688-a55a-5130f383dc5f) agregado anteriormente.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Insertar-un-salto-de-secci%C3%B3n-eef20fd8-e38c-4ba6-a027-e503bdf8375c")),
            };
        }

        // Insertar numeración de página
        public static IList<Attachment> GetInsertarNumeracionPaginaWord()
        {
            return new List<Attachment>()
            {
                 GetHeroCardV2(
                    "Insertar numeración de página en un documento",
                    "Se aplica a: Word 2016 Word 2013 Word 2010 Word 2007 Word Online",
                    "Imagine que quiere usar diferentes números de página o estilos y formatos de número en secciones distintas de un documento (por ejemplo, podría"+
                    " usar números de página como i, ii, iii… en la introducción y la tabla de contenido, y 1, 2, 3 en el resto del documento). El truco es dividir "+
                    "el documento en secciones y asegurarse de que esas secciones no estén vinculadas.\r\r"+
                    "En el siguiente [link](https://support.office.com/es-es/article/Agregar-formatos-de-n%C3%BAmero-o-n%C3%BAmeros-de-p%C3%A1gina-distintos-a-secciones-diferentes-bb4da2bd-1597-4b0c-9e91-620615ed8c05) podrá ver como se agrega la numeración de página a su documento.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Agregar-formatos-de-n%C3%BAmero-o-n%C3%BAmeros-de-p%C3%A1gina-distintos-a-secciones-diferentes-bb4da2bd-1597-4b0c-9e91-620615ed8c05")),
            };
        }

        // Agregar números de página en Word
        public static IList<Attachment> GetAgregarNumerosPaginasWord()
        {
            return new List<Attachment>()
            {
                 GetHeroCardV2(
                    "Agregar números de página en Word",
                    "Se aplica a: Word",
                    "Agregar numeración de páginas básica a un documento de Word mediante el botón Número de página de la pestañaInsertar.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Agregar-n%C3%BAmeros-de-p%C3%A1gina-en-Word-9f366518-0500-4b45-903d-987d3827c007")),
            };
        }

        // Agregar números de página en Word
        // Insertar el recuento de palabras en un documento
        public static IList<Attachment> GetAgregarNumerosPaginasWordInsertarRecuentoPalabras()
        {
            return new List<Attachment>()
            {
                 GetHeroCardV2(
                    "Agregar números de página en Word",
                    "Se aplica a: Word",
                    "Agregar numeración de páginas básica a un documento de Word mediante el botón Número de página de la pestañaInsertar.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Agregar-n%C3%BAmeros-de-p%C3%A1gina-en-Word-9f366518-0500-4b45-903d-987d3827c007")),
                 GetHeroCardV2(
                    "Insertar el recuento de palabras en un documento",
                    "Se aplica a: Word 2016 Word 2013 Word 2010 Word 2007",
                    "Para ver el recuento de palabras del documento, mire la barra de estado de la parte inferior de la ventana de Word.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/usar-los-campos-para-insertar-el-recuento-de-palabras-en-un-documento-8696d5ae-25bb-4173-a76f-00f213a2fa63?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }


        // Agregar un encabezado o pie de página
        public static IList<Attachment> GetAgregarEncabezadoPiePaginaWord()
        {
            return new List<Attachment>()
            {
                 GetHeroCardV2(
                    "Agregar un encabezado o pie de página",
                    "Se aplica a: Word",
                    "Agregue títulos, números de página o fechas a todas las páginas de un documento con encabezados y pies de página.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/agregar-un-encabezado-o-pie-de-p%C3%A1gina-b87ee4df-abc1-41f8-995b-b39f6d99c7ed?ui=es-ES&rs=es-HN&ad=PE")),
                };
        }


        // Insertar o dibujar una tabla
        public static IList<Attachment> GetInsertarDibujarTablaWord()
        {
            return new List<Attachment>()
            {
                 GetHeroCardV2(
                    "Insertar o dibujar una tabla",
                    "Se aplica a: Word 2016 Word 2013 Word 2010 Word 2007 Word Online Word Starter 2010",
                    "Para insertar rápidamente una tabla básica, haga clic en Insertar > Tabla y mueva el cursor sobre la cuadrícula " +
                    "hasta que haya resaltado el número de columnas y filas que desee.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/insertar-o-dibujar-una-tabla-a138f745-73ef-4879-b99a-2f3d38be612a?ui=es-ES&rs=es-ES&ad=ES")),
                };
        }

        // Insertar una marca de agua en Word
        public static IList<Attachment> GetInsertarMarcaAguaWord()
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
                };
        }

        // Insertar imágenes
        public static IList<Attachment> GetInsertarImagenes()
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

        // Insertar WordArt
        public static IList<Attachment> GetInsertarWordArt()
        {
            return new List<Attachment>()
            {
                 GetHeroCardV2(
                    "Insertar WordArt",
                    "Se aplica a: Excel 2016 Word 2016 Outlook 2016 PowerPoint 2016 Publisher 2016",
                    "WordArt es una manera rápida de hacer que el texto destaque con efectos especiales. \r\r"+
                    ">1. Haga clic en **Insertar** > **WordArt** y elija un estilo de WordArt.\r\r"+
                    ">2. Se mostrará el texto de marcador de posición 'Espacio para el texto', con el texto resaltado.\r\r"+
                    ">3. Escriba su propio texto para sustituir el texto de marcador de posición.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Insertar-WordArt-c5070583-1ebe-4dc4-a41f-5e3729adce54")),
                };
        }

        // Agregar, copiar o eliminar un cuadro de texto
        public static IList<Attachment> GetAgregarCopiarEliminarCuadroTexto()
        {
            return new List<Attachment>()
            {
                 GetHeroCardV2(
                    "Agregar, copiar o eliminar un cuadro de texto",
                    "Se aplica a: Excel 2016 Word 2016 Outlook 2016 PowerPoint 2016 Project Professional 2016",
                    "Puede agregar, copiar o eliminar cuadros de texto en sus aplicaciones de Microsoft Office. Un cuadro "+
                    "de texto le permite agregar texto en cualquier parte del archivo.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Agregar-copiar-o-eliminar-un-cuadro-de-texto-4d968daa-5c86-48f2-88fa-b65871966017")),
                };
        }

        //-------- CREAR --------
        //-----------------------
        // Crear un documento Word
        public static IList<Attachment> GetCrearDocumentoWord()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Crear un documento",
                    "Se aplica a: Word 2016, Word 2013, Word 2010, Word 2007, Word Online",
                    "Empezar a usar un documento básico en Microsoft Office Word es tan fácil como abrir un documento nuevo o " +
                    "existente, y empezar a escribir. ",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/crear-un-documento-3aa3c766-9733-4f60-9efa-de245467c13d")),
            };
        }

        // Crear o modificar un hipervínculo
        public static IList<Attachment> GetCrearHipervinculo()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Crear o modificar un hipervínculo",
                    "Se aplica a: Excel 2016 Word 2016 Outlook 2016 PowerPoint 2016 Office 2016",
                    "La forma más rápida de crear un hipervínculo básico en un documento de Office es presionar **ENTER** " +
                    "o la **barra espaciadora** después de escribir la dirección de una página web existente.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/crear-o-modificar-un-hiperv%C3%ADnculo-5d8c0804-f998-4143-86b1-1199735e07bf?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Crear una sangría de primera línea
        public static IList<Attachment> GetCrearSangria()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Crear una sangría de primera línea",
                    "Se aplica a: Word 2016 Word 2013",
                    "Con una sangría de primera línea, la primera línea de un párrafo tiene una sangría superior a la de las " +
                    "demás líneas del párrafo.\r\r"+
                    "Si desea saber como crear una sangría francesa haga clic [aquí](https://support.office.com/es-es/article/Crear-una-sangr%C3%ADa-francesa-7bdfb86a-c714-41a8-ac7a-3782a91ccad5).",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/crear-una-sangr%C3%ADa-de-primera-l%C3%ADnea-b3721167-e1c8-40c3-8a97-3f046fc72d6d")),
            };
        }

        // Crear una tabla de contenido en Word
        public static IList<Attachment> GetCrearTablaContenidoWord()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Crear una tabla de contenido en Word",
                    "Se aplica a: Word 2016 Word 2013 Word 2010 Word 2007",
                    "Para crear una tabla de contenido, en primer lugar, necesitará aplicar los estilos de título al texto " +
                    "que desea incluir en dicha tabla.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Crear-una-tabla-de-contenido-en-Word-882e8564-0edb-435e-84b5-1d8552ccf0c0")),
            };
        }

        // Crear un gráfico de Excel en Word
        public static IList<Attachment> GetCrearGraficoWord()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Crear un gráfico de Excel en Word",
                    "Se aplica a: Word 2013",
                    "No es necesario que inicie Excel para agregar un gráfico de Excel a un documento de Word. En vez de esto, " +
                    "puede crear un gráfico de Excel desde cero en Word y editar los datos y personalizar el gráfico en el mismo Word.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Crear-un-gr%C3%A1fico-de-Excel-en-Word-11a7d2f0-4487-4a9b-bbc6-d50916cd4a57")),
            };
        }

        // Crear formularios en Word
        public static IList<Attachment> GetCrearFormularioWord()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Crear un formulario para rellenar",
                    "Se aplica a: Word 2016 Word 2013 Word 2010 Word 2007",
                    "Para crear un formulario, puede empezar con una plantilla y agregar controles de contenido, como casillas, " +
                    "cuadros de texto, selectores de fecha y listas desplegables. Otros usuarios pueden usar Word para rellenar el " +
                    "formulario en su equipo. ",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Crear-formularios-que-los-usuarios-rellenan-o-imprimen-en-Word-040c5cc1-e309-445b-94ac-542f732c8c8b")),
            };
        }

        // Crear una lista de comprobación en Word
        public static IList<Attachment> GetCrearListaComprobacion()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Crear una lista de comprobación en Word",
                    "Se aplica a: Word 2016, Word 2013, Word 2010, Word 2007",
                    "Se pueden crear dos tipos de listas de comprobación:\r\r"+
                    ">* Listas con casillas o marcas de verificación.\r\r"+
                    ">* Listas que se pueden marcar.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/hacer-una-lista-de-comprobaci%C3%B3n-en-word-dd04fa4f-2ca7-4543-8818-c469eca9f45c?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Crear e imprimir etiquetas
        public static IList<Attachment> GetCrearImprimirEtiquetasWord()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Crear una lista de comprobación en Word",
                    "Se aplica a: Word 2016 Word 2013 Word 2010 Word 2007 Word Starter 2010",
                    "Para un lote de etiquetas diferentes, se recomienda empezar el documento desde una plantilla de etiqueta. "+
                    "Para buscar una, vaya a la pestaña **Archivo**, haga clic en **Nuevo** y, a continuación, en el cuadro "+
                    "de búsqueda, escriba etiquetas y presione Entrar.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/hacer-una-lista-de-comprobaci%C3%B3n-en-word-dd04fa4f-2ca7-4543-8818-c469eca9f45c?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Crear un estilo basado en el formato del documento
        public static IList<Attachment> GetCrearEstiloDocumento()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Personalizar o crear estilos en Word",
                    "Se aplica a: Word, Outlook",
                    "Hay dos maneras de modificar un estilo existente en la galería de estilos:\r\r"+
                    ">* [Modificar un estilo actualizándolo para que coincida con el formato del documento](https://support.office.com/es-es/article/personalizar-o-crear-estilos-en-word-d38d6e47-f6fc-48eb-a607-1eb120dec563?ui=es-ES&rs=es-ES&ad=ES#update)\r\r"+
                    ">* [Modificar un estilo de forma manual en el cuadro de diálogo Modificar estilo](https://support.office.com/es-es/article/personalizar-o-crear-estilos-en-word-d38d6e47-f6fc-48eb-a607-1eb120dec563?ui=es-ES&rs=es-ES&ad=ES#manual)",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/personalizar-o-crear-estilos-en-word-d38d6e47-f6fc-48eb-a607-1eb120dec563?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Crear una nueva lista de combinación de correspondencia
        public static IList<Attachment> GetCrearListaCombinacionCorrespondencia()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Crear una nueva lista de combinación de correspondencia",
                    "Se aplica a: Word 2016, Word 2013, Word 2010, Word Starter 2010",
                    "Si no tiene una lista de distribución como un origen de para nombres y direcciones en una combinación de " +
                    "correspondencia, puede crear uno en Word.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Configurar-una-nueva-lista-de-combinaci%C3%B3n-de-correspondencia-con-Word-1a752328-b1b5-4865-96a2-e0acd561fe6f")),
            };
        }

        // Crear lista de comprobacion
        // Crear lista de combinacion de correspondencia
        public static IList<Attachment> GetCrearListaComprobacionListaCombinacion()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Crear una lista de comprobación en Word",
                    "Se aplica a: Word 2016 Word 2013 Word 2010 Word 2007",
                    "Se pueden crear dos tipos de listas de comprobación:\r\r"+
                    ">* Listas con casillas o marcas de verificación.\r\r"+
                    ">* Listas que se pueden marcar en Word.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/hacer-una-lista-de-comprobaci%C3%B3n-en-word-dd04fa4f-2ca7-4543-8818-c469eca9f45c?ui=es-ES&rs=es-ES&ad=ES")),
                 GetHeroCardV2(
                    "Crear una nueva lista de combinación de correspondencia",
                    "Se aplica a: Word 2016, Word 2013, Word 2010, Word Starter 2010",
                    "Si no tiene una lista de distribución como un origen de para nombres y direcciones en una combinación de " +
                    "correspondencia, puede crear uno en Word.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Configurar-una-nueva-lista-de-combinaci%C3%B3n-de-correspondencia-con-Word-1a752328-b1b5-4865-96a2-e0acd561fe6f")),

            };
        }

        //--------- COMPARTIR ---------
        //-----------------------------
        // Compartir el documento en Word 2016 para Windows
        public static IList<Attachment> GetCompartirArchivosWord()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Compartir el documento en Word 2016 para Windows",
                    "Se aplica a: Word 2016",
                    " Al compartir sus archivos mediante OneDrive o SharePoint Online para Office 365, puede invitar a personas " +
                    "para el documento directamente ",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Compartir-el-documento-en-Word-2016-para-Windows-d39f3cd8-0aa0-412f-9a35-1abba926d354")),
            };
        }

        //------ HACER / REALIZAR ------
        //------------------------------
        // Permitir cambios en partes de un documento protegido
        public static IList<Attachment> GetPermitirCambiosDocumentoProtegido()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Permitir cambios en partes de un documento protegido",
                    "Se aplica a: Word 2016 Word 2013 Word 2010 Word 2007",
                    "Puede marcar un documento como de solo lectura y seguir permitiendo cambios en partes seleccionadas.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/permitir-cambios-en-partes-de-un-documento-protegido-187ed01c-8795-43e1-9fd0-c9fca419dadf")),
            };
        }

        // Realizar un seguimiento de los cambios en Word
        public static IList<Attachment> GetRealizarSeguimientoCambiosWord()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Realizar un seguimiento de los cambios en Word",
                    "Se aplica a: Word, Office 2007",
                    "Cuando desee ver quién a realizado cambios en el documento, active la característica control de cambios. "+
                    "También puede elegir qué cambios aceptar o rechazar y puede ver y eliminar comentarios.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/realizar-un-seguimiento-de-los-cambios-en-word-197ba630-0f5f-4a8e-9a77-3712475e806a?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        //---- CAMBIAR / MODIFICAR ----
        //-----------------------------
        // Cambiar el nombre del autor de los documentos
        public static IList<Attachment> GetCambiarNombreAutorDocumento()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Cambiar el nombre del autor de los documentos",
                    "Se aplica a: Word 2016, Word 2013, Word 2010, Word 2007",
                    "Cada vez que cree un nuevo documento, Word establece la propiedad del autor basándose en la configuración " +
                    "de nombre de usuario que aparece en el cuadro de diálogo **Opciones de Word**.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/cambiar-el-nombre-del-autor-de-los-documentos-0ad23fe7-b82e-40c4-b9d9-391fec971a54")),
            };
        }

        // Cambiar mayúsculas en el texto
        public static IList<Attachment> GetCambiarMayusculasTextoWord()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Cambiar mayúsculas en el texto",
                    "Se aplica a: Word, PowerPoint, Word para Mac, Word Starter 2010",
                    "Para cambiar el texto seleccionado en un documento, haga lo siguiente:\r\r"+
                    ">1. Seleccione el texto que desea cambiar.\r\r"+
                    ">2. En la ficha Inicio, en el grupo fuente, haga clic en Cambiar mayúsculas y minúsculas (g ).\r\r"+
                    ">3. Escoja la alternativa que más le convenga.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Cambiar-el-uso-de-may%C3%BAsculas-en-el-texto-1d86cf80-fbef-4380-8d6f-59a6b77db749")),
            };
        }

        // Cambiar el interlineado en Word
        public static IList<Attachment> GetCambiarInterlineadoWord()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Cambiar el interlineado en Word",
                    "Se aplica a: Word 2016, Word 2013, Word 2010, Word 2007, Word Starter 2010",
                    "El modo más rápido de cambiar la cantidad de espacio que aparece entre las líneas de texto o " +
                    "entre párrafos en un documento entero es usar la opción Espaciado entre párrafos de la pestaña Diseño.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Cambiar-el-interlineado-en-Word-1970e24a-441c-473d-918f-c6805237fbf4")),
            };
        }

        // Cambiar los espacios entre texto
        public static IList<Attachment> GetCambiarEspaciosTextoWord()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Cambiar los espacios entre texto",
                    "Se aplica a: Word, Outlook",
                    "Puede cambiar el espaciado entre caracteres para el texto seleccionado o solo para determinados caracteres. ",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Cambiar-los-espacios-entre-texto-e9b96011-1c42-45c0-ad8f-e8a6e4a33462")),
            };
        }

        // Cambiar el fondo o el color de un documento en Word 2016 para Windows
        public static IList<Attachment> GetCambiarColorFondoDocumentoWord()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Cambiar el fondo o el color de un documento en Word 2016 para Windows",
                    "Se aplica a: Word 2016",
                    "Agregue un color de fondo con el botón **Color de página**.\r\r"+
                    ">1. Haga clic en Diseño > Color de página.\r\r"+
                    ">2. Haga clic en el color deseado en Colores del tema o en Colores estándar.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Cambiar-el-fondo-o-el-color-de-un-documento-en-Word-2016-para-Windows-db481e61-7af6-4063-bbcd-b276054a5515")),
            };
        }

        // Cambiar borde de un documento word
        public static IList<Attachment> GetCambiarBordeDocumentoWord()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Decorar los documentos o las imágenes con bordes",
                    "Se aplica a: Word, Outlook, PowerPoint, Office 2007, Word Starter 2010",
                    "Los bordes pueden agregar interés y énfasis a diferentes partes del documento o mensaje de correo electrónico. " +
                    "Puede agregar bordes a páginas, texto, tablas y celdas de tabla, objetos gráficos e imágenes.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/decorar-los-documentos-o-las-im%C3%A1genes-con-bordes-70e0af47-31c7-47ae-89f3-9ec587f1e49f?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Cambiar o quitar el borde de un cuadro de texto
        public static IList<Attachment> GetCambiarBordeCuadroTextoWord()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Cambiar o quitar el borde de un cuadro de texto, una forma o un gráfico SmartArt",
                    "Se aplica a: Excel 2016,, Word 2016, Outlook 2016, PowerPoint 2016, Project Professional 2016, Excel 2013 ",
                    "Puede cambiar el color, el grosor o el estilo de un borde exterior de un gráfico SmartArt, de una forma o " +
                    "de un cuadro de texto, o bien puede quitar el borde por completo.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/cambiar-o-quitar-el-borde-de-un-cuadro-de-texto-una-forma-o-un-gr%C3%A1fico-smartart-ec2e4491-d3bf-4266-beac-f6298fdfde9f?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Cambiar borde de un documento word
        // Cambiar o quitar el borde de un cuadro de texto
        public static IList<Attachment> GetCambiarBordeWord()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Decorar los documentos o las imágenes con bordes",
                    "Se aplica a: Word, Outlook, PowerPoint, Office 2007, Word Starter 2010",
                    "Los bordes pueden agregar interés y énfasis a diferentes partes del documento o mensaje de correo electrónico. " +
                    "Puede agregar bordes a páginas, texto, tablas y celdas de tabla, objetos gráficos e imágenes.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/decorar-los-documentos-o-las-im%C3%A1genes-con-bordes-70e0af47-31c7-47ae-89f3-9ec587f1e49f?ui=es-ES&rs=es-ES&ad=ES")),
                GetHeroCardV2(
                    "Cambiar o quitar el borde de un cuadro de texto, una forma o un gráfico SmartArt",
                    "Se aplica a: Excel 2016,, Word 2016, Outlook 2016, PowerPoint 2016, Project Professional 2016, Excel 2013 ",
                    "Puede cambiar el color, el grosor o el estilo de un borde exterior de un gráfico SmartArt, de una forma o " +
                    "de un cuadro de texto, o bien puede quitar el borde por completo.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/cambiar-o-quitar-el-borde-de-un-cuadro-de-texto-una-forma-o-un-gr%C3%A1fico-smartart-ec2e4491-d3bf-4266-beac-f6298fdfde9f?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        //Modificar un encabezado o pie de página
        public static IList<Attachment> GetModificarEncabezadoPiePagina()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Modificar un encabezado o pie de página",
                    "Se aplica a: Word 2016 para Mac Word para Mac 2011",
                    "Los encabezados y pies de página son áreas en los márgenes superior e inferior de cada página en un documento. " +
                    "Puede agregar, editar o eliminar encabezados y pies de página.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/agregar-o-editar-encabezados-y-pies-de-p%C3%A1gina-en-word-para-mac-98a28ebf-8bf5-478c-a91f-548aebe87725")),
            };
        }

        //Modificar un estilo existente
        public static IList<Attachment> GetModificarEstiloExistente()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Personalizar o crear estilos en Word",
                    "Se aplica a: Word, Outlook",
                    "Hay dos maneras de modificar un estilo existente en la galería de estilos:\r\r"+
                    ">* [Modificar un estilo actualizándolo para que coincida con el formato del documento](https://support.office.com/es-es/article/personalizar-o-crear-estilos-en-word-d38d6e47-f6fc-48eb-a607-1eb120dec563?ui=es-ES&rs=es-ES&ad=ES#update)\r\r"+
                    ">* [Modificar un estilo de forma manual en el cuadro de diálogo Modificar estilo](https://support.office.com/es-es/article/personalizar-o-crear-estilos-en-word-d38d6e47-f6fc-48eb-a607-1eb120dec563?ui=es-ES&rs=es-ES&ad=ES#manual)",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/personalizar-o-crear-estilos-en-word-d38d6e47-f6fc-48eb-a607-1eb120dec563?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        //----- ELIMINAR / QUITAR -----
        //-----------------------------
        // Quitar comentarios en Word
        public static IList<Attachment> GetQuitarComentariosWord()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Quitar comentarios",
                    "Se aplica a: Word 2016",
                    "Cuando desee ver quién ha realicen cambios en el documento, active la característica control de cambios. " +
                    "También puede elegir qué cambios aceptar o rechazar y puede ver y eliminar comentarios.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/quitar-los-cambios-realizados-y-los-comentarios-en-word-2016-para-windows-7966b497-7e04-4a13-8d41-53a3ffa00c25?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Quitar marcas de revisión 
        public static IList<Attachment> GetQuitarMarcasRevision()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Quitar comentarios",
                    "Se aplica a: Word 2016",
                    "Cuando desee ver quién ha realicen cambios en el documento, active la característica control de cambios. " +
                    "También puede elegir qué cambios aceptar o rechazar y puede ver y eliminar comentarios.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/quitar-los-cambios-realizados-y-los-comentarios-en-word-2016-para-windows-7966b497-7e04-4a13-8d41-53a3ffa00c25?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Quitar hipervínculos
        public static IList<Attachment> GetQuitarHipervinculos()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Quitar hipervínculo",
                    "Se aplica a: Excel 2016 Word 2016 Outlook 2016 PowerPoint 2016",
                    "Puede quitar un hipervínculo de una dirección, quitar muchos vínculos a la vez, desactivar los hipervínculos " +
                    "automáticos y desactivar el requisito de presionar la tecla Ctrl para seguir un hipervínculo.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Quitar-o-desactivar-los-hiperv%C3%ADnculos-027b4e8c-38f8-432c-b57f-6c8b67ebe3b0")),
            };
        }

        // Quitar un salto de página
        public static IList<Attachment> GetQuitarSaltoPagina()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Quitar un salto de página",
                    "Se aplica a: Word 2010",
                    "Quitar un salto de página manual: \r\r"+
                    ">1. Haga clic en **Inicio** > **Mostrar u ocultar** ![duck](https://support.content.office.net/es-es/media/c0475c36-0248-45ef-b171-15dae58939ae.gif).\r\r"+
                    ">2. Haga doble clic en el salto de página para que esté seleccionado y, a continuación, presione la tecla **Suprimir**.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/quitar-un-salto-de-p%C3%A1gina-e696a217-adc7-4ef3-977b-de0c3d87b762?ui=es-ES&rs=es-HN&ad=PE")),
            };
        }

        // Eliminar un salto de sección
        public static IList<Attachment> GetEliminarSaltoSeccion()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Eliminar un salto de sección",
                    "Se aplica a: Word 2016 Word 2013 Word 2010",
                    "Siga los siguientes pasos:\r\r"+
                    ">1. En el grupo **Párrafo** de la pestaña **Inicio**, haga clic en **Mostrar u ocultar** ![duck](https://support.content.office.net/es-es/media/c0475c36-0248-45ef-b171-15dae58939ae.gif).\r\r"+
                    ">2. Para eliminarlo, coloque el cursor justo antes del salto de sección y presione **Suprimir**.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/eliminar-un-salto-de-secci%C3%B3n-1e12f200-7215-4688-a55a-5130f383dc5f?ui=es-ES&rs=es-HN&ad=PE")),
            };
        }

        // Quitar un salto de página 
        // Eliminar un salto de sección
        public static IList<Attachment> GetQuitarSaltoPaginaEliminarSaltoSeccion()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Quitar un salto de página",
                    "Se aplica a: Word 2010",
                    "Quitar un salto de página manual: \r\r"+
                    ">1. Haga clic en **Inicio** > **Mostrar u ocultar** ![duck](https://support.content.office.net/es-es/media/c0475c36-0248-45ef-b171-15dae58939ae.gif).\r\r"+
                    ">2. Haga doble clic en el salto de página para que esté seleccionado y, a continuación, presione la tecla **Suprimir**.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/quitar-un-salto-de-p%C3%A1gina-e696a217-adc7-4ef3-977b-de0c3d87b762?ui=es-ES&rs=es-HN&ad=PE")),
                GetHeroCardV2(
                    "Eliminar un salto de sección",
                    "Se aplica a: Word 2016 Word 2013 Word 2010",
                    "Siga los siguientes pasos:\r\r"+
                    ">1. En el grupo **Párrafo** de la pestaña **Inicio**, haga clic en **Mostrar u ocultar** ![duck](https://support.content.office.net/es-es/media/c0475c36-0248-45ef-b171-15dae58939ae.gif).\r\r"+
                    ">2. Para eliminarlo, coloque el cursor justo antes del salto de sección y presione **Suprimir**.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/eliminar-un-salto-de-secci%C3%B3n-1e12f200-7215-4688-a55a-5130f383dc5f?ui=es-ES&rs=es-HN&ad=PE")),

            };
        }

        // Quitar números de página
        public static IList<Attachment> GetQuitarNumerosPagina()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Quitar números de página",
                    "Se aplica a: Word 2016, Word 2013, Word 2010, Word 2007, Word Online",
                    "Quitar números de páginas continuos:\r\r"+
                    ">* En la pestaña **Insertar**, en el grupo **Encabezado y pie de página**, seleccione **Número de página** y, después, haga clic en **Quitar números de página**.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Quitar-n%C3%BAmeros-de-p%C3%A1gina-d79e5090-c8f7-4e24-ab97-c36cfeb8d85b")),
            };
        }

        // Eliminar o cambiar un encabezado o pie de página de una sola página
        public static IList<Attachment> GetEliminarCambiarEncabezadoPiePagina()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Eliminar o cambiar un encabezado o pie de página de una sola página",
                    "Se aplica a: Word 2016 Word 2013 Word 2010 Word 2007 Word Online",
                    "Puede quitar un encabezado de cualquier página de Word o realizar cambios en los encabezados de las páginas.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/eliminar-o-cambiar-un-encabezado-o-pie-de-p%C3%A1gina-de-una-sola-p%C3%A1gina-a9b6c963-a3e1-4de1-9142-ca1be1dba7ff?ui=es-ES&rs=es-HN&ad=PE")),
            };
        }

        // Quitar una marca de agua
        public static IList<Attachment> GetQuitarMarcaAgua()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Eliminar o cambiar un encabezado o pie de página de una sola página",
                    "Se aplica a: Word 2016, Word 2013, Word 2010, Word 2007, Word Online",
                    "Puede quitar una marca de agua de un documento si lo desea.\r\r"+
                    ">1. Abra el documento donde quiera quitar la marca de agua.\r\r"+
                    ">2. Vaya a la pestaña **Diseño** y, en el grupo **Fondo de página**, seleccione **Marca de agua**.\r\r"+
                    ">3. Seleccione **Quitar marca de agua**.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/quitar-una-marca-de-agua-636cc588-489d-46c4-a03f-07f3f4820029?ui=es-ES&rs=es-HN&ad=PE")),
            };
        }

        //-------- DESACTIVAR ---------
        //-----------------------------
        // Desactivar hipervínculos
        public static IList<Attachment> GetDesactivarHipervinculos()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Desactivar los hipervínculos automáticos",
                    "Se aplica a: Excel 2016 Word 2016 Outlook 2016 PowerPoint 2016",
                    "Puede quitar un hipervínculo de una dirección, quitar muchos vínculos a la vez, desactivar los hipervínculos " +
                    "automáticos y desactivar el requisito de presionar la tecla Ctrl para seguir un hipervínculo.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Quitar-o-desactivar-los-hiperv%C3%ADnculos-027b4e8c-38f8-432c-b57f-6c8b67ebe3b0")),
            };
        }

        // Configurar o desactivar el formato de texto automático
        public static IList<Attachment> GetDesactivarFormatoAutomatico()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Configurar o desactivar el formato de texto automático",
                    "Se aplica a: Excel, Word, Outlook, PowerPoint, Publisher, Visio Professional 2016",
                    "Para desactivar el formato automático, lo único que tiene que hacer es desmarcar todas las opciones que quiera " +
                    "desactivar en la pestaña [Formato automático mientras escribe](https://support.content.office.net/es-es/media/f0b96f4c-c337-49aa-841c-fafd1299331e.png).",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Quitar-o-desactivar-los-hiperv%C3%ADnculos-027b4e8c-38f8-432c-b57f-6c8b67ebe3b0")),
            };
        }

        //---------- MOSTRAR ----------
        //-----------------------------
        // Mostrar u ocultar las reglas horizontales y verticales
        public static IList<Attachment> GetMostrarOcultarReglaWord()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Mostrar u ocultar las reglas horizontales y verticales",
                    "Se aplica a: Word 2016 Word 2013 Word 2010 Word 2007",
                    "Asegúrese de que está en la vista Diseño de impresión y que la opción de regla vertical está activada.\r\r"+
                    ">* **Opción 1**: Elija **Ver regla** en la parte superior de la barra de desplazamiento vertical.\r\r"+
                    ">* **Opción 2**: Elija **Vista** y seleccione la casilla **Regla**.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/mostrar-u-ocultar-las-reglas-horizontales-y-verticales-dc8a4e0d-209f-43b8-b967-8e65da24d4c7")),
            };
        }

        //--------- CONVERTIR ---------
        //-----------------------------
        // Convertir texto en tabla o viceversa
        public static IList<Attachment> GetConvertirTextoTabla()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Convertir texto en tabla o viceversa",
                    "Se aplica a: Word, Outlook",
                    "Para convertir texto en tabla o viceversa, empiece haciendo clic en la marca de párrafo **Mostrar u ocultar** " +
                    "en la pestaña Inicio para poder ver cómo se separa el texto del documento.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Convertir-texto-en-tabla-o-viceversa-b5ce45db-52d5-4fe3-8e9c-e04b62f189e1")),
            };
        }

        //---------- EDITAR -----------
        //-----------------------------
        // Editar contenido de PDF en Word
        public static IList<Attachment> GetEditarContenidoPdfWord()
        {
            return new List<Attachment>()
            {
                GetVideoCard(
                    "Editar contenido de PDF en Word",
                    "Con Word 2013 y 2016, puede convertir un PDF en un documento de Word que se puede editar.",
                    "https://videocontent.osi.office.net/b44dad88-b993-4b1b-b992-eb226581a717/fae01964-f530-402d-a142-3889647ac5ba__H264_3400kbps_AAC_und_ch2_96kbps.mp4",
                    "https://support.office.com/es-es/article/editar-contenido-de-pdf-en-word-b2d1d729-6b79-499a-bcdb-233379c2f63a?ui=es-ES&rs=es-ES&ad=ES"),
            };
        }

        //--------- ESTABLECER --------
        //-----------------------------
        // Establecer los márgenes de una página en Word
        public static IList<Attachment> GetEstablecerMargenesPaginaWord()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Establecer los márgenes de una página en Word",
                    "Se aplica a: Word",
                    "En Word, se puede personalizar la configuración de márgenes o elegir una predefinida. Word establece " +
                    "automáticamente un margen de página de una pulgada alrededor de cada página.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/establecer-los-m%C3%A1rgenes-de-una-p%C3%A1gina-en-word-da21a474-99d8-4e54-b12d-a8a14ea7ce02?ui=es-ES&rs=es-ES&ad=ES")),
                };
        }

        // Establecer, desactivar o quitar tabulaciones
        public static IList<Attachment> GetEstablecerDesactivarQuitarTabulaciones()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Establecer, desactivar o quitar tabulaciones",
                    "Se aplica a: Word 2016 Outlook 2016 Word 2013 Outlook 2013 Word 2010 Word 2007",
                    "Puede usar tabulaciones para crear documentos con un formato sencillo. Al usar las opciones de diseño del documento, " +
                    "puede crear, por ejemplo, una tabla de contenido o un índice sin agregar una sola tabulación.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/establecer-desactivar-o-quitar-tabulaciones-06969e0f-2c81-4fe0-8df5-88f18087a8e0?ui=es-ES&rs=es-HN&ad=PE")),
                };
        }

        // Establecer las reglas para una combinación de correspondencia
        public static IList<Attachment> GetEstablecerReglasCombinacionCorrespondencia()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Establecer las reglas para una combinación de correspondencia",
                    "Se aplica a: Word 2016 Word 2013 Word 2010 Word 2007",
                    "Puede agregar reglas al configurar la combinación de correspondencia.\r\r"+
                    ">1. En la pestaña **Correspondencia**, en el grupo **Escribir e insertar campos**, seleccione **Reglas**.\r\r"+
                    ">2. Seleccione una regla disponible.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Establecer-las-reglas-para-una-combinaci%C3%B3n-de-correspondencia-d546ee7e-ab7a-4d6d-b488-41f9e4bd1409")),
                };
        }

        //---------- APLICAR ----------
        //-----------------------------
        // Aplicar espacio simple a las líneas de un documento
        public static IList<Attachment> GetAplicarEspacioSimpleLineasDocumento()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Aplicar espacio simple a las líneas de un documento",
                    "Se aplica a: Word 2016, Word 2013, Word 2010, Word 2007, Word para Mac",
                    "Aplicar espacio simple al documento:\r\r"+
                    ">1. Elija **Diseño** > **Espacio entre párrafos**.\r\r"+
                    ">2. Elija **Sin espacio entre párrafos**.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/aplicar-espacio-simple-a-las-l%C3%ADneas-de-un-documento-e96fa086-3f36-415e-8a7c-b4690ad94b92?ui=es-ES&rs=es-HN&ad=PE")),
                };
        }

        // Aplicar un estilo a texto en Word
        public static IList<Attachment> GetAplicarEstiloTextoWord()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Aplicar un estilo a texto en Word",
                    "Se aplica a: Word 2016, Word 2013, Word 2010, Word 2007",
                    "Siga los suigientes pasos:\r\r"+
                    ">1. Seleccione el texto al que desea aplicar un estilo.\r\r"+
                    ">2. En la ficha **Inicio**, en el grupo **estilos**, haga clic en el estilo que desee.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/aplicar-un-estilo-a-texto-en-word-f8b96097-4d25-4fac-8200-6139c8093109")),
               };
        }

        // Aplicar o quitar estilos y efectos de los objetos
        public static IList<Attachment> GetAplicarEstilosObjetos()
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

        //----------- BUSCAR ----------
        //-----------------------------
        // Buscar y reemplazar texto y otros datos en un documento de Word
        public static IList<Attachment> GetBuscarReemplazarTextoDatosDocumentoWord()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Buscar y reemplazar texto y otros datos en un documento de Word",
                    "Se aplica a: Word 2016, Word 2013, Word 2010, Word 2007, Word Online, Word Starter 2010",
                    "Word ofrece varias opciones para buscar contenido específico en su documento. Puede buscar y " +
                    "reemplazar elementos como texto, imágenes, títulos, marcadores o ciertos tipos de formato, como " +
                    "párrafos o saltos de página.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Buscar-y-reemplazar-texto-y-otros-datos-en-un-documento-de-Word-c6728c16-469e-43cd-afe4-7708c6c779b7")),
                };
        }

        //---------- PROBAR -----------
        //-----------------------------
        // Probar legibilidad de un documento
        public static IList<Attachment> GetProbarLegibilidadDocumento()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Conocer la legibilidad de un documento",
                    "Se aplica a: Word 2016 Outlook 2016 Word 2013 Outlook 2013",
                    "Siga los siguientes pasos: \r\r"+
                    ">1. Haga clic en la pestaña **Archivo** y, después, en **Opciones**.\r\r"+
                    ">2. Haga clic en **Revisión**.\r\r"+
                    ">3. En **Al corregir la ortografía y la gramática en Word**, asegúrese de que la casilla de verificación **Revisar gramática con ortografía** esté activada.\r\r"+
                    ">4. Seleccione **Estadísticas de legibilidad**.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/conocer-la-legibilidad-de-un-documento-85b4969e-e80a-4777-8dd3-f7fc3c8b3fd2?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        //---------- AJUSTAR ----------
        //-----------------------------
        // Ajustar texto en Word
        public static IList<Attachment> GetAjustarTextoWord()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Ajustar texto en Word",
                    "Se aplica a: Word 2016 Word 2013 Word 2010 Word 2007",
                    "Siga los siguientes pasos: \r\r"+
                    ">1. Haga clic en una imagen u objeto para seleccionarlo.\r\r"+
                    ">2. Haga clic en la pestaña **Formato de Herramientas de imagen** o de **Herramientas de dibujo** y, en el grupo **Organizar**, haga clic en **Ajustar texto**.\r\r"+
                    ">3. Elija el estilo de ajuste que quiere usar.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Ajustar-texto-en-Word-bdbbe1fe-c089-4b5c-b85c-43997da64a12")),
            };
        }

        // Ajustar la sangría y el espaciado
        public static IList<Attachment> GetAjustarSangriaEspaciado()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Ajustar la sangría y el espaciado",
                    "Se aplica a: Word 2016, Outlook 2016, Word 2013, Outlook 2013",
                    "Siga los siguientes pasos:\r\r"+
                    ">1. Seleccione un párrafo o un grupo de párrafos que quiera ajustar.\r\r"+
                    ">2. Haga clic en el selector de cuadro de diálogo **Párrafo** en la pestaña **Diseño de página** o **Presentación**.\r\r"+
                    ">3. Si fuera necesario, haga clic en la pestaña **Sangría y espacio**.\r\r"+
                    ">4. Elija la configuración y, después, haga clic en **Aceptar**.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Ajustar-la-sangr%C3%ADa-y-el-espaciado-36239d98-14c5-411e-a880-1ddf25d65cd6")),
            };
        }

        //----------- USAR ------------
        //-----------------------------
        // Usar las opciones de diseño de Word para mover imágenes
        public static IList<Attachment> GetUsarOpcionesDiseñoWord()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Usar las opciones de diseño de Word para mover imágenes",
                    "Se aplica a: Word 2016 Word 2013 Word Online",
                    "Normalmente, mover o cambiar la posición de una imagen en una página en Word es tan sencillo como arrastrarla con el mouse.\r\r" +
                    "Pero a veces no funciona. Por ejemplo, cuando mueve la imagen, el texto a su alrededor puede desordenarse.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Usar-las-opciones-de-dise%C3%B1o-de-Word-para-mover-im%C3%A1genes-becff26a-d1b9-4b9d-80f8-7e214557ca9f")),
                };
        }

        // Usar la combinación de correspondencia para crear y enviar correo masivo, etiquetas y sobres
        public static IList<Attachment> GetUsarCombinacionCorrespondenciaCrearEnviarCorreo()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Usar la combinación de correspondencia para crear y enviar correo masivo, etiquetas y sobres",
                    "Se aplica a: Word 2016 Word 2013 Word 2010 Word Starter 2010",
                    "Con el proceso de combinación de correspondencia, su organización puede crear un lote de cartas o correos " +
                    "electrónicos personalizados para enviar a los contactos profesionales.\r\r"+
                    ">* [Como usar la combinación de correspondencia para personalizar las letras de correo masivo](https://support.office.com/es-es/article/usar-la-combinaci%C3%B3n-de-correspondencia-para-personalizar-las-letras-de-correo-masivo-d7686bb1-3077-4af3-926b-8c825e9505a3?ui=es-ES&rs=es-ES&ad=ES)\r\r"+
                    ">* [Como usar la combinación de correspondencia para enviar mensajes de correo electrónico masivo](https://support.office.com/es-es/article/Usar-la-combinaci%C3%B3n-de-correspondencia-para-enviar-mensajes-de-correo-electr%C3%B3nico-masivo-0f123521-20ce-4aa8-8b62-ac211dedefa4)",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Usar-la-combinaci%C3%B3n-de-correspondencia-para-crear-y-enviar-correo-masivo-etiquetas-y-sobres-f488ed5b-b849-4c11-9cff-932c49474705")),
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