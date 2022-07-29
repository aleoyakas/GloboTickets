import EventSummary from "./EventSummary"

interface Event extends EventSummary {
  "price": number
  "artist": string
  "description": string
  "imageUrl": string
  "categoryId": string
  "categoryName": string
}

export default Event;
