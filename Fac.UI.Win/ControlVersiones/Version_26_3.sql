Select * from Empresa

-- Importar Guias de Cantera

Go
CREATE TABLE [dbo].[FAC34_GUIAREMISION_IMPORTAR](
	[FAC34CODEMP] [char](2) NOT NULL,
	[FAC01COD] [char](2) NOT NULL,
	[FAC34NROGUIA] [varchar](20) NOT NULL,
	[FAC34SERIEGUIA] [char](3) NULL,
	[FAC34CORRELATIVOGUIA] [char](7) NULL,
	[FAC34AA] [char](4) NOT NULL,
	[FAC34MM] [char](2) NOT NULL,
	[FAC03COD] [char](2) NOT NULL,
	[FAC02COD] [char](2) NOT NULL,
	[FAC03TIPART] [char](2) NOT NULL,
	[FAC34FECHA] [datetime] NOT NULL,
	[FAC34ORICODEMP] [varchar](11) NULL,
	[FAC34ORICODESTAB] [char](4) NULL,
	[FAC34ORIDESESTAB] [varchar](100) NULL,
	[FAC34ORIDOMPARTIDA] [varchar](100) NULL,
	[FAC34DESCODEMP] [varchar](11) NULL,
	[FAC34DESCODESTAB] [char](4) NULL,
	[FAC34DESDESESTAB] [varchar](100) NULL,
	[FAC34DESTDIRECCION] [varchar](100) NULL,
	[FAC34TRAYCODIGO] [varchar](10) NULL,
	[FAC34TRAYMARCA] [varchar](50) NULL,
	[FAC34TRAYPLACA] [varchar](10) NULL,
	[FAC34TRAYMARCASR] [varchar](50) NULL,
	[FAC34TRAYPLACASR] [varchar](10) NULL,
	[FAC34CHOFCOD] [varchar](11) NULL,
	[FAC34CHOFNOMBRE] [varchar](100) NULL,
	[FAC34CHOFLICCONDUCIR] [varchar](20) NULL,
	[FAC34MOTRASLCOD] [char](2) NULL,
	[FAC34MOTRASLDESC] [varchar](100) NULL,
	[FAC34MOTRASLDESCEXTRA] [varchar](100) NULL,
	[FAC34TOTALPESOMINA] [float] NULL,
	[FAC34TOTALPESODESTINO] [float] NULL,
	[FAC34ESTADO] [char](1) NULL,
	[FAC34ESTADOLLENADO] [char](1) NULL,
	[FAC34OBSERVACION] [varchar](250) NULL,
	[FAC34CODTRANSPORTISTA] [varchar](11) NULL,
	[FAC34DESTRANSPORTISTA] [varchar](100) NULL,
	[FAC34FECHAINITRASLADO] [datetime] NULL,
	[FAC34REFERENCIA] [varchar](250) NULL,
	[FAC34CONTENEDOR] [varchar](50) NULL,
	[FAC34PRECINTO] [varchar](100) NULL,
	[FAC34TOTAL1] [float] NULL,
	[FAC34TOTAL2] [float] NULL,
	[FAC34TOTAL3] [float] NULL,
	[FAC34TOTAL4] [float] NULL,
	[FAC34TOTAL5] [float] NULL,
	[FAC34DESDESEMP] [varchar](100) NULL,
	[FAC34FLAGORIPROD] [char](1) NULL,
	[FAC34CLICOD] [varchar](20) NULL,
	[FAC34OCNRO] [varchar](20) NULL,
	[FAC34OCTIPCOD] [char](1) NULL,
	[FAC34ESTADOPROCESOCOD] [char](2) NULL,
	[FAC34FECHABAJA] [datetime] NULL,
	[FAC34MOTIVOBAJA] [varchar](300) NULL,
	[FAC34ESTADOPROCESOOBSERVACION] [varchar](100) NULL,
	[FAC04ESTADOPROCESOFECHA] [datetime] NULL,
	[FAC04ESTADOPROCESOHORA] [time](7) NULL,
 CONSTRAINT [PK_FAC34_GUIAREMISION_IMPORTAR] PRIMARY KEY CLUSTERED 
(
	[FAC34CODEMP] ASC,
	[FAC01COD] ASC,
	[FAC34NROGUIA] ASC
)
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[FAC37_GUIAREMISION_OT](
	[FAC37CODEMP] [char](2) NOT NULL,
	[FAC37COD] [char](2) NOT NULL,
	[FAC37NROGUIA] [varchar](20) NOT NULL,
	[FAC37CONTRATISTACOD] [varchar](20) NULL,
	[FAC37CONTRATISTADESC] [varchar](250) NULL,
	[FAC37LABORCOD] [varchar](4) NULL,
	[FAC37LABORDESC] [varchar](250) NULL,
 CONSTRAINT [PK_FAC37_GUIAREMISION_OT] PRIMARY KEY CLUSTERED 
(
	[FAC37CODEMP] ASC,
	[FAC37COD] ASC,
	[FAC37NROGUIA] ASC
)
) ON [PRIMARY]

Go

--Sp_helptext Spu_Fact_Ins_GuiasRemisionImp
CREATE Procedure Spu_Fact_Ins_GuiasRemisionImp
@Empresa	VarChar(2),
@Anio		VarChar(4),
@Mes		VarChar(2),
@Usuario	VarChar(20),
@flag int output,
@Msgretorno VarChar(100)  Output          

As

BEGIN TRANSACTION   

Insert Into FAC34_GUIAREMISION(
FAC34CODEMP,
FAC01COD,
FAC34NROGUIA,
FAC34SERIEGUIA,
FAC34CORRELATIVOGUIA,
FAC34AA,
FAC34MM,
FAC03COD,
FAC02COD,
FAC03TIPART,
FAC34FECHA,
FAC34ORICODEMP,
FAC34ORICODESTAB,
FAC34ORIDESESTAB,
FAC34ORIDOMPARTIDA,
FAC34DE
SCODEMP,
FAC34DESDESEMP,
FAC34DESCODESTAB,
FAC34DESDESESTAB,
FAC34DESTDIRECCION,
FAC34TRAYCODIGO,
FAC34TRAYMARCA,
FAC34TRAYPLACA,
FAC34TRAYMARCASR,
FAC34TRAYPLACASR,
FAC34CHOFCOD,
FAC34CHOFNOMBRE,
FAC34CHOFLICCONDUCIR,
FAC34MOTRASLCOD,
FAC34MOTRASLDESC,
F
AC34MOTRASLDESCEXTRA,
FAC34ESTADO,
FAC34ESTADOLLENADO,
FAC34OBSERVACION,
FAC34CODTRANSPORTISTA,
FAC34DESTRANSPORTISTA,
FAC34FECHAINITRASLADO,
FAC34CLICOD,
FAC34ESTADOPROCESOCOD)
-- ===
Select 
-- Fila 1
Empresa as 'FAC34CODEMP',
'09' as 'FAC01COD',


(ltrim(rtrim(GUIA_SERIE))	+ '-' + ltrim(rtrim(GUIA_NRO))) as 'FAC34NROGUIA', 
ltrim(rtrim(GUIA_SERIE)) as 'FAC34SERIEGUIA',
ltrim(rtrim(GUIA_NRO)) as 'FAC34CORRELATIVOGUIA',
Anio as 'FAC34AA',
Mes as 'FAC34MM',
-- Fila 2
isnull(sp.FAC03COD,'') as 'FAC03CO


D',
Isnull(sp.FAC02COD,'') as 'FAC02COD',
Isnull(sp.FAC03TIPART,'') as 'FAC03TIPART' ,
Convert(datetime,FECHA,103) as 'FAC34FECHA',
Isnull(emp.Ruc,'') as 'FAC34ORICODEMP',
isnull(se.FAC07AESTABLECIMIENTOCOD,'') as 'FAC34ORICODESTAB', 
isnull(es.FAC63DESES
TAB,'') as 'FAC34ORIDESESTAB',
--Fila 3
DOMICILIO_DE_PARTIDA as  'FAC34ORIDOMPARTIDA',
Isnull(CLIENTE_RUC,'') as 'FAC34DESCODEMP',
Isnull(CLIENTE,'') as 'FAC34DESDESEMP',
'0001' as 'FAC34DESCODESTAB', 
'DIRECCION 1' as 'FAC34DESDESESTAB',
DOMICILIO_DE_DES
TINO as 'FAC34DESTDIRECCION',
-- Fila 4
'0001' as 'FAC34TRAYCODIGO',
VEHICULO_MARCA	as 'FAC34TRAYMARCA' , 
VEHICULO_PLACA as 'FAC34TRAYPLACA',
REMOLQUE_MARCA	 as 'FAC34TRAYMARCASR', 
REMOLQUE_PLACA as 'FAC34TRAYPLACASR',
-- Fila 5
right(LICENCIA_CONDUCTOR
_NRO,8)  as 'FAC34CHOFCOD',	
CONDUCTOR as 'FAC34CHO



FNOMBRE' , 
LICENCIA_CONDUCTOR_NRO as 'FAC34CHOFLICCONDUCIR',
-- Fila 6

motivo.FAC66CODMOTIVO as 'FAC34MOTRASLCOD',
MOTIVO_DEL_TRASLADO as 'FAC34MOTRASLDESC', -- VENTA 
'' as 'FAC34MOTRASLDESCEXTRA',
--Fila 7
'1' as 'FAC34ESTADO',
'0' as 
'FAC34ESTADOLLENADO',
'' as 'FAC34OBSERVACION',
--Fila 8
TRANSPORTISTA_RUC as 'FAC34CODTRANSPORTISTA', 
TRANSPORTISTA as 'FAC34DESTRANSPORTISTA',
Convert(datetime,FECHA,103) as 'FAC34FECHAINITRASLADO',
--Fila 9
CLIENTE_RUC as 'FAC34CLICOD',
'01' as 'FAC34


ESTADOPROCESOCOD'
From GuiasImportar 
--
Left Join Empresa emp On Empresa=Codigo	And Sistema='VENTAS'
-- ==
Left Join FAC03_SUBPLANTILLA sp on 

Empresa = FAC03CODEMP And FAC01COD='09' And ltrim(rtrim(GUIA_SERIE))=FAC03SERIEXDEF
-- ==
Left join FAC07_SERIES se on 
Empresa = se.FAC07CODEMP And se.FAC01COD='09'  And ltrim(rtrim(GUIA_SERIE))=se.FAC07SERIE
-- ==
Left Join FAC63_ESTABLECIMIENTOS es On






 Empresa = es.FAC63CODEMP And se.FAC07AESTABLECIMIENTOCOD = es.FAC63CODESTAB
--- ==
 lEFT jOIN FAC66_MOTIVODETRASLADO motivo
 on MOTIVO_DEL_TRASLADO = motivo.FAC66DESMOTIVO
 
 

Where Empresa=@Empresa
And Anio= @Anio
And Mes = @Mes
And USUARIO=@Usuario








If @@ERROR<>0        
    
 Begin            
  SELECT @MsgRetorno = 'Error al insertar la cabecera'   
  
  set @flag = -1                   
  Goto MANEJAERROR              
 End 

--Insertar Datos Adicionales, de control de produccion
Insert into FAC37_GUIAREMISION_OT(
FAC37CODEMP,FAC37COD,FAC37NROGUIA,FAC37CONTRATISTACOD ,FAC37CONTRATISTADESC,FAC37LABOR
COD,FAC37LABORDESC)
Select Empresa as 'FAC34CODEMP','09' as 'FAC01COD',(ltrim(rtrim(GUIA_SERIE))	+ '-' + ltrim(rtrim(GUIA_NRO))) as 'FAC34NROGUIA'
,'', CONTRATISTA,'',LABOR 
from GuiasImportar
Where Empresa=@Empresa
And Anio= @Anio
And Mes = @Mes
And USUA
RIO=@Usuario

If @@ERROR<>0            
 Begin            
  SELECT @MsgRetorno = 'Error al insertar Datos Adicionales Guia'      
  Goto MANEJAERROR         
 End 


-- Insertar detalle de Guia
Insert Into FAC35_DETGUIA(FAC35CODEMP,FAC01COD,FAC34NROGUIA,

FAC35CODGUIADET,FAC35CODPROD,FAC35DESCPROD,FAC35UNIMED,FAC35CANTIDAD,FA35PESO)

Select Empresa as 'FAC34CODEMP','09' as 'FAC01COD',(ltrim(rtrim(GUIA_SERIE))	+ '-' + ltrim(rtrim(GUIA_NRO))) as 'FAC34NROGUIA', 1 as 'FAC35CODGUIADET'
,isnull(a.IN01KEY,'') as 'PRODUCTO_COD',
PRODUCTO as 'PRODUCTO_DESC',UNIMED,CANTIDAD,PESO
From GuiasImportar Left Join In01arti a on 
IN01CODEMP=Empresa
And IN01AA=Anio
And ltrim(rtrim(IN01DESLAR))=ltrim(rtrim(PRODUCTO))
Where
Empresa=@Empresa
And Anio= @
Anio
And Mes = @Mes

And USUARIO=@Usuario

If @@ERROR<>0            
 Begin            
  SELECT @MsgRetorno = 'Error al insertar Detalle'                
  Goto MANEJAERROR              
 End 


Set @MsgRetorno='OK:: La a importacion se realizo con exito' 
   
set @flag = 1      
COMMIT TRANSACTION              
RETURN 1          
              
MANEJAERROR:    
set @flag = -1          
ROLLBACK TRANSACTION              
RETURN -1

Go
Go
Text
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--Spu_Fact_Del_FAC04_CABFACTURA      
CREATE Procedure [dbo].[Spu_Fact_Del_FAC34_GUIAREMISION]      
@FAC34CODEMP char(2),      
@FAC01COD char(2),      
@FAC34NROGUIA varchar(20),      
@flag     int output,        
@msgretorno varchar(100) Output      
As      
Begin Transaction 
-- Validar si existen repetidas       
 If ( Select Count(*) from FAC34_GUIAREMISION Where      
 FAC34CODEMP = @FAC34CODEMP      
 aND FAC01COD = @FAC01COD      
 And FAC34NROGUIA = @FAC34NROGUIA      
 ) > 0      
 Begin      
	 --Verificar si tiene detalles      
	 IF (Select Count (*) From FAC35_DETGUIA Where       
	  FAC35CODEMP=@FAC34CODEMP  And FAC01COD=@FAC01COD And      
	  FAC34NROGUIA=@FAC34NROGUIA)>0       
	  Begin      
		 Set @msgretorno='ERROR :: AL ELIMINAR ; PRIMERO ELIMINE EL DETALLE'      
		GOTO Manejaerror      
	  End      
	 Else      
		Begin      
		   Delete From FAC34_GUIAREMISION      
		   Where       
		   FAC34CODEMP = @FAC34CODEMP      
		   aND FAC01COD = @FAC01COD      
		   And FAC34NROGUIA = @FAC34NROGUIA      
		
			IF @@ERROR <>0      
			BEGIN      
				Set @msgretorno='ERROR :: INESPERADO al eliminar Guia Remision'      
				GOTO Manejaerror      
			END      
			
		-- 	Si existe la tabla lo deletea
		IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FAC37_GUIAREMISION_OT]') AND type in (N'U'))
			begin 
				Delete from FAC37_GUIAREMISION_OT where
				FAC37CODEMP=@FAC34CODEMP
				And FAC37COD=@FAC01COD
				And FAC37NROGUIA=@FAC34NROGUIA
			End
			
				IF @@ERROR <>0      
				BEGIN      
					Set @msgretorno='ERROR :: Al eliminar OT Guia Remision'      
					GOTO Manejaerror      
			END
		 End       
	      
		
 END      
 ELSE      
           BEGIN      
                     Set @msgretorno='ERROR :: NO EXISTE CODIGO'      
                     GOTO Manejaerror      
           End      
  
