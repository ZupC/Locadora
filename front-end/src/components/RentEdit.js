import React, { useEffect, useState } from 'react';
import api from '../services/locadora.service';
import { useNavigate, useParams } from 'react-router-dom';
import { Button, Form, Input, DatePicker, Select } from 'antd';
import AppNavbar from './AppNavbar';
import moment from 'moment';


const RentEdit = () => {
  const [rent, setRent] = useState([]);
  const [clients, setClients] = useState([]);
  const [movies, setMovies] = useState([]);

  const navigate = useNavigate();
  const { id } = useParams();
  const [form] = Form.useForm();
  const { Option } = Select;

  const ref = React.useRef(null);

  const layout = {
    labelCol: {
      span: 8,
    },
    wrapperCol: {
      span: 16,
    },
  };
  const tailLayout = {
    wrapperCol: {
      offset: 8,
      span: 16,
    },
  };

  //#region clientes
  useEffect(() => {
    api.get('api/Cliente').then(response => {
      setClients(response.data);
    })
  }, [id, setClients]);

  const clientOptions = [];

  clients.map(client => {
    clientOptions.push(<Option key={client.id} value={client.nome}>{client.nome}</Option>);
  })

  const handleChangeClient = (value) => {
    let client = clients.filter(i => i.nome === value)
    ref.current.setFieldsValue({
      id_cliente : client[0].id,
    });
  };
  //#endregion
  
  //#region Filmes
  useEffect(() => {
    api.get('api/Filme').then(response => {
      setMovies(response.data);
    })
  }, [id, setMovies]);

  const movieOptions = [];

  movies.map(movie => {
     movieOptions.push(<Option key={movie.id} value={movie.titulo}>{movie.titulo}</Option>);
  })

  const handleChangeMovie = (value) => {
    let movie = movies.filter(i => i.titulo === value)
    ref.current.setFieldsValue({
      id_filme : movie[0].id,
    });
  };
  //#endregion

  useEffect(() => {
    if (id !== 'new') {
      api.get(`/api/Locacao/${id}`).then(response => {
        form.setFieldsValue({
          id: `${response.data.id}`,
          cliente: `${response.data.cliente}`,
          id_cliente: `${response.data.clienteId}`,
          filme: `${response.data.filme}`,
          id_filme: `${response.data.filmeId}`
        });
        setRent(response.data);
      })
    }
  }, [id, setRent]);

  const handleSubmit = async (values) => {
    console.log(values)
    if (values.id) {
      await api.put('/api/Locacao/', values)
    } else {
      await api.post('/api/Locacao/', values)
    }

    setRent([]);
    navigate('/Locacao');
  }

  const title = <h2>{rent.id ? 'Editar locação' : 'Adicionar locação'}</h2>;

  return (<div>
    <AppNavbar />
    {title}
    <Form {...layout} form={form} ref={ref} name="Locacao" onFinish={handleSubmit}>
      <Form.Item name="id" label="id" hidden>
        <Input />
      </Form.Item>

      <Form.Item name="cliente" label="Cliente">
        <Select placeholder="Selecione o cliente" onChange={handleChangeClient}>
          {clientOptions}
        </Select>
      </Form.Item>

      <Form.Item name="id_cliente" label="clienteId" hidden>
        <Input />
      </Form.Item>

      <Form.Item name="filme" label="Filme">
        <Select placeholder="Selecione o filme" onChange={handleChangeMovie}>
          {movieOptions}
        </Select>
      </Form.Item>

      <Form.Item name="id_filme" label="filmeId" hidden>
        <Input />
      </Form.Item>

      <Form.Item {...tailLayout}>
        <Button type="primary" htmlType="submit">Save</Button>
        <Button type="primary" href="/Locacao">Cancel</Button>
      </Form.Item>
    </Form>
  </div >
  )
};

export default RentEdit;