import React from "react";
import { useEffect } from "react";
import Navbar from "../components/Navbar";
import PollCard from "../components/PollCard.js";
import LoadingDots from "../components/LoadingDots.js";
import { useState } from "react";
import { Link, useNavigate, useLocation } from "react-router-dom";
import pollService from "../services/pollServices";
import "../styles/adminCard.css";
function Dashboard(props) {

    const [polls, setPolls] = useState([]);
    const [currUser, setUser] = useState(null);
    const [loading, setLoading] = useState(true);

    const navigate = useNavigate();
    const location = useLocation();

    //API HANDLING
    try {
        if (location.state.userInfo);
    } catch (e) {
        navigate('/login');
    }

    useEffect(() => {
        console.log("Fetching Poll API Data..")
        pollService.getAllPolls().then((response) => {
            var pollData = [];
            for (var i = 0; i < response.data.length; i++) {
                var poll = {
                    pollId: response.data[i].pollId,
                    title: response.data[i].title,
                    description: response.data[i].description,
                    accountId: response.data[i].accountId
                }
                pollData.push(poll);
                setPolls(pollData);
            }
            setLoading(false);
            console.log("Fetched Poll Data!")
        }).catch(error => {
            console.log(error);
        })
    }, [])

    return (
        <div className="db-container">
            <Navbar />

            {loading == true ? <LoadingDots /> :
                    polls.map((pollcard) => (
                        <PollCard
                            title={pollcard.title}
                            description={pollcard.description}
                            pollId={pollcard.pollId}
                            userData={location.state.userInfo}
                        />
                    ))
            }
        </div>
    );
}

export default Dashboard;