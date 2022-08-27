import React, { useEffect, useState } from 'react';
import api from '../services/locadora.service';
import { Button, Table, Space, Collapse } from 'antd';
import AppNavbar from './AppNavbar';

const { Panel } = Collapse;

const RentsList = () => {

  const [rents, setRents] = useState([]);
  const [loading, setLoading] = useState(false);
  const dataSource = [];
  const columns = [
    {
      title: 'ID',
      dataIndex: 'key',
      key: 'key',
    },
    {
      title: 'Cliente',
      dataIndex: 'cliente',
      key: 'cliente',
    },
    {
      title: 'Filme',
      dataIndex: 'filme',
      key: 'filme',
    },
    {
      title: 'Data locação',
      dataIndex: 'dataLocacao',
      key: 'dataLocacao',
    },
    {
      title: 'Data devolução',
      dataIndex: 'dataDevolucao',
      key: 'dataDevolucao',
    },
    {
      title: 'Ações',
      dataIndex: 'action',
      key: 'action',
      render: (_, record) => {
        return (
          <Space size="middle">
            <Button href={`/Locacao/${record.key}`} type="primery">Editar</Button>
            <Button onClick={e => handleDeleteRent(record.key)} type="primery" danger>Excluir</Button>
          </Space>
        );
      },
    },
  ];

  useEffect(() => {
    setLoading(true);

    api.get('api/Locacao').then(response => {
      setRents(response.data);
      setLoading(false);
    })
  }, []);

  rents.map(rent => {
    dataSource.push({
      key: rent.id,
      cliente: rent.cliente,
      filme: rent.filme,
      dataLocacao: rent.dataLocacao.slice(0, 10),
      dataDevolucao: rent.dataDevolucao.slice(0, 10)
    });
  });

  const [reportLateReturn, setReportLateReturn] = useState([]);
  const dataSourceReportLateReturn = [];
  const columnsReportLateReturn = [
    {
      title: 'Cliente',
      dataIndex: 'cliente',
      key: 'cliente',
    },
    {
      title: 'CPF',
      dataIndex: 'cpf',
      key: 'cpf',
    },
    {
      title: 'Data de nascimento',
      dataIndex: 'dataNascimento',
      key: 'dataNascimento',
    },
  ];

  useEffect(() => {
    api.get('api/Locacao/ReportLateReturn').then(response => {
      setReportLateReturn(response.data);
    })
  }, []);

  reportLateReturn.map(client => {
    dataSourceReportLateReturn.push({
      key: client.id,
      cliente: client.nome,
      cpf: client.cpf,
      dataNascimento: client.dataNascimento.slice(0, 10),
    });
  });

  const [reportMoviesNeverRented, setReportMoviesNeverRented] = useState([]);
  const dataSourceReportMoviesNeverRented = [];
  const columnsReportMoviesNeverRented = [
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
    }
  ];

  useEffect(() => {
    api.get('api/Locacao/ReportMoviesNeverRented').then(response => {
      setReportMoviesNeverRented(response.data);
    })
  }, []);

  reportMoviesNeverRented.map(movie => {
    dataSourceReportMoviesNeverRented.push({
      key: movie.id,
      titulo: movie.titulo,
      classificacaoIndicativa: movie.classificacaoIndicativa,
      lancamento: movie.lancamento,
    });
  });

  const [reportMostRentedMovies, setReportMostRentedMovies] = useState([]);
  const dataSourceReportMostRentedMovies = [];
  const columnsReportMostRentedMovies = [
    {
      title: 'Titulo',
      dataIndex: 'titulo',
      key: 'titulo',
    },
    {
      title: 'Quantidade de vezes alugado',
      dataIndex: 'vezesAlugado',
      key: 'vezesAlugado',
    }
  ];

  useEffect(() => {
    api.get('api/Locacao/ReportMostRentedMovies').then(response => {
      setReportMostRentedMovies(response.data);
    })
  }, []);

  reportMostRentedMovies.map(movie => {
    dataSourceReportMostRentedMovies.push({
      key: movie.id,
      titulo: movie.titulo,
      vezesAlugado: movie.vezesAlugado,
    });
  });

  const [reportLessRentedMovies, setReportLessRentedMovies] = useState([]);
  const dataSourceReportLessRentedMovies = [];
  const columnsReportLessRentedMovies = [
    {
      title: 'Titulo',
      dataIndex: 'titulo',
      key: 'titulo',
    },
    {
      title: 'Quantidade de vezes alugado',
      dataIndex: 'vezesAlugado',
      key: 'vezesAlugado',
    }
  ];

  useEffect(() => {
    api.get('api/Locacao/ReportLessRentedMovies').then(response => {
      setReportLessRentedMovies(response.data);
    })
  }, []);

  reportLessRentedMovies.map(movie => {
    dataSourceReportLessRentedMovies.push({
      key: movie.id,
      titulo: movie.titulo,
      vezesAlugado: movie.vezesAlugado,
    });
  });

  const [reportSecondMostCustomerRented, setReportSecondMostCustomerRented] = useState([]);
  const dataSourceReportSecondMostCustomerRented = [];
  const columnsReportSecondMostCustomerRented = [
    {
      title: 'Nome',
      dataIndex: 'nome',
      key: 'nome',
    },
    {
      title: 'Quantidade de vezes alugado',
      dataIndex: 'vezesAlugado',
      key: 'vezesAlugado',
    }
  ];

  useEffect(() => {
    api.get('api/Locacao/ReportSecondMostCustomerRented').then(response => {
      setReportSecondMostCustomerRented(response.data);
    })
  }, []);

  dataSourceReportSecondMostCustomerRented.push({
    key: 1,
    nome: reportSecondMostCustomerRented.nome,
    vezesAlugado: reportSecondMostCustomerRented.vezesAlugado,
  });


  if (loading) {
    return <p>Loading...</p>;
  }

  function handleDeleteRent(id) {
    const response = api.delete(`api/Locacao/${id}`);
    let updatedrent = [...rents].filter(i => i.id !== id);
    setRents(updatedrent);
  }

  return (
    <div>
      <AppNavbar />
      <Button color="success" href="/Locacao/new">Nova locação</Button>
      <h3>Minhas locações</h3>
      <Table dataSource={dataSource} columns={columns} />;
      <div>
        <h2>Relatórios</h2>
        <Collapse>
          <Panel header="Clientes em atraso na devolução" key="1">
            <Table dataSource={dataSourceReportLateReturn} columns={columnsReportLateReturn} />;
          </Panel>
          <Panel header="Filmes que nunca foram alugados" key="2">
            <Table dataSource={dataSourceReportMoviesNeverRented} columns={columnsReportMoviesNeverRented} />;
          </Panel>
          <Panel header="Cinco filmes mais alugados do último ano" key="3">
            <Table dataSource={dataSourceReportMostRentedMovies} columns={columnsReportMostRentedMovies} />;
          </Panel>
          <Panel header="Três filmes menos alugados da última semana" key="4">
            <Table dataSource={dataSourceReportLessRentedMovies} columns={columnsReportLessRentedMovies} />;
          </Panel>
          <Panel header="O segundo cliente que mais alugou filmes" key="5">
            <Table dataSource={dataSourceReportSecondMostCustomerRented} columns={columnsReportSecondMostCustomerRented} />;
          </Panel>
        </Collapse>
      </div>
    </div>
  );
};

export default RentsList;