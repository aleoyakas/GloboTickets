import { useQuery, UseQueryOptions } from 'react-query';
import BasketLine from '../../models/BasketLine';
import QueryKeys from '../../models/QueryKeys';

interface GetBasketContentRequest {
  basketId?: string
}

const getBasketContent = async (request: GetBasketContentRequest): Promise<BasketLine[] | undefined> => {
  if (!request.basketId) {
    return;
  }
  const response = await fetch(`https://localhost:5005/api/baskets/${request.basketId}/basketLines`);

  if (response.ok) {
    return response.json()
  }

  throw new Error("ErrorFetchingBasketLines");
}

const useGetEventsInBasket = (request: GetBasketContentRequest,  options?: UseQueryOptions<BasketLine[] | undefined, Error>) =>
  useQuery<BasketLine[] | undefined, Error>(QueryKeys.basketLine, () => getBasketContent(request), options);

export default useGetEventsInBasket;
