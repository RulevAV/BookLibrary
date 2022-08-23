using BookLibrary.Domain.Entities;
using BookLibrary.Models;
using System;
using System.Collections.Generic;

namespace BookLibrary.Domain.Repositories.Abstract
{
    public interface IMeeting
    {
        public List<meeting> getAll();
        public meeting getId(Guid id);
        public meeting add(MeetingModel _meeting);
        public meeting update(Guid id, meeting _meeting);
        public meeting delete(Guid id);
    }
}
