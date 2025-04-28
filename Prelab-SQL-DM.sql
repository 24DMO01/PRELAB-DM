CREATE DATABASE videotienda;-- Crea una nueva base de datos llamada "videotienda" donde se almacenarán todas las tablas relacionadas.
USE videotienda;-- Selecciona la base de datos "videotienda" para empezar a trabajar dentro de ella.


-- Tabla Direccion
CREATE TABLE direccion ( -- Inicia la creación de una tabla llamada "direccion" que guardará información de las direcciones.
    idDireccion INT PRIMARY KEY,   -- Columna de tipo entero que será la clave primaria (identificador único de cada dirección)
    Direccion VARCHAR(45), -- Columna de texto para guardar la dirección (máximo 45 caracteres)
    Ciudad VARCHAR(45),  -- Columna de texto para la ciudad (máximo 45 caracteres)
    Pais VARCHAR(45)    -- Columna de texto para el país (máximo 45 caracteres)
);

INSERT INTO direccion VALUES (1, 'Zona 1', 'Ciudad de Guatemala', 'Guatemala'); -- Inserta un registro en la tabla "direccion" con id 1, ubicado en Zona 1, Ciudad de Guatemala, país Guatemala.
INSERT INTO direccion VALUES (2, 'Zona 10', 'Mixco', 'Guatemala'); -- Inserta un registro en la tabla "direccion" con id 2, Zona 10, ciudad Mixco, país Guatemala.
INSERT INTO direccion VALUES (3, 'Zona 15', 'Ciudad de Guatemala', 'Guatemala'); -- Inserta un registro en la tabla "direccion" con id 3, ubicado en Zona 15, Ciudad de Guatemala, país Guatemala.
INSERT INTO direccion VALUES (4, 'Zona 5', 'Villa Nueva', 'Guatemala'); -- Inserta un registro en la tabla "direccion" con id 4, ubicado en Zona 5, ciudad Villa Nueva, país Guatemala.
INSERT INTO direccion VALUES (5, 'Zona 2', 'Amatitlán', 'Guatemala'); -- Inserta un registro en la tabla "direccion" con id 5, Zona 2, ciudad Amatitlán, país Guatemala.

-- Tabla Cliente
CREATE TABLE cliente (-- Inicia la creación de una tabla llamada "Cliente" que guardará información de los clientes.
    idCliente INT PRIMARY KEY, -- Columna de tipo entero que será la clave primaria (identificador único de cada cliente)
    Nombre VARCHAR(45),   -- Columna de texto para el nombre del cliente
    Apellido VARCHAR(45),  -- Columna de texto para el apellido del cliente
    Edad INT,  -- Columna para la edad del cliente (tipo entero)
    Direccion_idDireccion INT,  -- Columna que servirá para relacionar al cliente con su dirección
    FOREIGN KEY (Direccion_idDireccion) REFERENCES direccion(idDireccion) ON DELETE CASCADE  -- Crea una clave foránea: esta columna debe coincidir con un idDireccion existente en la tabla "direccion" y Si se elimina una dirección, también se eliminarán automáticamente todos los clientes relacionados (por el CASCADE).
    
);
INSERT INTO cliente VALUES (1, 'Juliana', 'Ramirez', 25, 1);-- Inserta en la tabla "cliente" un cliente con id 1, nombre Juliana Ramírez, 25 años, que vive en la dirección con id 1.
INSERT INTO cliente VALUES (2, 'Carlos', 'Lopez', 38, 2);-- Inserta un cliente con id 2, nombre Carlos López, 38 años, dirección con id 2.
INSERT INTO cliente VALUES (3, 'Diego', 'Mencos', 23, 3);-- Inserta un cliente con id 3, nombre Diego Mencos, 23 años, dirección con id 3.
INSERT INTO cliente VALUES (4, 'Luis', 'Pérez', 22, 4);-- Inserta un cliente con id 4, nombre Luis Pérez, 22 años, dirección con id 4.
INSERT INTO cliente VALUES (5, 'Ana', 'Torres', 35, 5);-- Inserta un cliente con id 5, nombre Ana Torres, 35 años, dirección con id 5.

-- Tabla Categoria
CREATE TABLE categoria (-- Inicia la creación de una tabla llamada "categoria" que guardará información de las categorías de las películas.
    idCategoria INT PRIMARY KEY,  -- Columna de tipo entero que será la clave primaria.
    Nombre VARCHAR(45)  -- Columna de texto para el nombre de la categoría (máximo 45 caracteres).
);
INSERT INTO categoria VALUES (1, 'Acción'); -- Inserta la categoría "Acción" con id 1.
INSERT INTO categoria VALUES (2, 'Aventura'); -- Inserta la categoría "Aventura" con id 2.
INSERT INTO categoria VALUES (3, 'Terror');-- Inserta la categoría "Terror" con id 3.
INSERT INTO categoria VALUES (4, 'Romance');-- Inserta la categoría "Romance" con id 4.
INSERT INTO categoria VALUES (5, 'Fantasía'); -- Inserta la categoría "Fantasía" con id 5.

