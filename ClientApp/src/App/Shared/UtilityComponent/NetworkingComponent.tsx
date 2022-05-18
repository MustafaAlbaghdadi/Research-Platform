import * as React from "react";

interface Props {
    loading: boolean;
    loadingComponent: () => React.ReactNode;
    error: any;
    errorComponent: (error: any) => React.ReactNode;
    ready: () => React.ReactNode;
}

export default class NetworkingComponent extends React.Component<Props> {
    render() {
        if (this.props.loading) {
            return this.props.loadingComponent()
        } else if (this.props.error) {
            return this.props.errorComponent(this.props.error);
        }
        return this.props.ready();
    }
}