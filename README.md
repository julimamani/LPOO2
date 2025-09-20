
### `README.md`

# LPOO2 - Práctica de Laboratorio de Programación Orientada a Objetos 2

¡Bienvenido al repositorio **LPOO2**\! Este proyecto fue desarrollado como parte del curso de **Laboratorio de Programación Orientada a Objetos 2**. Es una aplicación de escritorio construida con Java que demuestra la integración de tecnologías backend modernas para la gestión de datos persistentes.

-----

### Visión General del Proyecto

Esta aplicación de escritorio sirve como una práctica de laboratorio para aplicar los principios de la programación orientada a objetos en un entorno de desarrollo real. El proyecto se centra en la conexión y manipulación de una base de datos utilizando el framework Spring Boot y el ORM Hibernate, junto con una base de datos MySQL.

-----

### Características Clave

  * **Aplicación de Escritorio**: Interfaz de usuario construida con Java.
  * **Conexión a Base de Datos**: Persistencia de datos gestionada a través de una base de datos MySQL.
  * **Spring Boot**: Framework principal para la configuración y el desarrollo backend.
  * **Hibernate**: Mapeo Objeto-Relacional (ORM) para la interacción con la base de datos sin escribir consultas SQL nativas.

-----

### Tecnologías Utilizadas

  * **Java**: Lenguaje de programación principal.
  * **Spring Boot**: Framework para el backend.
  * **Hibernate**: ORM para la persistencia.
  * **MySQL**: Sistema de gestión de bases de datos.
  * **Maven/Gradle**: Para la gestión de dependencias del proyecto.

-----

### Requisitos Previos

Antes de ejecutar la aplicación, asegúrate de tener instalado lo siguiente:

  * **Java Development Kit (JDK)**: Versión 8 o superior.
  * **Maven** o **Gradle**: Para construir y gestionar las dependencias del proyecto.
  * **MySQL**: Una instancia de MySQL para la base de datos.
  * **IDE** (opcional): Un entorno de desarrollo integrado como IntelliJ IDEA o Visual Studio Code.

-----

### Cómo Compilar y Ejecutar

1.  **Clona el repositorio**:

    ```bash
    git clone https://github.com/julimamani/LPOO2.git
    ```

2.  **Configura la base de datos**:

      * Crea una base de datos llamada `[nombre-de-tu-db]` en tu instancia de MySQL.
      * Actualiza las credenciales de conexión en el archivo de configuración de Spring Boot (`application.properties` o `application.yml`).

3.  **Compila y ejecuta la aplicación**:

      * **Con Maven**:
        ```bash
        cd LPOO2
        mvn spring-boot:run
        ```
      * **Con Gradle**:
        ```bash
        cd LPOO2
        gradle bootRun
        ```

-----

### Contacto
www.linkedin.com/in/julieta-mamani-perez

-----

### Licencia

Este proyecto está bajo la Licencia MIT.
