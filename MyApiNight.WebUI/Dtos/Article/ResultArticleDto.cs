﻿namespace MyApiNight.WebUI.Dtos.Article
{
    public class ResultArticleDto
    {
        public int ArticlesId { get; set; }
        public string Title { get; set; } // Makale Başlığı
        public string ImageUrl { get; set; } // Makale Görseli
        public string Content { get; set; } // Makale İçeriği
        public DateTime PublishDate { get; set; } // Yayın Tarihi
        public string Category { get; set; } // Makale Kategorisi
        public string AuthorName { get; set; } // Yazar Adı
    }
}
