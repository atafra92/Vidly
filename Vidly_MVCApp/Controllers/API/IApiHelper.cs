using System.Collections.Generic;
using Vidly_MVCApp.Models;

namespace Vidly_MVCApp.Controllers.API
{
    public interface IApiHelper<T> where T : class
    {
        T GetEntity(int id);
        IEnumerable<T> GetEntities(string query);
        void SaveEntity(T entityDto);
        void UpdateEntity(int id, T entityDto);
        void DeleteEntity(int id);
    }
}