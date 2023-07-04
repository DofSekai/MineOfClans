import '../../index.css';
import createCity from '../../business/createCity.js'; 
import { BrowserRouter as  Router, Route, Routes, Link, useNavigate } from 'react-router-dom';
import { useEffect, useState,useLocation  } from 'react';
import axios from "axios";
import config from '../../config.js';

export default function RegisterCity() {
    const [pseudo, setPseudo] = useState('');
    const [id_pseudo, setIdPseudo] = useState('');
    const [namecity, setCity] = useState(""); // �tat local pour stocker la valeur de l'input
    const navigate = useNavigate();
    const location = useLocation();

    useEffect(() => {
        const searchParams = new URLSearchParams(location.search); 
        setPseudo(searchParams.get('name'));
      }, [location.search]);

    useEffect(() => {
        axios.get(`http://localhost:${config.SWAGGER_PORT}/api/Users/search/${pseudo}`)
        .then(response => {
            setIdPseudo(response.data[0].id);          
        });
    });

    function handleInputChange(event) {
        setCity(event.target.value); 
    }
    async function handleClick() {
        try {
            await createCity({
                "name": namecity, 
                "userId": id_pseudo
            });
            navigate(`/game?name=${pseudo}&village=${namecity}`);
        } catch (e) {
            alert(e);
        }
    }

    return(
        <section> 
        <br></br>
        <hr></hr>
        <br></br>
        <Link to="/"><h1 className="font-bold text-center text-3xl">MineOfClans</h1></Link>
        <br></br>
        <hr></hr>
        <div class="min-h-screen bg-gray-100 py-6 flex flex-col justify-center sm:py-12">
            <div class="relative py-3 sm:max-w-xl sm:mx-auto">
                <div
                    class="absolute inset-0 bg-gradient-to-r from-blue-300 to-blue-600 shadow-lg transform -skew-y-6 sm:skew-y-0 sm:-rotate-6 sm:rounded-3xl">
                </div>
                <div class="relative px-4 py-10 bg-white shadow-lg sm:rounded-3xl sm:p-20">
                    <div class="max-w-md mx-auto">
                        <div>
                            <h1 class="text-2xl font-semibold">Add City</h1>
                        </div>
                        <div class="divide-y divide-gray-200">
                            <div class="py-8 text-base leading-6 space-y-4 text-gray-700 sm:text-lg sm:leading-7">
                                    <div class="relative">
                                        <input autoComplete="off" id="namecity" name="namecity" type="text" onChange={handleInputChange}
                                            class="peer placeholder-transparent h-10 w-full border-b-2 border-gray-300 text-gray-900 focus:outline-none focus:borer-rose-600" placeholder="Nom village" />
                                    <label class="absolute left-0 -top-3.5 text-gray-600 text-sm peer-placeholder-shown:text-base peer-placeholder-shown:text-gray-440 peer-placeholder-shown:top-2 transition-all peer-focus:-top-3.5 peer-focus:text-gray-600 peer-focus:text-sm">Nom village</label>
                                    
                                    </div>
                                    <div class="relative">
                                        <button class="bg-blue-500 text-white rounded-md px-2 py-1" value={namecity} onClick={handleClick} >Join</button>
                                    </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    );
}