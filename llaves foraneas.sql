

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
                                             
                    
                  
                 
                                         
                       
                  
                  
                  
                  
                   
             
                  