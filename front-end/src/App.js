import React from 'react';
import './App.css';
import Home from './Home';
import { BrowserRouter as Router,Route, Routes } from 'react-router-dom';
import ClientList from './components/ClientList';
import MovieList from './components/MovieList';
import RentList from './components/RentsList';
import ClientEdit from './components/ClientEdit';
import MovieEdit from './components/MovieEdit';
import RentEdit from './components/RentEdit';

const App = () => {
  return (
    <Router>
    <Routes>
      <Route exact path="/" element={<Home />} />
      <Route path='/Cliente' exact={true} element={<ClientList />} />
      <Route path='/Filme' exact={true} element={<MovieList />} />
      <Route path='/Locacao' exact={true} element={<RentList />} />
      <Route path='/Cliente/:id' exact={true} element={<ClientEdit />} />
      <Route path='/Filme/:id' exact={true} element={<MovieEdit />} />
      <Route path='/Locacao/:id' exact={true} element={<RentEdit />} />
    </Routes>
    </Router>
  )
}

export default App;