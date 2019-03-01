# SEScriptUploaderPlugin

Is ctrl-c, alt-tab, ctrl-v too hard for you? 
Do you ever strugle to copy and paste scripts between visual studio and space engineers?
Well Worry no more! Its as easy as 123!

1) Fix the refs, build the dll, and launch space engineers with the startup param -plugin <ABSOLUTE PATH TO YOUR PLUGIN>.
2) Submit a POST request to localhost:9000/GRIDNAME/BLOCKNAME (no spaces) with the body of the request as your script.
3) Profit

Building a script dynamically? try this to post to your ship.

HttpClient client = new HttpClient();
var response = client.PostAsync($"http://localhost:9000/{shipName}/{blockName}", content).Result;

Not building a script dynamically? What are you doing?!? 

Known Issues:
1) No spaces are allowed in the grid name and block name. Why? Because I didn't fix it. (cough pull request cough)
2) The rest of the code.