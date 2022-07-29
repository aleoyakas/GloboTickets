import React, { FC } from 'react';
import styles from './styles.module.css';

interface Props {
  ticketAmount: number
  updateTicketCount: (newCount: number) => void
  isLoading: boolean
}

const TicketCounter: FC<Props> = ({ ticketAmount, updateTicketCount, isLoading }) => {
  return (
    <div className={styles.container}>
      <button 
        onClick={() => updateTicketCount(ticketAmount + 1)} 
        className={styles.updateTicketCountBtn} 
        disabled={isLoading}
      >
        +
      </button>
      <p>Tickets: {ticketAmount}</p>
      <button
        onClick={() => updateTicketCount(ticketAmount - 1)}
        className={styles.updateTicketCountBtn}
        disabled={isLoading || ticketAmount === 0}
      >
        -
      </button>
    </div>
  );
}

export default TicketCounter;
