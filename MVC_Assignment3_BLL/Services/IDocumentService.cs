using Microsoft.AspNetCore.Http;

namespace MVC_Assignment3_BLL.Services;
public interface IDocumentService
{
    //Upload Document
    // (File , FolderName) ==> String (FileName)
    public Task<string?> UploadAsync(IFormFile file, string folderName);
    //delete Document
    // (FileName , FolderName) ==> bool
    public bool Delete(string fileName, string FolderName);
}
