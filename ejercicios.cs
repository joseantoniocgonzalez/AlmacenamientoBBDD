IES Gonzalo Nazareno
Administración de Sistemas Gestores de Bases de Datos

PRÁCTICA TEMA 5: ALMACENAMIENTO
TIPO B

Puntuación Máxima: 100 puntos.

ORACLE:

1. Establece que los objetos que se creen en el TS1 (creado por tí) tengan un tamaño inicial de 200K, y que cada extensión sea del doble del tamaño que la anterior. El número máximo de extensiones debe ser de 3.

2. Crea dos tablas en el tablespace recién creado e inserta un registro en cada una de ellas. Comprueba el espacio libre existente en el tablespace. Borra una de las tablas y comprueba si ha aumentado el espacio disponible en el tablespace. Explica la razón.

3. Convierte a TS1 en un tablespace de sólo lectura. Intenta insertar registros en la tabla existente. ¿Qué ocurre?. Intenta ahora borrar la tabla. ¿Qué ocurre? ¿Porqué crees que pasa eso?

4. Crea un espacio de tablas TS2 con dos ficheros en rutas diferentes de 1M cada uno no autoextensibles. Crea en el citado tablespace una tabla con la clausula de almacenamiento que quieras. Inserta registros hasta que se llene el tablespace. ¿Qué ocurre?

5. Realiza una consulta al diccionario de datos que muestre qué índices existen para objetos pertenecientes al esquema de SCOTT y sobre qué columnas están definidos. Averigua en qué fichero o ficheros de datos se encuentran las extensiones de sus segmentos correspondientes.

6. Resuelve el siguiente caso práctico en ORACLE:

En nuestra empresa existen tres departamentos: Informática, Ventas y Producción. En Informática trabajan tres personas: Pepe, Juan y Clara. En Ventas trabajan Ana y Eva y en Producción Jaime y Lidia.

a) Pepe es el administrador de la base de datos. Juan y Clara son los programadores de la base de datos, que trabajan tanto en la aplicación que usa el departamento de Ventas como en la usada por el departamento de Producción. Ana y Eva tienen permisos para insertar, modificar y borrar registros en las tablas de la aplicación de Ventas que tienes que crear, y se llaman Productos y Ventas, siendo propiedad de Ana. Jaime y Lidia pueden leer la información de esas tablas pero no pueden modificar la información. Crea los usuarios y dale los roles y permisos que creas conveniente.

b) Los espacios de tablas son System, Producción (ficheros prod1.dbf y prod2.dbf) y Ventas (fichero vent.dbf). Los programadores del departamento de Informática pueden crear objetos en cualquier tablespace de la base de datos, excepto en System. Los demás usuarios solo podrán crear objetos en su tablespace correspondiente teniendo un límite de espacio de 30 M los del departamento de Ventas y 100K los del de Producción. Pepe tiene cuota ilimitada en todos los espacios, aunque el suyo por defecto es System.

c) Pepe quiere crear una tabla Prueba que ocupe inicialmente 256K en el tablespace Ventas.

d) Pepe decide que los programadores tengan acceso a la tabla Prueba antes creada y puedan ceder ese derecho y el de conectarse a la base de datos a los usuarios que ellos quieran.

e) Lidia y Jaime dejan la empresa, borra los usuarios y el espacio de tablas correspondiente, detalla los pasos necesarios para que no quede rastro del espacio de tablas.

Postgres:

7. Averigua si existe el concepto de segmento y el de extensión en Postgres, en qué consiste y las diferencias con los conceptos correspondientes de ORACLE.


# Conceptos de Segmento y Extensión en PostgreSQL vs. Oracle

Oracle y PostgreSQL gestionan el almacenamiento de datos de manera diferente, lo que se refleja en sus conceptos de segmentos y extensiones.

## Oracle

En Oracle, un **segmento** es un conjunto de estructuras de almacenamiento, como tablas o índices, que ocupan espacio de almacenamiento. Un **segmento** se compone de uno o más **extensiones**, que son unidades de espacio que se asignan a un segmento cuando este necesita crecer. Los segmentos y extensiones son fundamentales en la gestión del espacio en Oracle, permitiendo un control detallado y flexible del almacenamiento de datos.

- **Características clave**:
  - Los segmentos se clasifican por tipo, incluyendo segmentos de tabla, segmentos de índice, y otros.
  - Las extensiones permiten el crecimiento dinámico de los segmentos según la demanda.

