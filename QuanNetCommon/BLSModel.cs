using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanNetCommon
{
    public class BLSModel
    {
        //S：标的资产现价
        //X：执行价
        //r：无风险利率
        //q：连续分红率，Cost of Carry = r-q
        //sigma：波动率
        //t：距离到期时间
        //PutCall：Call/Put
        public enum EPutCall
        {
            Call,
            Put,
        }

        public EPutCall PutCall
        {
            get;
            set;
        }

        public double GetOptionValue(double S, double X, double q, double r,
                                     double sigma, double t, EPutCall PutCall)
        {
            double t_sqrt = Math.Sqrt(t);
            double sigma2 = sigma * sigma;
            double d1 = (Math.Log(S / X) + (r - q + sigma2 * 0.5) * t) / (t_sqrt * sigma);
            double d2 = d1 - t_sqrt * sigma;

            switch (PutCall)
            {
                case EPutCall.Call:
                    return S * Math.Exp(-q * t) * N(d1) - X * Math.Exp(-r * t) * N(d2);
                case EPutCall.Put:
                    return -S * Math.Exp(-q * t) * N(-d1) + X * Math.Exp(-r * t) * N(-d2);
                default:
                    return 0.0;
            }
        }

        public double GetDelta(double S, double X, double q, double r,
                                     double sigma, double t, EPutCall PutCall)
        {
            double t_sqrt = Math.Sqrt(t);
            double sigma2 = sigma * sigma;
            double d1 = (Math.Log(S / X) + (r - q + sigma2 * 0.5) * t) / (t_sqrt * sigma);

            switch (PutCall)
            {
                case EPutCall.Call:
                    return Math.Exp(-q * t) * N(d1);
                case EPutCall.Put:
                    return -Math.Exp(-q * t) * N(-d1);
                default:
                    return 0.0;
            }
        }

        public double GetGamma(double S, double X, double q, double r,
                                     double sigma, double t, EPutCall PutCall)
        {
            double t_sqrt = Math.Sqrt(t);
            double sigma2 = sigma * sigma;
            double d1 = (Math.Log(S / X) + (r - q + sigma2 * 0.5) * t) / (t_sqrt * sigma);

            return Math.Exp(-q * t) * n(d1) / S / t_sqrt / sigma;
        }

        public double GetTheta(double S, double X, double q, double r,
                                     double sigma, double t, EPutCall PutCall)
        {
            double t_sqrt = Math.Sqrt(t);
            double sigma2 = sigma * sigma;
            double d1 = (Math.Log(S / X) + (r - q + sigma2 * 0.5) * t) / (t_sqrt * sigma);
            double d2 = d1 - t_sqrt * sigma;

            double part1 = S * sigma * Math.Exp(-q * t) * n(d1) / 2.0 / t_sqrt;
            double part2 = -q * S * Math.Exp(-q * t);
            double part3 = r * X * Math.Exp(-r * t);
            switch (PutCall)
            {
                case EPutCall.Call:
                    return -part1 - part2 * N(d1) - part3 * N(d2);
                case EPutCall.Put:
                    return -part1 + part2 * N(-d1) + part3 * N(-d2);
                default:
                    return 0.0;
            }
        }

        public double GetVega(double S, double X, double q, double r,
                                     double sigma, double t, EPutCall PutCall)
        {
            double t_sqrt = Math.Sqrt(t);
            double sigma2 = sigma * sigma;
            double d1 = (Math.Log(S / X) + (r - q + sigma2 * 0.5) * t) / (t_sqrt * sigma);

            return S * Math.Exp(-q * t) * n(d1) * t_sqrt;
        }

        public double GetRho(double S, double X, double q, double r,
                                     double sigma, double t, EPutCall PutCall)
        {
            double t_sqrt = Math.Sqrt(t);
            double sigma2 = sigma * sigma;
            double d1 = (Math.Log(S / X) + (r - q + sigma2 * 0.5) * t) / (t_sqrt * sigma);
            double d2 = d1 - t_sqrt * sigma;

            switch (PutCall)
            {
                case EPutCall.Call:
                    return t * X * Math.Exp(-r * t) * N(d2);
                case EPutCall.Put:
                    return -t * X * Math.Exp(-r * t) * N(-d2);
                default:
                    return 0.0;
            }
        }

        public double GetImpliedVol(double S, double X, double q, double r, double optionPrice,
                                    double t, EPutCall PutCall, double accuracy, int maxIterations)
        {
            if (optionPrice < 0.99 * (S - X * Math.Exp(-r * t)))
                return 0.0;
            double t_sqrt = Math.Sqrt(t);
            double sigma = optionPrice / S / 0.398 / t_sqrt;
            for (int i = 0; i < maxIterations; i++)
            {
                double price = GetOptionValue(S, X, q, r, sigma, t, PutCall);
                double diff = optionPrice - price;
                if (Math.Abs(diff) < accuracy)
                    return sigma;
                double vega = GetVega(S, X, q, r, sigma, t, PutCall);
                sigma = sigma + diff / vega;
            }
            return sigma;
        }

        public double N(double d)
        {
            double b1 = 0.31938153;
            double b2 = -0.356563782;
            double b3 = 1.781477937;
            double b4 = -1.821255978;
            double b5 = 1.330274429;
            double p = 0.2316419;
            double c2 = 0.3989423;

            double a = Math.Abs(d);
            double t = 1.0 / (1.0 + a * p);
            double b = c2 * Math.Exp((-d) * (d * 0.5));
            double n = ((((b5 * t + b4) * t + b3) * t + b2) * t + b1) * t;
            n = 1.0 - b * n;
            if (d < 0)
                n = 1.0 - n;
            return n;
        }

        public double n(double d)
        {
            return 1.0 / Math.Sqrt(2.0 * Math.PI) * Math.Exp(-d * d * 0.5);
        }
    }
    
}
