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

## **2. Obre el següent enllaç (sql inseckten) i realitza un mínim de 7 nivells fent servir tècniques d’injecció SQL. **

  1. level 1:
     ```
     SELECT username 
     FROM users 
     WHERE username ='jane' --' AND password ='d41d8cd98f00b204e9800998ecf8427e';
     ```
  2. level 2:
     ```

     ```

[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-22041afd0340ce965d47ae6ef1cefeee28c7c493a6346c4f15d667ab976d596c.svg)](https://classroom.github.com/a/S9WTUTwx)
