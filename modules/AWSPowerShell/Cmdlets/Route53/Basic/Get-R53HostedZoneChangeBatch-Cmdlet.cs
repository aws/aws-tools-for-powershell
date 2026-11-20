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
using Amazon.Route53;
using Amazon.Route53.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.R53
{
    /// <summary>
    /// Returns one change batch from the change history of a hosted zone, including every
    /// change in the batch. Each resource record set is in the same form that <c>ListResourceRecordSets</c>
    /// returns. For example, the name is in lowercase and ends with a dot. For an <c>UPSERT</c>
    /// or a <c>DELETE</c>, the response doesn't contain the values that the resource record
    /// set had before the change.
    /// 
    ///  
    /// <para>
    /// If the change batch isn't in the hosted zone's retained change history, for example
    /// because it's in another hosted zone, it expired, or it's from before <c>RetentionStartsAt</c>,
    /// Route 53 returns a <c>NoSuchChange</c> error. If Change History isn't turned on for
    /// the hosted zone, Route 53 returns a <c>FeatureNotEnabled</c> error.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "R53HostedZoneChangeBatch")]
    [OutputType("Amazon.Route53.Model.GetHostedZoneChangeBatchResponse")]
    [AWSCmdlet("Calls the Amazon Route 53 GetHostedZoneChangeBatch API operation.", Operation = new[] {"GetHostedZoneChangeBatch"}, SelectReturnType = typeof(Amazon.Route53.Model.GetHostedZoneChangeBatchResponse))]
    [AWSCmdletOutput("Amazon.Route53.Model.GetHostedZoneChangeBatchResponse",
        "This cmdlet returns an Amazon.Route53.Model.GetHostedZoneChangeBatchResponse object containing multiple properties."
    )]
    public partial class GetR53HostedZoneChangeBatchCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ChangeId
        /// <summary>
        /// <para>
        /// <para>The ID of the change batch that you want to get. This is the ID that <c>ChangeResourceRecordSets</c>
        /// returns in <c>ChangeInfo/Id</c>. You can specify the ID with or without the <c>/change/</c>
        /// prefix.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ChangeId { get; set; }
        #endregion
        
        #region Parameter HostedZoneId
        /// <summary>
        /// <para>
        /// <para>The ID of the hosted zone that contains the change batch.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String HostedZoneId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53.Model.GetHostedZoneChangeBatchResponse).
        /// Specifying the name of a property of type Amazon.Route53.Model.GetHostedZoneChangeBatchResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
                context.Select = CreateSelectDelegate<Amazon.Route53.Model.GetHostedZoneChangeBatchResponse, GetR53HostedZoneChangeBatchCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.HostedZoneId = this.HostedZoneId;
            #if MODULAR
            if (this.HostedZoneId == null && ParameterWasBound(nameof(this.HostedZoneId)))
            {
                WriteWarning("You are passing $null as a value for parameter HostedZoneId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ChangeId = this.ChangeId;
            #if MODULAR
            if (this.ChangeId == null && ParameterWasBound(nameof(this.ChangeId)))
            {
                WriteWarning("You are passing $null as a value for parameter ChangeId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Route53.Model.GetHostedZoneChangeBatchRequest();
            
            if (cmdletContext.HostedZoneId != null)
            {
                request.HostedZoneId = cmdletContext.HostedZoneId;
            }
            if (cmdletContext.ChangeId != null)
            {
                request.ChangeId = cmdletContext.ChangeId;
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
        
        private Amazon.Route53.Model.GetHostedZoneChangeBatchResponse CallAWSServiceOperation(IAmazonRoute53 client, Amazon.Route53.Model.GetHostedZoneChangeBatchRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53", "GetHostedZoneChangeBatch");
            try
            {
                return client.GetHostedZoneChangeBatchAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String HostedZoneId { get; set; }
            public System.String ChangeId { get; set; }
            public System.Func<Amazon.Route53.Model.GetHostedZoneChangeBatchResponse, GetR53HostedZoneChangeBatchCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
