create table test 
(
	id int ,
	name varchar(50) ,
	primary key (id)
);

select * from test
update test set id = 1 where id = 100
insert into test values(3,'Tin');