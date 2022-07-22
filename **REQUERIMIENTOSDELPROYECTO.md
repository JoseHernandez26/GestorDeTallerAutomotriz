# GestorDeTallerAutomotriz

Administración de Taller automotriz.
Diseñar e implementar una aplicación web que realice la gestión de un taller de automotriz.
La aplicación deberá tener los siguientes módulos:  
•	Ordenes de reparación recibidas.
•	Ordenes de reparación en proceso.
•	Ordenes de reparación completadas.
•	Ordenes de reparación canceladas.

El módulo Ordenes de reparación recibidas deberá permitir realizar las siguientes operaciones: 

•	Ingresar una nueva orden de reparación. Se le solicitara al usuario los siguientes datos: 
1.	Nombre del cliente (Requerido).
2.	Número de placa (Requerido).
3.	Tipo. (Requerido). 
	Pueden ser:
•	Automóvil (1).
•	Motocicleta (2).
•	Carga Pesada (3).
4.	Marca. (Requerido).
5.	Descripción del problema. (Requerido).
6.	Fecha de ingreso: No se digita, es la fecha y hora en la que se ingresó al sistema la orden.
7.	Estado: No se digita, por omisión se ingresa en estado Recibida (1).

•	Listar las ordenes que se encuentren en estado Recibida (1). (5 pts)
1.	Por cada orden se debe mostrar la siguiente información:
Nombre del cliente.
Número de placa.
Tipo.
Marca.
•	Ver detalle de una orden, debe mostrar la siguiente información de la orden seleccionada: 
	Nombre del cliente.
	Número de placa.
	Tipo.
	Marca.
	Descripción del problema. 
	Fecha de Ingreso.
•	Editar una orden. Solo se pueden editar ordenes en estado Recibida (1). 
1.	Solo se puede modificar los campos
	Nombre del cliente. (Requerido).
	Número de placa.  (Requerido).
	Tipo. (Requerido).
	Marca. (Requerido).
	Descripción del problema. (Requerido).
•	Cancelar una orden. Solo se pueden cancelar ordenes en estado Recibida (1). 
1.	Se le solicita al usuario un motivo de la cancelación (Requerido).
2.	Se cambia el estado Cancelado (4).
•	Iniciar una orden. Solo se pueden iniciar ordenes en estado Recibida (1). 
1.	Se le solicita al usuario el nombre del mecánico que atiende la orden(Requerido).
2.	Se cambia el estado EnProceso (2).
3.	Fecha de inicio de atención: No se digita, es la fecha y hora en la que se inicia la orden.
El módulo de Ordenes de reparación en proceso deberá permitir realizar las siguientes operaciones: (

•	Listar las ordenes que se encuentren en estado EnProceso (2). 
1.	Por cada orden se debe mostrar la siguiente información
	Nombre del cliente.
	Número de placa.
	Tipo.
	Marca.
	Nombre del Mecánico.
	Fecha de Ingreso.
	Fecha de Inicio de atención.
	Cantidad de días en taller.
•	Campo calculado, la diferencia en días desde que se ingresó la orden y la fecha actual.
	Cantidad de días en proceso.
•	Campo calculado, la diferencia en días desde que se inició la atención y la fecha actual.
•	Cancelar una orden. Solo se pueden cancelar ordenes en estado EnProceso (2). 
1.	Se le solicita al usuario un motivo de la cancelación (Requerido).
2.	Se cambia el estado Cancelado (4).
•	Completar una orden. Solo se pueden completar ordenes en estado EnProceso (2). 
1.	Se le solicita al usuario la descripción de la reparación(Requerido).
2.	Se cambia el estado Completada (3).
3.	Fecha de final de atención: No se digita, es la fecha y hora en la que se completa la orden.
El módulo de Ordenes de reparación completadas deberá permitir realizar las siguientes operaciones: 
•	Listar las ordenes que se encuentren en estado completadas (3). 
1.	Por cada orden se debe mostrar la siguiente información
	Nombre del cliente.
	Número de placa.
	Tipo.
	Marca.
	Nombre del Mecánico.
	Fecha de Ingreso.
Fecha de Inicio de atención.
	Cantidad de días en taller.
•	Campo calculado, la diferencia en días desde que se ingresó la orden y la fecha final de atención.
	Cantidad de días en proceso.
•	Campo calculado, la diferencia en días desde que se inició la atención y la fecha final de atención.
•	Ver detalle de una orden, debe mostrar la siguiente información de la orden seleccionada: 
	Nombre del cliente.
	Número de placa.
	Tipo.
	Marca.
	Descripción del problema. 
	Fecha de Ingreso.
	Nombre del mecánico.
	Descripción de la reparación.
	Fecha de Inicio de atención.
	Fecha de final de atención.
	Cantidad de días en taller.
•	Campo calculado, la diferencia en días desde que se ingresó la orden y la fecha final de atención.
	Cantidad de días en proceso.
•	Campo calculado, la diferencia en días desde que se inició la atención y la fecha final de atención.
El módulo Ordenes de reparación canceladas deberá permitir realizar las siguientes operaciones: 

•	Listar las ordenes que se encuentren en estado Cancelada (4). 
1.	Por cada orden se debe mostrar la siguiente información
		Tipo.
	Marca.
•	Ver detalle de una orden, debe mostrar la siguiente información de la orden seleccionada: 
	Nombre del cliente.
	Número de placa.
	Tipo.
	Marca.
	Descripción del problema. 
	Fecha de Ingreso.
	Motivo de la cancelación. 

