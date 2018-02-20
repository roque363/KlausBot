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

        // Crear una fórmula simple
        public static IList<Attachment> GetCrearFormulaSimple()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Crear una fórmula simple en Excel",
                    "Se aplica a: Excel 2016 Excel 2013 Excel 2010 Excel 2007",
                    "Siga los siguientes pasos:\r\r"+
                    ">1. Haga clic en la celda donde desea introducir la fórmula.\r\r"+
                    ">2. Escriba el = (signo igual) seguido de las constantes y operadores para su cálculo."+
                    ">3. Presione **Enter**(Windows) o **Retorno**(Mac).",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/crear-una-f%C3%B3rmula-simple-en-excel-11a5f0e5-38a3-4115-85bc-f4a465f64a8a?ui=es-ES&rs=es-ES&ad=ES")),
               };
        }

        // Crear una tabla dinámica para analizar datos de una hoja de cálculo
        public static IList<Attachment> GetCrearTablaDinamicaExcel()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Crear una tabla dinámica para analizar datos de una hoja de cálculo",
                    "Se aplica a: Excel 2016 Excel 2013 Excel 2010 Excel 2007",
                    "Siga los siguientes pasos:\r\r"+
                    ">1. Haga clic en una celda del rango de datos.\r\r"+
                    ">2. Vaya a **Insertar** > **Tablas** > **Tabla dinámica recomendada**.\r\r"+
                    ">3. Excel le brinda varias opciones, seleccione una y haga clic en **Aceptar**",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Crear-una-tabla-din%C3%A1mica-para-analizar-datos-de-una-hoja-de-c%C3%A1lculo-a9a84538-bfe9-40a9-a8e9-f99134456576")),
               };
        }

        // Crear un histograma en Excel
        public static IList<Attachment> GetCrearHistogramaExcel()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Crear un histograma en Excel",
                    "Se aplica a: Excel 2016 Word 2016 Outlook 2016 PowerPoint 2016 Excel 2013",
                    "Siga los siguientes pasos:\r\r"+
                    ">1. Seleccione los datos.\r\r"+
                    ">2. Haga clic en **Insertar** > **Insertar gráfico estadístico** > **Histograma**.\r\r"+
                    "![duck](https://support.content.office.net/es-es/media/f2724c8f-ac73-43c9-a0b2-718be485a399.png)",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/crear-un-histograma-en-excel-85680173-064b-4024-b39d-80f17ff2f4e8?ui=es-ES&rs=es-ES&ad=ES")),
               };
        }

        // Crear un modelo de datos en Excel
        public static IList<Attachment> GetCrearModeloDatos()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Crear un modelo de datos en Excel",
                    "Se aplica a: Excel 2016 Excel 2013",
                    "Un modelo de datos es un nuevo método para integrar datos de varias tablas y generar de forma efectiva un origen de datos "+
                    "relacional en un libro de Excel, estos se usan de forma transparente y proporcionan datos tabulares utilizados en tablas y"+
                    " gráficos dinámicos.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Crear-un-modelo-de-datos-en-Excel-87e7a54c-87dc-488e-9410-5c75dbcb0f7b")),
               };
        }

        // Crear un formato de número personalizado
        public static IList<Attachment> GetCrearFormatoNumeroPersonalizado()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Crear un formato de número personalizado",
                    "Se aplica a: Excel 2016 Excel 2013 Excel 2010 Excel 2007 ",
                    "Siga los siguientes pasos:\r\r"+
                    ">1. En la pestaña **Inicio**, haga clic en el Selector de cuadro de diálogo junto a **Número**.\r\r"+
                    "![duck](https://support.content.office.net/es-es/media/63114aca-c8ba-4cd3-a58c-d518828c484d.jpg)\r\r"+
                    ">2. En el cuadro **Categoría**, haga clic en **Personalizado**.\r\r"+
                    ">3. En el cuadro **Tipo**, realice los cambios necesarios en el formato de número seleccionado",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Crear-o-eliminar-un-formato-de-n%C3%BAmero-personalizado-78f2a361-936b-4c03-8772-09fab54be7f4")),
               };
        }

        // Crear una macro
        public static IList<Attachment> GetCrearMacro()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Crear una macro",
                    "Se aplica a: Excel 2016 Excel 2013 Excel 2010 Excel 2016 para Mac ",
                    "Siga los siguientes pasos:\r\r"+
                    ">1. En el grupo Código en la pestaña **Desarrollador**, haga clic en **Grabar macro**.\r\r"+
                    "![duck](https://support.content.office.net/es-es/media/b962324a-f530-4dc2-bd6c-401bc1faaafa.jpg)\r\r"+
                    ">2. Escriba un nombre para la macro en el cuadro **Nombre de la macro**\r\r"+
                    ">3. Especifique una tecla de método abreviado en el cuadro **Tecla de método abreviado**\r\r"+
                    ">4. Haga clic en **Aceptar** para comenzar a grabar.\r\r"+
                    ">5. Realice las acciones que desee automatizar.\r\r"+
                    ">6. Haga clic en **Detener grabación**.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/inicio-r%C3%A1pido-crear-una-macro-741130ca-080d-49f5-9471-1e5fb3d581a8")),
               };
        }

        //- INSERTAR / AGREGAR -
        //----------------------
        // Insertar, mover o eliminar saltos de página en una hoja de cálculo
        public static IList<Attachment> GetInsertarSaltosPaginaHojaCalculo()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Insertar un objeto en la hoja de cálculo de Excel",
                    "Se aplica a: Excel 2016 Excel 2013 Excel 2010 Excel 2007",
                    "Siga los siguientes pasos:\r\r"+
                    ">1. En la ficha **Ver**, en el grupo **Vistas de libro**, haga clic en **Vista previa de salto de página**.\r\r"+
                    "![duck](https://support.content.office.net/es-es/media/67067591-a24b-4c5a-8c18-e1c44efb2a0c.png)\r\r"+
                    ">2. Seleccione la fila o columna donde quiera insertarlo.\r\r"+
                    ">3. En el grupo **Configurar página** de la pestaña **Diseño de página**, haga clic en **Saltos** y luego en **Insertar salto de página**.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/insertar-mover-o-eliminar-saltos-de-p%c3%a1gina-en-una-hoja-de-c%c3%a1lculo-ad3dc726-beec-4a4c-861f-ed640612bdc2?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Escribir, insertar o cambiar una ecuación
        public static IList<Attachment> GetInsertarEcuacion()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Insertar o cambiar una ecuación",
                    "Se aplica a: Excel 2016 Word 2016 Outlook 2016 PowerPoint 2016 OneNote 2016",
                    "Siga los siguientes pasos:\r\r"+
                    ">1. Elija **Insertar** > **Ecuación** y seleccione la ecuación que prefiera de la galería.\r\r"+
                    "![duck](https://support.content.office.net/es-es/media/d557f6b7-4c2e-44c4-a053-5f6a276d914e.png)",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/insertar-mover-o-eliminar-saltos-de-p%c3%a1gina-en-una-hoja-de-c%c3%a1lculo-ad3dc726-beec-4a4c-861f-ed640612bdc2?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Agregar una consulta a una hoja de cálculo de Excel (Power Query)
        public static IList<Attachment> GetAgregarConsultaHojaCalculo()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Agregar una consulta a una hoja de cálculo de Excel (Power Query)",
                    "Se aplica a: Excel 2016 Excel 2013 Excel 2010",
                    "En Power Query, tiene varias opciones para cargar consultas en su libro de trabajo. El cuadro de diálogo"+
                    " **Opciones** le permite establecer los ajustes de carga de consulta predeterminados.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/agregar-una-consulta-a-una-hoja-de-c%c3%a1lculo-de-excel-power-query-ca69e0f0-3db1-4493-900c-6279bef08df4?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Insertar  filas y columnas
        public static IList<Attachment> GetInsertarCeldasFilasColumnas()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Insertar celdas, filas y columnas",
                    "Se aplica a: Excel 2016 Excel 2013 Excel 2010 Excel 2007 ",
                    "Siga los siguientes pasos:\r\r"+
                    ">1. Seleccione la celda o el intervalo de celdas en las que va insertar las nuevas celdas.\r\r"+
                    ">2. En el grupo **Celdas** haga clic en  **Insertar** > **Insertar celdas**. \r\r"+
                    ">3. En el cuadro de diálogo **Insertar**, haga clic en la dirección donde quiere desplazar las celdas adyacentes.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/insertar-o-eliminar-celdas-filas-y-columnas-6f40e6e4-85af-45e0-b39d-65dd504a3246?ui=es-ES&rs=es-HN&ad=PE")),
            };
        }

        // Insertar títulos a gráficos
        public static IList<Attachment> GetAgregarTitulosGraficos()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Agregar título a un gráfico",
                    "Se aplica a: Excel 2016 Word 2016 Outlook 2016 PowerPoint 2016",
                    "Cuando se crea un gráfico, aparece un cuadro de título de gráfico encima del gráfico. Simplemente puede activar esta casilla y "+
                    "escriba el título que desee, aplique el formato que desee y moverla a un lugar diferente en el gráfico.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/agregar-o-quitar-t%C3%ADtulos-de-un-gr%C3%A1fico-4cf3c009-1482-4908-922a-997c32ea8250?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Agregar una línea de tendencia a un gráfico
        public static IList<Attachment> GetAgregarLineaTendencia()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Agregar una línea de tendencia a un gráfico",
                    "Se aplica a: Excel 2016 Word 2016 Outlook 2016 PowerPoint 2016",
                    "Siga los siguientes pasos:\r\r"+
                    ">1. En el [gráfico](https://support.office.com/es-es/article/crear-un-gr%C3%A1fico-de-principio-a-fin-0baf399e-dd61-4e18-8a73-b3fd5d5680c2?ui=es-ES&rs=es-ES&ad=ES), haga clic en el serie de datos al que desea agregar una línea de tendencia\r\r"+
                    ">2. Haga clic en el botón **Elementos de gráfico** ![duck](https://support.content.office.net/es-es/media/626dda4e-57b4-416e-bc66-e7479e005a0a.jpg)\r\r"+
                    ">3. Active la casilla **Línea de tendencia**.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/agregar-una-l%C3%ADnea-promedio-m%C3%B3vil-o-de-tendencia-a-un-gr%C3%A1fico-fa59f86c-5852-4b68-a6d4-901a745842ad?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Insertar o quitar bordes de celda en una hoja de cálculo
        public static IList<Attachment> GetInsertarQuitarBordesCeldaHojaCalculo()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Insertar o quitar bordes de celda en una hoja de cálculo",
                    "Se aplica a: Excel 2016 Excel 2013",
                    "Siga los siguientes pasos:\r\r"+
                    ">1. Seleccione la celda o rango de celdas.\r\r"+
                    ">2. En la pestaña **Inicio**, haga clic en la flecha situada junto a **bordes** y elija las opciones de borde que desee.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Insertar-o-quitar-bordes-de-celda-en-una-hoja-de-c%C3%A1lculo-54fc84b6-d267-4d2c-bb27-7b00bb0abbf1")),
            };
        }

        // Agregar valores que coinciden con un único criterio con una función
        public static IList<Attachment> GetAgregarValoresFuncion()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Agregar valores en una función específica",
                    "Se aplica a: Excel 2016 Excel 2013 Excel 2010 Excel 2007",
                    "Algunas funciones:\r\r"+
                    ">1. [SUMAR.SI](https://support.office.com/es-es/article/sumar-si-funci%C3%B3n-sumar-si-169b8c99-c05c-4483-a712-1697a653039b?ui=es-ES&rs=es-ES&ad=ES) (función SUMAR.SI)\r\r"+
                    ">2. [SUMAR.SI.CONJUNTO](https://support.office.com/es-es/article/sumar-si-conjunto-funci%C3%B3n-sumar-si-conjunto-c9e748f5-7ea7-455d-9406-611cebce642b?ui=es-ES&rs=es-ES&ad=ES) (función SUMAR.SI.CONJUNTO)\r\r",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://answers.microsoft.com/es-es/msoffice/forum/msoffice_excel?auth=1")),
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

        // USAR
        //--------------------
        // Usar una plantilla en Excel  
        public static IList<Attachment> GetUsarPlantillaExcel()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Usar una plantilla en Excel",
                    "Se aplica a: Excel 2016 para Mac PowerPoint 2016 para Mac Word 2016 para Mac",
                    "Para iniciar un nuevo libro basado en una plantilla, en el menú **Archivo**, haga clic en"+
                    " **nuevo a partir de plantilla** y, a continuación, seleccione la plantilla que desee usar.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/crear-y-usar-su-propia-plantilla-en-office-para-mac-a1b72758-61a0-4215-80eb-165c6c4bed04?ui=es-ES&rs=es-ES&ad=ES")),
               };
        }

        // Usar fórmulas con formato condicional
        public static IList<Attachment> GetUsarFormulasFormatoCondicional()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Usar fórmulas con formato condicional",
                    "Se aplica a: Excel 2016 Excel 2013 Excel 2010 Excel 2007",
                    "El formato condicional resalta rápidamente información importante en una hoja de cálculo. Sin embargo, a veces las reglas de formato integradas no van lo bastante lejos."+
                    " Por esa razón debe añadir su propia regla de formato condicional que lo ayudará a agilizar acciones que las reglas integradas no pueden realizar.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/usar-f%C3%B3rmulas-con-formato-condicional-fed60dfa-1d3f-4e13-9ecb-f1951ff89d7f")),
               };
        }

        // Usar fórmulas en Excel
        public static IList<Attachment> GetUsarFormulasExcel()
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
               };
        }

        // Usar nombres en fórmulas
        public static IList<Attachment> GetUsarNombresFormulas()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Usar nombres en fórmulas",
                    "Se aplica a: Excel 2016 Excel 2013 Excel 2010 Excel 2007",
                    "Si utiliza nombres, sus fórmulas serán mucho más fáciles de entender y mantener. Puede definir un nombre para un rango de celdas, una función, "+
                    "una constante o una tabla. Una vez que haya adoptado la práctica de utilizar nombres en su libro, podrá actualizar, auditar y administrar esos nombres con facilidad.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Definir-y-usar-nombres-en-f%C3%B3rmulas-4d0f13ac-53b7-422e-afd2-abd7ff379c64")),
               };
        }

        // Usar Excel como calculadora
        public static IList<Attachment> GetUsarExcelCalculadora()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Usar Excel como calculadora",
                    "Se aplica a: Excel 2016 Excel 2013 Excel 2010 Excel 2007",
                    "En un hoja de cálculo, puede escribir fórmulas sencillas para agregar, dividir, multiplicar y restar dos o más valores numéricos. Cuando se familiarice con éstas "+
                    "y desee obtener más información sobre cómo crear fórmulas complejas, puede obtener más información en "+
                    "[información general sobre las fórmulas](https://support.office.com/es-es/article/informaci%C3%B3n-general-sobre-f%C3%B3rmulas-en-excel-ecfdc708-9162-49e8-b993-c311f47ca173?ui=es-ES&rs=es-ES&ad=ES)"+
                    " y [lista de funciones de hoja de cálculo](https://support.office.com/es-es/article/lista-de-funciones-de-hoja-de-c%C3%A1lculo-por-categor%C3%ADa-9d1bdb2c-9fbd-4b9f-9a62-7b1c61c771da).",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/usar-excel-como-calculadora-a1abc057-ed11-443a-a635-68216555ad0a")),
               };
        }

        // Usar columnas calculadas en una tabla de Excel
        public static IList<Attachment> GetUsarColumnasCalculadasExcel()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Usar columnas calculadas en una tabla de Excel",
                    "Se aplica a: Excel 2016 Excel 2013 Excel 2010 Excel 2007",
                    "Las columnas calculadas le permiten especificar una fórmula en una celda y dicha fórmula expandirá automáticamente al resto de la columna por sí mismo."+
                    " No es necesario utilizar los comandos rellenar ni copiar. Esto puede ser muy un ahorro de tiempo, especialmente si tiene una gran cantidad de filas.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Usar-columnas-calculadas-en-una-tabla-de-Excel-873fbac6-7110-4300-8f6f-aafa2ea11ce8")),
               };
        }

        // Usar la lista de campos para organizar los campos en una tabla dinámica
        public static IList<Attachment> GetUsarListaCamposTabla()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Usar la lista de campos para organizar los campos en una tabla dinámica",
                    "Se aplica a: Excel 2016 Excel 2013 Excel 2010 Excel 2007",
                    "Si hace clic dentro de la tabla dinámica, pero no ve la lista de campos, haga lo siguiente para abrirla:\r\r"+
                    ">1. Haga clic en cualquier parte de la tabla dinámica para mostrar las **Herramientas de tabla dinámica**.\r\r"+
                    ">2. Haga clic en **Analizar** > **Lista de campos**.\r\r"+
                    "![duck](https://support.content.office.net/es-es/media/7ea8506a-2ca2-4e0b-a050-711120a9bec1.jpg)",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Usar-columnas-calculadas-en-una-tabla-de-Excel-873fbac6-7110-4300-8f6f-aafa2ea11ce8")),
               };
        }

        // Usar funciones en Excel
        public static IList<Attachment> GetUsarFuncionesExcel()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Usar funciones en Excel",
                    "Se aplica a: Excel",
                    "Una función es una fórmula predefinida que le permite ahorrar tiempo. Por ejemplo, use la función SUMA para sumar una gran "+
                    "cantidad de números o celdas, y use la función PRODUCTO para multiplicarlos.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/usar-funciones-en-excel-2013-feca0bfc-79ed-4052-b8b3-db9b32fa7aec")),
                GetVideoCard(
                    "Office 365 - Excel",
                    "Funciones en Excel",
                    "http://wus-streaming-video-rt-microsoft-com.akamaized.net/5e355f0c-b138-4d2f-a74a-d82147bc672a/3dd25b76-3085-437c-93f6-4f4523d0_1280x720_2993.mp4",
                    "https://support.office.com/es-es/article/usar-funciones-en-excel-2013-feca0bfc-79ed-4052-b8b3-db9b32fa7aec"),
               };
        }

        // Funciones de compatibilidad
        public static IList<Attachment> GetUsarFuncionCompatibilidad()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Funciones de compatibilidad",
                    "Se aplica a: Excel 2016 Excel 2013 Excel 2010",
                    "Algunos ejemplos de funciones de compatibilidad:\r\r"+
                    "> Función [DISTR.BETA](https://support.office.com/es-es/article/funci%C3%B3n-distrbeta-49f1b9a9-a5da-470f-8077-5f1730b5fd47): Devuelve la función de distribución beta acumulativa.\r\r"+
                    "> Función [PRONOSTICO](https://support.office.com/es-es/article/funci%C3%B3n-pronostico-50ca49c9-7b40-4892-94e4-7ad38bbeda99): Devuelve un valor en una tendencia lineal.\r\r"+
                    "> Función [MODA](https://support.office.com/es-es/article/funci%C3%B3n-moda-e45192ce-9122-4980-82ed-4bdc34973120): Devuelve el valor más común de un conjunto de datos.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/funciones-de-compatibilidad-referencia-3d03e2d6-8559-4962-b037-58ac27efa2ad")),
               };
        }

        // Funciones de cubo
        public static IList<Attachment> GetUsarFuncionCubo()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Funciones de cubo",
                    "Se aplica a: Excel 2016 Excel 2013 Excel 2010",
                    "Algunos ejemplos de funciones de cubo:\r\r"+
                    "> Función [VALORCUBO](https://support.office.com/es-es/article/funci%C3%B3n-valorcubo-8733da24-26d1-4e34-9b3a-84a8f00dcbe0): Devuelve un valor agregado del cubo.\r\r"+
                    "> Función [RECUENTOCONJUNTOCUBO](https://support.office.com/es-es/article/funci%C3%B3n-recuentoconjuntocubo-c4c2a438-c1ff-4061-80fe-982f2d705286): Devuelve el número de elementos de un conjunto.\r\r"+
                    "> Función [MIEMBROCUBO](https://support.office.com/es-es/article/funci%C3%B3n-miembrocubo-0f6a15b9-2c18-4819-ae89-e1b5c8b398ad): Devuelve un miembro o tupla del cubo. Se usa para validar la existencia del miembro o la tupla en el cubo.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/funciones-de-cubo-referencia-2378132b-d3f2-4af1-896d-48a9ee840eb2")),
               };
        }

        // Funciones de base de datos
        public static IList<Attachment> GetUsarFuncionBaseDatos()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Funciones de base de datos",
                    "Se aplica a: Excel 2016 Excel 2013 Excel 2010",
                    "Algunos ejemplos de funciones de base de datos:\r\r"+
                    "> Función [BDPROMEDIO](https://support.office.com/es-es/article/funci%C3%B3n-bdpromedio-a6a2d5ac-4b4b-48cd-a1d8-7b37834e5aee): Devuelve el promedio de las entradas seleccionadas en la base de datos.\r\r"+
                    "> Función [BDMAX](https://support.office.com/es-es/article/funci%C3%B3n-bdmax-f4e8209d-8958-4c3d-a1ee-6351665d41c2): Devuelve el valor máximo de las entradas seleccionadas de la base de datos.\r\r"+
                    "> Función [BDSUMA](https://support.office.com/es-es/article/funci%C3%B3n-bdsuma-53181285-0c4b-4f5a-aaa3-529a322be41b): Suma los números de la columna de campo de los registros de la base de datos que cumplen los criterios.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/funciones-de-base-de-datos-referencia-ad87e69b-fc20-4d3d-9d52-d7dc023f5c23")),
               };
        }

        // Funciones de fecha y hora
        public static IList<Attachment> GetUsarFuncionFechaHora()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Funciones de fecha y hora",
                    "Se aplica a: Excel 2016 Excel 2013 Excel 2010",
                    "Algunos ejemplos de funciones de fecha y hora:\r\r"+
                    "> Función [FECHA](https://support.office.com/es-es/article/funci%C3%B3n-fecha-e36c0c8c-4104-49da-ab83-82328b832349): Devuelve el número de serie correspondiente a una fecha determinada.\r\r"+
                    "> Función [DIA](https://support.office.com/es-es/article/funci%C3%B3n-dia-8a7d1cbb-6c7d-4ba1-8aea-25c134d03101): Convierte un número de serie en un valor de día del mes.\r\r"+
                    "> Función [DIAS.LAB](https://support.office.com/es-es/article/funci%C3%B3n-diaslab-48e717bf-a7a3-495f-969e-5005e3eb18e7): Devuelve el número de todos los días laborables existentes entre dos fechas.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/funciones-de-fecha-y-hora-referencia-fd1b5961-c1ae-4677-be58-074152f97b81")),
               };
        }

        // Funciones de información
        public static IList<Attachment> GetUsarFuncionInformacion()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Funciones de información",
                    "Se aplica a: Excel 2016 Excel 2013 Excel 2010",
                    "Algunos ejemplos de funciones de información:\r\r"+
                    "> Función [CELDA](https://support.office.com/es-es/article/funci%C3%B3n-celda-51bd39a5-f338-4dbe-a33f-955d67c2b2cf): Devuelve información acerca del formato, la ubicación o el contenido de una celda.\r\r"+
                    "> Función [INFO](https://support.office.com/es-es/article/funci%C3%B3n-info-725f259a-0e4b-49b3-8b52-58815c69acae): Devuelve información acerca del entorno operativo en uso.\r\r"+
                    "> Función [ESREF](https://support.office.com/es-es/article/funci%C3%B3n-esref-0f2d7971-6019-40a0-a171-f2d869135665): Devuelve VERDADERO si el valor es una referencia.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/funciones-de-informaci%C3%B3n-referencia-f953e38d-07e5-4602-b753-1413810950e3")),
               };
        }

        // Funciones lógicas
        public static IList<Attachment> GetUsarFuncionLogica()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Funciones lógicas",
                    "Se aplica a: Excel 2016 Excel 2013 Excel 2010",
                    "Algunos ejemplos de funciones lógicas:\r\r"+
                    "> Función [Y](https://support.office.com/es-es/article/funci%C3%B3n-y-5f19b2e8-e1df-4408-897a-ce285a19e9d9): Devuelve VERDADERO si todos sus argumentos son VERDADERO.\r\r"+
                    "> Función [SI](https://support.office.com/es-es/article/funci%C3%B3n-si-69aed7c9-4e8a-4755-a9bc-aa8bbff73be2): Especifica una prueba lógica que realizar.\r\r"+
                    "> Función [SI.ERROR](https://support.office.com/es-es/article/funci%C3%B3n-sierror-c526fd07-caeb-47b8-8bb6-63f3e417f611): Devuelve un valor que se especifica si una fórmula lo evalúa como un error; de lo contrario, devuelve el resultado de la fórmula.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/funciones-l%C3%B3gicas-referencia-e093c192-278b-43f6-8c3a-b6ce299931f5")),
               };
        }

        // Funciones matemáticas y trigonométricas
        public static IList<Attachment> GetUsarFuncionMatematicaTrigonometrica()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Funciones matemáticas y trigonométricas",
                    "Se aplica a: Excel 2016 Excel 2013 Excel 2010",
                    "Algunos ejemplos de funciones matemáticas y trigonométricas:\r\r"+
                    "> Función [ABS](https://support.office.com/es-es/article/funci%C3%B3n-abs-3420200f-5628-4e8c-99da-c99d7c87713c): Devuelve el valor absoluto de un número.\r\r"+
                    "> Función [LOG10](https://support.office.com/es-es/article/funci%C3%B3n-log10-c75b881b-49dd-44fb-b6f4-37e3486a0211): Devuelve el logaritmo en base 10 de un número.\r\r"+
                    "> Función [SUMAR.SI](https://support.office.com/es-es/article/funci%C3%B3n-sumarsi-169b8c99-c05c-4483-a712-1697a653039b): Suma las celdas especificadas que cumplen unos criterios determinados.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/funciones-matem%C3%A1ticas-y-trigonom%C3%A9tricas-referencia-ee158fd6-33be-42c9-9ae5-d635c3ae8c16")),
               };
        }

        // Funciones estadísticas
        public static IList<Attachment> GetUsarFuncionEstadistica()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Funciones estadísticas",
                    "Se aplica a: Excel 2016 Excel 2013 Excel 2010",
                    "Algunos ejemplos de funciones estadísticas:\r\r"+
                    "> Función [PROMEDIO](https://support.office.com/es-es/article/funci%C3%B3n-promedio-047bac88-d466-426c-a32b-8f33eb960cf6): Devuelve el promedio de sus argumentos.\r\r"+
                    "> Función [CONTAR](https://support.office.com/es-es/article/funci%C3%B3n-contar-a59cd7fc-b623-4d93-87a4-d23bf411294c): Cuenta cuántos números hay en la lista de argumentos.\r\r"+
                    "> Función [FRECUENCIA](https://support.office.com/es-es/article/funci%C3%B3n-frecuencia-44e3be2b-eca0-42cd-a3f7-fd9ea898fdb9): Devuelve una distribución de frecuencia como una matriz vertical.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/funciones-estad%C3%ADsticas-referencia-624dac86-a375-4435-bc25-76d659719ffd")),
               };
        }

        // Funciones de búsqueda y referencia 
        public static IList<Attachment> GetUsarFuncionBusquedaReferencia()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Funciones de búsqueda y referencia ",
                    "Se aplica a: Excel 2016 Excel 2013 Excel 2010",
                    "Algunos ejemplos de búsqueda y referencia:\r\r"+
                    "> Función [DIRECCION](https://support.office.com/es-es/article/funci%C3%B3n-direccion-d0c26c0d-3991-446b-8de4-ab46431d4f89): Devuelve una referencia como texto a una sola celda de una hoja de cálculo.\r\r"+
                    "> Función [HIPERVINCULO](https://support.office.com/es-es/article/funci%C3%B3n-hipervinculo-333c7ce6-c5ae-4164-9c47-7de9b76f577f): Crea un acceso directo o un salto que abre un documento almacenado en un servidor de red, en una intranet o en Internet.\r\r"+
                    "> Función [FILA](https://support.office.com/es-es/article/funci%C3%B3n-fila-3a63b74a-c4d0-4093-b49a-e76eb49a6d8d): Devuelve el número de fila de una referencia.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/funciones-de-b%C3%BAsqueda-y-referencia-referencia-8aa21a3a-b56a-4055-8257-3ec89df2b23e")),
               };
        }

        // Funciones más populares
        public static IList<Attachment> GetUsarFuncionesPopulares()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Funciones más populares",
                    "Se aplica a: Excel 2016 Excel 2013 Excel 2010",
                    "Algunos ejemplos de funciones estadísticas:\r\r"+
                    "> Función [SUMA](https://support.office.com/es-es/article/funci%C3%B3n-suma-043e1c7d-7726-4e80-8f32-07b23e057f89): Use esta función para agregar los valores de las celdas.\r\r"+
                    "> Función [SI](https://support.office.com/es-es/article/funci%C3%B3n-si-69aed7c9-4e8a-4755-a9bc-aa8bbff73be2): Use esta función para devolver un valor si una condición es verdadera y otro valor si es falsa. [Vídeo acerca del uso de la función SI](https://support.office.com/es-es/article/aqu%C3%AD-puede-ver-un-v%C3%ADdeo-acerca-del-uso-de-la-funci%C3%B3n-si-c3ca139f-f7c6-495d-a65b-61947f7a103e).\r\r"+
                    "> Función [BUSCAR](https://support.office.com/es-es/article/funci%C3%B3n-buscar-446d94af-663b-451d-8251-369d5e3864cb): Use esta función cuando necesite buscar en una sola fila o columna y encontrar un valor desde la misma posición en una segunda fila o columna.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/funciones-de-excel-por-categor%C3%ADa-5f91f4e9-7b42-46d2-9bd1-63f26a86c0eb")),
               };
        }

        // IMPORTAR
        //--------------------
        // Importar datos en Excel y crear un modelo de datos
        public static IList<Attachment> GetImportarDatosExcel()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Importar datos en Excel y crear un modelo de datos",
                    "Se aplica a: Excel 2016 Excel 2013",
                    "Tiene estas opciones:\r\r"+
                    ">* [Importar datos desde una base de datos](https://support.office.com/es-es/article/tutorial-importar-datos-en-excel-y-crear-un-modelo-de-datos-4b4e5ab4-60ee-465e-8195-09ebba060bf0?ui=es-ES&rs=es-ES&ad=ES#__toc358186197)\r\r"+
                    ">* [Importar datos de una hoja de cálculo](https://support.office.com/es-es/article/tutorial-importar-datos-en-excel-y-crear-un-modelo-de-datos-4b4e5ab4-60ee-465e-8195-09ebba060bf0?ui=es-ES&rs=es-ES&ad=ES#__toc358186198)\r\r"+
                    ">* [Importar datos con la función copiar y pegar](https://support.office.com/es-es/article/tutorial-importar-datos-en-excel-y-crear-un-modelo-de-datos-4b4e5ab4-60ee-465e-8195-09ebba060bf0?ui=es-ES&rs=es-ES&ad=ES#__toc358186199)",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/tutorial-importar-datos-en-excel-y-crear-un-modelo-de-datos-4b4e5ab4-60ee-465e-8195-09ebba060bf0?ui=es-ES&rs=es-ES&ad=ES")),
               };
        }

        // VER - MOSTRAR
        //--------------------
        // Mostrar u ocultar fórmulas
        public static IList<Attachment> GetMostrarFormulas()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Mostrar u ocultar fórmulas",
                    "Se aplica a: Excel 2016 Excel 2013 Excel 2010 Excel 2007",
                    "Haga clic en la pestaña **Revisar** y, después, haga clic en **Desproteger hoja**. Si el botón **Desproteger hoja** no está "+
                    "disponible, desactive primero [la característica Libro compartido](https://support.office.com/es-es/article/la-característica-libro-compartido-49b833c0-873b-48d8-8bf2-c1c59a628534).",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/mostrar-u-ocultar-f%c3%b3rmulas-f7f5ab4e-bf24-4efc-8fc9-0c1b77a5356f?ui=es-ES&rs=es-ES&ad=ES")),
               };
        }

        // Mostrar u ocultar valores cero
        public static IList<Attachment> GetMostrarValoresCero()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Mostrar valores cero",
                    "Se aplica a: Excel 2016 Excel 2013 Excel 2010 Excel 2007 ",
                    "Siga los siguientes pasos:\r\r"+
                    ">1. Haga clic en **Archivo** > **Opciones** > **Avanzadas**.\r\r"+
                    ">2. En **Mostrar opciones para esta hoja**, seleccione una hoja de cálculo y, "+
                    "active la casilla **Mostrar un cero en celdas que tienen un valor cero**.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Mostrar-u-ocultar-valores-cero-3ec7a433-46b8-4516-8085-a00e9e476b03")),
            };
        }

        // Mostrar u ocultar filas o columnas
        public static IList<Attachment> GetMostrarFilasColumnas()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Mostrar u ocultar filas o columnas",
                    "Se aplica a: Excel 2016 Excel 2013 Excel 2010 Excel 2007 ",
                    "Siga los siguientes pasos:\r\r"+
                    ">1. Para mostrar las filas ocultas, seleccione la fila por encima y por debajo de las filas que desea mostrar.\r\r"+
                    ">2. En la ficha **Inicio**, en el grupo **Celdas**, haga clic en la opción **Formato**.\r\r"+
                    ">3. En **Visibilidad**, elija **Ocultar y mostrar** y, a continuación, haga clic en **Mostrar filas** o en **Mostrar columnas**.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/mostrar-u-ocultar-filas-o-columnas-659c2cad-802e-44ee-a614-dde8443579f8?ui=es-ES&rs=es-HN&ad=PE#bmdisplayrowcolumn")),
            };
        }

        // Mostrar una hoja de cálculo oculta
        public static IList<Attachment> GetMostrarHojaCalculoOculta()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Mostrar una hoja de cálculo oculta",
                    "Se aplica a: Excel 2016 Excel 2013 Excel 2010",
                    "Siga los siguientes pasos:\r\r"+
                    ">1. Haga clic en Inicio > formato.\r\r"+
                    "![duck](https://support.content.office.net/es-es/media/88b7e837-5fc0-4596-9159-b6eda61cfb04.gif)\r\r"+
                    ">2. En **Visibilidad**, haga clic en **Ocultar y mostrar** y en **Mostrar hoja**.\r\r"+
                    ">3. En el cuadro **Mostrar**, haga doble clic en el nombre de la hoja oculta que desee mostrar.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/ocultar-o-mostrar-hojas-de-c%c3%a1lculo-o-libros-a8f5977c-8f1a-4ce7-a45d-58cd2c7516de?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Mostrar u ocultar las líneas de división en una hoja de cálculo
        public static IList<Attachment> GetMostrarLineaCuadricula()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Mostrar una hoja de cálculo oculta",
                    "Se aplica a: Excel 2016 Excel 2013 Excel 2010 Excel 2007",
                    "Siga los siguientes pasos:\r\r"+
                    ">1. [Seleccione una o más hojas de cálculo](https://support.office.com/es-es/article/seleccione-una-o-más-hojas-de-cálculo-096b40c9-0ee7-4980-bac6-cc92aec7b266).\r\r"+
                    ">2. En la ficha **Ver** o **Vista**, en el grupo **Mostrar/ocultar**, active la casilla de verificación **Líneas de cuadrícula**.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/mostrar-u-ocultar-las-l%c3%adneas-de-divisi%c3%b3n-en-una-hoja-de-c%c3%a1lculo-3ef5aacb-4539-4ad5-9945-5ed53772dc4d?ui=es-ES&rs=es-HN&ad=PE")),
            };
        }

        // Mostrar números como fechas u horas
        public static IList<Attachment> GetMostrarNumerosFechasHoras()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Mostrar números como fechas u horas",
                    "Se aplica a: Excel 2016 Excel 2013 Excel 2010 Excel 2007",
                    "Siga los siguientes pasos:\r\r"+
                    ">1. En el grupo **Número** de la ficha Inicio, haga clic en el selector de cuadro de diálogo situado junto a **Número**.\r\r"+
                    "![duck](https://support.content.office.net/es-es/media/63114aca-c8ba-4cd3-a58c-d518828c484d.jpg)\r\r"+
                    ">2. En la lista **Categoría**, haga clic en **Fecha** o en **Hora**.\r\r"+
                    ">3. En la lista **Tipo**, haga clic en el formato de fecha u hora que desea utilizar y en **Aceptar**",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Mostrar-n%C3%BAmeros-como-fechas-u-horas-418bd3fe-0577-47c8-8caa-b4d30c528309")),
            };
        }
        // Mostrar números como moneda
        public static IList<Attachment> GetMostrarNumerosMoneda()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Mostrar números como moneda",
                    "Se aplica a: Excel 2016 Excel 2013 Excel 2010 Excel 2007",
                    "Siga los siguientes pasos:\r\r"+
                    ">1. En la pestaña **Inicio**, haga clic en el selector de cuadro de diálogo junto a **Número**.\r\r"+
                    "![duck](https://support.content.office.net/es-es/media/63114aca-c8ba-4cd3-a58c-d518828c484d.jpg)\r\r"+
                    ">2. En la lista **Categoría**, haga clic en **Moneda** o en **Contabilidad**.\r\r"+
                    ">3. En el cuadro **Símbolo**, haga clic en el símbolo de moneda que desee usar. y en **Aceptar**",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Mostrar-n%C3%BAmeros-como-moneda-0a03bb38-1a07-458d-9e30-2b54366bc7a4")),
            };
        }
        // Mostrar números como fechas, horas  y mostrar números como monedas
        public static IList<Attachment> GetMostrarNumerosFechasHorasMonedas()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Mostrar números como fechas u horas",
                    "Se aplica a: Excel 2016 Excel 2013 Excel 2010 Excel 2007",
                    "Siga los siguientes pasos:\r\r"+
                    ">1. En el grupo **Número** de la ficha Inicio, haga clic en el selector de cuadro de diálogo situado junto a **Número**.\r\r"+
                    "![duck](https://support.content.office.net/es-es/media/63114aca-c8ba-4cd3-a58c-d518828c484d.jpg)\r\r"+
                    ">2. En la lista **Categoría**, haga clic en **Fecha** o en **Hora**.\r\r"+
                    ">3. En la lista **Tipo**, haga clic en el formato de fecha u hora que desea utilizar y en **Aceptar**",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Mostrar-n%C3%BAmeros-como-fechas-u-horas-418bd3fe-0577-47c8-8caa-b4d30c528309")),
                GetHeroCardV2(
                    "Mostrar números como moneda",
                    "Se aplica a: Excel 2016 Excel 2013 Excel 2010 Excel 2007",
                    "Siga los siguientes pasos:\r\r"+
                    ">1. En la pestaña **Inicio**, haga clic en el selector de cuadro de diálogo junto a **Número**.\r\r"+
                    "![duck](https://support.content.office.net/es-es/media/63114aca-c8ba-4cd3-a58c-d518828c484d.jpg)\r\r"+
                    ">2. En la lista **Categoría**, haga clic en **Moneda** o en **Contabilidad**.\r\r"+
                    ">3. En el cuadro **Símbolo**, haga clic en el símbolo de moneda que desee usar. y en **Aceptar**",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Mostrar-n%C3%BAmeros-como-moneda-0a03bb38-1a07-458d-9e30-2b54366bc7a4")),
            };
        }

        // ELIMINAR - QUITAR - DESAPARECER
        //--------------------
        // Quitar una contraseña de una hoja de cálculo o un libro
        public static IList<Attachment> GetQuitarContrasenaHojaCalculolibroExcel()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Quitar la protección en un documento, un libro o una presentación",
                    "Se aplica a: Excel 2016 Word 2016 PowerPoint 2016",
                    "Para quitar la contraseña, abra el archivo que requiere la contraseña actual y vaya a **Archivo** > **Proteger documento** > **Cifrar con contraseña**. "+
                    "Elimine la contraseña y haga clic en Aceptar. No olvide guardar el archivo para hacer que el cambio sea permanente.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/agregar-o-quitar-la-protecci%C3%B3n-en-un-documento-un-libro-o-una-presentaci%C3%B3n-05084cc3-300d-4c1a-8416-38d3e37d6826?ui=es-ES&rs=es-ES&ad=ES")),
            };
        }

        // Quitar valores duplicados
        public static IList<Attachment> GetQuitarValoresDuplicados()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Quitar valores duplicados",
                    "Se aplica a: Excel 2016 Excel 2013 Excel 2010 Excel 2007",
                    "Para quitar valores duplicados, use el comando **Quitar duplicados** del grupo **Herramientas de datos** en la ficha **Datos**.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/Filtrar-valores-%C3%BAnicos-o-quitar-valores-duplicados-ccf664b0-81d6-449b-bbe1-8daaec1e83c2")),
            };
        }

        // Quitar formato condicional
        public static IList<Attachment> GetQuitarFormatoCondicionalExcel()
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
            };
        }

        // APLICAR
        //------------------
        // Aplicar formato condicional en Excel
        public static IList<Attachment> GetAplicarFormatoCondicionalExcel()
        {
            return new List<Attachment>()
            {
                GetHeroCardV2(
                    "Aplicar formato condicional en Excel",
                    "Se aplica a: Excel 2016 Excel 2013",
                    "El formato condicional permite aplicar colores en las celdas según condiciones específicas, como valores duplicados, valores que cumplen criterios específicos. "
                    +"También puede mostrar la clasificación de celdas individuales comparadas con un rango de valores con barras de datos, escalas de colores y conjuntos de iconos.",
                    new CardAction(ActionTypes.OpenUrl, "Ver más información",
                    value: "https://support.office.com/es-es/article/aplicar-formato-condicional-en-excel-34402f91-c7e7-4060-944c-65d913033d18")),
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