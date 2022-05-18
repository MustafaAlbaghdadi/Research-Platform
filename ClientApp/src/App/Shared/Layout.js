import React, {Component} from 'react';
import SideBar from "./SideBar";

export class Layout extends Component {
    static displayName = Layout.name;

    render() {

        return (
            <div dir={"rtl"} className="flex md:flex-row-reverse flex-wrap">

                <div className="w-full lg:w-5/6 md:w-4/6 bg-gray-100">

                    <div className="container bg-gray-100 pt-16 px-6">
                        {this.props.children}
                    </div>
                </div>

                <SideBar/>
            </div>



        );
    }
}
