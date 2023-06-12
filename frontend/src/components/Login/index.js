import "../App/default.css"
import "./test.css"
import mine from "../../img/mine.png"
import logo from "../../img/logo.png"
import golem from "../../img/golem.png"

import { BrowserRouter as Router, Route, Routes, Link } from 'react-router-dom';

export default function Game() {


    return (

        <section class="bg-gradient-to-b from-slate-400">

            <br></br>
            <hr></hr>
            <br></br>

            <div class="flex items-center justify-center">
                <img src={logo} alt="Logo" class="test"></img>
                <h1 class="font-bold text-3xl">MineOfClans</h1>
            </div>
            <br></br>
            <h1 class="font-bold text-2xl">Bienvenue .......</h1>
            <br></br>
            <hr></hr>
            <br></br>

            <div class="flex h-screen">
                <div class="w-1/4 h-full border-2 border-black p-4">
                    <h1 class="text-center text-2xl font-bold p-4">MINE</h1>
                    <br></br>
                    <p class="px-4">Iron : 0</p>
                    <br></br>
                    <p class="px-4">Gold : 0</p>
                    <br></br>
                    <p class="px-4">Emerauld : 0</p>
                    <br></br>
                    <br></br>
                    <img src={mine} alt="mine" class="w-36 h-36 rounded-3xl"></img>
                </div>
                <div class="w-1/2 h-full border-2 border-black p-4">
                    <h1 class="text-center text-2xl font-bold p-4">Village</h1>
                    <br></br>
                    <div class="flex h-1/2">
                        <div class="border-4 border-black w-1/2 h-72 p-4">
                            <p>Niveau Mine : X</p>
                            <br></br>
                            <img src={mine} alt="mine" class="w-36 h-36 rounded-3xl"></img>
                            <br></br>
                            <button class="bg-lime-500 text-white rounded-xl p-1">Upgrade</button>
                        </div>
                        <div class="border-4 border-black w-1/2 h-72 p-4">
                            <p>azerty</p>
                        </div>

                    </div>
                    <div class="border-4 border-black h-72 p-4">
                        <p>dofsekai</p>
                    </div>
                </div>
                <div class="w-1/4 h- border-2 border-black p-4">
                    <h1 class="text-center text-2xl font-bold p-4">D�fense</h1>
                    <br></br>
                    <div class="flex justify-center">
                        <img src={golem} alt="golem" class="w-26 h-52"></img>
                    </div>
                    <br></br>
                    <p class="px-4">Nombre de Golems : 0</p>
                </div>
            </div>

        </section>

    );


}