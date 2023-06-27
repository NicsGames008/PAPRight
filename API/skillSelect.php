<?php   
    include('connection.php');

    $userId = $_POST['userId'];

    $sql = "select * from skils where UserId = " . $userId .";";
    $result = mysqli_query($connect, $sql);

    if (mysqli_num_rows($result) > 0) {
        while ($row = mysqli_fetch_assoc($result)) {
            echo "ID:".$row['ID'].
            "|NameSkill:".$row['NameSkill'].
            "|MinLevel:".$row['MinLevel'].
            "|Description:".$row['Description'].
            "|Damage:".$row['Damage'].
            "|IsMagic:".$row['IsMagic'].
            "|Cost:".$row['Cost'].
            "|Effect:".$row['Effect'].
            "|EffectValue:".$row['EffectValue'].
            "|MinHealth:".$row['MinHealth'].
            "|MinStrength:".$row['MinStrength'].
            "|MinDex:".$row['MinDex'].
            "|MinConst:".$row['MinConst'].
            "|MinInt:".$row['MinInt'].
            "|MinMana:".$row['MinMana'].";";
        }
    }
?>