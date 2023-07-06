import config from '../config.js';
export default async function getCity(id) {

    const res = await fetch('http://localhost:'+config.SWAGGER_PORT+'/api/Villages/Users/'+id+'');
    if (!res.ok) {
        throw new Error(await res.text());
    }
    return await res.json();
}
