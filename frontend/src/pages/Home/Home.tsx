import React, { FC } from 'react';
import { useGetEvents } from '../../api/requests/events';
import { useGetUser } from '../../api/requests/user';
import { useGetBasket } from '../../api/requests/baskets';
import EventCard from '../../components/EventCard';
import styles from './styles.module.css';

const Home: FC = () => {
  const { data: userId } = useGetUser();
  const { data: basket } = useGetBasket({ userId });
  const { data: events, error: eventsError } = useGetEvents();

  if (eventsError) {
    return (
      <p>Failed to load events</p>
    )
  }

  return (
    <div className={styles.container}>
      {events?.map((event) => (
        <EventCard basketId={basket?.basketId} event={event} key={event.eventId} />
      ))}
    </div>
  );
}

export default Home;
