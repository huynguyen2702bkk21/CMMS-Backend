using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.ConstantDomain;

namespace WebAPICHATest.Domain.AggregateModels.ChartObjAggregate
{
    public class ChartObj : Entity, IAggregateRoot
    {
        //public string ChartObjId { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }

        public ChartObj(string name, decimal value) 
        {
            Name = name;
            Value = value;
        }

        public ChartObj(string name)
        {
            Name = name;
        }

        private ChartObj()
        {

        }

        public void Update(string name, decimal value)
        {
            Name = name;
            Value = value;
        }

        //public static ChartObj? baseFromJson(Dictionary<string, dynamic> json)
        //{
        //    ChartObj resultChartObj = new ChartObj();
        //    foreach (var kv in json)
        //    {
        //        if (kv.Key == "chartObjId")
        //        {
        //            resultChartObj.id = kv.Value;
        //        }
        //        if (kv.Key == "properties")
        //        {
        //            List<Dictionary<string, dynamic>> listProperties = new List<Dictionary<string, dynamic>>();
        //            JArray jsonItems = kv.Value;
        //            foreach (var item in jsonItems)
        //            {
        //                JObject jObject = (JObject)item;
        //                Dictionary<string, dynamic> tempDict = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(jObject.ToString());
        //                listProperties.Add(tempDict);
        //            }
        //            foreach (var properties in listProperties)
        //            {
        //                switch (properties["propertyId"])
        //                {
        //                    case "name":
        //                        resultChartObj.name = Constant.getValue(properties["valueString"], properties["valueType"]);
        //                        break;

        //                    case "value":
        //                        resultChartObj.value = Constant.getValue(properties["valueString"], properties["valueType"]);
        //                        break;


        //                }
        //            }
        //        }
        //    }
        //    return resultChartObj;
        //}

        //public static Dictionary<string, dynamic>? baseToJson(ChartObj objectModel)
        //{
        //    Dictionary<string, dynamic> newDict = new Dictionary<string, dynamic>();
        //    if (objectModel.id != null)
        //    {
        //        newDict.Add("chartObjId", objectModel.id);
        //        newDict.Add("description", "");
        //        List<Dictionary<string, dynamic>> propertiesDictList = new List<Dictionary<string, dynamic>>();
        //        Dictionary<string, dynamic>[] propertiesArray = new Dictionary<string, dynamic>[2];
        //        Dictionary<string, dynamic> tempDict = new Dictionary<string, dynamic>();
        //        tempDict = new Dictionary<string, dynamic>();
        //        tempDict["propertyId"] = "name";
        //        tempDict["description"] = "name";
        //        tempDict["valueString"] = objectModel.name;
        //        tempDict["valueType"] = 3;
        //        tempDict["valueUnitOfMeasure"] = "";
        //        propertiesDictList.Add(tempDict);

        //        tempDict = new Dictionary<string, dynamic>();
        //        tempDict["propertyId"] = "value";
        //        tempDict["description"] = "value";
        //        tempDict["valueString"] = objectModel.value.ToString();
        //        tempDict["valueType"] = 4;
        //        tempDict["valueUnitOfMeasure"] = "";
        //        propertiesDictList.Add(tempDict);



        //        int i = 0;
        //        foreach (Dictionary<string, dynamic> dict in propertiesDictList)
        //        {
        //            propertiesArray[i] = dict;
        //            i++;
        //        }
        //        newDict.Add("properties", propertiesArray);
        //    }
        //    return newDict;
        //}
    }
}
