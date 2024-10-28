-- Agregar tipo de cambio a otras moneda como euro,
-- Problema reportado : Cuando se venden facturas en euros y tenemos que pasarloa dolares y soles

CREATE TABLE [dbo].[TiCambioOtrasMonedas](
	[Fecha] [datetime] NOT NULL,
	[MonedaOrigenCod] [varchar](2) NOT NULL,
	[MonedaDestinoCod] [varchar](2) NOT NULL,
	[TipoCambio] [decimal](9, 6) NULL,
 CONSTRAINT [PK_TiCambioOtrasMonedas] PRIMARY KEY NONCLUSTERED 
(
	[Fecha] ASC,
	[MonedaOrigenCod] ASC,
	[MonedaDestinoCod] ASC
)
) ON [PRIMARY]


Insert into segformulario (codigo,nombre,descripcion,codmodulo)values('0120','frmTipoCambioMoneda','Tipo cambio moneda otros','03')
insert into segmenu values('0124', 'Tipo de cambio Moneda Otros', '01', '28', '00','', '0120', 'CurrencyExchange_25px.png', '03')
insert into segmenuxperfil values('18','0124', '11111111111111111111', '03')


Create procedure Spu_Fac_Trae_TipoCambioOtrosMoneda  
as  
Begin  
 Select * from TiCambioOtrasMonedas  
end  
  
Go
Create procedure Spu_Fac_Ins_InsertarTipoCambioOtrosMonedas  
@Fecha varchar(10) , -- 01/01/2000  
@MonedaOrigenCod varchar(2) ,  
@MonedaDestinoCod varchar(2) ,  
@TipoCambio decimal(9, 6) ,  
@flag int output,  
@msgretorno  varchar(100) Output    
as  
Begin transaction  
declare @fechaFormateada as datetime  
set @fechaFormateada = convert(datetime, @Fecha, 121)  
  
insert into TiCambioOtrasMonedas(Fecha, MonedaOrigenCod , MonedaDestinoCod , TipoCambio)   
values(@fechaFormateada, @MonedaOrigenCod , @MonedaDestinoCod , @TipoCambio)  
IF @@ERROR <>0    
    BEGIN    
     Set @msgretorno='ERROR :: INESPERADO'    
     GOTO Manejaerror    
    END    
  
Set @msgretorno='OK :: SE GRABO CON EXITO'     
set @flag = 1  
Commit transaction  
return 1  
  
Manejaerror:   
set @flag = -1  
Rollback transaction  
return -1
Go

Create procedure Spu_Fac_Upd_TipoCambioOtrosMoneda  
@Fecha varchar(10) , -- 01/01/2000  
@MonedaOrigenCod varchar(2) ,  
@MonedaDestinoCod varchar(2) ,  
@TipoCambio decimal(9, 6) ,  
@flag int output,  
@msgretorno  varchar(100) Output    
as  
Begin transaction  
  
Update TiCambioOtrasMonedas  
set TipoCambio = @TipoCambio  
where Fecha = @Fecha   
and MonedaOrigenCod = @MonedaOrigenCod   
and MonedaDestinoCod=@MonedaDestinoCod  
if @@error <> 0  
 Begin  
  Set @msgretorno='ERROR :: INESPERADO'    
  GOTO Manejaerror    
 End  
  
  
Set @msgretorno='OK :: SE ACTUALIZO CON EXITO'   
set @flag = 1  
Commit transaction  
return 1  
Manejaerror:   
set @flag = -1  
Rollback transaction  
return -1  
  
Go

Create procedure Spu_Fac_Del_TipoCambioOtrosMoneda  
@Fecha varchar(10),  
@MonedaOrigenCod varchar(2),  
@MonedaDestinoCod varchar(2),  
@flag int output,  
@msgretorno  varchar(100) Output    
  
as  
Begin transaction  
  
delete from TiCambioOtrasMonedas  
where Fecha = convert(datetime, @Fecha ,121)  
and MonedaOrigenCod = @MonedaOrigenCod  
and MonedaDestinoCod = @MonedaDestinoCod  
  
if @@error <> 0  
 Begin  
  Set @msgretorno='ERROR :: INESPERADO'    
  GOTO Manejaerror    
 End  
  
Set @msgretorno='OK :: SE ELIMINO CON EXITO'  
set @flag = 1  
Commit transaction  
return 1  
  
Manejaerror:   
set @flag = -1  
Rollback transaction  
return -1  
  
Go