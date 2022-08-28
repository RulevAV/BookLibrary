using BookLibrary.Domain.Entities;
using System;

namespace BookLibrary.Domain.Repositories.Abstract
{
    public interface IImage
    {
        public image add(image _image);

        public image getId(Guid id);
    }
}
