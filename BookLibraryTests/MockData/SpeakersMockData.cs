using BookLibrary.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibraryTests.MockData
{
    public class SpeakersMockData
    {
        public static List<speaker> getAll()
        {
            var item = new speaker();
            var data = new List<speaker>();
            data.Add(item);
            data.Add(item);
            data.Add(item);
            return data;
        }
    }
}
