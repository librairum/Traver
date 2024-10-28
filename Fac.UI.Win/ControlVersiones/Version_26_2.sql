-- Agregar reporte de guias Importadas

-- Agregar Menu 
Insert into segformulario (codigo,nombre,descripcion,codmodulo) values('0121','frmRepGuiasCantera','Reporte Guias Cantera','03')
insert into segmenu values('0125', 'Reporte Guias Cantera', '03', '09', '00','', '0121', 'DOC-26.png', '03')
insert into segmenuxperfil values('18','0125', '11111111111111111111', '03')
--Agregar Menu al perfil
insert into segmenuxperfil values('15','0082', '11111111111111111111', '03')
insert into segmenuxperfil values('15','0125', '11111111111111111111', '03')
--
Go

Go
--Exec Spu_Fact_Rep_GuiasCantera '01','2022','05','05'
Create Procedure Spu_Fact_Rep_GuiasCantera
@empresa	char(2),
@Anio		char(4),
@MesIni		char(2),
@MesFin		char(2)
As
Select cg.FAC34CODEMP,cg.FAC34AA,cg.FAC34MM,cg.FAC34SERIEGUIA,cg.FAC34NROGUIA,cg.FAC34FECHA,cg.FAC34ORIDESESTAB,cg.FAC34DESDESESTAB,cg.FAC34DESTDIRECCION,cg.FAC34MOTRASLDESC,
cg.FAC34MOTRASLDESCEXTRA,cg.FAC34ESTADO,cg.FAC34DESTRANSPORTISTA,cg.FAC34DESDESEMP,
dg.FAC35CODGUIADET,dg.FAC35CODPROD,dg.FAC35DESCPROD,dg.FAC35UNIMED,dg.FAC35CANTIDAD,dg.FA35NROPIEZAS,dg.FA35PESO,
got.FAC37CONTRATISTADESC,got.FAC37LABORDESC
From FAC34_GUIAREMISION cg 
Inner Join FAC35_DETGUIA dg on
cg.FAC34CODEMP = dg.FAC35CODEMP And cg.FAC01COD = dg.FAC01COD	And cg.FAC34NROGUIA=dg.FAC34NROGUIA
Left Join FAC37_GUIAREMISION_OT got on 
cg.FAC34CODEMP = got.FAC37CODEMP	
And cg.FAC01COD = got.FAC37COD	
And cg.FAC34NROGUIA = got.FAC37NROGUIA
Where
cg.FAC34CODEMP='01'
And cg.FAC34AA='2022'
And (cg.FAC34MM>='05' and cg.FAC34MM<='05')

