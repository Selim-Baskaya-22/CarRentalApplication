using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        public static string Add(IFormFile formFile)
        {
            var result = newPath(formFile);
            var sourcePath = Path.GetTempFileName();
            if (sourcePath.Length > 0)
            {
                using (var stream = new FileStream(sourcePath, FileMode.Create))
                {
                    formFile.CopyTo(stream);
                }

            }
            File.Move(sourcePath, result);
            return result;
        }

        public static IResult Delete(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception exp)
            {
                return new ErrorResult(exp.Message);
            }
            return new SuccessResult();


        }


        public static string Update(string sourcePath, IFormFile formFile)
        {
            var result = newPath(formFile);
            if (sourcePath.Length > 0)
            {
                using (var stream = new FileStream(result, FileMode.Create))
                {
                    formFile.CopyTo(stream);
                }
            }
            File.Delete(sourcePath);
            return result;

        }

        public static string newPath(IFormFile formFile)
        {
            FileInfo fileInfo = new FileInfo(formFile.FileName);
            string fileExtension = fileInfo.Extension;

            var path = Environment.CurrentDirectory + @"\wwwroot\Images";
            var newPath = Guid.NewGuid().ToString() + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Year + fileExtension;
            string result = $@"{path}\{newPath}";
            return result;
        }
    }
}
