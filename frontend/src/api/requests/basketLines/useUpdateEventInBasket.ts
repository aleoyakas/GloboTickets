import { useMutation, UseMutationOptions } from 'react-query';
import BasketLine from '../../models/BasketLine';
import QueryKeys from '../../models/QueryKeys';

interface UpdateEventInBasketInput {
  basketId: string
  basketLineId: string
  body: {
    ticketAmount: number
  }
}

const updateEventInBasket = async (request: UpdateEventInBasketInput): Promise<BasketLine[]> => {
  const response = await fetch(`https://localhost:5005/api/baskets/${request.basketId}/basketLines/${request.basketLineId}`, { 
    method: 'Put',
    headers: {
      "Content-Type": "application/json"
    },
    body: JSON.stringify(request.body)
  })

  if (response.ok) {
    return response.json()
  }

  throw new Error("ErrorUpdatingEventInBasket");
}

const useUpdateEventInBasket = (options?: UseMutationOptions<BasketLine[], Error, UpdateEventInBasketInput>) =>
  useMutation<BasketLine[], Error, UpdateEventInBasketInput>(QueryKeys.basketLine, updateEventInBasket, options);

export default useUpdateEventInBasket;
