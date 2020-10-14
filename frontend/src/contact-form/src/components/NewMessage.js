import React, { Component } from 'react';

export class NewMessage extends Component {
    render() {
        return(
            <form id="contact-form">
                <div className="form-group">
                    <div className="row">
                        <div className="col-md-6">
                            <input placeholder="Email" id="email" type="email" className="form-control" required></input>
                        </div>
                    </div>
                </div>
            </form>
        );
    }
}