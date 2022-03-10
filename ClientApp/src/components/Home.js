import React, { Component } from 'react';

export class Home extends Component {
    static displayName = Home.name;

    render() {
        return (
            <div>
                <h1>Autocomplete test</h1>
                <p>As a full-stack developer, you should implement an autocomplete component of cities (ordered asc), and data of the selected city (country, subcountry and geonameid):</p>
                <ul>
                    <li>Use any UI libraries such as bootstrap / material etc. </li>
                    <li>The UI shouldn't be fancy, but a nice-looking UI will be appreciated.</li>
                    <li>The component should be written using React. </li>
                    <li>The server-side should be written in .Net core (3.1/5) </li>
                    <li>Bonus - add meaningful unit tests for your work For your convenience we have attached a sample csv file with cities. </li>
                </ul>
            </div>
        );
    }
}
