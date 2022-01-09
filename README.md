## JISPEN – a simple tool for waste registration in hospitals and medical institutions

### Challenge:
Create a program for waste management and registration in medical institutions with the possibility of importing data into ENVITA with the subsequent creation of an annual report on waste production

### Basic requirements:
1. Free application
2. The installation of supporting files, systems or libraries must not be required to run the application

### Main features:
1. Possibility to manually create a template for creating records
2. Record keeping using the edit form
3. Export data of created records to XML format

### Solution:
The task is solved by creating a web application with a simple graphical interface. Care is taken for the simplicity of control, so that working with the program and its installation does not require any expanding knowledge.

### Technologies:
Database: PostgreSQL 13\
Back-end: C#, ASP.NET 5, Entity Framework 5\
Front-end: Typescript, React, Material-UI

### Database design:
![jispen_psql](https://user-images.githubusercontent.com/63300936/145693348-a8bb8c2d-0579-4c83-b159-e56218decaeb.png)

### Connecting to the database:
Entity Framework 5 is used to connect to the database.\
All tables and enitites are defined in `ApplicationContext` class.\
Instance of `ApplicationContext` is used in persistance classes to get access to specific table.\
<img src="https://user-images.githubusercontent.com/63300936/148684080-16e9f5ab-f15f-497f-8723-0c804932fd91.png" /><br/>
<img src="https://user-images.githubusercontent.com/63300936/148684098-7f311081-8562-479c-9edf-ed1d699a4c8e.png" />

### SQL Injection:
Beacuse of using Entity Framework prevention of SQL injections is easier.\
Also, almost all controllers' parameters are of the "long" type, which does not allow sending invalid data (like "1 or 1=1" to select SQL).\
The only way to send a `string` value to the program is a user controller, however, it accepts 2 parameters, one of which is a password that is hashed before being sent to the database, which prevents SQL injections.
