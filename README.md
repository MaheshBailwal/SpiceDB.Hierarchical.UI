# SpiceDB.Hierarchical.UI

## FAQ


### How to run SpiceDB on local machine?

Run command  docker run -d --name SpiceDB -p 50051:50051 quay.io/authzed/spicedb serve --grpc-preshared-key "spicedb_token"

This will download docker container for SpiceDB and make it run. After that click on connect menu,  popup window will appear with default values click connect button.

You will see below popup asking for init SpiceDB with sample schema and data. Click Yes



You will see sample data like below 



https://docs.authzed.com/spicedb/installing#docker

->How can view Schema 

Click on view schema menu to see schema like below



->How can I update Schema
Click on the Update button. 

->How can add new relation
Click on Add Relation menu to add relation, the popup window will show up like below 



Here you can add relationship based on schema defined by you.

->How can I delete RelationShip.

Select realtionShip in list view and press delete key..

-> How can I test permission on my data?

Click on Test menu the popup window will open like below from there you test permissions



Q. How to export.
A. You can export data by clicking on export menu. Once the export button is clicked the checkbox will be available against all items in the Authorization tree. You need to select items you want to export and after that click on Complete Export button. MessageBox will show up displaying the name of yaml file with exported data.


Q. How to import.
A. You can import any valid yaml file that has data according  to Authorization schema by clicking Import menu and selecting valid yaml file.


Q. What is use of export/import.
A. Export/Import feature can be useful when we want to move data from one environment to another environment. Like deveplover can create authorization data on its local machine/docker and then export data that can be pushed to other cloud environments.
Q. How can I create/update hierarchical tree structure based on my schema.
You can click Tree View Designer Menu the popup window will showup like below. On the left side in the Schema section you will see all the relationship nodes that you can drag and drop on the Tree Layout section. For displaying parent child relationship drag child relationship node on to the parent node from Schema section to Tree Layout section. Once your done you can save changes by click Save menu.

Q. How can I change the layout of the tree view?
You can click on Change Layout menu and select the layout file wich you want to use.





