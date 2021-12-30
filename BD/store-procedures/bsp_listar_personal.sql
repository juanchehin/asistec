DROP procedure IF EXISTS `bsp_listar_personal`;
DELIMITER $$

CREATE PROCEDURE `bsp_listar_personal` ()
BEGIN 
	/*
    Procedimiento que devuelve todo el personal de la BD
    */
    SELECT	IdPersonal,Apellidos,Nombres,DNI,Estado
    FROM	personal;
END$$
DELIMITER ;