import React, { Component } from 'react';
import { MessageItem } from './MessageItem';

export class MessageList extends Component{

    constructor(props) {
        super(props);
        this.state = {
            messages_list: []
        };
    }

    async componentDidMount() {
        const options = {
            crossDomain:true,
            headers: {
              'Access-Control-Allow-Origin':'*'
            }
        }

        let res = await fetch("http://localhost:5003/message", options)
        let messages = res.json()
        console.log(messages)
        this.setState({messages_list: messages})
    }

    render() {
        return(
            <div>
                {this.state.messages_list.map(message => (
                    <MessageItem>
                        {}
                    </MessageItem>
                ))}
                
            </div>
        );
    }
}