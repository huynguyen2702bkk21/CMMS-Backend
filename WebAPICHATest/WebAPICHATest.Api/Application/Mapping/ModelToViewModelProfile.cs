using WebAPICHATest.Api.Application.Queries;
using WebAPICHATest.Api.Application.Queries.Causes;
//using WebAPICHATest.Api.Application.Queries.ChartObjs;
using WebAPICHATest.Api.Application.Queries.Corrections;
using WebAPICHATest.Api.Application.Queries.EquipmentMaterials;
using WebAPICHATest.Api.Application.Queries.Equipments;
using WebAPICHATest.Api.Application.Queries.Images;
using WebAPICHATest.Api.Application.Queries.KitTests;
using WebAPICHATest.Api.Application.Queries.MaintenanceRequests;
using WebAPICHATest.Api.Application.Queries.MaintenanceResponses;
using WebAPICHATest.Api.Application.Queries.MaterialHistoryCards;
using WebAPICHATest.Api.Application.Queries.MaterialInfors;
using WebAPICHATest.Api.Application.Queries.MaterialRequests;
using WebAPICHATest.Api.Application.Queries.Materials;
using WebAPICHATest.Api.Application.Queries.MoldInfors;
using WebAPICHATest.Api.Application.Queries.Molds;
using WebAPICHATest.Api.Application.Queries.PerformanceIndexs;
using WebAPICHATest.Api.Application.Queries.Persons;
using WebAPICHATest.Api.Application.Queries.Sounds;
using WebAPICHATest.Api.Application.Queries.Standards;
using WebAPICHATest.Api.Application.Queries.TimeSeriesObjects;
using WebAPICHATest.Api.Application.Queries.WorkingTimes;
using WebAPICHATest.Domain.AggregateModels.CauseAggregate;
using WebAPICHATest.Domain.AggregateModels.ChartObjAggregate;
using WebAPICHATest.Domain.AggregateModels.CorrectionAggregate;
using WebAPICHATest.Domain.AggregateModels.EquipmentMaterialAggregate;
using WebAPICHATest.Domain.AggregateModels.ImageAggregate;
using WebAPICHATest.Domain.AggregateModels.KitTestAggregate;
using WebAPICHATest.Domain.AggregateModels.MaintenanceRequestAggregate;
using WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate;
using WebAPICHATest.Domain.AggregateModels.MaterialAggregate;
using WebAPICHATest.Domain.AggregateModels.MaterialHistoryCardAggregate;
using WebAPICHATest.Domain.AggregateModels.MaterialInforAggregate;
using WebAPICHATest.Domain.AggregateModels.MaterialRequestAggregate;
using WebAPICHATest.Domain.AggregateModels.MoldAggregate;
using WebAPICHATest.Domain.AggregateModels.MoldInforAggregate;
using WebAPICHATest.Domain.AggregateModels.PerformanceIndexAggregate;
using WebAPICHATest.Domain.AggregateModels.PersonAggregate;
using WebAPICHATest.Domain.AggregateModels.SoundAggregate;
using WebAPICHATest.Domain.AggregateModels.StandardAggregate;
using WebAPICHATest.Domain.AggregateModels.TimeSeriesObjectAggregate;
using WebAPICHATest.Domain.AggregateModels.WorkingTimeAggregate;

namespace WebAPICHATest.Api.Application.Mapping
{
    public class ModelToViewModelProfile : Profile
    {
        public ModelToViewModelProfile() 
        {
            MapMaintenanceRequestViewModels();
            MapEquipmentViewModels();
            //MapChartObjViewModels(); 
            MapMaterialInforViewModels();
            MapMaterialRequestViewModels();
            MapMaterialViewModels();
            MapCauseViewModels();
            MapPersonViewModels();
            MapCorrectionViewModels();
            MapMaintenanceResponseViewModels();
            MapImageViewModels();
            MapSoundViewModels();
            MapEquipmentMaterialViewModels();
            MapTimeSeriesObjectViewModels();
            MapPerformanceIndexViewModels();
            MapKitTestViewModels();
            MapStandardViewModels();
            MapMoldInforViewModels();
            MapMoldViewModels();
            MapWorkingTimeViewModels();
            MapMaterialHistoryCardViewModels();
        }

        public void MapEquipmentViewModels()
        {
            //CreateMap<QueryResult<Equipment>, QueryResult<EquipmentViewModel>>();
            //CreateMap<Equipment, EquipmentViewModel>();
            CreateMap<EquipmentGetModel, EquipmentViewModel> ();
            CreateMap<QueryResult<EquipmentGetModel>, QueryResult<EquipmentViewModel>>();
        }

        public void MapMaintenanceRequestViewModels()
        {
            CreateMap<QueryResult<MaintenanceRequestGetViewModel>, QueryResult<MaintenanceRequestViewModel>>();
            CreateMap<MaintenanceRequestGetViewModel, MaintenanceRequestViewModel>();
        }

