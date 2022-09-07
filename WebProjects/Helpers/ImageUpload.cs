namespace WebProjects.Models.Helpers;

public class ImageUpload
{
    public static async Task<string> UploadImage(string folderPath, IFormFile file)
    {
        
        if (Directory.Exists(folderPath) == false)
        {
            Directory.CreateDirectory(folderPath);
        }

        string filePath = $"{folderPath}/{file?.FileName}";

        await using (var stream = System.IO.File.Create(filePath))
        {
            await file?.CopyToAsync(stream)!;
        }

        return filePath;
    }
}