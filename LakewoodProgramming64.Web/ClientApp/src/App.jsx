import React, { useEffect, useState } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import './App.css';
import axios from 'axios';

const App = () => {
    const [items, setItems] = useState([]);
    useEffect(() => {
        const showCurriculum = async () => {
            const { data } = await axios.get('/api/scraper/scrape');
            await setItems(data);
            console.log(data)

        }
        showCurriculum();
    }, [])

    const splitTopics = topic => {
        const topicArray = topic.split('\n').slice(1, -1)
        return (topicArray.map(t => <li key={t}>{t}</li>))
    }

    return (
        <div className='container mt-5'>
            <div>
                <h1>Curriculum</h1>
            </div>
            <table style={{ fontSize: 20 }} className="table table-bordered">
                <tbody>
                    {items.map(m =>
                        <tr>
                            <td style={{ verticalAlign: "middle" }}>{m.month}</td>
                            <td>
                                <ul>
                                    {splitTopics(m.topic)}
                                </ul>
                            </td>
                        </tr>
              
                    )}
                </tbody>
            </table>
        </div>
    )
}
export default App;
//  {/* <li>{m.topic}</li> */}
//   {i.topics.map(t => <li>{topic}</li>)}
// {/* <td>
// <ul>
//     {topics.map(t => <li>{t}</li>)}


// </ul>
// </td> */}




