using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.CauseAggregate;
using WebAPICHATest.Domain.AggregateModels.DefectAggregate;
using WebAPICHATest.Domain.AggregateModels.PersonAggregate;
using WebAPICHATest.Domain.AggregateModels.MaintenanceRequestAggregate;
//using WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate;
using WebAPICHATest.Domain.AggregateModels.MaterialInforAggregate;
using WebAPICHATest.Domain.ConstantDomain;
using static WebAPICHATest.Domain.AggregateModels.EquipmentAggregate.Equipment;
using static WebAPICHATest.Domain.AggregateModels.MaintenanceRequestAggregate.MaintenanceRequest;
using WebAPICHATest.Domain.AggregateModels.CorrectionAggregate;
using WebAPICHATest.Domain.AggregateModels.EquipmentAggregate;

namespace WebAPICHATest.Domain.AggregateModels.MaintenanceWorkOrderAggregate
{
    public class MaintenanceWorkOrder : IAggregateRoot
    {
        public string? MaintenanceWorkOrderId { get; set; }
        public List<Cause> Cause { get; set; }
        public List<Correction> Correction { get; set; }
        public DateTime PlannedStart { get; set; }
        public DateTime PlannedFinish { get; set;}
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public Person ResponsiblePerson { get; set; }
        public List<MaterialInfor> Materials { get; set; }
        public EMaintenanceStatus Status { get; set; } //Enum
        public string Code { get; set; }
        public MaintenanceType Type { get; set; }
        public Equipment Equipment { get; set; }
        public List<Cause> Causes { get; set; }
        public Person Reviewer { get; set; }
        public MaintenanceRequest Request { get; set; }

        public enum MaintenanceType
        {
            reactive,
            preventive, 
            predictive
        }

        private MaintenanceWorkOrder()
        {

        }

        public MaintenanceWorkOrder(string maintenanceWorkOrderId)
        {
            MaintenanceWorkOrderId = maintenanceWorkOrderId;
        }

        public MaintenanceWorkOrder(string? maintenanceWorkOrderId, List<Cause> cause, List<Correction> correction, DateTime plannedStart, DateTime plannedFinish, DateTime createAt, DateTime updateAt, Person responsiblePerson, List<MaterialInfor> materials, EMaintenanceStatus status, string code, MaintenanceType type, Equipment equipment, List<Cause> causes, Person reviewer, MaintenanceRequest request)
        {
            MaintenanceWorkOrderId = maintenanceWorkOrderId;
            Cause = cause;
            Correction = correction;
            PlannedStart = plannedStart;
            PlannedFinish = plannedFinish;
            CreateAt = createAt;
            UpdateAt = updateAt;
            ResponsiblePerson = responsiblePerson;
            Materials = materials;
            Status = status;
            Code = code;
            Type = type;
            Equipment = equipment;
            Causes = causes;
            Reviewer = reviewer;
            Request = request;
        }


        //public static MaintenanceWorkOrder? baseFromJson(Dictionary<string, dynamic> json)
        //{
        //    MaintenanceWorkOrder resultMaintenanceWorkOrder = new MaintenanceWorkOrder();
        //    foreach (var kv in json)
        //    {
        //        if (kv.Key == "maintenanceWorkOrderId")
        //        {
        //            resultMaintenanceWorkOrder.id = kv.Value;
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
        //                        resultMaintenanceWorkOrder.id = Constant.getValue(properties["valueString"], properties["valueType"]);
        //                        break;

        //                    case "plannedStart":
        //                        resultMaintenanceWorkOrder.plannedStart = Constant.getValue(properties["valueString"], properties["valueType"]);
        //                        break;

        //                    case "plannedFinish":
        //                        resultMaintenanceWorkOrder.plannedFinish = Constant.getValue(properties["valueString"], properties["valueType"]);
        //                        break;

