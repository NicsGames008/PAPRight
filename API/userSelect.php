<?php
    include('connection.php');

    $sql = "select ID, UserName, aes_decrypt(PassWord, 'shrek') as PassWord, aes_decrypt(Email, 'shrek') as Email FROM User;";
    $result = mysqli_query($connect, $sql);

    if (mysqli_num_rows($result) > 0) {
        while ($row = mysqli_fetch_assoc($result)) {
            echo "Id:".$row['ID']."|username:".$row['UserName']."|email:".$row['Email']."|password:".$row['PassWord'].";";
        }
    }

?>