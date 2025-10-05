# Medical Viewer

![Görüntüleme Ekranı](https://github.com/user-attachments/assets/28b60a3b-741d-4768-a927-ef65f71984d2)
*<p align="center">Ana Görüntüleme Ekranı</p>*

## Proje Hakkında

**Medical Viewer**, WPF (Windows Presentation Foundation) kullanılarak geliştirilmiş, medikal DICOM görüntülerini görselleştirmeye yönelik bir masaüstü uygulamasıdır. Bu araç, DICOM serilerini 3 farklı eksende (Aksiyel, Sagital, Koronal) kesitsel olarak ve aynı zamanda 3D hacimsel (Volume Rendering) olarak interaktif bir şekilde görüntülemeyi sağlar.

Proje, temiz ve sürdürülebilir bir kod yapısı için **MVVM (Model-View-ViewModel)** mimari deseni üzerine inşa edilmiştir. 3D görselleştirme yetenekleri için açık kaynaklı ve güçlü bir kütüphane olan **VTK (The Visualization Toolkit)** ve onun .NET sarmalayıcısı olan **Activiz.NET** kullanılmıştır.

Uygulama, kullanıcı deneyimini iyileştirmek için iki ayrı pencereden oluşur:
1.  **Görüntüleme Ekranı:** Kesitlerin ve 3D modelin yer aldığı ana görselleştirme penceresi.
2.  **Kontrol Paneli:** Görüntü üzerinde ayarlamalar yapmayı sağlayan kontrol penceresi.

## Özellikler

-   **DICOM Desteği:** Klasör içindeki DICOM serilerini okuyup işleyebilir.
-   **Çoklu Görüntüleme:**
    -   Aksiyel, Sagital ve Koronal düzlemlerde kesitsel görüntüleme.
    -   3D Hacimsel Görüntüleme (Volume Rendering).
-   **İnteraktif Kontroller:**
    -   **Zoom:** Görüntüleri yakınlaştırma ve uzaklaştırma.
    -   **Katmanlar Arası Geçiş:** Fare tekerleği veya kaydırma çubukları ile kesitler arasında gezinme.
    -   **Eksen Çizgileri (Crosshairs):** Farklı pencerelerdeki anatomik konumları senkronize olarak gösteren kılvuz çizgileri.
-   **Pencereleme (Windowing):** Görüntü kontrastını ve parlaklığını ayarlamak için Pencere Genişliği (WW - Window Width) ve Pencere Seviyesi (WL - Window Level) kontrolleri.

## Ekran Görüntüleri

#### Kontrol Paneli
Kullanıcının görüntüleme parametrelerini (WW/WL, zoom, katman) kolayca yönetebildiği arayüz.

![Kontrol Paneli](https://github.com/user-attachments/assets/803c8477-7f41-4699-899b-08473fb3b250)

## Kullanılan Teknolojiler ve Mimari

-   **Platform:** .NET & WPF (Windows Presentation Foundation)
-   **Mimari Desen:** MVVM (Model-View-ViewModel)
-   **3D Grafik Kütüphanesi:** VTK (The Visualization Toolkit)
-   **.NET Wrapper:** Activiz.NET (VTK için .NET sarmalayıcısı)

## Kurulum ve Başlatma

1.  Projeyi klonlayın:
    ```bash
    git clone [https://github.com/kullanici-adiniz/medical-viewer.git](https://github.com/kullanici-adiniz/medical-viewer.git)
    ```
2.  Visual Studio ile `MedicalViewer.sln` dosyasını açın.
3.  Gerekli NuGet paketlerinin (özellikle **Activiz.NET.x64**) geri yüklendiğinden emin olun.
    *Not: Activiz.NET, platform hedefinin (x86 veya x64) tutarlı olmasını gerektirir. Bu proje x64 için yapılandırılmıştır.*
4.  Projeyi derleyin (`Build -> Build Solution`).
5.  Projeyi başlatın (`Debug -> Start Debugging` veya `F5`).

## Lisans

Bu proje MIT Lisansı altında lisanslanmıştır. Detaylar için `LICENSE` dosyasına bakınız.
