import React from "react";
import './App.css';
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";

import Home from "./pages/Home.js";
import Login from "./pages/Login.js";
import Dashboard from "./pages/Dashboard.js"
import AdminPanel from "./pages/AdminPanel.js"

function App() {
    return (
        <div className="App">
            <Router>
                <Routes>
                    <Route exact path="/" element={<Home />}></Route>
                    <Route exact path="/login" element={<Login />}></Route>
                    <Route exact path="/dashboard" element={<Dashboard />}></Route>
                    <Route exact path="/adminpanel" element={<AdminPanel />}></Route>
                </Routes>
            </Router>
        </div>
    );
}

export default App;
