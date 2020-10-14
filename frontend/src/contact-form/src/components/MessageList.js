import React, { Component } from 'react';
import { MessageItem } from './MessageItem';

export class MessageList extends Component{

    constructor(props) {
        super(props);
        this.state = {
            messages_list: []
        };
        this.messagesStore = this.messagesStore.bind(this);
    }

    componentDidMount() {
    }

    render() {
        return(
            <div>
                <MessageItem></MessageItem>
            </div>
        );
    }
}