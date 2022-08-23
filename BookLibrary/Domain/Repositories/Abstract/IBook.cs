using BookLibrary.Domain.Entities;
using BookLibrary.Models;
using System;
using System.Collections.Generic;

namespace BookLibrary.Domain.Repositories.Abstract
{
    public interface IBook
    {
        public List<book> getAll();
        public book getId(Guid id);
        public book add(book _book, Guid id);
        public book update(Guid id, BookModel _book);
        public book delete(Guid id);
    }
}
