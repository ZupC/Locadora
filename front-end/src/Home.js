import React, { useState } from 'react';
import style from'./App.css';
import AppNavbar from './components/AppNavbar';
import { Link } from 'react-router-dom';
import { Button, Row } from 'antd';

const Home = () => {
  const [size, setSize] = useState('large');
  return (
    <div>
      <AppNavbar />
      <Row justify="space-around">
        <Button type="primary" className='btn' href='/Cliente' size={size}>
          Clientes
        </Button>
        <Button type="primary" className='btn' href='/Filme' size={size}>
          Filmes
        </Button>
        <Button type="primary" className='btn' href='/Locacao' size={size}>
          Locações
        </Button>
      </Row>
    </div>
  );
}

export default Home;