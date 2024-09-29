using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.ImageAggregate;
using WebAPICHATest.Domain.AggregateModels.ProductAggregate;

namespace WebAPICHATest.Infrastructure.Repositories
{
    public class ImageRepository : BaseRepository, IImageRepository
    {
        public ImageRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Image Add(Image request)
        {
            if (request.IsTransient())
            {
                return _context.Images
                    .Add(request)
                    .Entity;
            }
            else
            {
                return request;
            }
        }

        public Image Update(Image request)
        {
            return _context.Images
                    .Update(request)
                    .Entity;
        }

        public async Task<Image?> GetById(string requestId)
        {
            return await _context.Images
                .FirstOrDefaultAsync(x => x.ImageId == requestId);
        }

        public async Task<List<Image>> GetListById(List<string> imageIds)
        {
            var images = await _context.Images
            .Where(x => imageIds.Contains(x.ImageId))
            .ToListAsync();

            var notFoundIds = imageIds
            .Where(id => !images.Any(pc => pc.ImageId == id));

            if (notFoundIds.Any())
            {
                throw new Exception("Not all images were found. Personnel class ids: " + string.Join(", ", notFoundIds));
            }

            return images;
        }

        //public async Task<List<Image>> GetListByMoldId(string moldId)
        //{
        //    var responses = await _context.Images
        //    .Where(x => x.SaveMoldId == moldId).ToListAsync();

        //    return responses;
        //}
    }
}
