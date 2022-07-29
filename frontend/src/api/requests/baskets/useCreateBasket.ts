import { useMutation, UseMutationOptions } from 'react-query';
import Basket from '../../models/Basket';
import QueryKeys from '../../models/QueryKeys';

interface CreateBasketInput {
  body: {
    userId?: string
  }
}

const createBasket = async (request: CreateBasketInput): Promise<Basket> => {
  const response = await fetch(`https://localhost:5005/api/baskets`, { 
    method: 'Post',
    headers: {
      "Content-Type": "application/json"
    },
    body: JSON.stringify(request.body)
  })

  if (response.ok) {
    return response.json()
  }

  throw new Error("ErrorCreatingBasket");
}

export const useCreateBasket = (options?: UseMutationOptions<Basket, Error, CreateBasketInput>) =>
  useMutation<Basket, Error, CreateBasketInput>(QueryKeys.basket, createBasket, options);

export default useCreateBasket;
