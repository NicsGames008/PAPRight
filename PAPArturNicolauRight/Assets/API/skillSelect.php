<?php   
    include('connection.php');

    $userId = $_POST['userId'];

    $sql = "select NameSkill, Description from skils where UserId = " . $userId .";";
    $result = mysqli_query($connect, $sql);

    if (mysqli_num_rows($result) > 0) {
        while ($row = mysqli_fetch_assoc($result)) {
            echo "SkillName:".$row['NameSkill']."|Desc:".$row['Description'].";";
        }
    }
?>