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
    ![alt tag](https://raw.githubusercontent.com/medeaohm/LostPets-ASP.NET-MVC-Project/master/images/Register-Login.jpg)