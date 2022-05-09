import axios from 'axios'

const GET_ANSWERS_API = "https://localhost:7027/api/answers"

class answerService {

    getAnswersById(pollId) {
        return axios.get(GET_ANSWERS_API + '/' + pollId);
    }

}

export default new answerService();