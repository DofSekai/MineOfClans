import '../../index.css';
import createUser from '../../business/createUser.js'; 
import React, { useState } from 'react';
import { BrowserRouter as  Router, Route, Routes, Link } from 'react-router-dom';


export default function Register() {

    const [pseudo, setPseudo] = useState(""); // État local pour stocker la valeur de l'input

    function handleInputChange(event) {
        setPseudo(event.target.value); // Mettre à jour la valeur de l'input dans l'état local
    }
    async function handleClick() {
        try {
            await createUser({
                "name": pseudo // Utiliser la valeur de l'input
            });
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
                            <h1 class="text-2xl font-semibold">Register</h1>
                        </div>
                        <div class="divide-y divide-gray-200">
                            <div class="py-8 text-base leading-6 space-y-4 text-gray-700 sm:text-lg sm:leading-7">
                                    <form id="form_pseudo" >
                                        <div class="relative">
                                            <input autoComplete="off" id="name" name="name" type="text" onChange={handleInputChange}
                                                class="peer placeholder-transparent h-10 w-full border-b-2 border-gray-300 text-gray-900 focus:outline-none focus:borer-rose-600" placeholder="Pseudo" />
                                        <label class="absolute left-0 -top-3.5 text-gray-600 text-sm peer-placeholder-shown:text-base peer-placeholder-shown:text-gray-440 peer-placeholder-shown:top-2 transition-all peer-focus:-top-3.5 peer-focus:text-gray-600 peer-focus:text-sm">Pseudo</label>
                                        
                                        </div>
                                        <div class="relative">
                                            <button class="bg-blue-500 text-white rounded-md px-2 py-1" value={pseudo} onClick={handleClick} >Join</button>
                                        </div>
                                    </form>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    );
}