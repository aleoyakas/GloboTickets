import React, { FC } from 'react';
import { BrowserRouter, Route, Routes } from "react-router-dom";
import Header from '../Header';
import Home from '../../pages/Home';
import ShoppingBasket from '../../pages/ShoppingBasket';
import { QueryClient, QueryClientProvider } from 'react-query';
import { ReactQueryDevtools } from 'react-query/devtools';

const queryClient = new QueryClient({
  defaultOptions: {
    queries: {
      retry: 0,
      staleTime: 30000,
    },
  }
})

const App: FC = () => {
  return (
    <QueryClientProvider client={queryClient}>
      <BrowserRouter>
        <Header />
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="basket" element={<ShoppingBasket />} />
        </Routes>
      </BrowserRouter>
      <ReactQueryDevtools initialIsOpen={false}/>
    </QueryClientProvider>
  );
}

export default App;
