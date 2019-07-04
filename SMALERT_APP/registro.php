<?php
$servername = "Colom.db.7358553.46a.hostedresource.net";
$username = "Colom";
$password = "Eternidad2680#";
$dbname = "Colom";

// Create connection
$conn = mysqli_connect($servername, $username, $password, $dbname);
// Check connection
if (!$conn) {
    die("Connection failed: " . mysqli_connect_error());
}

$nombres = $_POST["nombres"];
//$correo = $_POST["correo"];
//$clave = $_POST["clave"];
$tipo_discapacidad = $_POST["tipo_discapacidad"];
$edad = $_POST["edad"];
$celular = $_POST["celular"];
$nombre_responsable = $_POST["nombre_responsable"];
$cel_responsable = $_POST["cel_responsable"];
$fecha_registro = date("Y-m-d");
$comentarios = $_POST["comentarios"];
$direccion = $_POST["direccion"];
$ciudad = $_POST["ciudad"];

$sql = "INSERT INTO pacientes (nombres,tipo_discapacidad,edad,celular,nombre_responsable,cel_responsable,fecha_registro,comentarios,direccion,ciudad)
VALUES ('$nombres','$tipo_discapacidad','$edad','$celular','$nombre_responsable','$cel_responsable','$fecha_registro','$comentarios','$direccion','$ciudad')";

if (mysqli_query($conn, $sql)) {
    echo "Ok";
} else {
    echo "Error: " . $sql . "<br>" . mysqli_error($conn);
}

mysqli_close($conn);
?>