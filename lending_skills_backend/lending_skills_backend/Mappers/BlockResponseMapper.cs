using lending_skills_backend.Dtos.Responses;
using lending_skills_backend.Models;

namespace lending_skills_backend.Mappers
{
    public class BlockResponseMapper
    {
        public static BlockResponse Map(DbBlock block)
        {
            if (block == null) return null;

            return new BlockResponse
            {
                Id = block.Id,
                Data = block.Date, // Date в модели -> Data в DTO
                IsExample = block.IsExample,
                Type = block.Type,
                NextBlockId = block.NextBlockId,
                PreviousBlockId = block.PreviousBlockId,
                Form = block.Form != null ? FormResponseMapper.Map(block.Form) : null
            };
        }
    }
}
