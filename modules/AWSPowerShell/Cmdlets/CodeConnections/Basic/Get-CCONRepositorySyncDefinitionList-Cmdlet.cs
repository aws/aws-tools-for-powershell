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
using Amazon.CodeConnections;
using Amazon.CodeConnections.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CCON
{
    /// <summary>
    /// Lists the repository sync definitions for repository links in your account.
    /// </summary>
    [Cmdlet("Get", "CCONRepositorySyncDefinitionList")]
    [OutputType("Amazon.CodeConnections.Model.RepositorySyncDefinition")]
    [AWSCmdlet("Calls the AWS CodeConnections ListRepositorySyncDefinitions API operation.", Operation = new[] {"ListRepositorySyncDefinitions"}, SelectReturnType = typeof(Amazon.CodeConnections.Model.ListRepositorySyncDefinitionsResponse))]
    [AWSCmdletOutput("Amazon.CodeConnections.Model.RepositorySyncDefinition or Amazon.CodeConnections.Model.ListRepositorySyncDefinitionsResponse",
        "This cmdlet returns a collection of Amazon.CodeConnections.Model.RepositorySyncDefinition objects.",
        "The service call response (type Amazon.CodeConnections.Model.ListRepositorySyncDefinitionsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCCONRepositorySyncDefinitionListCmdlet : AmazonCodeConnectionsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter RepositoryLinkId
        /// <summary>
        /// <para>
        /// <para>The ID of the repository link for the sync definition for which you want to retrieve
        /// information.</para>
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
        public System.String RepositoryLinkId { get; set; }
        #endregion
        
        #region Parameter SyncType
        /// <summary>
        /// <para>
        /// <para>The sync type of the repository link for the the sync definition for which you want
        /// to retrieve information.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CodeConnections.SyncConfigurationType")]
        public Amazon.CodeConnections.SyncConfigurationType SyncType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RepositorySyncDefinitions'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeConnections.Model.ListRepositorySyncDefinitionsResponse).
        /// Specifying the name of a property of type Amazon.CodeConnections.Model.ListRepositorySyncDefinitionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RepositorySyncDefinitions";
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
                context.Select = CreateSelectDelegate<Amazon.CodeConnections.Model.ListRepositorySyncDefinitionsResponse, GetCCONRepositorySyncDefinitionListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.RepositoryLinkId = this.RepositoryLinkId;
            #if MODULAR
            if (this.RepositoryLinkId == null && ParameterWasBound(nameof(this.RepositoryLinkId)))
            {
                WriteWarning("You are passing $null as a value for parameter RepositoryLinkId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SyncType = this.SyncType;
            #if MODULAR
            if (this.SyncType == null && ParameterWasBound(nameof(this.SyncType)))
            {
                WriteWarning("You are passing $null as a value for parameter SyncType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CodeConnections.Model.ListRepositorySyncDefinitionsRequest();
            
            if (cmdletContext.RepositoryLinkId != null)
            {
                request.RepositoryLinkId = cmdletContext.RepositoryLinkId;
            }
            if (cmdletContext.SyncType != null)
            {
                request.SyncType = cmdletContext.SyncType;
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
        
        private Amazon.CodeConnections.Model.ListRepositorySyncDefinitionsResponse CallAWSServiceOperation(IAmazonCodeConnections client, Amazon.CodeConnections.Model.ListRepositorySyncDefinitionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeConnections", "ListRepositorySyncDefinitions");
            try
            {
                return client.ListRepositorySyncDefinitionsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String RepositoryLinkId { get; set; }
            public Amazon.CodeConnections.SyncConfigurationType SyncType { get; set; }
            public System.Func<Amazon.CodeConnections.Model.ListRepositorySyncDefinitionsResponse, GetCCONRepositorySyncDefinitionListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RepositorySyncDefinitions;
        }
        
    }
}
