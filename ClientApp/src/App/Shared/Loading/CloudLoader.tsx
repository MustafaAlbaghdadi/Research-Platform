import React from "react";


interface Props {
    className?: string;
    title?: string;
}

export default class CloudLoader extends React.Component<Props> {

    render(): any {
        return <div className={`cloud-loader ${this.props.className ? this.props.className : ''}`}>
            <img src={'/assets/loader.svg'} alt={''} className={'loader-image'}/>
            {
                this.props.title && <h3 className="mt-3">{this.props.title}</h3>
            }
        </div>
    }
}