import axios from 'axios';

function buildForm(file) {
  var formData = new FormData();
  formData.append("file", file);
  return formData;
}

export const getStudents = () => {
  return axios({
    url: 'api/student',
    method: 'get',
    baseURL: 'http://localhost:56637'
  });
}

export const issueCertificate = (studentId) => {
  return axios({
    url: 'api/certificate/issue/' + studentId,
    method: 'get',
    baseURL: 'http://localhost:56637'
  });
}

export const verifyCertificate = (file) => {
  return axios({
    url: 'api/certificate/verify',
    method: 'post',
    baseURL: 'http://localhost:56637',
    data: buildForm(file),
    config: { headers: {'Content-Type': 'multipart/form-data' }}
  });
}
