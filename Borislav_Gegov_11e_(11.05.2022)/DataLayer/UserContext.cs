using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    class UserContext : IDB<User, int> //tuk e prosto da ima neshto
    {
        public void Create(User item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int key)
        {
            throw new NotImplementedException();
        }

        public User Read(int key, bool noTracking = false, bool useNavigationProperties = false)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> Read(int skip, int take, bool useNavigationProperties = false)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> ReadAll(bool useNavigationProperties = false)
        {
            throw new NotImplementedException();
        }

        public void Update(User item, bool useNavigationProperties = false)
        {
            throw new NotImplementedException();
        }
    }
}
