import '../../index.css';
import test from "../../img/player_head.png"
import getUsers from '../../business/getUsers';
import { BrowserRouter as Router, Route, Routes, Link } from 'react-router-dom';
import React, { useState, useEffect } from 'react';

export default function Login() {
    const [users, setUsers] = useState([]);
    useEffect(() => {
        async function fetchUsers() {
            try {
                const fetchedUsers = await getUsers();
                setUsers(fetchedUsers);
            } catch (e) {
                alert(e);
            }
        }

        fetchUsers();
    }, []);
    return (
        <section>
            <br></br>
            <hr></hr>
            <br></br>
            <Link to="/"><h1 className="font-bold text-center text-3xl">MineOfClans</h1></Link>
            <br></br>
            <hr></hr>
            <br></br>
            <div class=" bg-gray-100 py-9 flex flex-col justify-center sm:py-12">
                <div class="grid grid-cols-3 gap-4">

                    {users.map(user => (
                        <div class="flex flex-col items-center" id={user.id}>
                            <img class="w-24 h-24" src={test}  />
                            <h3 class="text-center mt-2">{user.name}</h3>
                        </div>

                    ))}
                </div>
            </div>
        </section>
    );
}