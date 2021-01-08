Banka Sistemi

Uygulama dizini: BankSystem\bin\Release\BankSystem.exe 
Proje raporu dizini: proje_raporu.pdf
Proje raporu linki: https://github.com/mertkan-k/BankaSistemiDemo/blob/master/proje_raporu.pdf
Proje video linki: https://youtu.be/KnP-qOekXGw
Kulanilan tasarim desenleri: Singleton Pattern ve Factory Pattern (pdf dosyasinda detali aciklama bulunuyor)

Genel olarak kullanýcý ve yöneticilerin giriþ yapýp birtakým iþlemler gerçekleþtirebildikleri basit ve anlaþýlýr arayüzlü bir uygulama.

Veri deposu olarak iki adet json dosyasý üzerinden iþlemler yapýlýyor, bu dosyalarý bu program dýþýnda bir araçla editlemenizi tavsiye etmiyoruz, zira dosyalarda bozulma olmasý halinde sistem hata verip kapanacaktýr.
Eðer bu gibi bir sorun yaþarsanýz dosyalarý silip sistemin default olarak bu dosyalarý tekrar oluþturmasýný saðlayabilirsiniz.
Sistem, dosyalarý kendisi oluþturduðunda ve ya yönetici hesabýný bulamadýðýnda otomatik olara 'root' isminde ve '12345' þifresiyle bir yönetici hesabý oluþturacaktýr.

Uygulamaya giriþ yaptýðýnýzda sizden kullanýcý ve þifre istemektedir, henüz bir hesabýný yoksa istediðiniz bilgileri girerek 'Kayýt ol' butonuna týklayarak kayýt olabilir ve ardýndan 'Giriþ Yap' butonuna týklayarak giriþ yapabilirsiniz.
Kayýt olurken sistem otomatik oalrak sitemdeki en büyük kullanýcý numarasýna göre size bir kullanýcý numarasý ataamktadýr.
Eðer halihazýrda kullanýlan bir kullanýcý adý girerseniz hata alýrsýnýz.

Hesabýnýza her giriþ yaptýðýnýzda(doðrudan giriþ, yönetim panelinden deðil) giriþiniz kayýt altýna alýnýr.

Yeni bir kullanýcý oluþturulduðunda, bu kullanýcýya sistem tarafýndan belli bir miktar(ilgili .cs dosyasýnda) bakiye verilir.

