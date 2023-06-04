# Computing Technology Design Project

Design database system Swinburne Unit COS20031 Semester 01 / 2023

## BackEnd

Models were written based on business requirements then Repositories were crafted based on business logic.
There are some common features such as GetAll and GetById thus IRepository was made as a general interface to prevent duplication and repetitive tasks.
![image](https://github.com/InfiniteBlanK3T/Computing-Technology-Design-Project/assets/94949422/28bb9152-5caf-427a-8671-601106579511)
There are some specific cases that business logic that required thus some repositories were made specific to satisfy it.\
*Here is EndsService with specific requirements*
![image](https://github.com/InfiniteBlanK3T/Computing-Technology-Design-Project/assets/94949422/7401d888-a4fe-4a95-aa69-c5b61ee8a3ba)
![image](https://github.com/InfiniteBlanK3T/Computing-Technology-Design-Project/assets/94949422/697ff732-c1c1-4035-b970-4aefd3999225)
Same for Controllers when handling APIs Call, GenericControllers were made to handle common APIs calls that all the Controllers shared.\
![image](https://github.com/InfiniteBlanK3T/Computing-Technology-Design-Project/assets/94949422/777821dd-f3dd-460b-b7ed-028ceba49598)
Same as repo, if there were some specific requirements to fulfil specific needs regarding API, the Controllers will be made to fulfil it.\
![image](https://github.com/InfiniteBlanK3T/Computing-Technology-Design-Project/assets/94949422/2c752a2c-1de1-401c-8f42-5ae62af20ae1)

## Front End

![image](https://github.com/InfiniteBlanK3T/Computing-Technology-Design-Project/assets/94949422/d482d769-f900-4cc3-8a5b-e626d0a32c8d)
Only after Round and Archer are selected, the Equipment option would show up, "Recurve" here is the default equipment. Then user could moving onto next phase, choosing specific range and end that they want to record.\
![image](https://github.com/InfiniteBlanK3T/Computing-Technology-Design-Project/assets/94949422/bf073954-b053-4d1d-8215-8409b5760f70)
Based on the Number Of Ends here the recording will record the user scores
![image](https://github.com/InfiniteBlanK3T/Computing-Technology-Design-Project/assets/94949422/59be59e1-ac43-468f-81fb-a3296b1d7df1)\
Then finally, it will sum up all the score in each ends so that user could submit their scores.\
![image](https://github.com/InfiniteBlanK3T/Computing-Technology-Design-Project/assets/94949422/954c4064-8396-442f-b612-8d8eac3cbc65)

## License

[MIT](https://choosealicense.com/licenses/mit/)
