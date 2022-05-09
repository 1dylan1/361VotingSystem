import axios from 'axios'

const GET_USER_API = "https://localhost:7027/User/api/users"

class userService {

    getUserByLogin(username, password) {
        return axios.get(GET_USER_API + '/' + username + "/" + password);
    }

}

export default new userService();