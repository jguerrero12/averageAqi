import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;
  constructor() {
    super();
    this.state = { echo: '' };
  }

  render() {
    return (
      <div>
        <label for="echo">Enter your input to echo:</label>
        <input type="text" onChange={e => this.setState({ echo: e.target.value })} id="echo" name="echo" /><br /><br />
        <p>{this.state.echo}</p>
      </div>
    );
  }
}
