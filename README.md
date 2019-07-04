# smalert-HexagoNN

Este repositorio contiene el código desarrollado para dar solución a un reto del **Hackathon: Un llamado por Colombia**. Se desarrolló dos tecnologías nativas:

+ Aplicación móvil en Android que genera alertas tempranas y se alimenta de una base de datos en Cloudant de IBM.
+ RPA que extrae datos de la plataforma SIATA de los sensores de nivel de las cuencas hídricas del Valle de Aburrá y sube automáticamente a la base de datos alojada en Cloudant de donde se alimenta la app para generar las alertas.

## Carpetas:

#### RPA_SIATA
Esta carpeta contiene el RPA para la extracción de datos de la plataforma SIATA, desarrollada en Python 3 y conectado a Cloudant de IBM.

#### SMALERT_APP
En esta carpeta se encuentra el código de la app Smalert realizada en Unity y el APK correspondiente.
