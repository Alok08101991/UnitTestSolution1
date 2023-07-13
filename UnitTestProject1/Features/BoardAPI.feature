Feature: BoardAPI
	In order to avoid getting bored
	As a API automtion idiot
	I want to create activities

@mytag
Scenario Outline: Create Activities
	Given I have the <ActivityType> activity to be provided to <CountofPeople>
	And the name of the <Activitiy> based on <UniqueKey>
	When the Activities are created
	Then verify the sucess response 
	And verify the <ActivityType>, <Activitiy> & <CountofPeople> are correct in the response

	Examples: 
	| UniqueKey | ActivityType | Activitiy                                          | CountofPeople |
	| 6081071   | social       | Text a friend you haven't talked to in a long time | 2             |
	| 9149470   | social       | Compliment someone                                 | 2             |
	| 1505028   | social       | Go swimming with a friend                          | 2             |