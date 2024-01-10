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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Modifies the ID format of a resource for a specified IAM user, IAM role, or the root
    /// user for an account; or all IAM users, IAM roles, and the root user for an account.
    /// You can specify that resources should receive longer IDs (17-character IDs) when they
    /// are created. 
    /// 
    ///  
    /// <para>
    /// This request can only be used to modify longer ID settings for resource types that
    /// are within the opt-in period. Resources currently in their opt-in period include:
    /// <c>bundle</c> | <c>conversion-task</c> | <c>customer-gateway</c> | <c>dhcp-options</c>
    /// | <c>elastic-ip-allocation</c> | <c>elastic-ip-association</c> | <c>export-task</c>
    /// | <c>flow-log</c> | <c>image</c> | <c>import-task</c> | <c>internet-gateway</c> |
    /// <c>network-acl</c> | <c>network-acl-association</c> | <c>network-interface</c> | <c>network-interface-attachment</c>
    /// | <c>prefix-list</c> | <c>route-table</c> | <c>route-table-association</c> | <c>security-group</c>
    /// | <c>subnet</c> | <c>subnet-cidr-block-association</c> | <c>vpc</c> | <c>vpc-cidr-block-association</c>
    /// | <c>vpc-endpoint</c> | <c>vpc-peering-connection</c> | <c>vpn-connection</c> | <c>vpn-gateway</c>.
    /// 
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/resource-ids.html">Resource
    /// IDs</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>. 
    /// </para><para>
    /// This setting applies to the principal specified in the request; it does not apply
    /// to the principal that makes the request. 
    /// </para><para>
    /// Resources created with longer IDs are visible to all IAM roles and users, regardless
    /// of these settings and provided that they have permission to use the relevant <c>Describe</c>
    /// command for the resource type.
    /// </para>
    /// </summary>
    [Cmdlet("Edit", "EC2IdentityIdFormat", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) ModifyIdentityIdFormat API operation.", Operation = new[] {"ModifyIdentityIdFormat"}, SelectReturnType = typeof(Amazon.EC2.Model.ModifyIdentityIdFormatResponse))]
    [AWSCmdletOutput("None or Amazon.EC2.Model.ModifyIdentityIdFormatResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.EC2.Model.ModifyIdentityIdFormatResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditEC2IdentityIdFormatCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter PrincipalArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the principal, which can be an IAM user, IAM role, or the root user. Specify
        /// <c>all</c> to modify the ID format for all IAM users, IAM roles, and the root user
        /// of the account.</para>
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
        public System.String PrincipalArn { get; set; }
        #endregion
        
        #region Parameter Resource
        /// <summary>
        /// <para>
        /// <para>The type of resource: <c>bundle</c> | <c>conversion-task</c> | <c>customer-gateway</c>
        /// | <c>dhcp-options</c> | <c>elastic-ip-allocation</c> | <c>elastic-ip-association</c>
        /// | <c>export-task</c> | <c>flow-log</c> | <c>image</c> | <c>import-task</c> | <c>internet-gateway</c>
        /// | <c>network-acl</c> | <c>network-acl-association</c> | <c>network-interface</c> |
        /// <c>network-interface-attachment</c> | <c>prefix-list</c> | <c>route-table</c> | <c>route-table-association</c>
        /// | <c>security-group</c> | <c>subnet</c> | <c>subnet-cidr-block-association</c> | <c>vpc</c>
        /// | <c>vpc-cidr-block-association</c> | <c>vpc-endpoint</c> | <c>vpc-peering-connection</c>
        /// | <c>vpn-connection</c> | <c>vpn-gateway</c>.</para><para>Alternatively, use the <c>all-current</c> option to include all resource types that
        /// are currently within their opt-in period for longer IDs.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Resource { get; set; }
        #endregion
        
        #region Parameter UseLongId
        /// <summary>
        /// <para>
        /// <para>Indicates whether the resource should use longer IDs (17-character IDs)</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("UseLongIds")]
        public System.Boolean? UseLongId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.ModifyIdentityIdFormatResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the PrincipalArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^PrincipalArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^PrincipalArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PrincipalArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2IdentityIdFormat (ModifyIdentityIdFormat)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.ModifyIdentityIdFormatResponse, EditEC2IdentityIdFormatCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.PrincipalArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.PrincipalArn = this.PrincipalArn;
            #if MODULAR
            if (this.PrincipalArn == null && ParameterWasBound(nameof(this.PrincipalArn)))
            {
                WriteWarning("You are passing $null as a value for parameter PrincipalArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Resource = this.Resource;
            #if MODULAR
            if (this.Resource == null && ParameterWasBound(nameof(this.Resource)))
            {
                WriteWarning("You are passing $null as a value for parameter Resource which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UseLongId = this.UseLongId;
            #if MODULAR
            if (this.UseLongId == null && ParameterWasBound(nameof(this.UseLongId)))
            {
                WriteWarning("You are passing $null as a value for parameter UseLongId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.ModifyIdentityIdFormatRequest();
            
            if (cmdletContext.PrincipalArn != null)
            {
                request.PrincipalArn = cmdletContext.PrincipalArn;
            }
            if (cmdletContext.Resource != null)
            {
                request.Resource = cmdletContext.Resource;
            }
            if (cmdletContext.UseLongId != null)
            {
                request.UseLongIds = cmdletContext.UseLongId.Value;
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
        
        private Amazon.EC2.Model.ModifyIdentityIdFormatResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ModifyIdentityIdFormatRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "ModifyIdentityIdFormat");
            try
            {
                #if DESKTOP
                return client.ModifyIdentityIdFormat(request);
                #elif CORECLR
                return client.ModifyIdentityIdFormatAsync(request).GetAwaiter().GetResult();
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
            public System.String PrincipalArn { get; set; }
            public System.String Resource { get; set; }
            public System.Boolean? UseLongId { get; set; }
            public System.Func<Amazon.EC2.Model.ModifyIdentityIdFormatResponse, EditEC2IdentityIdFormatCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
