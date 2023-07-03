import { BrowserRouter as Router, Route, Routes, Link } from 'react-router-dom';
//import 'tailwindcss/tailwind.css';
import './index.css';
//import Game from '../Game';
import logo from "../../img/logo.png"
import '../../accueil.css'
import RankingComponent from '../Ranking/index';

export default function App() {
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
            
            <div class="flex items-center justify-center">
              <img src={logo} alt="Logo" class="w-44 h-44 rounded-full mr-2"></img>
                {/*<h1 class="font-bold text-3xl">MineOfClans</h1>*/}            
            </div>
            <br></br>
            <hr></hr>
            <div class="p-9 flex justify-center space-x-2">
                <Link to="/login"><button className="bg-red-500 rounded-xl p-4 w-20 text-white">Login</button> </Link>
                <Link to="/register" className="bg-blue-500 rounded-xl p-4 w-28 text-white"><button>Register</button> </Link>
            </div>
            <div>
              <RankingComponent />
            </div >

        </section>
  );
}




































