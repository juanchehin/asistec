DROP procedure IF EXISTS `bsp_listar_personal`;
DELIMITER $$

CREATE DEFINER=`root`@`localhost` PROCEDURE `bsp_listar_personal`()
BEGIN 
	/*
    Procedimiento que devuelve todo el personal de la BD
    */
    SELECT	p.IdPersonal,p.Apellidos,p.Nombres,p.DNI,p.Estado,e.Escuela
    FROM	personal p
    inner join escuelas e
    on p.IdEscuela = e.IdEscuela;

END$$
DELIMITER ;