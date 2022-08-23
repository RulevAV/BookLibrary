using BookLibrary.Domain.Entities;
using System;

namespace BookLibrary.Models
{
    public class MeetingModel
    {
        public DateTime dateMeeting { get; set; }

        public string[] reports { get; set; }

    }
}