Normal(Yönetici olmayan) bi hesaba girdiðinizde yapabileceðiniz iþlemler:
1- Havale/Eft:
	Sistemde default olarak bir banka tanýmlanmýþ ve tüm hesaplar bu bankaya yönlendirilmiþtir.
	Bu sayfada öncelikle geçerli bir kullanýcý numarasý girmelisiniz.
	Girdiðiniz numara bakiye aktaracaðýnýz hesabýn numarasýdýr ve bu numara, hesabýnýza giriþ yaptýðýnýzda sol üstte '#' den sonra bölümde bulunmaktadýr.
	Kendi numaranýzý girmeniz durumda sistem bunu algýlayýp devam etmenize izin vermeyecektir.
	Güvenlik amaçlý olarak, geçrli bir numara girdiðinizde bu numaraya ait kullanýcýnýn isminin sadece ilk ve son hanesini görebilirsiniz.
	Daha sonrasýnda iþleme gönderilecek miktarý girerek devam ediyorsunuz.
	Girdiðiniz miktar geçerli ise(bakiyenize uygun) son olarak hesap þifrenizi girip 'Havale Yap' butonuna týklayarak iþlemi bitirebilirsiniz.
	Eðer þifreniz yanlýþ ise sistem bunu belirtip sizi tekrar þifre girme alanýna yönlendirecektir.
	Bazý durumlarda(karý tarafýn bakiyesinin ulong long'u aþmasý vs.) iþlem baþarýsýz olur ve bilgilendirme metninide belirtilir.
	Ýþlem baþarýlý bir þekilde gerçekleþtiðinde hesap bakiyeniz yenilenir ve havale iþlemi her iki hesaba da kayýt alýnýr.
	

2- Ödeme Yap/Fatura Öde:
	Bir kullanýcýya dðeil de bir þirkete ödeme yapacaðýnýz alan.
	Öncelikle iþmerkezinin numarasýný girmelisiniz.
	Sistemde varsayýlan olarak iki adet tanýmlanmýþtýr: 1-N11 2-Hepsiburada 3-Trendyol 4-Amazon
	Bu veriler ilgili .cs dosyasýnda kolayca deðiþtirilebilir.
	Geçerli bir iþmerkezi numarasý girdiðinizde logosunun ve isminin yazdýðýný, ayrýca ödeme miktarýnýn aktif hale geldiðini görebilirsiniz.
	Ýþlemlere Havale iþlemlerinde olduðu gibi devam edip iþlemleri sonrandýrabilirsini.
	Baþarýlý bir iþlem sonrasýnda hesabýnýzda kayýt oluþturulur.
	

3- Ýþlem Geçmiþi:
	Hesabýnýzda yaptýðýnýz tüm iþlemleri tarihi ve iþlem sonrasý bakiyesiyle birlikte görüntüleyebilirsiniz.
	Ýsterseniz siz kontrol ederken deðiþiklik olma ihtimaline karþý 'Yenile' butonuna týklayarak kayýtlarý sistemden tekrar çekebilirsiz.
	

4- Yenile:
	Siz hesabýnýza giriþ yaptýktan sonra dýþarýdan iþlemler gerçekleþmiþse bazý durumlarda ekranda görüntülediðiniz veriler yenilenmemiþ olabilir.
	Bu durumlara karþý bu butonu kullanabilirsiniz.
	

5- Þifre Deðiþtir:
	Þifrenizi deðiþtirebileceðiz alana yönlendirilirsiniz.
	Bu alanda öncelikle eski þifrenizi girmelisiniz.
	Þifrenizi girdikten sonra yeni þifrenizi iki defa girmelisiniz.
	Yeni girdiðiniz þifreler ayný deðil ise sistem devam etmenize izin vermeyeceektir.
	Baþarýlý bir iþlem sonrasýnda hesabýnýzda kayýt oluþturulur.
	

Yönetici hesabýyla giriþ yaptýðýnýzda ise sistem sizi otomatik olarak yönetici paneline yönlendirecektir.
Bu panelde yapabileceðiniz iþlemler:
1- Tüm Kullanýcýlar:
	Yöneticiler de dahil olmak üzere tüm kullanýcýlarýn bilgilerini açýk þekilde görüntüleyebileceðiniz ve deðiþtirebileceðiniz alan.
	Sadece istediðiniz kullanýcý seçin ve bilgilerini deðiþtirip 'Kaydet' butonuna týklayýn.
	Deðiþiklikleri yapmaktan vazgeçtiyseniz 'Geri Al' butonuna týklayarak ilgili alanlarýn eski haline gelmesini saðlayabilirsiniz.
	Ýsterseniz 'Hesabýna Gir' butonuna týklayarak seçtiðiniz kullanýcýn paneline doðrudan giriþ yapabilirsiniz. Bu durum kayýt altýna alýnacaktýr.
	

2- Ýþlem Geçmiþi:
	Yöneticiler de dahil tüm kullanýcýlara ait tüm kayýtlarý görüntüleyebileceðiniz alan.
	

3- Kullanýcý Giriþi:
	Hesabýnýza yönetici olarak deðil de standart bir kullanýcý gibi giriþ yapýn.
	

4- Loglarý Sýfýrla:
	Yönetici de dahil tüm hesaplara ait kayýtlarý temizler.
	Bu iþlem, hesabýnýzda kayýt altýna alýnýr.

5- Kullanýcýlarý Sýfýrla:
	Yönetici dýþýndaki tüm hesaplarý ve bu hesaplara ait tüm loglarýn silinmesini saðlar.
	Bu iþlem, hesabýnýzda kayýt altýna alýnýr.
	Kullanmadan önce bir kere daha düþünün.
