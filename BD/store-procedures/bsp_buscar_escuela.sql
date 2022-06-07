DROP procedure IF EXISTS `bsp_buscar_escuela`;
DELIMITER $$

CREATE PROCEDURE `bsp_buscar_escuela`(pEscuela varchar(60))
BEGIN
	/*
	Permite buscar una escuela
    */
    SELECT		IdEscuela,Escuela,Observaciones
    FROM		escuelas
    WHERE		Escuela LIKE CONCAT('%',pEscuela,'%');    
END$$
DELIMITER ;