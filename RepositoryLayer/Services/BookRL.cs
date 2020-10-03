using System;
using System.Collections.Generic;
using System.Text;
using CommanLayer.Model;
using CommanLayer.RequestModel;
using CommanLayer.ResponseModel;
using RepositoryLayer.Interface;
using CloudinaryDotNet;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.Extensions.Configuration;

using CloudinaryDotNet.Actions;

namespace RepositoryLayer.Services
{
    public class AdminRL : IAdminRL
    {
        /// <summary>
        /// Created the Reference of ApplicationdbContext
        /// </summary>
        private ApplicationDbContext dbContext;

        private readonly IConfiguration configuration;

        BookModel bookModel = new BookModel();

        BookResponse response = new BookResponse();

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRL"/> class.
        /// </summary>
        /// <param name="dbContext">It contains the object ApplicationDbContext</param>
        public AdminRL(ApplicationDbContext dbContext, IConfiguration configuration)
        {
            this.dbContext = dbContext;
            this.configuration = configuration;
        }

        public BookResponse AddBook(CreateBookModel createBookModel)
        {
            try
            {
                Account account = new Account(
                                 configuration["CloudinarySettings:CloudName"],
                                 configuration["CloudinarySettings:ApiKey"],
                                 configuration["CloudinarySettings:ApiSecret"]);
                var path = createBookModel.Image.OpenReadStream();
                Cloudinary cloudinary = new Cloudinary(account);

                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(createBookModel.Image.FileName, path)
                };

                var uploadResult = cloudinary.Upload(uploadParams);
                    bookModel.BookName = createBookModel.BookName;
                    bookModel.AuthorName = createBookModel.AuthorName;
                    bookModel.Description = createBookModel.Description;
                    bookModel.Price = createBookModel.Price;
                    bookModel.Quantity = createBookModel.Quantity;
                    bookModel.CreatedDate = DateTime.Now;
                    bookModel.Image = uploadResult.Url.ToString();
                    this.dbContext.Books.Add(bookModel);
                    bookModel.IsDeleted = "No";
                    this.dbContext.SaveChanges();
               
                return Response(bookModel);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public BookResponse Response(BookModel bookModel)
        {
            // UserResponseModel userResponse = new UserResponseModel();
            response.BookId = bookModel.BookId;
            response.BookName = bookModel.BookName;
            response.AuthorName = bookModel.AuthorName;
            response.Description = bookModel.Description;
            response.Price = bookModel.Price;
            response.Quantity = bookModel.Quantity;
            response.CreatedDate = bookModel.CreatedDate;
            response.ModificationDate = bookModel.ModificationDate;
            response.Image = bookModel.Image;
            return response;
        }
    }
}
