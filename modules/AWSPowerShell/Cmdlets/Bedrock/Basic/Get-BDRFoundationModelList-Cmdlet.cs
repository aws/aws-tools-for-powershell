/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using System.Threading;
using Amazon.Bedrock;
using Amazon.Bedrock.Model;

namespace Amazon.PowerShell.Cmdlets.BDR
{
    /// <summary>
    /// Lists Amazon Bedrock foundation models that you can use. You can filter the results
    /// with the request parameters. For more information, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/foundation-models.html">Foundation
    /// models</a> in the <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/what-is-service.html">Amazon
    /// Bedrock User Guide</a>.
    /// </summary>
    [Cmdlet("Get", "BDRFoundationModelList")]
    [OutputType("Amazon.Bedrock.Model.FoundationModelSummary")]
    [AWSCmdlet("Calls the Amazon Bedrock ListFoundationModels API operation.", Operation = new[] {"ListFoundationModels"}, SelectReturnType = typeof(Amazon.Bedrock.Model.ListFoundationModelsResponse))]
    [AWSCmdletOutput("Amazon.Bedrock.Model.FoundationModelSummary or Amazon.Bedrock.Model.ListFoundationModelsResponse",
        "This cmdlet returns a collection of Amazon.Bedrock.Model.FoundationModelSummary objects.",
        "The service call response (type Amazon.Bedrock.Model.ListFoundationModelsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetBDRFoundationModelListCmdlet : AmazonBedrockClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ByCustomizationType
        /// <summary>
        /// <para>
        /// <para>Return models that support the customization type that you specify. For more information,
        /// see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/custom-models.html">Custom
        /// models</a> in the <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/what-is-service.html">Amazon
        /// Bedrock User Guide</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Bedrock.ModelCustomization")]
        public Amazon.Bedrock.ModelCustomization ByCustomizationType { get; set; }
        #endregion
        
        #region Parameter ByInferenceType
        /// <summary>
        /// <para>
        /// <para>Return models that support the inference type that you specify. For more information,
        /// see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/prov-throughput.html">Provisioned
        /// Throughput</a> in the <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/what-is-service.html">Amazon
        /// Bedrock User Guide</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Bedrock.InferenceType")]
        public Amazon.Bedrock.InferenceType ByInferenceType { get; set; }
        #endregion
        
        #region Parameter ByOutputModality
        /// <summary>
        /// <para>
        /// <para>Return models that support the output modality that you specify.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Bedrock.ModelModality")]
        public Amazon.Bedrock.ModelModality ByOutputModality { get; set; }
        #endregion
        
        #region Parameter ByProvider
        /// <summary>
        /// <para>
        /// <para>Return models belonging to the model provider that you specify.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ByProvider { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ModelSummaries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Bedrock.Model.ListFoundationModelsResponse).
        /// Specifying the name of a property of type Amazon.Bedrock.Model.ListFoundationModelsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ModelSummaries";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Bedrock.Model.ListFoundationModelsResponse, GetBDRFoundationModelListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ByCustomizationType = this.ByCustomizationType;
            context.ByInferenceType = this.ByInferenceType;
            context.ByOutputModality = this.ByOutputModality;
            context.ByProvider = this.ByProvider;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.Bedrock.Model.ListFoundationModelsRequest();
            
            if (cmdletContext.ByCustomizationType != null)
            {
                request.ByCustomizationType = cmdletContext.ByCustomizationType;
            }
            if (cmdletContext.ByInferenceType != null)
            {
                request.ByInferenceType = cmdletContext.ByInferenceType;
            }
            if (cmdletContext.ByOutputModality != null)
            {
                request.ByOutputModality = cmdletContext.ByOutputModality;
            }
            if (cmdletContext.ByProvider != null)
            {
                request.ByProvider = cmdletContext.ByProvider;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Bedrock.Model.ListFoundationModelsResponse CallAWSServiceOperation(IAmazonBedrock client, Amazon.Bedrock.Model.ListFoundationModelsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock", "ListFoundationModels");
            try
            {
                return client.ListFoundationModelsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public Amazon.Bedrock.ModelCustomization ByCustomizationType { get; set; }
            public Amazon.Bedrock.InferenceType ByInferenceType { get; set; }
            public Amazon.Bedrock.ModelModality ByOutputModality { get; set; }
            public System.String ByProvider { get; set; }
            public System.Func<Amazon.Bedrock.Model.ListFoundationModelsResponse, GetBDRFoundationModelListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ModelSummaries;
        }
        
    }
}
