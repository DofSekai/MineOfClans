import config from '../config.js';

export default async function updateOre(id_village) {

    const res = await fetch('http://localhost:'+config.SWAGGER_PORT+`/api/Villages/${id_village}`, {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({id: id_village})
    });

    if (!res.ok) {
        throw new Error(await res.text());
    }
}