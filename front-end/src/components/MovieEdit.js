import React, { useEffect, useState } from 'react';
import api from '../services/locadora.service';
import { useNavigate, useParams } from 'react-router-dom';
import { Button, Form, Input, DatePicker, Space } from 'antd';
import AppNavbar from './AppNavbar';

const MovieEdit = () => {
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

  const [movie, setMovie] = useState([]);
  const navigate = useNavigate();
  const { id } = useParams();
  const [form] = Form.useForm();

  useEffect(() => {
    if (id !== 'new') {
      api.get(`/api/Filme/${id}`).then(response => {
        form.setFieldsValue({
          id: `${response.data.id}`,
          titulo: `${response.data.titulo}`,
          classificacaoIndicativa: `${response.data.classificacaoIndicativa}`,
          lancamento: response.data.lancamento
        });
        setMovie(response.data);
      })
    }
  }, [id, setMovie]);

  const handleSubmit = async (values) => {
    if (values.id) {
      await api.put(`/api/Filme/`, values)
    } else {
      await api.post('/api/Filme/', values)
    }

    setMovie([]);
    navigate('/Filme');
  }

  const title = <h2 className='headerCenter'>{movie.id ? 'Editar filme' : 'Adicionar filme'}</h2>;

  return (<div>
    <AppNavbar />
    {title}
    <Form {...layout} form={form} name="Filme" onFinish={handleSubmit}>
      <Form.Item name="id" label="id" hidden>
        <Input />
      </Form.Item>

      <Form.Item name="titulo" label="Titulo" rules={[{ required: true, },]}>
        <Input />
      </Form.Item>

      <Form.Item name="classificacaoIndicativa" label="Classificação indicativa" rules={[{ required: true, },]}>
        <Input />
      </Form.Item>

      <Form.Item name="lancamento" label="Lançamento" rules={[{ required: true, },]}>
        <Input />
      </Form.Item>

      <Form.Item {...tailLayout}>
        <Space>
          <Button type="primary" htmlType="submit">Save</Button>
          <Button type="primary" href="/Filme">Cancel</Button>
        </Space>
      </Form.Item>
    </Form>
  </div>
  )
};

export default MovieEdit;