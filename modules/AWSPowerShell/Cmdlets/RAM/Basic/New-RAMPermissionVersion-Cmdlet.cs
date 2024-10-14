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
using Amazon.RAM;
using Amazon.RAM.Model;

namespace Amazon.PowerShell.Cmdlets.RAM
{
    /// <summary>
    /// Creates a new version of the specified customer managed permission. The new version
    /// is automatically set as the default version of the customer managed permission. New
    /// resource shares automatically use the default permission. Existing resource shares
    /// continue to use their original permission versions, but you can use <a>ReplacePermissionAssociations</a>
    /// to update them.
    /// 
    ///  
    /// <para>
    /// If the specified customer managed permission already has the maximum of 5 versions,
    /// then you must delete one of the existing versions before you can create a new one.
    /// </para>
    /// </summary>
    [Cmdlet("New", "RAMPermissionVersion", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RAM.Model.ResourceSharePermissionDetail")]
    [AWSCmdlet("Calls the AWS Resource Access Manager (RAM) CreatePermissionVersion API operation.", Operation = new[] {"CreatePermissionVersion"}, SelectReturnType = typeof(Amazon.RAM.Model.CreatePermissionVersionResponse))]
    [AWSCmdletOutput("Amazon.RAM.Model.ResourceSharePermissionDetail or Amazon.RAM.Model.CreatePermissionVersionResponse",
        "This cmdlet returns an Amazon.RAM.Model.ResourceSharePermissionDetail object.",
        "The service call response (type Amazon.RAM.Model.CreatePermissionVersionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewRAMPermissionVersionCmdlet : AmazonRAMClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter PermissionArn
        /// <summary>
        /// <para>
        /// <para>Specifies the <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">Amazon
        /// Resource Name (ARN)</a> of the customer managed permission you're creating a new version
        /// for.</para>
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
        public System.String PermissionArn { get; set; }
        #endregion
        
        #region Parameter PolicyTemplate
        /// <summary>
        /// <para>
        /// <para>A string in JSON format string that contains the following elements of a resource-based
        /// policy:</para><ul><li><para><b>Effect</b>: must be set to <c>ALLOW</c>.</para></li><li><para><b>Action</b>: specifies the actions that are allowed by this customer managed permission.
        /// The list must contain only actions that are supported by the specified resource type.
        /// For a list of all actions supported by each resource type, see <a href="https://docs.aws.amazon.com/service-authorization/latest/reference/reference_policies_actions-resources-contextkeys.html">Actions,
        /// resources, and condition keys for Amazon Web Services services</a> in the <i>Identity
        /// and Access Management User Guide</i>.</para></li><li><para><b>Condition</b>: (optional) specifies conditional parameters that must evaluate
        /// to true when a user attempts an action for that action to be allowed. For more information
        /// about the Condition element, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/reference_policies_elements_condition.html">IAM
        /// policies: Condition element</a> in the <i>Identity and Access Management User Guide</i>.</para></li></ul><para>This template can't include either the <c>Resource</c> or <c>Principal</c> elements.
        /// Those are both filled in by RAM when it instantiates the resource-based policy on
        /// each resource shared using this managed permission. The <c>Resource</c> comes from
        /// the ARN of the specific resource that you are sharing. The <c>Principal</c> comes
        /// from the list of identities added to the resource share.</para>
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
        public System.String PolicyTemplate { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Specifies a unique, case-sensitive identifier that you provide to ensure the idempotency
        /// of the request. This lets you safely retry the request without accidentally performing
        /// the same operation a second time. Passing the same value to a later call to an operation
        /// requires that you also pass the same value for all other parameters. We recommend
        /// that you use a <a href="https://wikipedia.org/wiki/Universally_unique_identifier">UUID
        /// type of value.</a>.</para><para>If you don't provide this value, then Amazon Web Services generates a random one for
        /// you.</para><para>If you retry the operation with the same <c>ClientToken</c>, but with different parameters,
        /// the retry fails with an <c>IdempotentParameterMismatch</c> error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Permission'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RAM.Model.CreatePermissionVersionResponse).
        /// Specifying the name of a property of type Amazon.RAM.Model.CreatePermissionVersionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Permission";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the PermissionArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^PermissionArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^PermissionArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PermissionArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-RAMPermissionVersion (CreatePermissionVersion)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RAM.Model.CreatePermissionVersionResponse, NewRAMPermissionVersionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.PermissionArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.PermissionArn = this.PermissionArn;
            #if MODULAR
            if (this.PermissionArn == null && ParameterWasBound(nameof(this.PermissionArn)))
            {
                WriteWarning("You are passing $null as a value for parameter PermissionArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PolicyTemplate = this.PolicyTemplate;
            #if MODULAR
            if (this.PolicyTemplate == null && ParameterWasBound(nameof(this.PolicyTemplate)))
            {
                WriteWarning("You are passing $null as a value for parameter PolicyTemplate which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.RAM.Model.CreatePermissionVersionRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.PermissionArn != null)
            {
                request.PermissionArn = cmdletContext.PermissionArn;
            }
            if (cmdletContext.PolicyTemplate != null)
            {
                request.PolicyTemplate = cmdletContext.PolicyTemplate;
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
        
        private Amazon.RAM.Model.CreatePermissionVersionResponse CallAWSServiceOperation(IAmazonRAM client, Amazon.RAM.Model.CreatePermissionVersionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Resource Access Manager (RAM)", "CreatePermissionVersion");
            try
            {
                #if DESKTOP
                return client.CreatePermissionVersion(request);
                #elif CORECLR
                return client.CreatePermissionVersionAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String PermissionArn { get; set; }
            public System.String PolicyTemplate { get; set; }
            public System.Func<Amazon.RAM.Model.CreatePermissionVersionResponse, NewRAMPermissionVersionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Permission;
        }
        
    }
}
