using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLayer
{
    public class Region
    {
        [Key]
        public int ID { get; private set; }
        [Required, MaxLength(20)]
        public string Name { get; set; }
        public IEnumerable<User> Users { get; set; }
        private Region()
        {}
        public Region(string name)
        {Name = name;}
    }
}
