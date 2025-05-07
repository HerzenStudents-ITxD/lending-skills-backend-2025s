using lending_skills_backend.Dtos.Requests;
using lending_skills_backend.Models;

namespace lending_skills_backend.Mappers
{
    public class UpdateDbBlockMapper
    {
        public static void Map(DbBlock block, EditBlockRequest request)
        {
            block.Date = request.Data;
            block.IsExample = request.IsExample;
            block.Type = request.Type;
        }
    }
}
