using BookLibrary.Domain.Entities;
using System;
using System.Collections.Generic;

namespace BookLibrary.Domain.Repositories.Abstract
{
    public interface IReport
    {
        public List<report> getAll();
        public report getId(Guid id);
        public report add(report _report);
        public report update(Guid id, report _report);
        public report delete(Guid id);
    }
}
