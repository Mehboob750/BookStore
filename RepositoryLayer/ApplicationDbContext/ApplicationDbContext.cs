// <copyright file="ApplicationDbContext.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Mehboob Shaikh</author>
//-----------------------------------------------------------------------
[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:FileHeaderFileNameDocumentationMustMatchTypeName", Justification = "Reviewed.")]

namespace RepositoryLayer
{
    using CommanLayer.Model;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// Dbset for UserDetails table
        /// </summary>
        public DbSet<UserModel> UserDetails { get; set; }

        /// <summary>
        /// Dbset for Books table 
        /// </summary>
        public DbSet<BookModel> Books { get; set; }

        /// <summary>
        /// Dbset for Cart table
        /// </summary>
        public DbSet<CartModel> Cart { get; set; }

    }
}