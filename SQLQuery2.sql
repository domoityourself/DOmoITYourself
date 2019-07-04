--select * from Posts

insert into Posts(
Subtitulo,
Titulo,
UrlSlug,
FechaPost,
ContenidoHTML,
EsBorrador,
FechaPublicacion,
Autor,
linkVideo,
Portada,
FechaModificacion) 
values (
'<div class="#FF0000 background-color:" style="background-color:#ff0000; height:100%; width:100%">  <p>SUBTITULO</p>  </div>',
'Prueba2',
'Prueba2',
'2019-05-24 00:00:00.000',
'<p>sadsav dawdsad sad sad asd s dasd asd sadd<span style="font-size:12px">sadsad sads ad sadsa d</span></p>    <p><span style="font-family:Courier New,Courier,monospace"><span style="font-size:20px">sadsadsadsadsa</span></span>guay</p>  ',
0,
'2019-05-24 00:00:00.000',
'Xavi',
'https://www.youtube.com/watch?v=eXX16TD7pP8',
'<div style="background-color:blue; height:100%; width:100%">  <p>Modificado</p>    <p>&nbsp;</p>    <p>&nbsp;</p>    <p>&nbsp;</p>    <p>&nbsp;</p>    <p>&nbsp;</p>  </div>  ',
'2019-07-02 19:46:57.450')