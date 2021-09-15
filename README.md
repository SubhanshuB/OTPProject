# OTPProject
An OTP based login app which uses React as Frontend , (.NET) Core as Backend & MongoDB as Database.

Following are the Software Required to run the Application in local : 
### 1. Visual Studio  (https://visualstudio.microsoft.com/)
### 2. Node (https://nodejs.org/en/)
### 3. MongoDB (https://www.mongodb.com/try/download/community)
### 4. VS Code* (https://code.visualstudio.com/download) 
### 5. Postman* : To Test API (https://www.postman.com/downloads/)
*Not Mandatory

## Steps : -

#### 1. Open MongoDB Compass / CLI(make sure it is running on port number27017 which is the default port) and create database OTPStoreDb with collection name PhonenumberOTP.
#### 2. Create another database UserStoreDB with collection name Users.
#### 3. Create a Folder where you want to clone the project.
#### 4. Open Powershell in that folder and run command **_git clone https://github.com/SubhanshuB/OTPProject.git_** OR If you don't have git install you can directly download(https://github.com/SubhanshuB/OTPProject/archive/refs/heads/main.zip) the zip file and extract it in this folder.
#### 5. Open API folder then  open Visual Studio Solution(.sln) file in Visual Studio.
#### 6. Once opened, run the project in IIS Server.
#### 7. Now open the UI folder and then run powershell window in that.
#### 8. Run the following commands to install dependencies :  
Bootstrap : npm install react-bootstrap@next bootstrap@5.1.0  
Axios : npm install axios --save  
Typerwriter : npm i typewriter-effect  

#### 9. Run command *npm start* to run the application. DONE!
Below are the screenshots: 
## React Frontend 
![Screenshot (77)](https://user-images.githubusercontent.com/30664033/133466164-dcfcdef0-ee65-42d0-963c-27b33864e79f.png)
## .NET Core Backend
![Screenshot (91)](https://user-images.githubusercontent.com/30664033/133466364-f094f143-ff08-4343-b83e-d99df57baae0.png)
## MongoDb
![Screenshot (78)](https://user-images.githubusercontent.com/30664033/133466382-fb7dd3a3-0dc3-4af4-a729-45c74b56fe98.png)
# Thank You!
