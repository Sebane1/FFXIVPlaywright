Welcome to FFXIV Playwright, a group macro builder intended for coordinating skits, plays, or any other group coordinated macro functions that are desired.


##A written group macro may look like this:

PersonOne: "Hello! this is a group macro tutorial" <wait.5>
PersonTwo: "And I'm a second person who will be participating in this macro!" <wait.5>
PersonOne: "Each person should be correctly named with no spaces, and all their dialogue should take place on the same line if possible before going on to the next person" <wait.5>
PersonTwo: "All dialogue should be in quotations, otherwise it might be confused as a command argument" <wait.5>
PersonOne: "We can use commands and dialogue on the same line" <wait.1> /happy <wait.5> 
PersonTwo: /happy <wait.1> "I'm very happy to show this off, so happy I may want to cheer" <wait.1> /cheer <wait.1> "See! Look how loud I can cheer!"
PersonOne: "And this concludes the tutorial! If you're familiar with FFXIV commands and macros, this program aims to use your existing knowledge of those" 
PersonTwo: "But now you can just worry about the big picture macro! This program will split it up into individualized chunks after the fact!" <wait.1> /cheer <wait.1>
PersonOne: "Hooray!" <wait.4> /welcome

##And will be automatically split up like this for PersonOne:

"Hello! this is a group macro tutorial" <wait.10>
"Each person should be correctly named with no spaces, and all their dialogue should take place on the same line if possible before going on to the next person" <wait.10>
"We can use commands and dialogue on the same line" <wait.1>
/happy <wait.9>
"And this concludes the tutorial! If you're familiar with FFXIV commands and macros, this program aims to use your existing knowledge of those" <wait.2>
"Hooray!" <wait.4>
/welcome

##And will be automatically split up like this for PersonTwo:

<wait.5>
"And I'm a second person who will be participating in this macro!" <wait.10>
"All dialogue should be in quotations, otherwise it might be confused as a command argument" <wait.11>
/happy <wait.1>
"I'm very happy to show this off, so happy I may want to cheer" <wait.2>
/cheer <wait.3>
"See! Look how loud I can cheer!" 
"But now you can just worry about the big picture macro! This program will split it up into individualized chunks after the fact!" <wait.1>
/cheer <wait.2>

##Keep in mind, that this tool is not limited to just generating macros between two people, and can theoretically keep track of as many people as you feasibly require for the group macro