set @flag = 1        
Set @msgretorno='OK :: SE ELIMINO CON EXITO'       
Commit Transaction
Return 1       

set @flag = -1        
Manejaerror:       
Rollback Transaction
Return -1  



Go

Text
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

--Sp_helptext Spu_Fact_Ins_GuiasRemisionImp

CREATE Procedure Spu_Fact_Ins_GuiasRemisionImp
@Empresa	VarChar(2),
@Anio		VarChar(4),
@Mes		VarChar(2),
@Usuario	VarChar(20),
@flag int output,
@Msgretorno VarChar(100)  Output          

As

BEGIN TRANSACTIO
N   

Insert Into FAC34_GUIAREMISION(
FAC34CODEMP,
FAC01COD,
FAC34NROGUIA,
FAC34SERIEGUIA,
FAC34CORRELATIVOGUIA,
FAC34AA,
FAC34MM,
FAC03COD,
FAC02COD,
FAC03TIPART,
FAC34FECHA,
FAC34ORICODEMP,
FAC34ORICODESTAB,
FAC34ORIDESESTAB,
FAC34ORIDOMPARTIDA,
FAC34DE
SCODEMP,
FAC34DESDESEMP,
FAC34DESCODESTAB,
FAC34DESDESESTAB,
FAC34DESTDIRECCION,
FAC34TRAYCODIGO,
FAC34TRAYMARCA,
FAC34TRAYPLACA,
FAC34TRAYMARCASR,
FAC34TRAYPLACASR,
FAC34CHOFCOD,
FAC34CHOFNOMBRE,
FAC34CHOFLICCONDUCIR,
FAC34MOTRASLCOD,
FAC34MOTRASLDESC,
F
AC34MOTRASLDESCEXTRA,
FAC34ESTADO,
FAC34ESTADOLLENADO,
FAC34OBSERVACION,
FAC34CODTRANSPORTISTA,
FAC34DESTRANSPORTISTA,
FAC34FECHAINITRASLADO,
FAC34CLICOD,
FAC34ESTADOPROCESOCOD)
-- ===
Select 
-- Fila 1
Empresa as 'FAC34CODEMP',
'09' as 'FAC01COD',


