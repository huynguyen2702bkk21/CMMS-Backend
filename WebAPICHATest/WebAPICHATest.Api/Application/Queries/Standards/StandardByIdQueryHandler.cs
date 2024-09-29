using Azure;
using WebAPICHATest.Api.Application.Queries.Standards;
using WebAPICHATest.Domain.AggregateModels.StandardAggregate;
using WebAPICHATest.Infrastructure;

namespace WebAPICHATest.Api.Application.Queries.Standards
{
    public class StandardByIdQueryHandler : IRequestHandler<StandardByIdQuery, QueryResult<StandardViewModel>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public StandardByIdQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<QueryResult<StandardViewModel>> Handle(StandardByIdQuery request, CancellationToken cancellationToken)
        {
            var queryable = _context.Standards
                .AsNoTracking();

            if (request.StandardId is not null)
            {
                queryable = queryable.Where(x => x.StandardId == request.StandardId);
            }

            int totalItems = await queryable.CountAsync();

            queryable = queryable
                .OrderBy(x => x.StandardId)
                .Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize);

            var requests = await queryable.ToListAsync();
            var listGetViewModel = new List<StandardGetViewModel>();
            foreach (Standard standard in requests)
            {
                var newGetViewModel = new StandardGetViewModel(standard.StandardId);
                newGetViewModel.KitTest = standard.KitTest;
                newGetViewModel.Measurements = standard.Measurements;
                List<string>? listImageString = null;
                if (string.IsNullOrEmpty(standard.Images) == false)
                {
                    listImageString = standard.Images.Split("|").ToList();
                    listImageString.RemoveAt(listImageString.Count - 1);
                }
                newGetViewModel.Images = listImageString;

                listGetViewModel.Add(newGetViewModel);
            }
            var queryResult = new QueryResult<StandardGetViewModel>(listGetViewModel, totalItems);

            return _mapper.Map<QueryResult<StandardGetViewModel>, QueryResult<StandardViewModel>>(queryResult);
        }
    }
}
