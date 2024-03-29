import { BrowserRouter as Router, Route, Routes, Link } from 'react-router-dom';
//import 'tailwindcss/tailwind.css';
import './index.css';
//import Game from '../Game';
import logo from "../../img/logo.png"
import trophee from "../../img/trophee.png"
import '../../accueil.css'
import React, { useState, useEffect } from 'react';
import getRanking from '../../business/getRanking';

export default function App() {

  const [users, setUsers] = useState([]);
  useEffect(() => {
  async function fetchUsers() {
    try {
      const fetchedUsers = await getRanking();
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
          <br></br>
          <br></br>
          <br></br>
          <br></br>
          <br></br>

            <br></br>
            <hr></hr>
            <br></br>
            
            <div className="flex items-center justify-center">
              <img src={logo} alt="Logo" className="w-44 h-44 rounded-full mr-2"></img>
                {/*<h1 className="font-bold text-3xl">MineOfClans</h1>*/}            
            </div>
            <br></br>
            <hr></hr>
            <div className="p-9 flex justify-center space-x-2">
                <Link to="/login"><button className="bg-red-500 rounded-xl p-4 w-20 text-white">Login</button> </Link>
                <Link to="/register" className="bg-blue-500 rounded-xl p-4 w-28 text-white"><button>Register</button> </Link>
            </div>
            <div className="flex flex-col items-center backdrop-blur-sm">
              <h1 className="text-3xl">Classement des joueurs : </h1>
              {users.length > 0 && users.map((user, index) => (
                <div key={user.id} className="flex items-center mt-2">
                  {index < 3 && <img src={trophee} alt="Image" className="w-16" />}
                  <h2 className="text-xl text-center text-white font-extrabold">{user.name} : Score {user.score}</h2>
                </div>
              ))}
              </div>
        </section>
  );
}




































