<?php   
    include('connection.php');

    $idSkill= $_POST['idSkill'];
    $idCharacter = $_POST['idCharacter'];
    $idUser = $_POST['idUser'];

  
    $sql = "insert into Skils_Character(SkilsID, CharacterID, UserID) values(".$idSkill.", ".$idCharacter.",".$idUser.");";
    

    $result = mysqli_query($connect, $sql);

    if (!$result) {
        echo "Error: " . mysqli_error($connect);
    }

?>