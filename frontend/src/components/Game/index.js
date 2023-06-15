import "../App/default.css"
import "./test.css"
import mine from "../../img/mine.png"
import mineButton from "../../img/mine-logo.png"
import logo from "../../img/logo.png"
import golem from "../../img/golem.png"
import hdv from "../../img/hdv.png"
import iron from "../../img/iron.png"
import diamond from "../../img/diamond.png"
import emerauld from "../../img/emerauld.png"
import murailles from "../../img/murailles.png"
import sorcier from "../../img/sorcier.png"
import axios from "axios"
import config from '../../config.js';


import { BrowserRouter as  Router, Route, Routes, Link } from 'react-router-dom';
import { useLocation } from 'react-router-dom';
import { useEffect, useState } from 'react';

export default function Game(){
  
  const location = useLocation();
  const [name, setName] = useState('');
  useEffect(() => {
    const searchParams = new URLSearchParams(location.search); 
    setName(searchParams.get('name'));
  }, [location.search]);


  const [user_irons, setIron] = useState('');
  const [user_diamond, setDiamond] = useState('');
  const [user_emerauld, setEmerauld] = useState('');

  const [max_irons, setMaxIron] = useState('');
  const [max_diamond, setMaxDiamond] = useState('');
  const [max_emerauld, setMaxEmerauld] = useState('');

  const [levelMine, setLevelMine] = useState('');

  //stockage + stock max
  axios.get('http://localhost:'+config.SWAGGER_PORT+'/api/Users')
  .then(response => {
    for(let i = 0; i < response.data.length; i++){
      if(response.data[i].name == {name}.name){
        setIron(response.data[i].village.irons);
        setDiamond(response.data[i].village.diamonds);
        setEmerauld(response.data[i].village.emeralds);
        setMaxIron(response.data[i].village.levelMine.ironMaxRate);
        setMaxDiamond(response.data[i].village.levelMine.diamondMaxRate);
        setMaxEmerauld(response.data[i].village.levelMine.emeraldMaxRate);
        setLevelMine(response.data[i].village.levelMineId);
      } else {
        console.log("erreur")
      }
    }
    
  })
  .catch(error => {
    // Gérez les erreurs de la requête ici
    console.error(error);
  });

  

return(

<section class="bg-gradient-to-tr from-sky-600 font-serif text-white">

<br></br>
            <hr></hr>
            <br></br>
            <Link to="/login"><button id="btn_deco">Déconnexion</button> </Link>
            <div class="flex items-center justify-center">
              <img src={logo} alt="Logo" class="test"></img>
            <h1 class="font-bold text-3xl">MineOfClans</h1>         
            </div>
            <br></br>
            <h1 class="font-bold text-2xl">Bienvenue {name} !</h1>   
            <br></br>
            <hr></hr>
            <br></br>

<div class="flex h-screen">
    <div class="w-1/4 h-full border-2 border-white p-4">
      <h1 class="text-center text-2xl font-bold p-4">MINE</h1>
      <br></br>
      <div class="flex">
        <img src={iron} class="w-8"></img>
        <p class="px-4">: {user_irons}</p>
      </div>   
      <br></br>
      <div class="flex">
        <img src={diamond} class="w-8"></img>
        <p class="px-4">: {user_diamond}</p>
      </div>
      <br></br>
      <div class="flex">
        <img src={emerauld} class="w-8"></img>
        <p class="px-4">: {user_emerauld}</p>
      </div>
      <br></br>
      <br></br>
      <img src={mineButton} alt="mine" class="w-36 h-34"></img>
      <p> CLIQUER POUR MINER </p>

      <br></br>
      <br></br>

      <div>
          <img src={sorcier} alt="sorcier" class="w-26 h-40 text-center"></img>
          <div class="flex">
            <p class="pe-2">Nombre de tours : </p>
          </div>
      </div>
    </div>
    <div class="w-1/2 h-screen border-2 border-white p-4 ">
      <h1 class="text-center text-2xl font-bold p-4">Village</h1>
      <br></br>
      <div class="flex h-1/2">
        <div class="border-4 border-white w-1/2 h-72 p-4 text-xl">
            <p>Niveau Mine : {levelMine}</p>
            <br></br>
            <div id="mine" class="mx-5"><img src={mine} alt="mine" class="w-38 h-36 rounded-3xl"></img></div>
            <div class="mr-50">
              <ul class="list-disc ml-8" id="stock_mine">
                <li>Max fer : {max_irons}</li>
                <li>Max diamant : {max_diamond} </li>
                <li>Max émeraude : {max_emerauld} </li>
              </ul>
            </div>
            <br></br>
            <button class="bg-lime-500 text-white rounded-xl p-1">Upgrade</button>
        </div>
        <div class="border-4 border-white w-1/2 h-72 p-4 text-xl">
            <p>Niveau HDV : X</p>
            <br></br>
            <div id="hdv" class="mx-5"><img src={hdv} alt="hdv" class="w-36 h-36"></img></div>  
            <div class="mr-50">
              <ul class="list-disc ml-8" id="stock_hdv">
                <li>Max golems :</li>
                <li>Max murailles : </li>
              </ul>
            </div>
            <br></br><br></br>     
            <button class="bg-lime-500 text-white rounded-xl p-1">Upgrade</button>
        </div>
        
      </div>
      <div class="border-4 border-white h-72 p-4 text-xl">
        <p>Shop :</p>
        <div class="image-container">
        <div>
          <img src={golem} alt="golem" class="w-26 h-40 text-center"></img>
          <div class="golem-container">
            <p class="pe-2">100</p><img src={iron} class="w-8"></img>
        </div>
        </div>
        <div>
          <img src={murailles} alt="murailles" class="w-26 h-40 text-center"></img>
          <div class="murailles-container">
          <p class="pe-2">30 </p> <img src={diamond} class="w-8"></img>
          </div>
        </div>
        <div>
          <img src={sorcier} alt="sorcier" class="w-26 h-40 text-center"></img>
          <div class="sorcier-container">
            <p class="pe-2">90</p><img src={emerauld} class="w-8"></img>
        </div>
        </div>
      </div>          
      </div>
    </div>
    <div class="w-1/4 h- border-2 border-white p-4">
      <h1 class="text-center text-2xl font-bold p-4">Défense</h1>
      <br></br>
      <div class="flex justify-center">
        <img src={golem} alt="golem" class="w-26 h-52"></img>
      </div>
      <br></br>
      <p class="px-4 text-center">Nombre de Golems : 0</p>
      <div class="flex justify-center my-10">
        <img src={murailles} alt="murailles" class="w-26 h-52"></img>
      </div>
      <br></br>
      <p class="px-4 text-center">Nombre de murailles : 0</p>
    </div>
  </div>
</section>   

);


}