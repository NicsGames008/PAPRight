<?php   
    include('connection.php');

    $userId = $_POST['userId'];

    $sql = "Select NameCharacter, AvatarCharacter from `Character` where UserID = ". $userId . ";;";
    $result = mysqli_query($connect, $sql);

    if (mysqli_num_rows($result) > 0) {
        while ($row = mysqli_fetch_assoc($result)) {
            echo "CharacterName:".$row['NameCharacter']."|Avatar:".$row['AvatarCharacter'].";";
        }
    }
?>