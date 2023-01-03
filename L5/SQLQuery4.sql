select 
request_session_id as spid,
resource_type as restype,
resource_database_id as bid,
DB_NAME(resource_database_id) as dbname,
resource_description as resdesc,
resource_associated_entity_id as resi,
request_mode as reqmode,
request_status as reqstatus

from sys.dm_tran_locks