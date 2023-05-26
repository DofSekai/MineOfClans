import { BrowserRouter as Router, Route, Routes, Link } from 'react-router-dom';
//import 'tailwindcss/tailwind.css';
import './index.css';

import Login from '../Login';
import Register from '../Register';
import Game from '../Game';

export default function App() {
  return (
    <Router>

        <section>
            <h1>MineOfClans</h1>
            <div class="button-log">
                <Link to="/login"><button class="bg-blue-500 text-white text-base px-4 py-2">Login</button> </Link>
                <Link to="/register"><button>Register</button> </Link>
            </div>

            <Game />
        </section>
        <Routes>

            <Route path="/login" element={<Login />} />
            <Route path="/register" element={<Register />} />

        </Routes>

    </Router>
  );
}




































