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
using Amazon.RAM;
using Amazon.RAM.Model;

namespace Amazon.PowerShell.Cmdlets.RAM
{
    /// <summary>
    /// Creates a resource share. You can provide a list of the <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">Amazon
    /// Resource Names (ARNs)</a> for the resources that you want to share, a list of principals
    /// you want to share the resources with, and the permissions to grant those principals.
    /// 
    ///  <note><para>
    /// Sharing a resource makes it available for use by principals outside of the Amazon
    /// Web Services account that created the resource. Sharing doesn't change any permissions
    /// or quotas that apply to the resource in the account that created it.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "RAMResourceShare", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RAM.Model.ResourceShare")]
    [AWSCmdlet("Calls the AWS Resource Access Manager (RAM) CreateResourceShare API operation.", Operation = new[] {"CreateResourceShare"}, SelectReturnType = typeof(Amazon.RAM.Model.CreateResourceShareResponse))]
    [AWSCmdletOutput("Amazon.RAM.Model.ResourceShare or Amazon.RAM.Model.CreateResourceShareResponse",
        "This cmdlet returns an Amazon.RAM.Model.ResourceShare object.",
        "The service call response (type Amazon.RAM.Model.CreateResourceShareResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewRAMResourceShareCmdlet : AmazonRAMClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AllowExternalPrincipal
        /// <summary>
        /// <para>
        /// <para>Specifies whether principals outside your organization in Organizations can be associated
        /// with a resource share. A value of <c>true</c> lets you share with individual Amazon
        /// Web Services accounts that are <i>not</i> in your organization. A value of <c>false</c>
        /// only has meaning if your account is a member of an Amazon Web Services Organization.
        /// The default value is <c>true</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AllowExternalPrincipals")]
        public System.Boolean? AllowExternalPrincipal { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Specifies the name of the resource share.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter PermissionArn
        /// <summary>
        /// <para>
        /// <para>Specifies the <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">Amazon
        /// Resource Names (ARNs)</a> of the RAM permission to associate with the resource share.
        /// If you do not specify an ARN for the permission, RAM automatically attaches the default
        /// version of the permission for each resource type. You can associate only one permission
        /// with each resource type included in the resource share.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PermissionArns")]
        public System.String[] PermissionArn { get; set; }
        #endregion
        
        #region Parameter Principal
        /// <summary>
        /// <para>
        /// <para>Specifies a list of one or more principals to associate with the resource share.</para><para>You can include the following values:</para><ul><li><para>An Amazon Web Services account ID, for example: <c>123456789012</c></para></li><li><para>An <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">Amazon
        /// Resource Name (ARN)</a> of an organization in Organizations, for example: <c>organizations::123456789012:organization/o-exampleorgid</c></para></li><li><para>An ARN of an organizational unit (OU) in Organizations, for example: <c>organizations::123456789012:ou/o-exampleorgid/ou-examplerootid-exampleouid123</c></para></li><li><para>An ARN of an IAM role, for example: <c>iam::123456789012:role/rolename</c></para></li><li><para>An ARN of an IAM user, for example: <c>iam::123456789012user/username</c></para></li></ul><note><para>Not all resource types can be shared with IAM roles and users. For more information,
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
        /// <para>Specifies a list of one or more ARNs of the resources to associate with the resource
        /// share.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceArns")]
        public System.String[] ResourceArn { get; set; }
        #endregion
        
        #region Parameter Source
        /// <summary>
        /// <para>
        /// <para>Specifies from which source accounts the service principal has access to the resources
        /// in this resource share.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Sources")]
        public System.String[] Source { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Specifies one or more tags to attach to the resource share itself. It doesn't attach
        /// the tags to the resources associated with the resource share.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.RAM.Model.Tag[] Tag { get; set; }
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ResourceShare'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RAM.Model.CreateResourceShareResponse).
        /// Specifying the name of a property of type Amazon.RAM.Model.CreateResourceShareResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ResourceShare";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-RAMResourceShare (CreateResourceShare)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RAM.Model.CreateResourceShareResponse, NewRAMResourceShareCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AllowExternalPrincipal = this.AllowExternalPrincipal;
            context.ClientToken = this.ClientToken;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.PermissionArn != null)
            {
                context.PermissionArn = new List<System.String>(this.PermissionArn);
            }
            if (this.Principal != null)
            {
                context.Principal = new List<System.String>(this.Principal);
            }
            if (this.ResourceArn != null)
            {
                context.ResourceArn = new List<System.String>(this.ResourceArn);
            }
            if (this.Source != null)
            {
                context.Source = new List<System.String>(this.Source);
            }
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.RAM.Model.Tag>(this.Tag);
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
            var request = new Amazon.RAM.Model.CreateResourceShareRequest();
            
            if (cmdletContext.AllowExternalPrincipal != null)
            {
                request.AllowExternalPrincipals = cmdletContext.AllowExternalPrincipal.Value;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.PermissionArn != null)
            {
                request.PermissionArns = cmdletContext.PermissionArn;
            }
            if (cmdletContext.Principal != null)
            {
                request.Principals = cmdletContext.Principal;
            }
            if (cmdletContext.ResourceArn != null)
            {
                request.ResourceArns = cmdletContext.ResourceArn;
            }
            if (cmdletContext.Source != null)
            {
                request.Sources = cmdletContext.Source;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.RAM.Model.CreateResourceShareResponse CallAWSServiceOperation(IAmazonRAM client, Amazon.RAM.Model.CreateResourceShareRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Resource Access Manager (RAM)", "CreateResourceShare");
            try
            {
                #if DESKTOP
                return client.CreateResourceShare(request);
                #elif CORECLR
                return client.CreateResourceShareAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? AllowExternalPrincipal { get; set; }
            public System.String ClientToken { get; set; }
            public System.String Name { get; set; }
            public List<System.String> PermissionArn { get; set; }
            public List<System.String> Principal { get; set; }
            public List<System.String> ResourceArn { get; set; }
            public List<System.String> Source { get; set; }
            public List<Amazon.RAM.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.RAM.Model.CreateResourceShareResponse, NewRAMResourceShareCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ResourceShare;
        }
        
    }
}
