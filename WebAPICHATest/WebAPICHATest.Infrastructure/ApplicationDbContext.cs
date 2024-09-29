using Microsoft.EntityFrameworkCore.Storage;
using WebAPICHATest.Domain.SeedWork;
using System;
using WebAPICHATest.Infrastructure.EntityConfigurations;
using WebAPICHATest.Domain.AggregateModels.MaintenanceRequestAggregate;
using WebAPICHATest.Domain.AggregateModels.PersonAggregate;
using WebAPICHATest.Domain.AggregateModels.ChartObjAggregate;
using WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate;
using WebAPICHATest.Domain.AggregateModels.MaterialInforAggregate;
using WebAPICHATest.Infrastructure.EntityConfigurations.MaintenanceRequests;
using WebAPICHATest.Infrastructure.EntityConfigurations.MaterialInfors;
using WebAPICHATest.Domain.AggregateModels.MaterialRequestAggregate;
using WebAPICHATest.Infrastructure.EntityConfigurations.MaterialRequests;
using WebAPICHATest.Domain.AggregateModels.MaterialAggregate;
using WebAPICHATest.Infrastructure.EntityConfigurations.Materials;
using WebAPICHATest.Domain.AggregateModels.CauseAggregate;
using WebAPICHATest.Infrastructure.EntityConfigurations.Persons;
using WebAPICHATest.Infrastructure.EntityConfigurations.MaintenanceResponses;
using WebAPICHATest.Domain.AggregateModels.CorrectionAggregate;
using WebAPICHATest.Infrastructure.EntityConfigurations.Corrections;
using WebAPICHATest.Infrastructure.EntityConfigurations.StringProperties;
using WebAPICHATest.Domain.AggregateModels.ImageAggregate;
using WebAPICHATest.Domain.AggregateModels.SoundAggregate;
using WebAPICHATest.Infrastructure.EntityConfigurations.Sounds;
using WebAPICHATest.Domain.AggregateModels.EquipmentMaterialAggregate;
using WebAPICHATest.Infrastructure.EntityConfigurations.EquipmentMaterials;
using WebAPICHATest.Domain.AggregateModels.TimeSeriesObjectAggregate;
using WebAPICHATest.Infrastructure.EntityConfigurations.TimeSeriesObjects;
using WebAPICHATest.Domain.AggregateModels.PerformanceIndexAggregate;
using WebAPICHATest.Infrastructure.EntityConfigurations.PerformanceIndexs;
using WebAPICHATest.Infrastructure.EntityConfigurations.Equipments;
using WebAPICHATest.Infrastructure.EntityConfigurations.Causes;
using WebAPICHATest.Domain.AggregateModels.KitTestAggregate;
using WebAPICHATest.Infrastructure.EntityConfigurations.KitTests;
using WebAPICHATest.Domain.AggregateModels.StandardAggregate;
using WebAPICHATest.Infrastructure.EntityConfigurations.Standards;
using WebAPICHATest.Domain.AggregateModels.MoldInforAggregate;
using WebAPICHATest.Infrastructure.EntityConfigurations.MoldInfors;
using WebAPICHATest.Domain.AggregateModels.ProductAggregate;
using WebAPICHATest.Infrastructure.EntityConfigurations.Products;
using WebAPICHATest.Domain.AggregateModels.MoldAggregate;
using WebAPICHATest.Infrastructure.EntityConfigurations.Molds;
using WebAPICHATest.Domain.AggregateModels.WorkingTimeAggregate;
using WebAPICHATest.Infrastructure.EntityConfigurations.WorkingTimes;
using WebAPICHATest.Domain.AggregateModels.EquipmentAggregate;
using WebAPICHATest.Domain.AggregateModels.MaterialHistoryCardAggregate;
using WebAPICHATest.Infrastructure.EntityConfigurations.MaterialHistoryCards;
using WebAPICHATest.Domain.AggregateModels.InspectionReportAggregate;
using WebAPICHATest.Infrastructure.EntityConfigurations.InspectionReports;
using WebAPICHATest.Domain.AggregateModels.InputAggregate;
using WebAPICHATest.Infrastructure.EntityConfigurations.InputTabuSearchs;
//using WebAPICHATest.Infrastructure.EntityConfigurations.ChartObjs;

namespace WebAPICHATest.Infrastructure
{
    public class ApplicationDbContext : DbContext, IUnitOfWork
    {
        public const string DEFAULT_SCHEMA = "application";

        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<MaintenanceRequest> MaintenanceRequests { get; set; }
        public DbSet<Person> Persons { get; set; }
        //public DbSet<ChartObj> ChartObjs { get; set; }
        public DbSet<MaterialInfor> MaterialInfors { get; set; }
        public DbSet<MaterialRequest> MaterialRequests { get; set; }

        public DbSet<Material> Materials { get; set; }
        public DbSet<Cause> Causes { get; set; }
        public DbSet<Correction> Corrections { get; set; }
        public DbSet<MaintenanceResponse> MaintenanceResponses { get; set; }

        public DbSet<Image> Images { get; set; }
        public DbSet<Sound> Sounds { get; set; }
        public DbSet<EquipmentMaterial> EquipmentMaterials { get; set; }
        public DbSet<TimeSeriesObject> TimeSeriesObjects { get; set; }
        public DbSet<PerformanceIndex> PerformanceIndexs { get; set; }
        public DbSet<KitTest> KitTests { get; set; }
        public DbSet<Standard> Standards { get; set; }
        public DbSet<MoldInfor> MoldInfors { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Mold> Molds { get; set; }
        public DbSet<WorkingTime> WorkingTimes { get; set; }
        public DbSet<MaterialHistoryCard> MaterialHistoryCards { get; set; }
        public DbSet<InspectionReport> InspectionReports { get; set; }
        public DbSet<InputTabuSearch> InputTabuSearchs { get; set; }

        private IDbContextTransaction? _currentTransaction;
        private readonly IMediator _mediator;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public IDbContextTransaction? GetCurrentTransaction() => _currentTransaction;
        public bool HasActiveTransaction => _currentTransaction != null;

        public ApplicationDbContext(DbContextOptions options, IMediator mediator) : base(options)
        {
            _mediator = mediator;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MaintenanceRequestEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MaterialInforEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MaterialRequestEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MaterialEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CauseEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PersonEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MaintenanceResponseEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CorrectionEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ImagesEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SoundsEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new EquipmentMaterialEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TimeSeriesObjectsEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PerformanceIndexEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new EquipmentEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new KitTestEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new StandardEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MoldInforEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ProductEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MoldEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new WorkingTimeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MaterialHistoryCardEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new InspectionReportEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new InputTabuSearchsEntityTypeConfiguration());
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            await _mediator.DispatchDomainEventsAsync(this);
            await base.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<IDbContextTransaction?> BeginTransactionAsync()
        {
            if (_currentTransaction != null) return null;

            _currentTransaction = await Database.BeginTransactionAsync();

            return _currentTransaction;
        }

        public async Task CommitTransactionAsync(IDbContextTransaction transaction)
        {
            if (transaction == null) throw new ArgumentNullException(nameof(transaction));
            if (transaction != _currentTransaction) throw new InvalidOperationException($"Transaction {transaction.TransactionId} is not current");

            try
            {
                await SaveChangesAsync();
                transaction.Commit();
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                _currentTransaction?.Rollback();
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }
    }
}