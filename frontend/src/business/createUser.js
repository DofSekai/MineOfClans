import config from '../config.js';

export default async function createUser(user) {
    const res = await fetch('http://localhost:'+config.SWAGGER_PORT+'/api/Users', {
        method: 'post',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(user)
    });

    if (!res.ok) {
        throw new Error(await res.text());
    }
}