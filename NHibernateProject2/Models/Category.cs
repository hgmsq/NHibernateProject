using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace NHibernateProject2.Models
{
    public class Category
    {
        
        public virtual int Id { get; set; }
        [DisplayName("分类名称")]
        public virtual string Name { get; set; }
        [DisplayName("分类描述")]
        public virtual string Description { get; set; }
    }
}