import { BrowserRouter as  Router, Route, Routes, Link } from 'react-router-dom';
import { useLocation } from 'react-router-dom';
import { useEffect, useState } from 'react';
import getCity from '../../business/getCity.js'; 
import logo from "../../img/logo.png"
import axios from "axios"
import config from '../../config.js';

export default function City(){
    const location = useLocation();
    const [name, setName] = useState('');
    const [id, setId] = useState('');
    const [citys, setCitys] = useState([]);

    useEffect(() => {
        const searchParams = new URLSearchParams(location.search); 
        setName(searchParams.get('name'));
    }, [location.search]);
   
    useEffect(() => {
        axios.get(`http://localhost:${config.SWAGGER_PORT}/api/Users/search/${name}`)
        .then(response => {
            console.log(response);
            setId(response.data[0].id);          
        });
    });
    
    useEffect(() => {
        if(typeof id !== 'number') {
            return;
        }

        async function fetchCity() {
          try {
            console.log(id);
            const fetchedCitys = await getCity(
                id
            );
            setCitys(fetchedCitys);
          } catch (e) {
            alert(e);
          }
        }
      
        fetchCity();
      }, [id]);
  
  return(
  
  <section class="">
  
    <br></br>
    <hr></hr>
    <br></br>
    <Link to="/login"><button id="btn_deco">Déconnexion</button> </Link>
    <div class="flex items-center justify-center">
        <img src={logo} alt="Logo" class="test"></img>
        <h1 class="font-bold text-3xl">MineOfClans</h1>         
    </div>
    <br></br>
    <h1 class="font-bold text-2xl">Villages de {name} !</h1>   
    <br></br>
    <hr></hr>
    {citys.map(city => (
            <div class="flex flex-col items-center">
            <a href={`http://localhost:3000/game?name=${name}&village=${city.name}`}> 
            <h3 class="text-center mt-2">{city.name}</h3></a>
        </div>
        
    ))}


  </section>   
  
  );
  
  
  }
  