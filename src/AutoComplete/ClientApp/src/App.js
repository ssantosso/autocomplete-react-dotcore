import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { CityData } from './components/CityData';

import './custom.css'

export default class App extends Component {
    static displayName = App.name;

    render() {
        return (
            <Layout>
                <Route exact path='/' component={CityData} />
                <Route path='/fetch-data' component={Home} />
            </Layout>
        );
    }
}
