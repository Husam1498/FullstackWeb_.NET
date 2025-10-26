<h1 style="text-align:center"> 1-Hello E-Ticaret Sitesi</h1>
<hr></hr>
<p style ="color: #7d6e6d;" >Merhaba Bu yapmak istediðim proje Asp.netCore ile mvc yapýsýný öðrenmek istenler için 
; Bir þirketin Web sitesini özeleþtirebilir ve deðiþtirilebilir
bir yapýda bir uygulama geliþtirmek,Örneðin kullanýcý
web arayüsünde hangi kategorilerin görüneceðini veya web ara yüzündeki
navbar,button renklerini kendi þirketine ait renklere dönüþtürebilecektir.
<h5>Peki projede Neler Hangi teknolojiler kullanýldý</h5>
<ul style ="color: #7d6e6d;">
<li>Visul Studio 2022</li>
<li>Asp .Net Core MVC</li>
<li>Katmanlý Mimari</li>
</ul>
</p>
<hr></hr>
 <h2 style="text-align:center">2-Kurulum </h2>
<ul style ="color: #cfb9b8;">
<li> 
	<p>
		Kuruluma Baþlamak için Bilgisayarýnýzda 
		.net 8 veya üzeri bir bir sürüme ihtiyacýnýz vardýr
		ve ben Veri tabaný Olarak Microsoft SQL Server Management Stdio  kullandýðým için sizde olmasý gerekiyor	
	</p>
</li>
<li>Ýlk Adýmý tamamladýktan sonra Projeyi açýn ve DataAcces ClassLÝbrarye gelerek
Concrete Klasorunun içinde olan MsSqlContext.cs deki Server adýnýzý girin

	
</li>
<li>Nuget consoldan Data Acces katmanýna gelip 
	<p style ="color:#cfb;" > Update-Database</p> diyip veri tabanýný oluþturun
</li>
<li> Veri Tabaný Baþarýlý Bir þekilde Oluþtuysa  projeyi çalýþtýrýn
	Þuan Seed Data Oluþturmadýðým için Default kullanýcý yoktur onun içiin Giriþ için Veri tabanýnda 
	Kullanicilar Tablosuna bir kullanýcý ekleyin ve rolün "admin" yapýn.
</li>

</ul>

<hr></hr>


 <h2 style="text-align:center">3-Katmanlar ve Dosyalar </h2>

 <details>
 <summary>Bussiness</summary>
 <p> -Ýþ katmaný, uygulama iþ yüklerini yöneten
 katmandýr. Veri tabanýndan gelen verilerin iþlenmesi, kontrol edilmesi,
 doðrulanmasý gibi iþlemler burada gerçekleþtirilir </p>
  
  <h3> Abstract Klasor</h3>
  <p>Veri Tablolarý ile ilgili interface tanýmlanan klasör </p>

  <h3>Concrete Klasor</h3>
  <p>Veri Tablolarý ile ilgili özeliklerin kontrol edildiði ve verileir
  Ýlgili katmana gönderildiði cllaslarý turan klasor</p>
 </details>

 <details>
 <summary>DataAcces</summary>
 <p> -Bu katman, veri tabanýndaki iþlemleri 
 gerçekleþtiren kodlarý içerir. Veri ekleme, silme, 
 güncelleme gibi veritabaný iþlemleri
 bu katmanda yapýlýr.  </p>
  
  <h3> Abstract Klasor</h3>
  <p>Veri Tablolarý ile ilgili interface tanýmlanan klasör </p>

  <h3>Concrete Klasor</h3>
  <p>Veri Tablolarý ile ilgili metodlarýn doldurulmasý ve veri tabaný
  na kayýt edilmesi ile ilgili klasorler bulunur</p>
 </details>

 <details>
 <summary>Entities</summary>
 <p> -Bu katman, Veri tabanýna kayýt edilecek 
 Tablolarý tutar </p>
 </details>

  <details>
 <summary>HeeloWebUÝ </summary>
 <p> -Bu katman, Kullanýcýlara Arayüz saðlayan katmandýr 
 Busssines katmanýný tanýr ve Kullanýcýya temiz ve kullanýþlý
 bir arayüz  tanýmlamamýzý saðlar. MVC YapýsýKullanýlmýþtýr.
 </p> 
 </details>

 <hr> </hr>
  <h2 style="text-align:center">4-Tanýtým Videosu </h2>
  <p> Proje Tam Hali bu deðildir 26:10:2025 tarihinde 
  çekilmiþtir. Proje geliþtirilmeye devam edilmektedir</p>
  <a href="https://drive.google.com/file/d/1fWPRwzzSma5f7hkVfc-Ku5DKm14-rQqh/view?usp=sharing"> 
  Viedo gözükmüyorsa Buraya Týkla
  </a>











