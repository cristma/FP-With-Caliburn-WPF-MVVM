using AE.Common;

namespace AE.FlightProcedures.Domain.Evaluation.Deviations.Factories
{
    internal interface IDeviationFactory
    {
        Deviation CreateDeviation(string message, DeviationSeverityTypes severity);
    }
}