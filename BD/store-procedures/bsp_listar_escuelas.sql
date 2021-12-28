DROP procedure IF EXISTS `bsp_listar_escuelas`;
DELIMITER $$

CREATE PROCEDURE `bsp_listar_escuelas` ()
BEGIN 
	/*
    Procedimiento que devuelve todas las escuelas de la BD
    */
    SELECT	IdEscuela,Escuela
    FROM	escuelas;    
END$$
DELIMITER ;