# Testing Challenges
We have 2 testing challenges.

## Rocos Platform UI Testing
Rocos.io is a SaaS platform, it has a page to allow users to signup with a given invitation code. The signup page validates user's inputs before sending to the backend api. It is located at url https://portal.rocos.io/signup. 

Your task is to create automated UI tests with your familiar testing framework to cover 5 unhappy pathes of the signup form. One of the tests need to covert the invalid invitation code (invalid invitation code can be constructed by ramdom characters).

### Specflow-Portal-Web by Ki Ueta
#### How to run automated test
1. Download sourcecode
2. Open a solution using Visual Studio
3. Install nuget packages and required sdk.
4. Compile and build solution
6. In Unit Test Explorer, right click on "UnsuccessfulSignUpFeature" test and click "Run Unit Test"
7. Get test result including screenshots in "Bin\Screenshots" folder of running directory.

#### Exclusion due to time constrain.
 - Assertion
   - if the test get extended
 - Test Frameworks
   - Each textboxes error messages have their own ids. It would be better to get error messages without specify element ids.
   - Logging 
   - Better to use Protractor
 - Source code
   - No comments in commited changes since no other contributors and there will be no more changes in the future.
   
   
## Warehouse Robot Control Testing Plan
Your team has been given a Warehouse Robot project. The requirements can be found at repo https://github.com/team-rocos/robot-challenge. As a testing expertise, you've been asked to initiate a testing plan based on the project requirements. One challenge is that your team is under delivery pressure, so you need to think what your team can do to achieve the high testing quality and also meet the delivery deadline.

### Test plan by Ki Ueta
1.Define pre-requisite for the development. 
   - Assumption. e.g.
       - No authentication
       - Average SDK command processing time? to define api timeout. 
       - Robot SDK would make sure the robot will complete the command and doesnt stop in the middle of the grid
   - Out of scope.e.g.
       - RESTfulAPI returns error response due to SDK functions return errors. This is because SDK is under development still.
       - ReSTfulAPI performance testing
       
2.Define and implement required test tools/environments.
   - Preferable Postman as api testing tool.
      - easy to develop and maintain since the requirements can possibly change during the process.
      - can mock the responses.
      - can be shared among team members for developing and testing purposes.
      - can be used as automated tests and included in CI/CD.
      - can be used as a sanity performance testing.
   - a server/ cloud web service for continuouse testing.
   
3.Implement unit test.
   - Should test invalid request data validation. e.g.
      - not sending required fields.
      - [RESTful API to accept a series of commands to the robot.] blank commands, too long commands, invalid commands (not NSWE, lower case, mroe than one space, other delimiters)   
   - Should test basic functionalities. e.g.
      - [RESTful API to accept a series of commands to the robot.] throw error when command move the robot outside the warehouse.
      - [RESTful API cancel the command series] return proper response when command is in execution/ executed/ idle.
      - [RESTful API to report the command series's execution status] return proper command execution status when command is in execution/ executed/ idle.
      
4.Implement automated system test + mock responses using Postman
   - Should test RESTful Api flow. e.g.
      - Send a series of commands >>> then send an execution status request
      - Send a series of commands >>> then send a cancellation of commands >>> then send an execution status request
      
5.Step 3 and 4 can be started once the api design is done and can be done in parallel. A coder and an automated test developer should review each other test scenarios.

6.Implement CI/CD pipeline to start continuous testing.  
Every code pushed and deployed to a test environment will automatically trigger the Postman automated tests.
In the beginning of the process, there might be a lot of failed tests since a coder hasnt finished the RESTful API implementation. it should be more passed tests overtime.
Test execution result can be sent to a coder, an automated test developer or even a product owner to show the development progress.

7.As usual agile process, expect step 3 to 6 will be repeated multiple times. however a turnaround would be quick. A coder would get the feedback faster and the automated test developer would be able to quickly adjust automated tests according to changed requirements.
