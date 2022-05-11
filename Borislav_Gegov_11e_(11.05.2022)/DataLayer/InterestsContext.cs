using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public class InterestContext : IDB<Interest, int>
    {
        private ActivityDbContext _context;

        public InterestContext(ActivityDbContext context)
        {_context = context;}
        public void Create(Interest item)
        {
            try
            {
                Region DBregion = _context.Regions.Find(item.RegionID);
                if (DBregion != null)
                {item.Region = DBregion;}
            }
            catch (Exception)
            {throw;}
        }

        public void Delete(int key)
        {
            try
            {
                _context.Interests.Remove(Read(key));
                _context.SaveChanges();
            }
            catch (Exception ex)
            {throw ex;}
        }
        public Interest Read(int key, bool noTracking = false, bool useNavigationProperties = false)
        {
            try
            {
                IQueryable<Interest> Query = _context.Interests;
                if (noTracking)
                {Query = Query.AsNoTrackingWithIdentityResolution();}
                if (useNavigationProperties)
                {Query = Query.Include(i => i.Region).Include(i => i.Users);}
                return Query.SingleOrDefault(i => i.ID == key);
            }
            catch (Exception ex)
            {throw ex;}
        }
        public IEnumerable<Interest> Read(int skip, int take, bool useNavigationProperties = false)
        {
            try
            {
                IQueryable<Interest> Query = _context.Interests.AsNoTrackingWithIdentityResolution();
                if (useNavigationProperties)
                {Query = Query.Include(i => i.Region).Include(i => i.Users);}
                return Query.Skip(skip).Take(take).ToList();
            }
            catch (Exception ex)
            {throw ex;}
        }
        public IEnumerable<Interest> ReadAll(bool useNavigationProperties = false)
        {
            try
            {
                IQueryable<Interest> Query = _context.Interests.AsNoTracking();
                if (useNavigationProperties)
                {Query = Query.Include(i => i.Region).Include(i => i.Users);}
                return Query.ToList();
            }
            catch (Exception ex)
            {throw ex;}
        }
        public void Update(Interest item, bool useNavigationProperties = false)
        {
            try
            {
                Interest interestFromDB = Read(item.ID, useNavigationProperties);
                if (useNavigationProperties)
                {
                    interestFromDB.Region = item.Region;
                    List<User> users = new List<User>();
                    foreach (User user in item.Users)
                    {
                        User userFromDB = _context.Users.Find(user.ID);
                        if (userFromDB != null)
                        {users.Add(userFromDB);}
                        else
                        {users.Add(user);}
                    }
                    interestFromDB.Users = users;
                }
                _context.Entry(interestFromDB).CurrentValues.SetValues(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {throw ex;}
        }
    }
}
