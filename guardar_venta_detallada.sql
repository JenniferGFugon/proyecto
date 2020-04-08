CREATE DEFINER=`root`@`localhost` PROCEDURE `guardar_venta_detalla`(
	in _venta int,
    in _id_producto int,
	in _cantidad int
)
begin
	set @nombreProducto = (select nombre from producto where id_producto = _id_producto);
   
    
	if (select count(*) from repuesto where nombre = @nombreProducto)>0 then 
     set @idrepuesto =(select id_repuesto from  repuesto where nombre = @nombreProducto);
		if (select existencia from repuesto where id_repuesto = @idrepuesto) >= _cantidad then 
			set @precio = (select precio_venta from producto where id_producto = _id_producto);
   			set @descuento = (select descuento from venta where id_venta = _venta) * @precio;
    		set @isv = (select isv from venta where id_venta = _venta) * @precio;
    		set @subtotal = (((@precio * _cantidad) - @descuento) + @isv);
			insert into detalle(id_venta, id_producto, cantidad, precio_venta, subtotal) values(_venta, _id_producto, _cantidad, @precio,@subtotal);
			UPDATE uma.venta SET total = total + @subtotal WHERE id_venta = _venta;
			UPDATE uma.repuesto SET existencia = (existencia - _cantidad) WHERE id_repuesto = @idrepuesto;
		end if;
	elseif(select count(*) from producto_general where nombre = @nombreProducto)>0 then 
			set @idproducto =(select id_producto_general from producto_general where  nombre = @nombreProducto);
			if (select existencia from producto_general where id_producto_general = @idproducto) >= _cantidad then 
				set @precio = (select precio_venta from producto where id_producto = _id_producto);
   				set @descuento = (select descuento from venta where id_venta = _venta) * @precio;
    			set @isv = (select isv from venta where id_venta = _venta) * @precio;
    			set @subtotal = (((@precio * _cantidad) - @descuento) + @isv);
				insert into detalle(id_venta, id_producto, cantidad, precio_venta, subtotal) values(_venta, _id_producto, _cantidad, @precio,@subtotal);
		    	UPDATE venta SET total = total + @subtotal WHERE id_venta = _venta;
				UPDATE producto_general SET existencia = (existencia - _cantidad) WHERE id_producto_general = @idproducto;
			end if; 
	else
				set @precio = (select precio_venta from producto where id_producto = _id_producto);
   				set @descuento = (select descuento from venta where id_venta = _venta) * @precio;
    			set @isv = (select isv from venta where id_venta = _venta) * @precio;
    			set @subtotal = (((@precio * _cantidad) - @descuento) + @isv);
				insert into detalle(id_venta, id_producto, cantidad, precio_venta, subtotal) values(_venta, _id_producto, _cantidad, @precio,@subtotal);
				UPDATE venta SET total = total + @subtotal WHERE id_venta = _venta;
	end if;
end