# AccreditGitHubUsers

### Generate GitHub Access Token for the API

 - Follow the steps from:  [How to Generate Github Access Token](https://docs.github.com/en/authentication/keeping-your-account-and-data-secure/creating-a-personal-access-token)
 - Copy the `Access_Token`
 
### Running the Application

 - Clone the repo to your computer or download the project zip file
 - Open the solution in Visual Studio
 - Go to ApiHelper.cs file and add your `Access_Token` on line 14
 - Set the start-up project to be the WebApi project and run the application with Debugging with `F5`
 
### Testing
 
 - Test 1: Search for username `robconery` (Valid Username)
 - Test 2: Search for username `robconer` (Invalid Username)
 - Test 3: Search for username `techyay` (Valid Username with No Public Projects)
