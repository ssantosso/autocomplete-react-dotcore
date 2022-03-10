import React, { Component } from 'react';
import Autocomplete from "./AutoComplete";

export class CityData extends Component {
    static displayName = CityData.name;


    constructor(props) {
        super(props);
        this.state = { city: [], loading: true };
    }

    async handleClick() {
        console.log("Thiss>", this);
        let userInput = document.getElementById("autocompleteFilter").value;
        this.state = { city: [], loading: true };
        await this.populateData(userInput);

    };

    componentDidMount(data) {
        this.state = { city: [], loading: true };
        this.populateData(data ? data : "");
    }




    render() {

        return (
            <div>

                <h1 id="tabelLabel" >List of City with AutoComplete</h1>
                <div className="row">
                    <Autocomplete className="form-control" />
                    <div className="col-md-3 col-xs-6 col-sm-6 margin-top" >
                        <span className="btn btn-dark "onClick={this.handleClick.bind(this)}>Search</span>

                    </div>
                </div>
                <div>

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
                            {this.state.city.map(data =>
                                <tr key={data.Original}>
                                    <td>{data.name}</td>
                                    <td>{data.country}</td>
                                    <td>{data.subcountry}</td>
                                    <td>{data.geonameid}</td>
                                </tr>
                            )}
                        </tbody>
                    </table>

                </div>
            </div>
        );
    }


    async populateData(userInput) {
        const response = await fetch('api/v1/city/obterporfiltro?filtro=' + (userInput != undefined && userInput ? userInput : ""));
        const data = await response.json();
        this.state = { city: [], loading: true };
        this.setState({ city: data.citys, loading: false });
    }


}
