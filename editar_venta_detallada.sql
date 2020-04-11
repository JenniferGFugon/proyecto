CREATE DEFINER=`root`@`localhost` PROCEDURE `modificar_venta_detalle`(
	in _iddetalle int,
	in _cantidad int,
	in _venta int,
	in _id_producto int 
)
begin
	set @cantidadanterior = (select cantidad from detalle where id_detalle = _iddetalle);
	set @nombreProducto = (select nombre from producto where id_producto = _id_producto);
	set @subtotalanterior = (select subtotal from detalle where id_detalle = _iddetalle);
	
	if (select count(*) from repuesto where nombre = @nombreProducto)>0 then
		set @idrepuesto =(select id_repuesto from  repuesto where nombre = @nombreProducto);
		if @cantidadanterior < _cantidad then
			if (select existencia from repuesto where id_repuesto = @idrepuesto) >= _cantidad then
				set @precio = (select precio_venta from producto where id_producto = _id_producto);
   				set @descuento = (select descuento from venta where id_venta = _venta) * @precio;
    			set @isv = (select isv from venta where id_venta = _venta) * @precio;
    			set @subtotal = (((@precio * _cantidad) - @descuento) + @isv);
				
    			update detalle set cantidad = _cantidad where id_detalle = _iddetalle;
    			update detalle set subtotal = (subtotal -@subtotalanterior) + @subtotal where id_detalle = _iddetalle;
		    	update venta set total = (total - @subtotalanterior) + @subtotal where id_venta = _venta;
				update repuesto set existencia = (existencia + @cantidadanterior) - _cantidad where id_repuesto = @idrepuesto;
			end if;	
		else
			    set @cantidadNueva = @cantidadanterior - _cantidad;
			    set @precio = (select precio_venta from producto where id_producto = _id_producto);
   				set @descuento = (select descuento from venta where id_venta = _venta) * @precio;
    			set @isv = (select isv from venta where id_venta = _venta) * @precio;
    			set @subtotal = (((@precio * @cantidadNueva) - @descuento) + @isv);
				
    			update detalle set cantidad = @cantidadNueva where id_detalle = _iddetalle;
    			update detalle set subtotal = (subtotal -@subtotalanterior) + @subtotal where id_detalle = _iddetalle;
		    	update venta set total = (total - @subtotalanterior) + @subtotal where id_venta = _venta;
				update repuesto set existencia = (existencia + @cantidadanterior)- @cantidadNueva where id_repuesto = @idrepuesto;
		end if;

	elseif (select count(*) from producto_general where nombre = @nombreProducto)>0 then
		if @cantidadanterior < _cantidad then
        set @idproducto = (select id_producto_general from producto_general where  nombre = @nombreProducto);
			if (select existencia from producto_general where id_producto_general = @idproducto) > _cantidad then 
				set @precio = (select precio_venta from producto where id_producto = _id_producto);
   				set @descuento = (select descuento from venta where id_venta = _venta) * @precio;
    			set @isv = (select isv from venta where id_venta = _venta) * @precio;
    			set @subtotal = (((@precio * _cantidad) - @descuento) + @isv);
				
    			update detalle set cantidad = _cantidad where id_detalle = _iddetalle;
    			update detalle set subtotal = (subtotal -@subtotalanterior) + @subtotal where id_detalle = _iddetalle;
		    	update venta set total = (total - @subtotalanterior) + @subtotal where id_venta = _venta;
				update producto_general set existencia = (existencia + @cantidadanterior) - _cantidad where id_producto_general = @idproducto;
			end if;	
		else
			    set @cantidadNueva = @cantidadanterior - _cantidad;
			    set @precio = (select precio_venta from producto where id_producto = _id_producto);
   				set @descuento = (select descuento from venta where id_venta = _venta) * @precio;
    			set @isv = (select isv from venta where id_venta = _venta) * @precio;
    			set @subtotal = (((@precio * @cantidadNueva) - @descuento) + @isv);
				
    			update detalle set cantidad = @cantidadNueva where id_detalle = _iddetalle;
    			update detalle set subtotal = (subtotal -@subtotalanterior) + @subtotal where id_detalle = _iddetalle;
		    	update venta set total = (total - @subtotalanterior) + @subtotal where id_venta = _venta;
				update producto_general set existencia = (existencia + @cantidadanterior)- @cantidadNueva where id_producto_general = @idproducto;
		end if;
	else
		if @cantidadanterior < _cantidad then
				set @precio = (select precio_venta from producto where id_producto = _id_producto);
   				set @descuento = (select descuento from venta where id_venta = _venta) * @precio;
    			set @isv = (select isv from venta where id_venta = _venta) * @precio;
    			set @subtotal = (((@precio * _cantidad) - @descuento) + @isv);
				
    			update detalle set cantidad = _cantidad where id_detalle = _iddetalle;
    			update detalle set subtotal = (subtotal -@subtotalanterior) + @subtotal where id_detalle = _iddetalle;
		    	update venta set total = (total - @subtotalanterior) + @subtotal where id_venta = _venta;
		else	
			    set @cantidadNueva = @cantidadanterior - _cantidad;
                select @cantidadNueva;
			    set @precio = (select precio_venta from producto where id_producto = _id_producto);
   				set @descuento = (select descuento from venta where id_venta = _venta) * @precio;
    			set @isv = (select isv from venta where id_venta = _venta) * @precio;
    			set @subtotal = (((@precio * @cantidadNueva) - @descuento) + @isv);
				
    			update detalle set cantidad = _cantidad where id_detalle = _iddetalle;
    			update detalle set subtotal = (subtotal -@subtotalanterior) + @subtotal where id_detalle = _iddetalle;
		    	update venta set total = (total - @subtotalanterior) + @subtotal where id_venta = _venta;
		end if;
	end if;
		
END