-- Tabla Peliculas
CREATE TABLE peliculas (-- Inicia la creación de una tabla llamada "películas" que guardará información de las películas.
    idPeliculas INT PRIMARY KEY,-- Columna de tipo entero que será la clave primaria.
    Nombre VARCHAR(45), -- Columna de texto para el nombre de la película.
    Duracion INT, -- Columna para la duración de la película en minutos.
    Descripcion TEXT, -- Columna de tipo texto para una descripción más amplia de la película.
    Año INT, -- Columna para el año de estreno de la película.
    Categoria_idCategoria INT,-- Columna para relacionar la película con una categoría.
    FOREIGN KEY (Categoria_idCategoria) REFERENCES categoria(idCategoria) ON DELETE CASCADE-- Clave foránea que conecta una película a una categoría. Si se elimina una categoría, también se eliminarán las películas relacionadas.
);
INSERT INTO peliculas VALUES (1, 'POKEMON1', 90, 'Película animada', 2000, 1); -- Inserta la película "POKEMON1" en la categoría de Acción.
INSERT INTO peliculas VALUES (2, 'Matrix', 130, 'Ciencia ficción', 1999, 2);-- Inserta la película "Matrix" en la categoría Aventura.
INSERT INTO peliculas VALUES (3, 'Titanic', 314, 'Hechos reales', 1997, 3);-- Inserta una versión de "Titanic" en la categoría Terror.
INSERT INTO peliculas VALUES (4, 'Titanic', 195, 'Historia de amor trágica', 1997, 4);-- Inserta otra versión de "Titanic" en la categoría Romance.
INSERT INTO peliculas VALUES (5, 'Inception', 148, 'Sueños dentro de sueños', 2010, 3);-- Inserta la película "Inception" en la categoría Terror.

-- Tabla Inventario
CREATE TABLE inventario (-- Inicia la creación de una tabla llamada "inventario" para controlar copias físicas de las películas.
    idCopiaPeliculas INT PRIMARY KEY,-- Columna de tipo entero que será la clave primaria.
    Peliculas_idPeliculas INT,-- Columna que indica a qué película pertenece la copia.
    Disponible INT,-- Columna que indica si la copia está disponible (1) o no (0).
    FOREIGN KEY (Peliculas_idPeliculas) REFERENCES peliculas(idPeliculas) ON DELETE CASCADE-- Clave foránea que conecta la copia con su película. Si se elimina la película, se elimina también su copia.
);
INSERT INTO inventario VALUES (1, 1, 1);  -- Inserta una copia disponible de la película con id 1.
INSERT INTO inventario VALUES (2, 2, 0); -- Inserta una copia no disponible de la película con id 2.
INSERT INTO inventario VALUES (3, 3, 1);  -- Inserta una copia disponible de la película con id 3.
INSERT INTO inventario VALUES (4, 4, 1); -- Inserta una copia disponible de la película con id 4.
INSERT INTO inventario VALUES (5, 5, 0); -- Inserta una copia no disponible de la película con id 5.

-- Tabla Renta
CREATE TABLE renta ( -- Crear la tabla "renta" para registrar las rentas de películas realizadas por clientes
    idRenta INT PRIMARY KEY, -- Columna de tipo entero que será la clave primaria.
    Fecha_Renta DATE, -- Columna para la fecha en la que se realizó la renta.
    Fecha_Entrega DATE,  -- Columna para la fecha en la que se debe devolver la película.
    Inventario_idCopiaPeliculas INT, -- Columna que relaciona la renta con una copia específica de película.
    Cliente_idCliente INT,  -- Columna que relaciona la renta con un cliente específico.
    FOREIGN KEY (Inventario_idCopiaPeliculas) REFERENCES inventario(idCopiaPeliculas) ON DELETE CASCADE, -- Clave foránea que conecta la renta con la copia rentada.
    FOREIGN KEY (Cliente_idCliente) REFERENCES cliente(idCliente) ON DELETE CASCADE-- Clave foránea que conecta la renta con el cliente que realiza la operación.
);
INSERT INTO renta VALUES (1, '2023-10-01', '2023-10-10', 1, 1); -- Renta del cliente 1 con la copia 1.
INSERT INTO renta VALUES (2, '2023-10-05', '2023-10-12', 2, 2); -- Renta del cliente 2 con la copia 2.
INSERT INTO renta VALUES (3, '2023-10-10', '2023-10-15', 3, 3); -- Renta del cliente 3 con la copia 3.
INSERT INTO renta VALUES (4, '2023-10-11', '2023-10-17', 4, 4); -- Renta del cliente 4 con la copia 4.
INSERT INTO renta VALUES (5, '2023-10-12', '2023-10-19', 5, 5); -- Renta del cliente 5 con la copia 5.

SELECT * FROM categoria; -- Muestra todos los registros de la tabla "categoria".
SELECT * FROM cliente; -- Muestra todos los registros de la tabla "cliente".
SELECT * FROM direccion;  -- Muestra todos los registros de la tabla "direccion".
SELECT * FROM inventario;  -- Muestra todos los registros de la tabla "inventario".
SELECT * FROM peliculas; -- Muestra todos los registros de la tabla "peliculas".
SELECT * FROM renta; -- Muestra todos los registros de la tabla "renta".

SELECT * FROM cliente WHERE Nombre = 'Juliana'; 
-- esto busca en la tabla clientes todos los registros donde el nombre sea "Juliana" 

DELETE  FROM videotienda.peliculas where Nombre = 'POKEMON1';
-- elimina registros de la tabla películas donde el nombre sea  "POKEMON1" 

SELECT * FROM categoria ORDER BY Nombre ASC;
 -- Muestra todas las categorías ordenadas de la A a la Z. 
 
 SELECT * FROM peliculas order by Año desc;
 -- Muestra todas las películas ordenadas del año más reciente al más antiguo. 
 
 SELECT c.Nombre, c.Apellido, d.Ciudad, d.Pais FROM cliente c JOIN direccion d ON c.Direccion_idDireccion = d.idDireccion;
-- Realiza un JOIN entre las tablas "cliente" y "direccion" para mostrar el nombre, apellido, ciudad y país del cliente junto a su dirección.










