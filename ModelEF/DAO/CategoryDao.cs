using ModelEF.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class CategoryDao
    {
        private DbContextWeb db;

        public CategoryDao()
        {
            db = new DbContextWeb();
        }
        public List<Category> ListAll()
        {
            return db.Categories.ToList();
        }
        public IEnumerable<Category> ListWhereAll(string keysearch, int page, int pagesize)
        {
            IQueryable<Category> model = db.Categories;
            if (!string.IsNullOrEmpty(keysearch))
            {
                model = model.Where(x => x.Name.Contains(keysearch));
            }
            return model.OrderBy(x => x.Name).ToPagedList(page, pagesize);
        }

        public string Insert(Category entity)
        {
            var category = GetById(entity.Name);
            if (category == null)
            {
                db.Categories.Add(entity);
            }
            else
            {
                category.Name = entity.Name;
                if (!String.IsNullOrEmpty(entity.Description))
                {
                    category.Description = entity.Description;
                }
                
            }
            db.SaveChanges();
            return entity.Name;
        }
        public Category GetById(string name)
        {
            return db.Categories.SingleOrDefault(x => x.Name == name);
        }

        public bool Delete(int id)
        {
            try
            {
                var category = db.Categories.Find(id);
                db.Categories.Remove(category);
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
