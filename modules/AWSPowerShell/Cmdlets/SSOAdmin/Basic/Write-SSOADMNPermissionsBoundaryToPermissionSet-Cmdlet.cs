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
using Amazon.SSOAdmin;
using Amazon.SSOAdmin.Model;

namespace Amazon.PowerShell.Cmdlets.SSOADMN
{
    /// <summary>
    /// Attaches an AWS managed or customer managed policy to the specified <a>PermissionSet</a>
    /// as a permissions boundary.
    /// </summary>
    [Cmdlet("Write", "SSOADMNPermissionsBoundaryToPermissionSet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Single Sign-On Admin PutPermissionsBoundaryToPermissionSet API operation.", Operation = new[] {"PutPermissionsBoundaryToPermissionSet"}, SelectReturnType = typeof(Amazon.SSOAdmin.Model.PutPermissionsBoundaryToPermissionSetResponse))]
    [AWSCmdletOutput("None or Amazon.SSOAdmin.Model.PutPermissionsBoundaryToPermissionSetResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SSOAdmin.Model.PutPermissionsBoundaryToPermissionSetResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteSSOADMNPermissionsBoundaryToPermissionSetCmdlet : AmazonSSOAdminClientCmdlet, IExecutor
    {
        
        #region Parameter InstanceArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM Identity Center instance under which the operation will be executed.
        /// </para>
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
        public System.String InstanceArn { get; set; }
        #endregion
        
        #region Parameter PermissionsBoundary_ManagedPolicyArn
        /// <summary>
        /// <para>
        /// <para>The AWS managed policy ARN that you want to attach to a permission set as a permissions
        /// boundary.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PermissionsBoundary_ManagedPolicyArn { get; set; }
        #endregion
        
        #region Parameter CustomerManagedPolicyReference_Name
        /// <summary>
        /// <para>
        /// <para>The name of the IAM policy that you have configured in each account where you want
        /// to deploy your permission set.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PermissionsBoundary_CustomerManagedPolicyReference_Name")]
        public System.String CustomerManagedPolicyReference_Name { get; set; }
        #endregion
        
        #region Parameter CustomerManagedPolicyReference_Path
        /// <summary>
        /// <para>
        /// <para>The path to the IAM policy that you have configured in each account where you want
        /// to deploy your permission set. The default is <code>/</code>. For more information,
        /// see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/reference_identifiers.html#identifiers-friendly-names">Friendly
        /// names and paths</a> in the <i>IAM User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PermissionsBoundary_CustomerManagedPolicyReference_Path")]
        public System.String CustomerManagedPolicyReference_Path { get; set; }
        #endregion
        
        #region Parameter PermissionSetArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the <code>PermissionSet</code>.</para>
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
        public System.String PermissionSetArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SSOAdmin.Model.PutPermissionsBoundaryToPermissionSetResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the PermissionSetArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^PermissionSetArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^PermissionSetArn' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PermissionSetArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-SSOADMNPermissionsBoundaryToPermissionSet (PutPermissionsBoundaryToPermissionSet)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SSOAdmin.Model.PutPermissionsBoundaryToPermissionSetResponse, WriteSSOADMNPermissionsBoundaryToPermissionSetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.PermissionSetArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.InstanceArn = this.InstanceArn;
            #if MODULAR
            if (this.InstanceArn == null && ParameterWasBound(nameof(this.InstanceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CustomerManagedPolicyReference_Name = this.CustomerManagedPolicyReference_Name;
            context.CustomerManagedPolicyReference_Path = this.CustomerManagedPolicyReference_Path;
            context.PermissionsBoundary_ManagedPolicyArn = this.PermissionsBoundary_ManagedPolicyArn;
            context.PermissionSetArn = this.PermissionSetArn;
            #if MODULAR
            if (this.PermissionSetArn == null && ParameterWasBound(nameof(this.PermissionSetArn)))
            {
                WriteWarning("You are passing $null as a value for parameter PermissionSetArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SSOAdmin.Model.PutPermissionsBoundaryToPermissionSetRequest();
            
            if (cmdletContext.InstanceArn != null)
            {
                request.InstanceArn = cmdletContext.InstanceArn;
            }
            
             // populate PermissionsBoundary
            var requestPermissionsBoundaryIsNull = true;
            request.PermissionsBoundary = new Amazon.SSOAdmin.Model.PermissionsBoundary();
            System.String requestPermissionsBoundary_permissionsBoundary_ManagedPolicyArn = null;
            if (cmdletContext.PermissionsBoundary_ManagedPolicyArn != null)
            {
                requestPermissionsBoundary_permissionsBoundary_ManagedPolicyArn = cmdletContext.PermissionsBoundary_ManagedPolicyArn;
            }
            if (requestPermissionsBoundary_permissionsBoundary_ManagedPolicyArn != null)
            {
                request.PermissionsBoundary.ManagedPolicyArn = requestPermissionsBoundary_permissionsBoundary_ManagedPolicyArn;
                requestPermissionsBoundaryIsNull = false;
            }
            Amazon.SSOAdmin.Model.CustomerManagedPolicyReference requestPermissionsBoundary_permissionsBoundary_CustomerManagedPolicyReference = null;
            
             // populate CustomerManagedPolicyReference
            var requestPermissionsBoundary_permissionsBoundary_CustomerManagedPolicyReferenceIsNull = true;
            requestPermissionsBoundary_permissionsBoundary_CustomerManagedPolicyReference = new Amazon.SSOAdmin.Model.CustomerManagedPolicyReference();
            System.String requestPermissionsBoundary_permissionsBoundary_CustomerManagedPolicyReference_customerManagedPolicyReference_Name = null;
            if (cmdletContext.CustomerManagedPolicyReference_Name != null)
            {
                requestPermissionsBoundary_permissionsBoundary_CustomerManagedPolicyReference_customerManagedPolicyReference_Name = cmdletContext.CustomerManagedPolicyReference_Name;
            }
            if (requestPermissionsBoundary_permissionsBoundary_CustomerManagedPolicyReference_customerManagedPolicyReference_Name != null)
            {
                requestPermissionsBoundary_permissionsBoundary_CustomerManagedPolicyReference.Name = requestPermissionsBoundary_permissionsBoundary_CustomerManagedPolicyReference_customerManagedPolicyReference_Name;
                requestPermissionsBoundary_permissionsBoundary_CustomerManagedPolicyReferenceIsNull = false;
            }
            System.String requestPermissionsBoundary_permissionsBoundary_CustomerManagedPolicyReference_customerManagedPolicyReference_Path = null;
            if (cmdletContext.CustomerManagedPolicyReference_Path != null)
            {
                requestPermissionsBoundary_permissionsBoundary_CustomerManagedPolicyReference_customerManagedPolicyReference_Path = cmdletContext.CustomerManagedPolicyReference_Path;
            }
            if (requestPermissionsBoundary_permissionsBoundary_CustomerManagedPolicyReference_customerManagedPolicyReference_Path != null)
            {
                requestPermissionsBoundary_permissionsBoundary_CustomerManagedPolicyReference.Path = requestPermissionsBoundary_permissionsBoundary_CustomerManagedPolicyReference_customerManagedPolicyReference_Path;
                requestPermissionsBoundary_permissionsBoundary_CustomerManagedPolicyReferenceIsNull = false;
            }
             // determine if requestPermissionsBoundary_permissionsBoundary_CustomerManagedPolicyReference should be set to null
            if (requestPermissionsBoundary_permissionsBoundary_CustomerManagedPolicyReferenceIsNull)
            {
                requestPermissionsBoundary_permissionsBoundary_CustomerManagedPolicyReference = null;
            }
            if (requestPermissionsBoundary_permissionsBoundary_CustomerManagedPolicyReference != null)
            {
                request.PermissionsBoundary.CustomerManagedPolicyReference = requestPermissionsBoundary_permissionsBoundary_CustomerManagedPolicyReference;
                requestPermissionsBoundaryIsNull = false;
            }
             // determine if request.PermissionsBoundary should be set to null
            if (requestPermissionsBoundaryIsNull)
            {
                request.PermissionsBoundary = null;
            }
            if (cmdletContext.PermissionSetArn != null)
            {
                request.PermissionSetArn = cmdletContext.PermissionSetArn;
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
        
        private Amazon.SSOAdmin.Model.PutPermissionsBoundaryToPermissionSetResponse CallAWSServiceOperation(IAmazonSSOAdmin client, Amazon.SSOAdmin.Model.PutPermissionsBoundaryToPermissionSetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Single Sign-On Admin", "PutPermissionsBoundaryToPermissionSet");
            try
            {
                #if DESKTOP
                return client.PutPermissionsBoundaryToPermissionSet(request);
                #elif CORECLR
                return client.PutPermissionsBoundaryToPermissionSetAsync(request).GetAwaiter().GetResult();
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
            public System.String InstanceArn { get; set; }
            public System.String CustomerManagedPolicyReference_Name { get; set; }
            public System.String CustomerManagedPolicyReference_Path { get; set; }
            public System.String PermissionsBoundary_ManagedPolicyArn { get; set; }
            public System.String PermissionSetArn { get; set; }
            public System.Func<Amazon.SSOAdmin.Model.PutPermissionsBoundaryToPermissionSetResponse, WriteSSOADMNPermissionsBoundaryToPermissionSetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
