use test
go

set lock_timeout 5000
go

begin tran tran2
insert test values (22)
update test set column1 +=3;

select * from test
--waitfor delay '00:00:03';
--commit tran tran2;
--select * from test 

set lock_timeout -1