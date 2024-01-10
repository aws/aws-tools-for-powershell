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
    /// Updates all resource shares that use a managed permission to a different managed permission.
    /// This operation always applies the default version of the target managed permission.
    /// You can optionally specify that the update applies to only resource shares that currently
    /// use a specified version. This enables you to update to the latest version, without
    /// changing the which managed permission is used.
    /// 
    ///  
    /// <para>
    /// You can use this operation to update all of your resource shares to use the current
    /// default version of the permission by specifying the same value for the <c>fromPermissionArn</c>
    /// and <c>toPermissionArn</c> parameters.
    /// </para><para>
    /// You can use the optional <c>fromPermissionVersion</c> parameter to update only those
    /// resources that use a specified version of the managed permission to the new managed
    /// permission.
    /// </para><important><para>
    /// To successfully perform this operation, you must have permission to update the resource-based
    /// policy on all affected resource types.
    /// </para></important>
    /// </summary>
    [Cmdlet("Edit", "RAMPermissionAssociation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RAM.Model.ReplacePermissionAssociationsWork")]
    [AWSCmdlet("Calls the AWS Resource Access Manager (RAM) ReplacePermissionAssociations API operation.", Operation = new[] {"ReplacePermissionAssociations"}, SelectReturnType = typeof(Amazon.RAM.Model.ReplacePermissionAssociationsResponse))]
    [AWSCmdletOutput("Amazon.RAM.Model.ReplacePermissionAssociationsWork or Amazon.RAM.Model.ReplacePermissionAssociationsResponse",
        "This cmdlet returns an Amazon.RAM.Model.ReplacePermissionAssociationsWork object.",
        "The service call response (type Amazon.RAM.Model.ReplacePermissionAssociationsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditRAMPermissionAssociationCmdlet : AmazonRAMClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter FromPermissionArn
        /// <summary>
        /// <para>
        /// <para>Specifies the <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">Amazon
        /// Resource Name (ARN)</a> of the managed permission that you want to replace.</para>
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
        public System.String FromPermissionArn { get; set; }
        #endregion
        
        #region Parameter FromPermissionVersion
        /// <summary>
        /// <para>
        /// <para>Specifies that you want to updated the permissions for only those resource shares
        /// that use the specified version of the managed permission.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? FromPermissionVersion { get; set; }
        #endregion
        
        #region Parameter ToPermissionArn
        /// <summary>
        /// <para>
        /// <para>Specifies the ARN of the managed permission that you want to associate with resource
        /// shares in place of the one specified by <c>fromPerssionArn</c> and <c>fromPermissionVersion</c>.</para><para>The operation always associates the version that is currently the default for the
        /// specified managed permission.</para>
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
        public System.String ToPermissionArn { get; set; }
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ReplacePermissionAssociationsWork'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RAM.Model.ReplacePermissionAssociationsResponse).
        /// Specifying the name of a property of type Amazon.RAM.Model.ReplacePermissionAssociationsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ReplacePermissionAssociationsWork";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the FromPermissionArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^FromPermissionArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^FromPermissionArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FromPermissionArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-RAMPermissionAssociation (ReplacePermissionAssociations)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RAM.Model.ReplacePermissionAssociationsResponse, EditRAMPermissionAssociationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.FromPermissionArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.FromPermissionArn = this.FromPermissionArn;
            #if MODULAR
            if (this.FromPermissionArn == null && ParameterWasBound(nameof(this.FromPermissionArn)))
            {
                WriteWarning("You are passing $null as a value for parameter FromPermissionArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FromPermissionVersion = this.FromPermissionVersion;
            context.ToPermissionArn = this.ToPermissionArn;
            #if MODULAR
            if (this.ToPermissionArn == null && ParameterWasBound(nameof(this.ToPermissionArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ToPermissionArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.RAM.Model.ReplacePermissionAssociationsRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.FromPermissionArn != null)
            {
                request.FromPermissionArn = cmdletContext.FromPermissionArn;
            }
            if (cmdletContext.FromPermissionVersion != null)
            {
                request.FromPermissionVersion = cmdletContext.FromPermissionVersion.Value;
            }
            if (cmdletContext.ToPermissionArn != null)
            {
                request.ToPermissionArn = cmdletContext.ToPermissionArn;
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
        
        private Amazon.RAM.Model.ReplacePermissionAssociationsResponse CallAWSServiceOperation(IAmazonRAM client, Amazon.RAM.Model.ReplacePermissionAssociationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Resource Access Manager (RAM)", "ReplacePermissionAssociations");
            try
            {
                #if DESKTOP
                return client.ReplacePermissionAssociations(request);
                #elif CORECLR
                return client.ReplacePermissionAssociationsAsync(request).GetAwaiter().GetResult();
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
            public System.String FromPermissionArn { get; set; }
            public System.Int32? FromPermissionVersion { get; set; }
            public System.String ToPermissionArn { get; set; }
            public System.Func<Amazon.RAM.Model.ReplacePermissionAssociationsResponse, EditRAMPermissionAssociationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ReplacePermissionAssociationsWork;
        }
        
    }
}
