import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './components/App';
import { createBrowserRouter, RouterProvider } from 'react-router-dom';
import Login from './components/Login';
import Register from './components/Register';
import Game from './components/Game';
import City from './components/City';
import RegisterCity from './components/RegisterCity';

const route = createBrowserRouter([
  {
    path: "/",
    element: <App />
  },
  {
    path: "/login",
    element: <Login />
  },
  {
    path: "/register",
    element: <Register />
  },
  {
    path: "/game",
    element: <Game />
  },
  {
    path: "/city",
    element: <City />
  },
  {
    path: "/registercity",
    element: <RegisterCity />
  }
]);

ReactDOM.createRoot(document.getElementById("root")).render(
  <React.StrictMode>
    <RouterProvider router={route} />
  </React.StrictMode>
);


