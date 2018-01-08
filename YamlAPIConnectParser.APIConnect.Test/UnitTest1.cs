using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace YamlAPIConnectParser.APIConnect.Test
{
    [TestClass]
    public class ObjectHelper_UnitTest
    {
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void DictionaryToObject_CreateProperty()
        {
            var dic = new Dictionary<object, object>();

            var obj_old = YamlAPIConnectParser.APIConnect.Reflection.PropertyHelper<Entity.Definitions>.CreateProperty("PropA", typeof(System.String), "valor");
            dic.Add(new Entity.Definitions(), obj_old);
            var obj_new = YamlAPIConnectParser.APIConnect.Parser.ObjectHelper.DictionaryToObject<Entity.Definitions>(dic);

            //Assert
            Assert.IsTrue(true);
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Object_CreateProperty()
        {
            var dic = new Dictionary<object, object>();

            var obj_old = YamlAPIConnectParser.APIConnect.Reflection.TypeBuilder<Entity.Definitions>.CreateNewObject();
            var obj_new = new Entity.Definitions();
            //Assert
             Assert.IsFalse(object.ReferenceEquals ( obj_old , obj_new));
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Object_LoadYaml()
        {
            string _filePath = @"f:\segurcaisaadeslas\SiniestrosHogar\SiniestrosHogar.Api\APIS-HOME\HOME-CLAIM-PRODUCT\ECHO\home_claim_1.0.0.yaml";
            var yaml = new YamlAPIConnectParser.APIConnect.Parser.YamlParser(_filePath);
           Entity.GettingStarted gettingStarted = yaml.Load(_filePath);

           var _properties= gettingStarted.Definitions.GetDynamicMemberNames();

            dynamic definitions = gettingStarted.Definitions;
            var consequentialtrade = definitions["consequentialtrade"];
            var properties = definitions.consequentialtrade["properties"];
            var consequentialTradeId = definitions.consequentialtrade.properties["consequentialTradeId"];
            
            var type = definitions.consequentialtrade.properties.consequentialTradeId["type"];
            //Assert
            // Assert.IsTrue(obj_old != null);
        }

    }
}
