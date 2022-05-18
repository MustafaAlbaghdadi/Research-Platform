import React, {Component} from 'react';
import {OfficeIO} from "../IO/OfficeIO";
import {Office} from "../Data/Office";
import OfficeTableRow from "./Table/OfficeTableRow";

interface State {
    Offices: Office[];
}

class Offices extends Component<any, State> {
    constructor(props: any) {
        super(props);
        this.state = {Offices: []};
        this.officeIO = new OfficeIO();

    }

    private officeIO: OfficeIO;

    async componentDidMount(): Promise<void> {
        this.officeIO.Offices().then(value =>
            this.setState({Offices: value.data})
        );
    }

    render() {
        return (
            <div>

                Offices
                <div>
                    <thead>
                    <tr>
                        <th>#</th>
                        <th>Title [English]</th>
                        <th>Title [Arabic]</th>
                    </tr>
                    </thead>
                    <tbody>
                    {
                        this.state.Offices.map((value, index) => <OfficeTableRow office={value} key={index}/>)
                    }
                    </tbody>
                </div>
            </div>
        );
    }
}

export default Offices;