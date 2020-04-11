-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
SHOW WARNINGS;
-- -----------------------------------------------------
-- Schema uma
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `uma` ;

-- -----------------------------------------------------
-- Schema uma
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `uma` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci ;
SHOW WARNINGS;
USE `uma` ;

-- -----------------------------------------------------
-- Table `categoria_cliente`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `categoria_cliente` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `categoria_cliente` (
  `id_categoria_cliente` INT NOT NULL AUTO_INCREMENT,
  `nombre_categoria` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id_categoria_cliente`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci
COMMENT = 'Guarda tipo de clientes (preferenciales y normales)';

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `categoria_empleado`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `categoria_empleado` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `categoria_empleado` (
  `id_categoria_empleado` INT NOT NULL AUTO_INCREMENT,
  `nombre_categoria` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`id_categoria_empleado`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;

SHOW WARNINGS;
CREATE UNIQUE INDEX `id_categoria_empleado_UNIQUE` ON `categoria_empleado` (`id_categoria_empleado` ASC) VISIBLE;

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `categoria_producto`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `categoria_producto` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `categoria_producto` (
  `id_categoria_producto` INT NOT NULL AUTO_INCREMENT,
  `nombre_categoria` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`id_categoria_producto`))
ENGINE = InnoDB
AUTO_INCREMENT = 3
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `cliente`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `cliente` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `cliente` (
  `id_cliente` INT NOT NULL auto_increment,
  `id_categoria_cliente` INT NOT NULL,
  `nombre_cliente` VARCHAR(45) NOT NULL,
  `numero_telefono` VARCHAR(9) NULL DEFAULT NULL,
  `correo_electronico` VARCHAR(100) NULL DEFAULT NULL,
  `direccion_cliente` MEDIUMTEXT NULL DEFAULT NULL,
  `RTN` VARCHAR(15) CHARACTER SET 'utf8' NULL DEFAULT NULL,
  `numero_identidad` VARCHAR(15) NULL DEFAULT NULL,
  PRIMARY KEY (`id_cliente`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci
COMMENT = 'Guarda la informacion del cliente';

SHOW WARNINGS;
CREATE UNIQUE INDEX `id_cliente_UNIQUE` ON `cliente` (`id_cliente` ASC) VISIBLE;

SHOW WARNINGS;
CREATE UNIQUE INDEX `numero_telefono_UNIQUE` ON `cliente` (`numero_telefono` ASC) VISIBLE;

SHOW WARNINGS;
CREATE UNIQUE INDEX `correo_electronico_UNIQUE` ON `cliente` (`correo_electronico` ASC) VISIBLE;

SHOW WARNINGS;
CREATE UNIQUE INDEX `RTN_UNIQUE` ON `cliente` (`RTN` ASC) VISIBLE;

SHOW WARNINGS;
CREATE UNIQUE INDEX `numero_identidad_UNIQUE` ON `cliente` (`numero_identidad` ASC) VISIBLE;

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `venta`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `venta` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `venta` (
  `id_venta` INT NOT NULL AUTO_INCREMENT,
  `estado` VARCHAR(30) NOT NULL,
  `fecha_hora` DATETIME NOT NULL,
  `id_cliente` INT NULL DEFAULT NULL,
  `descuento` DECIMAL(9,2) NULL DEFAULT NULL,
  `isv` DECIMAL(9,2) NOT NULL,
  `total` DECIMAL(9,2) NOT NULL,
  PRIMARY KEY (`id_venta`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci
COMMENT = 'Encabezado de la factura';

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `tipo_producto`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `tipo_producto` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `tipo_producto` (
  `id_tipo_producto` INT NOT NULL AUTO_INCREMENT,
  `nombre_tipo` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`id_tipo_producto`))
ENGINE = InnoDB
AUTO_INCREMENT = 4
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;

SHOW WARNINGS;
CREATE UNIQUE INDEX `id_tipo_producto_UNIQUE` ON `tipo_producto` (`id_tipo_producto` ASC) VISIBLE;

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `producto`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `producto` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `producto` (
  `id_producto` INT NOT NULL AUTO_INCREMENT,
  `id_tipo_producto` INT NOT NULL,
  `nombre` VARCHAR(100) NOT NULL,
  `imagen` MEDIUMBLOB NULL DEFAULT NULL,
  `precio_venta` DECIMAL(9,2) NOT NULL,
  PRIMARY KEY (`id_producto`))
ENGINE = InnoDB
AUTO_INCREMENT = 9
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci
COMMENT = 'Guarda el inventario';

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `detalle`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `detalle` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `detalle` (
  `id_detalle` INT NOT NULL AUTO_INCREMENT,
  `id_venta` INT NOT NULL,
  `id_producto` INT NOT NULL,
  `cantidad` INT NOT NULL,
  `precio_venta` DECIMAL(9,2) NOT NULL,
  `subtotal` DECIMAL(9,2) NOT NULL,
  PRIMARY KEY (`id_detalle`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci
COMMENT = 'Detalle de factura';

SHOW WARNINGS;
CREATE INDEX `FK_Producto_idx` ON `detalle` (`id_producto` ASC) VISIBLE;

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `empleado`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `empleado` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `empleado` (
  `id_empleado` INT NOT NULL AUTO_INCREMENT,
  `id_categoria_empleado` INT NOT NULL,
  `nombre_empleado` VARCHAR(100) NOT NULL,
  `numero_identidad` VARCHAR(15) NOT NULL,
  `edad` INT NOT NULL,
  `genero` VARCHAR(10) NOT NULL,
  `direccion` VARCHAR(200) NULL DEFAULT NULL,
  `correo_electronico` VARCHAR(50) NULL DEFAULT NULL,
  `grado_academico` VARCHAR(50) NULL DEFAULT NULL,
  `contraseña_login` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`id_empleado`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci
COMMENT = 'Guarda los empleados';

SHOW WARNINGS;
CREATE UNIQUE INDEX `id_empleado_UNIQUE` ON `empleado` (`id_empleado` ASC) VISIBLE;

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `estante producto`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `estante producto` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `estante producto` (
  `id_estante_producto` INT NOT NULL,
  `id_producto` INT NOT NULL,
  `nombre_estante` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`id_estante_producto`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `producto_general`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `producto_general` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `producto_general` (
  `id_producto_general` INT NOT NULL AUTO_INCREMENT,
  `id_tipo_producto` INT NOT NULL,
  `nombre` VARCHAR(100) NOT NULL,
  `marca` VARCHAR(50) NULL DEFAULT NULL,
  `precio_venta` DECIMAL(9,2) NOT NULL,
  `precio_compra` DECIMAL(9,2) NOT NULL,
  `existencia` INT NOT NULL,
  PRIMARY KEY (`id_producto_general`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `repuesto`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `repuesto` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `repuesto` (
  `id_repuesto` INT NOT NULL AUTO_INCREMENT,
  `id_tipo_producto` INT NOT NULL,
  `id_categoria_producto` INT NOT NULL,
  `nombre` VARCHAR(100) NOT NULL,
  `marca` VARCHAR(50) NOT NULL,
  `año` YEAR NULL DEFAULT NULL,
  `fabricante` VARCHAR(50) NULL DEFAULT NULL,
  `modelo` VARCHAR(50) NOT NULL,
  `precio_compra` DECIMAL(9,2) NOT NULL,
  `precio_venta` DECIMAL(9,2) NOT NULL,
  `existencia` INT NOT NULL,
  PRIMARY KEY (`id_repuesto`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;

SHOW WARNINGS;
CREATE INDEX `FK_tipo_producto_re_idx` ON `repuesto` (`id_tipo_producto` ASC) VISIBLE;

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `servicio`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `servicio` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `servicio` (
  `id_servicio` INT NOT NULL AUTO_INCREMENT,
  `id_tipo_producto` INT NOT NULL,
  `nombre` VARCHAR(100) NOT NULL,
  `precio` DECIMAL(9,2) NOT NULL,
  PRIMARY KEY (`id_servicio`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;

SHOW WARNINGS;
CREATE INDEX `FK_id_tipo_producto_idx` ON `servicio` (`id_tipo_producto` ASC) VISIBLE;

SHOW WARNINGS;
USE `uma`;

DELIMITER $$

USE `uma`$$
DROP TRIGGER IF EXISTS `Guardar_en_Productos` $$
SHOW WARNINGS$$
USE `uma`$$
CREATE
DEFINER=`root`@`localhost`
TRIGGER `uma`.`Guardar_en_Productos`
AFTER INSERT ON `uma`.`producto_general`
FOR EACH ROW
BEGIN
insert into producto (id_tipo_producto ,nombre, precio_venta) values ( 1,NEW.nombre,NEW.precio_venta);
END$$

SHOW WARNINGS$$

USE `uma`$$
DROP TRIGGER IF EXISTS `Guardar_en_Productos_repuesto` $$
SHOW WARNINGS$$
USE `uma`$$
CREATE
DEFINER=`root`@`localhost`
TRIGGER `uma`.`Guardar_en_Productos_repuesto`
AFTER INSERT ON `uma`.`repuesto`
FOR EACH ROW
BEGIN
insert into producto (id_tipo_producto , nombre, precio_venta) values ( 2,NEW.nombre,NEW.precio_venta);
END$$

SHOW WARNINGS$$

USE `uma`$$
DROP TRIGGER IF EXISTS `Guardar_en_Productos_servicio` $$
SHOW WARNINGS$$
USE `uma`$$
CREATE
DEFINER=`root`@`localhost`
TRIGGER `uma`.`Guardar_en_Productos_servicio`
AFTER INSERT ON `uma`.`servicio`
FOR EACH ROW
BEGIN
insert into producto (id_tipo_producto ,nombre, precio_venta) values ( 3,NEW.nombre,NEW.precio);
END$$

SHOW WARNINGS$$

DELIMITER ;

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;


ALTER TABLE cliente  ADD  CONSTRAINT categoria_cliente FOREIGN KEY (id_categoria_cliente)
                  REFERENCES categoria_cliente (id_categoria_cliente)
                  ON DELETE RESTRICT
                  ON UPDATE CASCADE;
                  
ALTER TABLE detalle  ADD  CONSTRAINT id_venta FOREIGN KEY (id_venta)
                  REFERENCES venta (id_venta)
                  ON DELETE RESTRICT
                  ON UPDATE CASCADE;   
                  
                  
 ALTER TABLE empleado  ADD  CONSTRAINT id_categoria_empleado FOREIGN KEY (id_categoria_empleado)
                  REFERENCES categoria_empleado (id_categoria_empleado)
                  ON DELETE RESTRICT
                  ON UPDATE CASCADE;          

 ALTER TABLE estante_producto  ADD  CONSTRAINT id_producto_estante FOREIGN KEY (id_producto)
                  REFERENCES producto (id_producto)
                  ON DELETE RESTRICT
                  ON UPDATE CASCADE;   
    
 ALTER TABLE producto  ADD  CONSTRAINT id_tipo_producto FOREIGN KEY (id_tipo_producto)
                  REFERENCES tipo_producto (id_tipo_producto)
                  ON DELETE RESTRICT
                  ON UPDATE CASCADE;  
                  
     
 ALTER TABLE producto_general  ADD  CONSTRAINT id_tipo_producto_general FOREIGN KEY (id_tipo_producto)
                  REFERENCES tipo_producto (id_tipo_producto)
                  ON DELETE RESTRICT
                  ON UPDATE CASCADE;  
                  
 ALTER TABLE repuesto  ADD  CONSTRAINT id_tipo_producto_repuesto FOREIGN KEY (id_tipo_producto)
                  REFERENCES tipo_producto (id_tipo_producto)
                  ON DELETE RESTRICT
                  ON UPDATE CASCADE;  
 
  ALTER TABLE servicio  ADD  CONSTRAINT id_tipo_producto_servicio FOREIGN KEY (id_tipo_producto)
                  REFERENCES tipo_producto (id_tipo_producto)
                  ON DELETE RESTRICT
                  ON UPDATE CASCADE;  
                       
  ALTER TABLE producto_general  ADD  CONSTRAINT id_tipo_producto_general FOREIGN KEY (id_tipo_producto)
                  REFERENCES tipo_producto (id_tipo_producto)
                  ON DELETE RESTRICT
                  ON UPDATE CASCADE;  
                  
   ALTER TABLE venta  ADD  CONSTRAINT id_cliente FOREIGN KEY (id_cliente)
                  REFERENCES cliente (id_cliente)
                  ON DELETE RESTRICT
                  ON UPDATE CASCADE; 
				

use uma;
	insert Into categoria_cliente(nombre_categoria) values("Mayoristas");
	insert Into categoria_cliente(nombre_categoria) values("Normal");
    select * from  categoria_cliente;
    
    select * from cliente;
 
 