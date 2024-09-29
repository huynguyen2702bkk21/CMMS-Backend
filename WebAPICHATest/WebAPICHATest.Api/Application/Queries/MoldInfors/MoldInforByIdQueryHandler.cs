using Azure;
using WebAPICHATest.Api.Application.Queries.MoldInfors;
using WebAPICHATest.Domain.AggregateModels.MoldInforAggregate;
using WebAPICHATest.Infrastructure;

namespace WebAPICHATest.Api.Application.Queries.MoldInfors
{
    public class MoldInforByIdQueryHandler : IRequestHandler<MoldInforByIdQuery, QueryResult<MoldInforViewModel>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MoldInforByIdQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<QueryResult<MoldInforViewModel>> Handle(MoldInforByIdQuery request, CancellationToken cancellationToken)
        {
            var queryable = _context.MoldInfors
                .AsNoTracking();

            if (request.MoldInforId is not null)
            {
                queryable = queryable.Where(x => x.MoldInforId == request.MoldInforId);
            }

            int totalItems = await queryable.CountAsync();

            queryable = queryable
                .OrderBy(x => x.MoldInforId)
                .Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize);

            var requests = await queryable.ToListAsync();
            var listGetViewModel = new List<MoldInforGetViewModel>();
            foreach (MoldInfor moldInfor in requests)
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

            var queryResult = new QueryResult<MoldInforGetViewModel>(listGetViewModel, totalItems);

            return _mapper.Map<QueryResult<MoldInforGetViewModel>, QueryResult<MoldInforViewModel>>(queryResult);
        }
    }
}
