DROP procedure IF EXISTS `bsp_listar_asistencias`;
DELIMITER $$

CREATE DEFINER=`root`@`localhost` PROCEDURE `bsp_listar_asistencias`(in pDesde int)
BEGIN 
	/*
    Procedimiento que devuelve todo el personal de la BD
    */
    SELECT	p.IdPersonal,p.Apellidos,p.Nombres,p.DNI,p.Estado,
    SEC_TO_TIME(SUM(TIME_TO_SEC(TIMEDIFF(a.HorarioSalida,a.HorarioEntrada)))) TotalHoras
    FROM	personal p
    INNER JOIN asistencias a
    on p.IdPersonal = a.IdPersonal
    GROUP BY p.IdPersonal
    LIMIT 		pDesde,5;

END$$
DELIMITER ;