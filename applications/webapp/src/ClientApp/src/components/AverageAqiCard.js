import React from "react";
import { searchWeather } from "./request";
import ListGroup from "react-bootstrap/ListGroup";
function CurrentWeather({ keywordStore }) {
  const [weather, setWeather] = React.useState({});
  const getWeatherForecast = async params => {
    const response = await getAverageAqi(params);
    setWeather(response.data);
  };
  React.useEffect(() => {
    keywordStore.keyword && getWeatherForecast(keywordStore.keyword);
  }, [keywordStore.keyword]);
  return (
    <div>
      {weather.main ? (
        <ListGroup flush>
          <ListGroupItem>
            Average AQI: {weather.main}
          </ListGroupItem>
        </ListGroup>
      ) : null}
    </div>
  );
}
export default CurrentWeather;