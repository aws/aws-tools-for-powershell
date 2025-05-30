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
using Amazon.ElasticMapReduce;
using Amazon.ElasticMapReduce.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EMR
{
    /// <summary>
    /// The presigned URL properties for the cluster's application user interface.
    /// </summary>
    [Cmdlet("Get", "EMRPersistentAppUIPresignedURL")]
    [OutputType("Amazon.ElasticMapReduce.Model.GetPersistentAppUIPresignedURLResponse")]
    [AWSCmdlet("Calls the Amazon Elastic MapReduce GetPersistentAppUIPresignedURL API operation.", Operation = new[] {"GetPersistentAppUIPresignedURL"}, SelectReturnType = typeof(Amazon.ElasticMapReduce.Model.GetPersistentAppUIPresignedURLResponse))]
    [AWSCmdletOutput("Amazon.ElasticMapReduce.Model.GetPersistentAppUIPresignedURLResponse",
        "This cmdlet returns an Amazon.ElasticMapReduce.Model.GetPersistentAppUIPresignedURLResponse object containing multiple properties."
    )]
    public partial class GetEMRPersistentAppUIPresignedURLCmdlet : AmazonElasticMapReduceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ApplicationId
        /// <summary>
        /// <para>
        /// <para>The application ID associated with the presigned URL.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ApplicationId { get; set; }
        #endregion
        
        #region Parameter AuthProxyCall
        /// <summary>
        /// <para>
        /// <para>A boolean that represents if the caller is an authentication proxy call.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AuthProxyCall { get; set; }
        #endregion
        
        #region Parameter ExecutionRoleArn
        /// <summary>
        /// <para>
        /// <para>The execution role ARN associated with the presigned URL.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExecutionRoleArn { get; set; }
        #endregion
        
        #region Parameter PersistentAppUIId
        /// <summary>
        /// <para>
        /// <para>The persistent application user interface ID associated with the presigned URL.</para>
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
        public System.String PersistentAppUIId { get; set; }
        #endregion
        
        #region Parameter PersistentAppUIType
        /// <summary>
        /// <para>
        /// <para>The persistent application user interface type associated with the presigned URL.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ElasticMapReduce.PersistentAppUIType")]
        public Amazon.ElasticMapReduce.PersistentAppUIType PersistentAppUIType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticMapReduce.Model.GetPersistentAppUIPresignedURLResponse).
        /// Specifying the name of a property of type Amazon.ElasticMapReduce.Model.GetPersistentAppUIPresignedURLResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.ElasticMapReduce.Model.GetPersistentAppUIPresignedURLResponse, GetEMRPersistentAppUIPresignedURLCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApplicationId = this.ApplicationId;
            context.AuthProxyCall = this.AuthProxyCall;
            context.ExecutionRoleArn = this.ExecutionRoleArn;
            context.PersistentAppUIId = this.PersistentAppUIId;
            #if MODULAR
            if (this.PersistentAppUIId == null && ParameterWasBound(nameof(this.PersistentAppUIId)))
            {
                WriteWarning("You are passing $null as a value for parameter PersistentAppUIId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PersistentAppUIType = this.PersistentAppUIType;
            
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
            var request = new Amazon.ElasticMapReduce.Model.GetPersistentAppUIPresignedURLRequest();
            
            if (cmdletContext.ApplicationId != null)
            {
                request.ApplicationId = cmdletContext.ApplicationId;
            }
            if (cmdletContext.AuthProxyCall != null)
            {
                request.AuthProxyCall = cmdletContext.AuthProxyCall.Value;
            }
            if (cmdletContext.ExecutionRoleArn != null)
            {
                request.ExecutionRoleArn = cmdletContext.ExecutionRoleArn;
            }
            if (cmdletContext.PersistentAppUIId != null)
            {
                request.PersistentAppUIId = cmdletContext.PersistentAppUIId;
            }
            if (cmdletContext.PersistentAppUIType != null)
            {
                request.PersistentAppUIType = cmdletContext.PersistentAppUIType;
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
        
        private Amazon.ElasticMapReduce.Model.GetPersistentAppUIPresignedURLResponse CallAWSServiceOperation(IAmazonElasticMapReduce client, Amazon.ElasticMapReduce.Model.GetPersistentAppUIPresignedURLRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic MapReduce", "GetPersistentAppUIPresignedURL");
            try
            {
                return client.GetPersistentAppUIPresignedURLAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ApplicationId { get; set; }
            public System.Boolean? AuthProxyCall { get; set; }
            public System.String ExecutionRoleArn { get; set; }
            public System.String PersistentAppUIId { get; set; }
            public Amazon.ElasticMapReduce.PersistentAppUIType PersistentAppUIType { get; set; }
            public System.Func<Amazon.ElasticMapReduce.Model.GetPersistentAppUIPresignedURLResponse, GetEMRPersistentAppUIPresignedURLCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
