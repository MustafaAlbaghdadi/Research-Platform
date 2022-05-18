import * as React from "react";

interface Props {
    title: string;
    message: string;
    exception: any;
}

export default class ErrorSegment extends React.Component<Props> {
    render() {
        return <div >
            <div>{this.props.title}</div>
            <div>{this.props.message}</div>
            {
                this.props.exception &&
                <>
                    <hr/>
                    <pre>
                        <code style={{whiteSpace: 'normal'}}>
                            {JSON.stringify(this.props.exception)}
                        </code>
                    </pre>
                </>
            }
        </div>
    }
}