import axios from 'axios'

const SEND_RESPONSE_API = "https://localhost:7027/Response/api/response"
const CHECK_RESPONSE_API = "https://localhost:7027/Response/api/hasCompleted"
const GET_COUNT_API = "https://localhost:7027/Response/api/getCount"
class responseService {

    sendResponse(a, b, c) {
        return axios.post(SEND_RESPONSE_API + "/" + a + "/" + b + "/" + c);
    }

    getResponses(pollId, accountId) {
        return axios.get(CHECK_RESPONSE_API + "/" + pollId + "/" + accountId);
    }

    getCount(pollId, answerId) {
        return axios.get(GET_COUNT_API + "/" + pollId);
    }
}

export default new responseService();