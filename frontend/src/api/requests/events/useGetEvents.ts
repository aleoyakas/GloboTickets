import { useQuery, UseQueryOptions } from 'react-query';
import Event from '../../models/Event';
import QueryKeys from '../../models/QueryKeys';

const getEvents = async (): Promise<Event[]> => {
  const response = await fetch('https://localhost:5005/api/events');

  if (response.ok) {
    return response.json()
  }

  throw new Error("ErrorFetchingEvents");
}

const useGetEvents = (options?: UseQueryOptions<Event[], Error>) =>
  useQuery<Event[], Error>(QueryKeys.events, getEvents, options);

export default useGetEvents;
