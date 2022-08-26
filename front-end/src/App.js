import React from 'react';
import './App.css';
import Home from './Home';
import { BrowserRouter as Router,Route, Routes } from 'react-router-dom';
import ClientList from './components/ClientList';
import ClientEdit from './components/ClientEdit';

const App = () => {
  return (
    <Router>
    <Routes>
      <Route exact path="/" element={<Home />} />
      <Route path='/Cliente' exact={true} element={<ClientList />} />
      <Route path='/Cliente/:id' exact={true} element={<ClientEdit />} />
    </Routes>
    </Router>
  )
}

export default App;