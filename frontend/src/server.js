
const httpServer = require('http').createServer().listen(8888);
const io = new (require('socket.io').Server)(httpServer, {
    cors: {
        origin: ['http://localhost:3000']
    }
});

io.on('connection', (socket) => {
  console.log('Nouvelle connexion WebSocket');

  socket.on('chat message', (message) => {
    console.log('Nouveau message de chat :', message);
    io.emit('chat message', message); // Diffuse le message à tous les clients connectés
  });

  socket.on('disconnect', () => {
    console.log('Déconnexion WebSocket');
  });
});
