<?php   
    include('connection.php');

    $idSkill= $_POST['idSkill'];
    $idCharacter = $_POST['idCharacter'];
  
    $sql = "insert into Skils_Character(SkilsID, CharacterID) values(".$idSkill.", ".$idCharacter.");";
    

    $result = mysqli_query($connect, $sql);

    if (!$result) {
        echo "Error: " . mysqli_error($connect);
    }

?>