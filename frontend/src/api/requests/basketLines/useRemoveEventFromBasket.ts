import { useMutation, UseMutationOptions } from 'react-query';
import QueryKeys from '../../models/QueryKeys';

interface RemoveBasketLineInput {
  basketId: string
  basketLineId: string
}

const removeBasketLine = async (request: RemoveBasketLineInput): Promise<undefined> => {
  const response = await fetch(`https://localhost:5005/api/baskets/${request.basketId}/basketLines/${request.basketLineId}`, { 
    method: 'Delete',
    headers: {
      "Content-Type": "application/json"
    },
  })

  if (!response.ok) {
    throw new Error("ErrorDeletingBasketLine");
  }

  return;
}

const useRemoveEventFromBasket = (options?: UseMutationOptions<undefined, Error, RemoveBasketLineInput>) =>
  useMutation<undefined, Error, RemoveBasketLineInput>(QueryKeys.basketLine, removeBasketLine, options);

export default useRemoveEventFromBasket;
