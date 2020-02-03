using Microsoft.AspNetCore.Http;

namespace Domain.Recipes.Services
{
	public interface IImageUploader
	{
		string Upload(IFormFile file, string key, string name);
	}
}