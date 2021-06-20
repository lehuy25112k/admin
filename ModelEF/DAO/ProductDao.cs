using ModelEF.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class ProductDao
    {
        private DbContextWeb db;

        public ProductDao()
        {
            db = new DbContextWeb();
        }
        public List<Product> ListAll()
        {
            return db.Products.OrderByDescending(x => x.UnitCost).ToList();
        }
        public IEnumerable<Product> ListWhereAll(string keysearch, int page, int pagesize)
        {
            IQueryable<Product> model = db.Products;
            if (!string.IsNullOrEmpty(keysearch))
            {
                model = model.Where(x => x.Name.Contains(keysearch));
            }
            return model.OrderBy(x => x.Name).ToPagedList(page, pagesize);
        }
        public Product GetById(string name)
        {
            return db.Products.SingleOrDefault(x => x.Name == name);
        }

        public string Insert(Product entity)
        {
            var prd = GetById(entity.Name);
            if (prd == null)
            {
                db.Products.Add(entity);
            }
            else
            {
                prd.ID = entity.ID;
                if (!String.IsNullOrEmpty(entity.Name))
                {
                    prd.Name = entity.Name;
                }
                prd.UnitCost = entity.UnitCost;
                prd.Quantity = entity.Quantity;
                prd.Description = entity.Description;
                prd.Status = entity.Status;
                prd.Image = entity.Image;
                prd.Category_ID = entity.Category_ID;
            }
            db.SaveChanges();
            return entity.Name;
        }

        public bool Delete(int id)
        {
            try
            {
                var pro = db.Categories.Find(id);
                db.Categories.Remove(pro);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

    }
}
