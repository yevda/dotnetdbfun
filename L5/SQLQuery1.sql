use test
go

delete test
go

insert test values (1)

--SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

begin tran tran1
insert test values (11)
update test set column1 +=2

select 'begin 1', * from test

--waitfor delay '00:00:05';
--rollback tran tran1

--select 'rollback 1', * from test
--go

--waitfor delay '00:00:01';
--select 'commit 2', * from test

