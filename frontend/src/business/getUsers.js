export default async function getUsers() {
    const res = await fetch('http://localhost:5235/api/Users');
    if (!res.ok) {
        throw new Error(await res.text());
    }
    return await res.json();
}