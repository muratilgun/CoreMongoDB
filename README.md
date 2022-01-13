## ASP.NET with NoSQL

###  MongoDB

MongoDB’nin sorgulama dilini kullanmadan ve komut satırına ihtiyaç olmadan sorgu ve filtreleme yapmanızı sağlayan ücretsiz sade bir araçtır. Sorgu performansı, sunucu durumu gibi ihtiyaç duyulan temel özellikleri barındırır. Web adresi: [Link]( https://www.mongodb.com/products/compass)

- Ücretsizdir
- Verileri table, list ve json formatında görsel olarak görme ve düzenleme imkanı sağlar.
- Sorgu performansı, database ve sunucu durumu gibi bilgileri temel düzeyde görebilme imkanı sağlar.
- Document ve collectionlarınızı analiz edip zengin görselleştirebilme imkanı sağlar.
- Veri kümenizdeki alanların sıklığını, türlerini ve aralıklarını anlamak için şemanızı hızlıca görselleştirmenize ve keşfetmenize olanak tanır.

Not: Kullanıcı ara yüzü sade ve kullanışlı görünüyor olsa da, verilerinizi kullanmaya yönelik tam özellikli bir geliştirme kullanıcı arabirimi veya tam özellikli bir database aracı değildir fakat ücretsiz bir araca göre fazlaca yeteneklidir.

<img src="https://i.ibb.co/L5RrVxc/Mongo-DV-Compass.png" alt="Mongo-DV-Compass" border="0">

### Proje Oluşturulması

MongoDB'yi kullanarak temel CRUD işlemleri yapmak için Asp.Net Core Web App (Model-View-Controller) projesi oluşturuyorum.(.NET 5)

<img src="https://i.ibb.co/Wx6Lfqb/Proje-olu-turulmas.png" alt="Proje-olusturulmasi">

NuGet Manager üzerinden MongoDB.Driver'ı yükledim. Ve temel Crud işlemleri için basit bir arayüz oluşturup denedim.

<img src="https://i.ibb.co/M7TF474/Datas.png" alt="Datas">
