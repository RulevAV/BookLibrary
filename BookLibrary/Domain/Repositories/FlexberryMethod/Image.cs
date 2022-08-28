using BookLibrary.Domain.Entities;
using BookLibrary.Domain.Repositories.Abstract;
using ICSSoft.STORMNET.Business;
using System;

namespace BookLibrary.Domain.Repositories.FlexberryMethod
{
    public class Image:IImage
    {
        SQLDataService ds = (SQLDataService)DataServiceProvider.DataService;

        public image add(image _image)
        {
            ds.UpdateObject(_image);//Добавить Объект
            return _image;
        }

        public image getId(Guid id)
        {
            image _image = new image();
            _image.SetExistObjectPrimaryKey(id);
            ds.LoadObject(_image);
            return _image;
        }
    }
}
