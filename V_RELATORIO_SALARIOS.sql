CREATE OR REPLACE VIEW V_RELATORIO_SALARIOS AS
SELECT 
    p.id,
    p.nome,
    p.cidade,
    p.email,
    p.usuario,
    p.telefone,
    c.nome AS CargoNome,
    ps.salario_bruto,
    ps.descontos,
    ps.salario_liquido
FROM 
    pessoa p
JOIN 
    cargo c ON c.id = p.cargo_id
LEFT JOIN 
    pessoa_salario ps ON p.id = ps.pessoa_id
ORDER BY 
    p.nome;