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
using Amazon.ComprehendMedical;
using Amazon.ComprehendMedical.Model;

namespace Amazon.PowerShell.Cmdlets.CMPM
{
    /// <summary>
    /// Gets the properties associated with an InferSNOMEDCT job. Use this operation to get
    /// the status of an inference job.
    /// </summary>
    [Cmdlet("Get", "CMPMSNOMEDCTInferenceJob")]
    [OutputType("Amazon.ComprehendMedical.Model.ComprehendMedicalAsyncJobProperties")]
    [AWSCmdlet("Calls the AWS Comprehend Medical DescribeSNOMEDCTInferenceJob API operation.", Operation = new[] {"DescribeSNOMEDCTInferenceJob"}, SelectReturnType = typeof(Amazon.ComprehendMedical.Model.DescribeSNOMEDCTInferenceJobResponse))]
    [AWSCmdletOutput("Amazon.ComprehendMedical.Model.ComprehendMedicalAsyncJobProperties or Amazon.ComprehendMedical.Model.DescribeSNOMEDCTInferenceJobResponse",
        "This cmdlet returns an Amazon.ComprehendMedical.Model.ComprehendMedicalAsyncJobProperties object.",
        "The service call response (type Amazon.ComprehendMedical.Model.DescribeSNOMEDCTInferenceJobResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCMPMSNOMEDCTInferenceJobCmdlet : AmazonComprehendMedicalClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter JobId
        /// <summary>
        /// <para>
        /// <para> The identifier that Amazon Comprehend Medical generated for the job. The StartSNOMEDCTInferenceJob
        /// operation returns this identifier in its response. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String JobId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ComprehendMedicalAsyncJobProperties'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ComprehendMedical.Model.DescribeSNOMEDCTInferenceJobResponse).
        /// Specifying the name of a property of type Amazon.ComprehendMedical.Model.DescribeSNOMEDCTInferenceJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ComprehendMedicalAsyncJobProperties";
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
                context.Select = CreateSelectDelegate<Amazon.ComprehendMedical.Model.DescribeSNOMEDCTInferenceJobResponse, GetCMPMSNOMEDCTInferenceJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.JobId = this.JobId;
            #if MODULAR
            if (this.JobId == null && ParameterWasBound(nameof(this.JobId)))
            {
                WriteWarning("You are passing $null as a value for parameter JobId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.ComprehendMedical.Model.DescribeSNOMEDCTInferenceJobRequest();
            
            if (cmdletContext.JobId != null)
            {
                request.JobId = cmdletContext.JobId;
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
        
        private Amazon.ComprehendMedical.Model.DescribeSNOMEDCTInferenceJobResponse CallAWSServiceOperation(IAmazonComprehendMedical client, Amazon.ComprehendMedical.Model.DescribeSNOMEDCTInferenceJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Comprehend Medical", "DescribeSNOMEDCTInferenceJob");
            try
            {
                return client.DescribeSNOMEDCTInferenceJobAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String JobId { get; set; }
            public System.Func<Amazon.ComprehendMedical.Model.DescribeSNOMEDCTInferenceJobResponse, GetCMPMSNOMEDCTInferenceJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ComprehendMedicalAsyncJobProperties;
        }
        
    }
}
