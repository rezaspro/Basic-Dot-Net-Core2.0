using BasicDotNetCore.Models;
using BasicDotNetCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicDotNetCore.Services
{
    public class Service<EntityT> : IService<EntityT>
    {
        private readonly IRepository<EntityT, long> _repository;
        protected readonly List<string> _defaultIncludeRelations = new List<string>();
        public Service(IRepository<EntityT, long> repository, List<string> defaultIncludeRelations = null)
        {
            _repository = repository;
            _repository.DefaultIncludedRelationalProperties = defaultIncludeRelations;
        }

        public virtual EntityT Get(long id)
        {
            return _repository.Get(id, _defaultIncludeRelations);
        }

        public virtual EntityT Save(EntityT entity)
        {
            using (var txn = _repository.BeginTransaction())
            {
                try
                {
                    _repository.Add(entity);
                    _repository.SaveChange();
                    txn.Commit();
                }
                catch (Exception ex)
                {
                    txn.Rollback();
                    throw ex;
                }
            }
            return entity;
        }


        public virtual EntityT Update(EntityT entity)
        {
            var model = (IBaseModel<long>)entity;
            var oldEntity = _repository.Get(model.Id);
                if (oldEntity != null)
                {
                    using (var txn = _repository.BeginTransaction())
                    {
                        try
                        {
                            //CopyNewData(entity, oldEntity);
                            _repository.Edit(oldEntity);
                            _repository.SaveChange();
                            txn.Commit();
                        }
                        catch (Exception ex)
                        {
                            txn.Rollback();
                            //Logger.LogError(ex.Message, ex);
                            throw ex;
                        }
                    }
                   
                    entity = oldEntity;
                }
                else
                {
                    //throw new InvalidEntityDataException("Null Entity.");
                }
            return entity;
        }

        public List<EntityT> Load(string name, List<string> includeRelationalProperties = null, bool withDeleted = false)
        {
            return _repository.Load(name, includeRelationalProperties, withDeleted);
        }

    }
}
