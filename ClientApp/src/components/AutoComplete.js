import React, { Component, Fragment } from "react";

class Autocomplete extends Component {
    constructor(props) {
        super(props);
        this.state = {
            activeSuggestion: 0,
            filteredSuggestions: [],
            showSuggestions: false,
            userInput: ""
        };
    }
    onChange = e => {
        const userInput = e.currentTarget.value;
        this.populateAutoComplete(userInput);
        this.setState({
            activeSuggestion: 0,
            filteredSuggestions: this.state.filteredSuggestions,
            showSuggestions: true,
            userInput: userInput
        });
    };
    onClick = e => {
        this.setState({
            activeSuggestion: 0,
            filteredSuggestions: [],
            showSuggestions: false,
            userInput: e.currentTarget.innerText
        });
    };

    onKeyDown = e => {
        const { activeSuggestion, filteredSuggestions } = this.state;

        if (e.keyCode === 13) {
            this.setState({
                activeSuggestion: 0,
                showSuggestions: false,
                userInput: filteredSuggestions[activeSuggestion]
            });
        } else if (e.keyCode === 38) {
            if (activeSuggestion === 0) {
                return;
            }
            this.setState({ activeSuggestion: activeSuggestion - 1 });
        }
        // User pressed the down arrow, increment the index
        else if (e.keyCode === 40) {
            if (activeSuggestion - 1 === filteredSuggestions.length) {
                return;
            }
            this.setState({ activeSuggestion: activeSuggestion + 1 });
        }
    };

    render() {
        const {
            onChange,
            onClick,
            onKeyDown,
            state: {
                activeSuggestion,
                filteredSuggestions,
                showSuggestions,
                userInput
            }
        } = this;

        let suggestionsListComponent;

        if (showSuggestions && userInput) {
            if (filteredSuggestions.length) {
                suggestionsListComponent = (
                    <ul className="suggestions">
                        {filteredSuggestions.map((suggestion, index) => {
                            let className;

                            // Flag the active suggestion with a class
                            if (index === activeSuggestion) {
                                className = "suggestion-active";
                            }
                            return (
                                <li className={className} key={suggestion} onClick={onClick}>
                                    {suggestion}
                                </li>
                            );
                        })}
                    </ul>
                );
            } else {
                suggestionsListComponent = (
                    <div className="no-suggestions">
                        <em>No suggestions available.</em>
                    </div>
                );
            }
        }
        return (
            <Fragment>
                <div className="col-md-5 col-xs-12 col-lg-5 col-sm-8 form-group has-feedback">

                    <input
                        id="autocompleteFilter"
                        type="text"
                        style={{ margin: 20 }}
                        onChange={onChange}
                        onKeyDown={onKeyDown}
                        value={userInput}
                        className="form-control"
                        placeholder="please write the city you are looking for"
                    />


                    {suggestionsListComponent}
                </div>
            </Fragment>
        );
    }
    async populateAutoComplete(userInput) {
        const response = await fetch('api/v1/city/obterporfiltro?filtro=' + userInput);
        const data = await response.json();
        this.setState({
            activeSuggestion: 0,
            filteredSuggestions: data.sugestions,
            showSuggestions: true,
            userInput: userInput
        });
    }
}

export default Autocomplete;