(ltrim(rtrim(GUIA_SERIE))	+ '-' + ltrim(rtrim(GUIA_NRO))) as 'FAC34NROGUIA', 
ltrim(rtrim(GUIA_SERIE)) as 'FAC34SERIEGUIA',
ltrim(rtrim(GUIA_NRO)) as 'FAC34CORRELATIVOGUIA',
Anio as 'FAC34AA',
Mes as 'FAC34MM',
-- Fila 2
isnull(sp.FAC03COD,'') as 'FAC03CO


D',
Isnull(sp.FAC02COD,'') as 'FAC02COD',
Isnull(sp.FAC03TIPART,'') as 'FAC03TIPART' ,
Convert(datetime,FECHA,103) as 'FAC34FECHA',
Isnull(emp.Ruc,'') as 'FAC34ORICODEMP',
isnull(se.FAC07AESTABLECIMIENTOCOD,'') as 'FAC34ORICODESTAB', 
isnull(es.FAC63DESES
TAB,'') as 'FAC34ORIDESESTAB',
--Fila 3
DOMICILIO_DE_PARTIDA as  'FAC34ORIDOMPARTIDA',
Isnull(CLIENTE_RUC,'') as 'FAC34DESCODEMP',
Isnull(CLIENTE,'') as 'FAC34DESDESEMP',
'0001' as 'FAC34DESCODESTAB', 
'DIRECCION 1' as 'FAC34DESDESESTAB',
DOMICILIO_DE_DES
TINO as 'FAC34DESTDIRECCION',
-- Fila 4
'0001' as 'FAC34TRAYCODIGO',
VEHICULO_MARCA	as 'FAC34TRAYMARCA' , 
VEHICULO_PLACA as 'FAC34TRAYPLACA',
REMOLQUE_MARCA	 as 'FAC34TRAYMARCASR', 
REMOLQUE_PLACA as 'FAC34TRAYPLACASR',
-- Fila 5
right(LICENCIA_CONDUCTOR
_NRO,8)  as 'FAC34CHOFCOD',	
CONDUCTOR as 'FAC34CHO



