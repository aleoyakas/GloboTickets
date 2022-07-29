import { useQuery, UseQueryOptions } from 'react-query';
import Basket from '../../models/Basket';
import QueryKeys from '../../models/QueryKeys';

interface GetBasketInput {
  userId?: string
}

const getBasket = async (request: GetBasketInput): Promise<Basket> => {
  const response = await fetch(`https://localhost:5005/api/baskets?userId=${request.userId}`);

  if (response.status === 200) {
    return response.json();
  }

  if (response.status === 204) {
    throw new Error("UserHasNoBasket");
  }

  throw new Error("ErrorFetchingBasketOverview");
}

const useGetBasket = (request: GetBasketInput, options?: UseQueryOptions<Basket, Error>) =>
  useQuery<Basket, Error>([QueryKeys.basket, ...Object.values(request)], () => getBasket(request), options);

export default useGetBasket;
