import { BrowserRouter as Router, Route, Routes, Link } from 'react-router-dom';
//import 'tailwindcss/tailwind.css';
import './index.css';
//import Game from '../Game';

export default function App() {
  return (
        <section>
            <br></br>
            <hr></hr>
            <br></br>
            <h1 className="font-bold text-center text-3xl">MineOfClans</h1>
            <br></br>
            <hr></hr>
            <div class="p-9 flex justify-center space-x-2">
                <Link to="/login"><button className="bg-red-500 rounded-xl p-2 text-white">Login</button> </Link>
                <Link to="/register" className="bg-blue-500 rounded-xl p-2 text-white"><button>Register</button> </Link>
            </div>

        </section>
  );
}




































