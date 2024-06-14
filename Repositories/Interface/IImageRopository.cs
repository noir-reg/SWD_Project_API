using BusinessObjects.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interface
{
    public  interface IImageRopository
    {
        IEnumerable<ImageResponse> GetImageByProductId(int id);
        public bool CreateImage(CreateImageRequest createImageRequest);
        public bool UpdateImage(UpdateImageRequest updateImageRequest);
        public bool DeleteImage(int id);
    }
}