FNOMBRE' , 
LICENCIA_CONDUCTOR_NRO as 'FAC34CHOFLICCONDUCIR',
-- Fila 6

motivo.FAC66CODMOTIVO as 'FAC34MOTRASLCOD',
MOTIVO_DEL_TRASLADO as 'FAC34MOTRASLDESC', -- VENTA 
'' as 'FAC34MOTRASLDESCEXTRA',
--Fila 7
'1' as 'FAC34ESTADO',
'0' as 
'FAC34ESTADOLLENADO',
'' as 'FAC34OBSERVACION',
--Fila 8
TRANSPORTISTA_RUC as 'FAC34CODTRANSPORTISTA', 
TRANSPORTISTA as 'FAC34DESTRANSPORTISTA',
Convert(datetime,FECHA,103) as 'FAC34FECHAINITRASLADO',
--Fila 9
CLIENTE_RUC as 'FAC34CLICOD',
'01' as 'FAC34


ESTADOPROCESOCOD'
From GuiasImportar 
--
Left Join Empresa emp On Empresa=Codigo	And Sistema='VENTAS'
-- ==
Left Join FAC03_SUBPLANTILLA sp on 

Empresa = FAC03CODEMP And FAC01COD='09' And ltrim(rtrim(GUIA_SERIE))=FAC03SERIEXDEF
-- ==
Left join FAC07_SERIES se on 
Empresa = se.FAC07CODEMP And se.FAC01COD='09'  And ltrim(rtrim(GUIA_SERIE))=se.FAC07SERIE
-- ==
Left Join FAC63_ESTABLECIMIENTOS es On






 Empresa = es.FAC63CODEMP And se.FAC07AESTABLECIMIENTOCOD = es.FAC63CODESTAB
--- ==
 lEFT jOIN FAC66_MOTIVODETRASLADO motivo
 on MOTIVO_DEL_TRASLADO = motivo.FAC66DESMOTIVO
 
 

Where Empresa=@Empresa
And Anio= @Anio
And Mes = @Mes
And USUARIO=@Usuario








If @@ERROR<>0        
    
 Begin            
  SELECT @MsgRetorno = 'Error al insertar la cabecera'   
  
  set @flag = -1                   
  Goto MANEJAERROR              
 End 

--Insertar Datos Adicionales, de control de produccion
Insert into FAC37_GUIAREMISION_OT(
FAC37CODEMP,FAC37COD,FAC37NROGUIA,FAC37CONTRATISTACOD ,FAC37CONTRATISTADESC,FAC37LABOR
COD,FAC37LABORDESC)
Select Empresa as 'FAC34CODEMP','09' as 'FAC01COD',(ltrim(rtrim(GUIA_SERIE))	+ '-' + ltrim(rtrim(GUIA_NRO))) as 'FAC34NROGUIA'
,'', CONTRATISTA,'',LABOR 
from GuiasImportar
Where Empresa=@Empresa
And Anio= @Anio
And Mes = @Mes
And USUA
RIO=@Usuario

If @@ERROR<>0            
 Begin            
  SELECT @MsgRetorno = 'Error al insertar Datos Adicionales Guia'      
  Goto MANEJAERROR         
 End 


-- Insertar detalle de Guia
Insert Into FAC35_DETGUIA(FAC35CODEMP,FAC01COD,FAC34NROGUIA,

FAC35CODGUIADET,FAC35CODPROD,FAC35DESCPROD,FAC35UNIMED,FAC35CANTIDAD,FA35PESO)

Select Empresa as 'FAC34CODEMP','09' as 'FAC01COD',(ltrim(rtrim(GUIA_SERIE))	+ '-' + ltrim(rtrim(GUIA_NRO))) as 'FAC34NROGUIA', 1 as 'FAC35CODGUIADET'
,isnull(a.IN01KEY,'') as 'PRODUCTO_COD',
PRODUCTO as 'PRODUCTO_DESC',UNIMED,CANTIDAD,PESO
From GuiasImportar Left Join In01arti a on 
IN01CODEMP=Empresa
And IN01AA=Anio
And ltrim(rtrim(IN01DESLAR))=ltrim(rtrim(PRODUCTO))
Where
Empresa=@Empresa
And Anio= @Anio
And Mes = @Mes

And USUARIO=@Usuario

If @@ERROR<>0            
 Begin            
  SELECT @MsgRetorno = 'Error al insertar Detalle'                
  Goto MANEJAERROR              
 End 


Set @MsgRetorno='OK:: La a importacion se realizo con exito' 
   
set @flag = 1      
COMMIT TRANSACTION              
RETURN 1          
              
MANEJAERROR:    
set @flag = -1          
ROLLBACK TRANSACTION              
RETURN -1


Go

--Spu_Fac_Ins_GuiasImportar  
CREATE procedure Spu_Fac_Ins_GuiasImportar        
@Empresa char(2) , -- se asigna de los valores globales del sistema      
@Anio char(4) , -- se asigna de los valores globales del sistema      
@Mes char(2) , -- se asigna de los valores globales del sistema      
@Contador int , -- por defecto sera valor 1      
@Item int ,-- por defecto sera valor 1       
@CANTIDAD float ,      
@UNIMED varchar(5) ,      
@PRODUCTO varchar(250) , -- descripcion del producto      
@PESO float ,      
@FECHA varchar(10), --@FECHA datetime , -- ingresaremos en formato de cadena dd/mm/yyyy, luego se convertira       
@GUIA_SERIE varchar(10) ,      
@GUIA_NRO varchar(20) ,      
@MOTIVO_DEL_TRASLADO varchar(50) ,      
@DOMICILIO_DE_PARTIDA varchar(250) ,      
@DOMICILIO_DE_DESTINO varchar(250) ,      
@CLIENTE_RUC varchar(20) ,      
@CLIENTE varchar(250) , -- descripcion del cliente (razon social o datos personal)      
@TRANSPORTISTA_RUC varchar(20) ,      
@TRANSPORTISTA varchar(250) , -- datos personales del tranportista nombre, apellido      
@LICENCIA_CONDUCTOR_NRO varchar(20) , -- numero de licencia del conductor      
@CONDUCTOR varchar(250) , -- datos personal del conducto (nombres,apellidos)      
@VEHICULO_MARCA varchar(50) ,       
@VEHICULO_PLACA varchar(20) ,      
@REMOLQUE_MARCA varchar(50) ,      
@REMOLQUE_PLACA varchar(20) ,      
@CONTRATISTA varchar(250) , -- datos personales del contratist(nombres, apellidos)      
@LABOR char(50) ,      
@USUARIO varchar(50) ,      
@flag int output,        
@mensaje varchar(20) output        
       
