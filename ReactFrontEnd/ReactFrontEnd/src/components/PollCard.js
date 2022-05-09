import React from "react";
import { useState, useEffect } from "react";
import answerService from "../services/answerService";
import responseService from "../services/responseServices";
import LoadingDots from "../components/LoadingDots.js";
import "../styles/pollCard.css"


function PollCard(props) {

    var [activeButton, setActiveButton] = useState(null);
    var [votingOption, setVotingOption] = useState(null);
    var [optionList, setOptionList] = useState([]);
    var [loading, setLoading] = useState(true);
    var [hasVoted, setHasVoted] = useState(false);
    var userId = props.userData[0].accId;

    useEffect(() => {
        console.log("Fetching Answers API..")
        answerService.getAnswersById(props.pollId).then((response) => {
            var options = [];
            for (var i = 0; i < response.data.length; i++) {
                var optionElement = {
                    option: response.data[i].choice,
                    answerId: response.data[i].answerId
                }
                options.push(optionElement);
            }
            setOptionList(options);
            console.log("Retrieved Answers Data!")
            setLoading(false);
        })

        console.log("Fetching Responses API..")
        responseService.getResponses(props.pollId, userId).then((response) => {
            if (response.data.length > 0) {
                console.log("User has voted on this poll.")
                setHasVoted(true); //user cannot vote on poll anymore.
            }
        }).catch((error) => {
            console.log(error)
        })
    }, [])

    const handleActiveButton = (e) => {
        setActiveButton(e);
        setVotingOption(e)
    }

    function handleConfirm() {
       if(votingOption != null) {
           return true;
       } else {
           return false;
       }
    }

    const SendVote = (e) => {
        e.preventDefault();
        if (hasVoted === true) {
            console.log("Youve already voted for this. Stop.")
            return;
        }
        console.log("Attempting to send vote..")
        responseService.sendResponse(votingOption.answerId, props.pollId, userId).then((response) => {
            console.log(response);
            console.log("Vote sent!");
            window.location.reload(false);
        }).catch(error => {
            console.log(error)
        })
    }

    return (
        <div className="pollCard-container">
            <h1>{props.title}</h1>
            <p>{props.description}</p>
            {loading === true ? <LoadingDots /> :
                (hasVoted === false) ?
                    optionList.map((optionElement) => (
                        <button
                            className={activeButton === optionElement ? 'pc_button1' : 'pc_button2'}
                            onClick={() => handleActiveButton(optionElement)}>{optionElement.option}
                        </button>
                    ))
                    : <h1 style={{ color:"white"}}>You've already voted on this poll.</h1>
            }
            <button className="pc_buttonC" onClick={(e) => SendVote(e)}>Confirm</button>
        </div>
    );
}

export default PollCard;