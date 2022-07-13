import React, { useEffect, useState } from 'react';
import logo from './logo.svg';
import './App.css';
import { fetchApi } from './ApiClient';

function App() {
    let [hb, setHb] = useState<Response | null>(null)

    useEffect(() => {
        fetchApi('api/hb').then(x => {
            let result = x.json() as Promise<Response>
            result.then(y => setHb(y))
        })
    }, [])

    return (
        <div className="App">
            <header className="App-header">
                <img src={logo} className="App-logo" alt="logo" />
                <p>
                    Heartbeat date: {hb?.date ?? 'loading...'}
                </p>
                <a
                    className="App-link"
                    href="https://reactjs.org"
                    target="_blank"
                    rel="noopener noreferrer"
                >
                    Learn React
                </a>
            </header>
        </div>
    );
}

export default App;

interface Response {
    date: string
}
