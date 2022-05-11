using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public class RegionContext : IDB<Region, int>
    {
        private ActivityDbContext _context;

        public RegionContext(ActivityDbContext context)
        { _context = context;}
        public void Create(Region item)
        {
            try
            {
                _context.Regions.Add(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {throw ex;}
        }
        public void Delete(int key)
        {
            try
            {
                _context.Regions.Remove(Read(key));
                _context.SaveChanges();
            }
            catch (Exception ex)
            {throw ex;}
        }
        public Region Read(int key, bool noTracking = false, bool useNavigationProperties = false)
        {
            try
            {
                IQueryable<Region> Query = _context.Regions;
                if (noTracking)
                {Query = Query.AsNoTrackingWithIdentityResolution();}
                if (useNavigationProperties)
                {Query = Query.Include(i => i.Users);}
                return Query.SingleOrDefault(i => i.ID == key);
            }
            catch (Exception ex)
            {throw ex;}
        }
        public IEnumerable<Region> Read(int skip, int take, bool useNavigationProperties = false)
        {
            try
            {
                IQueryable<Region> Query = _context.Regions.AsNoTrackingWithIdentityResolution();
                if (useNavigationProperties)
                {Query = Query.Include(i => i.Users);}
                return Query.Skip(skip).Take(take).ToList();
            }
            catch (Exception ex)
            {throw ex;}
        }
        public IEnumerable<Region> ReadAll(bool useNavigationProperties = false)
        {
            try
            {
                IQueryable<Region> Query = _context.Regions.AsNoTracking();
                if (useNavigationProperties)
                {Query = Query.Include(i => i.Users);}
                return Query.ToList();
            }
            catch (Exception ex)
            {throw ex;}
        }
        public void Update(Region item, bool useNavigationProperties = false)
        {
            try
            {
                Region DBregion = Read(item.ID, useNavigationProperties);
                if (useNavigationProperties)
                {
                    List<User> users = new List<User>();
                    foreach (User user in item.Users)
                    {
                        User DBuser = _context.Users.Find(user.ID);
                        if (DBuser != null)
                        {users.Add(DBuser);}
                        else
                        {users.Add(user);}
                    }
                    DBregion.Users = users;
                }
                _context.Entry(DBregion).CurrentValues.SetValues(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {throw ex;}
        }
    }
}
