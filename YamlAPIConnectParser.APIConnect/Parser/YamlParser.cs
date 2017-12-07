/*
 * Created by SharpDevelop.
 * User: jmmartinez
 * Date: 23/11/2017
 * Time: 21:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using YamlDotNet.RepresentationModel;
using YamlDotNet.Serialization;

namespace YamlAPIConnectParser.APIConnect.Parser
{

     public class ContextYaml : IDYamlNode<Dictionary<object,object>>
    {
        
        private Dictionary<object, object> MappingNode { get; set; }

        public Entity.GettingStarted Data { get; set; }

        public ContextYaml(Dictionary<object, object> mappingNode) {
            MappingNode = mappingNode;
            string jsonString = JsonConvert.SerializeObject(mappingNode);
            //validar los campos de los objetos y crearlos si no estan


           Data = GettingStarted.FromJson(jsonString);
        }

        public Dictionary<object, object> FindMappingNode(string objId)
        {

            if (MappingNode == null || MappingNode.Count <= 0 || !MappingNode.ContainsKey(objId)) return null;

            return (Dictionary<object, object>)MappingNode[objId];
        }

       

        public void Load(Dictionary<object, object> mappingNode)
        {
            MappingNode = mappingNode;
        }
    }


    public partial class GettingStarted
    {
        public static Entity.GettingStarted FromJson(string json) => JsonConvert.DeserializeObject<Entity.GettingStarted>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this GettingStarted self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    public class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
        };
    }
    /// <summary>
    /// Description of YamlParser.
    /// </summary>
    public class YamlParser
	{
		private string _filePath;
		
		public YamlParser(string filePath)
		{
			_filePath = filePath;
		}
		
       
		private string ParseType(YamlMappingNode mappingNode)
		{
			if(mappingNode.Children.ContainsKey("type"))
			{
				var type = mappingNode["type"].ToString();
				if(type == "array")
				{
					var items = (YamlMappingNode)mappingNode["items"];
					var itemsType = items.Children["$ref"].ToString();
					return string.Format(@"array[[{0}]]", itemsType);
				}
				return type;
			}
			else if(mappingNode.Children.ContainsKey("$ref"))
			{
				return mappingNode["$ref"].ToString();
			}
			
			return string.Empty;
		}
		
		//private void LoadDefinitionProperties(YamlMappingNode mappingNode, ApiDefinition apiDefinition)
		//{
		//	if(mappingNode.Children.ContainsKey("properties"))
		//	{
		//		var propertiesMapping = (YamlMappingNode)mappingNode.Children["properties"];
		//		foreach (var prop in propertiesMapping)
		//		{
		//			var propMapping = (YamlMappingNode)prop.Value;
		//			var apiProperty = new ApiProperty();
					
		//			apiProperty.Name = prop.Key.ToString();
		//			apiProperty.Type = ParseType(propMapping);
		//			apiProperty.Description = propMapping.Children.ContainsKey("description") ? propMapping["description"].ToString() : string.Empty;
					
		//			apiDefinition.Properties.Add(apiProperty.Name, apiProperty);
		//		}
		//	}
		//}
		
		//private void LoadDefinitions(YamlMappingNode mappingNode, Api api)
		//{
		//	var defs = (YamlMappingNode)mappingNode.Children["definitions"];
  //      	foreach (var definition in defs)
  //  		{
		//		var definitionMapping = (YamlMappingNode)definition.Value;
		//		var apiDefinition = new ApiDefinition();
		//		apiDefinition.Name = definition.Key.ToString();
		//		apiDefinition.Description = definitionMapping.Children.ContainsKey("description") ? definitionMapping["description"].ToString() : string.Empty;
		//		if(definitionMapping.Children.ContainsKey("type"))
		//		{
		//			apiDefinition.Type = ParseType(definitionMapping);
		//		}
				
		//		LoadDefinitionProperties(definitionMapping, apiDefinition);
		//		api.Definitions.Add(apiDefinition.Name, apiDefinition);
  //  		}
		//}
		
		public Entity.GettingStarted Load(string filePath)
		{
			using(StreamReader stream = new StreamReader(filePath))
			{
				var yaml = new YamlStream();
        		//yaml.Load(stream);
        		var deserializer = new DeserializerBuilder().Build();
                string value = stream.ReadToEnd().ToString();

                var yamlObject = deserializer.Deserialize(new StringReader(value) );
                //(YamlMappingNode)yaml.Documents[0].RootNode
                var entityYaml = new ContextYaml((Dictionary < object, object > )yamlObject);
                
                //var api = new Api();


        		//LoadDefinitions(entityYaml.Data, api);
        		
        		return entityYaml.Data ;
			}
		}
	}
}
