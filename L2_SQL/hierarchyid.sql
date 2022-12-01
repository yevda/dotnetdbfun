--IF OBJECT_ID('NewTree') is not null
--drop table NewTree;

--create table NewTree (
--	NewTreeID hierarchyid PRIMARY KEY,
--	NodeName NVARCHAR(30) UNIQUE
--);

--GO

--INSERT NewTree (NewTreeID, NodeName)
--VALUES (hierarchyid::GetRoot(), 'Root')

----

--SELECT NewTreeID, NewTreeID.ToString(), NewTreeID.GetLevel(), NodeName
--from NewTree
--order by NewTreeID

--DECLARE @Root hierarchyid;
--select @Root = hierarchyid::GetRoot()
--from NewTree;

--INSERT NewTree(NewTreeID, NodeName)
--VALUES (@Root.GetDescendant(NULL, NULL), 'C');

--DECLARE @C hierarchyid
--SELECT @C = NewTreeID
--from NewTree
--WHERE NodeName = 'C'

--INSERT NewTree(NewTreeID, NodeName)
--VALUES (@Root.GetDescendant(NULL, @C), 'A');

--DECLARE @A hierarchyid
--SELECT @A = NewTreeID
--from NewTree
--WHERE NodeName = 'A'

--INSERT NewTree(NewTreeID, NodeName)
--VALUES (@Root.GetDescendant(@A, @C), 'B');

--SELECT NewTreeID, NewTreeID.ToString(), NewTreeID.GetLevel(), NodeName
--FROM NewTree
--order by NewTreeID
----

--INSERT NewTree(NewTreeID, NodeName)
--VALUES(@A.GetDescendant(NULL, NULL), 'AA')

--select * from NewTree
--where NewTreeID.IsDescendantOf(@A) = 1;

--declare @AA hierarchyid
--select @AA = NewTreeID from NewTree
--where NodeName = 'AA';

--select * from NewTree 
--where NewTreeID = @AA.GetAncestor(2)

---

--create proc ExtendTree (@ParentName nvarchar(30), @NewNodeName nvarchar(30))
--as
--begin
--	declare @ParentNode hierarchyid, @childnode hierarchyid;

--	select @ParentNode = NewTreeID
--	from NewTree
--	where NodeName = @ParentName;

--	set transaction isolation level serializable
--	begin transaction
--		select @childnode = max(NewTreeID)
--		from NewTree
--		where NewTreeID.GetAncestor(1) = @ParentNode;

--		insert NewTree (NewTreeID, NodeName)
--		values (@ParentNode.GetDescendant(@childnode, NULL), @NewNodeName);
--	commit
--end;
--go

--exec ExtendTree 'B', 'BA'
--exec ExtendTree 'B', 'BB'
--exec ExtendTree 'B', 'BC'

--exec ExtendTree 'AA', 'AAA'
--exec ExtendTree 'AAA', 'AAAA'

--SELECT NewTreeID, NewTreeID.ToString(), NewTreeID.GetLevel(), NodeName
--FROM NewTree
--order by NewTreeID