import React, { useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import userService from "../services/userServices";
import LoadingDots from "../components/LoadingDots.js";

import "../styles/Login.css";

function Signup() {

    const navigate = useNavigate();
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [errNotifier, setErrNotifier] = useState(false);
    const [loading, setLoading] = useState(false);

    //API HANDLING
    const handleUserLogin = (e) => {
        e.preventDefault();
        if (email.trim().length === 0 || password.trim().length === 0) {
            console.log("Your string is empty. We aren't calling an API.")
            return;
        }
        console.log("Attempting API CALL..")
        setLoading(true)
        let userData = null;
        userService.getUserByLogin(email, password).then((response) => {
            setLoading(false)
            if (response.data.id !== -1) { //if we got a valid account from our db..
                userData = [
                    {
                        accId: response.data.id,
                        userName: response.data.voterId,
                        accType: response.data.accountType
                    }
                ]
                console.log(userData)

                if (userData[0].accId !== -1) {
                    console.log("Account Successfully Validated - Redirecting..")
                    if (userData[0].accType === 'A') {
                        navigate('/adminpanel', { state: { userInfo: userData } });
                    } else {
                        navigate('/dashboard', { state: { userInfo: userData } });
                    }
                }

            } else {
                setErrNotifier(true);
                console.log("API Returned an invalid login. Enter correct login.")
            }
        }).catch(error => {
            console.log(error);
        })
    }

    return (
        <div className="login-container">
            <Link to="/">
                <button className="return-button">Back</button>
            </Link>
            <div className="login">
                <form className="form-login">
                    {errNotifier ? <h1 className="err-text">Incorrect Login.</h1> : null}
                    <p>Voter Registered Username</p>
                    <input type="text" name="" placeholder="Ex: jdoe1" onChange={(e) => setEmail(e.target.value)}>
                    </input>
                    <p>Password</p>
                    <input type="password" name="" placeholder="Password" onChange={(e) => setPassword(e.target.value)}>
                    </input>
                    <input type="submit" name="" value="Submit" onClick={(e) => handleUserLogin(e)}>
                    </input>
                    {loading === true ? <LoadingDots /> : null }
                </form>
            </div>
        </div>
    );
}

export default Signup;