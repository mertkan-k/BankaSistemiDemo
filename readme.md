Banka Sistemi

Uygulama dizini: BankSystem\bin\Release\BankSystem.exe 
Proje raporu dizini: proje_raporu.pdf
Proje raporu linki: https://github.com/mertkan-k/BankaSistemiDemo/blob/master/proje_raporu.pdf
Proje video linki: https://youtu.be/KnP-qOekXGw
Kulanilan tasarim desenleri: Singleton Pattern ve Factory Pattern (pdf dosyasinda detali aciklama bulunuyor)

Genel olarak kullan�c� ve y�neticilerin giri� yap�p birtak�m i�lemler ger�ekle�tirebildikleri basit ve anla��l�r aray�zl� bir uygulama.

Veri deposu olarak iki adet json dosyas� �zerinden i�lemler yap�l�yor, bu dosyalar� bu program d���nda bir ara�la editlemenizi tavsiye etmiyoruz, zira dosyalarda bozulma olmas� halinde sistem hata verip kapanacakt�r.
E�er bu gibi bir sorun ya�arsan�z dosyalar� silip sistemin default olarak bu dosyalar� tekrar olu�turmas�n� sa�layabilirsiniz.
Sistem, dosyalar� kendisi olu�turdu�unda ve ya y�netici hesab�n� bulamad���nda otomatik olara 'root' isminde ve '12345' �ifresiyle bir y�netici hesab� olu�turacakt�r.

Uygulamaya giri� yapt���n�zda sizden kullan�c� ve �ifre istemektedir, hen�z bir hesab�n� yoksa istedi�iniz bilgileri girerek 'Kay�t ol' butonuna t�klayarak kay�t olabilir ve ard�ndan 'Giri� Yap' butonuna t�klayarak giri� yapabilirsiniz.
Kay�t olurken sistem otomatik oalrak sitemdeki en b�y�k kullan�c� numaras�na g�re size bir kullan�c� numaras� ataamktad�r.
E�er halihaz�rda kullan�lan bir kullan�c� ad� girerseniz hata al�rs�n�z.

Hesab�n�za her giri� yapt���n�zda(do�rudan giri�, y�netim panelinden de�il) giri�iniz kay�t alt�na al�n�r.

Yeni bir kullan�c� olu�turuldu�unda, bu kullan�c�ya sistem taraf�ndan belli bir miktar(ilgili .cs dosyas�nda) bakiye verilir.

