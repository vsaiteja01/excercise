create database PayScaleDb
use PayScaleDb
create table payscale(PayBand nvarchar(50) primary key,BasicSalary float)

insert into payscale values('Grade-A',2000);
insert into payscale values('Grade-B',4000);
insert into payscale values('Grade-C',6000);
insert into payscale values('Grade-D',8000);
insert into payscale values('Grade-E',10000);

alter table payscale add HRA as (0.1*BasicSalary) persisted;
alter table payscale add TA as(0.05*BasicSalary) persisted;
alter table payscale add DA as(0.05*BasicSalary) persisted;
alter table payscale add NetSalary as (1.11 * Basicsalary) persisted;
alter table payscale add InHandSalary as (1.01* BasicSalary) persisted;

select * from payscale