import '../../index.css';
import test from "../../img/player_head.png"
import dof from "../../img/dof.png"
import ply from "../../img/plynox.png"
import miss from "../../img/misswe.png"
import getUsers from '../../business/getUsers';
import { BrowserRouter as  Router, Route, Routes, Link } from 'react-router-dom';
import React, { useState, useEffect } from 'react';

const RandomChoiceComponent = () => {
  const getRandomChoice = () => {
    const randomNumber = Math.floor(Math.random() * 4) + 1;

    if (randomNumber === 1) {
      return dof;
    } else if (randomNumber === 2) {
      return ply;
    }
     else {
      return miss;
    }
  };

  const randomChoice = getRandomChoice();
  return (
    <img className="w-45 h-24" src={randomChoice} alt="Image" />
  );
};



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
    return(
        <section> 
            <br></br>
            <hr></hr>
            <br></br>
            <Link to="/"><h1 className="font-bold text-center text-3xl">MineOfClans</h1></Link>
            <br></br>
            <hr></hr>
            <br></br>
            <div class=" bg-slate-100 rounded-full py-9 flex flex-col justify-center sm:py-12">
                <div class="grid grid-cols-3 gap-4">
                   
                        {users.map(user => (
                             <div class="flex flex-col items-center">
                                <a href={`http://localhost:3000/game?name=${encodeURIComponent(user.name)}`}> <RandomChoiceComponent />
                                <h3 class="text-center mt-2">{user.name}</h3></a>
                            </div>
                           
                        ))}
                </div>
            </div>
        </section>
    );
}