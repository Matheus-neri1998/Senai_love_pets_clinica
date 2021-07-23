import axios from "axios";
import { Component } from "react";

export default class atendimentos extends Component{

    constructor(props){
        super(props);
        this.state = {
          // nomeEstado : valorInicial
          ListaAtendimentos : [],
          IdPet : 0,
          IdVeterinario : 0,
          Descricao : '',
          data : new Date(),
          hora : '',
          IdSituacao : 0,
          ListaVeterinarios : [],
          ListaPets : [],
          ListaSituacoes : [],
          
        };
      };
    
      BuscarAtendimentos = () => {
        console.log('Esta função traz todos os atendimentos')
    
        fetch('http://localhost:5000/api/atendimento')
    
        .then(resposta => {
          if (resposta.status !== 200) {
            throw Error();
          }

          return resposta.json();
        })
    
        .then(resposta => this.setState({ ListaAtendimentos : resposta }))
    
        .catch(erro => console.log(erro));
      }; // fim de BuscarAtendimentos

      BuscarVeterinarios = () => {
        fetch('http://localhost:5000/api/veterinario', {
          headers : {
            'Authorization' : 'Bearer' + localStorage.getItem('usuario-login')
          }
        })

        .then(resposta => {
          if (resposta.status !== 200) {
            throw Error();
          }
          return resposta.json();
        })

        .then(resposta => this.setState({ ListaVeterinarios : resposta }))

        .catch(erro => console.log(erro));
      }; // fim de BuscarVeterinarios

      BuscarPets = () => {
        fetch('http://localhost:5000/api/pet', {
          headers : {
            'Authorization' : 'Bearer' + localStorage.getItem('usuario-login')
          }
        })

        .then(resposta => {
          if (resposta.status !== 200) {
            throw Error();
          }
          return resposta.json();
        })

        .then(resposta => this.setState({ ListaPets : resposta }))

        .catch(erro => console.log(erro));

      }; // fim de BuscarPets

      BuscarSituacoes = () => {
        fetch('http://localhost:5000/api/situacao', {
          headers : {
            'Authorization' : 'Bearer' + localStorage.getItem('usuario-login')
          }
        })

        .then(resposta => {
          if (resposta.status !== 200) {
            throw Error();
          }
          return resposta.json();
        })

        .then(resposta => this.setState({ ListaSituacoes : resposta }))

        .catch(erro => console.log(erro));
      }; // fim de BuscarSituacoes
     
      componentDidMount(){
        this.BuscarAtendimentos();
        this.BuscarVeterinarios();
        this.BuscarPets();
        this.BuscarSituacoes();
      }; 

      CadastrarAtendimento = (event) => {
        event.PreventDefault();

        let Atendimento = {
          IdPet               :        this.state.IdPet,
          IdVeterinario       :        this.state.IdVeterinario,
          Descricao           :        this.state.Descricao,
          DataAtendimento     :        this.state.data + 'T' + this.state.hora,
          IdSituacao          :        this.state.IdSituacao,
        }

        axios.post('http://localhost:5000/api/atendimento', Atendimento, {
          headers : {
            'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
          }
        })
    
        .then(resposta => {
          if (resposta.status === 201) {
            console.log('Um novo atendimento foi agendado!')
          }
        })
    
        .catch(erro => console.log(erro))
    
        .then(this.BuscarAtendimentos);

      } // Fim de CadastrarAtendimento
    
      atualizaStateCampo = (campo) => {
        // exemplo          idPet           :       1
        this.setState({ [campo.target.name] : campo.target.value })
      };
    


      render(){
        return(
          <div>
            <h1>Gerenciar Atendimentos</h1>
    
            <section>
              <h2>Lista dos Atendimentos</h2>
    
              <table>
    
                <thead>
                  <tr>
                    <th>#</th>
                    <th>Pet</th>
                    <th>Veterinário</th>
                    <th>Descrição</th>
                    <th>Data de Atendimento</th>
                    <th>Situação</th>
                  </tr>
                </thead>
    
                <tbody>
    
                  {
                    this.state.ListaAtendimentos.map( (atendimento) => {
                      return(
    
                        <tr key={atendimento.IdAtendimento}>
                          <td>{atendimento.IdAtendimento}</td>
                          <td>{atendimento.IdPetNavigation.nomePet}</td>
                          <td>{atendimento.IdVeterinarioNavigation.nomeVeterinario}</td>
                          <td>{atendimento.Descricao}</td>
                          <td>{Intl.DateTimeFormat("pt-BR", {
                            year: 'numeric', month: 'numeric', day: 'numeric',
                            hour: 'numeric', minute: 'numeric',
                            hour12: false
                          }).format(new Date(atendimento.DataAtendimento))}</td>
                          <td>{atendimento.IdSituacaoNavigation.nomeSituacao}</td>
                        </tr>
    
                      )
                    } )
                  }
    
                </tbody>
    
              </table>
            </section>
    
            <section>
              <h2>Cadastro de Atendimentos</h2>
            </section>
          </div>
        )
      }
}