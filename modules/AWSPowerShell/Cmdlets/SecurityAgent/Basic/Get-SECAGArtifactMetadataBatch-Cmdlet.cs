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
using Amazon.SecurityAgent;
using Amazon.SecurityAgent.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SECAG
{
    /// <summary>
    /// Retrieves metadata for one or more artifacts in an agent space.
    /// </summary>
    [Cmdlet("Get", "SECAGArtifactMetadataBatch")]
    [OutputType("Amazon.SecurityAgent.Model.ArtifactMetadataItem")]
    [AWSCmdlet("Calls the AWS Security Agent BatchGetArtifactMetadata API operation.", Operation = new[] {"BatchGetArtifactMetadata"}, SelectReturnType = typeof(Amazon.SecurityAgent.Model.BatchGetArtifactMetadataResponse))]
    [AWSCmdletOutput("Amazon.SecurityAgent.Model.ArtifactMetadataItem or Amazon.SecurityAgent.Model.BatchGetArtifactMetadataResponse",
        "This cmdlet returns a collection of Amazon.SecurityAgent.Model.ArtifactMetadataItem objects.",
        "The service call response (type Amazon.SecurityAgent.Model.BatchGetArtifactMetadataResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetSECAGArtifactMetadataBatchCmdlet : AmazonSecurityAgentClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AgentSpaceId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the agent space that contains the artifacts.</para>
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
        public System.String AgentSpaceId { get; set; }
        #endregion
        
        #region Parameter ArtifactId
        /// <summary>
        /// <para>
        /// <para>The list of artifact identifiers to retrieve metadata for.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("ArtifactIds")]
        public System.String[] ArtifactId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ArtifactMetadataList'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityAgent.Model.BatchGetArtifactMetadataResponse).
        /// Specifying the name of a property of type Amazon.SecurityAgent.Model.BatchGetArtifactMetadataResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ArtifactMetadataList";
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
                context.Select = CreateSelectDelegate<Amazon.SecurityAgent.Model.BatchGetArtifactMetadataResponse, GetSECAGArtifactMetadataBatchCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AgentSpaceId = this.AgentSpaceId;
            #if MODULAR
            if (this.AgentSpaceId == null && ParameterWasBound(nameof(this.AgentSpaceId)))
            {
                WriteWarning("You are passing $null as a value for parameter AgentSpaceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ArtifactId != null)
            {
                context.ArtifactId = new List<System.String>(this.ArtifactId);
            }
            #if MODULAR
            if (this.ArtifactId == null && ParameterWasBound(nameof(this.ArtifactId)))
            {
                WriteWarning("You are passing $null as a value for parameter ArtifactId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SecurityAgent.Model.BatchGetArtifactMetadataRequest();
            
            if (cmdletContext.AgentSpaceId != null)
            {
                request.AgentSpaceId = cmdletContext.AgentSpaceId;
            }
            if (cmdletContext.ArtifactId != null)
            {
                request.ArtifactIds = cmdletContext.ArtifactId;
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
        
        private Amazon.SecurityAgent.Model.BatchGetArtifactMetadataResponse CallAWSServiceOperation(IAmazonSecurityAgent client, Amazon.SecurityAgent.Model.BatchGetArtifactMetadataRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Security Agent", "BatchGetArtifactMetadata");
            try
            {
                return client.BatchGetArtifactMetadataAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AgentSpaceId { get; set; }
            public List<System.String> ArtifactId { get; set; }
            public System.Func<Amazon.SecurityAgent.Model.BatchGetArtifactMetadataResponse, GetSECAGArtifactMetadataBatchCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ArtifactMetadataList;
        }
        
    }
}
