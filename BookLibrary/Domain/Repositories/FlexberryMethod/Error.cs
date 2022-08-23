using BookLibrary.Domain.Entities;
using BookLibrary.Domain.Repositories.Abstract;
using ICSSoft.STORMNET;
using ICSSoft.STORMNET.Business;
using ICSSoft.STORMNET.Business.LINQProvider;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookLibrary.Domain.Repositories.FlexberryMethod
{
    public class Error : IError
    {
        SQLDataService ds = (SQLDataService)DataServiceProvider.DataService;
        public List<error> getAll()
        {
            return ds.Query<error>(error.Views.errorL).ToList();
        }

        public error getId(Guid id)
        {
            error _error = new error();
            _error.SetExistObjectPrimaryKey(id);
            ds.LoadObject(_error);
            return _error;
        }

        public error add(error _error)
        {
            ds.UpdateObject(_error);//Добавить Объект
            return _error;
        }

        public error update(Guid id, error _error)
        {
            error error = new error();
            error.SetExistObjectPrimaryKey(id);
            ds.LoadObject(error);
            error.SetProperties(_error);
            error.SetStatus(ObjectStatus.Altered);
            ds.UpdateObject(error);//Добавить Объект

            return error;
        }
        public error delete(Guid id)
        {
            error error = new error();
            error.SetExistObjectPrimaryKey(id);
            ds.LoadObject(error);

            error.SetStatus(ObjectStatus.Deleted);
            ds.UpdateObject(error);

            return error;
        }
    }
}
