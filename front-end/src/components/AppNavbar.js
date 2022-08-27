import React, { useState } from 'react';
import { Menu } from 'antd';
import '../App.css';
const items = [
  {
    label: (
      <a href="/">
        Home
      </a>
    ),
    key: 'Home',
  },
  {
    label: (
      <a href="/Cliente">
        Cliente
      </a>
    ),
    key: 'Cliente',
  },
  {
    label: (
      <a href="/Filme">
        Filme
      </a>
    ),
    key: 'Filme',
  },
  {
    label: (
      <a href="/Locacao">
        Locações
      </a>
    ),
    key: 'Locacao',
  },
];

const AppNavbar = () => {

  const [isOpen, setIsOpen] = useState(false);

  const [current, setCurrent] = useState('mail');

  const onClick = (e) => {
    setCurrent(e.key);
  };

  return (
    <Menu onClick={onClick} selectedKeys={[current]} mode="horizontal" items={items} className='header'/>
  );
};

export default AppNavbar;