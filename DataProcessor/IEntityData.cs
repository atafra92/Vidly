using DataProcessor.Models;
using System.Collections.Generic;

namespace DataProcessor
{
    public interface IEntityData<T,U> where T : class where U : class
    {
        IEnumerable<T> GetAll();
        T GetById(int? id);
        void CreateNew(T entity);
        T EditById(int? id);
        void SaveEditsMVC(T entity);
        List<U> GetNavProperty();
        void SaveEditsAPI();
        void DeleteEntity(T entity);
    }
}