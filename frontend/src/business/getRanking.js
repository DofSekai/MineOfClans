import config from '../config.js';
export default async function getRanking() {

    const res = await fetch('http://localhost:'+config.SWAGGER_PORT+'/api/Users/ranking');
    if (!res.ok) {
        throw new Error(await res.text());
    }

    const data = await res.json();
    const ranking = data.map(user => ({
        id: user.id,
        name: user.name
    }));
  
    return ranking;
}