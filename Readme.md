<h1 style="text-align:center"> 1-Hello E-Ticaret Sitesi</h1>
<hr></hr>
<p style ="color: #7d6e6d;" >Merhaba Bu yapmak istedi�im proje Asp.netCore ile mvc yap�s�n� ��renmek istenler i�in 
; Bir �irketin Web sitesini �zele�tirebilir ve de�i�tirilebilir
bir yap�da bir uygulama geli�tirmek,�rne�in kullan�c�
web aray�s�nde hangi kategorilerin g�r�nece�ini veya web ara y�z�ndeki
navbar,button renklerini kendi �irketine ait renklere d�n��t�rebilecektir.
<h5>Peki projede Neler Hangi teknolojiler kullan�ld�</h5>
<ul style ="color: #7d6e6d;">
<li>Visul Studio 2022</li>
<li>Asp .Net Core MVC</li>
<li>Katmanl� Mimari</li>
</ul>
</p>
<hr></hr>
 <h2 style="text-align:center">2-Kurulum </h2>
<ul style ="color: #cfb9b8;">
<li> 
	<p>
		Kuruluma Ba�lamak i�in Bilgisayar�n�zda 
		.net 8 veya �zeri bir bir s�r�me ihtiyac�n�z vard�r
		ve ben Veri taban� Olarak Microsoft SQL Server Management Stdio  kulland���m i�in sizde olmas� gerekiyor	
	</p>
</li>
<li>�lk Ad�m� tamamlad�ktan sonra Projeyi a��n ve DataAcces ClassL�brarye gelerek
Concrete Klasorunun i�inde olan MsSqlContext.cs deki Server ad�n�z� girin

	
</li>
<li>Nuget consoldan Data Acces katman�na gelip 
	<p style ="color:#cfb;" > Update-Database</p> diyip veri taban�n� olu�turun
</li>
<li> Veri Taban� Ba�ar�l� Bir �ekilde Olu�tuysa  projeyi �al��t�r�n
	�uan Seed Data Olu�turmad���m i�in Default kullan�c� yoktur onun i�iin Giri� i�in Veri taban�nda 
	Kullanicilar Tablosuna bir kullan�c� ekleyin ve rol�n "admin" yap�n.
</li>

</ul>

<hr></hr>


 <h2 style="text-align:center">3-Katmanlar ve Dosyalar </h2>

 <details>
 <summary>Bussiness</summary>
 <p> -�� katman�, uygulama i� y�klerini y�neten
 katmand�r. Veri taban�ndan gelen verilerin i�lenmesi, kontrol edilmesi,
 do�rulanmas� gibi i�lemler burada ger�ekle�tirilir </p>
  
  <h3> Abstract Klasor</h3>
  <p>Veri Tablolar� ile ilgili interface tan�mlanan klas�r </p>

  <h3>Concrete Klasor</h3>
  <p>Veri Tablolar� ile ilgili �zeliklerin kontrol edildi�i ve verileir
  �lgili katmana g�nderildi�i cllaslar� turan klasor</p>
 </details>

 <details>
 <summary>DataAcces</summary>
 <p> -Bu katman, veri taban�ndaki i�lemleri 
 ger�ekle�tiren kodlar� i�erir. Veri ekleme, silme, 
 g�ncelleme gibi veritaban� i�lemleri
 bu katmanda yap�l�r.  </p>
  
  <h3> Abstract Klasor</h3>
  <p>Veri Tablolar� ile ilgili interface tan�mlanan klas�r </p>

  <h3>Concrete Klasor</h3>
  <p>Veri Tablolar� ile ilgili metodlar�n doldurulmas� ve veri taban�
  na kay�t edilmesi ile ilgili klasorler bulunur</p>
 </details>

 <details>
 <summary>Entities</summary>
 <p> -Bu katman, Veri taban�na kay�t edilecek 
 Tablolar� tutar </p>
 </details>

  <details>
 <summary>HeeloWebU� </summary>
 <p> -Bu katman, Kullan�c�lara Aray�z sa�layan katmand�r 
 Busssines katman�n� tan�r ve Kullan�c�ya temiz ve kullan��l�
 bir aray�z  tan�mlamam�z� sa�lar. MVC Yap�s�Kullan�lm��t�r.
 </p> 
 </details>

 <hr> </hr>
  <h2 style="text-align:center">4-Tan�t�m Videosu </h2>
  <p> Proje Tam Hali bu de�ildir 26:10:2025 tarihinde 
  �ekilmi�tir. Proje geli�tirilmeye devam edilmektedir</p>
  <a href="https://drive.google.com/file/d/1fWPRwzzSma5f7hkVfc-Ku5DKm14-rQqh/view?usp=sharing"> 
  Viedo g�z�km�yorsa Buraya T�kla
  </a>











