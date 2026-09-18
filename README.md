# Belediye Envanter, Araç ve Personel Takip Sistemi

<p align="center">
  <img src="https://img.shields.io/badge/Platform-Windows%20Forms-blue?style=for-the-badge&logo=windows" alt="Platform" />
  <img src="https://img.shields.io/badge/Language-C%23%20%2F%20.NET-239120?style=for-the-badge&logo=c-sharp" alt="Language" />
  <img src="https://img.shields.io/badge/Database-MS%20Access%20(OLEDB)-orange?style=for-the-badge&logo=microsoft-access" alt="Database" />
  <img src="https://img.shields.io/badge/Reporting-SAP%20Crystal%20Reports-005691?style=for-the-badge" alt="Crystal Reports" />
  <img src="https://img.shields.io/badge/Status-Completed-success?style=for-the-badge" alt="Status" />
</p>

---

## Proje Genel Bakışı

**Belediye Envanter, Araç ve Personel Takip Sistemi**, belediye bünyesindeki hizmet araçlarının, iş makinelerinin, birim personellerinin ve araca özel yakıt giderlerinin tek bir çatı altından dijital olarak yönetilmesini sağlayan kurumsal bir masaüstü uygulamasıdır.

Sistem; kâğıt üzerindeki fiş ve evrak karmaşasını ortadan kaldırarak akaryakıt giderlerini, personel sicil kayıtlarını ve araç zimmet durumlarını kayıt altına alır ve **SAP Crystal Reports** altyapısıyla resmi evrak formatında raporlar.

---

## Temel Modüller ve Özellikler

### 1. Araç Filosu & Envanter Yönetimi
* **Teknik Sicil Kaydı:** Plaka, marka, model, yıl, renk, kasa tipi, yakıt/vites türü, şasi numarası ve özel açıklamalar.
* **Aktif / Pasif Ayrımı (Soft Delete):** Görevde olan aktif araçlar ile arızalı/hurdaya ayrılmış araçların ayrı listelerde takibi.
* **Gelişmiş Filtreleme:** Kolon bazlı gruplama, anlık arama (Find/Clear) ve sıralama desteği.
* **Sağ Tık (Context) Menüsü:** Seçili araca özel hızlı aksiyonlar:
  * ✏️ Güncelle
  * ⏸️ Pasif Et / Aktif Et
  * ⛽ **Yakıt Fişi Girişi ve Geçmişi**
  * 🖨️ Rapor Görüntüle
  * ❌ Sil

---

### 2. Yakıt Fişi & Tüketim Takibi
* **Araca Özel Fiş Girişi:** İlgili araca sağ tıklanarak doğrudan o aracın ID'sine bağlı fiş kaydı oluşturma.
* **Detaylı Masraf Kaydı:** Fiş numarası, alış tarihi, yakıt litresi, birim/toplam tutar, teslim alan alıcı personel ve açıklama bilgisi.
* **Geçmiş Yakıt Hareketleri:** Araç ekranının altındaki dinamik listede o araca ait tüm geçmiş yakıt fişlerinin listelenmesi.

---

### 3. Personel Özlük & Sicil Yönetimi
* **Kapsamlı Özlük Formu:** Ad, Soyad, TC Kimlik No, Sicil No, Görev Birimi, İşe Giriş Tarihi, Telefon, E-posta, Adres, Cinsiyet, Doğum Tarihi/Yeri, Anne/Baba Adı ve Kan Grubu.
* **Durum Takibi:** Aktif çalışanlar ve görevden ayrılan personeller için bağımsız filtreleme.
* **Hızlı Yönetim:** Personel listesi üzerinde sağ tık menüsüyle profil güncelleme, pasife alma ve sicil dökümü.

---

### 4. SAP Crystal Reports ile Resmi Raporlama
* **Genel Araç Listesi Raporu:** Belediye envanterindeki tüm araçların marka, model, yıl ve yakıt türüyle A4 resmi evrak dökümü.
* **Araç Detay & Yakıt Harcama Raporu:** Seçilen araca ait tüm akaryakıt alımlarının (fiş no, alış tarihi, alıcı, litre, tutar) listelenmesi ve **Toplam Tutar (₺)** maliyet hesabı dökümü.
* **Yazdırma ve Dışa Aktarma:** Dökümleri tek tıkla fiziksel yazıcıya gönderme veya PDF/Excel olarak dışa aktarma (Export).

