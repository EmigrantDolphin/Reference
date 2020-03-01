import React, { useState } from 'react'

function Something(){
    const [inputText, setInputText] = useState('');

    function keyUpHandler(e){
        console.log(e.target.value);
        setInputText(e.target.value);
    }

    async function clickHandler(){
        console.log("Success");
        //post to server contents of input
        const resp = await fetch("something", {
            method: "Post",
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                something: inputText
            })
        }).then (res => res.json())
            .then(res => console.log(res));
    }

    return (
        <React.Fragment>
            <div>
                <p>Hello my brother</p>
                <input type="text" name="someInput" onKeyUp={keyUpHandler}/>
                <button onClick={clickHandler}>Submit</button>
            </div>
        </React.Fragment>
    );
}

export default Something;