as        
Begin        
Begin transaction       
      
      
--Asignar valor de numero item y contador      
--set @Item = 1      
--set @Contador = 1      
      
--Asignar codigo de producto segun la descripcion      
declare @fechaformateada as datetime      
select  @fechaformateada = convert(datetime, @fecha, 121)      
      
 insert into GuiasImportar values(@Empresa,@Anio, @Mes, @Contador, @Item,@CANTIDAD, @UNIMED, @PRODUCTO,@PESO ,       
 @fechaformateada,@guia_serie, @guia_nro, @MOTIVO_DEL_TRASLADO, @DOMICILIO_DE_PARTIDA, @DOMICILIO_DE_DESTINO,@CLIENTE_RUC,       
 @CLIENTE, @TRANSPORTISTA_RUC, @TRANSPORTISTA, @LICENCIA_CONDUCTOR_NRO, @CONDUCTOR, @VEHICULO_MARCA, @VEHICULO_PLACA,      
 @REMOLQUE_MARCA, @REMOLQUE_PLACA, @CONTRATISTA, @LABOR, @USUARIO)        
       
       
 if @@Error <> 0      
 Begin      
 set @mensaje = 'Error al insertar guia de importacion'      
 set @flag = -1      
 goto ManejaError       
 End      
       
 set @mensaje = 'Insercion exitosa'      
 set @flag = 1      
 Commit Transaction      
 return 1      
       
 ManejaError:      
 set @flag = -1      
 Rollback transaction      
 return -1      
       
End   
  
Go  
  
  
    
CREATE procedure Spu_Fac_Trae_GuiasImportadas        
@Empresa char(2) , -- se asigna de los valores globales del sistema        
@USUARIO varchar(50)    
as        
begin        
--la tabla debe listar todo los datos que contiene, los datos de esta tabla tambien sera retirado cuando se procese de temporal a la tabla final d      
 Select * from GuiasImportar     
 where   
 Empresa = @Empresa  
 and USUARIO = @USUARIO    
end  

Go
CREATE procedure Spu_Fac_Del_GuiasImportadas    
@Empresa char(2) , -- se asigna de los valores globales del sistema        
@USUARIO varchar(50)    
as      
Begin      
 delete from GuiasImportar    
 where Empresa = @Empresa      
 and USUARIO = @USUARIO    
End  
  
Go

CREATE Procedure Spu_Fact_Trae_ValImpGuias     
@Empresa VarChar(2),     
@Anio VarChar(4),     
@Mes VarChar(2),     
@Usuario VarChar(20),     
@flag varchar(2)     
as     
-- Creo una temporal para los errores                               
CREATE TABLE #Guias_importarError(     
[Empresa] [char](2) NULL,     
[Anio] [char](4) NULL,     
[Mes] [char](2) NULL,     
[Contador] [int] Not NULL,     
[Item] [int] NULL,     
[CANTIDAD] [float] NULL,     
[UNIMED] [varchar](5) NULL,     
[PRODUCTO] [varchar](250) NULL,     
[PESO] [float] NULL,     
[FECHA] [datetime] NULL,     
[GUIA_SERIE] [varchar](10) NULL,     
[GUIA_NRO] [varchar](20) NULL,     
[MOTIVO_DEL_TRASLADO] [varchar](50) NULL,     
[DOMICILIO_DE_PARTIDA] [varchar](250) NULL,     
[DOMICILIO_DE_DESTINO] [varchar](250) NULL,     
[CLIENTE_RUC] [varchar](20) NULL,     
[CLIENTE] [varchar](250) NULL,     
[TRANSPORTISTA_RUC] [varchar](20) NULL,     
[TRANSPORTISTA] [varchar](250) NULL,     
[LICENCIA_CONDUCTOR_NRO] [varchar](20) NULL,     
[CONDUCTOR] [varchar](250) NULL,     
[VEHICULO_MARCA] [varchar](50) NULL,     
[VEHICULO_PLACA] [varchar](20) NULL,     
[REMOLQUE_MARCA] [varchar](50) NULL,     
[REMOLQUE_PLACA] [varchar](20) NULL,     
[CONTRATISTA] [varchar](250) NULL,     
[LABOR] [char](50) NULL,     
[USUARIO] [varchar](50) NULL,     
[Errorcod] [varchar](5) NULL,     
[Errordes] [varchar](250) NULL )     
    
    
    
CREATE TABLE #Guias_importarOri(     
[Empresa] [char](2) NULL,     
[Anio] [char](4) NULL,     
[Mes] [char](2) NULL,     
[Contador] [int] Not NULL,     
[Item] [int] NULL,     
[CANTIDAD] [float] NULL,     
[UNIMED] [varchar](5) NULL,     
[PRODUCTO] [varchar](250) NULL,     
[PESO] [float] NULL,     
[FECHA] [datetime] NULL,     
[GUIA_SERIE] [varchar](10) NULL,     
[GUIA_NRO] [varchar](20) NULL,     
[MOTIVO_DEL_TRASLADO] [varchar](50) NULL,     
[DOMICILIO_DE_PARTIDA] [varchar](250) NULL,     
[DOMICILIO_DE_DESTINO] [varchar](250) NULL,     
[CLIENTE_RUC] [varchar](20) NULL,     
[CLIENTE] [varchar](250) NULL,     
[TRANSPORTISTA_RUC] [varchar](20) NULL,     
[TRANSPORTISTA] [varchar](250) NULL,     
[LICENCIA_CONDUCTOR_NRO] [varchar](20) NULL,     
[CONDUCTOR] [varchar](250) NULL,     
[VEHICULO_MARCA] [varchar](50) NULL,     
[VEHICULO_PLACA] [varchar](20) NULL,     
[REMOLQUE_MARCA] [varchar](50) NULL,     
[REMOLQUE_PLACA] [varchar](20) NULL,     
[CONTRATISTA] [varchar](250) NULL,     
[LABOR] [char](50) NULL,     
[USUARIO] [varchar](50) NULL )     
-- =============                        
 If @flag='IV'                          
