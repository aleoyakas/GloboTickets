import EventSummary from "./EventSummary"

interface BasketLine {
  "basketLineId": string
  "basketId": string
  "eventId": string
  "price": 0,
  "ticketAmount": 0,
  "event": EventSummary
}

export default BasketLine;
