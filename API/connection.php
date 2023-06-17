<?php
    /*DB Online*//*
    $server = "db4free.net";
    $username = "arturnic";
    $password = "Luars007";
    $db = "papdatabase";

    /*LocalHost*/

    $server = "localhost";
    $username = "root";
    $password = "tgpsi";
    $db = "pap";



    $connect = mysqli_connect($server, $username, $password, $db);

    // Define a codificação internacional Unicode.
    $connect->set_charset("utf8mb4");
    if (!$connect) {						// Faz a ligação ou devolve o erro ao Mobile
        die("CONNECTION FAIL: ".$connect->connect_error);
    }
?>