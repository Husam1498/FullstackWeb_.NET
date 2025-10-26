<h1 style="text-align:center"> 1-Hello E-Ticaret Sitesi</h1>
<hr></hr>
<p style ="color: #7d6e6d;" >Bu proje, ASP.NET Core ile MVC yap�s�n� ��renmek isteyenler i�in
tasarlanm��t�r. Ama�, bir �irketin web sitesini 
�zelle�tirilebilir ve de�i�tirilebilir bir yap�da
geli�tirmektir. �rne�in, kullan�c� web aray�z�nde
hangi kategorilerin g�r�nece�ini belirleyebilecek 
veya navbar ve buton renklerini kendi �irketine ait
kurumsal renklere d�n��t�rebilecektir..</p>
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
		Kuruluma ba�lamak i�in bilgisayar�n�zda 
		.NET 8 veya �zeri bir s�r�m�n y�kl� 
		olmas� gerekmektedir. Ayr�ca, veri taban�
		olarak Microsoft SQL Server Management Studio
		kulland���m i�in sizin bilgisayar�n�zda da
		bu yaz�l�m�n kurulu olmas� gerekir.	
	</p>
</li>
<li>
	�lk ad�m� tamamlad�ktan sonra projeyi
	a��n ve DataAccess Class Library b�l�m�ne gidin
	. Ard�ndan, Concrete klas�r� i�inde yer alan
	MsSqlContext.cs dosyas�ndaki Server alan�na 
	kendi bilgisayar�n�zdaki SQL Server ad�n� girin.
	
</li>
<li>Nuget consoldan Data Acces katman�na gelip 
	<p style ="color:#cfb;" > Update-Database</p> diyip veri taban�n� olu�turun
</li>
<li> Veri taban� ba�ar�yla olu�turulduysa
projeyi �al��t�rabilirsiniz. �u anda Seed Data
tan�mlanmad��� i�in varsay�lan bir kullan�c� 
bulunmamaktad�r. Bu nedenle giri� yapabilmek
i�in veri taban�ndaki Kullanicilar tablosuna
manuel olarak bir kullan�c� ekleyip rol�n� admin
olarak ayarlaman�z gerekmektedir

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











