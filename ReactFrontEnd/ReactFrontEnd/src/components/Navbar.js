import React from "react";
import "../styles/Navbar.css";
import { Link, useNavigate } from "react-router-dom";


function Navbar() {

    const navigate = useNavigate();

    const something = () => {
        console.log("helo");
        navigate("/"); 
    }

    return (
        <div className="navbar-container">
           <a className="active" onClick={something}>Log Out</a>
        </div>
    );
}

export default Navbar;