Begin    
   Insert into    
      #Guias_importarOri(Empresa, Anio, Mes, Contador, Item, CANTIDAD, UNIMED, PRODUCTO, PESO, FECHA, GUIA_SERIE, GUIA_NRO, MOTIVO_DEL_TRASLADO,     
      DOMICILIO_DE_PARTIDA, DOMICILIO_DE_DESTINO, CLIENTE_RUC, CLIENTE, TRANSPORTISTA_RUC,     
      TRANSPORTISTA, LICENCIA_CONDUCTOR_NRO, CONDUCTOR, VEHICULO_MARCA, VEHICULO_PLACA, REMOLQUE_MARCA, REMOLQUE_PLACA, CONTRATISTA, LABOR, USUARIO)     
      Select    
         Empresa,    
         Anio,    
         Mes,    
         Contador,    
         Item,    
         CANTIDAD,    
         UNIMED,    
         PRODUCTO,    
         PESO,    
         FECHA,    
         GUIA_SERIE,    
         GUIA_NRO,    
         MOTIVO_DEL_TRASLADO,    
         DOMICILIO_DE_PARTIDA,    
         DOMICILIO_DE_DESTINO,    
         CLIENTE_RUC,    
         CLIENTE,    
         TRANSPORTISTA_RUC,    
         TRANSPORTISTA,    
         LICENCIA_CONDUCTOR_NRO,    
         CONDUCTOR,    
         VEHICULO_MARCA,    
         VEHICULO_PLACA,    
         REMOLQUE_MARCA,    
         REMOLQUE_PLACA,    
         CONTRATISTA,    
         LABOR,    
         USUARIO     
      from    
         guiasimportar    
      Where    
         Empresa = @Empresa     
         And usuario = @Usuario     
         And Isnull(GUIA_NRO, '') <> ''     
