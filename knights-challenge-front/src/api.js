import axios from 'axios';

export default axios.create({
    baseURL: 'http://localhost:44345',
    headers: {
        'Content-type': 'application/json',
    },
});