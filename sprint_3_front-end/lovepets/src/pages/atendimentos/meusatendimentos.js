import { Component } from "react";

export default class meusatendimentos extends Component{
    constructor(props){
        super(props);
        this.state = {
            ListaAtendimentos : []  
        };
    };

    BuscarAtendimentos = () => {
        console.log('Esta função traz todos os atendimentos.')

        fetch('http://localhost:5000/api/atendimento/listarmeus', {
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

        .then(resposta => this.setState({ListaAtendimentos : resposta}))

        .catch(erro => console.log(erro));

    }; // Fim de BuscarAtendimentos

    componentDidMount(){
        this.BuscarAtendimentos();
    };

    render(){
        return(
            <div>
                <h1>Meus Atendimentos</h1>

                <section>
                    <h2>Lista de Atendimentos</h2>

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
                            this.state.listaAtendimentos.map( (atendimento) => {
                                return(

                                <tr key={atendimento.idAtendimento}>
                                    <td>{atendimento.idAtendimento}</td>
                                    <td>{atendimento.idPetNavigation.nomePet}</td>
                                    <td>{atendimento.idVeterinarioNavigation.nomeVeterinario}</td>
                                    <td>{atendimento.descricao}</td>
                                    <td>{Intl.DateTimeFormat("pt-BR", {
                                    year: 'numeric', month: 'numeric', day: 'numeric',
                                    hour: 'numeric', minute: 'numeric',
                                    hour12: false
                                    }).format(new Date(atendimento.dataAtendimento))}</td>
                                    <td>{atendimento.idSituacaoNavigation.nomeSituacao}</td>
                                </tr>

                                )
                            } )
                            }

                        </tbody>

                    </table>

                </section>

            </div>
        )
    }

}