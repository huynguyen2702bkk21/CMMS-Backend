using Azure;
using WebAPICHATest.Api.Application.Queries.MaterialRequests;
using WebAPICHATest.Api.Application.Queries.MoldInfors;
using WebAPICHATest.Domain.AggregateModels.MaterialRequestAggregate;
using WebAPICHATest.Domain.AggregateModels.MoldInforAggregate;
using WebAPICHATest.Infrastructure;
using static WebAPICHATest.Domain.AggregateModels.MaterialRequestAggregate.MaterialRequest;

namespace WebAPICHATest.Api.Application.Queries.MoldInfors
{
    public class MoldInforsQueryHandler : IRequestHandler<MoldInforsQuery, List<MoldInforViewModel>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MoldInforsQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<MoldInforViewModel>> Handle(MoldInforsQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.MoldInfors.AsNoTracking().ToListAsync();

            var listGetViewModel = new List<MoldInforGetViewModel>();
            foreach (MoldInfor moldInfor in result)
            {
                var newGetViewModel = new MoldInforGetViewModel(moldInfor.MoldInforId);
                newGetViewModel.Cavity = moldInfor.Cavity;
                newGetViewModel.DocumentLink = moldInfor.DocumentLink;
                List<string>? listImageString = null;
                if (string.IsNullOrEmpty(moldInfor.Images) == false)
                {
                    listImageString = moldInfor.Images.Split("|").ToList();
                    listImageString.RemoveAt(listImageString.Count - 1);
                }
                newGetViewModel.Images = listImageString;

                listGetViewModel.Add(newGetViewModel);
            }

            return _mapper.Map<List<MoldInforGetViewModel>, List<MoldInforViewModel>>(listGetViewModel);
        }
    }
}
