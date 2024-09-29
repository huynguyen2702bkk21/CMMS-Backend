using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.PersonAggregate;
using WebAPICHATest.Domain.AggregateModels.EquipmentAggregate;
//using WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate;

namespace WebAPICHATest.Domain.ConstantDomain
{
    public class Constant
    {
        public enum EValueType
        {
            Boolean = 0,
            Integer = 1,
            Decimal = 2,
            String = 3,
            Json = 4,
        }

        public static dynamic getValue(string value, long valueType)
        {
            switch ((int)valueType)
            {
                case (int)EValueType.Boolean:
                    return bool.Parse(value);
                case (int)EValueType.Integer:
                    return int.Parse(value);
                case (int)EValueType.Decimal:
                    return decimal.Parse(value);
                case (int)EValueType.String:
                    return value;
                default:
                    return null;
            }
        }

        public static bool isInRange(DateTime? startDate, DateTime? endDate, DateTime? checkDate)
        {
            return (startDate <= checkDate) && (checkDate <= endDate);
        }
    }

    class UUID
    {
        public static string generateUUID()
        {
            Guid myUUId = Guid.NewGuid();
            string convertedUUID = myUUId.ToString();
            return convertedUUID;
        }
    }

    public class CallURL
    {
        public static string getMethod(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string data = "";

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;

                if (response.CharacterSet == null)
                    readStream = new StreamReader(receiveStream);
                else
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));

