<?php   
    include('connection.php');

    $userId = $_POST['userId'];

    $sql = "select * from Item where UserID = ".$userId.";";
    $result = mysqli_query($connect, $sql);

    if (mysqli_num_rows($result) > 0) {
        while ($row = mysqli_fetch_assoc($result)) {
            echo "ID:".$row['ID'].
            "|NameItem:".$row['NameItem'].         
            "|TypeItem:".$row['TypeItem'].            
            "|DescriptionItem:".$row['DescriptionItem'].
            "|HealthBoost:".$row['HealthBoost'].            
            "|StrengthBoost:".$row['StrengthBoost'].
            "|DexterityBoost:".$row['DexterityBoost'].
            "|ConstitutionBoost:".$row['ConstitutionBoost'].
            "|IntelligenceBoost:".$row['IntelligenceBoost'].
            "|ManaBoost:".$row['ManaBoost'].";";
        }
    }
?>