using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApiNight.EntityLayer.Concrete
{
    public class Article
    {
        [Key] // Birincil anahtar olduğunu belirtir
        public int ArticlesId { get; set; }
        public string Title { get; set; } // Makale Başlığı
        public string ImageUrl { get; set; } // Makale Görseli
        public string Content { get; set; } // Makale İçeriği
        public DateTime PublishDate { get; set; } // Yayın Tarihi
        public string Category { get; set; } // Makale Kategorisi
        public string AuthorName { get; set; } // Yazar Adı
    }

}
