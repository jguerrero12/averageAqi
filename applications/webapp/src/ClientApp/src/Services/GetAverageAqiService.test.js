import GetAverageAqiService from './GetAverageAqiService';
import GetAverageAqiRequest from '../Models/GetAverageAqiRequest';
import DateRange from '../Models/DateRange';
import Location from '../Models/Location';
jest.mock('axios');
import axios from 'axios';

const aqiRes = '14';
axios.post.mockResolvedValue({ data: aqiRes });

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
    expect(axios.post).toHaveBeenCalled();
    expect(res.data).toEqual(aqiRes);
});