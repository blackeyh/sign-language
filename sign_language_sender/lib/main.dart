import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;

void main() {
  runApp(MyApp());
}

class MyApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Message Sender',
      theme: ThemeData(
        primarySwatch: Colors.blue,
      ),
      home: MessageSenderPage(),
    );
  }
}

class MessageSenderPage extends StatefulWidget {
  @override
  _MessageSenderPageState createState() => _MessageSenderPageState();
}

class _MessageSenderPageState extends State<MessageSenderPage> {
  final TextEditingController _controller = TextEditingController();
  final String ngrokUrl = 'https://sharp-enormous-collie.ngrok-free.app';

  String _text = '';
  bool _isListening = false;

  void _sendMessage() async {
    if (_text.isNotEmpty) {
      final response = await http.post(
        Uri.parse('$ngrokUrl/message'),
        headers: {'Content-Type': 'application/json'},
        body: jsonEncode({'new_message': _text}),
      );

      if (response.statusCode == 200) {
        ScaffoldMessenger.of(context).showSnackBar(
          SnackBar(content: Text('Message sent successfully')),
        );
      } else {
        ScaffoldMessenger.of(context).showSnackBar(
          SnackBar(content: Text('Failed to send message: ${response.body}')),
        );
      }
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text("Send Message"),
      ),
      body: Padding(
        padding: const EdgeInsets.all(16.0),
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: <Widget>[
            TextField(
              controller: _controller,
              onChanged: (value) {
                setState(() {
                  _text = value;
                });
              },
              decoration: InputDecoration(labelText: 'Enter your message'),
            ),
            SizedBox(height: 20),
           
            SizedBox(height: 20),
            ElevatedButton(
              onPressed: _sendMessage,
              child: Text('Send Message'),
            ),
          ],
        ),
      ),
    );
  }

}
