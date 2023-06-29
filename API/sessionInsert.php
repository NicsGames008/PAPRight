<?php
    include('connection.php');

    $UserId = $_POST['UserId'];
    $nameSession = $_POST['nameSession'];
    $dateSession = $_POST['dateSession'];

    $sql = "insert into`Session`(UserID, NameSession, DateSession) values(".$UserId.", '".$nameSession."', '".$dateSession."');";
    $result = mysqli_query($connect, $sql);
?>