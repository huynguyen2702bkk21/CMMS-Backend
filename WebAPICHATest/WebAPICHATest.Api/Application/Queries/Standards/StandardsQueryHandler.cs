using Azure;
using WebAPICHATest.Api.Application.Queries.Standards;
using WebAPICHATest.Domain.AggregateModels.StandardAggregate;
using WebAPICHATest.Infrastructure;

namespace WebAPICHATest.Api.Application.Queries.Standards
{
    public class StandardsQueryHandler : IRequestHandler<StandardsQuery, List<StandardViewModel>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public StandardsQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<StandardViewModel>> Handle(StandardsQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Standards.AsNoTracking().ToListAsync();

            var listGetViewModel = new List<StandardGetViewModel>();
            foreach (Standard standard in result)
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

            return _mapper.Map<List<StandardGetViewModel>, List<StandardViewModel>>(listGetViewModel);
        }
    }
}
