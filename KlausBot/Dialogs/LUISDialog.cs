﻿using System;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using KlausBot.Models;
using KlausBot.Util;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;

namespace KlausBot.Dialogs
{
    //[LuisModel("cd076119-b212-4414-a71d-3874bb7a5ab6", "755c923dc1fe4acb91201cbd955e7a71")] KlausBot
    [LuisModel("26132056-47a4-4f3b-9c71-ee6e5fa0dad3", "2a755c441df445349b5d17f491219153")]

    [Serializable]
    public class LUISDialog : LuisDialog<ConsultaServicio>
    { 
        private readonly BuildFormDelegate<ConsultaServicio> consultaServicio;

        public LUISDialog(BuildFormDelegate<ConsultaServicio> servicioConsultado)
        {
            this.consultaServicio = servicioConsultado;
        }

        // No se reconoce la accion del usuario
        [LuisIntent("")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            var estadoPregunta2 = "False";

            Random rnd = new Random();
            // Dudas que puede generar el bot
            string[] none = {
                "Perdón, no entiendo lo que estas diciendo \U0001F615",
                "Perdón, no entendí lo que necesitas \U0001F615",
                "Perdón, no entendí lo que quieres decir \U0001F615",
            };

            // Generate random indexes for none
            int mIndex = rnd.Next(0, none.Length);

            var reply = context.MakeMessage();
            reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;
            reply.Attachments = Respuestas.GetConsulta();

            // Display the result.
            await context.PostAsync(none[mIndex]);
            await context.PostAsync(reply);
            context.Wait(MessageReceived);
            context.PrivateConversationData.SetValue<string>("EstadoPregunta", estadoPregunta2);
            return;
        }

        // El usuario tiene una accion de saludo
        [LuisIntent("Saludo")]
        public async Task Saludo(IDialogContext context, LuisResult result)
        {
            context.Call(new SaludoDialog(), Callback);
        }

        private async Task Callback(IDialogContext context, IAwaitable<object> result)
        {
            context.Wait(MessageReceived);
        }

        [LuisIntent("Consulta.ServicioGeneral")]
        public async Task ConsultaServicio(IDialogContext context, LuisResult result)
        {
            var formularioRegistro = new FormDialog<ConsultaServicio>(new ConsultaServicio(), this.consultaServicio, FormOptions.PromptInStart);
            context.Call<ConsultaServicio>(formularioRegistro, Callback);
        }

        [LuisIntent("Despedida")]
        public async Task Despedida(IDialogContext context, LuisResult result)
        {
            await new DespedidaDialog(context, result).StartAsync();
        }

        // -------------------------------------------------------------------------------------
        // Acciones que puede tomar el usuario

        [LuisIntent("Consulta.Abrir")]
        public async Task ConsultaAbrir(IDialogContext context, LuisResult result)
        {
            await new AbrirDialog(context, result).StartAsync();
        }

        // La accion del usuairo es agregar
        [LuisIntent("Consulta.Agregar")]
        public async Task ConsultaAgregar(IDialogContext context, LuisResult result)
        {
            await new AgregarDialog(context, result).StartAsync();

        }

        [LuisIntent("Consulta.Aplicar")]
        public async Task ConsultaAplicar(IDialogContext context, LuisResult result)
        {
            await new AplicarDialog(context, result).StartAsync();
        }

        [LuisIntent("Consulta.Buscar")]
        public async Task ConsultaBuscar(IDialogContext context, LuisResult result)
        {
            await new BuscarDialog(context, result).StartAsync();
        }

        // La accion del usuario es cambiar
        [LuisIntent("Consulta.Cambiar")]
        public async Task ConsultaCambiar(IDialogContext context, LuisResult result)
        {
            // ---------> Verificar esta pregunta color - fuente (Se necesitan 4 Entities)<----------
            await new CambiarDialog(context, result).StartAsync();
            // ---------> Verificar esta pregunta color - fuente (Se necesitan 4 Entities)<----------
        }

        [LuisIntent("Consulta.Cargar")]
        public async Task ConsultaCargar(IDialogContext context, LuisResult result)
        {
            await new CargarDialog(context, result).StartAsync();
        }

        [LuisIntent("Consulta.Compartir")]
        public async Task CompartiraEditar(IDialogContext context, LuisResult result)
        {
            await new CompartirDialog(context, result).StartAsync();
        }

        // La accion del usuario es de una consulta secundaria
        [LuisIntent("Consulta.Secundaria")]
        public async Task ConsultaSecundaria(IDialogContext context, LuisResult result)
        {
            // --------> Se tiene respuesta hasta EliminarDialog <----------
            await new ConsultaSecundariaDialog(context, result).StartAsync();
            // --------> Se tiene respuesta hasta EliminarDialog <----------
        }

        [LuisIntent("Consulta.Copiar")]
        public async Task ConsultaCopiar(IDialogContext context, LuisResult result)
        {
            await new CopiarDialog(context, result).StartAsync();
        }

