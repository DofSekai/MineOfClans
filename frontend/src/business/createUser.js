
export default async function createUser(user) {
    const res = await fetch('http://localhost:5235/api/Users', {
        method: 'post',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(user)
    });

    if (!res.ok) {
        throw new Error(await res.text());
    }
}