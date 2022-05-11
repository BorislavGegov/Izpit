using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BusinessLayer
{
    public class Interest
    {
        [Key]
        public int ID { get; private set; }
        [Required, MaxLength(20)]
        public string Title { get; set; }
        public IEnumerable<User> Users { get; set; }
        public Region Region { get; set; }
        [ForeignKey("Region")]
        public int RegionID { get; set; }
        private Interest()
        {}
        public Interest(string title, Region region)
        {
            Title = title;
            Region = region;
        }
    }
}
