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

import levelup from "../../sound/levelup.mp3"
import pnj from "../../sound/pnj.mp3"
import witch from "../../sound/witch.mp3"
import damage from "../../sound/damage.mp3"
import chevre from "../../sound/chevre.ogg"
import ghast from "../../sound/ghast.mp3"


import { BrowserRouter as  Router, Route, Routes, Link } from 'react-router-dom';
import { useLocation } from 'react-router-dom';
import { useEffect, useState } from 'react';
import updateOre from "../../business/updateOre"
import updateMine from "../../business/updateMine"
import updateHdv from "../../business/updateHdv"
import updateGolem from "../../business/updateGolem"
import updateWall from "../../business/updateWall"
import updateTower from "../../business/updateTower"

export default function Game(){
  
  const location = useLocation();
  const [name, setName] = useState('');
  const [id_village, setIdVillage] = useState('');
  const [name_village, setNomVillage] = useState('');
  const [lastUpdate, setLastUpdate] = useState(0);

  useEffect(() => {
    const searchParams = new URLSearchParams(location.search); 
    setName(searchParams.get('name'));
    setNomVillage(searchParams.get('village'));
  }, [location.search]);

  const [user_irons, setIron] = useState('');
  const [user_diamond, setDiamond] = useState('');
  const [user_emerauld, setEmerauld] = useState('');

  const [user_golem, setGolem] = useState('');
  const [user_wall, setWall] = useState('');
  const [user_tour, setTour] = useState('');

  const [max_irons, setMaxIron] = useState('');
  const [max_diamond, setMaxDiamond] = useState('');
  const [max_emerauld, setMaxEmerauld] = useState('');
  const [max_golem, setMaxGolem] = useState('');
  const [max_wall, setMaxWall] = useState('');
  const [max_tour, setMaxTour] = useState('');

  const [levelMine, setLevelMine] = useState('');
  const [levelHdv, setLevelHdv] = useState('');


  const [irons_rankup_mine, setIronMine] = useState('');
  const [diamond_rankup_mine, setDiamondMine] = useState('');
  const [emerald_rankup_mine, setEmeraldMine] = useState('');

  const [irons_rankup_hdv, setIronHdv] = useState('');
  const [diamond_rankup_hdv, setDiamondHdv] = useState('');
  const [emerald_rankup_hdv, setEmeraldHdv] = useState('');
  
  useEffect(() => {
    if(typeof name_village !== 'string' || name_village === '') {
      return;
    }
    axios.get(`http://localhost:${config.SWAGGER_PORT}/api/Villages/search/${name_village}`)
    .then(response => {
        setIdVillage(response.data[0].id);   
        setIron(response.data[0].irons);
        setDiamond(response.data[0].diamonds);
        setEmerauld(response.data[0].emeralds);
        setMaxIron(response.data[0].levelMine.ironMaxRate);
        setMaxDiamond(response.data[0].levelMine.diamondMaxRate);
        setMaxEmerauld(response.data[0].levelMine.emeraldMaxRate);
        setLevelMine(response.data[0].levelMine.id);
        setLevelHdv(response.data[0].levelHdv.id);
        setGolem(response.data[0].golems);
        setWall(response.data[0].walls);

        setMaxGolem(response.data[0].levelHdv.maxGolems);
        setMaxWall(response.data[0].levelHdv.maxWalls);
        setTour(response.data[0].towers);
        setMaxTour(response.data[0].levelHdv.maxTowers);

        axios.get(`http://localhost:${config.SWAGGER_PORT}/api/RankupMines/${response.data[0].levelMine.id}`)
        .then(response => {
          setIronMine(response.data.irons);
          setDiamondMine(response.data.diamonds);
          setEmeraldMine(response.data.emeralds);          
        });

        axios.get(`http://localhost:${config.SWAGGER_PORT}/api/RankupHdvs/${response.data[0].levelHdv.id}`)
        .then(response => {
          setIronHdv(response.data.irons);
          setDiamondHdv(response.data.diamonds);
          setEmeraldHdv(response.data.emeralds);          
        });
    })
    .catch(error => {
      // Gérez les erreurs de la requête ici
      console.error(error);
    });
  }, [name_village, lastUpdate]);
  
  
    const rankupmine_title = `irons : ${irons_rankup_mine} | diamond : ${diamond_rankup_mine} | emerald : ${emerald_rankup_mine}`
    const rankuphdv_title = `irons : ${irons_rankup_hdv} | diamond : ${diamond_rankup_hdv} | emerald : ${emerald_rankup_hdv}`
  
   
  async function handleClick() {
    try {
        await updateOre(id_village);
        setLastUpdate(Date.now())
    } catch (e) {
        console.log(e);
    }
  }

  async function handleClickMine() {
    try {
        if(parseInt(user_irons) > parseInt(irons_rankup_mine) && parseInt(user_diamond) > parseInt(diamond_rankup_mine) && parseInt(user_emerauld) > parseInt(emerald_rankup_mine) && parseInt(levelMine) < 10){
          let audio = new Audio(levelup);
          audio.play();
        }else{
          let audio = new Audio(ghast);
          audio.play();
        }
        await updateMine(id_village);
        setLastUpdate(Date.now())
        
    } catch (e) {
        console.log(e);
    }
  }

  async function handleClickHdv() {
    try {
      if(parseInt(user_irons) > parseInt(irons_rankup_hdv) && parseInt(user_diamond) > parseInt(diamond_rankup_hdv) && parseInt(user_emerauld) > parseInt(emerald_rankup_hdv) && parseInt(levelHdv) < 5){
        let audio = new Audio(levelup);
        audio.play();
      }else{
        let audio = new Audio(ghast);
        audio.play();
      }
        await updateHdv(id_village);
        setLastUpdate(Date.now())
    } catch (e) {
        console.log(e);
    }
  }

  async function handleClickGolem() {
    try {
      if(parseInt(user_golem) < parseInt(max_golem) && parseInt(user_irons) > 600 ){
        let audio = new Audio(pnj);
        audio.play();
      }
        await updateGolem(id_village);
        setLastUpdate(Date.now())
    } catch (e) {
        console.log(e);
    }
  }

  async function handleClickWall() {
    try {
      if(parseInt(user_wall) < parseInt(max_wall) && parseInt(user_diamond) > 50 ){
        let audio = new Audio(chevre);
        audio.play();
      }
        await updateWall(id_village);
        setLastUpdate(Date.now())
    } catch (e) {
        console.log(e);
    }
  }

  async function handleClickTower() {
    try {
      if(parseInt(user_tour) < parseInt(max_tour) && parseInt(user_emerauld) > 100 ){
        let audio = new Audio(witch);
        audio.play();
      }
        await updateTower(id_village);
        setLastUpdate(Date.now())
    } catch (e) {
        console.log(e);
    }
  }

  async function handleClickDeco() {
    try {
      let audio = new Audio(damage);
      audio.play();
    } catch (e) {
        console.log(e);
    }
  }

return(

<section className="bg-gradient-to-tr backdrop-blur-sm font-serif text-white">

<br></br>
            <hr></hr>
            <br></br>
            <Link to="/login"><button id="btn_deco" onClick={handleClickDeco}>Déconnexion</button> </Link>
            <Link to={`/city?name=${name}`}><button id="btn_deco">Villages</button> </Link>
            <Link to={`/chat`}><button id="btn_deco">Chat</button> </Link>
            <div className="flex items-center justify-center">
              <img src={logo} alt="Logo" className="test"></img>
            <h1 className="font-bold text-3xl text-green-950">MineOfClans</h1>         
            </div>
            <br></br>
            <h1 className="font-bold text-2xl text-green-950">Bienvenue {name} à {name_village} !</h1>   
            <br></br>
            <hr></hr>
            <br></br>

<div id="fond" className="flex h-screen">
    <div className="w-1/4 h-full border-2 border-white p-4">
      <h1 className="text-center text-2xl font-bold p-4">MINE</h1>
      <br></br>
      <div className="flex">
        <img src={iron} className="w-8"></img>
        <p className="px-4">: {user_irons}</p>
      </div>   
      <br></br>
      <div className="flex">
        <img src={diamond} className="w-8"></img>
        <p className="px-4">: {user_diamond}</p>
      </div>
      <br></br>
      <div className="flex">
        <img src={emerauld} className="w-8"></img>
        <p className="px-4">: {user_emerauld}</p>
      </div>
      <br></br>
      <br></br>
      <img src={mineButton} onClick={handleClick} alt="mine" className="w-36 h-34 hover:border"></img>
      <p> CLIQUER POUR MINER </p>

      <br></br>
      <br></br>

      <div>
          <img src={sorcier} alt="sorcier" className="w-26 h-40 text-center"></img>
          <div className="flex">
            <p className="pe-2">Nombre de tours : {user_tour} </p>
          </div>
      </div>
    </div>
    <div className="w-1/2 h-screen border-2 border-white p-4 ">
      <h1 className="text-center text-2xl font-bold p-4">Village</h1>
      <br></br>
      <div className="flex h-1/2">
        <div className="border-4 border-white w-1/2 h-72 p-4 text-xl">
            <p>Niveau Mine : {levelMine}</p>
            <br></br>
            <div id="mine" className="mx-5"><img src={mine} alt="mine" className="w-38 h-36 rounded-3xl"></img></div>
            <div className="mr-50">
              <ul className="list-disc ml-8" id="stock_mine">
                <li>Max fer : {max_irons}</li>
                <li>Max diamant : {max_diamond} </li>
                <li>Max émeraude : {max_emerauld} </li>
              </ul>
            </div>
            <br></br>
            <button id="mon-bouton" className="bg-lime-500 text-white rounded-xl p-1 relative" title={rankupmine_title} onClick={handleClickMine}>
              Upgrade</button>
        </div>
        <div className="border-4 border-white w-1/2 h-72 p-4 text-xl">
            <p>Niveau HDV : {levelHdv} </p>
            <br></br>
            <div id="hdv" className="mx-5"><img src={hdv} alt="hdv" className="w-36 h-36"></img></div>  
            <div className="mr-50">
              <ul className="list-disc ml-8" id="stock_hdv">
                <li>Max golems : {max_golem}</li>
                <li>Max murailles : {max_wall}</li>
                <li>Max tours : {max_tour}</li>
              </ul>
            </div>
            <br></br><br></br>     
            <button id="mon-bouton" className="bg-lime-500 text-white rounded-xl p-1 relative" title={rankuphdv_title} onClick={handleClickHdv}>

              Upgrade</button>
        </div>
        
      </div>
      <div className="border-4 border-white h-72 p-4 text-xl">
        <p>Shop :</p>
        <div className="image-container">
        <div>
          <img src={golem} alt="golem" className="w-26 h-40 text-center hover:border" onClick={handleClickGolem}></img>
          <div className="golem-container">
            <p className="pe-2">600</p><img src={iron} className="w-8"></img>
        </div>
        </div>
        <div>
          <img src={murailles} alt="murailles" className="w-26 h-40 text-center hover:border" onClick={handleClickWall}></img>
          <div className="murailles-container">
          <p className="pe-2">50 </p> <img src={diamond} className="w-8"></img>
          </div>
        </div>
        <div>
          <img src={sorcier} alt="sorcier" className="w-26 h-40 text-center hover:border" onClick={handleClickTower}></img>
          <div className="sorcier-container">
            <p className="pe-2">100</p><img src={emerauld} className="w-8"></img>
        </div>
        </div>
      </div>          
      </div>
    </div>
    <div className="w-1/4 h- border-2 border-white p-4">
      <h1 className="text-center text-2xl font-bold p-4">Défense</h1>
      <br></br>
      <div className="flex justify-center">
        <img src={golem} alt="golem" className="w-26 h-52"></img>
      </div>
      <br></br>
      <p className="px-4 text-center">Nombre de Golems : {user_golem}</p>
      <div className="flex justify-center my-10">
        <img src={murailles} alt="murailles" className="w-26 h-52"></img>
      </div>
      <br></br>
      <p className="px-4 text-center">Nombre de murailles : {user_wall}</p>
    </div>
  </div>
</section>   

);

}