---

### 5. Sistem & Güvenlik Yönetimi
* **Kullanıcı & Profil Yönetimi:** Giriş yapan kullanıcının oturum bilgisi, yetkilendirme ve profil güncelleme.
* **Tek Tıkla Veritabanı Yedeği (Yedek Al):** Olası çökme veya veri kaybına karşı doğrudan arayüzden MS Access veritabanı yedeği alabilme.
* **Tema Değiştirici:** Kurum renklerine uygun görsel tema desteği.

---

## Ekran Görüntüleri (Arayüz & Raporlar)

### Araç Takip & Sağ Tık Menüsü
| Aktif Araç Listesi ve Arama | Sağ Tık Hızlı İşlem Menüsü |
|:---:|:---:|
| ![Araç Listesi](screenshots/01_arac_listesi.png) | ![Araç Sağ Tık Menüsü](screenshots/02_arac_sag_tik.png) |

---

### Yakıt Fişi Takip Modülü
> Araç sağ tık menüsünden erişilen; araca ait fiş girişinin ve alt kısımda geçmiş yakıt kayıtlarının yer aldığı takip formu:

<p align="center">
  <img src="screenshots/03_yakit_fisi_ekrani.png" alt="Araç Yakıt Fişi Takip Ekranı" width="85%" />
</p>

---

### Personel Yönetimi
| Personel Detaylı Kayıt Formu | Personel Sağ Tık Menüsü |
|:---:|:---:|
| ![Personel Kayıt](screenshots/04_personel_kayit.png) | ![Personel Sağ Tık Menüsü](screenshots/05_personel_sag_tik.png) |

---

### SAP Crystal Reports Resmi Çıktıları
| Genel Araç Listesi Raporu | Araç Detay & Yakıt Harcama Raporu |
|:---:|:---:|
| ![Araç Listesi Raporu](screenshots/06_rapor_arac_listesi.png) | ![Araç Detay ve Yakıt Raporu](screenshots/07_rapor_arac_yakit_detay.png) |

---

## Kullanılan Teknolojiler

| Alan | Teknoloji |
| :--- | :--- |
| **Programlama Dili** | C# (.NET Framework) |
| **Arayüz (UI)** | Windows Forms (WinForms), Gelişmiş Grid Bileşenleri |
| **Veritabanı** | Microsoft Access Database (`.accdb` / Microsoft.ACE.OLEDB) |
| **Raporlama Aracı** | SAP Crystal Reports Runtime for .NET |
| **Mimari** | Modüler Form Mimarisi, Soft-Delete Veri Güvenliği, Yedekleme Servisi |

---

## Kurulum ve Çalıştırma

### Sistem Gereksinimleri
1. **İşletim Sistemi:** Windows 10 / 11 (x86 veya x64)
2. **.NET Framework:** 4.7.2 veya üzeri
3. **Microsoft Access Database Engine:** OLEDB sürücüsü yüklü olmalıdır.
4. **SAP Crystal Reports Runtime:** Rapor ekranlarının çalışması için Crystal Reports Runtime (32-bit/64-bit) kurulu olmalıdır.
5. **Geliştirme Ortamı:** Visual Studio 2019 / 2022

### Kurulum Adımları
1. Repoyu bilgisayarınıza klonlayın:
   ```bash
   git clone https://github.com/kullanici-adiniz/belediye-envanter-takip.git
   ```
2. `BelediyeEnvanterTakip.sln` çözüm dosyasını Visual Studio ile açın.
3. Veritabanı dosyasının (`.accdb`) bağlantı yolunu `App.config` dosyasından kontrol edin.
4. Projeyi derleyin (`Build Solution`) ve `F5` tuşuna basarak çalıştırın.

---

## Geliştirici

* **Mustafa Aslan**

---
