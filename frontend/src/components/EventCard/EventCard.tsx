import React, { FC, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { useQueryClient } from 'react-query';
import Event from '../../api/models/Event';
import QueryKeys from '../../api/models/QueryKeys';
import { useAddEventToBasket } from '../../api/requests/basketLines';
import TicketCounter from '../TicketCounter';
import styles from './styles.module.css';

interface Props {
  basketId?: string
  event: Event
}

const EventCard: FC<Props> = ({ basketId, event }) => {
  const navigate = useNavigate();
  const queryClient = useQueryClient();
  const [ticketAmount, setTicketAmount] = useState(0);

  const { mutate: addEventToBasket, isLoading } = useAddEventToBasket({ onSuccess: () => {
    queryClient.invalidateQueries(QueryKeys.basket);
    queryClient.invalidateQueries(QueryKeys.basketLine);
  }});

  const addEvent = () => {
    if (basketId) {
      addEventToBasket({
        basketId,
        body: { 
          eventId: event.eventId,
          ticketAmount,
          price: event.price
        }
      }, { onSuccess: () => {
        navigate('/basket')
      }});
    }
  }

  return (
    <article className={styles.eventCard}>
      <h2>{event.name}</h2>
      <p>{event.artist}</p>
      <div className={styles.eventInfo}>
        <img src={event.imageUrl} alt={event.name} className={styles.eventImg} />
        <p>{event.description}</p>
      </div>
      {basketId && (
        <>
          <TicketCounter
            ticketAmount={ticketAmount}
            updateTicketCount={setTicketAmount}
            isLoading={isLoading}
          />
          <button
            onClick={addEvent}
            className={styles.addToCartBtn}
            disabled={ticketAmount === 0 || !basketId}
          >
            Add to Cart
          </button>
        </>
      )}
    </article>
  );
}

export default EventCard;
