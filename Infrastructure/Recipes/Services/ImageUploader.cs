using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Domain.Recipes.Services;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Recipes.Services
{
	public class ImageUploader : IImageUploader
	{
		public string Upload(IFormFile file, string key, string name)
		{
			var account = new Account(
				"whatshouldieat",
				"175927673971229",
				"nwnmNeLlie9zT9vrIEKucDNgfTc");

			var cloudinary = new Cloudinary(account);
			
			var uploadParams = new ImageUploadParams
			{
				File = new FileDescription(name, file.OpenReadStream()),
				Folder = "what-should-i-eat/recipe",
				PublicId = $"{name}_{key}",
				Overwrite = true
			};
			var uploadResult = cloudinary.Upload(uploadParams);
			return uploadResult.SecureUri.ToString();
		}
	}
}