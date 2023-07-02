const APIURL = "https://webapp-averageaqi.herokuapp.com";

const axios = require("axios");
export const getAverageAqi = params =>
  axios.get(
      `${APIURL}/averageAqi`,
      { params }
  );