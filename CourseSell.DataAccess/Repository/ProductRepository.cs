using CourseSell.DataAccess.Repository.IRepository;
using CourseSell.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSell.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db) {
            _db = db;
        }

        public void Update(Product obj)
        {
            var objFromDb = _db.Products.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Title = obj.Title;
                objFromDb.Description = obj.Description;
                objFromDb.CourseID = obj.CourseID;
                objFromDb.Instructor = obj.Instructor;
                objFromDb.Price = obj.Price;
                objFromDb.ListPrice = obj.ListPrice;
                objFromDb.Price5 = obj.Price5;
                objFromDb.Price10 = obj.Price10;
                objFromDb.CategoryId = obj.CategoryId;
                objFromDb.CoverType = obj.CoverType;
                if (obj.ImageUrl != null) 
                { 
                    objFromDb.ImageUrl = obj.ImageUrl;
                }
            }
        }
    }
}
