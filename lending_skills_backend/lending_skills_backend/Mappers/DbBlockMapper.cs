using lending_skills_backend.Dtos.Requests;
using lending_skills_backend.Models;

namespace lending_skills_backend.Mappers
{
    public class DbBlockMapper
    {
        public static DbBlock Map(AddBlockToPageRequest request)
        {
            return new DbBlock
            {
                Date = request.Data,
                IsExample = request.IsExample,
                Type = request.Type,
                PageId = request.PageId
            };
        }
    }
}
