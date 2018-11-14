/* Install-Package Microsoft.AspNet.WebApi.Cors*/

CREATE TABLE note (
  id int NOT NULL identity(1,1)  ,
  date date NOT NULL,
  title varchar(45) NOT NULL DEFAULT '',
  body varchar(200) NOT NULL DEFAULT '',
  username varchar(20) NOT NULL DEFAULT ''
) 


CREATE TABLE user (
  username varchar(20) NOT NULL DEFAULT '',
  password varchar(45) NOT NULL DEFAULT ''
) 

ALTER TABLE user
  ADD PRIMARY KEY (username);



ALTER TABLE note
  ADD PRIMARY KEY (id)
 

 
ALTER TABLE note
  ADD CONSTRAINT FK_note_1 FOREIGN KEY (username) REFERENCES user (username);

