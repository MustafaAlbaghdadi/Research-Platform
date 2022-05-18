import React, {Component} from 'react';
import {Office} from "../../Data/Office";

interface Props {
    office: Office;
}

class OfficeTableRow extends Component<Props> {
    render() {
        return (
            <tr>
                <th scope="row">{this.props.office.id}</th>
                <td>{this.props.office.nameEN}</td>
                <td>{this.props.office.nameAR}</td>
            </tr>
        );
    }
}

export default OfficeTableRow;