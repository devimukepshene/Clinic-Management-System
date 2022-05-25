

use Clinic 
go
--login credential
create table loginval
(
UserName Varchar(40),
Pasword varchar(10)
)
drop table loginval
select * from loginval


--procedure for loginvalidate
alter proc loginvalidate
@user varchar(20),
@pass varchar(20)
as
select * from loginval where UserName like @user and Pasword like @pass

drop proc loginvalidate


--Add Docter
create table AddDocter
(
DocterID int identity(1,1),
FirstName varchar(20),
LastName varchar(20),
Gender varchar(9),
Specialization varchar(20),
Visiting_Hours varchar(20),
Constraint Pk_DocID Primary Key(DocterID)
)
drop table AddDocter
select * from AddDocter
create proc Newdocdetails
@Doc_Fname varchar(20),
@Doc_Lname varchar(20),
@Gen varchar(9),
@spl varchar(20),
@hrs varchar(20)
as
insert into AddDocter(FirstName,LastName,Gender,Specialization,Visiting_Hours)
values(@Doc_Fname,@Doc_Lname,@Gen,@spl,@hrs)

exec Newdocdetails
drop proc Newdocdetails

create proc Docterinfo
as
select * from AddDocter


--Add Patients
create table AddPatients
(
PatientID int,
FirstName varchar(20),
LastName varchar(20),
Gender Varchar(9),
Age Varchar(10),
DOB varchar(50),
Constraint PK_PatID Primary Key(PatientID)
)
drop table AddPatients
select * from AddPatients
alter proc NewPatientDetails
@patientid int,
@pat_Fname varchar(20),
@Pat_Lname varchar(20),
@gen Varchar(9),
@age Varchar(10),
@dob Varchar(50)
as
insert into AddPatients(PatientID,FirstName,LastName,Gender,Age,DOB)
values(@patientid,@pat_Fname,@Pat_Lname,@gen,@age,@dob)

exec NewPatientDetails
drop NewPatientDetails
go

alter proc Patientinfo
as
select * from AddPatients

--schedule procedure
Create table Scheduledet
(
patientID int,
Specialization varchar(20),
Docter varchar(30),
VisitDate varchar(40),
AppointmentTime varchar(30)
)
select * from Scheduledet
drop table Scheduledet
create proc Scheduledetails
@patientid int,
@Spl varchar(20),
@doc varchar(20),
@visit varchar(40),
@v_time varchar(30)
as
insert into Scheduledet(patientID,Specialization,Docter,VisitDate,AppointmentTime)
values(@patientid,@Spl,@doc,@visit,@v_time)

drop proc Scheduledetails

alter proc Scheduleinfo
as
Select * from Scheduledet

--CancelAppointment
create proc CancelAppointment
@patientid varchar(20),
@visit varchar(40)
as
delete from Scheduledet where PatientID=@patientid and VisitDate=@visit 
drop proc CancelAppointment

insert into loginval values('Suvetha','suvi@123')
insert into loginval values('padma','padhu701')
insert into loginval values('Gobi','gobi201')


insert into scheduledet values(1,'Dermatologist','Chandrashekar','22-12-2022','01:00PM-02:00PM')
insert into scheduledet values(2,'Opthamology','SuryaPrakash','31-07-2022','02:00PM-03:00PM')
insert into scheduledet values(3,'Orthopedics','Karthickeyan','06-10-2022','03:00PM-04:00PM')

delete from Scheduledet where patientID=2

insert into AddDocter values('Surya','Prakash','Male','Opthamology','02:00PM-03:00PM')
insert into AddDocter values('Chandra','shekar','Male','Dermatologist','01:00PM-02:00PM')
select * from AddDocter
select * from AddPatients
select * from scheduledet
select * from loginval

delete from AddDocter where DocterID =2
