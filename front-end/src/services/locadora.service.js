import axios from 'axios';

const api = axios.create({
  baseURL: 'https://localhost:7040'
});

export default api;