## PostgreSQL

PostgreSQL no utiliza los términos **segmento** y **extensión** como tales. En su lugar, gestiona el almacenamiento a través de un conjunto de archivos en el sistema de archivos del servidor. La unidad básica de almacenamiento en PostgreSQL es el **bloque**, típicamente de 8KB, y las tablas se almacenan en un conjunto de archivos de un gigabyte llamados **"forks"**. Cuando una tabla o índice crece más allá del tamaño de un archivo, PostgreSQL crea automáticamente un nuevo archivo (o "fork").

- **Características clave**:
  - El almacenamiento de datos se basa en archivos que pueden expandirse según sea necesario, pero el concepto es más abstracto que en Oracle y menos visible para el administrador de la base de datos.
  - PostgreSQL maneja internamente el crecimiento de los archivos de datos y la asignación de espacio sin necesidad de una intervención manual detallada en términos de segmentos y extensiones.

## Comparación y Diferencias Clave

- **Gestión del Espacio**: Oracle proporciona una gestión detallada del espacio a través de segmentos y extensiones, mientras que PostgreSQL maneja el espacio de manera más automática y abstracta.
- **Visibilidad para el Administrador**: Oracle permite a los administradores de bases de datos tener un control y una visibilidad más detallados sobre cómo se asigna y utiliza el espacio en disco. En PostgreSQL, este proceso es más automatizado y menos transparente.
- **Flexibilidad y Control**: Oracle ofrece más flexibilidad y control en la administración del espacio de almacenamiento, lo cual es esencial en entornos empresariales grandes y complejos. PostgreSQL simplifica la gestión del espacio, lo que puede ser beneficioso para sistemas más pequeños o para aquellos que prefieren una administración menos compleja.

## Fuentes para Consulta

