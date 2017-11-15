using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using PagedList;

namespace DvdShop.Models.Repositories
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {
        private DvdDbContext _dataContext;
        private readonly IDbSet<T> _dbSet;
        private IDbFactory DbFactory { get; set; }

        private DvdDbContext DbContext => _dataContext ?? (_dataContext = DbFactory.GetDbContext());

        protected RepositoryBase(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            _dbSet = DbContext.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
            _dataContext.SaveChanges();
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _dataContext.Entry(entity).State = EntityState.Modified;
            _dataContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
            _dataContext.SaveChanges();
        }

        public void Delete(Expression<Func<T, bool>> @where)
        {
            var objects = _dbSet.Where<T>(where).AsEnumerable();
            foreach (var obj in objects)
            {
                _dbSet.Remove(obj);
            }
            _dataContext.SaveChanges();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public T GetByName(string name)
        {
            return _dbSet.Find(name);
        }

        public T GetWithCondition(Expression<Func<T, bool>> @where)
        {
            return _dbSet.Where<T>(where).FirstOrDefault();
        }

        public IEnumerable<T> GetAll(string[] includes = null)
        {
            if (includes == null || !includes.Any())
                return _dataContext.Set<T>().AsQueryable();
            var query = _dataContext.Set<T>().Include(includes.First());
            query = includes.Skip(1).Aggregate(query, (current, include) => current.Include(include));
            return query.AsQueryable();
            //return _dbSet.ToList();
        }

        public IEnumerable<T> GetManyCondition(Expression<Func<T, bool>> @where)
        {
            return _dbSet.Where<T>(where);
        }

        public IPagedList<T> GetPage<TOrder>(Page page, Expression<Func<T, bool>> @where, Expression<Func<T, TOrder>> order)
        {
            var results = _dbSet.OrderBy(order).Where(where).GetPage(page).ToList();
            var total = _dbSet.Count(where);
            return  new StaticPagedList<T>(results,page.PageNumber,page.PageSize,total);
        }
    }
}