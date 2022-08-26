import React, { useState } from 'react';
import './App.css';
import AppNavbar from './components/AppNavbar';
import { Link } from 'react-router-dom';
import { Button } from 'antd';

const Home = () => {
  const [size, setSize] = useState('large');
  return (
    <div>
      <AppNavbar />
      <Button type="primary" href='/Cliente' size={size}>
        Clientes
      </Button>
      <Button type="primary" href='/Filme' size={size}>
        Filmes
      </Button>
      <Button type="primary" href='/Locacao' size={size}>
        Locações
      </Button>
    </div>
  );
}

export default Home;