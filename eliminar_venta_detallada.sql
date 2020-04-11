CREATE DEFINER=`root`@`localhost` PROCEDURE `eliminar_venta_detalle`(
	in _id_detalle int
	)
begin
	set @id_producto = (select id_producto from detalle where id_detalle = _id_detalle);
	set @cantidad = (select cantidad from detalle where id_detalle = _id_detalle);
	set @nombreProducto = (select nombre from producto where id_producto = @id_producto);
	set @subtotal = (select subtotal from detalle where id_detalle = _id_detalle);
	set @id_venta = (select id_venta from detalle where id_detalle = _id_detalle);
    
        select @id_venta;

	if (select count(*) from repuesto where nombre = @nombreProducto)>0 then 
		set @id_repuesto = (select id_repuesto from repuesto where nombre = @nombreProducto);
		update repuesto set existencia = existencia + @cantidad where id_repuesto = @id_repuesto;
		update venta set total = (total - @subtotal) where id_venta = @id_venta;
        delete from detalle where id_detalle = _id_detalle;
	
	elseif(select count(*) from producto_general where nombre = @nombreProducto)>0 then
    set @id_producto = (select id_producto_general from producto_general  where nombre = @nombreProducto);
		delete from detalle where id_detalle = _id_detalle;
		update producto_general set existencia = existencia + @cantidad where id_producto_general = @id_producto;
		update venta set total = (total - @subtotal) where id_venta = @id_venta;
	
	else
	delete from detalle where id_detalle = _id_detalle;
		update venta set total = (total - @subtotal) where id_venta = @id_venta;
		
	end if;
	
END