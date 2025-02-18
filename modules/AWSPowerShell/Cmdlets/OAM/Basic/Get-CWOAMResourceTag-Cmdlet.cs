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
using Amazon.OAM;
using Amazon.OAM.Model;

namespace Amazon.PowerShell.Cmdlets.CWOAM
{
    /// <summary>
    /// Displays the tags associated with a resource. Both sinks and links support tagging.
    /// </summary>
    [Cmdlet("Get", "CWOAMResourceTag")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the CloudWatch Observability Access Manager ListTagsForResource API operation.", Operation = new[] {"ListTagsForResource"}, SelectReturnType = typeof(Amazon.OAM.Model.ListTagsForResourceResponse))]
    [AWSCmdletOutput("System.String or Amazon.OAM.Model.ListTagsForResourceResponse",
        "This cmdlet returns a collection of System.String objects.",
        "The service call response (type Amazon.OAM.Model.ListTagsForResourceResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCWOAMResourceTagCmdlet : AmazonOAMClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ResourceArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the resource that you want to view tags for.</para><para>The ARN format of a sink is <c>arn:aws:oam:<i>Region</i>:<i>account-id</i>:sink/<i>sink-id</i></c></para><para>The ARN format of a link is <c>arn:aws:oam:<i>Region</i>:<i>account-id</i>:link/<i>link-id</i></c></para><para>For more information about ARN format, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/logs/iam-access-control-overview-cwl.html">CloudWatch
        /// Logs resources and operations</a>.</para><important><para>Unlike tagging permissions in other Amazon Web Services services, to retrieve the
        /// list of tags for links or sinks you must have the <c>oam:RequestTag</c> permission.
        /// The <c>aws:ReguestTag</c> permission does not allow you to tag and untag links and
        /// sinks.</para></important>
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
        public System.String ResourceArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Tags'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.OAM.Model.ListTagsForResourceResponse).
        /// Specifying the name of a property of type Amazon.OAM.Model.ListTagsForResourceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Tags";
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
                context.Select = CreateSelectDelegate<Amazon.OAM.Model.ListTagsForResourceResponse, GetCWOAMResourceTagCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ResourceArn = this.ResourceArn;
            #if MODULAR
            if (this.ResourceArn == null && ParameterWasBound(nameof(this.ResourceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.OAM.Model.ListTagsForResourceRequest();
            
            if (cmdletContext.ResourceArn != null)
            {
                request.ResourceArn = cmdletContext.ResourceArn;
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
        
        private Amazon.OAM.Model.ListTagsForResourceResponse CallAWSServiceOperation(IAmazonOAM client, Amazon.OAM.Model.ListTagsForResourceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "CloudWatch Observability Access Manager", "ListTagsForResource");
            try
            {
                return client.ListTagsForResourceAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ResourceArn { get; set; }
            public System.Func<Amazon.OAM.Model.ListTagsForResourceResponse, GetCWOAMResourceTagCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Tags;
        }
        
    }
}
