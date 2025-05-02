# 🤟 SignBridge: Real-Time 3D Sign Language Translator

> Bridging communication between hearing and deaf individuals through real-time 3D sign language animations powered by Unity, Python, and Flutter.

---

## 📽️ Demo

Check out the full system in action in our demo video:  
🎥 [`demo.mkv`](demo.mkv)

---

## 📌 Overview

**SignBridge** is a cross-platform communication tool designed to help hearing users send clear, understandable messages to deaf or hard-of-hearing individuals — particularly those who struggle with reading traditional written language.

The system converts text input from a mobile app into live 3D sign language animations, shown through a Unity-rendered avatar.

---

## 🧱 System Components

### 🧍 Unity - Sign Performer

- Displays a **3D humanoid avatar** performing sign language.
- Uses pre-animated sign gestures for a set of recognized words.
- Continuously polls the Python server via HTTP to check for new messages.
- **Unknown or unsupported words are skipped**, reflecting how sign language naturally omits some terms.

#### ✅ Supported Vocabulary

The following words trigger animations in Unity:

"hello", "this", "sign", "language", "translation",
"phone", "application", "help", "us", "to",
"communication", "with", "deaf", "people", "i",
"feeling", "prefer", "you", "which", "happy",
"what", "will", "eat", "today", "for",
"thank", "understand"
---
### 🌐 Python Server - Message Relay

- Acts as the **communication bridge** between Flutter and Unity.
- Receives messages from the Flutter mobile app using HTTP `POST`.
- Responds to Unity with the latest message using HTTP `GET`.
- Persists the message until a new one is received.
- Built using **Flask**, with optional **Ngrok** for external accessibility.

#### 🧪 API Endpoints

| Method | Endpoint      | Description                  |
|--------|---------------|------------------------------|
| `POST` | `/message`    | Receives message from Flutter |
| `GET`  | `/message`    | Sends latest message to Unity |

---

### 📱 Flutter App - Text Sender

- Provides a clean and simple UI for the user to enter messages.
- Sends the input to the Python server using a `POST` request.
- Designed for anyone to quickly send a message that will be signed visually in Unity.
- Runs on mobile using the Flutter framework.

---

## 🔄 System Workflow


Flutter App
   ⬇️ (POST /message)
Python Server
   ⬆️ (GET /message)
Unity App
   🧍 3D Avatar performs animations

-----


## 🧪 How It Works
A hearing person opens the Flutter app and types a message like:
"Hello! This application helps with communication."

The app sends this message to the Python server (POST /message).

The Unity app polls the server every second (GET /message) for updates.

When a new message is found, Unity:

Splits it into words

Matches supported words to animations

Skips unsupported ones

Plays the animations in order using a 3D avatar

The deaf person sees the message performed in sign language.


## 🧰 Technologies Used
🎮 Unity 3D (for animation and interaction)

🧪 Python (Flask for API backend)

📱 Flutter (for mobile interface)

🌍 Ngrok (to expose localhost server over the internet)

-----

## 🎯 Goals & Impact
Empower deaf users with accessible communication through visual sign language.

Improve interaction where reading may not be sufficient (e.g., young children, recently deafened individuals).

Provide a portable, low-barrier solution that requires no physical interpreters or additional hardware.