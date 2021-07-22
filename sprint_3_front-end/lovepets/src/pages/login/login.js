import { Component } from "react";

import axios from "axios";
import { parseJwt } from "../../services/auth";

export default class login extends Component{
    constructor(props){
        super(props);
        this.state = {
            email : "",
            senha : ""
        };
    };

    efetuarLogin = (event) => {
        event.PreventDefault();

        axios.post('http://localhost:5000/api/login', {
            email : this.state.email,
            senha : this.state.senha
        })

        .then(resposta => {
            if (resposta.status === 200) {
                console.log('Meu Token é: ' + resposta.data.token);
                localStorage.setItem('usuario-login' , resposta.data.token)

                if (parseJwt().role === "1") {
                    this.props.history.push('/atendimento')
                } 

                else {
                    this.props.history.push('/meusatendimentos')
                };
            }
        })

    };

    AtualizaStateCampo = (campo) => {
        // Exemplo        // Email              // Adm
        this.setState({ [campo.target.name] : campo.target.value})
    };

    render(){
        return(

            <div>
                <h1>Login</h1>

                <section>
                    <form onSubmit={this.efetuarLogin}>
                        <input
                        // Email
                            type="text"
                            name="email"
                            value={this.state.email}
                            onChange={this.AtualizaStateCampo}
                            placeholder="username"
                        />

                        <input
                        // Senha
                            type="text"
                            name="senha"
                            value={this.state.senha}
                            onChange={this.AtualizaStateCampo}
                            placeholder="password"
                        />
                        
                        <button type="submit">Entrar</button>

                    </form>
                </section>
            </div>
        )

    }

}