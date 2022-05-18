import React, {Component} from 'react';

interface Props {
    object: any;
    baseProprietyName: string;// like title and it will be title + AR or EN
    titleEN: string;
    titleAR: string;
    isTextArea: boolean;
    onChange: (value) => void;

}

class FormTextInput extends Component<Props> {

    onENValueChange = (value) => {
        this.props.object[this.props.baseProprietyName + "EN"] = value;
        this.props.onChange(this.props.object);
    };
    onARValueChange = (value) => {
        this.props.object[this.props.baseProprietyName + "AR"] = value;
        this.props.onChange(this.props.object);
    };

    render() {

        return (
            <div className="row form-group">
                <div className="col-md-2">{this.props.titleEN}</div>
                {this.props.isTextArea ? (
                    <>
                        <div className="col-md-5">
                            <textarea className="form-control" placeholder={this.props.titleEN}
                                      onChange={event => this.onENValueChange(event.target.value)}/>
                        </div>
                        <div className="col-md-5">
                            <textarea className="form-control text-right " placeholder={this.props.titleAR}
                                      onChange={event => this.onARValueChange(event.target.value)}/>
                        </div>

                    </>
                ) : (
                    <>
                        <div className="col-md-5">
                            <input className="form-control" placeholder={this.props.titleEN}
                                   onChange={event => this.onENValueChange(event.target.value)}/>
                        </div>
                        <div className="col-md-5">
                            <input className="form-control text-right " placeholder={this.props.titleAR}
                                   onChange={event => this.onARValueChange(event.target.value)}/>
                        </div>
                    </>
                )}

            </div>
        );
    }
}

export default FormTextInput;