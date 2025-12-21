namespace Internship_7_Moodle.Domain.Common.Model;

public class GetAllResponse<TEntity>
{
    public IEnumerable<TEntity> Entities { get; init; }

    public GetAllResponse()
    {
        Entities = Enumerable.Empty<TEntity>();
    }
    
    public GetAllResponse(IEnumerable<TEntity> entities)
    {
        Entities = entities;
    }
}