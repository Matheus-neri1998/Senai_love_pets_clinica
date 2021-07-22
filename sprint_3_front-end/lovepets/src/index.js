import React from 'react';
import ReactDOM from 'react-dom';
import {Route, BrowserRouter as Router, Switch, Redirect} from 'react-router-dom';
import { UsuarioAutenticado, parseJwt} from './services/auth';

import './index.css';

import App from './pages/home/App';
import atendimentos from './pages/atendimentos/atendimento';
import meusatendimentos from './pages/atendimentos/meusatendimentos';
import login from './pages/login/login';
import notFound from './pages/notFound/notFound';

import reportWebVitals from './reportWebVitals';


// Estrutura IF TERNÁRIO
// CONDIÇÃO ? FAÇO ALGO SE VERDADEIRO : FAÇO ALGO SE FALSO
// Exemplo
// 2 > 1 ? Sim : Não
// resposta > Sim

const PermissaoAdm = ({ component : Component }) => (
    <Route
      render = {props => 
        UsuarioAutenticado() && parseJwt().role === '1' ?
        <Component {...props}/> :
        <Redirect to="login" />
      }
    />
)

const PermissaoVetPet = ({ component : Component}) => (
        <Route
        render = {props => 
          UsuarioAutenticado() && parseJwt().role === '2' || parseJwt().role === '3' ?
          <Component {...props}/> :
          <Redirect to="login" />
        }
      />

)

const routing = (
      <Router>
        <Switch>
          <Route exact path="/" component={App}/>
          <PermissaoAdm path="/atendimento" component={atendimentos} />
          <PermissaoVetPet path="/meusatendimentos" component={meusatendimentos} />
          <Route path="/login" component={login} />
          <Route path="/notFound" component={notFound} />
          <Redirect to="/notFound" />
        </Switch>
      </Router>

)

ReactDOM.render(routing, document.getElementById('root'));

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
