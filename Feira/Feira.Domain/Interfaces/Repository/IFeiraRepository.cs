using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Feira.Domain.Interfaces.Repository
{
    public interface IFeiraRepository
    {
        Task<bool> InserirAsync(Feira.Domain.Entities.Feira feira);
        Task<bool> ExcluirAsync(Feira.Domain.Entities.Feira feira);
        Task<Feira.Domain.Entities.Feira> BuscarPorIdAsync(int id);
        Task<bool> AlterarAsync(Feira.Domain.Entities.Feira feira);
        Task<List<Feira.Domain.Entities.Feira>> BuscarFiltroAsync(string distrito, string regiao5, string nomeFeira, string bairro);
    }
}
