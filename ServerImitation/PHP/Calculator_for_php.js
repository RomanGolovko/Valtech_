﻿var num1, num2, action;

function NumBtnPress(e)
{
    resultWindow.value += e;
}

function ActionBtnPress(e)
{
    if (e == '=')
    {
        num2 = parseInt(resultWindow.value);
        Calculate(num1, num2, action);
    }
    else
    {
        action = e;
        num1 = parseInt(resultWindow.value);
        resultWindow.value = "";
    }
}

function Calculate(num1, num2, action)
{
    var request = new XMLHttpRequest();
    function reqReadyStateChange()
    {
        if (request.readyState == 4)
        {
            var status = request.status;
            if (status == 200)
            {
                resultWindow.value = request.responseText;
            }
        }
    }

    var body = "?num1=" + num1 + "&num2=" + num2 + "&action=" + action;
    request.open("GET", "http://127.0.0.1:88/Calculator.php" + body, true);
    request.onreadystatechange = reqReadyStateChange;
    request.send();


    //var body = num1 + "&" + num2 + "&" + action;
    //request.open("POST", "http://127.0.0.1:88/Calculator.php");
    //request.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');
    //request.onreadystatechange = reqReadyStateChange;
    //request.send(body);
}