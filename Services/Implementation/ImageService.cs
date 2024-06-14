using BusinessObjects.DTOs;
using Repositories.Interface;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class ImageService : IImageService
    {
        private readonly IImageRopository _imageRepository;

        public ImageService(IImageRopository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public IEnumerable<ImageResponse> GetImageByProductId(int id)
        {
            // Delegate the operation to ImageRepository
            return _imageRepository.GetImageByProductId(id);
        }

        public bool CreateImage(CreateImageRequest createImageRequest)
        {
            // Delegate the operation to ImageRepository
            return _imageRepository.CreateImage(createImageRequest);
        }

        public bool UpdateImage(UpdateImageRequest updateImageRequest)
        {
            // Delegate the operation to ImageRepository
            return _imageRepository.UpdateImage(updateImageRequest);
        }

        public bool DeleteImage(int id)
        {
            // Delegate the operation to ImageRepository
            return _imageRepository.DeleteImage(id);
        }
    }
}
