CREATE DEFINER=`root`@`localhost` PROCEDURE `guardar_venta`(in _id_cliente int
 )
begin 
	if (select cliente.id_categoria_cliente from cliente where id_cliente = _id_cliente) = 1 then
	insert into venta(id_cliente, descuento) values(_id_cliente, 0.1);   
	end if;
    if (select cliente.id_categoria_cliente from cliente where id_cliente = _id_cliente) = 2 then
	insert into venta(id_cliente, descuento) values(_id_cliente, 0.0);   
	end if;
end