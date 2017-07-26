# TDP-TPFinal-2016-Grupo8

Funcionamiento del programa.

Este programa permite hacer publicidad mediante el uso de imágenes y textos en pantalla. Las imágenes se organizan en campañas las cuales tienen cierto intervalo de tiempo entre imagen y cierta fechas y hora para mostrarse. Mientras que los textos se muestran simplemente según cada cierto rango de fechas y hora, estos textos se “deslizan” a través de la pantalla. Estos textos pueden extraerse de una fuente de RSS o pueden agregarse directamente a la base de datos.

Manual de usuario de aplicación de publicidades.
Pantalla del administrador:
  Crear entidad
    Seleccionar el botón Create en alguno de los artículos desplegables.
    La aplicación va a mostrar la pantalla de la entidad según corresponda.
    Modificar el nombre con una cadena representativa.
    (Solo campañas)
      En caso de ser una Campaña se deben rellenar los campos de minutos y segundos del intervalo. Se permite cualquier número    entero sin restricción.
    Modificar la información de la fecha según corresponda. En cuanto a la fecha, la inicial no podrá ser mayor a la final. En cuanto a las horas de inicio y de fin se aplica lo mismo, además que los valores de las horas deben ir de 0 a 23 y la de los minutos entre 0 y 59.
    (Según cada entidad)
    En caso de ser una campaña se debe adjuntar a la misma una o varias imágenes. Tocando el botón de Add image se va a abrir una pantalla la cual permitirá seleccionar imágenes de la computadora local. Si se desea eliminar imágenes, solo se debe seleccionar las columnas presionando el botón a la izquierda de cada una y presionar la tecla “d” minúscula.
    En caso de ser un banner de texto se debe modificar el texto por el cual se quiera mostrar.
    En caso de ser una fuente RSS se debe modificar el texto por una dirección URL a una página que ofrezca servicio de RSS.
    Seleccionar el botón Accept para crear la entidad y el botón Cancel para eliminar la entidad.

Buscar entidad
    Seleccionar el botón Search en alguno de los artículos desplegables.
    La aplicación va a abrir una nueva pantalla y va a mostrar un listado de todos los elementos de dicha entidad.
    En el campo superior derecho ingresar el nombre por el cual se realizará la búsqueda.


Eliminar entidad
    Seleccionar el botón Search en alguno de los artículos desplegables.
    La aplicación va a abrir una nueva pantalla y va a mostrar un listado de todos los elementos de dicha entidad.
    Se debe seleccionar una fila (tocando en la parte más izquierda de la misma) y presionar la tecla “d” minúscula.

Modificar entidad
    Seleccionar el botón Search en alguno de los artículos desplegables.
    La aplicación va a abrir una nueva pantalla y va a mostrar un listado de todos los elementos de dicha entidad.
    Se debe seleccionar una fila (tocando en la parte más izquierda de la misma) y presionar la tecla “m” minúscula.
    La aplicación va a abrir una nueva pantalla que va a mostrar los datos de la entidad seleccionada y se deberán realizar los cambios de manera similar al crear entidad (ver paso 1).

Pantalla de publicidad
    Muestra una imagen cada cierto intervalo de tiempo y un texto deslizante. Los tiempos de refresco son por defecto XX minutos para la imagen y son instantáneos para los banners.
    Imagen por defecto
    En caso de no encontrar ninguna imagen activa se muestra una por defecto (puede cambiarse reemplazando la imagen por defecto del directorio del programa).

Botón Force update
    Fuerza a los servicios a actualizarse con la base de datos inmediatamente.

