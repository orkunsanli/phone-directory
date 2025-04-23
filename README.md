# Phone Directory API

Bu proje, kişilerin ve iletişim bilgilerinin yönetimi için geliştirilmiş bir mikroservis mimarisi uygulamasıdır.

## Proje Yapısı

Proje aşağıdaki servislerden oluşmaktadır:

1. **PersonService**: Kişilerin ve iletişim bilgilerinin yönetimi
2. **ReportService**: Raporlama işlemleri
3. **Shared**: Ortak kullanılan modeller ve servisler

## Teknolojiler

- .NET 9.0
- Entity Framework Core
- PostgreSQL
- Docker
- Docker Compose

## Kurulum

1. Projeyi klonlayın:
```bash
git clone https://github.com/your-username/PhoneDirectory.git
cd PhoneDirectory
```

2. Docker Compose ile servisleri başlatın:
```bash
docker-compose up -d
```

3. Veritabanı migration'larını uygulayın:
```bash
cd PhoneDirectory.PersonService
dotnet ef database update --project ../PhoneDirectory.Shared
```

## API Endpoints

### PersonService (http://localhost:5101)

#### Kişi İşlemleri
- `GET /api/persons`: Tüm kişileri listeler
- `GET /api/persons/{id}`: Belirli bir kişiyi getirir
- `POST /api/persons`: Yeni bir kişi ekler
- `PUT /api/persons/{id}`: Kişi bilgilerini günceller
- `DELETE /api/persons/{id}`: Kişiyi siler

#### İletişim Bilgisi İşlemleri
- `POST /api/persons/{id}/contacts`: Kişiye yeni iletişim bilgisi ekler
- `DELETE /api/persons/{id}/contacts/{contactId}`: Kişiden iletişim bilgisini siler

### ReportService (http://localhost:5102)

#### Rapor İşlemleri
- `GET /api/reports`: Tüm raporları listeler
- `GET /api/reports/{id}`: Belirli bir raporu getirir
- `POST /api/reports`: Yeni bir rapor oluşturur

## Swagger UI

Her servisin Swagger UI'ına aşağıdaki adreslerden erişilebilir:
- PersonService: http://localhost:5101/swagger
- ReportService: http://localhost:5102/swagger

## Veritabanı

Proje PostgreSQL veritabanı kullanmaktadır. Veritabanı bağlantı bilgileri:

- Host: localhost
- Port: 5432
- Database: phone_directory
- Username: postgres
- Password: postgres

## Geliştirme

1. Projeyi geliştirme ortamında çalıştırmak için:
```bash
cd PhoneDirectory.PersonService
dotnet run
```

2. Yeni bir migration oluşturmak için:
```bash
dotnet ef migrations add MigrationName --project ../PhoneDirectory.Shared
```

3. Migration'ı veritabanına uygulamak için:
```bash
dotnet ef database update --project ../PhoneDirectory.Shared
``` 