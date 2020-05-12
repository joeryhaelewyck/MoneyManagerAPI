using MoneyManagerApi.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManagerApi.Models
{
    public interface ICostRepository
    {
        Cost getById(int id);
        Cost getByName(string name);
        IEnumerable<Cost> getByType(string type);
        IEnumerable<Cost> getAll();
        void Add(Cost cost);
        void Delete(Cost cost);
        Cost UpdateAmount(Cost cost, CostPatchDTO costPatchDTO);
        void SaveChanges();
    }
}
