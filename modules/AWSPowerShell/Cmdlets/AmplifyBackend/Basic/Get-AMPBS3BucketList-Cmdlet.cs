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
using Amazon.AmplifyBackend;
using Amazon.AmplifyBackend.Model;

namespace Amazon.PowerShell.Cmdlets.AMPB
{
    /// <summary>
    /// The list of S3 buckets in your account.
    /// </summary>
    [Cmdlet("Get", "AMPBS3BucketList")]
    [OutputType("Amazon.AmplifyBackend.Model.S3BucketInfo")]
    [AWSCmdlet("Calls the Amplify Backend ListS3Buckets API operation.", Operation = new[] {"ListS3Buckets"}, SelectReturnType = typeof(Amazon.AmplifyBackend.Model.ListS3BucketsResponse))]
    [AWSCmdletOutput("Amazon.AmplifyBackend.Model.S3BucketInfo or Amazon.AmplifyBackend.Model.ListS3BucketsResponse",
        "This cmdlet returns a collection of Amazon.AmplifyBackend.Model.S3BucketInfo objects.",
        "The service call response (type Amazon.AmplifyBackend.Model.ListS3BucketsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetAMPBS3BucketListCmdlet : AmazonAmplifyBackendClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>Reserved for future use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Buckets'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AmplifyBackend.Model.ListS3BucketsResponse).
        /// Specifying the name of a property of type Amazon.AmplifyBackend.Model.ListS3BucketsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Buckets";
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
                context.Select = CreateSelectDelegate<Amazon.AmplifyBackend.Model.ListS3BucketsResponse, GetAMPBS3BucketListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
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
            var request = new Amazon.AmplifyBackend.Model.ListS3BucketsRequest();
            
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
        
        private Amazon.AmplifyBackend.Model.ListS3BucketsResponse CallAWSServiceOperation(IAmazonAmplifyBackend client, Amazon.AmplifyBackend.Model.ListS3BucketsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amplify Backend", "ListS3Buckets");
            try
            {
                return client.ListS3BucketsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String NextToken { get; set; }
            public System.Func<Amazon.AmplifyBackend.Model.ListS3BucketsResponse, GetAMPBS3BucketListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Buckets;
        }
        
    }
}
