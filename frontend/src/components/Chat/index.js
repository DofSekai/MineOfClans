import React, { Component } from 'react';
import io from 'socket.io-client';
import { BrowserRouter as  Router, Route, Routes, Link } from 'react-router-dom';
import { useLocation } from 'react-router-dom';
import { useEffect, useState } from 'react';

import config from '../../config.js';

import "../App/default.css"

class Chat extends Component {

  constructor(props) {
    super(props);
    this.state = {
      messages: [],
      newMessage: '',
    };

    this.socket = io('http://localhost:8888'); // Remplacez l'URL par l'adresse de votre serveur WebSocket
  }

  

  componentDidMount() {
    this.socket.on('connect', () => {
      console.log('Connecté au serveur WebSocket');
    });

    this.socket.on('disconnect', () => {
      console.log('Déconnecté du serveur WebSocket');
    });

    this.socket.on('chat message', (message) => {
      this.setState((prevState) => ({
        messages: [...prevState.messages, message],
      }));
    });
  }

  handleChange = (event) => {
    this.setState({ newMessage: event.target.value });
  };

  handleSubmit = (event) => {
    event.preventDefault();
    const { newMessage } = this.state;
    this.socket.emit('chat message', newMessage);
    this.setState({ newMessage: '' });
  };

  render() {
    const { messages, newMessage } = this.state;

    return (
      <div class="bg-white">
        <ul>
          {messages.map((message, index) => (
            <li key={index}>{message}</li>
          ))}
        </ul>
        <form onSubmit={this.handleSubmit}>
          <input class="border border-black"
            type="text"
            value={newMessage}
            onChange={this.handleChange}
          />
          <button class="bg-green-500*
          " type="submit">Envoyer</button>
        </form>
        <br></br>
        <Link to={`/`}><button id="btn_deco">Menu</button> </Link>
      </div>
    );
  }
}

export default Chat;