Normal(Y�netici olmayan) bi hesaba girdi�inizde yapabilece�iniz i�lemler:
1- Havale/Eft:
	Sistemde default olarak bir banka tan�mlanm�� ve t�m hesaplar bu bankaya y�nlendirilmi�tir.
	Bu sayfada �ncelikle ge�erli bir kullan�c� numaras� girmelisiniz.
	Girdi�iniz numara bakiye aktaraca��n�z hesab�n numaras�d�r ve bu numara, hesab�n�za giri� yapt���n�zda sol �stte '#' den sonra b�l�mde bulunmaktad�r.
	Kendi numaran�z� girmeniz durumda sistem bunu alg�lay�p devam etmenize izin vermeyecektir.
	G�venlik ama�l� olarak, ge�rli bir numara girdi�inizde bu numaraya ait kullan�c�n�n isminin sadece ilk ve son hanesini g�rebilirsiniz.
	Daha sonras�nda i�leme g�nderilecek miktar� girerek devam ediyorsunuz.
	Girdi�iniz miktar ge�erli ise(bakiyenize uygun) son olarak hesap �ifrenizi girip 'Havale Yap' butonuna t�klayarak i�lemi bitirebilirsiniz.
	E�er �ifreniz yanl�� ise sistem bunu belirtip sizi tekrar �ifre girme alan�na y�nlendirecektir.
	Baz� durumlarda(kar� taraf�n bakiyesinin ulong long'u a�mas� vs.) i�lem ba�ar�s�z olur ve bilgilendirme metninide belirtilir.
	��lem ba�ar�l� bir �ekilde ger�ekle�ti�inde hesap bakiyeniz yenilenir ve havale i�lemi her iki hesaba da kay�t al�n�r.
	

2- �deme Yap/Fatura �de:
	Bir kullan�c�ya d�eil de bir �irkete �deme yapaca��n�z alan.
	�ncelikle i�merkezinin numaras�n� girmelisiniz.
	Sistemde varsay�lan olarak iki adet tan�mlanm��t�r: 1-N11 2-Hepsiburada 3-Trendyol 4-Amazon
	Bu veriler ilgili .cs dosyas�nda kolayca de�i�tirilebilir.
	Ge�erli bir i�merkezi numaras� girdi�inizde logosunun ve isminin yazd���n�, ayr�ca �deme miktar�n�n aktif hale geldi�ini g�rebilirsiniz.
	��lemlere Havale i�lemlerinde oldu�u gibi devam edip i�lemleri sonrand�rabilirsini.
	Ba�ar�l� bir i�lem sonras�nda hesab�n�zda kay�t olu�turulur.
	

3- ��lem Ge�mi�i:
	Hesab�n�zda yapt���n�z t�m i�lemleri tarihi ve i�lem sonras� bakiyesiyle birlikte g�r�nt�leyebilirsiniz.
	�sterseniz siz kontrol ederken de�i�iklik olma ihtimaline kar�� 'Yenile' butonuna t�klayarak kay�tlar� sistemden tekrar �ekebilirsiz.
	

4- Yenile:
	Siz hesab�n�za giri� yapt�ktan sonra d��ar�dan i�lemler ger�ekle�mi�se baz� durumlarda ekranda g�r�nt�ledi�iniz veriler yenilenmemi� olabilir.
	Bu durumlara kar�� bu butonu kullanabilirsiniz.
	

5- �ifre De�i�tir:
	�ifrenizi de�i�tirebilece�iz alana y�nlendirilirsiniz.
	Bu alanda �ncelikle eski �ifrenizi girmelisiniz.
	�ifrenizi girdikten sonra yeni �ifrenizi iki defa girmelisiniz.
	Yeni girdi�iniz �ifreler ayn� de�il ise sistem devam etmenize izin vermeyeceektir.
	Ba�ar�l� bir i�lem sonras�nda hesab�n�zda kay�t olu�turulur.
	

Y�netici hesab�yla giri� yapt���n�zda ise sistem sizi otomatik olarak y�netici paneline y�nlendirecektir.
Bu panelde yapabilece�iniz i�lemler:
1- T�m Kullan�c�lar:
	Y�neticiler de dahil olmak �zere t�m kullan�c�lar�n bilgilerini a��k �ekilde g�r�nt�leyebilece�iniz ve de�i�tirebilece�iniz alan.
	Sadece istedi�iniz kullan�c� se�in ve bilgilerini de�i�tirip 'Kaydet' butonuna t�klay�n.
	De�i�iklikleri yapmaktan vazge�tiyseniz 'Geri Al' butonuna t�klayarak ilgili alanlar�n eski haline gelmesini sa�layabilirsiniz.
	�sterseniz 'Hesab�na Gir' butonuna t�klayarak se�ti�iniz kullan�c�n paneline do�rudan giri� yapabilirsiniz. Bu durum kay�t alt�na al�nacakt�r.
	

2- ��lem Ge�mi�i:
	Y�neticiler de dahil t�m kullan�c�lara ait t�m kay�tlar� g�r�nt�leyebilece�iniz alan.
	

3- Kullan�c� Giri�i:
	Hesab�n�za y�netici olarak de�il de standart bir kullan�c� gibi giri� yap�n.
	

4- Loglar� S�f�rla:
	Y�netici de dahil t�m hesaplara ait kay�tlar� temizler.
	Bu i�lem, hesab�n�zda kay�t alt�na al�n�r.

5- Kullan�c�lar� S�f�rla:
	Y�netici d���ndaki t�m hesaplar� ve bu hesaplara ait t�m loglar�n silinmesini sa�lar.
	Bu i�lem, hesab�n�zda kay�t alt�na al�n�r.
	Kullanmadan �nce bir kere daha d���n�n.