- **PostgreSQL Documentation**: Para comprender en profundidad cómo PostgreSQL gestiona el almacenamiento de datos.
  - [PostgreSQL Storage System](https://www.postgresql.org/docs/current/storage.html)

- **Oracle Documentation**: Para detalles sobre la gestión de segmentos y extensiones en Oracle.
  - [Managing Space for Schema Objects in Oracle](https://docs.oracle.com/en/database/oracle/oracle-database/19/admin/managing-space-for-schema-objects.html)

Estas diferencias reflejan las filosofías de diseño y los objetivos de uso de cada sistema de gestión de bases de datos, con Oracle enfocándose en ofrecer gran control y flexibilidad en entornos empresariales, mientras que PostgreSQL busca simplificar la gestión del almacenamiento y la administración de la base de datos.





MySQL:


8. Averigua si existe el concepto de espacio de tablas en MySQL y las diferencias con los tablespaces de ORACLE.


Tanto MySQL como Oracle utilizan el concepto de espacios de tablas (tablespaces) pero con diferencias notables en su implementación y uso.

## Espacios de Tablas en MySQL

En MySQL, un espacio de tablas es una unidad de almacenamiento que consiste en uno o más archivos en el sistema de archivos que almacenan los datos para una o más tablas y sus índices. Los espacios de tablas permiten a MySQL gestionar el almacenamiento de datos de manera eficiente.

- **Características clave**:
  - A partir de MySQL 5.6, se introdujo la característica de tablespaces generales que permite a los usuarios definir tablespaces fuera del sistema de archivos de base de datos predeterminado.
  - MySQL 8.0 expande las capacidades de los tablespaces, incluyendo la posibilidad de crear tablespaces para InnoDB que pueden albergar múltiples tablas.
  - Permite una mejor gestión del almacenamiento y optimización del rendimiento.

- **URLs para consulta**:
  - [MySQL Tablespaces](https://dev.mysql.com/doc/refman/8.0/en/general-tablespaces.html)
  - [InnoDB Tablespaces](https://dev.mysql.com/doc/refman/8.0/en/innodb-tablespace.html)

## Tablespaces en Oracle

Oracle utiliza tablespaces como la estructura principal de almacenamiento para organizar y almacenar los datos. Un tablespace en Oracle puede contener distintos tipos de objetos de base de datos, como tablas, índices, y grandes objetos (LOBs). 

- **Características clave**:
  - Los tablespaces en Oracle pueden ser de varios tipos, como pequeños y grandes archivos (smallfile y bigfile).
  - Oracle permite una gestión avanzada de tablespaces, incluyendo tablespaces temporales y de deshacer, así como la capacidad de transportar tablespaces entre distintas bases de datos.
  - Ofrece funcionalidades avanzadas de segmentación y particionamiento dentro de los tablespaces para optimizar el rendimiento y la gestión del espacio.

- **URLs para consulta**:
  - [Managing Tablespaces in Oracle](https://docs.oracle.com/en/database/oracle/oracle-database/19/admin/managing-tablespaces.html)
  - [Oracle Tablespaces](https://docs.oracle.com/cd/B28359_01/server.111/b28310/tspaces001.htm)

## Diferencias Clave

- **Flexibilidad y Uso**: Oracle ofrece una mayor flexibilidad en la gestión de tablespaces, incluyendo tipos especializados y avanzadas capacidades de administración. MySQL, aunque ha mejorado su soporte de tablespaces, se enfoca en simplicidad y eficiencia dentro de su modelo de gestión.
- **Soporte Multitable**: MySQL desde la versión 5.7 permite tablespaces generales que pueden contener múltiples tablas, un concepto que Oracle ha soportado desde hace mucho tiempo con sus tablespaces que pueden albergar diversos tipos de objetos de base de datos.
- **Funcionalidades Avanzadas**: Oracle ofrece funcionalidades más avanzadas como tablespaces temporales y de deshacer, y la capacidad de transportar tablespaces entre bases de datos, lo cual es particularmente útil en entornos empresariales y de alta disponibilidad.

Estas diferencias reflejan las filosofías subyacentes de cada sistema de gestión de bases de datos, con Oracle apuntando a entornos empresariales de gran escala y MySQL ofreciendo una solución eficiente y de fácil manejo.


MongoDB:

9. Averigua si existe la posibilidad en MongoDB de decidir en qué archivo se almacena una colección.




# Almacenamiento de Colecciones en MongoDB

En MongoDB, la asignación directa de colecciones a archivos específicos en el sistema de archivos no es una característica disponible para los usuarios. La gestión del almacenamiento es manejada de manera automática por MongoDB, siguiendo un enfoque que abstrae los detalles de almacenamiento a nivel de archivo para simplificar la administración de la base de datos.

## Métodos Indirectos de Influencia en el Almacenamiento

Aunque no se puede decidir directamente el archivo específico para una colección, existen algunas características y técnicas que permiten influir de manera indirecta en cómo y dónde se almacenan los datos:

### 1. Sharding

- **Descripción**: Distribuye los datos de una base de datos entre varios servidores (shards).
- **Propósito**: Permite la escalabilidad horizontal, pero no controla el almacenamiento a nivel de archivos individuales dentro de un servidor.

### 2. Particiones a Nivel de Sistema Operativo o Almacenamiento

- **Descripción**: Configurar el sistema de archivos o soluciones de almacenamiento para designar en qué dispositivo físico o partición se almacenan los datos de MongoDB.
- **Propósito**: Afecta a toda la instancia de MongoDB y no a colecciones individuales, basándose en la configuración del directorio de datos.

### 3. WiredTiger Storage Engine

- **Descripción**: Motor de almacenamiento predeterminado de MongoDB, que gestiona cómo se almacenan los datos en el disco.
- **Propósito**: Ofrece optimización automática del almacenamiento y el rendimiento de los datos, sin permitir asignación de colecciones a archivos específicos.

## Conclusión
MongoDB está diseñado para manejar el almacenamiento de datos de forma eficiente y automática, sin requerir ni permitir la intervención manual en la asignación específica de colecciones a archivos. Este diseño busca simplificar la administración de la base de datos y optimizar el rendimiento y la escalabilidad sin sacrificar la flexibilidad.




# Recursos y Fuentes consultadas sobre MongoDB


## Documentación Oficial de MongoDB


- [MongoDB Documentation](https://docs.mongodb.com/)

## MongoDB University


- [MongoDB University](https://university.mongodb.com/)

## Foro de la Comunidad MongoDB


- [MongoDB Community Forums](https://www.mongodb.com/community/forums/)

## MongoDB Blog


- [MongoDB Blog](https://www.mongodb.com/blog)

## WiredTiger Documentation


- [WiredTiger Documentation](http://source.wiredtiger.com/)
