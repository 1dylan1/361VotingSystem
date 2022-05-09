import React from "react";
import { useState, useEffect } from "react";
import { PieChart, Pie, Sector, Cell, Tooltip, Legend } from "recharts";

import responseService from "../services/responseServices";
import LoadingDots from "../components/LoadingDots.js";
import "../styles/pollCard.css";
import "../styles/adminCard.css";


function AdminPollCard(props) {

    var [activeButton, setActiveButton] = useState(null);
    var [votingOption, setVotingOption] = useState(null);
    var [optionList, setOptionList] = useState([]); //options for each poll
    var [loading, setLoading] = useState(true);
    var [hasVoted, setHasVoted] = useState(false);
    var userId = props.userData[0].accId;
    var [data, setDataList] = useState([]);
    var [sum, setSum] = useState(0);

    const COLORS = ["#0088FE", "#00C49F", "#FFBB28", "#FF8042"];

    useEffect(() => {
        var list = [];
        responseService.getCount(props.pollId).then((response) => {
            var s = 0;
                for (var i = 0; i < response.data.length; i++) {
                    var element = {
                        name: response.data[i].choice,
                        value: response.data[i].sum
                    } 
                    list.push(element);
                    s = s + element.value;

                }
            setSum(s)
            setDataList(list);
        }).catch((error) => {
            console.log(error)
        })

        setLoading(false);
    }, [])

    const handleActiveButton = (e) => {
        setActiveButton(e);
        setVotingOption(e)
    }

    return (
        <div className="pollCard-container">
            {loading === true ? <LoadingDots /> :
                <div>
                    <h1>{props.title}</h1>
                    <p>{props.description}</p>
                    <b>Total Votes: {sum}</b>
                    <div className="pi-chart">
                        <PieChart width={300} height={550}>
                            <Pie
                                data={data}
                                cx={120}
                                cy={200}
                                innerRadius={60}
                                outerRadius={80}
                                paddingAngle={5}
                                dataKey="value"
                            >
                                {data.map((entry, index) => (
                                    <Cell key={`cell-${index}`} fill={COLORS[index % COLORS.length]} />
                                ))}
                            </Pie>
                            <Tooltip />
                            <Legend className="legend-layout" layout="vertical" align="right" />
                            </PieChart>
                        </div>
                </div>
            }
        </div>
    );
}

export default AdminPollCard;
