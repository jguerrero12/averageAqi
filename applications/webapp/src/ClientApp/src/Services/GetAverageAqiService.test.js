import GetAverageAqiService from './GetAverageAqiService';
import GetAverageAqiRequest from '../Models/GetAverageAqiRequest';
import DateRange from '../Models/DateRange';
import Location from '../Models/Location';
import axios from 'axios';

const aqiRes = '14'
jest.mock('axios')
axios.get = jest.fn().mockResolvedValue({ data: aqiRes });

it('gets average aqis', async () => {
    const res = await new GetAverageAqiService().getAverageAqi(
        new GetAverageAqiRequest(
            new DateRange(
                new Date('2022-01-01'),
                new Date('2022-12-01')
            ),
            new Location(39.775379, -86.161407)
        )
    );
    expect(axios.get).toHaveBeenCalled();
    expect(res.data).toEqual(aqiRes);
});