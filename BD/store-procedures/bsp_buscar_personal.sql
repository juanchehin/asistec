DROP procedure IF EXISTS `bsp_buscar_personal`;
DELIMITER $$

CREATE PROCEDURE `bsp_buscar_personal`(pDNI int)
BEGIN
	/*
	Permite buscar personal por DNI
    */
    SELECT		IdPersonal,Apellidos,Nombres,DNI,Estado
    FROM		personal
    WHERE		DNI LIKE CONCAT('%',pTextoBuscar,'%');    
END$$
DELIMITER ;