using BookLibrary.Domain.Entities;
using BookLibrary.Domain.Repositories.Abstract;
using BookLibrary.Models;
using ICSSoft.STORMNET;
using ICSSoft.STORMNET.Business;
using ICSSoft.STORMNET.Business.LINQProvider;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookLibrary.Domain.Repositories.FlexberryMethod
{
    public class Book : IBook
    {
        SQLDataService ds = (SQLDataService)DataServiceProvider.DataService;

        public List<book> getAll()
        {
            return ds.Query<book>(book.Views.bookL).ToList();
        }

        public book getId(Guid id)
        {
            book _book = new book();
            _book.SetExistObjectPrimaryKey(id);
            ds.LoadObject(_book);
            return _book;
        }

        public book add(book _book, Guid id)
        {
            _book.tags = null;

            user _user = new user();
            _user.SetExistObjectPrimaryKey(id);
            ds.LoadObject(_user);

            //var _user = new user();
            _user.books.Add(_book);

            var p = new DataObject[] { _book, _user };

            ds.UpdateObjects(ref p);//Добавить Объект

            return _book;
        }

        public book update(Guid id, BookModel _book)
        {
            book book = new book();
            book.SetExistObjectPrimaryKey(id);
            ds.LoadObject(book);

            book.name = _book.name;
            book.author = _book.author;
            book.suauthormPages = _book.suauthormPages;
            book.tags = _book.tags;
            book.averageRating = _book.averageRating;
            book.URLcover = _book.URLcover;
            book.URLDescription = _book.URLDescription;
            
            book.SetStatus(ObjectStatus.Altered);
            ds.UpdateObject(book);//Добавить Объект

            return book;
        }
        public book delete(Guid id)
        {
            book book = new book();
            book.SetExistObjectPrimaryKey(id);
            ds.LoadObject(book);

            book.SetStatus(ObjectStatus.Deleted);
            ds.UpdateObject(book);

            return book;
        }
    }
}
