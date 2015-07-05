# LogGate
"Logbook As A Service" is a ReST/OWIN service that logs QSO locally and/or to a cloud location.

LogGate uses CouchDb as the backend database.  For the most part CouchDb is LogGate as it meets and excesses  
what I wanted for LogGate.

My original concept was to write a small server that would take ReST request and change them into a SQL
database calls.  So I started looking for a database to meet the following requirements:

	* Easy to install
	* Stable and rock solid
	* Ran on Windows, Linux and Mac
	* Support for many different languages
	* Open Source
	* Mature and Maintained 

CouchDb has the following features:
	
	* Easy to install
	* Run on Windows, Linux and Mac, plus support for browsers include phone via PouchDb.
	* Support for many different languages
	* Open Source as an Apache Project
	* Mature and Maintained - It dates back to at least 2010 which the BBC started to use it as a cluster fault tolerant.
	* Many to Many replication.  Replication is painless.
	* Rock solid.  
	* Cloud support, IBM offers Cloud Couchdb as a service called Cloudant.com.  Any usage under $50 per month 
		isn’t billed ie: free.  That is a lot of data.
	* Plus much more
