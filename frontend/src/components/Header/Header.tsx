import React, { FC, useState } from 'react';
import { Link } from 'react-router-dom';
import Basket from '../../api/models/Basket';
import { useGetUser } from '../../api/requests/user';
import { useCreateBasket, useGetBasket } from '../../api/requests/baskets';
import styles from './styles.module.css';

const Header: FC = () => {
  const [basket, setBasket] = useState<Basket>();

  const { data: userId } = useGetUser();
  const { mutate: createBasket } = useCreateBasket({
    onSuccess: (basket) => {
      setBasket(basket)
    }
  });
  
  useGetBasket({ userId }, {
    enabled: typeof userId !== 'undefined',
    onSuccess: ((basket) => {
      setBasket(basket);
    }),
    onError: ((error: Error) => {
      if (error.message === "UserHasNoBasket") {
        createBasket({ body: { userId } });
      }
    })
  });

  return (
    <header className={styles.container}>
      <h1 className={styles.heading}>Global Tickets</h1>
      <nav className={styles.navMenu}>
        <ul>
          <li>
            <Link to="/" className={styles.navLink}>Home</Link>
          </li>
          <li>
            <Link to="/basket" className={styles.navLink}>Shopping Basket: {basket ? basket.numberOfItems : '-'}</Link>
          </li>
        </ul>
      </nav>
    </header>
  );
}

export default Header;
