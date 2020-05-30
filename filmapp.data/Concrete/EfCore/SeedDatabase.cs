using System.Linq;
using filmapp.entity;
using Microsoft.EntityFrameworkCore;

namespace filmapp.data.Concrete.EfCore
{
    public static class SeedDatabase
    {
        public static void Seed()
        {
            var context = new FilmSiteContext();
            if(context.Database.GetPendingMigrations().Count()==0)
            {
                if(context.Movies.Count()==0)
                {
                    context.Movies.AddRange(Movies);
                }
            }
            context.SaveChanges();
        }
        private static Movie[] Movies={
        new Movie(){Name="Whiplash",Category="Dram",Stars="Miles Teller, J.K. Simmons, Paul Reiser",Year=2015,Director="Damien Chazelle",ImageUrl="whiplash.jpg",Review="Whiplash, genç bir müzisyenin öykünü anlatıyor. Küçük yaşlardan itibaren bateri çalmaya başlayan Andrew, işinde tam anlamıyla bir usta olmak ister. Üniversite tercihinde de ülkenin en iyi müzik okulu olarak gördüğü Shcarffer Konservatuarı'na girer. Henüz 19 yaşındadır ama dersler harici var gücüyle antrenman yapar. Bir gün, okulun en sert hocalarından biri olan caz duayeni Terence Fletcher'ın dikkatini çeker. Fletcher Andrew'ü okulun en parlak öğrencilerinin seçildiği ve sürekli yeni yarışmalara hazırlanan 'studio band'e seçer. Başarısı kadar acımasızlığıyla da ün yapmış olan Fletcher, Andrew'un kapasitesinin sonuna kadar kullanmadan asla başarmış saymayacaktır. Genç bateristin önünde sadece mesleki bir test değil, psikolojik bir sınav da vardır... Senaristliğini ve yönetmenliğini Damien Chazelle'in üstlendiği filmin başrolünde Miles Teller yer alıken karşısında kendisine J.K. Simmons eşlik ediyor."},
        new Movie(){Name="Blackwidow",Category="Aksiyon",Stars="Scarlett Johansson, Florence Pugh, David Harbour",Director="Cate Shortland",Year=2020,ImageUrl="blackwidow.jpg",Review="Marvel'ın Yenilmezler ekibinin yetenekli casusu Natasha Romanoff, nam-ı diğer Black Widow'un solo filmidir. Ünlü kurgusal karakteri, Yenilmezler serisinde olduğu gibi Scarlett Johansson canlandırıyor."},
        new Movie(){Name="La La Land",Category="Romantik",Stars="Ryan Gosling, Emma Stone, John Legend",Director="Damien Chazelle",Year=2016,ImageUrl="lalaland.jpg",Review="Aşıklar Şehri, yolları kesişen iki insanın hikayesini anlatıyor. Hayatlarında yön bulmaya çalışan iki tutkulu insan Sebastian ve Mia'nın yolları, Los Angeles'ta trafiğin sıkışık olduğu bir gün kesişir. Her ikisi de sanat tutkunu olan bu iki insan, hayallerini gerçekleştirme yolunda düşe kalka ilerlemektedir.Sebastian gelenekseksel jazzın kolonlardan yükseldiği bir kulüp açma hayalinde, Mia ise kafesinde çalıştığı film platosunda kendine uygun tüm oyunculuk seçmelerine katılarak bir rol kapma telaşındadır. Bu iki insanın kalpleri birbiri için atmaya başladığında ortaya çıkan manzarayı hayat şartları bozacak, onları yavaş yavaş hayallerinden uzaklaştırmaya başlayacaktır.Oscar ödüllü Whiplash’in yazarı Damien Chazelle’in yazıp yönettiği bu romantik müzikal, modern zamana adanmış bir Hollywood masalı."},
        new Movie(){Name="Chef",Category="Aile",Stars="Jon Favreau, John Leguizamo, Sofia Vergara",Director="Jon Favreau",Year=2014,ImageUrl="chef.jpg",Review="Carl Casper şık bir restoranda çalışan bir baş aşçıdır. Kendi mutfağına ait yemekleri nefistir ama lokantanın menüsüne bağımlı çalıştıkça yaratıcılığı ve ona bağlı olarak da yemeklerinin lezzeti düşüşe geçer.  Üstelik önemli bir gurmenin yemekleri hakkında yaptığı olumsuz eleştiriler Carl için bardağı taşıran son damla olur. Yeteneğine rağmen kariyerinde düşüşe geçtiğini hisseden Carl'a tam da bu dönem bir teklif gelir: ikinci el bir bir yemek karavanı al ve kendi  işinin patronu ol! Oğlu Percy ve eski bir arkadaşı olan Martin’in yardımıyla Carl Amerika yollarında yemeğe ve yeni lezzetlere ve de en önemişi hayata dair tutkusunu yeniden keşfedecektir. Yönetmenliğini ve senaristliğini Jon Favreau’nun üstlendiği dramatikomedi filminin kadrosunda Favreau'ya Scarlett Johansson, Sofía Vergara ve Robert Downey Jr., John Leguizamo, Dustin Hoffman ve Oliver Platt gibi yıldız isimler eşlik ediyor."},
        new Movie(){Name="Karakomik Filmler 2",Category="Komedi",Stars="Cem Yılmaz, Büşra Develi, Özkan Uğur",Director="Cem Yılmaz",Year=2020,ImageUrl="karakomik2.jpg",Review="Cem Yılmaz’ın yönetmenliğini ve senaristliğini üstlendiği ‘Karakomik Filmler’ serisinin devam filmi Karakomik Filmler 2 Deli ve Emanet  adında iki filmde oluşuyor. Deli, en büyük hayali sevdiği kızın karşısında oturmak olan bir taksicinin, gece mesaisinde başına gelenler olayları konu ederken; Emanet, yetenek yarışmalarına katılıp bu sayede şöhret olmanın hayalini kuran bir danşçının hikayesini konu ediyor."}
    
        };
    }
    
}