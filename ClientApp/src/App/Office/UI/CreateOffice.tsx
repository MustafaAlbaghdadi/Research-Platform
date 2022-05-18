import React, {Component} from 'react';
import FormTextInput from "../../Shared/UI/FormTextInput";
import {Office} from "../Data/Office";
import {OfficeIO} from "../IO/OfficeIO";

interface Props {

}

interface State {
    office: Office;
}

class CreateOffice extends Component<Props, State> {
    // constructor(props: Props) {
    //     super(props);
    //     this.state = {office: {id: 0, nameAR: "", nameEN: ""}};
    //     this.officeIo = new OfficeIO();
    // }
    //
    // private officeIo: OfficeIO;
    // private submit = async () => {
    //     const result = await this.officeIo.Create(this.state.office);
    //     console.log(result);
    // };

    render() {
        return (
            <div>
Hello
                {/*<FormTextInput object={this.state.office} baseProprietyName={"name"} titleEN={"Office Name"}*/}
                {/*               titleAR={"اسم المكتب"} isTextArea={false}*/}
                {/*               onChange={value => this.setState({office: value})}/>*/}

                {/*<div className="form-group  mt-5">*/}
                {/*    <input type="button" onClick={this.submit} className="btn btn-primary col-md-2" value="Add"/>*/}
                {/*</div>*/}

            </div>
        );
    }
}

export default CreateOffice;