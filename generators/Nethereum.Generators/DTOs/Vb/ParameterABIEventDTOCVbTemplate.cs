using System;
using System.Linq;
using Nethereum.Generators.Core;
using Nethereum.Generators.Model;

namespace Nethereum.Generators.DTOs
{
    public class ParameterABIEventDTOVbTemplate
    {
        private ParameterABIModelTypeMap parameterAbiModelTypeMap;
        private Utils utils;

        public ParameterABIEventDTOVbTemplate()
        {
            var typeMapper = new ABITypeToVBType();
            parameterAbiModelTypeMap = new ParameterABIModelTypeMap(typeMapper, CodeGenLanguage.Vb);
            utils = new Utils();
        }

        public string GenerateAllProperties(ParameterABI[] parameters)
        {
            return string.Join(Environment.NewLine, parameters.Select(GenerateProperty));
        }

        public string GenerateProperty(ParameterABI parameter)
        {
            var parameterModel = new ParameterABIModel(parameter, CodeGenLanguage.Vb);
            return
                $@"{SpaceUtils.Two___Tabs}<[Parameter](""{parameter.Type}"", ""{@parameter.Name}"", {parameter.Order}, {utils.GetBooleanAsString(parameter.Indexed)})>
{SpaceUtils.Two___Tabs}Public Overridable Property [{parameterModel.GetPropertyName()}] As {parameterAbiModelTypeMap.GetParameterDotNetOutputMapType(parameter)}";
        }
    }
}