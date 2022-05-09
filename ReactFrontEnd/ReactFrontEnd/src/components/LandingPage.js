import React from "react";
import "../styles/LandingPage.css"


function LandingPage() {
    return (
        <div>
            <header className="showcase">
                <h1>Your Vote Matters.</h1>
                <p>Your Choice. Your Voice.</p>
                <a href="/login" className="btn">Vote Now</a>
            </header>
        </div>
    );
}

export default LandingPage;