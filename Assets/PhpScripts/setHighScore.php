<?php 
	
	$con = mysqli_connect("mysql.hostinger.com.br","u880524449_user","userpass","u880524449_jogos");
if (!$con)
  {
  die('Could not connect: ' . mysql_error());
  }
 
	$sql="INSERT INTO luzonPlayerScore (id, name,score)
	VALUES
	(NULL,'$_POST[nome]','$_POST[score]')";
if (!mysqli_query($con,$sql))
  {
  die('Error: ' . mysql_error());
  }
echo "1 record added";
 
mysqli_close($con);
	
	
?>