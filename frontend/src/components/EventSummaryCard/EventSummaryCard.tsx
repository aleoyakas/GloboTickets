import React, { FC } from 'react';
import { useQueryClient } from 'react-query';
import EventSummary from '../../api/models/EventSummary';
import QueryKeys from '../../api/models/QueryKeys';
import { useRemoveEventFromBasket, useUpdateEventInBasket } from '../../api/requests/basketLines';
import UpdateTicketCounter from '../TicketCounter';
import styles from './styles.module.css';

interface Props {
  basketId: string
  basketLineId: string
  event: EventSummary
  price: number
  ticketAmount: number
}

const EventSummaryCard: FC<Props> = ({ basketId, basketLineId, event, price, ticketAmount }) => {
  const queryClient = useQueryClient();
  
  const { mutate: updateEventInBasket, isLoading } = useUpdateEventInBasket({ onSuccess: () => {
    queryClient.invalidateQueries(QueryKeys.basketLine)
  }});

  const updateTicketCount = (newCount: number) => {
    updateEventInBasket({
      basketId,
      basketLineId,
      body: {
        ticketAmount: newCount
      }
    });
  }

  const { mutate: removeEventFromBasket } = useRemoveEventFromBasket({ onSuccess: () => {
    queryClient.invalidateQueries(QueryKeys.basket)
    queryClient.invalidateQueries(QueryKeys.basketLine)
  }});

  return (
    <div className={styles.container}>
      <h2>{event.name}</h2>
      <p>{new Date(event.date).toDateString()}</p>
      <div className={styles.eventInfo}>
        <p>Price per ticket: £{price}</p>
        <UpdateTicketCounter ticketAmount={ticketAmount} updateTicketCount={updateTicketCount} isLoading={isLoading} />
        <p>Event Total: £{ticketAmount * price}</p>
      </div>
      <button
        onClick={() => removeEventFromBasket({ basketId, basketLineId })}
        className={styles.removeEvent}
      >
        Remove Event
      </button>
    </div>
  );
}

export default EventSummaryCard;
