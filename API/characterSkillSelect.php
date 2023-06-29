<?php
    include('connection.php');

    $userId= $_GET['userId'];

    $sqlSkill = "select SkilsID, CharacterID from `Skils_Character` where UserID = ".$userId.";";


    $resultSkill = mysqli_query($connect, $sqlSkill);


    if (mysqli_num_rows($resultSkill) > 0) {
        while ($rowSkill = mysqli_fetch_assoc($resultSkill)) {
            echo "IdSkill:".$rowSkill['ID']."|";
        }
    }
?>