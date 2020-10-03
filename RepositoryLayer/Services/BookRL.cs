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
using System.Linq;

namespace RepositoryLayer.Services
{
    public class BookRL : IBookRL
    {
        /// <summary>
        /// Created the Reference of ApplicationdbContext
        /// </summary>
        private ApplicationDbContext dbContext;

        private readonly IConfiguration configuration;

        BookModel bookModel = new BookModel();

        BookResponse bookResponse = new BookResponse();

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRL"/> class.
        /// </summary>
        /// <param name="dbContext">It contains the object ApplicationDbContext</param>
        public BookRL(ApplicationDbContext dbContext, IConfiguration configuration)
        {
            this.dbContext = dbContext;
            this.configuration = configuration;
        }

        public BookResponse AddBook(BookRequestModel createBookModel)
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

        public List<BookResponse> GetAllBooks()
        {
            try
            {
                List<BookResponse> bookResponseList = new List<BookResponse>();
                var responseList = this.dbContext.Books;
                foreach (var response in responseList)
                {
                    BookResponse bookResponse = new BookResponse();
                    bookResponse.BookId = response.BookId;
                    bookResponse.BookName = response.BookName;
                    bookResponse.AuthorName = response.AuthorName;
                    bookResponse.Description = response.Description;
                    bookResponse.Price = response.Price;
                    bookResponse.Quantity = response.Quantity;
                    bookResponse.CreatedDate = response.CreatedDate;
                    bookResponse.Image = response.Image;
                    bookResponseList.Add(bookResponse);
                }
                return bookResponseList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public BookResponse UpdateBook(int Id, BookRequestModel updateBookModel)
        {
            try
            {
                var response = this.dbContext.Books.FirstOrDefault(value => ((value.BookId == Id)));

                if (!response.Equals(null))
                {
                    Account account = new Account(
                                     configuration["CloudinarySettings:CloudName"],
                                     configuration["CloudinarySettings:ApiKey"],
                                     configuration["CloudinarySettings:ApiSecret"]);
                    var path = updateBookModel.Image.OpenReadStream();
                    Cloudinary cloudinary = new Cloudinary(account);

                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(updateBookModel.Image.FileName, path)
                    };

                    var uploadResult = cloudinary.Upload(uploadParams);
                    response.BookName = updateBookModel.BookName;
                    response.AuthorName = updateBookModel.AuthorName;
                    response.Description = updateBookModel.Description;
                    response.Price = updateBookModel.Price;
                    response.Quantity = updateBookModel.Quantity;
                    response.ModificationDate = DateTime.Now;
                    response.Image = uploadResult.Url.ToString();
                    response.IsDeleted = "No";
                    this.dbContext.Books.Update(response);
                    this.dbContext.SaveChanges();

                    return Response(response);
                }
                return bookResponse;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public BookResponse Response(BookModel bookModel)
        {
            BookResponse bookResponse = new BookResponse();
            bookResponse.BookId = bookModel.BookId;
            bookResponse.BookName = bookModel.BookName;
            bookResponse.AuthorName = bookModel.AuthorName;
            bookResponse.Description = bookModel.Description;
            bookResponse.Price = bookModel.Price;
            bookResponse.Quantity = bookModel.Quantity;
            bookResponse.CreatedDate = bookModel.CreatedDate;
            bookResponse.ModificationDate = bookModel.ModificationDate;
            bookResponse.Image = bookModel.Image;
            return bookResponse;
        }
    }
}
