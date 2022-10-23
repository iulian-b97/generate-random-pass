# Generate Random Password (ASP.NET Core 5 - MVC(Model-View-Controller))
#
   Technology and libraries used: 
#
        .NET Core 5 - MVC, SQL Server, C#, EntityFramework, BCrypt, HTML, CSS
#

#
# 1.Generate User Password
# 
 Avem ca data de intrare un 'userId' si 'dateTimeNow'(timpul la care este generat automat cand este generata parola).
 Daca 'userId' introdus nu exista acesta va fi creat si de asemenea se va genera si parola.
 Daca 'userId' introdus exista se va genera doar o parola noua.
 Din momentul generarii parolei aceasta este valida maxim 30 de secunde.
#
![alt text](https://github.com/iulian-b97/generate-random-pass/blob/main/_screens/s1.jpg)
![alt text](https://github.com/iulian-b97/generate-random-pass/blob/main/_screens/s2.jpg)
![alt text](https://github.com/iulian-b97/generate-random-pass/blob/main/_screens/s7.jpg)
#
# 2.Check User Password
# 
  Aici putem verifica daca parola introdusa este una existenta sau daca mai este valida.
#
![alt text](https://github.com/iulian-b97/generate-random-pass/blob/main/_screens/s3.jpg)
# 
  Acest mesaj va fi afisat atunci cand parola introdusa este existenta cat si valida.
#
![alt text](https://github.com/iulian-b97/generate-random-pass/blob/main/_screens/s4.jpg)
# 
  Acest mesaj va fi afisat atunci cand parola introdusa nu mai este valida.
#
![alt text](https://github.com/iulian-b97/generate-random-pass/blob/main/_screens/s5.jpg)
# 
  Acest mesaj va fi afisat atunci cand parola introdusa nu este existenta.
#
![alt text](https://github.com/iulian-b97/generate-random-pass/blob/main/_screens/s6.jpg)

