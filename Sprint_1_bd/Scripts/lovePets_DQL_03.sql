USE lovePets_tarde;
GO

SELECT * FROM clinica;
SELECT * FROM veterinario;
SELECT * FROM tipoUsuario;
SELECT * FROM usuario;
SELECT * FROM pet;
SELECT * FROM raca;
SELECT * FROM dono;
SELECT * FROM tipoPet;
SELECT * FROM situacao;
SELECT * FROM atendimento;

-- listar todos os veterinários (nome e CRMV) de uma clínica (razão social)
SELECT nomeVeterinario, crmv, razaoSocial FROM veterinario
INNER JOIN clinica
ON veterinario.idClinica = clinica.idClinica;

-- listar todas as raças que começam com a letra S
SELECT * FROM raca
WHERE nomeRaca LIKE 'S%';

-- listar todos os tipos de pet que terminam com a letra O
-- não é CASE SENSITIVE
SELECT * FROM tipoPet
WHERE nomeTipoPet LIKE '%O';

-- listar todos os pets mostrando os nomes dos seus donos
SELECT nomePet, dataNascimento, nomeDono FROM pet
LEFT JOIN dono
ON pet.idDono = dono.idDono;

-- listar todos os atendimentos mostrando o nome do veterinário que atendeu,
-- o nome, a raça e o tipo do pet que foi atendido, o nome do dono do pet
-- e o nome da clínica onde o pet foi atendido
SELECT dataAtendimento [data], nomeVeterinario AS veterinario, nomePet pet, nomeRaca [raça], 
nomeTipoPet especie, nomeDono dono, razaoSocial [razao social]
FROM atendimento
INNER JOIN veterinario
ON atendimento.idVeterinario = veterinario.idVeterinario
INNER JOIN pet
ON atendimento.idPet = pet.idPet
INNER JOIN raca
ON pet.idRaca = raca.idRaca
INNER JOIN tipoPet
ON tipoPet.idTipoPet = raca.idTipoPet
INNER JOIN dono
ON dono.idDono = pet.idDono
INNER JOIN clinica
ON clinica.idClinica = veterinario.idClinica;

SELECT * FROM atendimento
WHERE idAtendimento = 2

DELETE FROM atendimento
WHERE idAtendimento = 1

UPDATE atendimento
SET idSituacao = 2
WHERE idAtendimento = 2