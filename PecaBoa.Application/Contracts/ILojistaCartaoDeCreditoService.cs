using PecaBoa.Application.Dtos.V1.Lojista.LojistaCartoesDeCredito;

namespace PecaBoa.Application.Contracts;

public interface ILojistaCartaoDeCreditoService
{
    Task<List<LojistaCartaoDeCreditoDto>> GetAll();
    Task<LojistaCartaoDeCreditoDto?> GetById(int id);
    Task<LojistaCartaoDeCreditoDto?> Create(CreateLojistaCartaoDeCreditoDto dto);
    Task<LojistaCartaoDeCreditoDto?> Update(int id, UpdateLojistaCartaoDeCreditoDto dto);
    Task Remove(int id);
}