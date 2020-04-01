use uma;



DELIMITER |
CREATE TRIGGER Guardar_en_Productos
AFTER INSERT ON producto_general 
FOR EACH ROW
BEGIN
insert into producto (id_producto,id_tipo_producto ,nombre, precio_venta,habilitado) values ( new.id_producto_general, 1,NEW.nombre,NEW.precio_venta,true);
END;
|

DELIMITER |
CREATE TRIGGER Guardar_en_Productos_repuesto
AFTER INSERT ON repuesto
FOR EACH ROW
BEGIN
insert into producto (id_producto,id_tipo_producto , nombre, precio_venta,habilitado) values ( new.id_repuesto,2,NEW.nombre,NEW.precio_venta,true);
END;
|

DELIMITER |
CREATE TRIGGER Guardar_en_Productos_servicio
AFTER INSERT ON servicio
FOR EACH ROW
BEGIN
insert into producto (id_producto,id_tipo_producto ,nombre, precio_venta,habilitado) values (new.id_servicio, 3,NEW.nombre,NEW.precio,true);
END;
|


DELIMITER |
CREATE TRIGGER Modificar_en_Productos_General
AFTER UPDATE ON producto_general 
FOR EACH ROW
BEGIN
UPDATE producto SET nombre = new.nombre ,  precio_venta = new.precio_venta where id_producto = new.id_producto_general;
END;
|

DELIMITER |
CREATE TRIGGER Modificar_en_repuesto
AFTER UPDATE ON repuesto
FOR EACH ROW
BEGIN
UPDATE producto SET nombre = new.nombre ,  precio_venta = new.precio_venta where id_producto = new.id_repuesto;
END;
|

DELIMITER |
CREATE TRIGGER Modificar_en_servicio
AFTER UPDATE ON servicio
FOR EACH ROW
BEGIN
UPDATE producto SET nombre = new.nombre ,  precio = new.precio where id_producto = new.id_servicio;
END;
|
/*
DELIMITER |
CREATE TRIGGER Eliminar_servicio
BEFORE DELETE ON servicio
FOR EACH ROW
BEGIN
DECLARE idVenta INT ;
SET idVenta =  (select id_producto from detalle where id_producto = (select id from producto where id_producto = new.id_servicio ));
if(idVenta != 0)
then begin
DELETE id,id_producto,nombre,precio_venta  from producto where id_producto = new.id_servicio;
end ; end if;
else then begin
update producto set habilitado = true where id_producto = new.id_servicio;
end; end else;
END;
|*/


select * from producto_general;
DELETE  from producto_general where id_producto_general = 1 ;





drop trigger Guardar_en_Productos_servicio;
drop trigger Guardar_en_Productos;
drop trigger Guardar_en_Productos_repuesto;


INSERT INTO tipo_producto (nombre_tipo) values ('Producto General'),
											   ('Respuesto'),
                                               ('Servicio');
INSERT INTO categoria_producto (nombre_categoria) values ('Original'),
											             ('Generico');
                                                                                          
                                               
INSERT INTO producto_general (id_tipo_producto,precio_compra,nombre,marca,existencia,precio_venta) values(1,10,'caja','rojo','10',20);
INSERT INTO repuesto (id_tip_producto,id_cat_producto,nombre,marca,modelo,año,fabricante,precio_compra,precio_venta,existencia) values(2,1,'reloj','no se','hola','2010','no se ',10,20,20);



select * from producto
select * from producto_general
select * from repuesto

