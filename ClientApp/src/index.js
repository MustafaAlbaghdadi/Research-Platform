import React from 'react';
import ReactDOM from 'react-dom';
import {BrowserRouter} from 'react-router-dom';
import registerServiceWorker from './registerServiceWorker';
import './tailwind.output.css'
import Store from "./Bootstrap/Store";
import {Provider} from "react-redux";
import Main from "./Main";

const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
const rootElement = document.getElementById('root');

ReactDOM.render(
    <Provider store={Store()}>
        <BrowserRouter basename={baseUrl}>
            <Main/>
        </BrowserRouter>
    </Provider>,
    rootElement);

registerServiceWorker();

