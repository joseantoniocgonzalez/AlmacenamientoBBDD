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

MySQL:

8. Averigua si existe el concepto de espacio de tablas en MySQL y las diferencias con los tablespaces de ORACLE.

MongoDB:

9. Averigua si existe la posibilidad en MongoDB de decidir en qué archivo se almacena una colección.
ls


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
