var nu1, num2, action;

function NumBtnPress(e)
{
    resultWindow.value += e;
}

function ActionBtnPress(e)
{
    if (e == '=')
    {
        num2 = parseInt(resultWindow.value);

        try
        {
            resultWindow.value = Calculate(num1, num2, action);
        } catch (e)
        {
            resultWindow.value = "";
            alert("You can't devide by zero");
        }
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
    var result;
    switch (action)
    {
        case '+': result = num1 + num2; break;
        case '-': result = num1 - num2; break;
        case '*': result = num1 * num2; break;
        case '/':
            {
                if (num2 == 0)
                {
                    throw new DOMException();
                }

                result = num1 / num2;
            } break;
        default: break;
    }
    return result;
}