using System;
using System.Collections.Generic;
using System.Text;

namespace CB_importData
{
    public interface IFileService<T>
    {
        List<T> Open(string filename);
        void Save(string filename, List<T> objectsList);
        void Validation(string filename);
    }
}
