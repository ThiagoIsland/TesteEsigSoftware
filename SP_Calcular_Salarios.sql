create or replace NONEDITIONABLE PROCEDURE SP_CALCULAR_SALARIOS AS 
BEGIN
  DELETE FROM pessoa_salario;
  
  FOR p IN (SELECT id, nome, cargo_id from Pessoa) LOOP
  
  DECLARE 
        var_salario_base    NUMBER(10, 2) := 0;
        var_salario_bruto   NUMBER(10, 2) := 0;
        var_total_descontos NUMBER(10, 2) := 0;
        var_salario_liquido NUMBER(10, 2) := 0;
    BEGIN 

        SELECT NVL(SUM(v.valor), 0)
        INTO var_salario_base
        FROM cargo_vencimentos cv
        JOIN vencimentos v ON cv.vencimentos_id = v.id
        WHERE cv.cargo_id = p.cargo_id
            AND v.tipo = 'C'
            AND v.forma_incidencia = 'V';
        
        var_salario_bruto := var_salario_base;

        FOR creditos_perc IN (
        SELECT v.valor
        FROM cargo_vencimentos cv
        JOIN vencimentos v ON cv.vencimentos_id = v.id
        WHERE cv.cargo_id = p.cargo_id
            AND v.tipo = 'C'
            AND v.forma_incidencia = 'P' 
        ) LOOP
            var_salario_bruto := var_salario_bruto + (var_salario_base * (creditos_perc.valor / 100));
        END LOOP;
        
        FOR descontos_item IN (
        SELECT v.valor, v.forma_incidencia
        FROM cargo_vencimentos cv
        JOIN vencimentos v ON cv.vencimentos_id = v.id
        WHERE cv.cargo_id = p.cargo_id
            AND v.tipo = 'D' 
        ) LOOP
        IF descontos_item.forma_incidencia = 'V' THEN
           var_total_descontos := var_total_descontos + descontos_item.valor;
        ELSE 
           var_total_descontos := var_total_descontos + (var_salario_bruto * (descontos_item.valor / 100));
        END IF;
        END LOOP;
        
        var_salario_liquido := var_salario_bruto - var_total_descontos;

        INSERT INTO pessoa_salario (pessoa_id, nome, salario_bruto, descontos, salario_liquido)
        VALUES (p.id, p.nome, var_salario_bruto, var_total_descontos, var_salario_liquido);

        END;
    END LOOP;
    COMMIT;
END SP_CALCULAR_SALARIOS;