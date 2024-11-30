using System.ComponentModel.DataAnnotations.Schema;

namespace UdemyCourseApi.Models.Domain
{
    public class Image
    {
        public Guid Id { get; set; }

        [NotMapped]
        public IFormFile File { get; set; }

        public string Filename { get; set; }

        public string ? Filedescription { get; set; }   

        public string FileExtension { get; set; }

        public string FilesizeInBytes { get; set; } 


        public string FilePath { get; set; }


    }
}
