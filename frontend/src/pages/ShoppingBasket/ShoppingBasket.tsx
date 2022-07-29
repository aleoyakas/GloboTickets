import React, { FC, Suspense } from 'react';
import { useGetBasket } from '../../api/requests/baskets';
import { useGetEventsInBasket } from '../../api/requests/basketLines';
import { useGetUser } from '../../api/requests/user';
import EventSummaryCard from '../../components/EventSummaryCard';
import styles from './styles.module.css';
import getTimeInSeconds from '../../utils/getTimeInSeconds';

interface Props {
  basketId: string
}

const Content: FC<Props> = ({ basketId }) => {
  const { data: basketLines } = useGetEventsInBasket({ basketId }, { suspense: true });
  const sortedBasketLines = (basketLines || []).sort((a , b) => getTimeInSeconds(a.event.date) - getTimeInSeconds(b.event.date))
  const isBasketEmpty = sortedBasketLines.length === 0;
  const total = basketLines?.reduce((acc, curr) => acc + (curr.price * curr.ticketAmount), 0)

  return (
    <div className={styles.events}>
      {sortedBasketLines?.map((basketLine) => (
        <EventSummaryCard
          key={basketLine.basketLineId}
          basketId={basketLine.basketId}
          basketLineId={basketLine.basketLineId}
          event={basketLine.event}
          price={basketLine.price}
          ticketAmount={basketLine.ticketAmount} />
      ))}
      {isBasketEmpty && (
        <p>You have nothing in your basket!</p>
      )}
      <div className={styles.purchaseInfo}>
        Total: £{total}
        <button
          onClick={() => alert("Woooooo")}
          disabled={isBasketEmpty}
        >
          Complete Purchase
        </button>
      </div>
    </div>
  );
}

const ShoppingBasket: FC = () => {
  const { data: user } = useGetUser();
  const { data: basket } = useGetBasket({ userId: user });

  if (!basket) {
    return null;
  }

  return (
    <div className={styles.container}>
      <Suspense fallback={<p>Loading....</p>}>
        <Content basketId={basket.basketId} />
      </Suspense>
    </div>
  );
}

export default ShoppingBasket;
