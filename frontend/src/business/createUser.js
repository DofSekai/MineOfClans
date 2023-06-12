export default async function createUser(user) {
	const res = await fetch('https://localhost:3000/register?pseudo=', {
		method: 'post',
		headers: { 'Content-Type': 'application/json' },
		body: JSON.stringify(user)
	});

	if (!res.ok) {
		throw new Error(await res.text());
	}
}