
IF OBJECT_ID('TEMPDB..#objetos') IS NOT NULL DROP TABLE #objetos
SELECT	
	[schema] = S.[name],
	[action] = t.[name],
	[object] = O.[Name],	
	id = [object_id],
	create_date
INTO #objetos
FROM SYS.OBJECTS AS O INNER JOIN SYS.SCHEMAS AS S ON O.[schema_id] = S.[schema_id]
join (
	select * from (Values
		('U', 'table'),
		('V', 'view'),
		('P', 'proc'),
		('FN', 'function')
	) t([type], [name])
) T on T.[type] = o.[type]
WHERE S.[Name] = 'SeuLanche'
go

declare 
	@comando varchar(255)

declare c_tabelas cursor local read_only fast_forward for
select 
	comando = concat('drop ', [action], ' ', [schema], '.', [object])
from #objetos
order by 
	id desc,
	create_date desc

open c_tabelas

fetch next from c_tabelas   
into @comando

while @@fetch_status = 0  
begin  
	exec(@comando)

	fetch next from c_tabelas   
	into @comando
end

IF SCHEMA_ID('SeuLanche') IS NOT NULL DROP SCHEMA SeuLanche;

GO
CREATE SCHEMA SeuLanche;