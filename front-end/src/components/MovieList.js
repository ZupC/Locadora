import React, { useEffect, useState } from 'react';
import api from '../services/locadora.service';
import { Button, Table, Space } from 'antd';
import AppNavbar from './AppNavbar';

const MoviesList = () => {

  const [movies, setMovies] = useState([]);
  const [loading, setLoading] = useState(false);

  const dataSource = [];
  const columns = [
    {
      title: 'ID',
      dataIndex: 'key',
      key: 'key',
    },
    {
      title: 'Titulo',
      dataIndex: 'titulo',
      key: 'titulo',
    },
    {
      title: 'Classificação indicativa',
      dataIndex: 'classificacaoIndicativa',
      key: 'classificacaoIndicativa',
    },
    {
      title: 'Lançamento',
      dataIndex: 'lancamento',
      key: 'lancamento',
    },
    {
      title: 'Ações',
      dataIndex: 'action',
      key: 'action',
      render: (_, record) => {
        return (
          <Space size="middle">
            <Button href ={`/Filme/${record.key}`} type="primery">Editar</Button>
            <Button onClick={e => handleDeleteFilme(record.key)} type="primery" danger>Excluir</Button>
          </Space>
        );
      },
    },
  ];

  useEffect(() => {
    setLoading(true);

    api.get('api/Filme').then(response => {
      setMovies(response.data);
      setLoading(false);
    })
  }, []);

  function handleDeleteFilme(id) {
    const response = api.delete(`api/Filme/${id}`);
    let updatedGroups = [...movies].filter(i => i.id !== id);
    setMovies(updatedGroups);
  }

  if (loading) {
    return <p>Loading...</p>;
  }

  movies.map(movie => {
    dataSource.push({
      key: movie.id,
      titulo: movie.titulo,
      classificacaoIndicativa: movie.classificacaoIndicativa,
      lancamento: movie.lancamento
    });
  });

  return (
    <div>
      <AppNavbar />
      <Button color="success" href="/Filme/new">Novo filme</Button>
      <h3>Meus filmes</h3>
      <Table dataSource={dataSource} columns={columns} />;
    </div>
  );
};

export default MoviesList;