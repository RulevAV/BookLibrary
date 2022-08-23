using BookLibrary.Domain.Entities;
using System;
using System.Collections.Generic;

namespace BookLibrary.Domain.Repositories.Abstract
{
    public interface IError
    {
        public List<error> getAll();
        public error getId(Guid id);
        public error add(error _error);
        public error update(Guid id, error _error);
        public error delete(Guid id);
    }
}
