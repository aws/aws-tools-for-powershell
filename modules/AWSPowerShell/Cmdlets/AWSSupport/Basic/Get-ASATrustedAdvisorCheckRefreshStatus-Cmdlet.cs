/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.AWSSupport;
using Amazon.AWSSupport.Model;

namespace Amazon.PowerShell.Cmdlets.ASA
{
    /// <summary>
    /// Returns the refresh status of the Trusted Advisor checks that have the specified check
    /// IDs. You can get the check IDs by calling the <a>DescribeTrustedAdvisorChecks</a>
    /// operation.
    /// 
    ///  
    /// <para>
    /// Some checks are refreshed automatically, and you can't return their refresh statuses
    /// by using the <c>DescribeTrustedAdvisorCheckRefreshStatuses</c> operation. If you call
    /// this operation for these checks, you might see an <c>InvalidParameterValue</c> error.
    /// </para><note><ul><li><para>
    /// You must have a Business, Enterprise On-Ramp, or Enterprise Support plan to use the
    /// Amazon Web Services Support API. 
    /// </para></li><li><para>
    /// If you call the Amazon Web Services Support API from an account that doesn't have
    /// a Business, Enterprise On-Ramp, or Enterprise Support plan, the <c>SubscriptionRequiredException</c>
    /// error message appears. For information about changing your support plan, see <a href="http://aws.amazon.com/premiumsupport/">Amazon
    /// Web Services Support</a>.
    /// </para></li></ul></note><para>
    /// To call the Trusted Advisor operations in the Amazon Web Services Support API, you
    /// must use the US East (N. Virginia) endpoint. Currently, the US West (Oregon) and Europe
    /// (Ireland) endpoints don't support the Trusted Advisor operations. For more information,
    /// see <a href="https://docs.aws.amazon.com/awssupport/latest/user/about-support-api.html#endpoint">About
    /// the Amazon Web Services Support API</a> in the <i>Amazon Web Services Support User
    /// Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "ASATrustedAdvisorCheckRefreshStatus")]
    [OutputType("Amazon.AWSSupport.Model.TrustedAdvisorCheckRefreshStatus")]
    [AWSCmdlet("Calls the AWS Support DescribeTrustedAdvisorCheckRefreshStatuses API operation.", Operation = new[] {"DescribeTrustedAdvisorCheckRefreshStatuses"}, SelectReturnType = typeof(Amazon.AWSSupport.Model.DescribeTrustedAdvisorCheckRefreshStatusesResponse), LegacyAlias="Get-ASATrustedAdvisorCheckRefreshStatuses")]
    [AWSCmdletOutput("Amazon.AWSSupport.Model.TrustedAdvisorCheckRefreshStatus or Amazon.AWSSupport.Model.DescribeTrustedAdvisorCheckRefreshStatusesResponse",
        "This cmdlet returns a collection of Amazon.AWSSupport.Model.TrustedAdvisorCheckRefreshStatus objects.",
        "The service call response (type Amazon.AWSSupport.Model.DescribeTrustedAdvisorCheckRefreshStatusesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetASATrustedAdvisorCheckRefreshStatusCmdlet : AmazonAWSSupportClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CheckId
        /// <summary>
        /// <para>
        /// <para>The IDs of the Trusted Advisor checks to get the status.</para><note><para>If you specify the check ID of a check that is automatically refreshed, you might
        /// see an <c>InvalidParameterValue</c> error.</para></note>
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
        [Alias("CheckIds")]
        public System.String[] CheckId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Statuses'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AWSSupport.Model.DescribeTrustedAdvisorCheckRefreshStatusesResponse).
        /// Specifying the name of a property of type Amazon.AWSSupport.Model.DescribeTrustedAdvisorCheckRefreshStatusesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Statuses";
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
                context.Select = CreateSelectDelegate<Amazon.AWSSupport.Model.DescribeTrustedAdvisorCheckRefreshStatusesResponse, GetASATrustedAdvisorCheckRefreshStatusCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.CheckId != null)
            {
                context.CheckId = new List<System.String>(this.CheckId);
            }
            #if MODULAR
            if (this.CheckId == null && ParameterWasBound(nameof(this.CheckId)))
            {
                WriteWarning("You are passing $null as a value for parameter CheckId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AWSSupport.Model.DescribeTrustedAdvisorCheckRefreshStatusesRequest();
            
            if (cmdletContext.CheckId != null)
            {
                request.CheckIds = cmdletContext.CheckId;
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
        
        private Amazon.AWSSupport.Model.DescribeTrustedAdvisorCheckRefreshStatusesResponse CallAWSServiceOperation(IAmazonAWSSupport client, Amazon.AWSSupport.Model.DescribeTrustedAdvisorCheckRefreshStatusesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Support", "DescribeTrustedAdvisorCheckRefreshStatuses");
            try
            {
                #if DESKTOP
                return client.DescribeTrustedAdvisorCheckRefreshStatuses(request);
                #elif CORECLR
                return client.DescribeTrustedAdvisorCheckRefreshStatusesAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> CheckId { get; set; }
            public System.Func<Amazon.AWSSupport.Model.DescribeTrustedAdvisorCheckRefreshStatusesResponse, GetASATrustedAdvisorCheckRefreshStatusCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Statuses;
        }
        
    }
}
