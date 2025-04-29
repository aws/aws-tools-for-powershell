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
using Amazon.TrustedAdvisor;
using Amazon.TrustedAdvisor.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.TA
{
    /// <summary>
    /// Get a specific recommendation within an AWS Organizations organization. This API supports
    /// only prioritized recommendations.
    /// </summary>
    [Cmdlet("Get", "TAOrganizationRecommendation")]
    [OutputType("Amazon.TrustedAdvisor.Model.OrganizationRecommendation")]
    [AWSCmdlet("Calls the Trusted Advisor GetOrganizationRecommendation API operation.", Operation = new[] {"GetOrganizationRecommendation"}, SelectReturnType = typeof(Amazon.TrustedAdvisor.Model.GetOrganizationRecommendationResponse))]
    [AWSCmdletOutput("Amazon.TrustedAdvisor.Model.OrganizationRecommendation or Amazon.TrustedAdvisor.Model.GetOrganizationRecommendationResponse",
        "This cmdlet returns an Amazon.TrustedAdvisor.Model.OrganizationRecommendation object.",
        "The service call response (type Amazon.TrustedAdvisor.Model.GetOrganizationRecommendationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetTAOrganizationRecommendationCmdlet : AmazonTrustedAdvisorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter OrganizationRecommendationIdentifier
        /// <summary>
        /// <para>
        /// <para>The Recommendation identifier</para>
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
        public System.String OrganizationRecommendationIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'OrganizationRecommendation'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.TrustedAdvisor.Model.GetOrganizationRecommendationResponse).
        /// Specifying the name of a property of type Amazon.TrustedAdvisor.Model.GetOrganizationRecommendationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "OrganizationRecommendation";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.TrustedAdvisor.Model.GetOrganizationRecommendationResponse, GetTAOrganizationRecommendationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.OrganizationRecommendationIdentifier = this.OrganizationRecommendationIdentifier;
            #if MODULAR
            if (this.OrganizationRecommendationIdentifier == null && ParameterWasBound(nameof(this.OrganizationRecommendationIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter OrganizationRecommendationIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.TrustedAdvisor.Model.GetOrganizationRecommendationRequest();
            
            if (cmdletContext.OrganizationRecommendationIdentifier != null)
            {
                request.OrganizationRecommendationIdentifier = cmdletContext.OrganizationRecommendationIdentifier;
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
        
        private Amazon.TrustedAdvisor.Model.GetOrganizationRecommendationResponse CallAWSServiceOperation(IAmazonTrustedAdvisor client, Amazon.TrustedAdvisor.Model.GetOrganizationRecommendationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Trusted Advisor", "GetOrganizationRecommendation");
            try
            {
                return client.GetOrganizationRecommendationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String OrganizationRecommendationIdentifier { get; set; }
            public System.Func<Amazon.TrustedAdvisor.Model.GetOrganizationRecommendationResponse, GetTAOrganizationRecommendationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.OrganizationRecommendation;
        }
        
    }
}
