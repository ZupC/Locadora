import React, { useEffect, useState } from 'react';
import api from '../services/locadora.service';
import { Button, Table, Space } from 'antd';
import AppNavbar from './AppNavbar';
import { Link } from 'react-router-dom';

const ClientsList = () => {

  const [clients, setClients] = useState([]);
  const [loading, setLoading] = useState(false);
  const dataSource = [];
  const columns = [
    {
      title: 'ID',
      dataIndex: 'key',
      key: 'key',
    },
    {
      title: 'Nome',
      dataIndex: 'nome',
      key: 'nome',
    },
    {
      title: 'CPF',
      dataIndex: 'cpf',
      key: 'cpf',
    },
    {
      title: 'Data de aniverário',
      dataIndex: 'aniversario',
      key: 'aniversario',
    },
    {
      title: 'Ações',
      dataIndex: 'action',
      key: 'action',
      render: (_, record) => {
        return (
          <Space size="middle">
            <Button href ={`/Cliente/${record.key}`} type="primery">Editar</Button>
            <Button onClick={e => handleDeleteCliente(record.key)} type="primery" danger>Excluir</Button>
          </Space>
        );
      },
    },
  ];

  useEffect(() => {
    setLoading(true);

    api.get('api/Cliente').then(response => {
      setClients(response.data);
      setLoading(false);
    })
  }, []);

  function handleDeleteCliente(id) {
    const response = api.delete(`api/Cliente/${id}`);
    let updatedGroups = [...clients].filter(i => i.id !== id);
    setClients(updatedGroups);
  }

  if (loading) {
    return <p>Loading...</p>;
  }

  clients.map(client => {
    dataSource.push({
      key: client.id,
      nome: client.nome,
      cpf: client.cpf,
      aniversario: client.dataNascimento.slice(0, 10)
    });
  });

  return (
    <div>
      <AppNavbar />
      <Button color="success" href="/Cliente/new">Novo cliente</Button>
      <h3>Meus clientes</h3>
      <Table dataSource={dataSource} columns={columns} />;
    </div>
  );
};

export default ClientsList;