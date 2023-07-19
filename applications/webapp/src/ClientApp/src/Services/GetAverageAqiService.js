import axios from 'axios';
/**
 * Gets average aqi for a given Date range and location
 */
export default class GetAverageAqiService {
  APIURL = "https://webapp-averageaqi.herokuapp.com";

  getAverageAqi(params) {
    return axios.post(
      `${this.APIURL}/averageAqi`,
      { params }
    );
  }
}