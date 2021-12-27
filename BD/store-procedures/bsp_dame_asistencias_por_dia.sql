DROP procedure IF EXISTS `bsp_dame_asistencias_por_dia`;
DELIMITER $$
CREATE PROCEDURE `bsp_dame_asistencias_por_dia`(pFecha date)
SALIR:BEGIN
	/*
    Permite listar las asistencias de una fecha dada, devuelve una tabla
    con el listado de los DNI, apellidos ,nombres y escuela
    */
	-- Manejo de error en la transacción
	DECLARE EXIT HANDLER FOR SQLEXCEPTION
	BEGIN
		SHOW ERRORS;
		SELECT 'Error en la transacción. Contáctese con el administrador.' Mensaje,
				NULL AS Id;
		ROLLBACK;
	END;
    -- Controla que la fecha sea obligatoria 
	IF pFecha = '' OR pFecha IS NULL THEN
		SELECT 'Debe proveer una fecha' AS Mensaje, NULL AS Id;
		LEAVE SALIR;
    END IF;

	START TRANSACTION;
	SELECT		p.DNI,p.Apellidos,p.Nombres,e.Escuela
    FROM		asistencias a 
				LEFT JOIN personal p on a.Idpersonal = p.IdPersonal
                LEFT JOIN escuelas e on e.IdEscuela = p.IdEscuela
	WHERE		a.FechaEntrada = pFecha
	GROUP BY	p.IdPersonal
    ORDER BY	a.IdAsistencia asc;
    -- LIMIT 		pDesde,5;
        
	SELECT 'OK' AS Mensaje;
    
    COMMIT;
END$$
DELIMITER ;