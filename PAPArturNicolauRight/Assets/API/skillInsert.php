<?php   
    include('connection.php');

    $userId= $_POST['userId'];
    $nameSkill = $_POST['nameSkill'];
    $minLevel= $_POST['minLevel'];
    $Desc= $_POST['desc'];
    $damage= $_POST['damage'];
    $minHealth= $_POST['minHealth'];
    $minStr= $_POST['minStr'];
    $minDex= $_POST['minDex'];
    $minConst= $_POST['minConst'];
    $minInt= $_POST['minInt'];
    $minMana= $_POST['minMana'];
    $animation= $_POST['animation'];
    $isMagic= $_POST['isMagic'];
    $cost = $_POST['cost'];
    $effect = $_POST['effect'];
    $effectValue = $_POST['effectValue'];

    if ($isMagic == 0) {
        $sql = "insert into Skils(UserID, NameSkill, MinLevel, Description, Damage, MinHealth, MinStrength, MinDex, MinConst, MinInt,MinMana , Animation, IsMagic) values(".$userId.",'".$nameSkill."',".$minLevel.",'".$Desc."',".$damage.",".$minHealth.",".$minStr.",".$minDex.",".$minConst.",".$minInt.",".$minMana.",'".$animation."','".$isMagic."');";
    }
    else if ($isMagic == 1) {
        $sql = "insert into Skils(UserID, NameSkill, MinLevel, Description, Damage, MinHealth, MinStrength, MinDex, MinConst, MinInt,MinMana , Animation, IsMagic, Cost, Effect, EffectValue) values(".$userId.",'".$nameSkill."',".$minLevel.",'".$Desc."',".$damage.",".$minHealth.",".$minStr.",".$minDex.",".$minConst.",".$minInt.",".$minMana.",'".$animation."','".$isMagic."', ".$cost.", '".$effect."', ".$effectValue.");";
    }

    $result = mysqli_query($connect, $sql);

    if (!$result) {
        echo "Error: " . mysqli_error($connect);
    }

    $result2 =  mysqli_query($connect,"select * from Skils;");

    if (mysqli_num_rows($result2) > 0) {
        while ($row = mysqli_fetch_assoc($result2)) {
            echo "SkillName:".$row['NameSkill']."|Desc:".$row['Description'].";";
        }
    }
?>