        // La accion del usuario es crear 
        [LuisIntent("Consulta.Crear")]
        public async Task ConsultaCrear(IDialogContext context, LuisResult result)
        {
            await new CrearDialog(context, result).StartAsync();
        }

        [LuisIntent("Consulta.Definicion")]
        public async Task ConsultaDefinicion(IDialogContext context, LuisResult result)
        {
            await new DefinicionDialog(context, result).StartAsync();
        }

        [LuisIntent("Consulta.Desactivar")]
        public async Task ConsultaDesactivar(IDialogContext context, LuisResult result)
        {
            await new DesactivarDialog(context, result).StartAsync();
        }

        [LuisIntent("Consulta.Editar")]
        public async Task ConsultaEditar(IDialogContext context, LuisResult result)
        {
            await new EditarDialog(context, result).StartAsync();
        }

        [LuisIntent("Consulta.Eliminar")]
        public async Task ConsultaEliminar(IDialogContext context, LuisResult result)
        {
            await new EliminarDialog(context, result).StartAsync();
        }

        [LuisIntent("Consulta.Encontrar")]
        public async Task ConsultaEncontrar(IDialogContext context, LuisResult result)
        {
            await new EncontrarDialog(context, result).StartAsync();
        }

        [LuisIntent("Consulta.Enviar")]
        public async Task ConsultaEnviar(IDialogContext context, LuisResult result)
        {
            await new EnviarDialog(context, result).StartAsync();
        }

        [LuisIntent("Consulta.Establecer")]
        public async Task ConsultaEstablecer(IDialogContext context, LuisResult result)
        {
            await new EstablecerDialog(context, result).StartAsync();
        }

        [LuisIntent("Consulta.Exportar")]
        public async Task ConsultaExportar(IDialogContext context, LuisResult result)
        {
            await new ExportarDialog(context, result).StartAsync();
        }

        [LuisIntent("Consulta.Guardar")]
        public async Task ConsultaGuardar(IDialogContext context, LuisResult result)
        {
            await new GuardarDialog(context, result).StartAsync();
        }

        [LuisIntent("Consulta.Importar")]
        public async Task ConsultaImportar(IDialogContext context, LuisResult result)
        {
            await new ImportarDialog(context, result).StartAsync();
        }

        [LuisIntent("Consulta.Imprimir")]
        public async Task ConsultaImprimir(IDialogContext context, LuisResult result)
        {
            await new ImprimirDialog(context, result).StartAsync();
        }

        [LuisIntent("Consulta.Mover")]
        public async Task ConsultaMover(IDialogContext context, LuisResult result)
        {
            await new MoverDialog(context, result).StartAsync();
        }

        [LuisIntent("Consulta.Obtener")]
        public async Task ConsultaObtener(IDialogContext context, LuisResult result)
        {
            await new ObtenerDialog(context, result).StartAsync();
        }

        [LuisIntent("Consulta.Organizar")]
        public async Task ConsultaOrganizar(IDialogContext context, LuisResult result)
        {
            await new OrganizarDialog(context, result).StartAsync();
        }

        [LuisIntent("Consulta.Proteger")]
        public async Task ConsultaProteger(IDialogContext context, LuisResult result)
        {
            await new ProtegerDialog(context, result).StartAsync();
        }

        // La accion del usuairo es recuperar 
        [LuisIntent("Consulta.Recuperar")]
        public async Task ConsultaRecuperar(IDialogContext context, LuisResult result)
        {
            await new RecuperarDialog(context, result).StartAsync();
        }

        [LuisIntent("Consulta.Revisar")]
        public async Task ConsultaRevisar(IDialogContext context, LuisResult result)
        {
            await new RevisarDialog(context, result).StartAsync();
        }

        // La accion del usuairo es recuperar 
        [LuisIntent("Consulta.Sincronizar")]
        public async Task ConsultaSincronizar(IDialogContext context, LuisResult result)
        {
            await new SincronizarDialog(context, result).StartAsync();
        }

        [LuisIntent("Consulta.Solucionar")]
        public async Task ConsultaSolucionar(IDialogContext context, LuisResult result)
        {
            await new SolucionarDialog(context, result).StartAsync();
        }

        [LuisIntent("Consulta.Trabajar")]
        public async Task ConsultaTrabajar(IDialogContext context, LuisResult result)
        {
            await new TrabajarDialog(context, result).StartAsync();
        }

        // La accion del usuairo es usar
        [LuisIntent("Consulta.Usar")]
        public async Task ConsultaUsar(IDialogContext context, LuisResult result)
        {
            await new UsarDialog(context, result).StartAsync();
        }

        [LuisIntent("Consulta.Ver")]
        public async Task ConsultaVer(IDialogContext context, LuisResult result)
        {
            await new VerDialog(context, result).StartAsync();
        }

    }
}