        //                    case "responsiblePerson":
        //                        Dictionary<string, dynamic> dictresponsiblePerson = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(properties["valueString"]);
        //                        resultMaintenanceWorkOrder.responsiblePerson = dictresponsiblePerson != null ? Employee.baseFromJson(dictresponsiblePerson) : null;
        //                        break;
        //                    case "materials":
        //                        List<Dictionary<string, dynamic>> listDictmaterials = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Dictionary<string, dynamic>>>(properties["valueString"]);
        //                        List<Material> listDictresourcessTemp = new List<Material>();
        //                        if (listDictmaterials != null)
        //                        {
        //                            foreach (Dictionary<string, dynamic> dictresources in listDictmaterials)
        //                            {
        //                                Material? temp = Material.baseFromJson(dictresources);
        //                                if (temp != null)
        //                                {
        //                                    listDictresourcessTemp.Add(temp);
        //                                }
        //                            }
        //                            resultMaintenanceWorkOrder.materials = listDictresourcessTemp;
        //                        }
        //                        else
        //                        {
        //                            resultMaintenanceWorkOrder.materials = null;
        //                        }
        //                        break;
        //                    case "status":
        //                        resultMaintenanceWorkOrder.status = (MaintenanceStatus)Enum.Parse(typeof(MaintenanceStatus), properties["valueString"], true);
        //                        break;

        //                    case "code":
        //                        resultMaintenanceWorkOrder.code = Constant.getValue(properties["valueString"], properties["valueType"]);
        //                        break;

        //                    case "request":
        //                        Dictionary<string, dynamic> dictrequest = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(properties["valueString"]);
        //                        resultMaintenanceWorkOrder.request = dictrequest != null ? MaintenanceRequest.baseFromJson(dictrequest) : null;
        //                        break;
        //                    case "type":
        //                        resultMaintenanceWorkOrder.type = (MaintenanceDefectType)Enum.Parse(typeof(MaintenanceDefectType), properties["valueString"], true);
        //                        break;

        //                    case "equipment":
        //                        Dictionary<string, dynamic> dictequipment = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(properties["valueString"]);
        //                        resultMaintenanceWorkOrder.equipment = dictequipment != null ? Equipment.baseFromJson(dictequipment) : null;
        //                        break;
        //                    case "defects":
        //                        List<Dictionary<string, dynamic>> listDictdefectss = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Dictionary<string, dynamic>>>(properties["valueString"]);
        //                        List<Defect> listDictdefectssTemp = new List<Defect>();
        //                        if (listDictdefectss != null)
        //                        {
        //                            foreach (Dictionary<string, dynamic> dictdefects in listDictdefectss)
        //                            {
        //                                Defect? temp = Defect.baseFromJson(dictdefects);
        //                                if (temp != null)
        //                                {
        //                                    listDictdefectssTemp.Add(temp);
        //                                }
        //                            }
        //                            resultMaintenanceWorkOrder.defects = listDictdefectssTemp;
        //                        }
        //                        else
        //                        {
        //                            resultMaintenanceWorkOrder.defects = null;
        //                        }
        //                        break;
        //                    case "problem":
        //                        resultMaintenanceWorkOrder.problem = Constant.getValue(properties["valueString"], properties["valueType"]);
        //                        break;

        //                    case "reviewer":
        //                        Dictionary<string, dynamic> dictreviewer = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(properties["valueString"]);
        //                        resultMaintenanceWorkOrder.reviewer = dictreviewer != null ? Employee.baseFromJson(dictreviewer) : null;
        //                        break;

        //                }
        //            }
        //        }
        //    }
        //    return resultMaintenanceWorkOrder;
        //}

        //public static Dictionary<string, dynamic>? baseToJson(MaintenanceWorkOrder objectModel)
        //{
        //    Dictionary<string, dynamic> newDict = new Dictionary<string, dynamic>();
        //    if (objectModel.id != null)
        //    {
        //        newDict.Add("maintenanceWorkOrderId", objectModel.id);
        //        newDict.Add("description", "");
        //        List<Dictionary<string, dynamic>> propertiesDictList = new List<Dictionary<string, dynamic>>();
        //        Dictionary<string, dynamic>[] propertiesArray = new Dictionary<string, dynamic>[13];
        //        Dictionary<string, dynamic> tempDict = new Dictionary<string, dynamic>();
        //        tempDict = new Dictionary<string, dynamic>();
        //        tempDict["propertyId"] = "id";
        //        tempDict["description"] = "id";
        //        tempDict["valueString"] = objectModel.id.ToString();
        //        tempDict["valueType"] = 4;
        //        tempDict["valueUnitOfMeasure"] = "";
        //        propertiesDictList.Add(tempDict);

