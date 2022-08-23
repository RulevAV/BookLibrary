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
    public class Speaker : ISpeaker
    {
        SQLDataService ds = (SQLDataService)DataServiceProvider.DataService;

        public List<speaker> getAll()
        {
            return ds.Query<speaker>(speaker.Views.speakerL).ToList();
        }

        public speaker getId(Guid id)
        {
            speaker _speaker = new speaker();
            _speaker.SetExistObjectPrimaryKey(id);
            ds.LoadObject(_speaker);
            return _speaker;
        }

        public speaker add(speaker _speaker)
        {
            ds.UpdateObject(_speaker);//Добавить Объект
            return _speaker;
        }

        public speaker update(Guid id, SpeakerModel _speaker)
        {
            speaker Speaker = new speaker();
            Speaker.SetExistObjectPrimaryKey(id);
            ds.LoadObject(Speaker);

            Speaker.firstName = _speaker.firstName;
            Speaker.lastName = _speaker.lastName;
            Speaker.patronymic = _speaker.patronymic;

            Speaker.SetStatus(ObjectStatus.Altered);
            ds.UpdateObject(Speaker);//Добавить Объект

            return Speaker;
        }
        public speaker delete(Guid id)
        {
            speaker Speaker = new speaker();
            Speaker.SetExistObjectPrimaryKey(id);
            ds.LoadObject(Speaker);

            Speaker.SetStatus(ObjectStatus.Deleted);
            ds.UpdateObject(Speaker);

            return Speaker;
        }
    }
}
