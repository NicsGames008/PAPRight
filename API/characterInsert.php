<?php   
    include('connection.php');

    $userId= $_POST['userId'];
    $nameCharacter = $_POST['nameCharacter'];
    $background= $_POST['background'];
    $race= $_POST['race'];
    $health= $_POST['health'];
    $str= $_POST['str'];
    $dex= $_POST['dex'];
    $const= $_POST['const'];
    $int= $_POST['int'];
    $mana= $_POST['mana'];

    
    $sql = "insert into `Character`(UserID, NameCharacter, Backgroud, Race, Health, Strength, Dexterity, Constitution, Intelligence, Mana) values(" . $userId . ", '" . $nameCharacter . "', '" . $background . "', '" . $race . "', " . $health . ", " . $str . ", " . $dex . ", " . $const . ", " . $int . ", " . $mana . ");";
    

    $result = mysqli_query($connect, $sql);

    if (!$result) {
        echo "Error: " . mysqli_error($connect);
    }

?>