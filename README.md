# dotnet-JavaScript-Object-Communication-API
A framework for communication between c# (dotnet) and JavaScript websites, using a common data transfer object.
Example:
Send new Data Transfer Object in JavaScript:
<code>
//Create a new Data Transfer Object for the request
var request = new DTO("")
//Add a data entry to the request
request.Add("ACTION", "DoSomething")
//Prints the STATUS" attribute of the response from the dotnet backend
API.AsyncGet(request, (response)=>{alert(response.Get("STATUS"));})
</code>
Snipped of complimentary C# Code
<code>
//PostContent should be a string containing the POST body formatted as UTF-8
string HandlePOST(string PostContent)
{
  //Recreate DTO send by JavaScript
  DTO request = new DTO(PostContent);
  //Create new DTO for response
  DTO response = new DTO("");
  //Check if ACTION is DoSomething
  if(request.Get("ACTION") == "DoSomething")
  //Add data to the response object
    response.Add("STATUS", "Requested ACTION was DoSomething!");
  else
    response.Add("STATUS", "Requested ACTION was not DoSomething!");
  //return the DTO as a UTF-8 encoded response to the initial POST request
  return response.ToString();
}
</code>
