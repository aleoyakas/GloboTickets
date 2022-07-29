import { useQuery, UseQueryOptions } from 'react-query';
import QueryKeys from '../../models/QueryKeys';

const getEvents = async (): Promise<string> => "47448e29-cfb8-94fa-48c0-dea319b25b92";

const useGetUser = (options?: UseQueryOptions<string, Error>) =>
  useQuery<string, Error>(QueryKeys.user, getEvents, options);

export default useGetUser;
