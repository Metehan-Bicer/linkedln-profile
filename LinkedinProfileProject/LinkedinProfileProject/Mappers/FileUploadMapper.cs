using AutoMapper;
using LinkedinProfileProject.Entities;
using LinkedinProfileProject.Models;

namespace LinkedinProfileProject.Mappers
{
    public class FileUploadMapper : Profile
    {
        public FileUploadMapper() : base()
        {
            CreateMap<FileUploadModel, FileUpload>()

               .ForMember(destination => destination.Extension,
                    options => options.MapFrom(source => Path.GetExtension(source.File.FileName)))
               .ForMember(destination => destination.ContentType,
                    options => options.MapFrom(source => source.File.ContentType));
            CreateMap<FileUpload, FileUploadModel>();

            CreateMap<FileUpload, FileUploadModelImage>()
                    .ForMember(destination => destination.Base64,
                         options => options.MapFrom(source => Convert.ToBase64String(File.ReadAllBytes(source.Adress))));

        }
    }
}
