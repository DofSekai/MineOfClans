import config from '../config.js';
export default async function getUsers() {
    const res = await fetch('http://localhost:'+config.SWAGGER_PORT+'/api/Users');
    if (!res.ok) {
        throw new Error(await res.text());
    }
    return await res.json();
}