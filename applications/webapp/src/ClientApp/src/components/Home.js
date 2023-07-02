import React, { Component } from 'react';
import { Form, FormGroup, Input, Button, Label } from 'reactstrap';

export class Home extends Component {
  static displayName = Home.name;
  constructor() {
    super();
    this.state = { echo: '' };
  }

  render() {
    return (
      <div>
        <h2>
          Welcome to the Average AQI calculator.
          Enter your location and date range to get your average AQI below.
        </h2>
        <Form>
          <FormGroup>
            <Label for="startDate">
              Start Date
            </Label>
            <Input
              required
              type="date"
              onChange={e => this.setState({ startDate: e.target.value })}
              id="startDate"
              name="startDate"
            />
          </FormGroup>
          <FormGroup>
            <Label for="endDate">
              End Date
            </Label>
            <Input
              required
              type="date"
              onChange={e => this.setState({ endDate: e.target.value })}
              id="endDate"
              name="endDate"
            />
          </FormGroup>
          <Button>
            Search
          </Button>
        </Form>

        <br />
        <br />
        <p>
          {this.state.echo}
        </p>
      </div>
    );
  }
}
