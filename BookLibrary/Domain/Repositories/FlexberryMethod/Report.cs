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
    public class Report : IReport
    {
        SQLDataService ds = (SQLDataService)DataServiceProvider.DataService;

        public List<report> getAll()
        {
            return ds.Query<report>(report.Views.reportL).ToList();
        }

        public report getId(Guid id)
        {
            report _report = new report();
            _report.SetExistObjectPrimaryKey(id);
            ds.LoadObject(_report);
            return _report;
        }

        public report add(report _report)
        {
            ds.UpdateObject(_report);//Добавить Объект
            return _report;
        }

        public report update(Guid id, report _report)
        {
            report report = new report();
            report.SetExistObjectPrimaryKey(id);
            ds.LoadObject(report);
            report.SetProperties(_report);
            report.SetStatus(ObjectStatus.Altered);
            ds.UpdateObject(report);//Добавить Объект

            return report;
        }
        public report delete(Guid id)
        {
            report report = new report();
            report.SetExistObjectPrimaryKey(id);
            ds.LoadObject(report);

            report.SetStatus(ObjectStatus.Deleted);
            ds.UpdateObject(report);

            return report;
        }
    }
}
