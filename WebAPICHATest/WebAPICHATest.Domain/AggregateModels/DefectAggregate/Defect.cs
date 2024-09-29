using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.ConstantDomain;
using static WebAPICHATest.Domain.AggregateModels.EquipmentAggregate.Equipment;

namespace WebAPICHATest.Domain.AggregateModels.DefectAggregate
{
    public class Defect
    {
        public string id { get; set; }
        public string code { get; set; }
        public SolutionType type { get; set; } //Enum
        public EEquipmentType equipmentType { get; set; } //Enum
        public string name { get; set; }
        public double estProcessTime { get; set; }
        public string note { get; set; }
        public DefectSeverity severity { get; set; } //Enum

        public enum SolutionType
        {
            repair,
            replace
        }

        public enum DefectSeverity
        {
            urgent,
            high,
            normal,
            low
        }


        //public static Defect? baseFromJson(Dictionary<string, dynamic> json)
        //{
        //    Defect resultDefect = new Defect();
        //    foreach (var kv in json)
        //    {
        //        if (kv.Key == "defectId")
        //        {
        //            resultDefect.id = kv.Value;
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
        //                    case "id":
        //                        resultDefect.id = Constant.getValue(properties["valueString"], properties["valueType"]);
        //                        break;

        //                    case "code":
        //                        resultDefect.code = Constant.getValue(properties["valueString"], properties["valueType"]);
        //                        break;

        //                    case "type":
        //                        resultDefect.type = (SolutionType)Enum.Parse(typeof(SolutionType), properties["valueString"], true);
        //                        break;

        //                    case "equipmentType":
        //                        resultDefect.equipmentType = (EquipmentType)Enum.Parse(typeof(EquipmentType), properties["valueString"], true);
        //                        break;

        //                    case "name":
        //                        resultDefect.name = Constant.getValue(properties["valueString"], properties["valueType"]);
        //                        break;

        //                    case "estProcessTime":
        //                        resultDefect.estProcessTime = Constant.getValue(properties["valueString"], properties["valueType"]);
        //                        break;

        //                    case "note":
        //                        resultDefect.note = Constant.getValue(properties["valueString"], properties["valueType"]);
        //                        break;

        //                    case "severity":
        //                        resultDefect.severity = (DefectSeverity)Enum.Parse(typeof(DefectSeverity), properties["valueString"], true);
        //                        break;


        //                }
        //            }
        //        }
        //    }
        //    return resultDefect;
        //}

        //public static Dictionary<string, dynamic>? baseToJson(Defect objectModel)
        //{
        //    Dictionary<string, dynamic> newDict = new Dictionary<string, dynamic>();
        //    if (objectModel.id != null)
        //    {
        //        newDict.Add("defectId", objectModel.id);
        //        newDict.Add("description", "");
        //        List<Dictionary<string, dynamic>> propertiesDictList = new List<Dictionary<string, dynamic>>();
        //        Dictionary<string, dynamic>[] propertiesArray = new Dictionary<string, dynamic>[8];
        //        Dictionary<string, dynamic> tempDict = new Dictionary<string, dynamic>();
        //        tempDict = new Dictionary<string, dynamic>();
        //        tempDict["propertyId"] = "id";
        //        tempDict["description"] = "id";
        //        tempDict["valueString"] = objectModel.id;
        //        tempDict["valueType"] = 3;
        //        tempDict["valueUnitOfMeasure"] = "";
        //        propertiesDictList.Add(tempDict);

        //        tempDict = new Dictionary<string, dynamic>();
        //        tempDict["propertyId"] = "code";
        //        tempDict["description"] = "code";
        //        tempDict["valueString"] = objectModel.code;
        //        tempDict["valueType"] = 3;
        //        tempDict["valueUnitOfMeasure"] = "";
        //        propertiesDictList.Add(tempDict);

        //        tempDict = new Dictionary<string, dynamic>();
        //        tempDict["propertyId"] = "type";
        //        tempDict["description"] = "type";
        //        tempDict["valueString"] = objectModel.type.ToString();
        //        tempDict["valueType"] = 4;
        //        tempDict["valueUnitOfMeasure"] = "";
        //        propertiesDictList.Add(tempDict);

        //        tempDict = new Dictionary<string, dynamic>();
        //        tempDict["propertyId"] = "equipmentType";
        //        tempDict["description"] = "equipmentType";
        //        tempDict["valueString"] = objectModel.equipmentType.ToString();
        //        tempDict["valueType"] = 4;
        //        tempDict["valueUnitOfMeasure"] = "";
        //        propertiesDictList.Add(tempDict);

        //        tempDict = new Dictionary<string, dynamic>();
        //        tempDict["propertyId"] = "name";
        //        tempDict["description"] = "name";
        //        tempDict["valueString"] = objectModel.name;
        //        tempDict["valueType"] = 3;
        //        tempDict["valueUnitOfMeasure"] = "";
        //        propertiesDictList.Add(tempDict);

        //        tempDict = new Dictionary<string, dynamic>();
        //        tempDict["propertyId"] = "estProcessTime";
        //        tempDict["description"] = "estProcessTime";
        //        tempDict["valueString"] = objectModel.estProcessTime.ToString();
        //        tempDict["valueType"] = 4;
        //        tempDict["valueUnitOfMeasure"] = "";
        //        propertiesDictList.Add(tempDict);

        //        tempDict = new Dictionary<string, dynamic>();
        //        tempDict["propertyId"] = "note";
        //        tempDict["description"] = "note";
        //        tempDict["valueString"] = objectModel.note;
        //        tempDict["valueType"] = 3;
        //        tempDict["valueUnitOfMeasure"] = "";
        //        propertiesDictList.Add(tempDict);

        //        tempDict = new Dictionary<string, dynamic>();
        //        tempDict["propertyId"] = "severity";
        //        tempDict["description"] = "severity";
        //        tempDict["valueString"] = objectModel.severity.ToString();
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
