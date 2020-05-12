using MoneyManagerApi.DTOs;
using MoneyManagerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManagerApi.Data.Repositories.Contracts
{
    public interface ICostRepository
    {
        Cost getById(int id);
        Cost getByName(string name);
        IEnumerable<Cost> getByType(Frequency type);
        IEnumerable<Cost> getAll();
        void Add(Cost cost);
        void Delete(Cost cost);
        Cost UpdateAmount(Cost cost, CostPatchDTO costPatchDTO);
        void SaveChanges();
    }
}
