# Twitable
System Name: Twitable 
Version: 1.0.0.0 
Developer: Peter Mugisha
Date: 04 May 2016
Description:
A program to simulate a twitter-like feed. Your program will receive two seven-bit ASCII files. The first file contains a list of users and their followers. The second file contains tweets. Given the users, followers and tweets, the objective is to display a simulated twitter feed for each user to the console. Both user.txt and tweet.txt can be found in the Tweet Files folder under the master branch.

Notes and Assumptions
1.	Since only file names are provided as arguments to invoke the console application, the files would have to be stored in a predetermined directory. This directory is stored in the console app.config as the SourceDirectory
2.	The console application arguments are supplied as user.txt,tweet.txt where the former contains usernames (and those they follow) and the latter contains the tweets
3.	File validation will take place in the console application before further processing. The content validation will take place as the data is being read.
4.	Custom exceptions are raised to highlight invalid content
5.	The repository pattern was used in order to have a loose coupling to underlying persistence technology – in this case, flat files.  The repository interface makes it possible to have different implementations without impacting other layers of the solution
6.	Repository interfaces will inherit the IEntityRepository which – for the scope of the assessment – will implement 2 methods;
•	GetAll that returns all entities per file/repository
•	GetByFilter, which filters the entities
