import React from 'react';
import ReactDOM from 'react-dom';
import {Route, BrowserRouter as Router, Switch, Redirect} from 'react-router-dom';

import './index.css';

import App from './pages/home/App';
import atendimentos from './pages/atendimentos/atendimento';
import login from './pages/login/login';
import notFound from './pages/notFound/notFound';

import reportWebVitals from './reportWebVitals';

const routing = (
      <Router>
        <Switch>
          <Route exact path="/" component={App}/>
          <Route path="/atendimento" component={atendimentos} />
          <Route path="/login" component={login} />
          <Route />
        </Switch>
      </Router>

)

ReactDOM.render(routing, document.getElementById('root'));

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
