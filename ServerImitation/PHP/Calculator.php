 <?php 

	 $act=$_GET['action'];
	 $num1=intval($_GET['num1']);
	 $num2=intval($_GET['num2']);

  
  $result=0;
  
  switch($act)
  {
	  case "Add": $result = $num1 + $num2; break;
	  case "Sub": $result = $num1 - $num2; break;
	  case "Mul": $result = $num1 * $num2; break;
	  case "Div":
	  {
		  if($num2 == 0)
		  {
			  $result = "You can't divide by zero!";
		  }
		  else
		  {
			  $result = $num1 / $num2; break;
		  }
	  }
  }

  header('Access-Control-Allow-Origin: *');
  echo $result; 
 ?>