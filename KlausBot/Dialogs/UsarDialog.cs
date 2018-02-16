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
    public class UsarDialog
    {
        private IDialogContext context;
        private LuisResult result;

        public UsarDialog(IDialogContext context, LuisResult result)
        {
            this.context = context;
            this.result = result;
        }

        public async Task StartAsync()
        {
            var reply = context.MakeMessage();
            reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;

            var estadoPregunta = "True";
            var estadoPregunta2 = "False";
            var accion = "Usar";
            context.PrivateConversationData.SetValue<string>("Accion", accion);

            var estadoRespuesta = "True";

            string confirmacionRespuesta1 = "Tengo esta respuesta para usted:";
            string confirmacionRespuesta2 = "Tengo estas respuestas para usted:";
            string preguntaNoRegistrada1 = "Lo siento, su pregunta no esta registrada, tal vez no escribió la pregunta correctamente";
            string preguntaNoRegistrada2 = "Lo siento, su pregunta no esta registrada";
            string opcionSecundarioDeRespuesta1 = "Pero esta respuesta le podría interesar:";
            string opcionSecundarioDeRespuesta2 = "Pero estas respuestas le podrían interesar:";
            string preguntaConsulta = "si tiene otra consulta, por favor hágamelo saber";

            foreach (var entityP1 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra1"))
            {
                var palabra1 = entityP1.Entity.ToLower().Replace(" ", "");
                context.PrivateConversationData.SetValue<string>("Palabra1", palabra1);
                // --------------------------------------------------------------------
                if (palabra1 == "@menciones" || palabra1 == "@" || palabra1 == "@mencion")
                {
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");

                        if (palabra2 == "atención" || palabra2 == "atencion")
                        {
                            reply.Attachments = RespuestasOutlook.GetUsarArrobaLlamarAtencion();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = RespuestasOutlook.GetUsarArrobaLlamarAtencion();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = RespuestasOutlook.GetUsarArrobaLlamarAtencion();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    return;
                }
                else if (palabra1 == "asistente")
                {
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");

                        if (palabra2 == "programación" || palabra2 == "programacion")
                        {
                            reply.Attachments = RespuestasOutlook.GetUsarAsistenteProgramacion();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = RespuestasOutlook.GetUsarAsistenteProgramacion();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = RespuestasOutlook.GetUsarAsistenteProgramacion();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    return;
                }
                else if (palabra1 == "calendarios" || palabra1 == "calendario")
                {
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");

                        if (palabra2 == "adecuada" || palabra2 == "recomendados" || palabra2 == "mejorforma" || palabra2 == "adecuadas")
                        {
                            reply.Attachments = RespuestasOutlook.GetUsarCalendarioManeraAdecuadaOutlook();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = RespuestasOutlook.GetUsarCalendarioManeraAdecuadaOutlook();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = RespuestasOutlook.GetUsarCalendarioManeraAdecuadaOutlook();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    return;
                }
                else if (palabra1 == "carpeta" || palabra1 == "carpetas")
                {
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");

                        if (palabra2 == "busqueda" || palabra2 == "búsqueda" || palabra2 == "busquedas" || palabra2 == "búsquedas")
                        {
                            reply.Attachments = RespuestasOutlook.GetUsarCrearCarpetasBusqueda();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = RespuestasOutlook.GetUsarCrearCarpetasBusqueda();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = RespuestasOutlook.GetUsarCrearCarpetasBusqueda();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    return;
                }
                else if (palabra1 == "filtros" || palabra1 == "filtro")
                {
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");

                        if (palabra2 == "detestable" || palabra2 == "detestables" || palabra2 == "nodeseado" || palabra2 == "nodeseados")
                        {
                            foreach (var entityP3 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra3"))
                            {
                                var palabra3 = entityP3.Entity.ToLower().Replace(" ", "");

                                if (palabra3 == "mensajes" || palabra3 == "mensaje" || palabra3 == "correo" || palabra3 == "correos")
                                {
                                    reply.Attachments = RespuestasOutlook.GetUsarFiltrosCorreoNoDeseadoControlarMensajes();
                                    await context.PostAsync(confirmacionRespuesta1);
                                    await context.PostAsync(reply);
                                    await context.PostAsync(preguntaConsulta);
                                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                                    context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                                    return;
                                }
                                else
                                {
                                    reply.Attachments = RespuestasOutlook.GetUsarFiltrosCorreoNoDeseadoControlarMensajes();
                                    await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra3}'?");
                                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                                    await context.PostAsync(reply);
                                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                                    return;
                                }
                            }
                            reply.Attachments = RespuestasOutlook.GetUsarFiltrosCorreoNoDeseadoControlarMensajes();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = RespuestasOutlook.GetUsarFiltrosCorreoNoDeseadoControlarMensajes();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = RespuestasOutlook.GetUsarFiltrosCorreoNoDeseadoControlarMensajes();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    return;
                }
                else if (palabra1 == "limpieza")
                {
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");

                        if (palabra2 == "conversación" || palabra2 == "conversaciones" || palabra2 == "charla" || palabra2 == "charlas")
                        {
                            reply.Attachments = RespuestasOutlook.GetUsarLimpiezaConversacion();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = RespuestasOutlook.GetUsarLimpiezaConversacion();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = RespuestasOutlook.GetUsarLimpiezaConversacion();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    return;
                }
                else if (palabra1 == "correos" || palabra1 == "correo" || palabra1 == "otroscorreos" || palabra1 == "otrocorreo")
                {
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");

                        if (palabra2 == "organizar" || palabra2 == "ordenar" || palabra2 == "estructurar")
                        {
                            reply.Attachments = RespuestasOutlook.GetUsarCorreosOrganizarBajaPrioridad();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = RespuestasOutlook.GetUsarCorreosOrganizarBajaPrioridad();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = RespuestasOutlook.GetUsarCorreosOrganizarBajaPrioridad();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    return;
                }
                else if (palabra1 == "cuentas" || palabra1 == "cuenta")
                {
                    // Se detectó  la segunda parte de la pregunta
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");

                        if (palabra2 == "microsoft" || palabra2 == "Microsoft")
                        {
                            // Se detectó el Servicio de la pregunta
                            foreach (var serv in result.Entities.Where(Entity => Entity.Type == "Servicio"))
                            {
                                var servicioU = serv.Entity.ToLower().Replace(" ", "");
                                if (servicioU == "onenote" || servicioU == "OneNote")
                                {
                                    reply.Attachments = RespuestasOneNote.GetUsarVariasCuentasMicrosoftOneNote();
                                    await context.PostAsync(confirmacionRespuesta1);
                                    await context.PostAsync(reply);
                                    await context.PostAsync(preguntaConsulta);
                                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                                    context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                                    return;
                                }
                                else
                                {
                                    reply.Attachments = RespuestasOneNote.GetUsarVariasCuentasMicrosoftOneNote();
                                    await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{servicioU}'?");
                                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                                    await context.PostAsync(reply);
                                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                                    return;
                                }
                            }
                            // No se detectó el Servicio de la pregunta
                            reply.Attachments = RespuestasOneNote.GetUsarVariasCuentasMicrosoftOneNote();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = RespuestasOneNote.GetUsarVariasCuentasMicrosoftOneNote();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    // Se detectó el Servicio de la pregunta
                    foreach (var serv in result.Entities.Where(Entity => Entity.Type == "Servicio"))
                    {
                        var servicioU = serv.Entity.ToLower().Replace(" ", "");
                        if (servicioU == "onenote" || servicioU == "OneNote")
                        {
                            reply.Attachments = RespuestasOneNote.GetUsarVariasCuentasMicrosoftOneNote();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else if (servicioU == "outlook" || servicioU == "Outlook")
                        {
                            reply.Attachments = RespuestasOneNote.GetUsarVariasCuentasMicrosoftOneNote();
                            await context.PostAsync($"Lo siento no tengo una respuesta con el servicio:'{servicioU}'");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = RespuestasOneNote.GetUsarVariasCuentasMicrosoftOneNote();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{servicioU}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                        }
                    }
                    // No se detectó el Servicio de la pregunta
                    // Obtener el producto si este a sido escodigo anteriormente
                    var servicio2 = "Servicio";
                    context.PrivateConversationData.TryGetValue<string>("tipoDeServicio", out servicio2);
                    if (servicio2 == "OneNote" || servicio2 == "One Note")
                    {
                        reply.Attachments = RespuestasOneNote.GetUsarVariasCuentasMicrosoftOneNote();
                        await context.PostAsync(confirmacionRespuesta1);
                        await context.PostAsync(reply);
                        await context.PostAsync(preguntaConsulta);
                        context.PrivateConversationData.SetValue<string>("tipoServicio", "Servicio");
                        context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                        context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                        return;
                    }
                    else
                    {
                        reply.Attachments = RespuestasOneNote.GetUsarVariasCuentasMicrosoftOneNote();
                        await context.PostAsync($"Lo siento no tengo una respuesta con el servicio:'{servicio2}'");
                        await context.PostAsync(opcionSecundarioDeRespuesta1);
                        await context.PostAsync(reply);
                        context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                        return;
                    }
                }
                else if (palabra1 == "diferentes" || palabra1 == "diferente")
                {
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");

                        if (palabra2 == "versiones" || palabra2 == "version")
                        {
                            reply.Attachments = RespuestasOneNote.GetUtilizaDiferentesVersionesOneNote();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = RespuestasOneNote.GetUtilizaDiferentesVersionesOneNote();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = RespuestasOneNote.GetUtilizaDiferentesVersionesOneNote();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    return;
                }
                else if (palabra1 == "graficos" || palabra1 == "grafico" || palabra1 == "gráficos" || palabra1 == "gráfico")
                {
                    reply.Attachments = RespuestasOutlook.GetAgregarGraficosMensajesOutlook();
                    await context.PostAsync(confirmacionRespuesta1);
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                    return;
                }
                else if (palabra1 == "tabulación" || palabra1 == "tabulacion" || palabra1 == "tabulaciones")
                {
                    reply.Attachments = RespuestasWord.GetEstablecerDesactivarQuitarTabulaciones();
                    await context.PostAsync(confirmacionRespuesta1);
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                    return;
                }
                else if (palabra1 == "opción" || palabra1 == "opcion" || palabra1 == "opciones")
                {
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");

                        if (palabra2 == "diseño" || palabra2 == "diseños")
                        {
                            reply.Attachments = RespuestasWord.GetUsarOpcionesDiseñoWord();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = RespuestasWord.GetUsarOpcionesDiseñoWord();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                        }
                    }
                    reply.Attachments = RespuestasWord.GetUsarOpcionesDiseñoWord();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                    return;
                }
                else if (palabra1 == "plantillas" || palabra1 == "plantilla")
                {
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");

                        if (palabra2 == "currículo" || palabra2 == "curriculo" || palabra2 == "curriculum")
                        {
                            reply.Attachments = RespuestasWord.GetUsarOpcionesDiseñoWord();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = RespuestasWord.GetUsarOpcionesDiseñoWord();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                        }
                    }
                    foreach (var serv in result.Entities.Where(Entity => Entity.Type == "Servicio"))
                    {
                        var servicio1 = serv.Entity.ToLower().Replace(" ", "");

                        if (servicio1 == "word" || servicio1 == "excel" || servicio1 == "powerpoint")
                        {
                            reply.Attachments = Respuestas.GetUsarPlantilla();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = Respuestas.GetUsarPlantilla();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{servicio1}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta2);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                    }
                    // No se detectó el 'servicio' de la pregunta
                    // Se obtiene el servicio que esta guardado en cache
                    var servicioC = "Servicio";
                    context.PrivateConversationData.TryGetValue<string>("tipoServicio", out servicioC);
                    if (servicioC == "Word" || servicioC == "PowerPoint" || servicioC == "Excel")
                    {
                        reply.Attachments = Respuestas.GetUsarPlantilla();
                        await context.PostAsync(confirmacionRespuesta1);
                        await context.PostAsync(reply);
                        context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                        return;
                    }
                    else
                    {
                        reply.Attachments = Respuestas.GetUsarPlantilla();
                        await context.PostAsync(preguntaNoRegistrada1);
                        await context.PostAsync(opcionSecundarioDeRespuesta1);
                        await context.PostAsync(reply);
                        context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                        return;
                    }
                }
                else if (palabra1 == "combinación" || palabra1 == "combinacion" || palabra1 == "combinaciones")
                {
                    reply.Attachments = RespuestasWord.GetUsarCombinacionCorrespondenciaCrearEnviarCorreo();
                    await context.PostAsync(confirmacionRespuesta1);
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                    return;
                }
                else if (palabra1 == "estilos" || palabra1 == "estilo")
                {
                    foreach (var serv in result.Entities.Where(Entity => Entity.Type == "Servicio"))
                    {
                        var servicioI = serv.Entity.ToLower().Replace(" ", "");

                        if (servicioI == "word")
                        {
                            reply.Attachments = RespuestasWord.GetAplicarEstiloTextoWord();
                            await context.PostAsync(confirmacionRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = RespuestasWord.GetAplicarEstilosObjetos();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{serv}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                    }
                    reply.Attachments = RespuestasWord.GetAplicarEstilosObjetos();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
                    await context.PostAsync(preguntaConsulta);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                    return;
                }
                else
                {
                    await context.PostAsync(preguntaNoRegistrada2);
                    await context.PostAsync($"O tal vez no escribió correctamente la palabra '{palabra1}'?");
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta2);
                    return;
                }
            }
            // Si el usuario no ingreso la primera parte de la pregunta
            // Se detectó el Servicio de la pregunta
            foreach (var serv in result.Entities.Where(Entity => Entity.Type == "Servicio"))
            {
                var servicioU = serv.Entity.ToLower().Replace(" ", "");
                if (servicioU == "onedrive")
                {
                    foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                    {
                        var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");
                        if (palabra2 == "windowsphone")
                        {
                            reply.Attachments = RespuestasOneDrive.GetUsarOneDriveEmpresaOneDriveWindowsPhone();
                            await context.PostAsync(preguntaNoRegistrada1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else if (palabra2 == "android")
                        {
                            reply.Attachments = RespuestasOneDrive.GetUsarOneDriveAndroid();
                            await context.PostAsync(preguntaNoRegistrada1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else if (palabra2 == "ios")
                        {
                            reply.Attachments = RespuestasOneDrive.GetUsarOneDriveEmpresaOneDriveIos();
                            await context.PostAsync(preguntaNoRegistrada1);
                            await context.PostAsync(reply);
                            await context.PostAsync(preguntaConsulta);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                            return;
                        }
                        else
                        {
                            reply.Attachments = RespuestasOneDrive.GetUsarOneDrive();
                            await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                            await context.PostAsync(opcionSecundarioDeRespuesta1);
                            await context.PostAsync(reply);
                            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                            return;
                        }
                    }
                    // No se detectó la segunda parte de la pregunta
                    reply.Attachments = RespuestasOneDrive.GetUsarOneDrive();
                    await context.PostAsync(preguntaNoRegistrada1);
                    await context.PostAsync(opcionSecundarioDeRespuesta1);
                    await context.PostAsync(reply);
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    return;
                }
                else
                {
                    await context.PostAsync($"Lo siento, su pregunta no esta registrada");
                    await context.PostAsync($"O tal vez no la escribió correctamente, ¿{servicioU}?");
                    context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                    return;
                }
            }
            //obtener el producto si este a sido escodigo anteriormente
            var servicio = "Servicio";
            context.PrivateConversationData.TryGetValue<string>("tipoDeServicio", out servicio);
            if (servicio == "OneDrive")
            {
                foreach (var entityP2 in result.Entities.Where(Entity => Entity.Type == "Pregunta::Palabra2"))
                {
                    var palabra2 = entityP2.Entity.ToLower().Replace(" ", "");
                    if (palabra2 == "windowsphone")
                    {
                        reply.Attachments = RespuestasOneDrive.GetUsarOneDriveEmpresaOneDriveWindowsPhone();
                        await context.PostAsync(preguntaNoRegistrada1);
                        await context.PostAsync(reply);
                        await context.PostAsync(preguntaConsulta);
                        context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                        context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                        return;
                    }
                    else if (palabra2 == "android")
                    {
                        reply.Attachments = RespuestasOneDrive.GetUsarOneDriveAndroid();
                        await context.PostAsync(preguntaNoRegistrada1);
                        await context.PostAsync(reply);
                        await context.PostAsync(preguntaConsulta);
                        context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                        context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                        return;
                    }
                    else if (palabra2 == "ios")
                    {
                        reply.Attachments = RespuestasOneDrive.GetUsarOneDriveEmpresaOneDriveIos();
                        await context.PostAsync(preguntaNoRegistrada1);
                        await context.PostAsync(reply);
                        await context.PostAsync(preguntaConsulta);
                        context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                        context.PrivateConversationData.SetValue<string>("EstadoRespuesta", estadoRespuesta);
                        return;
                    }
                    else
                    {
                        reply.Attachments = RespuestasOneDrive.GetUsarOneDrive();
                        await context.PostAsync($"Lo siento, su pregunta no esta registrada, tal vez no escribió correctamente la palabra '{palabra2}'?");
                        await context.PostAsync(opcionSecundarioDeRespuesta1);
                        await context.PostAsync(reply);
                        context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                        return;
                    }
                }
                // No se detectó la segunda parte de la pregunta
                reply.Attachments = RespuestasOneDrive.GetUsarOneDrive();
                await context.PostAsync(preguntaNoRegistrada1);
                await context.PostAsync(opcionSecundarioDeRespuesta1);
                await context.PostAsync(reply);
                context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta);
                return;
            }
            else
            {
                reply.Attachments = Respuestas.GetConsultaV2();
                await context.PostAsync(preguntaNoRegistrada2);
                await context.PostAsync(reply);
                await context.PostAsync("O tal vez no escribió la pregunta correctamente");
                context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta2);
                return;
            }
        }
    }
}