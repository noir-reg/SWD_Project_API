using BusinessObjects.DTOs;
using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Repositories.Implementation
{
    public class ImageRopository : IImageRopository
    {
       private readonly MilkShopContext _context = new();
        public bool CreateImage(CreateImageRequest createImageRequest)
        {
            try
            {
                var image = new Image
                {
                    ProductId = createImageRequest.ProductId,
                    Url = createImageRequest.Url
                };

                _context.Images.Add(image);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                // Handle exceptions, log errors, or return appropriate response
                return false;
            }
        }
        public bool UpdateImage(UpdateImageRequest updateImageRequest)
        {
            var image = _context.Images.FirstOrDefault(x => x.Id == updateImageRequest.Id);
            if (image == null)
                return false;
            image.Id = updateImageRequest.Id;
            image.ProductId = updateImageRequest.ProductId;
            image.Url = updateImageRequest.Url;

            _context.SaveChanges();
            return true;
        }
        public bool DeleteImage(int id)
        {
            var image = _context.Images.FirstOrDefault(x => x.Id == id);
            if (image == null)
                return false;

            _context.Images.Remove(image);
            _context.SaveChanges();
            return true;
        }
        public IEnumerable<ImageResponse> GetImageByProductId(int id)
        {
            return _context.Images
                .Where(x => x.ProductId == id)
                .Select(p => new ImageResponse
            { 
                Id = p.Id,
                ProductId = p.ProductId,
                Url = p.Url
           }).ToList();
        }
    }
}
