Lekser

Zmienić plik tekstowy z działaniami matematycznymi w strumień tokenów.
3 metody do wyboru:
- if'y
- automat skończony
- regex


Rodzaje symboli leksykalnych (tokenów):
operator (+ - * /)
nawias ( ( ) )
liczba całkowita
liczba zmiennoprzecinkowa (z kropką)
identyfikator (litera+cyfry lub litera) (identyfikator nie może zaczynać się od cyfr)

bez uwzględniania równań

np.
x12+7.5
identyfikator	x12
operator plus	+
liczba zmienno.	7.5

123x+2.5
liczba całk.	123

w pliku mogą być błędne dane, np.
123.23.23
123.a
12x
x12
++
( JJJJJJ )


x12+7.5
123x+2.5
3-7
10 / 3
x * y - z
zmienna1 + zmienna2
w1a*w2b
10.3-alfa
0.685739*5
(x+y)*z
(a * a) + b
(0.1 - beta) + 8