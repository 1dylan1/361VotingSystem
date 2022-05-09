import axios from 'axios'

const GET_ALL_POLLS_REST_API = "https://localhost:7027/Poll/api/polls"

class pollService {

    getAllPolls() {
        return axios.get(GET_ALL_POLLS_REST_API)
    }
}

export default new pollService();