        //public void MapChartObjViewModels()
        //{
        //    CreateMap<QueryResult<ChartObj>, QueryResult<ChartObjViewModel>>();
        //    CreateMap<ChartObj, ChartObjViewModel>();
        //}

        public void MapMaterialInforViewModels()
        {
            CreateMap<QueryResult<MaterialInforGetViewModel>, QueryResult<MaterialInforViewModel>>();
            CreateMap<MaterialInforGetViewModel, MaterialInforViewModel>();
        }

        public void MapMaterialRequestViewModels()
        {
            CreateMap<QueryResult<MaterialRequestGetViewModel>, QueryResult<MaterialRequestViewModel>>();
            CreateMap<MaterialRequestGetViewModel, MaterialRequestViewModel>();
        }

        public void MapMaterialViewModels()
        {
            CreateMap<QueryResult<Material>, QueryResult<MaterialViewModel>>();
            CreateMap<Material, MaterialViewModel>();
        }

        public void MapCauseViewModels()
        {
            //CreateMap<QueryResult<Cause>, QueryResult<CauseViewModel>>();
            //CreateMap<Cause, CauseViewModel>();
            CreateMap<CauseGetViewModel, CauseViewModel>();
            CreateMap<QueryResult<CauseGetViewModel>, QueryResult<CauseViewModel>>();
        }

        public void MapPersonViewModels()
        {
            //CreateMap<QueryResult<Person>, QueryResult<PersonViewModel>>();
            //CreateMap<Person, PersonViewModel>();
            CreateMap<QueryResult<PersonGetViewModel>, QueryResult<PersonViewModel>>();
            CreateMap<PersonGetViewModel, PersonViewModel>();
        }

        public void MapCorrectionViewModels()
        {
            //CreateMap<QueryResult<Correction>, QueryResult<CorrectionViewModel>>();
            //CreateMap<Correction, CorrectionViewModel>();
            CreateMap<QueryResult<CorrectionGetViewModel>, QueryResult<CorrectionViewModel>>();
            CreateMap<CorrectionGetViewModel, CorrectionViewModel>();
        }

        public void MapMaintenanceResponseViewModels()
        {
            //CreateMap<QueryResult<MaintenanceResponse>, QueryResult<MaintenanceResponseViewModel>>();
            //CreateMap<MaintenanceResponse, MaintenanceResponseViewModel>();
            CreateMap<MaintenanceResponseGetViewModel, MaintenanceResponseViewModel>();
            CreateMap<QueryResult<MaintenanceResponseGetViewModel>, QueryResult<MaintenanceResponseViewModel>>();
        }

        public void MapImageViewModels()
        {
            CreateMap<QueryResult<Image>, QueryResult<ImageViewModel>>();
            CreateMap<Image, ImageViewModel>();
        }

        public void MapSoundViewModels()
        {
            CreateMap<QueryResult<Sound>, QueryResult<SoundViewModel>>();
            CreateMap<Sound, SoundViewModel>();
        }

        public void MapEquipmentMaterialViewModels()
        {
            CreateMap<QueryResult<EquipmentMaterial>, QueryResult<EquipmentMaterialViewModel>>();
            CreateMap<EquipmentMaterial, EquipmentMaterialViewModel>();
        }

        public void MapTimeSeriesObjectViewModels()
        {
            CreateMap<QueryResult<TimeSeriesObject>, QueryResult<TimeSeriesObjectViewModel>>();
            CreateMap<TimeSeriesObject, TimeSeriesObjectViewModel>();
        }

        public void MapPerformanceIndexViewModels()
        {
            CreateMap<QueryResult<PerformanceIndex>, QueryResult<PerformanceIndexViewModel>>();
            CreateMap<PerformanceIndex, PerformanceIndexViewModel>();
        }

        public void MapKitTestViewModels()
        {
            CreateMap<QueryResult<KitTest>, QueryResult<KitTestViewModel>>();
            CreateMap<KitTest, KitTestViewModel>();
        }

        public void MapStandardViewModels()
        {
            CreateMap<QueryResult<Standard>, QueryResult<StandardViewModel>>();
            CreateMap<Standard, StandardViewModel>();
        }

        public void MapMoldInforViewModels()
        {
            CreateMap<QueryResult<MoldInforGetViewModel>, QueryResult<MoldInforViewModel>>();
            CreateMap<MoldInforGetViewModel, MoldInforViewModel>();
        }

        public void MapMoldViewModels()
        {
            CreateMap<QueryResult<MoldGetModel>, QueryResult<MoldViewModel>>();
            CreateMap<MoldGetModel, MoldViewModel>();
        }

        public void MapWorkingTimeViewModels()
        {
            CreateMap<QueryResult<WorkingTime>, QueryResult<WorkingTimeViewModel>>();
            CreateMap<WorkingTime, WorkingTimeViewModel>();
        }

        public void MapMaterialHistoryCardViewModels()
        {
            CreateMap<QueryResult<MaterialHistoryCard>, QueryResult<MaterialHistoryCardViewModel>>();
            CreateMap<MaterialHistoryCard, MaterialHistoryCardViewModel>();
        }
    }
}