# SpiceDB.Hierarchical.UI

Recently my team started using SpiceDB for authorization. SpiceDB works on gRPC and very simple to use but there was no Client available through which we can connect and manipulate data/schema on the SpiceDB. So I have created this small utility for the same.   

## FAQ


### How to run SpiceDB on local machine?

Run command  docker run -d --name SpiceDB -p 50051:50051 quay.io/authzed/spicedb serve --grpc-preshared-key "spicedb_token"

This will download docker container for SpiceDB and make it run. After that click on connect menu,  popup window will appear with default values click connect button.

For more detail you can follow this link https://docs.authzed.com/spicedb/installing#docker

### How to Connect to SpiceDB using this Utility?
You clone this Repo and run the code using Visual Studio with .Net6 and above, you will see below popup asking for initializing SpiceDB with sample schema and data. Click Yes
![image2](https://user-images.githubusercontent.com/10897285/208427379-e8688fd0-ac52-4ec6-b151-e76c4b2a92e7.png)



You will see sample data like below 

![image3](https://user-images.githubusercontent.com/10897285/208427487-aed081f1-7e1e-409c-ba1c-7f9c2514ec91.png)




### How can I view Schema?

Click on view schema menu to see schema like below

![image6](https://user-images.githubusercontent.com/10897285/208428092-eceaee8f-d713-43f9-9077-d9ffc91eb3ea.png)


### How can I update Schema?
Click on the Update button after making changes. 

### How can add new relation?
Click on Add Relation menu to add relation, the popup window will show up like below 
![image1](https://user-images.githubusercontent.com/10897285/208428461-17d2afce-2466-48ea-a11f-65f3ac619946.png)

Here you can add relationship based on schema defined by you.

### How can I delete RelationShip?

Select realtionShip in list view and press delete key..

### How can I test permission on my data?

Click on Test menu the popup window will open like below from there you test permissions

![image5](https://user-images.githubusercontent.com/10897285/208428716-8c998620-1a73-4b44-b5c9-97cb1cd26804.png)


### How to export?
You can export data by clicking on export menu. Once the export button is clicked the checkbox will be available against all items in the Authorization tree. You need to select items you want to export and after that click on Complete Export button. MessageBox will show up displaying the name of yaml file with exported data.


### How to import?
You can import any valid yaml file that has data according  to Authorization schema by clicking Import menu and selecting valid yaml file.


### What is use of export/import?
Export/Import feature can be useful when we want to move data from one environment to another environment. Like deveplover can create authorization data on its local machine/docker and then export data that can be pushed to other cloud environments.

### How can I create/update hierarchical tree structure based on my schema.
You can click Tree View Designer Menu the popup window will showup like below. On the left side in the Schema section you will see all the relationship nodes that you can drag and drop on the Tree Layout section. For displaying parent child relationship drag child relationship node on to the parent node from Schema section to Tree Layout section. Once your done you can save changes by click Save menu.

![image4](https://user-images.githubusercontent.com/10897285/208429167-23a320b1-4cb9-4fba-a2b4-8bae6b259509.png)


### How can I change the layout of the tree view?
You can click on Change Layout menu and select the layout file wich you want to use.





