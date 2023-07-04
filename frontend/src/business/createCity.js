import config from '../config.js';

export default async function createCity(request) {
    const res = await fetch('http://localhost:'+config.SWAGGER_PORT+'/api/Villages/', {
        method: 'post',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(request)
    });

    if (!res.ok) {
        throw new Error(await res.text());
    }
}