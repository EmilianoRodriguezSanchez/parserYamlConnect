using System;
using Xunit;
using YamlParserConnect.Parser;

namespace Parser.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            string _filePath = @"D:\Proyectos\SegurCaixa\APIs\SiniestrosHogar\SiniestrosHogar.Api\APIS-HOME\HOME-CLAIM-PRODUCT\LIVE\home_claim_1.0.0.yaml";
            var yaml = new YamlParser(_filePath);
            YamlAPIConnectParser.Entity.GettingStarted gettingStarted = yaml.Load(_filePath);
           
            var _properties= gettingStarted.Definitions.GetDynamicMemberNames();
            Assert.Equal(1, 1);

        }
    }
}