                data = readStream.ReadToEnd();
                response.Close();
                readStream.Close();
            }

            return data;
        }

        //public static bool postMethod(EquipmentClassPost body)
        //{
        //    string URL = "https://manufacturingoperationsmanagementcoremicroserviceapi.azurewebsites.net/api/EquipmentClasses";
        //    var client = new RestClient(URL);
        //    var request = new RestRequest();

        //    //var newBody = new Dictionary<string, dynamic>();
        //    //newBody.Add("equipmentClassId", "anhtu@12345");

        //    //newBody.Add("description", "tu-add-files");
        //    //List<Dictionary<string, dynamic>> propertiesDictList = new List<Dictionary<string, dynamic>>();
        //    //Dictionary<string, dynamic> codeDict = new Dictionary<string, dynamic>();
        //    //codeDict["propertyId"] = "code";
        //    //codeDict["description"] = "code-of-equipment";
        //    //codeDict["valueString"] = "L01-6";
        //    //codeDict["valueType"] = 3;
        //    //codeDict["valueUnitOfMeasure"] = "";
        //    //propertiesDictList.Add(codeDict);
        //    //Dictionary<string, dynamic> nameDict = new Dictionary<string, dynamic>();
        //    //nameDict["propertyId"] = "name";
        //    //nameDict["description"] = "name-of-equipment";
        //    //nameDict["valueString"] = "L01";
        //    //nameDict["valueType"] = 3;
        //    //nameDict["valueUnitOfMeasure"] = "";
        //    //propertiesDictList.Add(nameDict);
        //    //Dictionary<string, dynamic>[] propertiesArray = new Dictionary<string, dynamic>[propertiesDictList.Count];
        //    //propertiesArray[0] = propertiesDictList[0];
        //    //propertiesArray[1] = propertiesDictList[1];

        //    //newBody.Add("properties", propertiesArray);
        //    request.AddJsonBody(body);
        //    var response = client.Post(request);
        //    Console.WriteLine("success");
        //    return response.IsSuccessStatusCode;
        //}

        public static bool postMethod(Dictionary<string, dynamic> body, string URL)
        {
            var client = new RestClient(URL);
            var request = new RestRequest();

            request.AddJsonBody(body);
            Console.WriteLine("AddJsonBody done!");
            var response = client.Post(request);
            Console.WriteLine("success");
            return response.IsSuccessful;
        }

        public static bool putMethod(Dictionary<string, dynamic> body, string URL)
        {
            var client = new RestClient(URL);
            var request = new RestRequest();

            request.AddJsonBody(body);
            var response = client.Put(request);
            Console.WriteLine("success");
            return response.IsSuccessful;
        }
    }

    public static class TempMethod
    {
        //    //public static string AddEquipment(Equipment equipment)
        //    //{
        //    //    //EquipmentClassPost equipmentPost = EquipmentClass.fromEquipmentToJson(equipmentClass);
        //    //    Dictionary<string, dynamic> equipmentBody = TempMethod.BaseToJsonEquipment(equipment);
        //    //    Console.WriteLine("BaseToJson is success");
        //    //    string URL = "https://manufacturingoperationsmanagementcoremicroserviceapi.azurewebsites.net/api/Equipments";

        //    //    bool isSuccess = CallURL.postMethod(equipmentBody, URL);
        //    //    string message = "";
        //    //    if (isSuccess)
        //    //    {
        //    //        message = "The creation is success";
        //    //    }
        //    //    else
        //    //    {
        //    //        message = "The creation is fail";
        //    //    }
        //    //    return message;
        //    //}
        //    public static Dictionary<string, dynamic>? BaseToJsonEquipmentClass(EquipmentClass equipmentClass)
        //    {
        //        Dictionary<string, dynamic> newDict = new Dictionary<string, dynamic>();
        //        if (equipmentClass.id != null)
        //        {
        //            newDict.Add("equipmentClassId", equipmentClass.id);
        //            newDict.Add("description", "description-of-equipmentClass");
        //            List<Dictionary<string, dynamic>> propertiesDictList = new List<Dictionary<string, dynamic>>();
        //            Dictionary<string, dynamic> tempDict = new Dictionary<string, dynamic>();
        //            tempDict["propertyId"] = "code";
        //            tempDict["description"] = "code-of-equipment";
        //            tempDict["valueString"] = equipmentClass.code;
        //            tempDict["valueType"] = 3;
        //            tempDict["valueUnitOfMeasure"] = "";
        //            propertiesDictList.Add(tempDict);
        //            Console.WriteLine("code is success");

        //            tempDict = new Dictionary<string, dynamic>();
        //            tempDict["propertyId"] = "name";
        //            tempDict["description"] = "name-of-equipment";
        //            tempDict["valueString"] = equipmentClass.name;
        //            tempDict["valueType"] = 3;
        //            tempDict["valueUnitOfMeasure"] = "";
        //            propertiesDictList.Add(tempDict);
        //            Console.WriteLine("name is success");

        //            tempDict = new Dictionary<string, dynamic>();
        //            tempDict["propertyId"] = "type";
        //            tempDict["description"] = "type-of-equipment";
        //            tempDict["valueString"] = equipmentClass.type.ToString();
        //            tempDict["valueType"] = 3;
        //            tempDict["valueUnitOfMeasure"] = "";
        //            propertiesDictList.Add(tempDict);
        //            Console.WriteLine("type is success");

        //            tempDict = new Dictionary<string, dynamic>();
        //            tempDict["propertyId"] = "mtbf";
        //            tempDict["description"] = "mtbf-of-equipment";
        //            tempDict["valueString"] = equipmentClass.mtbf.ToString();
        //            tempDict["valueType"] = 2;
        //            tempDict["valueUnitOfMeasure"] = "";
        //            propertiesDictList.Add(tempDict);
        //            Console.WriteLine("mtbf is success");

        //            tempDict = new Dictionary<string, dynamic>();
        //            tempDict["propertyId"] = "mttf";
        //            tempDict["description"] = "mttf-of-equipment";
        //            tempDict["valueString"] = equipmentClass.mttf.ToString();
        //            tempDict["valueType"] = 2;
        //            tempDict["valueUnitOfMeasure"] = "";
        //            propertiesDictList.Add(tempDict);
        //            Console.WriteLine("mttf is success");

        //            tempDict = new Dictionary<string, dynamic>();
        //            tempDict["propertyId"] = "oee";
        //            tempDict["description"] = "oee-of-equipment";
        //            tempDict["valueString"] = equipmentClass.oee.ToString();
        //            tempDict["valueType"] = 2;
        //            tempDict["valueUnitOfMeasure"] = "";
        //            propertiesDictList.Add(tempDict);
        //            Console.WriteLine("oee is success");

        //            tempDict = new Dictionary<string, dynamic>();
        //            tempDict["propertyId"] = "status";
        //            tempDict["description"] = "status-of-equipment";
        //            tempDict["valueString"] = equipmentClass.status.ToString();
        //            tempDict["valueType"] = 3;
        //            tempDict["valueUnitOfMeasure"] = "";
        //            propertiesDictList.Add(tempDict);
        //            Console.WriteLine("status is success");

        //            //tempDict = new Dictionary<string, dynamic>();
        //            //tempDict["propertyId"] = "recentMaintenanceWorkOrder";
        //            //tempDict["description"] = "recentMaintenanceWorkOrder-of-equipment";
        //            //List<Dictionary<string, dynamic>> listMaintenanceWorkOrders = new List<Dictionary<string, dynamic>>();
        //            //foreach (MaintenanceResponse workOrder in equipment.recentMaintenanceWorkOrder)
        //            //{
        //            //    Dictionary<string, dynamic> newWorkOrderDict = MaintenanceResponse.baseToJson(workOrder);
        //            //    listMaintenanceWorkOrders.Add(newWorkOrderDict);
        //            //}
        //            //tempDict["valueString"] = listMaintenanceWorkOrders.ToArray().ToString();
        //            //tempDict["valueType"] = 3;
        //            //tempDict["valueUnitOfMeasure"] = "";
        //            //propertiesDictList.Add(tempDict);
        //            //Console.WriteLine("recentMaintenanceWorkOrder is success");

        //            Dictionary<string, dynamic>[] propertiesArray = new Dictionary<string, dynamic>[propertiesDictList.Count];
        //            int i = 0;
        //            foreach (Dictionary<string, dynamic> dict in propertiesDictList)
        //            {
        //                propertiesArray[i] = dict;
        //                i++;
        //            }
        //            newDict.Add("properties", propertiesArray);
        //        }
        //        return newDict;
        //    }

        //    public static EquipmentClass? BaseFromJsonEquipmentClass(Dictionary<string, dynamic> json)
        //    {
        //        EquipmentClass resultEquipmentClass = new EquipmentClass();
        //        foreach (var kv in json)
        //        {
        //            if (kv.Key == "equipmentId")
        //            {
        //                resultEquipmentClass.id = kv.Value;
        //            }

        //            if (kv.Key == "properties")
        //            {
        //                List<Dictionary<string, dynamic>> listProperties = new List<Dictionary<string, dynamic>>();
        //                JArray jsonItems = kv.Value;
        //                foreach (var item in jsonItems)
        //                {
        //                    JObject jObject = (JObject)item;
        //                    Dictionary<string, dynamic> tempDict = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(jObject.ToString());
        //                    listProperties.Add(tempDict);
        //                }

        //                //listProperties = kv.Value;

        //                foreach (var properties in listProperties)
        //                {
        //                    switch (properties["propertyId"])
        //                    {
        //                        case "code":
        //                            var value = properties["valueString"];
        //                            var valueType = properties["valueType"];
        //                            resultEquipmentClass.code = Constant.getValue(value, valueType);
        //                            break;
        //                        case "name":
        //                            resultEquipmentClass.name = Constant.getValue(properties["valueString"], properties["valueType"]);
        //                            break;
        //                        case "type":
        //                            resultEquipmentClass.type = properties["valueString"];
        //                            break;
        //                        case "mtbf":
        //                            resultEquipmentClass.mtbf = Constant.getValue(properties["valueString"], properties["valueType"]);
        //                            break;
        //                        case "mttf":
        //                            resultEquipmentClass.mttf = Constant.getValue(properties["valueString"], properties["valueType"]);
        //                            break;
        //                        case "oee":
        //                            resultEquipmentClass.oee = Constant.getValue(properties["valueString"], properties["valueType"]);
        //                            break;
        //                        case "status":
        //                            resultEquipmentClass.status = properties["valueString"];
        //                            break;
        //                            //case "recentMaintenanceWorkOrder":
        //                            //    List<Dictionary<string, dynamic>> listDictWorkOrders = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Dictionary<string, dynamic>>>(properties["valueString"]);
        //                            //    List<MaintenanceResponse> listWorkOrdersTemp = new List<MaintenanceResponse>();
        //                            //    foreach (Dictionary<string, dynamic> dictWorkOrder in listDictWorkOrders)
        //                            //    {
        //                            //        MaintenanceResponse temp = MaintenanceResponse.baseFromJson(dictWorkOrder);
        //                            //        if (temp != null)
        //                            //        {
        //                            //            listWorkOrdersTemp.Add(temp);
        //                            //        }
        //                            //    }

        //                            //    resultEquipmentClass.recentMaintenanceWorkOrder = listWorkOrdersTemp;
        //                            //break;
        //                    }
        //                }
        //            }
        //        }
        //        return resultEquipmentClass;
        //    }

        //    public static Equipment? BaseFromJsonEquipment(Dictionary<string, dynamic> json)
        //    {
        //        Equipment resultEquipment = new Equipment();
        //        foreach (var kv in json)
        //        {
        //            if (kv.Key == "equipmentId")
        //            {
        //                resultEquipment.id = kv.Value;
        //            }

        //            if (kv.Key == "properties")
        //            {
        //                List<Dictionary<string, dynamic>> listProperties = new List<Dictionary<string, dynamic>>();
        //                JArray jsonItems = kv.Value;
        //                foreach (var item in jsonItems)
        //                {
        //                    JObject jObject = (JObject)item;
        //                    Dictionary<string, dynamic> tempDict = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(jObject.ToString());
        //                    listProperties.Add(tempDict);
        //                }

        //                //listProperties = kv.Value;

        //                foreach (var properties in listProperties)
        //                {
        //                    switch (properties["propertyId"])
        //                    {
        //                        case "code":
        //                            var value = properties["valueString"];
        //                            var valueType = properties["valueType"];
        //                            resultEquipment.code = Constant.getValue(value, valueType);
        //                            break;
        //                        case "name":
        //                            resultEquipment.name = Constant.getValue(properties["valueString"], properties["valueType"]);
        //                            break;
        //                        case "type":
        //                            resultEquipment.type = properties["valueString"];
        //                            break;
        //                        case "mtbf":
        //                            resultEquipment.mtbf = Constant.getValue(properties["valueString"], properties["valueType"]);
        //                            break;
        //                        case "mttf":
        //                            resultEquipment.mttf = Constant.getValue(properties["valueString"], properties["valueType"]);
        //                            break;
        //                        case "oee":
        //                            resultEquipment.oee = Constant.getValue(properties["valueString"], properties["valueType"]);
        //                            break;
        //                        case "status":
        //                            resultEquipment.status = properties["valueString"];
        //                            break;
        //                            //case "recentMaintenanceWorkOrder":
        //                            //    List<Dictionary<string, dynamic>> listDictWorkOrders = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Dictionary<string, dynamic>>>(properties["valueString"]);
        //                            //    List<MaintenanceResponse> listWorkOrdersTemp = new List<MaintenanceResponse>();
        //                            //    foreach (Dictionary<string, dynamic> dictWorkOrder in listDictWorkOrders)
        //                            //    {
        //                            //        MaintenanceResponse temp = MaintenanceResponse.baseFromJson(dictWorkOrder);
        //                            //        if (temp != null)
        //                            //        {
        //                            //            listWorkOrdersTemp.Add(temp);
        //                            //        }
        //                            //    }

        //                            //    resultEquipment.recentMaintenanceWorkOrder = listWorkOrdersTemp;
        //                            //    break;
        //                    }
        //                }
        //            }
        //        }
        //        return resultEquipment;
        //    }

        //    public static Dictionary<string, dynamic>? BaseToJsonEquipment(Equipment equipment)
        //    {
        //        Dictionary<string, dynamic> newDict = new Dictionary<string, dynamic>();
        //        if (equipment.id != null)
        //        {
        //            newDict.Add("equipmentId", equipment.id);
        //            newDict.Add("description", "description-of-equipment");
        //            List<Dictionary<string, dynamic>> propertiesDictList = new List<Dictionary<string, dynamic>>();
        //            Dictionary<string, dynamic> tempDict = new Dictionary<string, dynamic>();
        //            tempDict["propertyId"] = "code";
        //            tempDict["description"] = "code-of-equipment";
        //            tempDict["valueString"] = equipment.code;
        //            tempDict["valueType"] = 3;
        //            tempDict["valueUnitOfMeasure"] = "";
        //            propertiesDictList.Add(tempDict);
        //            Console.WriteLine("code is success");

        //            tempDict = new Dictionary<string, dynamic>();
        //            tempDict["propertyId"] = "name";
        //            tempDict["description"] = "name-of-equipment";
        //            tempDict["valueString"] = equipment.name;
        //            tempDict["valueType"] = 3;
        //            tempDict["valueUnitOfMeasure"] = "";
        //            propertiesDictList.Add(tempDict);
        //            Console.WriteLine("name is success");

        //            tempDict = new Dictionary<string, dynamic>();
        //            tempDict["propertyId"] = "type";
        //            tempDict["description"] = "type-of-equipment";
        //            tempDict["valueString"] = equipment.type.ToString();
        //            tempDict["valueType"] = 3;
        //            tempDict["valueUnitOfMeasure"] = "";
        //            propertiesDictList.Add(tempDict);
        //            Console.WriteLine("type is success");

        //            tempDict = new Dictionary<string, dynamic>();
        //            tempDict["propertyId"] = "mtbf";
        //            tempDict["description"] = "mtbf-of-equipment";
        //            tempDict["valueString"] = equipment.mtbf.ToString();
        //            tempDict["valueType"] = 2;
        //            tempDict["valueUnitOfMeasure"] = "";
        //            propertiesDictList.Add(tempDict);
        //            Console.WriteLine("mtbf is success");

        //            tempDict = new Dictionary<string, dynamic>();
        //            tempDict["propertyId"] = "mttf";
        //            tempDict["description"] = "mttf-of-equipment";
        //            tempDict["valueString"] = equipment.mttf.ToString();
        //            tempDict["valueType"] = 2;
        //            tempDict["valueUnitOfMeasure"] = "";
        //            propertiesDictList.Add(tempDict);
        //            Console.WriteLine("mttf is success");

        //            tempDict = new Dictionary<string, dynamic>();
        //            tempDict["propertyId"] = "oee";
        //            tempDict["description"] = "oee-of-equipment";
        //            tempDict["valueString"] = equipment.oee.ToString();
        //            tempDict["valueType"] = 2;
        //            tempDict["valueUnitOfMeasure"] = "";
        //            propertiesDictList.Add(tempDict);
        //            Console.WriteLine("oee is success");

        //            tempDict = new Dictionary<string, dynamic>();
        //            tempDict["propertyId"] = "status";
        //            tempDict["description"] = "status-of-equipment";
        //            tempDict["valueString"] = equipment.status.ToString();
        //            tempDict["valueType"] = 3;
        //            tempDict["valueUnitOfMeasure"] = "";
        //            propertiesDictList.Add(tempDict);
        //            Console.WriteLine("status is success");

        //            //tempDict = new Dictionary<string, dynamic>();
        //            //tempDict["propertyId"] = "recentMaintenanceWorkOrder";
        //            //tempDict["description"] = "recentMaintenanceWorkOrder-of-equipment";
        //            //List<Dictionary<string, dynamic>> listMaintenanceWorkOrders = new List<Dictionary<string, dynamic>>();
        //            //foreach (MaintenanceResponse workOrder in equipment.recentMaintenanceWorkOrder)
        //            //{
        //            //    Dictionary<string, dynamic> newWorkOrderDict = MaintenanceResponse.baseToJson(workOrder);
        //            //    listMaintenanceWorkOrders.Add(newWorkOrderDict);
        //            //}
        //            //tempDict["valueString"] = listMaintenanceWorkOrders.ToArray().ToString();
        //            //tempDict["valueType"] = 3;
        //            //tempDict["valueUnitOfMeasure"] = "";
        //            //propertiesDictList.Add(tempDict);
        //            //Console.WriteLine("recentMaintenanceWorkOrder is success");

        //            Dictionary<string, dynamic>[] propertiesArray = new Dictionary<string, dynamic>[propertiesDictList.Count];
        //            int i = 0;
        //            foreach (Dictionary<string, dynamic> dict in propertiesDictList)
        //            {
        //                propertiesArray[i] = dict;
        //                i++;
        //            }
        //            newDict.Add("properties", propertiesArray);
        //        }
        //        return newDict;
        //    }

        //    public static MaintenanceResponse? baseFromJson(Dictionary<string, dynamic> json)
        //    {
        //        MaintenanceResponse result = new MaintenanceResponse();
        //        foreach (var kv in json["items"])
        //        {
        //            if (kv.Key == "equipmentId")
        //            {
        //                result.id = kv.Value;
        //            }

        //            if (kv.Key == "properties")
        //            {
        //                List<Dictionary<string, dynamic>> listProperties = kv.Value;
        //                foreach (var properties in listProperties)
        //                {
        //                    switch (properties["propertyId"])
        //                    {
        //                        case "cause":
        //                            List<dynamic> listTemp = properties["valueString"];
        //                            var resultListString = new List<dynamic>();
        //                            foreach (var temp in listTemp)
        //                            {
        //                                resultListString.Add(Constant.getValue(temp, properties["valueType"]));
        //                            }

        //                            result.cause = resultListString.OfType<string>().ToList();
        //                            break;
        //                        case "correction":
        //                            List<dynamic> listCorrection = properties["valueString"];
        //                            var resultListCorrection = new List<dynamic>();
        //                            foreach (var temp in listCorrection)
        //                            {
        //                                resultListCorrection.Add(Constant.getValue(temp, properties["valueType"]));
        //                            }

        //                            result.cause = resultListCorrection.OfType<string>().ToList();
        //                            break;
        //                        case "actualStartTime":
        //                            var resultActualStartTime = Constant.getValue(properties["valueString"], properties["valueType"]);
        //                            result.actualStartTime = DateTime.ParseExact(resultActualStartTime, "yyyy-MM-ddTHH\\:mm\\:ss.fffffffzzz", System.Globalization.CultureInfo.InvariantCulture);
        //                            break;
        //                        case "actualFinishTime":
        //                            var resultActualFinishTime = Constant.getValue(properties["valueString"], properties["valueType"]);
        //                            result.actualFinishTime = DateTime.ParseExact(resultActualFinishTime, "yyyy-MM-ddTHH\\:mm\\:ss.fffffffzzz", System.Globalization.CultureInfo.InvariantCulture);
        //                            break;
        //                        case "status":
        //                            result.status = Constant.getValue(properties["valueString"], properties["valueType"]);
        //                            break;
        //                        case "statusTime":
        //                            var resultStatusTime = Constant.getValue(properties["valueString"], properties["valueType"]);
        //                            result.statusTime = DateTime.ParseExact(resultStatusTime, "yyyy-MM-ddTHH\\:mm\\:ss.fffffffzzz", System.Globalization.CultureInfo.InvariantCulture);
        //                            break;
        //                        case "responsiblePerson":
        //                            Dictionary<string, dynamic> dictResponsiblePerson = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(properties["valueString"]);
        //                            result.responsiblePerson = Employee.baseFromJson(dictResponsiblePerson);
        //                            break;
        //                        case "images":
        //                            List<dynamic> listImages = properties["valueString"];
        //                            var resultListImages = new List<dynamic>();
        //                            foreach (var temp in listImages)
        //                            {
        //                                resultListImages.Add(Constant.getValue(temp, properties["valueType"]));
        //                            }

        //                            result.images = resultListImages.OfType<string>().ToList();
        //                            break;
        //                        case "sounds":
        //                            List<dynamic> listSounds = properties["valueString"];
        //                            var resultListSounds = new List<dynamic>();
        //                            foreach (var temp in listSounds)
        //                            {
        //                                resultListSounds.Add(Constant.getValue(temp, properties["valueType"]));
        //                            }

        //                            result.sounds = resultListSounds.OfType<string>().ToList();
        //                            break;
        //                        case "parts":
        //                            List<Dictionary<string, dynamic>> listDictParts = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Dictionary<string, dynamic>>>(properties["valueString"]);
        //                            List<MaintenancePart> listPartTemp = new List<MaintenancePart>();
        //                            foreach (Dictionary<string, dynamic> dictPart in listDictParts)
        //                            {
        //                                MaintenancePart temp = MaintenancePart.baseFromJson(dictPart);
        //                                if (temp != null)
        //                                {
        //                                    listPartTemp.Add(temp);
        //                                }
        //                            }

        //                            result.parts = listPartTemp;
        //                            break;
        //                        case "note":
        //                            result.note = Constant.getValue(properties["valueString"], properties["valueType"]);
        //                            break;
        //                    }
        //                }
        //            }
        //        }
        //        return result;
        //    }

        //    public static Dictionary<string, dynamic>? baseToJson(MaintenanceResponse response)
        //    {
        //        Dictionary<string, dynamic> newDict = new Dictionary<string, dynamic>();
        //        if (response.id != null)
        //        {
        //            newDict.Add("maintenanceResponseId", response.id);
        //            newDict.Add("description", "description-of-maintenance-response");
        //            List<Dictionary<string, dynamic>> propertiesDictList = new List<Dictionary<string, dynamic>>();
        //            Dictionary<string, dynamic> tempDict = new Dictionary<string, dynamic>();
        //            tempDict["propertyId"] = "cause";
        //            tempDict["description"] = "cause-of-maintenance-response";
        //            string[] stringArray = new string[response.cause.Count];
        //            int j = 0;
        //            foreach (string cause in response.cause)
        //            {
        //                stringArray[j] = cause;
        //                j++;
        //            }
        //            tempDict["valueString"] = stringArray;
        //            tempDict["valueType"] = 3;
        //            tempDict["valueUnitOfMeasure"] = "";
        //            propertiesDictList.Add(tempDict);

        //            tempDict = new Dictionary<string, dynamic>();
        //            tempDict["propertyId"] = "correction";
        //            tempDict["description"] = "correction-of-maintenance-response";
        //            stringArray = new string[response.correction.Count];
        //            j = 0;
        //            foreach (string correction in response.correction)
        //            {
        //                stringArray[j] = correction;
        //                j++;
        //            }
        //            tempDict["valueString"] = stringArray;
        //            tempDict["valueType"] = 3;
        //            tempDict["valueUnitOfMeasure"] = "";
        //            propertiesDictList.Add(tempDict);

        //            tempDict = new Dictionary<string, dynamic>();
        //            tempDict["propertyId"] = "actualStartTime";
        //            tempDict["description"] = "actualStartTime-of-maintenance-response";
        //            var startDate = response.actualStartTime;
        //            tempDict["valueString"] = startDate.ToString();
        //            tempDict["valueType"] = 3;
        //            tempDict["valueUnitOfMeasure"] = "";
        //            propertiesDictList.Add(tempDict);

        //            tempDict = new Dictionary<string, dynamic>();
        //            tempDict["propertyId"] = "actualFinishTime";
        //            tempDict["description"] = "actualFinishTime-of-maintenance-response";
        //            var finishDate = response.actualStartTime;
        //            tempDict["valueString"] = finishDate.ToString();
        //            tempDict["valueType"] = 3;
        //            tempDict["valueUnitOfMeasure"] = "";
        //            propertiesDictList.Add(tempDict);

        //            tempDict = new Dictionary<string, dynamic>();
        //            tempDict["propertyId"] = "status";
        //            tempDict["description"] = "status-of-maintenance-response";
        //            tempDict["valueString"] = response.status.ToString();
        //            tempDict["valueType"] = 1;
        //            tempDict["valueUnitOfMeasure"] = "";
        //            propertiesDictList.Add(tempDict);

        //            tempDict = new Dictionary<string, dynamic>();
        //            tempDict["propertyId"] = "statusTime";
        //            tempDict["description"] = "statusTime-of-maintenance-response";
        //            var statusDate = response.statusTime;
        //            tempDict["valueString"] = statusDate.ToString();
        //            tempDict["valueType"] = 3;
        //            tempDict["valueUnitOfMeasure"] = "";
        //            propertiesDictList.Add(tempDict);

        //            tempDict = new Dictionary<string, dynamic>();
        //            tempDict["propertyId"] = "responsiblePerson";
        //            tempDict["description"] = "responsiblePerson-of-maintenance-response";
        //            var responsiblePersonDict = Employee.baseToJson(response.responsiblePerson);
        //            tempDict["valueString"] = responsiblePersonDict.ToString();
        //            tempDict["valueType"] = 4;
        //            tempDict["valueUnitOfMeasure"] = "";
        //            propertiesDictList.Add(tempDict);

        //            tempDict = new Dictionary<string, dynamic>();
        //            tempDict["propertyId"] = "images";
        //            tempDict["description"] = "images-of-maintenance-response";
        //            tempDict["valueString"] = response.images.ToArray().ToString();
        //            tempDict["valueType"] = 3;
        //            tempDict["valueUnitOfMeasure"] = "";
        //            propertiesDictList.Add(tempDict);

        //            tempDict = new Dictionary<string, dynamic>();
        //            tempDict["propertyId"] = "sounds";
        //            tempDict["description"] = "sounds-of-maintenance-response";
        //            tempDict["valueString"] = response.sounds.ToArray().ToString();
        //            tempDict["valueType"] = 3;
        //            tempDict["valueUnitOfMeasure"] = "";
        //            propertiesDictList.Add(tempDict);

        //            tempDict = new Dictionary<string, dynamic>();
        //            tempDict["propertyId"] = "parts";
        //            tempDict["description"] = "parts-of-maintenance-response";
        //            List<Dictionary<string, dynamic>> listParts = new List<Dictionary<string, dynamic>>();
        //            foreach (MaintenancePart part in response.parts)
        //            {
        //                Dictionary<string, dynamic> newPartDict = MaintenancePart.baseToJson(part);
        //                listParts.Add(newPartDict);
        //            }
        //            tempDict["valueString"] = listParts.ToArray().ToString();
        //            tempDict["valueType"] = 3;
        //            tempDict["valueUnitOfMeasure"] = "";
        //            propertiesDictList.Add(tempDict);

        //            tempDict = new Dictionary<string, dynamic>();
        //            tempDict["propertyId"] = "note";
        //            tempDict["description"] = "note-of-maintenance-response";
        //            tempDict["valueString"] = response.note.ToString();
        //            tempDict["valueType"] = 3;
        //            tempDict["valueUnitOfMeasure"] = "";
        //            propertiesDictList.Add(tempDict);

        //            Dictionary<string, dynamic>[] propertiesArray = new Dictionary<string, dynamic>[propertiesDictList.Count];
        //            int i = 0;
        //            foreach (Dictionary<string, dynamic> dict in propertiesDictList)
        //            {
        //                propertiesArray[i] = dict;
        //                i++;
        //            }
        //            newDict.Add("properties", propertiesArray);
        //        }
        //        return newDict;
        //    }

        //    public static Employee? baseFromJson(Dictionary<string, dynamic> json)
        //    {
        //        Employee result = new Employee();
        //        foreach (var kv in json["items"])
        //        {
        //            if (kv.Key == "equipmentId")
        //            {
        //                result.id = kv.Value;
        //            }

        //            if (kv.Key == "properties")
        //            {
        //                List<Dictionary<string, dynamic>> listProperties = kv.Value;
        //                foreach (var properties in listProperties)
        //                {
        //                    switch (properties["propertyId"])
        //                    {
        //                        case "name":
        //                            result.name = Constant.getValue(properties["valueString"], properties["valueType"]);
        //                            break;
        //                    }
        //                }
        //            }
        //        }
        //        return result;
        //    }

        //    public static Dictionary<string, dynamic>? baseToJson(Employee employee)
        //    {
        //        Dictionary<string, dynamic> newDict = new Dictionary<string, dynamic>();
        //        if (employee.id != null)
        //        {
        //            newDict.Add("employeeId", employee.id);
        //            newDict.Add("description", "description-of-employee");
        //            List<Dictionary<string, dynamic>> propertiesDictList = new List<Dictionary<string, dynamic>>();
        //            Dictionary<string, dynamic>[] propertiesArray = new Dictionary<string, dynamic>[1];
        //            Dictionary<string, dynamic> tempDict = new Dictionary<string, dynamic>();
        //            tempDict["propertyId"] = "name";
        //            tempDict["description"] = "name-of-employee";
        //            tempDict["valueString"] = employee.name;
        //            tempDict["valueType"] = 3;
        //            tempDict["valueUnitOfMeasure"] = "";
        //            propertiesDictList.Add(tempDict);
        //            propertiesArray[0] = propertiesDictList[0];
        //            newDict.Add("properties", propertiesArray);
        //        }
        //        return newDict;
        //    }

        //public static MaintenancePart? baseFromJson(Dictionary<string, dynamic> json)
        //{
        //    MaintenancePart result = new MaintenancePart();
        //    foreach (var kv in json["items"])
        //    {
        //        if (kv.Key == "equipmentId")
        //        {
        //            result.id = kv.Value;
        //        }

        //        if (kv.Key == "properties")
        //        {
        //            List<Dictionary<string, dynamic>> listProperties = kv.Value;
        //            foreach (var properties in listProperties)
        //            {
        //                switch (properties["propertyId"])
        //                {
        //                    case "sparePartInfo":
        //                        Dictionary<string, dynamic> dictsparePartInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(properties["valueString"]);
        //                        result.sparePartInfo = SparePartInfo.baseFromJson(dictsparePartInfo);
        //                        break;
        //                    case "quantity":
        //                        result.quantity = Constant.getValue(properties["valueString"], properties["valueType"]);
        //                        break;
        //                    case "available":
        //                        result.available = Constant.getValue(properties["valueString"], properties["valueType"]);
        //                        break;
        //                }
        //            }
        //        }
        //    }
        //    return result;
        //}

        //public static Dictionary<string, dynamic>? baseToJson(MaintenancePart part)
        //{
        //    Dictionary<string, dynamic> newDict = new Dictionary<string, dynamic>();
        //    if (part.id != null)
        //    {
        //        newDict.Add("maintenancePartId", part.id);
        //        newDict.Add("description", "description-of-maintenance-part");
        //        List<Dictionary<string, dynamic>> propertiesDictList = new List<Dictionary<string, dynamic>>();
        //        Dictionary<string, dynamic> tempDict = new Dictionary<string, dynamic>();

        //        tempDict["propertyId"] = "sparePartInfo";
        //        tempDict["description"] = "spare-part-info-of-maintenance-part";
        //        Dictionary<string, dynamic> dictTemp = SparePartInfo.baseToJson(part.sparePartInfo);
        //        tempDict["valueString"] = dictTemp.ToString();
        //        tempDict["valueType"] = 4;
        //        tempDict["valueUnitOfMeasure"] = "";
        //        propertiesDictList.Add(tempDict);

        //        tempDict = new Dictionary<string, dynamic>();
        //        tempDict["propertyId"] = "quantity";
        //        tempDict["description"] = "quantity-of-maintenance-part";
        //        tempDict["valueString"] = part.quantity.ToString();
        //        tempDict["valueType"] = 3;
        //        tempDict["valueUnitOfMeasure"] = "";
        //        propertiesDictList.Add(tempDict);

        //        tempDict = new Dictionary<string, dynamic>();
        //        tempDict["propertyId"] = "available";
        //        tempDict["description"] = "available-of-maintenance-part";
        //        tempDict["valueString"] = part.available.ToString();
        //        tempDict["valueType"] = 3;
        //        tempDict["valueUnitOfMeasure"] = "";
        //        propertiesDictList.Add(tempDict);

        //        Dictionary<string, dynamic>[] propertiesArray = new Dictionary<string, dynamic>[propertiesDictList.Count];
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

        //public static SparePartInfo? baseFromJson(Dictionary<string, dynamic> json)
        //{
        //    SparePartInfo result = new SparePartInfo();
        //    foreach (var kv in json["items"])
        //    {
        //        if (kv.Key == "equipmentId")
        //        {
        //            result.id = kv.Value;
        //        }

        //        if (kv.Key == "properties")
        //        {
        //            List<Dictionary<string, dynamic>> listProperties = kv.Value;
        //            foreach (var properties in listProperties)
        //            {
        //                switch (properties["propertyId"])
        //                {
        //                    case "code":
        //                        result.code = Constant.getValue(properties["valueString"], properties["valueType"]);
        //                        break;
        //                    case "name":
        //                        result.name = Constant.getValue(properties["valueString"], properties["valueType"]);
        //                        break;
        //                    case "unit":
        //                        result.unit = Constant.getValue(properties["valueString"], properties["valueType"]);
        //                        break;
        //                    case "minimumQuantity":
        //                        result.minimumQuantity = Constant.getValue(properties["valueString"], properties["valueType"]);
        //                        break;
        //                }
        //            }
        //        }
        //    }
        //    return result;
        //}

        //public static Dictionary<string, dynamic>? baseToJson(SparePartInfo sparePartInfo)
        //{
        //    Dictionary<string, dynamic> newDict = new Dictionary<string, dynamic>();
        //    if (sparePartInfo.id != null)
        //    {
        //        newDict.Add("sparePartInfoId", sparePartInfo.id);
        //        newDict.Add("description", "description-of-sparePartInfo");
        //        List<Dictionary<string, dynamic>> propertiesDictList = new List<Dictionary<string, dynamic>>();
        //        Dictionary<string, dynamic> tempDict = new Dictionary<string, dynamic>();
        //        tempDict["propertyId"] = "code";
        //        tempDict["description"] = "code-of-sparePartInfo";
        //        tempDict["valueString"] = sparePartInfo.code;
        //        tempDict["valueType"] = 3;
        //        tempDict["valueUnitOfMeasure"] = "";
        //        propertiesDictList.Add(tempDict);

        //        tempDict = new Dictionary<string, dynamic>();
        //        tempDict["propertyId"] = "name";
        //        tempDict["description"] = "name-of-sparePartInfo";
        //        tempDict["valueString"] = sparePartInfo.name;
        //        tempDict["valueType"] = 3;
        //        tempDict["valueUnitOfMeasure"] = "";
        //        propertiesDictList.Add(tempDict);

        //        tempDict = new Dictionary<string, dynamic>();
        //        tempDict["propertyId"] = "unit";
        //        tempDict["description"] = "unit-of-sparePartInfo";
        //        tempDict["valueString"] = sparePartInfo.unit;
        //        tempDict["valueType"] = 3;
        //        tempDict["valueUnitOfMeasure"] = "";
        //        propertiesDictList.Add(tempDict);

        //        tempDict = new Dictionary<string, dynamic>();
        //        tempDict["propertyId"] = "minimumQuantity";
        //        tempDict["description"] = "minimumQuantity-of-sparePartInfo";
        //        tempDict["valueString"] = sparePartInfo.minimumQuantity.ToString();
        //        tempDict["valueType"] = 2;
        //        tempDict["valueUnitOfMeasure"] = "";
        //        propertiesDictList.Add(tempDict);

        //        Dictionary<string, dynamic>[] propertiesArray = new Dictionary<string, dynamic>[propertiesDictList.Count];
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
