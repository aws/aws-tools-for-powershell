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
using Amazon.StorageGateway;
using Amazon.StorageGateway.Model;

namespace Amazon.PowerShell.Cmdlets.SG
{
    /// <summary>
    /// Updates the list of Active Directory users and groups that have special permissions
    /// for SMB file shares on the gateway.
    /// </summary>
    [Cmdlet("Update", "SGSGSMBLocalGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Storage Gateway UpdateSMBLocalGroups API operation.", Operation = new[] {"UpdateSMBLocalGroups"}, SelectReturnType = typeof(Amazon.StorageGateway.Model.UpdateSMBLocalGroupsResponse))]
    [AWSCmdletOutput("System.String or Amazon.StorageGateway.Model.UpdateSMBLocalGroupsResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.StorageGateway.Model.UpdateSMBLocalGroupsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateSGSGSMBLocalGroupCmdlet : AmazonStorageGatewayClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter SMBLocalGroups_GatewayAdmin
        /// <summary>
        /// <para>
        /// <para>A list of Active Directory users and groups that have local Gateway Admin permissions.
        /// Acceptable formats include: <c>DOMAIN\User1</c>, <c>user1</c>, <c>DOMAIN\group1</c>,
        /// and <c>group1</c>.</para><para>Gateway Admins can use the Shared Folders Microsoft Management Console snap-in to
        /// force-close files that are open and locked.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SMBLocalGroups_GatewayAdmins")]
        public System.String[] SMBLocalGroups_GatewayAdmin { get; set; }
        #endregion
        
        #region Parameter GatewayARN
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        public System.String GatewayARN { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'GatewayARN'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.StorageGateway.Model.UpdateSMBLocalGroupsResponse).
        /// Specifying the name of a property of type Amazon.StorageGateway.Model.UpdateSMBLocalGroupsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "GatewayARN";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the GatewayARN parameter.
        /// The -PassThru parameter is deprecated, use -Select '^GatewayARN' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^GatewayARN' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.GatewayARN), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SGSGSMBLocalGroup (UpdateSMBLocalGroups)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.StorageGateway.Model.UpdateSMBLocalGroupsResponse, UpdateSGSGSMBLocalGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.GatewayARN;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.GatewayARN = this.GatewayARN;
            #if MODULAR
            if (this.GatewayARN == null && ParameterWasBound(nameof(this.GatewayARN)))
            {
                WriteWarning("You are passing $null as a value for parameter GatewayARN which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.SMBLocalGroups_GatewayAdmin != null)
            {
                context.SMBLocalGroups_GatewayAdmin = new List<System.String>(this.SMBLocalGroups_GatewayAdmin);
            }
            
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
            var request = new Amazon.StorageGateway.Model.UpdateSMBLocalGroupsRequest();
            
            if (cmdletContext.GatewayARN != null)
            {
                request.GatewayARN = cmdletContext.GatewayARN;
            }
            
             // populate SMBLocalGroups
            var requestSMBLocalGroupsIsNull = true;
            request.SMBLocalGroups = new Amazon.StorageGateway.Model.SMBLocalGroups();
            List<System.String> requestSMBLocalGroups_sMBLocalGroups_GatewayAdmin = null;
            if (cmdletContext.SMBLocalGroups_GatewayAdmin != null)
            {
                requestSMBLocalGroups_sMBLocalGroups_GatewayAdmin = cmdletContext.SMBLocalGroups_GatewayAdmin;
            }
            if (requestSMBLocalGroups_sMBLocalGroups_GatewayAdmin != null)
            {
                request.SMBLocalGroups.GatewayAdmins = requestSMBLocalGroups_sMBLocalGroups_GatewayAdmin;
                requestSMBLocalGroupsIsNull = false;
            }
             // determine if request.SMBLocalGroups should be set to null
            if (requestSMBLocalGroupsIsNull)
            {
                request.SMBLocalGroups = null;
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
        
        private Amazon.StorageGateway.Model.UpdateSMBLocalGroupsResponse CallAWSServiceOperation(IAmazonStorageGateway client, Amazon.StorageGateway.Model.UpdateSMBLocalGroupsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Storage Gateway", "UpdateSMBLocalGroups");
            try
            {
                #if DESKTOP
                return client.UpdateSMBLocalGroups(request);
                #elif CORECLR
                return client.UpdateSMBLocalGroupsAsync(request).GetAwaiter().GetResult();
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
            public System.String GatewayARN { get; set; }
            public List<System.String> SMBLocalGroups_GatewayAdmin { get; set; }
            public System.Func<Amazon.StorageGateway.Model.UpdateSMBLocalGroupsResponse, UpdateSGSGSMBLocalGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.GatewayARN;
        }
        
    }
}