        //        tempDict = new Dictionary<string, dynamic>();
        //        tempDict["propertyId"] = "plannedStart";
        //        tempDict["description"] = "plannedStart";
        //        tempDict["valueString"] = objectModel.plannedStart.ToString();
        //        tempDict["valueType"] = 4;
        //        tempDict["valueUnitOfMeasure"] = "";
        //        propertiesDictList.Add(tempDict);

        //        tempDict = new Dictionary<string, dynamic>();
        //        tempDict["propertyId"] = "plannedFinish";
        //        tempDict["description"] = "plannedFinish";
        //        tempDict["valueString"] = objectModel.plannedFinish.ToString();
        //        tempDict["valueType"] = 4;
        //        tempDict["valueUnitOfMeasure"] = "";
        //        propertiesDictList.Add(tempDict);

        //        tempDict = new Dictionary<string, dynamic>();
        //        tempDict["propertyId"] = "responsiblePerson";
        //        tempDict["description"] = "responsiblePerson";
        //        tempDict["valueString"] = Employee.baseToJson(objectModel.responsiblePerson).ToString();

        //        tempDict["valueType"] = 4;
        //        tempDict["valueUnitOfMeasure"] = "";
        //        propertiesDictList.Add(tempDict);

        //        tempDict = new Dictionary<string, dynamic>();
        //        tempDict["propertyId"] = "materials";
        //        tempDict["description"] = "materials";
        //        List<Dictionary<string, dynamic>> listMaterials = new List<Dictionary<string, dynamic>>();
        //        if (objectModel.materials != null)
        //        {
        //            foreach (Material materials in objectModel.materials)
        //            {
        //                Dictionary<string, dynamic>? newMaterialDict = Material.baseToJson(materials);
        //                if (newMaterialDict != null)
        //                {
        //                    listMaterials.Add(newMaterialDict);
        //                }
        //            }
        //            tempDict["valueString"] = listMaterials.ToArray().ToString();
        //        }
        //        else
        //        {
        //            tempDict["valueString"] = "null";
        //        }


        //        tempDict["valueType"] = 4;
        //        tempDict["valueUnitOfMeasure"] = "";
        //        propertiesDictList.Add(tempDict);

        //        tempDict = new Dictionary<string, dynamic>();
        //        tempDict["propertyId"] = "status";
        //        tempDict["description"] = "status";
        //        tempDict["valueString"] = objectModel.status.ToString();
        //        tempDict["valueType"] = 4;
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
        //        tempDict["propertyId"] = "request";
        //        tempDict["description"] = "request";
        //        tempDict["valueString"] = MaintenanceRequest.baseToJson(objectModel.request).ToString();

        //        tempDict["valueType"] = 4;
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
        //        tempDict["propertyId"] = "equipment";
        //        tempDict["description"] = "equipment";
        //        tempDict["valueString"] = Equipment.baseToJson(objectModel.equipment).ToString();

        //        tempDict["valueType"] = 4;
        //        tempDict["valueUnitOfMeasure"] = "";
        //        propertiesDictList.Add(tempDict);

        //        tempDict = new Dictionary<string, dynamic>();
        //        tempDict["propertyId"] = "defects";
        //        tempDict["description"] = "defects";
        //        List<Dictionary<string, dynamic>> listDefect = new List<Dictionary<string, dynamic>>();
        //        if (objectModel.defects != null)
        //        {
        //            foreach (Defect defect in objectModel.defects)
        //            {
        //                Dictionary<string, dynamic>? newDefectDict = Defect.baseToJson(defect);
        //                if (newDefectDict != null)
        //                {
        //                    listDefect.Add(newDefectDict);
        //                }
        //            }
        //            tempDict["valueString"] = listDefect.ToArray().ToString();
        //        }
        //        else
        //        {
        //            tempDict["valueString"] = "null";
        //        }


