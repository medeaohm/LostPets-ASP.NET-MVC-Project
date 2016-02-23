# Lost Pets - a simple ASP .NET Application

This application is part of the ASP .NET MVC course at Telerik Academy. The purpuse of the application is to allow users to create and share post regarding lost or found pets. Additionally, users can comment post.

The application consists of:

- **public part** (accessible without authentication)
- **private part** (available for registered users)
- **administrative part** (available for administrators only)
    
### Public Part
Not register users can only access the public part of te application, which consist of:
- The **Home page** - showing the 4 most recent posts with lick to to Post Details Page
    ![alt tag](https://raw.githubusercontent.com/medeaohm/LostPets-ASP.NET-MVC-Project/master/images/HomePage-NotRegisteredUsers.jpg)

- **Post Details Page** - shows the posts content and the list of the related comments
    ![alt tag](https://raw.githubusercontent.com/medeaohm/LostPets-ASP.NET-MVC-Project/master/images/DetailsPage-NotRegisteredUsers.jpg)

- **All Posts page** - a pageable, sortable and filterable table containing all the posts. 
    ![alt tag](https://raw.githubusercontent.com/medeaohm/LostPets-ASP.NET-MVC-Project/master/images/All-NotRegisteredUsers.jpg)

- And of course, users can Register/Login
    ![alt tag](https://github.com/medeaohm/LostPets-ASP.NET-MVC-Project/blob/master/images/Register-and-Login.jpg)


### Private Part
Additionally, registered user have access to several other part of the application:

- **Add new post** - user can create new post (and upload related image)
    ![alt tag](https://github.com/medeaohm/LostPets-ASP.NET-MVC-Project/blob/master/images/AddPost-RegisteredUsers.jpg)

- **View and Modify** their own posts 
    ![alt tag](https://github.com/medeaohm/LostPets-ASP.NET-MVC-Project/blob/master/images/ViewMyPosts-RegisteredUsers.jpg)
    - Edit a post
        ![alt tag](https://github.com/medeaohm/LostPets-ASP.NET-MVC-Project/blob/master/images/EditPost-RegisteredUsers.jpg)
    - Delete a post
        ![alt tag](https://github.com/medeaohm/LostPets-ASP.NET-MVC-Project/blob/master/images/DeletePost-RegisteredUsers.jpg)

- **Comment** posts (as well as they are able to delete their own comments)
    ![alt tag](https://github.com/medeaohm/LostPets-ASP.NET-MVC-Project/blob/master/images/Comment-RegisteredUsers.jpg)

- **View and Modify their profile** - of course, they can also view the profiles of the other users
    ![alt tag](https://github.com/medeaohm/LostPets-ASP.NET-MVC-Project/blob/master/images/ViewMyProfile-RegisteredUsers.jpg)
    ![alt tag](https://github.com/medeaohm/LostPets-ASP.NET-MVC-Project/blob/master/images/EditMyProfile-RegisteredUsers.jpg)
    

### Administration Part
The administrator of the page is allowed to:
- **Edit/Delete posts**
    ![alt tag](https://github.com/medeaohm/LostPets-ASP.NET-MVC-Project/blob/master/images/Posts-Admin.jpg)

- **Edit/Delete comments**
    ![alt tag](https://github.com/medeaohm/LostPets-ASP.NET-MVC-Project/blob/master/images/Comments-Admin.jpg)

- **Delete comments**
    ![alt tag](https://github.com/medeaohm/LostPets-ASP.NET-MVC-Project/blob/master/images/Users-Admin.jpg)