End    
Else    
   If @flag = 'IC'     
   Begin    
      -- Se validaba de otro origen, no aplica  para este caso     
           
      print 'No Aplica'     
   End    
   -- ========== Validar Inconsistencias del mismo registro                               
   If @flag='IV'                      -- Validar solo para la importacion de excel     
   Begin    
      -- 1.- Valida Motivo de traslado         
      Insert Into #Guias_importarError (Empresa,Anio,Mes,Contador,Item,CANTIDAD,UNIMED,PRODUCTO,PESO,FECHA,GUIA_SERIE,GUIA_NRO,MOTIVO_DEL_TRASLADO,      
      DOMICILIO_DE_PARTIDA,    
      DOMICILIO_DE_DESTINO,    
      CLIENTE_RUC,    
      CLIENTE,    
      TRANSPORTISTA_RUC,    
      TRANSPORTISTA,    
      LICENCIA_CONDUCTOR_NRO,    
      CONDUCTOR,    
      VEHICULO_MARCA,    
      VEHICULO_PLACA,    
      REMOLQUE_MARCA,    
      REMOLQUE_PLACA,    
      CONTRATISTA,    
      LABOR,    
      USUARIO,    
      Errorcod,    
      Errordes    
   )    
   Select    
      Empresa,    
      Anio,    
      Mes,    
      Contador,    
      Item,    
      CANTIDAD,    
      UNIMED,    
      PRODUCTO,    
      PESO,    
      FECHA,    
      GUIA_SERIE,    
      GUIA_NRO,    
      MOTIVO_DEL_TRASLADO,    
      DOMICILIO_DE_PARTIDA,    
      DOMICILIO_DE_DESTINO,    
      CLIENTE_RUC,    
      CLIENTE,    
      TRANSPORTISTA_RUC,    
      TRANSPORTISTA,    
      LICENCIA_CONDUCTOR_NRO,    
      CONDUCTOR,    
      VEHICULO_MARCA,    
      VEHICULO_PLACA,    
      REMOLQUE_MARCA,    
      REMOLQUE_PLACA,    
      CONTRATISTA,    
      LABOR,    
      USUARIO,    
      '1.1',    
      'Motivo de traslado No Valido: La descripcion debe ser igual a la que figura en la guia'     
   from    
      #Guias_importarOri     
   Where    
      Empresa = @Empresa     
      And usuario = @Usuario     
      And Upper(MOTIVO_DEL_TRASLADO) Not in     
      (    
         Select    
            Upper(FAC66DESMOTIVO)     
         from    
            FAC66_MOTIVODETRASLADO    
      )    
      -- Validar Fechas vs Periodo     
      Insert Into    
         #Guias_importarError (Empresa, Anio, Mes, Contador, Item, CANTIDAD,     
         UNIMED, PRODUCTO, PESO, FECHA, GUIA_SERIE, GUIA_NRO, MOTIVO_DEL_TRASLADO,     
         DOMICILIO_DE_PARTIDA, DOMICILIO_DE_DESTINO, CLIENTE_RUC, CLIENTE, TRANSPORTISTA_RUC,     
         TRANSPORTISTA, LICENCIA_CONDUCTOR_NRO, CONDUCTOR, VEHICULO_MARCA, VEHICULO_PLACA, REMOLQUE_MARCA,     
         REMOLQUE_PLACA, CONTRATISTA, LABOR, USUARIO, Errorcod, Errordes)     
         Select    
            Empresa,    
            Anio,    
            Mes,    
            Contador,    
            Item,    
            CANTIDAD,    
            UNIMED,    
            PRODUCTO,    
            PESO,    
            FECHA,    
            GUIA_SERIE,    
            GUIA_NRO,    
            MOTIVO_DEL_TRASLADO,    
            DOMICILIO_DE_PARTIDA,    
            DOMICILIO_DE_DESTINO,    
            CLIENTE_RUC,    
            CLIENTE,    
            TRANSPORTISTA_RUC,    
            TRANSPORTISTA,    
            LICENCIA_CONDUCTOR_NRO,    
            CONDUCTOR,    
            VEHICULO_MARCA,    
            VEHICULO_PLACA,    
            REMOLQUE_MARCA,    
            REMOLQUE_PLACA,    
            CONTRATISTA,    
            LABOR,    
            USUARIO,    
            '1.2',    
            'Fecha No Pertenece al Periodo: La Fecha debe estar dentro del periodo'     
         From    
            #Guias_importarOri     
         Where    
            Empresa = @Empresa     
            And usuario = @Usuario     
            And     
            (    
               Month(Isnull (FECHA, '')) <> Mes     
               Or YEAR(Isnull(FECHA, '')) <> Anio    
            )    
              
            --Validar Voucher repetidos                                
            Insert Into #Guias_importarError (Empresa,Anio,Mes,GUIA_SERIE,GUIA_NRO,Contador,Errorcod,Errordes)                                          
            Select    
               Empresa,    
               Anio,    
               Mes,    
               GUIA_SERIE,    
               GUIA_NRO,    
               0,    
               '1.3',    
               'Guia Repetida'     
            From    
      #Guias_importarOri     
            Where    
               Empresa = @Empresa     
               And usuario = @Usuario     
            Group By    
               Empresa,    
               Anio,    
               Mes,    
               GUIA_SERIE,    
               GUIA_NRO     
            Having    
               COUNT(*) > 1          
                   
               -- ========== Validar datos de Detalle                                   
               -- 7.- Valida Cantidad         
               Insert Into #Guias_importarError (Empresa,Anio,Mes,Contador,Item,    
               CANTIDAD,    
               UNIMED,    
               PRODUCTO,    
               PESO,    
               FECHA,    
               GUIA_SERIE,    
               GUIA_NRO,    
               MOTIVO_DEL_TRASLADO,    
               DOMICILIO_DE_PARTIDA,    
               DOMICILIO_DE_DESTINO,    
               CLIENTE_RUC,    
               CLIENTE,    
               TRANSPORTISTA_RUC,    
               TRANSPORTISTA,    
               LICENCIA_CONDUCTOR_NRO,    
               CONDUCTOR,    
               VEHICULO_MARCA,    
               VEHICULO_PLACA,    
               REMOLQUE_MARCA,    
               REMOLQUE_PLACA,    
               CONTRATISTA,    
               LABOR,    
               USUARIO,    
               Errorcod,    
               Errordes    
   )    
   Select    
      Empresa,    
      Anio,    
      Mes,    
      Contador,    
      Item,    
      CANTIDAD,    
      UNIMED,    
      PRODUCTO,    
      PESO,    
      FECHA,    
      GUIA_SERIE,    
      GUIA_NRO,    
      MOTIVO_DEL_TRASLADO,    
      DOMICILIO_DE_PARTIDA,    
      DOMICILIO_DE_DESTINO,    
      CLIENTE_RUC,    
      CLIENTE,    
      TRANSPORTISTA_RUC,    
      TRANSPORTISTA,    
      LICENCIA_CONDUCTOR_NRO,    
      CONDUCTOR,    
      VEHICULO_MARCA,    
      VEHICULO_PLACA,    
      REMOLQUE_MARCA,    
      REMOLQUE_PLACA,    
      CONTRATISTA,    
      LABOR,    
      USUARIO,    
      '1.4',    
      'Cantidad No Valida'     
   from    
      #Guias_importarOri     
   Where    
      Empresa = @Empresa     
      And usuario = @Usuario     
      And Isnull(CANTIDAD, 0) = 0   -- 8.- Valida Peso          
      Insert Into #Guias_importarError (Empresa,Anio,Mes,Contador,Item,CANTIDAD,UNIMED,PRODUCTO,    
      PESO,    
      FECHA,    
      GUIA_SERIE,    
      GUIA_NRO,    
      MOTIVO_DEL_TRASLADO,    
      DOMICILIO_DE_PARTIDA,    
      DOMICILIO_DE_DESTINO,    
      CLIENTE_RUC,    
      CLIENTE,    
      TRANSPORTISTA_RUC,    
      TRANSPORTISTA,    
      LICENCIA_CONDUCTOR_NRO,    
      CONDUCTOR,    
      VEHICULO_MARCA,    
      VEHICULO_PLACA,    
      REMOLQUE_MARCA,    
      REMOLQUE_PLACA,    
      CONTRATISTA,    
      LABOR,    
      USUARIO,    
      Errorcod,    
      Errordes    
   )    
   Select    
      Empresa,    
      Anio,    
      Mes,    
      Contador,    
      Item,    
      CANTIDAD,    
      UNIMED,    
      PRODUCTO,    
      PESO,    
      FECHA,    
      GUIA_SERIE,    
      GUIA_NRO,    
      MOTIVO_DEL_TRASLADO,    
      DOMICILIO_DE_PARTIDA,    
      DOMICILIO_DE_DESTINO,    
      CLIENTE_RUC,    
      CLIENTE,    
      TRANSPORTISTA_RUC,    
      TRANSPORTISTA,    
      LICENCIA_CONDUCTOR_NRO,    
      CONDUCTOR,    
      VEHICULO_MARCA,    
      VEHICULO_PLACA,    
      REMOLQUE_MARCA,    
      REMOLQUE_PLACA,    
      CONTRATISTA,    
      LABOR,    
      USUARIO,    
      '1.5',    
      'Peso  No Valido'     
   from    
      #Guias_importarOri     
   Where    
      Empresa = @Empresa     
      And usuario = @Usuario     
      And Isnull(PESO, 0) = 0   -- Valida Producto           
      Insert Into #Guias_importarError (Empresa,Anio,Mes,Contador,Item,CANTIDAD,UNIMED,PRODUCTO,PESO,FECHA,GUIA_SERIE,GUIA_NRO,    
      MOTIVO_DEL_TRASLADO,    
      DOMICILIO_DE_PARTIDA,    
      DOMICILIO_DE_DESTINO,    
      CLIENTE_RUC,    
      CLIENTE,    
      TRANSPORTISTA_RUC,    
      TRANSPORTISTA,    
      LICENCIA_CONDUCTOR_NRO,    
      CONDUCTOR,    
      VEHICULO_MARCA,    
      VEHICULO_PLACA,    
      REMOLQUE_MARCA,    
      REMOLQUE_PLACA,    
      CONTRATISTA,    
      LABOR,    
      USUARIO,    
      Errorcod,    
      Errordes    
   )    
   Select    
      Empresa,    
      Anio,    
      Mes,    
      Contador,    
      Item,    
      CANTIDAD,    
      UNIMED,    
      PRODUCTO,    
      PESO,    
      FECHA,    
      GUIA_SERIE,    
      GUIA_NRO,    
      MOTIVO_DEL_TRASLADO,    
      DOMICILIO_DE_PARTIDA,    
      DOMICILIO_DE_DESTINO,    
      CLIENTE_RUC,    
      CLIENTE,    
      TRANSPORTISTA_RUC,    
      TRANSPORTISTA,    
      LICENCIA_CONDUCTOR_NRO,    
      CONDUCTOR,    
      VEHICULO_MARCA,    
      VEHICULO_PLACA,    
      REMOLQUE_MARCA,    
      REMOLQUE_PLACA,    
      CONTRATISTA,    
      LABOR,    
      USUARIO,    
      '1.6',    
      'Producto No Valido : Descripcion del producto debe ser igual a la registrada en maestro de productos'     
   from    
      #Guias_importarOri     
   Where    
      Empresa = @Empresa     
      And usuario = @Usuario     
      And Upper(PRODUCTO) Not in     
      (    
         Select    
            Upper(IN01DESLAR)     
         from    
            in01arti     
         where    
            IN01CODEMP = @Empresa     
            And IN01AA = @Anio    
      )    
      -- Valida Unidad medida de producto          
      Insert Into #Guias_importarError (Empresa,Anio,Mes,Contador,Item,CANTIDAD,UNIMED,PRODUCTO,PESO,FECHA,GUIA_SERIE,    
      GUIA_NRO,MOTIVO_DEL_TRASLADO,   DOMICILIO_DE_PARTIDA,DOMICILIO_DE_DESTINO,    
      CLIENTE_RUC,    
      CLIENTE,    
      TRANSPORTISTA_RUC,    
      TRANSPORTISTA,    
      LICENCIA_CONDUCTOR_NRO,    
      CONDUCTOR,    
      VEHICULO_MARCA,    
      VEHICULO_PLACA,    
      REMOLQUE_MARCA,    
      REMOLQUE_PLACA,    
      CONTRATISTA,    
      LABOR,    
      USUARIO,    
      Errorcod,    
      Errordes    
   )    
   Select    
      Empresa,    
      Anio,    
      Mes,    
      Contador,    
      Item,    
      CANTIDAD,    
      UNIMED,    
      PRODUCTO,    
      PESO,    
      FECHA,    
      GUIA_SERIE,    
      GUIA_NRO,    
      MOTIVO_DEL_TRASLADO,    
      DOMICILIO_DE_PARTIDA,    
      DOMICILIO_DE_DESTINO,    
      CLIENTE_RUC,    
      CLIENTE,    
      TRANSPORTISTA_RUC,    
      TRANSPORTISTA,    
      LICENCIA_CONDUCTOR_NRO,    
      CONDUCTOR,    
      VEHICULO_MARCA,    
      VEHICULO_PLACA,    
      REMOLQUE_MARCA,    
      REMOLQUE_PLACA,    
      CONTRATISTA,    
      LABOR,    
      USUARIO,    
      '1.7',    
      'Unida Medida No Valido '     
   from    
      #Guias_importarOri     
   Where    
      Empresa = @Empresa     
      And usuario = @Usuario     
      And Upper(UNIMED) Not in     
      (    
         Select    
            Upper(In21Codigo)     
         from    
            in21unidad     
         where    
            in21codemp = @Empresa    
      )    
      -- Valida Unidad medida de producto         
      Insert Into #Guias_importarError (Empresa,Anio,Mes,Contador,Item,CANTIDAD,UNIMED,PRODUCTO,PESO,FECHA,    
      GUIA_SERIE,    
      GUIA_NRO,    
      MOTIVO_DEL_TRASLADO,    
      DOMICILIO_DE_PARTIDA,    
      DOMICILIO_DE_DESTINO,    
      CLIENTE_RUC,    
      CLIENTE,    
      TRANSPORTISTA_RUC,    
      TRANSPORTISTA,    
      LICENCIA_CONDUCTOR_NRO,    
      CONDUCTOR,    
      VEHICULO_MARCA,    
      VEHICULO_PLACA,    
      REMOLQUE_MARCA,    
      REMOLQUE_PLACA,    
      CONTRATISTA,    
      LABOR,    
      USUARIO,    
      Errorcod,    
      Errordes    
   )    
   Select    
      Empresa,    
      Anio,    
      Mes,    
      Contador,    
      Item,    
      CANTIDAD,    
      UNIMED,    
      PRODUCTO,    
      PESO,    
      FECHA,    
      GUIA_SERIE,    
      GUIA_NRO,    
      MOTIVO_DEL_TRASLADO,    
      DOMICILIO_DE_PARTIDA,    
      DOMICILIO_DE_DESTINO,    
      CLIENTE_RUC,    
      CLIENTE,    
      TRANSPORTISTA_RUC,    
      TRANSPORTISTA,    
      LICENCIA_CONDUCTOR_NRO,    
      CONDUCTOR,    
      VEHICULO_MARCA,    
      VEHICULO_PLACA,    
      REMOLQUE_MARCA,    
      REMOLQUE_PLACA,    
      CONTRATISTA,    
      LABOR,    
      USUARIO,    
      '1.8',    
      'Unida Medida No Valido '     
   from    
      #Guias_importarOri     
   Where    
      Empresa = @Empresa     
      And usuario = @Usuario     
      And Upper(UNIMED) Not in     
      (    
         Select    
            Upper(In21Codigo)     
         from    
            in21unidad     
         where    
            in21codemp = @Empresa    
      )    
      -- 12.- Valida Número de RUC                                  
      Insert Into    
         #Guias_importarError (Empresa, Anio, Mes, Contador, Item, CANTIDAD, UNIMED, PRODUCTO, PESO, FECHA, GUIA_SERIE,     
         GUIA_NRO, MOTIVO_DEL_TRASLADO, DOMICILIO_DE_PARTIDA, DOMICILIO_DE_DESTINO, CLIENTE_RUC, CLIENTE,     
         TRANSPORTISTA_RUC, TRANSPORTISTA, LICENCIA_CONDUCTOR_NRO, CONDUCTOR, VEHICULO_MARCA,     
         VEHICULO_PLACA, REMOLQUE_MARCA, REMOLQUE_PLACA, CONTRATISTA, LABOR, USUARIO, Errorcod, Errordes)     
         Select    
            Empresa,    
            Anio,    
            Mes,    
            Contador,    
            Item,    
            CANTIDAD,    
            UNIMED,    
            PRODUCTO,    
            PESO,    
            FECHA,    
            GUIA_SERIE,    
            GUIA_NRO,    
            MOTIVO_DEL_TRASLADO,    
            DOMICILIO_DE_PARTIDA,    
            DOMICILIO_DE_DESTINO,    
            CLIENTE_RUC,    
            CLIENTE,    
            TRANSPORTISTA_RUC,    
            TRANSPORTISTA,    
            LICENCIA_CONDUCTOR_NRO,    
            CONDUCTOR,    
            VEHICULO_MARCA,    
            VEHICULO_PLACA,    
            REMOLQUE_MARCA,    
            REMOLQUE_PLACA,    
            CONTRATISTA,    
            LABOR,    
            USUARIO,    
            '1.9', 'RUC de cliente No Valido' from #Guias_importarOri      
 Where  Empresa = @Empresa And usuario = @Usuario     
 And Upper(CLIENTE_RUC) Not in ( Select Upper(Isnull(ccm02cod,'')) from ccm02cta     
 where ccm02emp = @Empresa And ccm02tipana = '01'    
   )    
   End    
   -- Retornar valores                            
   Select     Errorcod,Errordes,Contador,  Empresa,Anio,Mes,Item,CANTIDAD,UNIMED,PRODUCTO,PESO,FECHA,GUIA_SERIE,GUIA_NRO,MOTIVO_DEL_TRASLADO,    
   DOMICILIO_DE_PARTIDA,    
   DOMICILIO_DE_DESTINO,    
   CLIENTE_RUC,    
   CLIENTE,    
   TRANSPORTISTA_RUC,    
   TRANSPORTISTA,    
   LICENCIA_CONDUCTOR_NRO,    
   CONDUCTOR,    
   VEHICULO_MARCA,    
   VEHICULO_PLACA,    
   REMOLQUE_MARCA,    
   REMOLQUE_PLACA,    
   CONTRATISTA,    
   LABOR,    
   USUARIO     
   From    
      #Guias_importarError     
      Where    
         Empresa = @Empresa     
         And usuario = @Usuario     
         Order by    
            Errorcod  
  
  