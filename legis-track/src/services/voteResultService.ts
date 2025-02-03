import axios from "axios";

const api = axios.create({
  baseURL: 'https://localhost:7238',
  timeout: 10000,
  headers: {
    'Content-Type': 'application/json'
  }
});

const getLegislatorBillSupportStats = async () => {
  try {
    const response = await api.get('/bill/legislator-stats');
    return response.data;
  } catch (error) {
    console.error("Ocorreu um erro na requisição: ", error)
  }
}

const getBillSupportStats = async () => {
  try {
    const response = await api.get('/bill/bill-stats');
    return response.data;
  } catch (error) {
    console.error("Ocorreu um erro na requisição: ", error);
  }
}

export const voteResultService = {
  getLegislatorBillSupportStats,
  getBillSupportStats,
}