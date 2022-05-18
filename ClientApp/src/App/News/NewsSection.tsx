import React, {Component} from 'react';
import FormTextInput from "../Shared/UI/FormTextInput";
import {NewsItem} from "./Data/News";
import {NewsIO} from "./IO/NewsIO";

interface Props {

}

interface State {
    newsItem: NewsItem;
    file: any;
}

class NewsSection extends Component<Props, State> {
    constructor(props) {
        super(props);
        this.state = {newsItem: {detailsAR: "", titleAR: "", detailsEN: "", titleEN: "", image: ""}, file: null};
        this.newsIO = new NewsIO();
    }

    public newsIO: NewsIO;
    onChangeHandler = event => {
        if (event.target.files.length > 0) {
            this.setState({file: event.target.files[0]});
        }
    };

    private submit = async () => {

        const result = await this.newsIO.CreateNewsItem(this.state.newsItem, this.state.file);
        console.log(result);
    };

    render() {

        return (
            <div className="container">
                <FormTextInput object={this.state.newsItem} baseProprietyName={"title"} titleEN={"Title"}
                               titleAR={"العنوان"} isTextArea={false}
                               onChange={value => this.setState({newsItem: value})}/>

                <FormTextInput object={this.state.newsItem} baseProprietyName={"details"} titleEN={"Details"}
                               titleAR={"التفاصيل"} isTextArea={true}
                               onChange={value => this.setState({newsItem: value})}/>


                <div className="row form-group">

                    <div className="col-md-2">File</div>

                    <div className="col-md-10">
                        <input type="file" name="file" onChange={this.onChangeHandler}/>

                    </div>

                </div>
                <div className="form-group  mt-5">
                    <input type="button" onClick={this.submit} className="btn btn-primary col-md-2" value="Add"/>
                </div>


            </div>
        );

    }


}

export default NewsSection;