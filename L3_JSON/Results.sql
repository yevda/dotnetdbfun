create table JSON_TBL (JsonCol nvarchar(max), CompressJsonCol varbinary (max));
go

insert into JSON_TBL (JsonCol, CompressJsonCol)
SELECT c, COMPRESS (c) FROM OPENROWSET (
BULK 'C:\Users\sergey.evdokimov\Source\Repos\dotnetdbfun\L3_JSON\sample_json_16BE.txt',
SINGLE_NCLOB
) as x(c);

SELECT JsonCol, LEN(JsonCol), CAST(DECOMPRESS(CompressJsonCol) as nvarchar(max)), LEN (CompressJsonCol)
FROM JSON_TBL

--SELECT JsonCol, LEN(JsonCol), CompressJsonCol, LEN (CompressJsonCol)
--FROM JSON_TBL

select @@VERSION

DECLARE @json nvarchar(max)

set @json = (select top 1 JsonCol FROM JSON_TBL);

select * from openjson (@json) 

with
(
useremail varchar (200) '$.email'

)