using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagment.Application.contract
{
    public interface IImageService
    {
        public Task<string?> SaveImageAsync(IFormFile image, string Folder);
    }
}
