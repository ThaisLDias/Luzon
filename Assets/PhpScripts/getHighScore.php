<?php
$myconnection = mysqli_connect("mysql.hostinger.com.br","u880524449_user","userpass","u880524449_jogos");
if (mysqli_connect_errno()) {
    printf("Connect failed: %s\n", mysqli_connect_error());
    exit();
}
$result = mysqli_query($myconnection, "SELECT id, name, score FROM luzonPlayerScore ORDER BY  `luzonPlayerScore`.`score` DESC 
LIMIT 0 , 5");
			
        while($obj = $result->fetch_object()){ 
	   echo $obj->name . " "; 
           echo $obj->score."/";
        }
	mysqli_free_result($result);
?>						