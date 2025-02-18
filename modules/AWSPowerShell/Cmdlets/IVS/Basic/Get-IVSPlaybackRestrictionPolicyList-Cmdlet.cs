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
using Amazon.IVS;
using Amazon.IVS.Model;

namespace Amazon.PowerShell.Cmdlets.IVS
{
    /// <summary>
    /// Gets summary information about playback restriction policies.
    /// </summary>
    [Cmdlet("Get", "IVSPlaybackRestrictionPolicyList")]
    [OutputType("Amazon.IVS.Model.PlaybackRestrictionPolicySummary")]
    [AWSCmdlet("Calls the Amazon Interactive Video Service ListPlaybackRestrictionPolicies API operation.", Operation = new[] {"ListPlaybackRestrictionPolicies"}, SelectReturnType = typeof(Amazon.IVS.Model.ListPlaybackRestrictionPoliciesResponse))]
    [AWSCmdletOutput("Amazon.IVS.Model.PlaybackRestrictionPolicySummary or Amazon.IVS.Model.ListPlaybackRestrictionPoliciesResponse",
        "This cmdlet returns a collection of Amazon.IVS.Model.PlaybackRestrictionPolicySummary objects.",
        "The service call response (type Amazon.IVS.Model.ListPlaybackRestrictionPoliciesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetIVSPlaybackRestrictionPolicyListCmdlet : AmazonIVSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>Maximum number of policies to return. Default: 1.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The first policy to retrieve. This is used for pagination; see the <c>nextToken</c>
        /// response field.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PlaybackRestrictionPolicies'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IVS.Model.ListPlaybackRestrictionPoliciesResponse).
        /// Specifying the name of a property of type Amazon.IVS.Model.ListPlaybackRestrictionPoliciesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PlaybackRestrictionPolicies";
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
                context.Select = CreateSelectDelegate<Amazon.IVS.Model.ListPlaybackRestrictionPoliciesResponse, GetIVSPlaybackRestrictionPolicyListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            
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
            var request = new Amazon.IVS.Model.ListPlaybackRestrictionPoliciesRequest();
            
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
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
        
        private Amazon.IVS.Model.ListPlaybackRestrictionPoliciesResponse CallAWSServiceOperation(IAmazonIVS client, Amazon.IVS.Model.ListPlaybackRestrictionPoliciesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Interactive Video Service", "ListPlaybackRestrictionPolicies");
            try
            {
                return client.ListPlaybackRestrictionPoliciesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.IVS.Model.ListPlaybackRestrictionPoliciesResponse, GetIVSPlaybackRestrictionPolicyListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PlaybackRestrictionPolicies;
        }
        
    }
}
