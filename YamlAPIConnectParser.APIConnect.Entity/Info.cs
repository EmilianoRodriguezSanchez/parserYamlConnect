using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YamlAPIConnectParser.APIConnect.Entity
{
    // To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
    //
    //    using ParserToYamlJsonContext;
    //
    //    var data = GettingStarted.FromJson(jsonString);
    //

    using System;
    using System.Net;

    using Newtonsoft.Json;

    public partial class Info: DynamicDictionary
        {
            [JsonProperty("contact")]
            public Contact Contact { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("title")]
            public string Title { get; set; }

            [JsonProperty("version")]
            public string Version { get; set; }

            [JsonProperty("x-ibm-name")]
            public string XIbmName { get; set; }
        }


        #region Properties
    /*    public partial class PostOutput
        {
            [JsonProperty("additionalProperties")]
            public string AdditionalProperties { get; set; }

            [JsonProperty("properties")]
            public Properties14 Properties { get; set; }
        }

        public partial class Properties14
        {
            [JsonProperty("listaErrores")]
            public ListaSenyales ListaErrores { get; set; }

            [JsonProperty("numeroPoliza")]
            public TipoFraccionamiento NumeroPoliza { get; set; }
        }

        public partial class PostInput
        {
            [JsonProperty("additionalProperties")]
            public string AdditionalProperties { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("properties")]
            public Properties4 Properties { get; set; }
        }

        public partial class Properties4
        {
            [JsonProperty("beanPoliza")]
            public BeanCodComercial BeanPoliza { get; set; }

            [JsonProperty("codigoComercial")]
            public TipoFraccionamiento CodigoComercial { get; set; }

            [JsonProperty("codigoOficinaConsulta")]
            public TipoFraccionamiento CodigoOficinaConsulta { get; set; }

            [JsonProperty("codigoProducto")]
            public TipoFraccionamiento CodigoProducto { get; set; }

            [JsonProperty("codigoSimulacion")]
            public TipoFraccionamiento CodigoSimulacion { get; set; }

            [JsonProperty("passwd")]
            public CCCIban Passwd { get; set; }

            [JsonProperty("usuario")]
            public CCCIban Usuario { get; set; }
        }

        public partial class GetOutput
        {
            [JsonProperty("additionalProperties")]
            public string AdditionalProperties { get; set; }

            [JsonProperty("properties")]
            public FriskyProperties Properties { get; set; }
        }

        public partial class FriskyProperties
        {
            [JsonProperty("beanSimulacion")]
            public BeanCodComercial BeanSimulacion { get; set; }

            [JsonProperty("listaErrores")]
            public ListaSenyales ListaErrores { get; set; }
        }

        public partial class GetInput
        {
            [JsonProperty("additionalProperties")]
            public string AdditionalProperties { get; set; }

            [JsonProperty("properties")]
            public BraggadociousProperties Properties { get; set; }
        }

        public partial class BraggadociousProperties
        {
            [JsonProperty("codigoComercial")]
            public TipoFraccionamiento CodigoComercial { get; set; }

            [JsonProperty("codigoOficinaConsulta")]
            public TipoFraccionamiento CodigoOficinaConsulta { get; set; }

            [JsonProperty("codigoProducto")]
            public TipoFraccionamiento CodigoProducto { get; set; }

            [JsonProperty("codigoSimulacion")]
            public TipoFraccionamiento CodigoSimulacion { get; set; }

            [JsonProperty("passwd")]
            public TipoFraccionamiento Passwd { get; set; }

            [JsonProperty("usuario")]
            public TipoFraccionamiento Usuario { get; set; }
        }

        public partial class Error
        {
            [JsonProperty("additionalProperties")]
            public string AdditionalProperties { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("properties")]
            public Properties7 Properties { get; set; }
        }

        public partial class Properties7
        {
            [JsonProperty("httpCode")]
            public HttpCode HttpCode { get; set; }

            [JsonProperty("httpMessage")]
            public HttpCode HttpMessage { get; set; }

            [JsonProperty("moreInformation")]
            public HttpCode MoreInformation { get; set; }
        }

        public partial class HttpCode
        {
            [JsonProperty("example")]
            public string Example { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }
        }

        public partial class DeleteInput
        {
            [JsonProperty("additionalProperties")]
            public string AdditionalProperties { get; set; }

            [JsonProperty("properties")]
            public TentacledProperties Properties { get; set; }
        }

        public partial class TentacledProperties
        {
            [JsonProperty("codigoComercial")]
            public TipoFraccionamiento CodigoComercial { get; set; }

            [JsonProperty("codigoOficinaConsulta")]
            public TipoFraccionamiento CodigoOficinaConsulta { get; set; }

            [JsonProperty("codigoProducto")]
            public CCCIban CodigoProducto { get; set; }

            [JsonProperty("numeroPoliza")]
            public TipoFraccionamiento NumeroPoliza { get; set; }

            [JsonProperty("passwd")]
            public CCCIban Passwd { get; set; }

            [JsonProperty("usuario")]
            public CCCIban Usuario { get; set; }
        }

        public partial class BeanSublimite
        {
            [JsonProperty("additionalProperties")]
            public string AdditionalProperties { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("properties")]
            public HilariousProperties Properties { get; set; }
        }

        public partial class HilariousProperties
        {
            [JsonProperty("listaFranquiciasSublimite")]
            public Lista ListaFranquiciasSublimite { get; set; }

            [JsonProperty("tipoSublimite")]
            public CCCIban TipoSublimite { get; set; }

            [JsonProperty("valorSublimite")]
            public TipoFraccionamiento ValorSublimite { get; set; }
        }

        public partial class BeanSimulacion
        {
            [JsonProperty("additionalProperties")]
            public string AdditionalProperties { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("properties")]
            public Properties5 Properties { get; set; }
        }

        public partial class Properties5
        {
            [JsonProperty("accionSuscripcionDelegada")]
            public TipoFraccionamiento AccionSuscripcionDelegada { get; set; }

            [JsonProperty("BeanCodComercial")]
            public BeanCodComercial BeanCodComercial { get; set; }

            [JsonProperty("ClausulasManuales")]
            public BeanCodComercial ClausulasManuales { get; set; }

            [JsonProperty("codigoProducto")]
            public CCCIban CodigoProducto { get; set; }

            [JsonProperty("codigoSimulacion")]
            public TipoFraccionamiento CodigoSimulacion { get; set; }

            [JsonProperty("DatosRiesgo")]
            public BeanCodComercial DatosRiesgo { get; set; }

            [JsonProperty("estadoSimulacion")]
            public TipoFraccionamiento EstadoSimulacion { get; set; }

            [JsonProperty("fechaCreacionSimulacion")]
            public TipoFraccionamiento FechaCreacionSimulacion { get; set; }

            [JsonProperty("fechaFinVigencia")]
            public TipoFraccionamiento FechaFinVigencia { get; set; }

            [JsonProperty("fechaInicioVigencia")]
            public TipoFraccionamiento FechaInicioVigencia { get; set; }

            [JsonProperty("listaCapitalesAsegurados")]
            public ListaSenyales ListaCapitalesAsegurados { get; set; }

            [JsonProperty("listaClauAutomaticas")]
            public Lista ListaClauAutomaticas { get; set; }

            [JsonProperty("listaCoberturas")]
            public Lista ListaCoberturas { get; set; }

            [JsonProperty("listaDescuentos")]
            public ListaSenyales ListaDescuentos { get; set; }

            [JsonProperty("listaFranquicias")]
            public ListaSenyales ListaFranquicias { get; set; }

            [JsonProperty("listaPersonas")]
            public ListaSenyales ListaPersonas { get; set; }

            [JsonProperty("listaPrecioSeguro")]
            public ListaSenyales ListaPrecioSeguro { get; set; }

            [JsonProperty("ListaSenyales")]
            public ListaSenyales ListaSenyales { get; set; }

            [JsonProperty("oficina")]
            public TipoFraccionamiento Oficina { get; set; }

            [JsonProperty("polizaRenovable")]
            public TipoFraccionamiento PolizaRenovable { get; set; }

            [JsonProperty("sumaAsegurada")]
            public TipoFraccionamiento SumaAsegurada { get; set; }

            [JsonProperty("usuario")]
            public CCCIban Usuario { get; set; }
        }

        public partial class BeanSenyal
        {
            [JsonProperty("additionalProperties")]
            public string AdditionalProperties { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("properties")]
            public CunningProperties Properties { get; set; }
        }

        public partial class CunningProperties
        {
            [JsonProperty("estado")]
            public CCCIban Estado { get; set; }

            [JsonProperty("idSenyal")]
            public CCCIban IdSenyal { get; set; }
        }

        public partial class BeanPrecioSeguro
        {
            [JsonProperty("additionalProperties")]
            public string AdditionalProperties { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("properties")]
            public Properties1 Properties { get; set; }
        }

        public partial class Properties1
        {
            [JsonProperty("importeAnual")]
            public TipoFraccionamiento ImporteAnual { get; set; }

            [JsonProperty("importeMensual")]
            public TipoFraccionamiento ImporteMensual { get; set; }

            [JsonProperty("importeMensualSucesivo")]
            public TipoFraccionamiento ImporteMensualSucesivo { get; set; }

            [JsonProperty("importeSemestral")]
            public TipoFraccionamiento ImporteSemestral { get; set; }

            [JsonProperty("importeSemestralSucesivo")]
            public TipoFraccionamiento ImporteSemestralSucesivo { get; set; }

            [JsonProperty("importeTrimestral")]
            public TipoFraccionamiento ImporteTrimestral { get; set; }

            [JsonProperty("importeTrimestralSucesivo")]
            public TipoFraccionamiento ImporteTrimestralSucesivo { get; set; }

            [JsonProperty("tipoFranquicia")]
            public TipoFraccionamiento TipoFranquicia { get; set; }

            [JsonProperty("valorFranquicia")]
            public TipoFraccionamiento ValorFranquicia { get; set; }
        }

        public partial class BeanPoliza
        {
            [JsonProperty("additionalProperties")]
            public string AdditionalProperties { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("properties")]
            public Properties2 Properties { get; set; }
        }

        public partial class Properties2
        {
            [JsonProperty("datosSeguro")]
            public BeanCodComercial DatosSeguro { get; set; }

            [JsonProperty("fechaFinVigencia")]
            public TipoFraccionamiento FechaFinVigencia { get; set; }

            [JsonProperty("fechaInicioVigencia")]
            public TipoFraccionamiento FechaInicioVigencia { get; set; }

            [JsonProperty("idProducto")]
            public CCCIban IdProducto { get; set; }

            [JsonProperty("listaDatosAseguramiento")]
            public ListaSenyales ListaDatosAseguramiento { get; set; }

            [JsonProperty("listaPersonas")]
            public ListaSenyales ListaPersonas { get; set; }

            [JsonProperty("numeroContrato")]
            public TipoFraccionamiento NumeroContrato { get; set; }

            [JsonProperty("numeroPoliza")]
            public TipoFraccionamiento NumeroPoliza { get; set; }

            [JsonProperty("oficinaGestora")]
            public TipoFraccionamiento OficinaGestora { get; set; }

            [JsonProperty("usuario")]
            public CCCIban Usuario { get; set; }
        }

        public partial class ListaSenyales
        {
            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("items")]
            public BeanCodComercial Items { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }
        }

        public partial class BeanPersona
        {
            [JsonProperty("additionalProperties")]
            public string AdditionalProperties { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("properties")]
            public StickyProperties Properties { get; set; }
        }

        public partial class StickyProperties
        {
            [JsonProperty("codPais")]
            public CCCIban CodPais { get; set; }

            [JsonProperty("codPostal")]
            public CCCIban CodPostal { get; set; }

            [JsonProperty("direccion")]
            public CCCIban Direccion { get; set; }

            [JsonProperty("emailContacto")]
            public CCCIban EmailContacto { get; set; }

            [JsonProperty("esResidente")]
            public TipoFraccionamiento EsResidente { get; set; }

            [JsonProperty("fechaNacimiento")]
            public TipoFraccionamiento FechaNacimiento { get; set; }

            [JsonProperty("idioma")]
            public TipoFraccionamiento Idioma { get; set; }

            [JsonProperty("nomProvincia")]
            public CCCIban NomProvincia { get; set; }

            [JsonProperty("Nombre")]
            public CCCIban Nombre { get; set; }

            [JsonProperty("numDoc")]
            public CCCIban NumDoc { get; set; }

            [JsonProperty("numPer")]
            public TipoFraccionamiento NumPer { get; set; }

            [JsonProperty("personasACargo")]
            public CCCIban PersonasACargo { get; set; }

            [JsonProperty("poblacion")]
            public CCCIban Poblacion { get; set; }

            [JsonProperty("primerApellido")]
            public CCCIban PrimerApellido { get; set; }

            [JsonProperty("rolTomador")]
            public TipoFraccionamiento RolTomador { get; set; }

            [JsonProperty("segundoApellido")]
            public CCCIban SegundoApellido { get; set; }

            [JsonProperty("Sexo")]
            public CCCIban Sexo { get; set; }

            [JsonProperty("telefono")]
            public TipoFraccionamiento Telefono { get; set; }

            [JsonProperty("telefonoMovil")]
            public TipoFraccionamiento TelefonoMovil { get; set; }

            [JsonProperty("tipoDoc")]
            public TipoFraccionamiento TipoDoc { get; set; }

            [JsonProperty("tipoFigura")]
            public TipoFraccionamiento TipoFigura { get; set; }

            [JsonProperty("tipoPersona")]
            public TipoFraccionamiento TipoPersona { get; set; }
        }

        public partial class FluffyBeanFranquicia
        {
            [JsonProperty("additionalProperties")]
            public string AdditionalProperties { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("properties")]
            public Properties3 Properties { get; set; }
        }

        public partial class Properties3
        {
            [JsonProperty("tipoFranquicia")]
            public CCCIban TipoFranquicia { get; set; }

            [JsonProperty("valor")]
            public TipoFraccionamiento Valor { get; set; }
        }

        public partial class PurpleBeanFranquicia
        {
            [JsonProperty("additionalProperties")]
            public string AdditionalProperties { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("properties")]
            public FluffyProperties Properties { get; set; }
        }

        public partial class FluffyProperties
        {
            [JsonProperty("tipoFranquicia")]
            public TipoFraccionamiento TipoFranquicia { get; set; }

            [JsonProperty("Valor")]
            public TipoFraccionamiento Valor { get; set; }
        }

        public partial class BeanFormaAseguramiento
        {
            [JsonProperty("additionalProperties")]
            public string AdditionalProperties { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("properties")]
            public Properties9 Properties { get; set; }
        }

        public partial class Properties9
        {
            [JsonProperty("tipoFormaAseguramiento")]
            public TipoFraccionamiento TipoFormaAseguramiento { get; set; }

            [JsonProperty("valorFormaAseguramiento")]
            public TipoFraccionamiento ValorFormaAseguramiento { get; set; }
        }

        public partial class BeanError
        {
            [JsonProperty("properties")]
            public MagentaProperties Properties { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }
        }

        public partial class MagentaProperties
        {
            [JsonProperty("campoError")]
            public CCCIban CampoError { get; set; }

            [JsonProperty("idError")]
            public CCCIban IdError { get; set; }

            [JsonProperty("valorError")]
            public CCCIban ValorError { get; set; }
        }

        public partial class BeanDetalleRiesgo
        {
            [JsonProperty("additionalProperties")]
            public string AdditionalProperties { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("properties")]
            public MischievousProperties Properties { get; set; }
        }

        public partial class MischievousProperties
        {
            [JsonProperty("campoDetRiesgo")]
            public TipoFraccionamiento CampoDetRiesgo { get; set; }

            [JsonProperty("valorDetRiesgo")]
            public TipoFraccionamiento ValorDetRiesgo { get; set; }
        }

        public partial class BeanDescuento
        {
            [JsonProperty("additionalProperties")]
            public string AdditionalProperties { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("properties")]
            public AmbitiousProperties Properties { get; set; }
        }

        public partial class AmbitiousProperties
        {
            [JsonProperty("margenOficina")]
            public TipoFraccionamiento MargenOficina { get; set; }

            [JsonProperty("margenOficinaSucesivos")]
            public TipoFraccionamiento MargenOficinaSucesivos { get; set; }

            [JsonProperty("tipoDescuento")]
            public TipoFraccionamiento TipoDescuento { get; set; }

            [JsonProperty("valorDesc")]
            public TipoFraccionamiento ValorDesc { get; set; }

            [JsonProperty("valorMaxDesc")]
            public TipoFraccionamiento ValorMaxDesc { get; set; }

            [JsonProperty("valorMaxPrimerDesc")]
            public TipoFraccionamiento ValorMaxPrimerDesc { get; set; }

            [JsonProperty("valorPrimerDesc")]
            public TipoFraccionamiento ValorPrimerDesc { get; set; }
        }

        public partial class BeanDatosSeguro
        {
            [JsonProperty("additionalProperties")]
            public string AdditionalProperties { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("properties")]
            public Properties6 Properties { get; set; }
        }

        public partial class Properties6
        {
            [JsonProperty("CCCIban")]
            public CCCIban CCCIban { get; set; }

            [JsonProperty("cuentaCCC")]
            public TipoFraccionamiento CuentaCCC { get; set; }

            [JsonProperty("digitosCCC")]
            public TipoFraccionamiento DigitosCCC { get; set; }

            [JsonProperty("entidadCCC")]
            public TipoFraccionamiento EntidadCCC { get; set; }

            [JsonProperty("formaPago")]
            public TipoFraccionamiento FormaPago { get; set; }

            [JsonProperty("idPrecio")]
            public TipoFraccionamiento IdPrecio { get; set; }

            [JsonProperty("oficinaCCC")]
            public TipoFraccionamiento OficinaCCC { get; set; }

            [JsonProperty("TipoFraccionamiento")]
            public TipoFraccionamiento TipoFraccionamiento { get; set; }
        }

        public partial class BeanDatosRiesgos
        {
            [JsonProperty("additionalProperties")]
            public string AdditionalProperties { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("properties")]
            public IndecentProperties Properties { get; set; }
        }

        public partial class IndecentProperties
        {
            [JsonProperty("listaDetalleRiesgo")]
            public Lista ListaDetalleRiesgo { get; set; }
        }

        public partial class BeanDatosAseguramiento
        {
            [JsonProperty("additionalProperties")]
            public string AdditionalProperties { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("properties")]
            public Properties8 Properties { get; set; }
        }

        public partial class Properties8
        {
            [JsonProperty("campoDetAseguramiento")]
            public CCCIban CampoDetAseguramiento { get; set; }

            [JsonProperty("valorDetAseguramiento")]
            public CCCIban ValorDetAseguramiento { get; set; }
        }

        public partial class BeanCodComercial2
        {
            [JsonProperty("additionalProperties")]
            public string AdditionalProperties { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("properties")]
            public IndigoProperties Properties { get; set; }
        }

        public partial class IndigoProperties
        {
            [JsonProperty("codComercial")]
            public TipoFraccionamiento CodComercial { get; set; }

            [JsonProperty("digitosCodComercial")]
            public TipoFraccionamiento DigitosCodComercial { get; set; }
        }

        public partial class BeanCobertura
        {
            [JsonProperty("additionalProperties")]
            public string AdditionalProperties { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("properties")]
            public Properties12 Properties { get; set; }
        }

        public partial class Properties12
        {
            [JsonProperty("capitalAsegurado")]
            public TipoFraccionamiento CapitalAsegurado { get; set; }

            [JsonProperty("fechaFinCobertura")]
            public TipoFraccionamiento FechaFinCobertura { get; set; }

            [JsonProperty("fechaInicioCobertura")]
            public TipoFraccionamiento FechaInicioCobertura { get; set; }

            [JsonProperty("formaAseguramiento")]
            public BeanCodComercial FormaAseguramiento { get; set; }

            [JsonProperty("idCobertura")]
            public CCCIban IdCobertura { get; set; }

            [JsonProperty("listaFranquiciasCoberturas")]
            public Lista ListaFranquiciasCoberturas { get; set; }

            [JsonProperty("listaSublimite")]
            public Lista ListaSublimite { get; set; }

            [JsonProperty("renovable")]
            public TipoFraccionamiento Renovable { get; set; }
        }

        public partial class Lista
        {
            [JsonProperty("items")]
            public BeanCodComercial Items { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }
        }

        public partial class BeanCodComercial
        {
            [JsonProperty("$ref")]
            public string Ref { get; set; }
        }

        public partial class TipoFraccionamiento
        {
            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("example")]
            public string Example { get; set; }

            [JsonProperty("format")]
            public string Format { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }
        }

        public partial class BeanClausulasManuales
        {
            [JsonProperty("additionalProperties")]
            public string AdditionalProperties { get; set; }

            [JsonProperty("properties")]
            public Properties10 Properties { get; set; }
        }

        public partial class Properties10
        {
            [JsonProperty("descClausulaManual")]
            public CCCIban DescClausulaManual { get; set; }
        }

        public partial class BeanClauAutomatica
        {
            [JsonProperty("additionalProperties")]
            public string AdditionalProperties { get; set; }

            [JsonProperty("properties")]
            public Properties11 Properties { get; set; }
        }

        public partial class Properties11
        {
            [JsonProperty("idClauAutomatica")]
            public CCCIban IdClauAutomatica { get; set; }
        }

        public partial class BeanCapitalAsegurado
        {
            [JsonProperty("additionalProperties")]
            public string AdditionalProperties { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("properties")]
            public Properties13 Properties { get; set; }
        }

        public partial class Properties13
        {
            [JsonProperty("idCapital")]
            public CCCIban IdCapital { get; set; }

            [JsonProperty("valorCapital")]
            public CCCIban ValorCapital { get; set; }
        }

        public partial class CCCIban
        {
            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }
        }*/
#endregion

       
    }
