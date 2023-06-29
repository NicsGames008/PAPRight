<?php   
    include('connection.php');

    $userId = $_POST['userId'];

    $sql = "Select * from `Character` where UserID = ". $userId . ";;";
    $result = mysqli_query($connect, $sql);

    if (mysqli_num_rows($result) > 0) {
        while ($row = mysqli_fetch_assoc($result)) {
            echo "ID:".$row['ID'].
            "|NameCharacter:".$row['NameCharacter'].         
            "|Backgroud:".$row['Backgroud'].            
            "|Race:".$row['Race'].
            "|Health:".$row['Health'].            
            "|Strength:".$row['Strength'].
            "|Dexterity:".$row['Dexterity'].
            "|Constitution:".$row['Constitution'].
            "|Intelligence:".$row['Intelligence'].
            "|Mana:".$row['Mana'].";";
        }
    }
?>