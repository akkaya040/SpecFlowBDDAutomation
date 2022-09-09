Feature: ApiWithGherkin
This Sample Api Test Contains CRUD Operations For Petstore

    Background:
        Given The user set base url as : https://petstore.swagger.io/v2

    @POST
    @CreateAUser
    Scenario: Create A User
        Given The user sends post request to /user/createWithArray
        * The user should see the response 200

    @Positive
    @GET
    @GetInsertedUser
    Scenario: Get Inserted User
        Given The user sends post request to /user/createWithArray
        Given The user sends get request to /user/specflowkurtulus
        * The user should see the response 200

    @PUT
    @UpdateAUser
    Scenario: Update A User
        Given The user sends post request to /user/createWithArray
        Given The user sends put request to /user/specflowkurtulus
        * The user should see the response 200

    @DELETE
    @UpdateAUser
    Scenario: Delete A User
        Given The user sends delete request to /user/specflowkurtulus
        * The user should see the response 200
        Given The user sends get request to /user/specflowkurtulus
        * The user should see the response 404

    @Negative
    @GET
    @GetUnknownUser
    Scenario: Get Unknown User
        Given The user sends get request to /user/kurtulusmehmetakkaya3213
        * The user should see the response 404