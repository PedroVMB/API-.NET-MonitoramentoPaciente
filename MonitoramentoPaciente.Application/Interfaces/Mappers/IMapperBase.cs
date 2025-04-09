namespace MonitoramentoPaciente.Application.Mapper;

public interface IMapperBase<TEntity, TEntityDto> where TEntity : class
{
    TEntity MapperDtoToEntity(TEntityDto dto);
    
    IEnumerable<TEntityDto> MapperListTEntityDto(IEnumerable<TEntity> listTEntities);
    
    TEntityDto MapperEntityToDto(TEntity tEntity);
}