using BookLibrary.Domain.Entities;
using BookLibrary.Models;
using System;
using System.Collections.Generic;

namespace BookLibrary.Domain.Repositories.Abstract
{
    public interface ISpeaker
    {
        public List<speaker> getAll();
        public speaker getId(Guid id);
        public speaker add(speaker _speaker);
        public speaker update(Guid id, SpeakerModel _speaker);
        public speaker delete(Guid id);
    }
}
