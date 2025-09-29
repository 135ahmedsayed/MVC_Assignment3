using Microsoft.AspNetCore.Http;

namespace MVC_Assignment3_BLL.Services;
public class DocumentService : IDocumentService
{
    // Check Extension
    private List<string> _CheckExtension = [".Png" , ".jpeg",".jpg"];
    // Check Size
    private const int _MaxSize = 2_097_152; // 2MBb 
    public async Task<string?> UploadAsync(IFormFile file, string folderName)
    {
        //1- Validation Extension
        var extension = Path.GetExtension(file.FileName); // get the extension
        if(!_CheckExtension.Contains(extension))
            throw new Exception($"Invalid Extension {extension}");
        //2- Validation Size
        if (file.Length > _MaxSize)
            throw new Exception($"Invalid Size {file.Length}");
        //3- Create Unique File Name
        var fileName = $"{Guid.NewGuid()}{extension}";
        //4- Get FolderPath المكان اللي هخزن فيه الملف
        var folderPath = Path.Combine(Directory.GetCurrentDirectory() , "wwwroot" , "Data" , folderName);
        //5- File Path
        var filePath = Path.Combine(folderPath, fileName);
        //6- Copy to File Stream   عدل الاسم
        using Stream filestreem = new FileStream(filePath, FileMode.Create);
        await file.CopyToAsync(filestreem);
        //7- Return FileName
        return fileName;
    }

    public bool Delete(string fileName, string FolderName)
    {
        //1- Get FilePath المكان اللي هخزن فيه الملف
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Data", FolderName, fileName);
        //2- Check if File Exists
        if(!File.Exists(filePath))
            throw new Exception($"Not Found {fileName}");
        File.Delete(filePath);
        return true;
    }
}
