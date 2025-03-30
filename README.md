# T1. PR1. Seguretat i vulnerabilitat

# **1. L’organització OWASP Foundation va actualitzar en 2021 el seu Top 10 de vulnerabilitats més trobades en aplicacions web.**

**1 - A07:2021 – Fallas de Identificación y Autenticación**

Son falles en la confirmacio de la identitat, la autenticacio i en la gestio de sesions dels usuaris.
Permet atacs automatitzats com la reutilització de credencials conegudes, on l'atacant té una llista de parells d'usuari i contrasenya vàlids. 
Exposa l'identificador de sessió a la URL.
Emmagatzema les contrasenyes en text clar, xifrades o utilitzant funcions de hash febles.

Mesures per evitar-les:

1.Implementeu un control contra contrasenyes febles, tal com verificar que una nova contrasenya o la utilitzada en el canvi de contrasenya no estigui inclosa a la llista de les 10,000 pitjors contrasenyes.

2. Quan sigui possible, implementeu l'autenticació multifactor per evitar atacs automatitzats de reutilització de credencials conegudes, força bruta i reús de credencials robades.

3. Assegureu-vos que el registre, la recuperació de les credencials i l'ús d'APIs no permeten els atacs d'enumeració d'usuaris mitjançant la utilització dels mateixos missatges genèrics a totes les sortides.

**2 - A10:2021 – Falsificación de Solicitudes del Lado del Servidor (SSRF)**

Les falles de SSRF tenen lloc quan una aplicació web està obtenint un recurs remot sense validar l'URL proporcionada per l'usuari. Permet que un atacant coaccioni a l'aplicació perquè enviï una sol·licitud falsificada a una destinació inesperada.



[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-22041afd0340ce965d47ae6ef1cefeee28c7c493a6346c4f15d667ab976d596c.svg)](https://classroom.github.com/a/S9WTUTwx)
