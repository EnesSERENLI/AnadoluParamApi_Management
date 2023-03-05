## AnadoluParamApi_Management Project
* In this project, you can create category-based products and add these products to your basket and shop. For example, you created a category called dairy products. You have created a subcategory named cheeses linked to this category. Finally, you can create a product named Sütaş Cheese under this sub-category and add it to your cart and shop.

* You can list created products.
* You can make a category-based product listing.
* You can update and list your shopping cart.
* You can list, update and delete all categories and subcategories.

## How Can I Run the Project

* First of all, you must have MSSql server and MongoDB installed on your computer. In the project, logging operations were made to MongoDB. Everything else is recorded in MSSql.

* Afterwards, you need to enter your MSSql server information, MongoDB information and database information to the places specified in the code line below in the appconfig file within the AnadoluParamApi project.
```
 "ConnectionStrings": {
    "DbType": "SQL",
    "DefaultConnection": "server=DESKTOP-JOE5KI8\\SQLEXPRESS02;Database=AnadoluParamApiDB;Trusted_Connection=True; MultipleActiveResultSets=True;",
    "MongoConnection": "mongodb://localhost:27017",
    "DatabaseName": "AnadoluParamMongoDB"
  }
```
* After entering your server information, open the 'Terminal' and enter the AnadoluParamApi.Data project. Create a migration with the 'dotnet ef migrations add initial' command. Since I created it in this project, you may not need to create it again.

* However, you should still transfer the database into MSSql by running the 'dotnet ef database update' command. Or, you can restore the file with the .bak extension from which you pulled the project into MSSql and run it without doing these operations.

* For RedisCache operations, your computer must have redis installed. Made in CategoryController only.
* You can find RedisCache information in appconfig. Here you should replace it with your own information.
```
 "Redis": {
    "Host": "localhost",
    "Port": "6379",
    "InstanceName": "enessrnli"
  }
```
* In Docker, I created a redis named enesrnli, which is localhost by default. I use this. You can create one yourself.
![Docker](https://user-images.githubusercontent.com/101792073/222928867-02130091-5762-4153-9aea-8fc970763779.png)

* After running the project, you need to register in the system to be able to make a request. You can register with the register shown in the photo below, and then you should get tokens with the account information you created through the login endpoint.

![swaggerUI](https://user-images.githubusercontent.com/101792073/222928394-dbf53676-0eac-4a4e-b996-8fc8dee23ec9.png)<hr/>

* You must copy the token you received and paste it into it by clicking on one of the lock icons on the right on swaggerUI. If so, you will be logged into the system.
![TokenResponse](https://user-images.githubusercontent.com/101792073/222928584-3cf90fcb-02ab-4913-82cd-ff9234e22060.png)<hr/>

* There are 2 roles in the system. For this reason, if you create an account with the role of admin and member, you will receive unauthorized response only on endpoints with admin authority.

![UseAccessToken](https://user-images.githubusercontent.com/101792073/222928611-2b8e8724-8aa3-490e-b92f-669ac614bd23.png)




