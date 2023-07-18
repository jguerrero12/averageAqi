const APIURL = "https://webapp-averageaqi.herokuapp.com";

import axios from 'axios';
/**
 * Gets average aqi for a given Date range and location
 */
export default class GetAverageAqiService {
  getAverageAqi(params) {
    return axios.get(
      `${APIURL}/averageAqi`,
      { params }
    );
  }
}