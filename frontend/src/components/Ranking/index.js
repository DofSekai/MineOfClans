import "../App/default.css"
import React, { useEffect, useState } from 'react';


const RankingComponent = () => {
    const [userIds, setUserIds] = useState([]);
  
    useEffect(() => {
      const fetchUserIds = async () => {
        try {
          const response = await fetch('http://localhost:'+config.SWAGGER_PORT+'/api/Users/ranking');
          const data = await response.json();
          const ids = data.map(user => user.id);
          setUserIds(ids);
        } catch (error) {
          console.error('Erreur lors de la récupération des IDs des utilisateurs:', error);
        }
      };
  
      fetchUserIds();
    }, []);
  
    return (
      <div>
        <h1>Classement des utilisateurs</h1>
        <ul>
          {userIds.map(userId => (
            <li key={userId}>{userId}</li>
          ))}
        </ul>
      </div>
    );
  };

export default RankingComponent;