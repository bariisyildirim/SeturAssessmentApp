# SeturAssessmentApp

## Projenin Amacı 
Web veya mobil uygulamaların kullanacağı web servislerin olduğu bir yapı tasarlayarak, basit bir telefon rehberi uygulaması oluşturulması sağlanacaktır.

## Özet
.NET Core, Postman ve MongoDB teknolojileri kullanılarak yazılmış bir Telefon Rehberi Uygulamasıdır.

### Teknik Tasarım
Visual Studio ortamında Solution name'i 'SeturAssessmentApp' olup 'Setur.APIApp' adında .NET Core Web API projesi oluşturuldu. 
Katmanlı mimari yapısı kullanarak projeye 4 ayrı katman eklendi. Setur.Entity isimli library içerisinde veriler tanımlanarak Person ve Contact adında iki sınıf oluşturuldu.
Setur.Data isimli library servisler ve veriler arasındaki bağlantıyı kurmak ve database tarafını ayağa kaldırmak için oluşturuldu. Bu katman içerisinde Models ve Repositories adında iki ayrı klasör yaratıldı. Models içerisinde PersonDatabaseSettings adında interface ile birlikte iki sınıf açıldı.
Bu sınıfların içerisinde projeye bağlantı sağlayacak database verilerinin bilgileri tutuldu. Repositories içerisinde ise projenin servisleriyle bağlantı oluşturulacak methodlar yazıldı.
Setur.Business katmanında ise servislerin yapacağı işler koda döküldü. (Örneğin Create isimli method ile oluşturulan servis Rehberde kişi oluşturmak amacı ile yazılmıştır.)
Ek olarak raporlama tarafında kullanılan veriler bu katmanın içerinde tutuldu. Setur.APIApp tarafı projenin ayağa kaldırıldığı taraftır.
Bu kısımda Controllers klasörü içerisinde servisler çağrıldı ve proje ayağa kaldırıldı.

### Teknik Gereklilikler
Visual Studio 2019 <br/>
Postman <br/>
MongoDB <br/>
NuGet Packages (Microsoft.AspNetCore.Mvc.NewtonsoftJson, MongoDB.Driver, MongoDB.Bson)