        //        tempDict["valueType"] = 4;
        //        tempDict["valueUnitOfMeasure"] = "";
        //        propertiesDictList.Add(tempDict);

        //        tempDict = new Dictionary<string, dynamic>();
        //        tempDict["propertyId"] = "problem";
        //        tempDict["description"] = "problem";
        //        tempDict["valueString"] = objectModel.problem;
        //        tempDict["valueType"] = 3;
        //        tempDict["valueUnitOfMeasure"] = "";
        //        propertiesDictList.Add(tempDict);

        //        tempDict = new Dictionary<string, dynamic>();
        //        tempDict["propertyId"] = "reviewer";
        //        tempDict["description"] = "reviewer";
        //        tempDict["valueString"] = Employee.baseToJson(objectModel.reviewer).ToString();

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


        //public static List<MaintenanceWorkOrder> fromJsonToMaintenanceWorkOrderList(string URL)
        //{
        //    List<MaintenanceWorkOrder> newListMaintenanceWorkOrder = new List<MaintenanceWorkOrder>();
        //    string data = CallURL.getMethod(URL);

        //    Dictionary<string, dynamic>? itemsDictJsonFromAPI = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(data);
        //    List<Dictionary<string, dynamic>> listDictJsonFromAPI = new List<Dictionary<string, dynamic>>();


        //    JArray jsonItems = itemsDictJsonFromAPI["items"];
        //    foreach (var item in jsonItems)
        //    {
        //        JObject jObject = (JObject)item;
        //        Dictionary<string, dynamic> tempDict = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(jObject.ToString());
        //        listDictJsonFromAPI.Add(tempDict);
        //    }

        //    foreach (Dictionary<string, dynamic> dictJsonAPI in listDictJsonFromAPI)
        //    {
        //        var newMaintenanceWorkOrder = MaintenanceWorkOrder.baseFromJson(dictJsonAPI);
        //        if (newMaintenanceWorkOrder != null)
        //        {
        //            newListMaintenanceWorkOrder.Add(newMaintenanceWorkOrder);
        //        }
        //    }

        //    return newListMaintenanceWorkOrder;
        //}

        //public static MaintenanceWorkOrder fromJsonToMaintenanceWorkOrderDetail(string id, string URL)
        //{
        //    List<MaintenanceWorkOrder> newListMaintenanceWorkOrder = new List<MaintenanceWorkOrder>();
        //    string data = CallURL.getMethod(URL);

        //    Dictionary<string, dynamic>? itemsDictJsonFromAPI = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(data);
        //    List<Dictionary<string, dynamic>> listDictJsonFromAPI = new List<Dictionary<string, dynamic>>();


        //    JArray jsonItems = itemsDictJsonFromAPI["items"];
        //    foreach (var item in jsonItems)
        //    {
        //        JObject jObject = (JObject)item;
        //        Dictionary<string, dynamic> tempDict = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(jObject.ToString());
        //        listDictJsonFromAPI.Add(tempDict);
        //    }

        //    foreach (Dictionary<string, dynamic> dictJsonAPI in listDictJsonFromAPI)
        //    {
        //        var newMaintenanceWorkOrder = MaintenanceWorkOrder.baseFromJson(dictJsonAPI);
        //        if (newMaintenanceWorkOrder != null)
        //        {
        //            newListMaintenanceWorkOrder.Add(newMaintenanceWorkOrder);
        //        }
        //    }

        //    MaintenanceWorkOrder returnMaintenanceWorkOrder = new MaintenanceWorkOrder();
        //    foreach (MaintenanceWorkOrder maintenanceWorkOrder in newListMaintenanceWorkOrder)
        //    {
        //        if (maintenanceWorkOrder.id == id)
        //        {
        //            returnMaintenanceWorkOrder = maintenanceWorkOrder;
        //        }
        //    }

        //    return returnMaintenanceWorkOrder;
        //}
    }
}
