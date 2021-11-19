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
    /// Adds the specified list of principals and list of resources to a resource share. Principals
    /// that already have access to this resource share immediately receive access to the
    /// added resources. Newly added principals immediately receive access to the resources
    /// shared in this resource share.
    /// </summary>
    [Cmdlet("Connect", "RAMResourceShare", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RAM.Model.ResourceShareAssociation")]
    [AWSCmdlet("Calls the AWS Resource Access Manager (RAM) AssociateResourceShare API operation.", Operation = new[] {"AssociateResourceShare"}, SelectReturnType = typeof(Amazon.RAM.Model.AssociateResourceShareResponse))]
    [AWSCmdletOutput("Amazon.RAM.Model.ResourceShareAssociation or Amazon.RAM.Model.AssociateResourceShareResponse",
        "This cmdlet returns a collection of Amazon.RAM.Model.ResourceShareAssociation objects.",
        "The service call response (type Amazon.RAM.Model.AssociateResourceShareResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class ConnectRAMResourceShareCmdlet : AmazonRAMClientCmdlet, IExecutor
    {
        
        #region Parameter Principal
        /// <summary>
        /// <para>
        /// <para>Specifies a list of principals to whom you want to the resource share. This can be
        /// <code>null</code> if you want to add only resources.</para><para>What the principals can do with the resources in the share is determined by the RAM
        /// permissions that you associate with the resource share. See <a>AssociateResourceSharePermission</a>.</para><para>You can include the following values:</para><ul><li><para>An Amazon Web Services account ID, for example: <code>123456789012</code></para></li><li><para>An <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">Amazon
        /// Resoure Name (ARN)</a> of an organization in Organizations, for example: <code>organizations::123456789012:organization/o-exampleorgid</code></para></li><li><para>An ARN of an organizational unit (OU) in Organizations, for example: <code>organizations::123456789012:ou/o-exampleorgid/ou-examplerootid-exampleouid123</code></para></li><li><para>An ARN of an IAM role, for example: <code>iam::123456789012:role/rolename</code></para></li><li><para>An ARN of an IAM user, for example: <code>iam::123456789012user/username</code></para></li></ul><note><para>Not all resource types can be shared with IAM roles and users. For more information,
        /// see <a href="https://docs.aws.amazon.com/ram/latest/userguide/permissions.html#permissions-rbp-supported-resource-types">Sharing
        /// with IAM roles and users</a> in the <i>Resource Access Manager User Guide</i>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Principals")]
        public System.String[] Principal { get; set; }
        #endregion
        
        #region Parameter ResourceArn
        /// <summary>
        /// <para>
        /// <para>Specifies a list of <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">Amazon
        /// Resource Names (ARNs)</a> of the resources that you want to share. This can be <code>null</code>
        /// if you want to add only principals.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceArns")]
        public System.String[] ResourceArn { get; set; }
        #endregion
        
        #region Parameter ResourceShareArn
        /// <summary>
        /// <para>
        /// <para>Specifies the <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">Amazon
        /// Resoure Name (ARN)</a> of the resource share that you want to add principals or resources
        /// to.</para>
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
        public System.String ResourceShareArn { get; set; }
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
        /// you.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ResourceShareAssociations'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RAM.Model.AssociateResourceShareResponse).
        /// Specifying the name of a property of type Amazon.RAM.Model.AssociateResourceShareResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ResourceShareAssociations";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ResourceShareArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ResourceShareArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ResourceShareArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ResourceShareArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Connect-RAMResourceShare (AssociateResourceShare)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RAM.Model.AssociateResourceShareResponse, ConnectRAMResourceShareCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ResourceShareArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            if (this.Principal != null)
            {
                context.Principal = new List<System.String>(this.Principal);
            }
            if (this.ResourceArn != null)
            {
                context.ResourceArn = new List<System.String>(this.ResourceArn);
            }
            context.ResourceShareArn = this.ResourceShareArn;
            #if MODULAR
            if (this.ResourceShareArn == null && ParameterWasBound(nameof(this.ResourceShareArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceShareArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.RAM.Model.AssociateResourceShareRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Principal != null)
            {
                request.Principals = cmdletContext.Principal;
            }
            if (cmdletContext.ResourceArn != null)
            {
                request.ResourceArns = cmdletContext.ResourceArn;
            }
            if (cmdletContext.ResourceShareArn != null)
            {
                request.ResourceShareArn = cmdletContext.ResourceShareArn;
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
        
        private Amazon.RAM.Model.AssociateResourceShareResponse CallAWSServiceOperation(IAmazonRAM client, Amazon.RAM.Model.AssociateResourceShareRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Resource Access Manager (RAM)", "AssociateResourceShare");
            try
            {
                #if DESKTOP
                return client.AssociateResourceShare(request);
                #elif CORECLR
                return client.AssociateResourceShareAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> Principal { get; set; }
            public List<System.String> ResourceArn { get; set; }
            public System.String ResourceShareArn { get; set; }
            public System.Func<Amazon.RAM.Model.AssociateResourceShareResponse, ConnectRAMResourceShareCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ResourceShareAssociations;
        }
        
    }
}
