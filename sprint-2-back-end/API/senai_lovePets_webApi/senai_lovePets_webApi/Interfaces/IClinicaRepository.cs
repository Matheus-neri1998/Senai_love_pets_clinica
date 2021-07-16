using senai_lovePets_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Interfaces
{
    interface IClinicaRepository
    {
        List<Clinica> ListarTodos();

        Clinica BuscarPorId(int id);

        void Cadastrar(Clinica NovaClinica);

        void Deletar(int id);

        void Atualizar(int id, Clinica NovaClinica);
    }
}
