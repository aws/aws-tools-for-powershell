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
using Amazon.IdentityManagement;
using Amazon.IdentityManagement.Model;

namespace Amazon.PowerShell.Cmdlets.IAM
{
    /// <summary>
    /// Enables the management of privileged root user credentials across member accounts
    /// in your organization. When you enable root credentials management for <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/id_root-user.html#id_root-user-access-management">centralized
    /// root access</a>, the management account and the delegated admininstrator for IAM can
    /// manage root user credentials for member accounts in your organization.
    /// 
    ///  
    /// <para>
    /// Before you enable centralized root access, you must have an account configured with
    /// the following settings:
    /// </para><ul><li><para>
    /// You must manage your Amazon Web Services accounts in <a href="https://docs.aws.amazon.com/organizations/latest/userguide/orgs_introduction.html">Organizations</a>.
    /// </para></li><li><para>
    /// Enable trusted access for Identity and Access Management in Organizations. For details,
    /// see <a href="https://docs.aws.amazon.com/organizations/latest/userguide/services-that-can-integrate-ra.html">IAM
    /// and Organizations</a> in the <i>Organizations User Guide</i>.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Enable", "IAMOrganizationsRootCredentialsManagement", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IdentityManagement.Model.EnableOrganizationsRootCredentialsManagementResponse")]
    [AWSCmdlet("Calls the AWS Identity and Access Management EnableOrganizationsRootCredentialsManagement API operation.", Operation = new[] {"EnableOrganizationsRootCredentialsManagement"}, SelectReturnType = typeof(Amazon.IdentityManagement.Model.EnableOrganizationsRootCredentialsManagementResponse))]
    [AWSCmdletOutput("Amazon.IdentityManagement.Model.EnableOrganizationsRootCredentialsManagementResponse",
        "This cmdlet returns an Amazon.IdentityManagement.Model.EnableOrganizationsRootCredentialsManagementResponse object containing multiple properties."
    )]
    public partial class EnableIAMOrganizationsRootCredentialsManagementCmdlet : AmazonIdentityManagementServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IdentityManagement.Model.EnableOrganizationsRootCredentialsManagementResponse).
        /// Specifying the name of a property of type Amazon.IdentityManagement.Model.EnableOrganizationsRootCredentialsManagementResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Enable-IAMOrganizationsRootCredentialsManagement (EnableOrganizationsRootCredentialsManagement)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IdentityManagement.Model.EnableOrganizationsRootCredentialsManagementResponse, EnableIAMOrganizationsRootCredentialsManagementCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
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
            var request = new Amazon.IdentityManagement.Model.EnableOrganizationsRootCredentialsManagementRequest();
            
            
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
        
        private Amazon.IdentityManagement.Model.EnableOrganizationsRootCredentialsManagementResponse CallAWSServiceOperation(IAmazonIdentityManagementService client, Amazon.IdentityManagement.Model.EnableOrganizationsRootCredentialsManagementRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Identity and Access Management", "EnableOrganizationsRootCredentialsManagement");
            try
            {
                #if DESKTOP
                return client.EnableOrganizationsRootCredentialsManagement(request);
                #elif CORECLR
                return client.EnableOrganizationsRootCredentialsManagementAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.IdentityManagement.Model.EnableOrganizationsRootCredentialsManagementResponse, EnableIAMOrganizationsRootCredentialsManagementCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
