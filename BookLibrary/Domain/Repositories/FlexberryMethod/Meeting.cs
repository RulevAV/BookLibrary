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
    public class Meeting : IMeeting
    {
        SQLDataService ds = (SQLDataService)DataServiceProvider.DataService;

        public List<meeting> getAll()
        {
            return ds.Query<meeting>(meeting.Views.meetingL).ToList();
        }

        public meeting getId(Guid id)
        {
            meeting _meeting = new meeting();
            _meeting.SetExistObjectPrimaryKey(id);
            ds.LoadObject(_meeting);
            return _meeting;
        }

        public meeting add(MeetingModel newMeeting)
        {
            var _meeting = new meeting();
            _meeting.dateMeeting = newMeeting.dateMeeting;

            ds.UpdateObject(_meeting);//Добавить Объект
            return _meeting;
        }

        public meeting update(Guid id, meeting _meeting)
        {
            meeting meeting = new meeting();
            meeting.SetExistObjectPrimaryKey(id);
            ds.LoadObject(meeting);
            meeting.SetProperties(_meeting);
            meeting.SetStatus(ObjectStatus.Altered);
            ds.UpdateObject(meeting);//Добавить Объект

            return meeting;
        }
        public meeting delete(Guid id)
        {
            meeting meeting = new meeting();
            meeting.SetExistObjectPrimaryKey(id);
            ds.LoadObject(meeting);

            meeting.SetStatus(ObjectStatus.Deleted);
            ds.UpdateObject(meeting);

            return meeting;
        }
    }
}
