import React from 'react';
import './App.css';
import { BrowserRouter, Route } from 'react-router-dom';
import { NewMessage } from './components/NewMessage';
import { MessageList } from './components/MessageList';

function App() {
  return (
    <BrowserRouter>
      <div className="App">
          <Route exact path='/' component={MessageList}></Route>
          <Route path='/newMessage' component={NewMessage}></Route>
      </div>
    </BrowserRouter>
  );
}

export default App;
