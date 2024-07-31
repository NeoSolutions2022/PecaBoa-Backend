using PecaBoa.Domain.Entities;

namespace PecaBoa.Domain.Contracts.Repositories;

public interface ILojistaCartaoDeCreditoRepository : IRepository<LojistaCartaoDeCredito>
{
    Task<LojistaCartaoDeCredito?> GetById(int id);
    Task<List<LojistaCartaoDeCredito>> GetAll();
    void Create(LojistaCartaoDeCredito lojistaCartaoDeCredito);
    void Update(LojistaCartaoDeCredito lojistaCartaoDeCredito);
    void Remove(LojistaCartaoDeCredito lojistaCartaoDeCredito);
}