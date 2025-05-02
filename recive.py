from fastapi import FastAPI
from fastapi.responses import PlainTextResponse
from pydantic import BaseModel
import uvicorn
app = FastAPI()

class Message(BaseModel):
    new_message: str

message = "h"

@app.get("/message", response_class=PlainTextResponse)
def get_message():
    return message

@app.post("/message")
def update_message(message_body: Message):
    global message
    message = message_body.new_message
    return {"message": "Message updated successfully"}

if __name__ == "__main__":
    uvicorn.run(app, host="0.0.0.0", port=8000)
