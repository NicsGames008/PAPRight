<?php
    include('connection.php');

    $userId= $_POST['userId'];
    $nameSkill = $_POST['nameSkill'];

    $sqlSkill = "select ID from skils where NameSkill = '". $nameSkill . "' and UserID = " . $userId . ";";
    $sqlCharacter = "select ID from `Character` WHERE UserId = ".$userId." ORDER BY id DESC LIMIT 1;";


    $resultSkill = mysqli_query($connect, $sqlSkill);
    $resultCharacter = mysqli_query($connect, $sqlCharacter);


    if (mysqli_num_rows($resultSkill) > 0) {
        while ($rowSkill = mysqli_fetch_assoc($resultSkill)) {
            echo "IdSkill:".$rowSkill['ID']."|";
        }
    }

    
    if (mysqli_num_rows($resultCharacter) > 0) {
        while ($rowCharacter = mysqli_fetch_assoc($resultCharacter)) {
            echo "IdCharacter:".$rowCharacter['ID'].";";
        }
    }

?>