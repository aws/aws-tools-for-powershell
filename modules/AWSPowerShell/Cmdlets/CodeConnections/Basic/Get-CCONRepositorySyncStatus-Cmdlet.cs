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
using Amazon.CodeConnections;
using Amazon.CodeConnections.Model;

namespace Amazon.PowerShell.Cmdlets.CCON
{
    /// <summary>
    /// Returns details about the sync status for a repository. A repository sync uses Git
    /// sync to push and pull changes from your remote repository.
    /// </summary>
    [Cmdlet("Get", "CCONRepositorySyncStatus")]
    [OutputType("Amazon.CodeConnections.Model.RepositorySyncAttempt")]
    [AWSCmdlet("Calls the AWS CodeConnections GetRepositorySyncStatus API operation.", Operation = new[] {"GetRepositorySyncStatus"}, SelectReturnType = typeof(Amazon.CodeConnections.Model.GetRepositorySyncStatusResponse))]
    [AWSCmdletOutput("Amazon.CodeConnections.Model.RepositorySyncAttempt or Amazon.CodeConnections.Model.GetRepositorySyncStatusResponse",
        "This cmdlet returns an Amazon.CodeConnections.Model.RepositorySyncAttempt object.",
        "The service call response (type Amazon.CodeConnections.Model.GetRepositorySyncStatusResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCCONRepositorySyncStatusCmdlet : AmazonCodeConnectionsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Branch
        /// <summary>
        /// <para>
        /// <para>The branch of the repository link for the requested repository sync status.</para>
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
        public System.String Branch { get; set; }
        #endregion
        
        #region Parameter RepositoryLinkId
        /// <summary>
        /// <para>
        /// <para>The repository link ID for the requested repository sync status.</para>
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
        /// <para>The sync type of the requested sync status.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'LatestSync'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeConnections.Model.GetRepositorySyncStatusResponse).
        /// Specifying the name of a property of type Amazon.CodeConnections.Model.GetRepositorySyncStatusResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "LatestSync";
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
                context.Select = CreateSelectDelegate<Amazon.CodeConnections.Model.GetRepositorySyncStatusResponse, GetCCONRepositorySyncStatusCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Branch = this.Branch;
            #if MODULAR
            if (this.Branch == null && ParameterWasBound(nameof(this.Branch)))
            {
                WriteWarning("You are passing $null as a value for parameter Branch which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.CodeConnections.Model.GetRepositorySyncStatusRequest();
            
            if (cmdletContext.Branch != null)
            {
                request.Branch = cmdletContext.Branch;
            }
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
        
        private Amazon.CodeConnections.Model.GetRepositorySyncStatusResponse CallAWSServiceOperation(IAmazonCodeConnections client, Amazon.CodeConnections.Model.GetRepositorySyncStatusRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeConnections", "GetRepositorySyncStatus");
            try
            {
                #if DESKTOP
                return client.GetRepositorySyncStatus(request);
                #elif CORECLR
                return client.GetRepositorySyncStatusAsync(request).GetAwaiter().GetResult();
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
            public System.String Branch { get; set; }
            public System.String RepositoryLinkId { get; set; }
            public Amazon.CodeConnections.SyncConfigurationType SyncType { get; set; }
            public System.Func<Amazon.CodeConnections.Model.GetRepositorySyncStatusResponse, GetCCONRepositorySyncStatusCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.LatestSync;
        }
        
    }
}
