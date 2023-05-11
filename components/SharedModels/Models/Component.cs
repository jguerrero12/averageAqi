namespace SharedModels
{
    public class Components
    {
        public Guid Id { get; set; }
        /// <summary>
        /// Сoncentration of CO(Carbon monoxide), μg/m3
        /// </summary>
        public double co {get;set;} 
        /// <summary>
        /// Сoncentration of NO (Nitrogen monoxide), μg/m3
        /// </summary>
        public double no {get;set;} 
        /// <summary>
        /// Сoncentration of NO2 (Nitrogen dioxide), μg/m3
        /// </summary>
        public double no2 {get;set;} 
        /// <summary>
        /// Сoncentration of O3 (Ozone), μg/m3
        /// </summary>
        public double o3 {get;set;} 
        /// <summary>
        /// Сoncentration of SO2 (Sulphur dioxide), μg/m3
        /// </summary>
        public double so2 {get;set;} 
        /// <summary>
        /// Сoncentration of PM2.5 (Fine particles matter), μg/m3
        /// </summary>
        public double pm2_5 {get;set;} 
        /// <summary>
        /// Сoncentration of PM10 (Coarse particulate matter), μg/m3
        /// </summary>
        public double pm10 {get;set;} 
        /// <summary>
        /// Сoncentration of NH3 (Ammonia), μg/m3
        /// </summary>
        public double nh3 {get;set;} 
    }
}