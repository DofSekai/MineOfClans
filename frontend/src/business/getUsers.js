export default async function getUsers() {
    const res = await fetch('https://localhost:7227/api/Users');
    if (!res.ok) {
        throw new Error(await res.text());
    }
    return await res.json();
}