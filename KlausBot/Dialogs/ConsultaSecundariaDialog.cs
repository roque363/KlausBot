// Se tiene implementado 
// - AbrirDialog - AgregarDialog - AplicarDialog - BuscarDialog - CambiarDialog - CrearDialog - EliminarDialog - EnviarDialog

using System;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Threading.Tasks;
using System.Collections.Generic;
using KlausBot.Models;
using KlausBot.Util;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Builder.Dialogs;

namespace KlausBot.Dialogs
{
    public class ConsultaSecundariaDialog
    {
        private IDialogContext context;
        private LuisResult result;

        public ConsultaSecundariaDialog(IDialogContext context, LuisResult result)
        {
            this.context = context;
            this.result = result;
        }

        public async Task StartAsync()
        {
            var reply = context.MakeMessage();
            reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;

            string confirmacionRespuesta1 = "También tengo esta respuesta para usted :";
            string confirmacionRespuesta2 = "También tengo estas respuestas para usted :";
            string preguntaNoEncontrada = "Lo siento, no tengo otra respuesta para su pregunta";
            string preguntaConsulta = "si tiene otra consulta por favor hágamelo saber";

            //obtener el estado de la pregunta (*Saber si el usuario a realizado una pregunta o no*)
            var estadoPregunta = "EstadoPregunta";
            context.PrivateConversationData.TryGetValue<string>("EstadoPregunta", out estadoPregunta);

            //obtener la Accion si este a sido escodigo anteriormente
            var acccion = "Accion";
            context.PrivateConversationData.TryGetValue<string>("Accion", out acccion);

            //obtener el producto si este a sido escodigo anteriormente
            var servicio = "Servicio";
            context.PrivateConversationData.TryGetValue<string>("tipoDeServicio", out servicio);

            //obtener la Pregunta::Palabra2 si este a sido escodigo anteriormente
            var palabra1 = "Palabra1";
            context.PrivateConversationData.TryGetValue<string>("Palabra1", out palabra1);

            // -----------------------------------------------------------
            // CREAR
            // -----------------------------------------------------------
            if (palabra1 == "firma" || palabra1 == "firmas")
            {
                if (acccion == "Crear")
                {
                    reply.Attachments = RespuestasOutlook.GetFirma();
                    await context.PostAsync(confirmacionRespuesta1);
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                }
                else if (acccion == "Cambiar")
                {
                    reply.Attachments = RespuestasOutlook.GetFirma();
                    await context.PostAsync(confirmacionRespuesta1);
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                }
                else
                {
                    // Si el usuario no ingreso la primera parte de la pregunta
                    reply.Attachments = Respuestas.GetConsultaV2();
                    await context.PostAsync("Lo siento, ocurrio un error inesperado");
                    await context.PostAsync(reply);
                    return;
                }
            }
            else if (palabra1 == "categoría" || palabra1 == "categoria" || palabra1 == "categorias" || palabra1 == "categorías")
            {
                if (acccion == "Crear")
                {
                    reply.Attachments = RespuestasOutlook.GetUtiliceCategoriasOutlook();
                    await context.PostAsync(confirmacionRespuesta1);
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                }
                else if (acccion == "Eliminar")
                {
                    reply.Attachments = RespuestasOutlook.GetAgregarEditarEliminarCategoriaBusiness();
                    await context.PostAsync(confirmacionRespuesta1);
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                }
                else
                {
                    // Si el usuario no ingreso la primera parte de la pregunta
                    reply.Attachments = Respuestas.GetConsultaV2();
                    await context.PostAsync("Lo siento, ocurrio un error inesperado");
                    await context.PostAsync(reply);
                    return;
                }
            }
            else if (palabra1 == "plantilla" || palabra1 == "plantillas")
            {
                reply.Attachments = RespuestasOutlook.GetCrearPlantilla();
                await context.PostAsync(confirmacionRespuesta1);
                await context.PostAsync(reply);
                await context.PostAsync(preguntaConsulta);
            }
            else if (palabra1 == "carpeta" || palabra1 == "carpetas")
            {
                reply.Attachments = RespuestasOutlook.GetCrearUsarCarpetasPersonales();
                await context.PostAsync(confirmacionRespuesta1);
                await context.PostAsync(reply);
                await context.PostAsync(preguntaConsulta);
            }
            else if (palabra1 == "tarea" || palabra1 == "tareas")
            {
                reply.Attachments = RespuestasOutlook.GetCreandoAsignandoTareas();
                await context.PostAsync(confirmacionRespuesta1);
                await context.PostAsync(reply);
                await context.PostAsync(preguntaConsulta);
            }
            else if (palabra1 == "grupo" || palabra1 == "grupos")
            {
                reply.Attachments = RespuestasOutlook.GetCrearGrupo();
                await context.PostAsync(confirmacionRespuesta1);
                await context.PostAsync(reply);
                await context.PostAsync(preguntaConsulta);
            }
            else if (palabra1 == "diseño" || palabra1 == "diseños")
            {
                reply.Attachments = RespuestasOutlook.GetCrearDiseños();
                await context.PostAsync(confirmacionRespuesta1);
                await context.PostAsync(reply);
                await context.PostAsync(preguntaConsulta);
            }
            else if (palabra1 == "evento" || palabra1 == "eventos")
            {
                reply.Attachments = RespuestasOutlook.GetCrearEvento();
                await context.PostAsync(confirmacionRespuesta1);
                await context.PostAsync(reply);
                await context.PostAsync(preguntaConsulta);
            }
            else if (palabra1 == "vista" || palabra1 == "vistas")
            {
                await context.PostAsync(preguntaNoEncontrada);
            }
            else if (palabra1 == "correo" || palabra1 == "correos" || palabra1 == "mensaje" || palabra1 == "mensajes" || palabra1 == "correoelectronico")
            {
                if (acccion == "Buscar")
                {
                    reply.Attachments = RespuestasOutlook.GetBuscarsCorreoContactos();
                     await context.PostAsync(confirmacionRespuesta1);
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                }
                else if (acccion == "Crear")
                {
                    reply.Attachments = RespuestasOutlook.GetCrearMensaje();
                    await context.PostAsync(confirmacionRespuesta1);
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                }
                else
                {
                    // Si el usuario no ingreso la primera parte de la pregunta
                    reply.Attachments = Respuestas.GetConsultaV2();
                    await context.PostAsync("Lo siento, ocurrio un error inesperado");
                    await context.PostAsync(reply);
                    return;
                }
            }
            else if (palabra1 == "cita" || palabra1 == "citas" || palabra1 == "eventos" || palabra1 == "evento" || palabra1 == "reunión" || palabra1 == "reuniones")
            {
                if (acccion == "Cambiar")
                {
                    reply.Attachments = RespuestasOutlook.GetCambiarZonaHorariaCita();
                    await context.PostAsync(confirmacionRespuesta1);
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                }
                else if (acccion == "Crear")
                {
                    reply.Attachments = RespuestasOutlook.GetCrearAgregarCitaEvento();
                    await context.PostAsync(confirmacionRespuesta1);
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                }
                else
                {
                    // Si el usuario no ingreso la primera parte de la pregunta
                    reply.Attachments = Respuestas.GetConsultaV2();
                    await context.PostAsync("Lo siento, ocurrio un error inesperado");
                    await context.PostAsync(reply);
                    return;
                }
            }
            // -----------------------------------------------------------
            // ABRIR
            // -----------------------------------------------------------
            else if (palabra1 == "elemento" || palabra1 == "elementos")
            {
                reply.Attachments = RespuestasOutlook.GetBuscarElemento();
                await context.PostAsync(confirmacionRespuesta2);
                await context.PostAsync(reply);
                await context.PostAsync(preguntaConsulta);
            }
            else if (palabra1 == "archivos" || palabra1 == "archivo")
            {
                await context.PostAsync(preguntaNoEncontrada);
            }
            // -----------------------------------------------------------
            // AGREGAR
            // -----------------------------------------------------------
            else if (palabra1 == "contacto" || palabra1 == "contactos" || palabra1 == "emails" || palabra1 == "email")
            {
                // -----------------------------------------------------------
                // BUSCAR
                // -----------------------------------------------------------
                if (acccion == "Buscar")
                {
                    reply.Attachments = RespuestasOutlook.GetBuscarsCorreoContactos();
                    await context.PostAsync(confirmacionRespuesta1);
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                }
                //--------------------------------------------------------------
                else if (acccion == "Crear")
                {
                    reply.Attachments = RespuestasOutlook.GetAgregarYBloquearContactos();
                    await context.PostAsync(confirmacionRespuesta2);
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                }
                else if (acccion == "Agregar")
                {
                    reply.Attachments = RespuestasOutlook.GetAgregarYBloquearContactos();
                    await context.PostAsync(confirmacionRespuesta2);
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                }
                else
                {
                    // Si el usuario no ingreso la primera parte de la pregunta
                    reply.Attachments = Respuestas.GetConsultaV2();
                    await context.PostAsync("Lo siento, ocurrio un error inesperado");
                    await context.PostAsync(reply);
                    return;
                }
            }
            else if (palabra1 == "graficos" || palabra1 == "grafico" || palabra1 == "gráficos" || palabra1 == "gráfico")
            {
                reply.Attachments = RespuestasOutlook.GetUsarGráficos();
                await context.PostAsync(confirmacionRespuesta1);
                await context.PostAsync(reply);
                await context.PostAsync(preguntaConsulta);
            }
            else if (palabra1 == "tabla" || palabra1 == "tablas")
            {
                reply.Attachments = RespuestasOutlook.GetAgregarTablas();
                await context.PostAsync(confirmacionRespuesta1);
                await context.PostAsync(reply);
                await context.PostAsync(preguntaConsulta);
            }
            else if (palabra1 == "confirmaciones" || palabra1 == "conformación" || palabra1 == "confirmacion")
            {
                reply.Attachments = RespuestasOutlook.GetAgregarConfirmacion();
                await context.PostAsync(confirmacionRespuesta1);
                await context.PostAsync(reply);
                await context.PostAsync(preguntaConsulta);
            }
            else if (palabra1 == "notificaciones" || palabra1 == "notificación" || palabra1 == "notificacion")
            {
                reply.Attachments = RespuestasOutlook.GetActivarDesactivarAlertas();
                await context.PostAsync(confirmacionRespuesta1);
                await context.PostAsync(reply);
                await context.PostAsync(preguntaConsulta);
            }
            else if (palabra1 == "seguimiento" || palabra1 == "seguimientos")
            {
                reply.Attachments = RespuestasOutlook.GetSeguimiento();
                await context.PostAsync(confirmacionRespuesta1);
                await context.PostAsync(reply);
                await context.PostAsync(preguntaConsulta);
            }
            else if (palabra1 == "díasnolaborables" || palabra1 == "diasnolaborables" || palabra1 == "feriados" || palabra1 == "feriado")
            {
                reply.Attachments = RespuestasOutlook.GetAgregarDiasNoLaborables();
                await context.PostAsync(confirmacionRespuesta2);
                await context.PostAsync(reply);
                await context.PostAsync(preguntaConsulta);
            }
            else if (palabra1 == "tarjetas" || palabra1 == "tarjeta")
            {
                reply.Attachments = RespuestasOutlook.GetTarjeta();
                await context.PostAsync(confirmacionRespuesta1);
                await context.PostAsync(reply);
                await context.PostAsync(preguntaConsulta);
            }
            else if (palabra1 == "hipervínculo" || palabra1 == "hipervinculo" || palabra1 == "hipervínculos" || palabra1 == "hipervinculos")
            {
                reply.Attachments = RespuestasOutlook.GetCrearQUitarHipervínculoParaMac();
                await context.PostAsync(confirmacionRespuesta1);
                await context.PostAsync(reply);
                await context.PostAsync(preguntaConsulta);
            }
            // -----------------------------------------------------------
            // APLICAR
            // -----------------------------------------------------------
            else if (palabra1 == "diseñosdefondo" || palabra1 == "diseñosdefondos" || palabra1 == "fondos" || palabra1 == "fondo")
            {
                reply.Attachments = RespuestasOutlook.GetCrearDiseñosParaMensajes();
                await context.PostAsync(confirmacionRespuesta1);
                await context.PostAsync(reply);
                await context.PostAsync(preguntaConsulta);
            }
            // -----------------------------------------------------------
            // CAMBIAR
            // -----------------------------------------------------------
            else if (palabra1 == "modo" || palabra1 == "apariencia")
            {
                reply.Attachments = RespuestasOutlook.GetBuscarsCorreoContactos();
                await context.PostAsync(confirmacionRespuesta1);
                await context.PostAsync(reply);
                await context.PostAsync(preguntaConsulta);
            }
            else if (palabra1 == "vista" || palabra1 == "vistas")
            {
                reply.Attachments = RespuestasOutlook.GetBuscarsCorreoContactos();
                await context.PostAsync(confirmacionRespuesta1);
                await context.PostAsync(reply);
                await context.PostAsync(preguntaConsulta);
            }
            else if (palabra1 == "sonido" || palabra1 == "sonidos")
            {
                reply.Attachments = RespuestasOutlook.GetBuscarsCorreoContactos();
                await context.PostAsync(confirmacionRespuesta1);
                await context.PostAsync(reply);
                await context.PostAsync(preguntaConsulta);
            }
            else if (palabra1 == "nombres" || palabra1 == "nombre" || palabra1 == "personas" || palabra1 == "persona")
            {
                // -----------------------------------------------------------
                // BUSCAR
                // -----------------------------------------------------------
                if (acccion == "Buscar")
                {
                    reply.Attachments = RespuestasOutlook.GetBuscarsCorreoContactos();
                    await context.PostAsync(confirmacionRespuesta1);
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                }
                //--------------------------------------------------------------
                else if (acccion == "Crear")
                {
                    reply.Attachments = RespuestasOutlook.GetAgregarYBloquearContactos();
                    await context.PostAsync(confirmacionRespuesta2);
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                }
                else if (acccion == "Agregar")
                {
                    reply.Attachments = RespuestasOutlook.GetCambiarNombrePerfil();
                    await context.PostAsync(confirmacionRespuesta2);
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                }
                else
                {
                    // Si el usuario no ingreso la primera parte de la pregunta
                    reply.Attachments = Respuestas.GetConsultaV2();
                    await context.PostAsync("Lo siento, ocurrio un error inesperado");
                    await context.PostAsync(reply);
                    return;
                }
            }
            else if (palabra1 == "color" || palabra1 == "colores" || palabra1 == "fuente" || palabra1 == "fuentes")
            {
                reply.Attachments = RespuestasOutlook.GetCambiarTema();
                await context.PostAsync(confirmacionRespuesta1);
                await context.PostAsync(reply);
                await context.PostAsync(preguntaConsulta);
            }
            else if (palabra1 == "tamañodefuente" || palabra1 == "tamañosdefuentes" || palabra1 == "tamaño de fuente")
            {
                reply.Attachments = RespuestasOutlook.GetDefinirFuente();
                await context.PostAsync(confirmacionRespuesta1);
                await context.PostAsync(reply);
                await context.PostAsync(preguntaConsulta);
            }
            else if (palabra1 == "configuración" || palabra1 == "configuracion" || palabra1 == "configuraciones")
            {
                reply.Attachments = RespuestasOutlook.GetCambiarConfiguracionVisualizacionCorreo();
                await context.PostAsync(confirmacionRespuesta1);
                await context.PostAsync(reply);
                await context.PostAsync(preguntaConsulta);
            }
            else if (palabra1 == "ubicación" || palabra1 == "ubicaciones" || palabra1 == "ubicacion")
            {
                await context.PostAsync(preguntaNoEncontrada);
            }
            else if (palabra1 == "nivel" || palabra1 == "niveles")
            {
                await context.PostAsync(preguntaNoEncontrada);
            }
            // -----------------------------------------------------------
            // ENVIAR
            // -----------------------------------------------------------
            else if (palabra1 == "respuestasautomaticas" || palabra1 == "respuestaautomatica" || palabra1 == "respuestasautomáticas" || palabra1 == "respuestaautomática" || palabra1 == "respuestasfuera" || palabra1 == "respuestafuera")
            {
                await context.PostAsync(preguntaNoEncontrada);
            }
            // -----------------------------------------------------------
            else
            {
                if (estadoPregunta == "1")
                {
                    // Si el usuario no ingreso la primera parte de la pregunta
                    reply.Attachments = Respuestas.GetConsultaV2();
                    await context.PostAsync("Lo siento, no tengo otra respuesta");
                    await context.PostAsync(reply);
                    return;
                }
                else
                {
                    // El usuario no a registrado ninguna pregunta
                    reply.Attachments = Respuestas.GetConsultaV2();
                    await context.PostAsync("Lo siento, acaso tienes una consulta");
                    await context.PostAsync(reply);
                    return;
                }
            }
        }
    }
}