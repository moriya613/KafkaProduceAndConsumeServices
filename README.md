1) - Prerequisite -

	Please Install:

	7Zip		https://www.7-zip.org/download.html

	JRE8		http://www.oracle.com/technetwork/java/javase/downloads/jre8-downloads-2133155.html

	zookeeper	https://zookeeper.apache.org/releases.html

	kafka		http://kafka.apache.org/downloads.html


2) - Run Kafka -

	Zookeeper Start 		C:\kafka-2.12>	zkServer

	Kafka Start				C:\kafka-2.12>	.\bin\windows\kafka-server-start.bat .\config\server.properties

	Create Topic			C:\kafka-2.12\bin\windows>	kafka-topics.bat --create --zookeeper localhost:9092 --replication-factor 1 --partitions 1 --topic LSports


3) - Run visual Studio solution attached - 
	Just run it , it will call the consumer and producer
	the Json file with all the messages is already attached as embedded file
	the messages will be printed in the consule
