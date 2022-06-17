using Core.Utilities.Business;
using Core.Utilities.Result;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.FileHelper
{
    public class FileHelperManager : IFileHelper
    {
        public static readonly List<string> ImageExtensions = new List<string> { ".JPG", ".JPEG", ".JPE", ".BMP", ".GIF", ".PNG",".jpg",
                                                                                 ".jpeg",".jpe",".bmp",".gif",".png" };
        public IResult Upload(IFormFile file, string root)
        {
            IResult result = BusinessRules.Run(CheckIfAFileSent(file),
                CheckIfFileIsAnImage(file));
            if (result != null)
            {
                return result;
            }

            if (!Directory.Exists(root))//Dosya dizini var mı yok mu sorgular, yoksa oluşturur
            {
                Directory.CreateDirectory(root);
            }
            string fileName = CreateFile(root, file);//GUID ve dosya uzantısını kullanarak dizinde dosyayı oluşturur
            return new SuccessResult(fileName);
        }

        public IResult Update(IFormFile file, string filePath, string root)
        {
            var result = DeleteFile(filePath);
            if (result.Success)
            {
                return Upload(file, root);
            }
            return result;
        }

        public IResult Delete(string filePath)
        {
            return DeleteFile(filePath);
        }

        private string CreateFile(string root, IFormFile file)
        {
            var guid = Guid.NewGuid().ToString();//hazır guid oluşturma fonksiyonu
            var extension = Path.GetExtension(file.FileName);//gelen dosyanın uzantı ekini string olarak ayrıştırır
            var fileName = guid + extension;//oluşturulan guid ve uzantı ismiyle yeni isimde bir dosya oluşturulur

            using (FileStream fileStream = File.Create(root + fileName))//belirtilen dizin yoksa oluşturur
            {
                file.CopyTo(fileStream);//gelen dosyayı belirtilen dizine kopyalar
                fileStream.Flush();//nesneyi temizler
            }
            return fileName;
        }

        private IResult DeleteFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                return new SuccessResult("Dosya silindi");
            }
            return new ErrorResult("Belirtilen dosya bulunamadı");
        }

        private static IResult CheckIfFileIsAnImage(IFormFile file)//Dosyanın bir image olduğundan emin olmak için
        {
            if (ImageExtensions.Contains(Path.GetExtension(file.FileName)))
            {
                return new SuccessResult();
            }
            return new ErrorResult("Hatalı dosya uzantısı");
        }

        private static IResult CheckIfAFileSent(IFormFile file)//Formun boş gelmediğinden emin olmak için
        {
            if (file != null && file.Length > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult("Bozuk dosya");
        }
    }
}
