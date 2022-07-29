import { useMutation, UseMutationOptions } from 'react-query';
import BasketLine from '../../models/BasketLine';
import QueryKeys from '../../models/QueryKeys';

interface AddEventToBasketInput {
  basketId: string
  body: {
    eventId: string
    ticketAmount: number
    price: number
  }
}
  
const addEventToBasket = async (request: AddEventToBasketInput): Promise<BasketLine[]> => {
  const response = await fetch(`https://localhost:5005/api/baskets/${request.basketId}/basketLines`, { 
    method: 'Post',
    headers: {
      "Content-Type": "application/json"
    },
    body: JSON.stringify(request.body)
  })

  if (response.ok) {
    return response.json()
  }

  throw new Error("ErrorAddingEventToBasket");
}

const useAddEventToBasket = (options?: UseMutationOptions<BasketLine[], Error, AddEventToBasketInput>) =>
  useMutation<BasketLine[], Error, AddEventToBasketInput>(QueryKeys.basketLine, addEventToBasket, options);

export default useAddEventToBasket;
