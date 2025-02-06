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
using Amazon.XRay;
using Amazon.XRay.Model;

namespace Amazon.PowerShell.Cmdlets.XR
{
    /// <summary>
    /// Requests a sampling quota for rules that the service is using to sample requests.
    /// </summary>
    [Cmdlet("Get", "XRSamplingTarget")]
    [OutputType("Amazon.XRay.Model.GetSamplingTargetsResponse")]
    [AWSCmdlet("Calls the AWS X-Ray GetSamplingTargets API operation.", Operation = new[] {"GetSamplingTargets"}, SelectReturnType = typeof(Amazon.XRay.Model.GetSamplingTargetsResponse))]
    [AWSCmdletOutput("Amazon.XRay.Model.GetSamplingTargetsResponse",
        "This cmdlet returns an Amazon.XRay.Model.GetSamplingTargetsResponse object containing multiple properties."
    )]
    public partial class GetXRSamplingTargetCmdlet : AmazonXRayClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter SamplingStatisticsDocument
        /// <summary>
        /// <para>
        /// <para>Information about rules that the service is using to sample requests.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("SamplingStatisticsDocuments")]
        public Amazon.XRay.Model.SamplingStatisticsDocument[] SamplingStatisticsDocument { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.XRay.Model.GetSamplingTargetsResponse).
        /// Specifying the name of a property of type Amazon.XRay.Model.GetSamplingTargetsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.XRay.Model.GetSamplingTargetsResponse, GetXRSamplingTargetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.SamplingStatisticsDocument != null)
            {
                context.SamplingStatisticsDocument = new List<Amazon.XRay.Model.SamplingStatisticsDocument>(this.SamplingStatisticsDocument);
            }
            #if MODULAR
            if (this.SamplingStatisticsDocument == null && ParameterWasBound(nameof(this.SamplingStatisticsDocument)))
            {
                WriteWarning("You are passing $null as a value for parameter SamplingStatisticsDocument which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.XRay.Model.GetSamplingTargetsRequest();
            
            if (cmdletContext.SamplingStatisticsDocument != null)
            {
                request.SamplingStatisticsDocuments = cmdletContext.SamplingStatisticsDocument;
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
        
        private Amazon.XRay.Model.GetSamplingTargetsResponse CallAWSServiceOperation(IAmazonXRay client, Amazon.XRay.Model.GetSamplingTargetsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS X-Ray", "GetSamplingTargets");
            try
            {
                #if DESKTOP
                return client.GetSamplingTargets(request);
                #elif CORECLR
                return client.GetSamplingTargetsAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
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
            public List<Amazon.XRay.Model.SamplingStatisticsDocument> SamplingStatisticsDocument { get; set; }
            public System.Func<Amazon.XRay.Model.GetSamplingTargetsResponse, GetXRSamplingTargetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
