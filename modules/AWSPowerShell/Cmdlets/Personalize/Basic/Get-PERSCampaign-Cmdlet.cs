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
using Amazon.Personalize;
using Amazon.Personalize.Model;

namespace Amazon.PowerShell.Cmdlets.PERS
{
    /// <summary>
    /// Describes the given campaign, including its status.
    /// 
    ///  
    /// <para>
    /// A campaign can be in one of the following states:
    /// </para><ul><li><para>
    /// CREATE PENDING &gt; CREATE IN_PROGRESS &gt; ACTIVE -or- CREATE FAILED
    /// </para></li><li><para>
    /// DELETE PENDING &gt; DELETE IN_PROGRESS
    /// </para></li></ul><para>
    /// When the <c>status</c> is <c>CREATE FAILED</c>, the response includes the <c>failureReason</c>
    /// key, which describes why.
    /// </para><para>
    /// For more information on campaigns, see <a href="https://docs.aws.amazon.com/personalize/latest/dg/API_CreateCampaign.html">CreateCampaign</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "PERSCampaign")]
    [OutputType("Amazon.Personalize.Model.Campaign")]
    [AWSCmdlet("Calls the AWS Personalize DescribeCampaign API operation.", Operation = new[] {"DescribeCampaign"}, SelectReturnType = typeof(Amazon.Personalize.Model.DescribeCampaignResponse))]
    [AWSCmdletOutput("Amazon.Personalize.Model.Campaign or Amazon.Personalize.Model.DescribeCampaignResponse",
        "This cmdlet returns an Amazon.Personalize.Model.Campaign object.",
        "The service call response (type Amazon.Personalize.Model.DescribeCampaignResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetPERSCampaignCmdlet : AmazonPersonalizeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CampaignArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the campaign.</para>
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
        public System.String CampaignArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Campaign'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Personalize.Model.DescribeCampaignResponse).
        /// Specifying the name of a property of type Amazon.Personalize.Model.DescribeCampaignResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Campaign";
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
                context.Select = CreateSelectDelegate<Amazon.Personalize.Model.DescribeCampaignResponse, GetPERSCampaignCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CampaignArn = this.CampaignArn;
            #if MODULAR
            if (this.CampaignArn == null && ParameterWasBound(nameof(this.CampaignArn)))
            {
                WriteWarning("You are passing $null as a value for parameter CampaignArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Personalize.Model.DescribeCampaignRequest();
            
            if (cmdletContext.CampaignArn != null)
            {
                request.CampaignArn = cmdletContext.CampaignArn;
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
        
        private Amazon.Personalize.Model.DescribeCampaignResponse CallAWSServiceOperation(IAmazonPersonalize client, Amazon.Personalize.Model.DescribeCampaignRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Personalize", "DescribeCampaign");
            try
            {
                return client.DescribeCampaignAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String CampaignArn { get; set; }
            public System.Func<Amazon.Personalize.Model.DescribeCampaignResponse, GetPERSCampaignCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Campaign;
        }
        
    }
}
