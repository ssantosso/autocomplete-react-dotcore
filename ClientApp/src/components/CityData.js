import React, { Component } from 'react';
import Autocomplete from "./AutoComplete";

export class CityData extends Component {
    static displayName = CityData.name;

    onClick = e => {
        this.populateData(Autocomplete.userInput);
    };
    constructor(props) {
        super(props);
        this.state = { city: [], loading: true };
    }

    componentDidMount() {
        this.populateData();
    }



    static renderCityTable(data) {
        return (
            <div>
                <div className="row">
                    <Autocomplete className="form-control" />
                    <button className="btn btn-success" onClick={this.onClick}>Search</button>
                </div>
                <table className='table table-striped' aria-labelledby="tabelLabel">
                    <thead>
                        <tr>
                            <th>name</th>
                            <th>country</th>
                            <th>subcountry</th>
                            <th>geonameid</th>
                        </tr>
                    </thead>
                    <tbody>
                        {data.map(data =>
                            <tr key={data.name}>
                                <td>{data.name}</td>
                                <td>{data.country}</td>
                                <td>{data.subcountry}</td>
                                <td>{data.geonameid}</td>
                            </tr>
                        )}
                    </tbody>
                </table>
            </div>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : CityData.renderCityTable(this.state.city);

        return (
            <div>
                <h1 id="tabelLabel" >List of City with AutoComplete</h1>
                {contents}
            </div>
        );
    }

    async populateData() {
        const response = await fetch('api/v1/city');
        const data = await response.json();
        this.setState({ city: data, loading: false });
    }
}
