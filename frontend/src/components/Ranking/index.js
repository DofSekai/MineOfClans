import React, { useEffect, useState } from 'react';
import getRanking from '../../business/getRanking';

const RankingComponent = () => {
  const [ranking, setRanking] = useState([]);

  useEffect(() => {
    const fetchRanking = async () => {
      try {
        const rankingData = await getRanking();
        setRanking(rankingData);
      } catch (error) {
        console.error('Erreur lors de la récupération du classement des utilisateurs:', error);
      }
    };

    fetchRanking();
  }, []);

  return (
    <div>
      <h1>Classement des utilisateurs</h1>
      <ul>
        {ranking.map(user => (
          <li key={user.id}>
            ID: {user.id} - Nom: {user.name}
          </li>
        ))}
      </ul>
    </div>
  );
};

export default RankingComponent;