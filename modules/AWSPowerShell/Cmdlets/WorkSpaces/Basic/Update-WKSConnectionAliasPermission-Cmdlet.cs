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
using Amazon.WorkSpaces;
using Amazon.WorkSpaces.Model;

namespace Amazon.PowerShell.Cmdlets.WKS
{
    /// <summary>
    /// Shares or unshares a connection alias with one account by specifying whether that
    /// account has permission to associate the connection alias with a directory. If the
    /// association permission is granted, the connection alias is shared with that account.
    /// If the association permission is revoked, the connection alias is unshared with the
    /// account. For more information, see <a href="https://docs.aws.amazon.com/workspaces/latest/adminguide/cross-region-redirection.html">
    /// Cross-Region Redirection for Amazon WorkSpaces</a>.
    /// 
    ///  <note><ul><li><para>
    /// Before performing this operation, call <a href="https://docs.aws.amazon.com/workspaces/latest/api/API_DescribeConnectionAliases.html">
    /// DescribeConnectionAliases</a> to make sure that the current state of the connection
    /// alias is <c>CREATED</c>.
    /// </para></li><li><para>
    /// To delete a connection alias that has been shared, the shared account must first disassociate
    /// the connection alias from any directories it has been associated with. Then you must
    /// unshare the connection alias from the account it has been shared with. You can delete
    /// a connection alias only after it is no longer shared with any accounts or associated
    /// with any directories.
    /// </para></li></ul></note>
    /// </summary>
    [Cmdlet("Update", "WKSConnectionAliasPermission", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon WorkSpaces UpdateConnectionAliasPermission API operation.", Operation = new[] {"UpdateConnectionAliasPermission"}, SelectReturnType = typeof(Amazon.WorkSpaces.Model.UpdateConnectionAliasPermissionResponse))]
    [AWSCmdletOutput("None or Amazon.WorkSpaces.Model.UpdateConnectionAliasPermissionResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.WorkSpaces.Model.UpdateConnectionAliasPermissionResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateWKSConnectionAliasPermissionCmdlet : AmazonWorkSpacesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AliasId
        /// <summary>
        /// <para>
        /// <para>The identifier of the connection alias that you want to update permissions for.</para>
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
        public System.String AliasId { get; set; }
        #endregion
        
        #region Parameter ConnectionAliasPermission_AllowAssociation
        /// <summary>
        /// <para>
        /// <para>Indicates whether the specified Amazon Web Services account is allowed to associate
        /// the connection alias with a directory.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Boolean? ConnectionAliasPermission_AllowAssociation { get; set; }
        #endregion
        
        #region Parameter ConnectionAliasPermission_SharedAccountId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Web Services account that the connection alias is shared
        /// with.</para>
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
        public System.String ConnectionAliasPermission_SharedAccountId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WorkSpaces.Model.UpdateConnectionAliasPermissionResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AliasId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AliasId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AliasId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AliasId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-WKSConnectionAliasPermission (UpdateConnectionAliasPermission)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WorkSpaces.Model.UpdateConnectionAliasPermissionResponse, UpdateWKSConnectionAliasPermissionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AliasId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AliasId = this.AliasId;
            #if MODULAR
            if (this.AliasId == null && ParameterWasBound(nameof(this.AliasId)))
            {
                WriteWarning("You are passing $null as a value for parameter AliasId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ConnectionAliasPermission_AllowAssociation = this.ConnectionAliasPermission_AllowAssociation;
            #if MODULAR
            if (this.ConnectionAliasPermission_AllowAssociation == null && ParameterWasBound(nameof(this.ConnectionAliasPermission_AllowAssociation)))
            {
                WriteWarning("You are passing $null as a value for parameter ConnectionAliasPermission_AllowAssociation which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ConnectionAliasPermission_SharedAccountId = this.ConnectionAliasPermission_SharedAccountId;
            #if MODULAR
            if (this.ConnectionAliasPermission_SharedAccountId == null && ParameterWasBound(nameof(this.ConnectionAliasPermission_SharedAccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter ConnectionAliasPermission_SharedAccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.WorkSpaces.Model.UpdateConnectionAliasPermissionRequest();
            
            if (cmdletContext.AliasId != null)
            {
                request.AliasId = cmdletContext.AliasId;
            }
            
             // populate ConnectionAliasPermission
            var requestConnectionAliasPermissionIsNull = true;
            request.ConnectionAliasPermission = new Amazon.WorkSpaces.Model.ConnectionAliasPermission();
            System.Boolean? requestConnectionAliasPermission_connectionAliasPermission_AllowAssociation = null;
            if (cmdletContext.ConnectionAliasPermission_AllowAssociation != null)
            {
                requestConnectionAliasPermission_connectionAliasPermission_AllowAssociation = cmdletContext.ConnectionAliasPermission_AllowAssociation.Value;
            }
            if (requestConnectionAliasPermission_connectionAliasPermission_AllowAssociation != null)
            {
                request.ConnectionAliasPermission.AllowAssociation = requestConnectionAliasPermission_connectionAliasPermission_AllowAssociation.Value;
                requestConnectionAliasPermissionIsNull = false;
            }
            System.String requestConnectionAliasPermission_connectionAliasPermission_SharedAccountId = null;
            if (cmdletContext.ConnectionAliasPermission_SharedAccountId != null)
            {
                requestConnectionAliasPermission_connectionAliasPermission_SharedAccountId = cmdletContext.ConnectionAliasPermission_SharedAccountId;
            }
            if (requestConnectionAliasPermission_connectionAliasPermission_SharedAccountId != null)
            {
                request.ConnectionAliasPermission.SharedAccountId = requestConnectionAliasPermission_connectionAliasPermission_SharedAccountId;
                requestConnectionAliasPermissionIsNull = false;
            }
             // determine if request.ConnectionAliasPermission should be set to null
            if (requestConnectionAliasPermissionIsNull)
            {
                request.ConnectionAliasPermission = null;
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
        
        private Amazon.WorkSpaces.Model.UpdateConnectionAliasPermissionResponse CallAWSServiceOperation(IAmazonWorkSpaces client, Amazon.WorkSpaces.Model.UpdateConnectionAliasPermissionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon WorkSpaces", "UpdateConnectionAliasPermission");
            try
            {
                #if DESKTOP
                return client.UpdateConnectionAliasPermission(request);
                #elif CORECLR
                return client.UpdateConnectionAliasPermissionAsync(request).GetAwaiter().GetResult();
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
            public System.String AliasId { get; set; }
            public System.Boolean? ConnectionAliasPermission_AllowAssociation { get; set; }
            public System.String ConnectionAliasPermission_SharedAccountId { get; set; }
            public System.Func<Amazon.WorkSpaces.Model.UpdateConnectionAliasPermissionResponse, UpdateWKSConnectionAliasPermissionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
