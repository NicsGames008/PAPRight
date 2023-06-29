<?php   
    include('connection.php');

    $userId = $_POST['userId'];

    $sql = "select NameSession, DateSession from `Session` where UserID = ".$userId.";";
    $result = mysqli_query($connect, $sql);

    if (mysqli_num_rows($result) > 0) {
        while ($row = mysqli_fetch_assoc($result)) {
            echo "NameSession:".$row['NameSession'].         
            "|DateSession:".$row['DateSession'].";";
        }
    }
?>