DROP procedure IF EXISTS `bsp_dame_personal`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `bsp_dame_personal`(pIdPersonal smallint)
SALIR:BEGIN
	/*
	Procedimiento que sirve para instanciar un personal desde la base de datos.
    */
    IF NOT EXISTS(SELECT pIdPersonal FROM personal WHERE IdPersonal = pIdPersonal ) THEN
		SELECT 'El personal no existe!' AS Mensaje;
		LEAVE SALIR;
    END IF;
    
		SELECT	*
		FROM	personal
		WHERE	IdPersonal = pIdPersonal;
	
END ;;
DELIMITER ;