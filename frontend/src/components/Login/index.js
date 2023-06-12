import '../../index.css';
import test from "../../img/player_head.png"
import { BrowserRouter as  Router, Route, Routes, Link } from 'react-router-dom';

export default function Login(){
    return(
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
                <div class="flex flex-col items-center">
                    <img class="w-24 h-24" src={test} alt="Profile 1" />
                    <h3 class="text-center mt-2">Profile 1</h3>
                </div>
                <div class="flex flex-col items-center">
                    <img class="w-24 h-24" src={test} alt="Profile 2" />
                    <h3 class="text-center mt-2">Profile 2</h3>
                </div>
                <div class="flex flex-col items-center">
                    <img class="w-24 h-24" src={test} alt="Profile 3" />
                    <h3 class="text-center mt-2">Profile 3</h3>
                </div>
                <div class="flex flex-col items-center">
                    <img class="w-24 h-24" src={test} alt="Profile 3" />
                    <h3 class="text-center mt-2">Profile 4</h3>
                </div>
                <div class="flex flex-col items-center">
                    <img class="w-24 h-24" src={test} alt="Profile 3" />
                    <h3 class="text-center mt-2">Profile 5</h3>
                </div>
                <div class="flex flex-col items-center">
                    <img class="w-24 h-24" src={test} alt="Profile 3" />
                    <h3 class="text-center mt-2">Profile 6</h3>
                </div>
                </div>
            </div>
        </section>
    );
}