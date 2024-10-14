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
using Amazon.ManagedGrafana;
using Amazon.ManagedGrafana.Model;

namespace Amazon.PowerShell.Cmdlets.MGRF
{
    /// <summary>
    /// Lists the users and groups who have the Grafana <c>Admin</c> and <c>Editor</c> roles
    /// in this workspace. If you use this operation without specifying <c>userId</c> or <c>groupId</c>,
    /// the operation returns the roles of all users and groups. If you specify a <c>userId</c>
    /// or a <c>groupId</c>, only the roles for that user or group are returned. If you do
    /// this, you can specify only one <c>userId</c> or one <c>groupId</c>.
    /// </summary>
    [Cmdlet("Get", "MGRFPermissionList")]
    [OutputType("Amazon.ManagedGrafana.Model.ListPermissionsResponse")]
    [AWSCmdlet("Calls the Amazon Managed Grafana ListPermissions API operation.", Operation = new[] {"ListPermissions"}, SelectReturnType = typeof(Amazon.ManagedGrafana.Model.ListPermissionsResponse))]
    [AWSCmdletOutput("Amazon.ManagedGrafana.Model.ListPermissionsResponse",
        "This cmdlet returns an Amazon.ManagedGrafana.Model.ListPermissionsResponse object containing multiple properties."
    )]
    public partial class GetMGRFPermissionListCmdlet : AmazonManagedGrafanaClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter GroupId
        /// <summary>
        /// <para>
        /// <para>(Optional) Limits the results to only the group that matches this ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GroupId { get; set; }
        #endregion
        
        #region Parameter UserId
        /// <summary>
        /// <para>
        /// <para>(Optional) Limits the results to only the user that matches this ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UserId { get; set; }
        #endregion
        
        #region Parameter UserType
        /// <summary>
        /// <para>
        /// <para>(Optional) If you specify <c>SSO_USER</c>, then only the permissions of IAM Identity
        /// Center users are returned. If you specify <c>SSO_GROUP</c>, only the permissions of
        /// IAM Identity Center groups are returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ManagedGrafana.UserType")]
        public Amazon.ManagedGrafana.UserType UserType { get; set; }
        #endregion
        
        #region Parameter WorkspaceId
        /// <summary>
        /// <para>
        /// <para>The ID of the workspace to list permissions for. This parameter is required.</para>
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
        public System.String WorkspaceId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to include in the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token to use when requesting the next set of results. You received this token
        /// from a previous <c>ListPermissions</c> operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ManagedGrafana.Model.ListPermissionsResponse).
        /// Specifying the name of a property of type Amazon.ManagedGrafana.Model.ListPermissionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the WorkspaceId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^WorkspaceId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^WorkspaceId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ManagedGrafana.Model.ListPermissionsResponse, GetMGRFPermissionListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.WorkspaceId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.GroupId = this.GroupId;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.UserId = this.UserId;
            context.UserType = this.UserType;
            context.WorkspaceId = this.WorkspaceId;
            #if MODULAR
            if (this.WorkspaceId == null && ParameterWasBound(nameof(this.WorkspaceId)))
            {
                WriteWarning("You are passing $null as a value for parameter WorkspaceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ManagedGrafana.Model.ListPermissionsRequest();
            
            if (cmdletContext.GroupId != null)
            {
                request.GroupId = cmdletContext.GroupId;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.UserId != null)
            {
                request.UserId = cmdletContext.UserId;
            }
            if (cmdletContext.UserType != null)
            {
                request.UserType = cmdletContext.UserType;
            }
            if (cmdletContext.WorkspaceId != null)
            {
                request.WorkspaceId = cmdletContext.WorkspaceId;
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
        
        private Amazon.ManagedGrafana.Model.ListPermissionsResponse CallAWSServiceOperation(IAmazonManagedGrafana client, Amazon.ManagedGrafana.Model.ListPermissionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Managed Grafana", "ListPermissions");
            try
            {
                #if DESKTOP
                return client.ListPermissions(request);
                #elif CORECLR
                return client.ListPermissionsAsync(request).GetAwaiter().GetResult();
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
            public System.String GroupId { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String UserId { get; set; }
            public Amazon.ManagedGrafana.UserType UserType { get; set; }
            public System.String WorkspaceId { get; set; }
            public System.Func<Amazon.ManagedGrafana.Model.ListPermissionsResponse, GetMGRFPermissionListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
