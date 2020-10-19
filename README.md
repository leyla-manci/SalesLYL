# SalesLYL
c#,.net,razor,html,ajax.googleapis,jquery,bootstrap,fontawesome,javascript,mvc,sql
***

<p>
Örnek proje, bir fatura giriş uygulaması olacaktır. Kullanıcı adı ve şifreyle uygulamaya girdikten sonra, bir ekran vasıtasıyla fatura girişi yapabilmeliyiz. Fatura ekranının yapısı, alanları, ve dizaynı tamamen size ait. Bir faturada kabaca size hangi alanlar olması gerekiyorsa onları koyabilirsiniz. Faturanın hesap kitap kısmını düşünmeyin. Birim fiyat * miktar şeklinde bir hesaplama yeterlidir. Vergisel hesaplamalara girmenize gerek yok. Girdiğimiz fatura kayıtlarını izleyip, değiştirip, silebilmeliyiz. Arayüz tasarım tamamen size kalmış. Teknoloji olarak, tercihen webapi, ve angular js talep ediyoruz. Bu teknolojilere hakim değilseniz, mvc, ve bildiğiniz bir javascript frameworkde olur. Entitiyframework gibi bir framework kullanılmasını istemiyoruz. Veritabanı olarak sql server kullanılacak. Örnek proje tamamlandıktan sonra, tüm kodlarla birlikte, veritabanının backup’ınıda göndermelisiniz. Proje süreniz 3 gündür.
NOT : Db backup’ını alırken sql server 2016 uyumlu olarak alırsanız sevinirim.</p>
</br>
***   

  -  structure : Model-View-Controller </br>
  -  DbRepository  : bu sınıf dbConnectStrin bağlantısı ile sunucu bağlantısını sağlayarak, veritabanı etkileşim işlemlerini(CRUD) yapar</br>
  -  statik olarak en fazla 3 kalem eklenmekte : düzenle ve yeni oluşturma işlemlerinde dinamik kalem ekleme-silme özelliği sonraki versiyonda eklenebilir.</br>
  -  herhangi bir orm aracı kulanılmadı: entityframework vb. kullanılmadı,row sql stringleri ile işlemler yapıldı</br>
  - _prtsc klasöründe db script i ve ekran alıntıları mevcut</br>
  -  login ; user:admin pass : admin</br>
  

   
*** 

   <b>  Screen Shots </b> 
   </br>
   
<table><tr><td>
 <img src="https://github.com/leyla-manci/SalesLYL/blob/master/_prtsc/login.png">
* Login Page
    </br>
    </br>
 </td>
   </tr>
 <tr>
 <td>
  <img src="https://github.com/leyla-manci/SalesLYL/blob/master/_prtsc/invoicelist.png">
* Invoice List  </br>
    </br>
 </td>
</tr>
 <tr>
 <td>
  <img src="https://github.com/leyla-manci/SalesLYL/blob/master/_prtsc/edit-invoice.png">
* edit invoice  </br>
    </br>
 </td></tr>
 <tr>
 <td>
  <img src="https://github.com/leyla-manci/SalesLYL/blob/master/_prtsc/show-invoice.png">
* show invoice  </br>
    </br>
 </td>
 </tr>
<tr>
 <td>
  <img src="https://github.com/leyla-manci/SalesLYL/blob/master/_prtsc/connection-string-config.png">
* connection string on config  </br>
    </br>
 </td></tr>
 <tr>
 <td>
  <img src="https://github.com/leyla-manci/SalesLYL/blob/master/_prtsc/full-script4server-2016-with-schema-data.png">
* script for server 2016  </br>
    </br>
 </td></tr>
</table>


***
-Katkı Sunanlar---

* Leyla Akmancı | [leyla.manci@gmail.com](mailto:leyla.manci@gmail.com)
