USE lovePets_tarde;
GO

INSERT INTO clinica(cnpj, razaoSocial, endereco)
VALUES			   ('99999999999999', 'lovePets', 'Al. Barão de Limeira, 538');
GO

INSERT INTO tipoPet(nomeTipoPet)
VALUES			   ('cachorro'),
				   ('gato');
GO

INSERT INTO dono(nomeDono)
VALUES			('Paulo'),
                ('Odirlei');
GO

INSERT INTO raca(idTipoPet, nomeRaca)
VALUES			(1, 'poodle'),
				(1, 'labrador'),
				(1, 'SRD'),
				(2, 'siamês');
GO

INSERT INTO tipoUsuario(nomeTipoUsuario)
VALUES				   ('administrador'),
					   ('veterinário'),
					   ('pet');
GO

INSERT INTO usuario(idTipoUsuario, email, senha)
VALUES			   (1, 'adm@adm.com', 'adm123'),
				   (2, 'saulo@email.com', 'saulo123'),
				   (2, 'caique@email.com', 'caique123'),
				   (3, 'junior@email.com', 'junior123'),
				   (3, 'loli@email.com', 'loli123'),
				   (3, 'sammy@email.com', 'sammy123');
GO

INSERT INTO pet(nomePet, idRaca, idDono, dataNascimento, idUsuario)
VALUES		   ('junior', 1, 1, '10/10/2018', 4),
			   ('loli', 4, 1, '18/05/2017', 5),
			   ('sammy', 1, 2, '16/06/2016', 6);
GO

INSERT INTO veterinario(idClinica, crmv, nomeVeterinario, idUsuario)
VALUES				   (1, '432551', 'Saulo', 2),
					   (1, '653655', 'Caique', 3);
GO

INSERT INTO situacao(nomeSituacao)
VALUES				('realizada'),
					('agendada'),
					('cancelada');
GO

INSERT INTO atendimento(idPet, idVeterinario, descricao, dataAtendimento, idSituacao)
VALUES				   (1, 1, 'restam 10 dias de vida', '15/07/2021 16:00', 1),
					   (2, 2, 'o paciente está ok', '16/07/2021 17:00', 2),
					   (1, 2, 'o paciente está ok', '17/07/2021 10:00', 3);
GO