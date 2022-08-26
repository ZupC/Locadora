import React, { useEffect, useState } from 'react';
import api from '../services/locadora.service';
import { useNavigate, useParams } from 'react-router-dom';
import { Button, Form, Input, DatePicker } from 'antd';
import moment from 'moment';
import AppNavbar from './AppNavbar';

const ClientEdit = () => {
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

  const [client, setClient] = useState([]);
  const navigate = useNavigate();
  const { id } = useParams();
  const [form] = Form.useForm();

  useEffect(() => {
    if (id !== 'new') {
      api.get(`/api/Cliente/${id}`).then(response => {
        form.setFieldsValue({
          id: `${response.data.id}`,
          nome: `${response.data.nome}`,
          cpf: `${response.data.cpf}`,
          dataNascimento: moment(response.data.dataNascimento)
        });
        setClient(response.data);
      })
    }
  }, [id, setClient]);

  const handleSubmit = async (values) => {
    console.log(values.id)
    if (values.id) {
      await api.put(`/api/Cliente/`, values)
    } else {
      await api.post('/api/Cliente/', values)
    }

    setClient([]);
    navigate('/Cliente');
  }

  const title = <h2>{client.id ? 'Editar cliente' : 'Adicionar cliente'}</h2>;


  return (<div>
    <AppNavbar />
    {title}
    <Form {...layout} form={form} name="Cliente" onFinish={handleSubmit}>
      <Form.Item name="id" label="id" hidden>
        <Input />
      </Form.Item>

      <Form.Item name="nome" label="Nome" rules={[{ required: true, },]}>
        <Input />
      </Form.Item>

      <Form.Item name="cpf" label="CPF" rules={[{ required: true, },]}>
        <Input />
      </Form.Item>

      <Form.Item name="dataNascimento" label="Data de nascimento" rules={[{ required: true, },]}>
        <DatePicker />
      </Form.Item>

      <Form.Item {...tailLayout}>
        <Button type="primary" htmlType="submit">Save</Button>
        <Button type="primary" href="/Cliente">Cancel</Button>
      </Form.Item>
    </Form>
  </div>
  )
};

export default ClientEdit;